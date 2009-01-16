using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using hwj.DBUtility.TableMapping;

namespace hwj.DBUtility.MSSQL
{
    public class GenerateSql<T> : BaseGenSql<T> where T : BaseTable, new()
    {
        private const string _MsSqlSelectString = "SELECT {0} {1} FROM {2} {3} {4} {5};";
        private const string _MsSqlTopCount = "top {0}";
        private const string _MsSqlInsertLastID = "SELECT @@IDENTITY AS 'Identity';";
        private const string _MsSqlPaging_RowCount = "EXEC dbo.Hwj_Paging_RowCount '{0}','{1}','{2}',{3},{4},'{5}','{6}','{7}'";
        private const string _MsSqlParam = "@{0}";
        private const string _MsSqlWhereParam = "@_{0}";
        private const string _MsSqlTruncate = "TRUNCATE TABLE {0};";

        #region Insert Sql
        public override string InsertLastIDSql()
        {
            return _MsSqlInsertLastID;
        }
        public override string InsertSql(T entity)
        {
            StringBuilder sbInsField = new StringBuilder();
            StringBuilder sbInsValue = new StringBuilder();
            if (entity.UseAssigned)
            {
                foreach (FieldMappingInfo f in FieldMappingInfo.GetFieldMapping(typeof(T)))
                {
                    if (entity.Assigned.IndexOf(f.FieldName) != -1)
                    {
                        object obj = f.Property.GetValue(entity, null);
                        if (obj != null)
                        {
                            if (!f.DataHandles.Find(Enums.DataHandle.UnInsert))
                            {
                                sbInsField.Append(f.FieldName).Append(',');
                                sbInsValue.AppendFormat(_MsSqlParam, f.FieldName).Append(',');
                            }
                        }
                    }
                }
            }
            else
            {
                foreach (FieldMappingInfo f in FieldMappingInfo.GetFieldMapping(typeof(T)))
                {
                    object obj = f.Property.GetValue(entity, null);
                    if (obj != null)
                    {
                        if (!f.DataHandles.Find(Enums.DataHandle.UnInsert))
                        {
                            sbInsField.Append(f.FieldName).Append(',');
                            sbInsValue.AppendFormat(_MsSqlParam, f.FieldName).Append(',');
                        }
                    }
                }
            }
            return string.Format(_InsertString, entity.GetType().Name, sbInsField.ToString().TrimEnd(','), sbInsValue.ToString().TrimEnd(','));
        }
        #endregion
        #region Delete Sql
        public override string TruncateSql(string tableName)
        {
            return string.Format(_MsSqlTruncate, tableName);
        }
        #endregion
        #region Select Sql
        public override string SelectSql(string tableName, DisplayFields displayFields, FilterParams filterParam, SortParams sortFields, int? maxCount)
        {
            return SelectSql(tableName, displayFields, filterParam, sortFields, maxCount, true);
        }
        public string SelectSql(string tableName, DisplayFields displayFields, FilterParams filterParam, SortParams sortFields, int? maxCount, bool isNoLock)
        {
            string sMaxCount = string.Empty;

            if (maxCount.HasValue && maxCount > 0)
            {
                sMaxCount = string.Format(_MsSqlTopCount, maxCount);
            }
            return string.Format(_MsSqlSelectString, sMaxCount, GenDisplayFieldsSql(displayFields), GetTableName(tableName), GetNoLock(isNoLock), GenFilterParamsSql(filterParam), GenSortParamsSql(sortFields));
        }
        /// <summary>
        /// 数据分页
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="selectFields">需要显示的字段</param>
        /// <param name="whereParam">筛选条件</param>
        /// <param name="orderParam">排序</param>
        /// <param name="PK">分页依据(关键字)</param>
        /// <param name="groupParam">分组显示</param>
        /// <param name="pageNumber">页数</param>
        /// <param name="pageSize">每页显示记录数</param>
        /// <returns></returns>
        public string SelectPageSql(string tableName, DisplayFields displayFields, FilterParams filterParam, SortParams sortParams, GroupParams groupParam, DisplayFields PK, int pageNumber, int pageSize)
        {
            string _SelectFields = GenDisplayFieldsSql(displayFields);
            string _FilterParam = GenFilterParamsSql(filterParam, true);
            string _OrderParam = GenSortParamsSql(sortParams, true);
            return string.Format(_MsSqlPaging_RowCount, GetTableName(tableName), GenDisplayFieldsSql(PK, true), _OrderParam, pageNumber, pageSize, _SelectFields, _FilterParam, GenGroupParamsSql(groupParam));
        }
        #endregion

        #region Private Functions
        protected override string GenFilterParamsSql(FilterParams listParam, bool isPage)
        {
            if (listParam != null && listParam.Count > 0)
            {
                StringBuilder sbWhere = new StringBuilder();
                if (!isPage)
                    sbWhere.Append("WHERE ");
                foreach (SqlParam para in listParam)
                {
                    if (para.Operator == Enums.Operator.IN)
                    {
                        StringBuilder inSql = new StringBuilder();
                        string[] s = (string[])para.FieldValue;

                        for (int i = 0; i < s.Length; i++)
                        {
                            inSql.AppendFormat(_MsSqlParam, "T" + i).Append(',');
                        }
                        sbWhere.Append(para.FieldName).AppendFormat(para.Operator.ToSqlString(), inSql.ToString().TrimEnd(',')).Append(para.Expression.ToSqlString());
                    }
                    else
                        sbWhere.Append(GetCondition(para, true, isPage));
                }
                //格式化最后的表达式，
                string sql = sbWhere.ToString().TrimEnd(',');
                int andL = Enums.Expression.AND.ToSqlString().Length;
                int andR = Enums.Expression.OR.ToSqlString().Length;
                if (sql.Substring(sql.Length - andL, andL) == Enums.Expression.AND.ToSqlString())
                    sql = sql.Substring(0, sql.Length - andL);
                if (sql.Substring(sql.Length - andR, andR) == Enums.Expression.OR.ToSqlString())
                    sql = sql.Substring(0, sql.Length - andR);
                return sql;
            }
            else
                return string.Empty;
        }
        protected override string GetCondition(SqlParam para, bool isFilter, bool isPage)
        {
            StringBuilder sbStr = new StringBuilder();
            FieldMappingInfo f = new FieldMappingInfo(FieldMappingInfo.GetFieldInfo(typeof(T), para.FieldName));
            string __MsSqlParam = string.Empty;
            if (isFilter)
                __MsSqlParam = _MsSqlWhereParam;
            else
                __MsSqlParam = _MsSqlParam;
            if (para.Operator == Enums.Operator.IsNotNull || para.Operator == Enums.Operator.IsNull)
                sbStr.Append(para.FieldName).Append(para.Operator.ToSqlString()).Append(para.Expression.ToSqlString());
            else if (isPage)
                sbStr.Append(para.FieldName).Append(para.Operator.ToSqlString()).Append('\'').Append('\'').Append(CheckSql(para.FieldValue.ToString())).Append('\'').Append('\'').Append(para.Expression.ToSqlString());
            else
                sbStr.Append(para.FieldName).Append(para.Operator.ToSqlString()).AppendFormat(__MsSqlParam, para.ParamName != null ? para.ParamName : para.FieldName).Append(para.Expression.ToSqlString());
            return sbStr.ToString();
        }
        private string GetNoLock(bool isNoLock)
        {
            if (isNoLock)
                return "(NOLOCK)";
            else
                return string.Empty;
        }
        #endregion

        #region Public Functions
        public List<SqlParameter> GenParameter(UpdateParam updateParam)
        {
            if (updateParam != null)
            {
                List<SqlParameter> LstDP = new List<SqlParameter>();
                foreach (UpdateFields up in updateParam)
                {
                    foreach (FieldMappingInfo f in FieldMappingInfo.GetFieldMapping(typeof(T)))
                    {
                        if (up.FieldName == f.FieldName)
                        {
                            SqlParameter dp = new SqlParameter();
                            dp.DbType = f.DataTypeCode;
                            dp.ParameterName = string.Format(_MsSqlParam, up.FieldName);
                            dp.Value = CheckValue(dp, up.FieldValue);
                            LstDP.Add(dp);
                            break;
                        }
                    }
                }
                return LstDP;
            }
            else
                return null;
        }
        public List<SqlParameter> GenParameter(FilterParams filterParam)
        {
            if (filterParam != null)
            {
                List<SqlParameter> LstDP = new List<SqlParameter>();
                foreach (SqlParam sp in filterParam)
                {
                    if (sp.Operator == Enums.Operator.IN)
                    {
                        string[] s = (string[])sp.FieldValue;
                        for (int i = 0; i < s.Length; i++)
                        {
                            SqlParameter p = new SqlParameter();
                            p.ParameterName = "T" + i;
                            p.Value = s[i].ToString();
                            LstDP.Add(p);
                        }
                    }
                    else if (sp.Operator == Enums.Operator.IsNotNull || sp.Operator == Enums.Operator.IsNull)
                    {
                    }
                    else
                    {
                        foreach (FieldMappingInfo f in FieldMappingInfo.GetFieldMapping(typeof(T)))
                        {
                            if (sp.FieldName == f.FieldName)
                            {
                                SqlParameter dp = new SqlParameter();
                                dp.DbType = f.DataTypeCode;
                                dp.ParameterName = string.Format(_MsSqlWhereParam, sp.ParamName != null ? sp.ParamName : sp.FieldName);
                                dp.Value = sp.FieldValue;
                                LstDP.Add(dp);
                                break;
                            }
                        }
                    }
                }
                return LstDP;
            }
            else
                return null;
        }

        public List<SqlParameter> GenParameter(T entity)
        {
            List<SqlParameter> LstDP = new List<SqlParameter>();
            if (entity.UseAssigned)
            {
                foreach (FieldMappingInfo f in FieldMappingInfo.GetFieldMapping(typeof(T)))
                {
                    if (entity.Assigned.IndexOf(f.FieldName) != -1)
                    {
                        SqlParameter dp = new SqlParameter();
                        dp.DbType = f.DataTypeCode;
                        dp.ParameterName = string.Format(_MsSqlParam, f.FieldName);
                        dp.Value = CheckValue(dp, f.Property.GetValue(entity, null));
                        LstDP.Add(dp);
                    }
                }
            }
            else
            {
                foreach (FieldMappingInfo f in FieldMappingInfo.GetFieldMapping(typeof(T)))
                {
                    SqlParameter dp = new SqlParameter();
                    object _value = f.Property.GetValue(entity, null);
                    dp.DbType = f.DataTypeCode;
                    dp.ParameterName = string.Format(_MsSqlParam, f.FieldName);
                    dp.Value = CheckValue(dp, f.Property.GetValue(entity, null));
                    LstDP.Add(dp);
                }
            }
            return LstDP;
        }
        private object CheckValue(SqlParameter param, object value)
        {
            if (IsDateType(param.DbType))
            {
                if (Convert.ToDateTime(value) == DateTime.MinValue)
                    return DBNull.Value;
            }
            return value;
        }
        #endregion
    }
}
