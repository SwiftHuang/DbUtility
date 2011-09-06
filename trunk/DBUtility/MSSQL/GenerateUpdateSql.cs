using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using hwj.DBUtility.TableMapping;

namespace hwj.DBUtility.MSSQL
{
    public class GenerateUpdateSql<T> : BaseGenUpdateSql<T> where T : BaseTable<T>, new()
    {
        //private const string _MsSqlSelectString = "SELECT {0} {1} FROM {2} {3} {4} {5};";
        //private const string _MsSqlTopCount = "top {0}";
        //private const string _MsSqlPaging_RowCount = "EXEC dbo.Hwj_Paging_RowCount @TableName,@FieldKey,@Sort,@PageIndex,@PageSize,@DisplayField,@Where,@Group,@_PTotalCount output";
        //private const string _MsSqlPageView = "EXEC dbo.sp_PageView @TableName,@FieldKey,@PageIndex,@PageSize,@DisplayField,@Sort,@Where,@_RecordCount output";
        private const string _MsSqlInsertLastID = "SELECT @@IDENTITY AS 'Identity';";
        private const string _MsSqlParam = "@{0}";
        private const string _MsSqlWhereParam = "@_{0}";
        private const string _MsSqlTruncate = "TRUNCATE TABLE {0};";
        private const string _MsSqlGetDate = "GetDate()";
        private const string _MsSqlFieldFmt = "[{0}]";

        /// <summary>
        /// SQL生成类
        /// </summary>
        public GenerateUpdateSql()
        {
            base.DatabaseGetDateSql = _MsSqlGetDate;
            _FieldFormat = _MsSqlFieldFmt;
        }

        #region Insert Sql
        /// <summary>
        /// 返回最后插入的标识值
        /// </summary>
        /// <returns></returns>
        public override string InsertLastIDSql()
        {
            return _MsSqlInsertLastID;
        }
        public override string InsertSql(T entity)
        {
            StringBuilder sbInsField = new StringBuilder();
            StringBuilder sbInsValue = new StringBuilder();
            if (entity.GetAssignedStatus())
            {
                foreach (FieldMappingInfo f in FieldMappingInfo.GetFieldMapping(typeof(T)))
                {
                    if (entity.GetAssigned().IndexOf(f.FieldName) != -1)
                    {
                        InsertSqlString(ref sbInsField, ref sbInsValue, f, entity);
                    }
                }
            }
            else
            {
                foreach (FieldMappingInfo f in FieldMappingInfo.GetFieldMapping(typeof(T)))
                {
                    InsertSqlString(ref sbInsField, ref sbInsValue, f, entity);
                }
            }
            return string.Format(_InsertString, entity.GetTableName(), sbInsField.ToString().TrimEnd(','), sbInsValue.ToString().TrimEnd(','));
        }
        private void InsertSqlString(ref StringBuilder insField, ref StringBuilder insValue, FieldMappingInfo field, T entity)
        {
            object obj = field.Property.GetValue(entity, null);
            if (obj != null)
            {
                if (!Enums.DataHandlesFind(field.DataHandles, Enums.DataHandle.UnInsert))
                {
                    insField.Append(field.FieldName).Append(',');
                    if (!IsDatabaseDate(field.DataTypeCode, obj))
                        insValue.AppendFormat(_MsSqlParam, field.FieldName).Append(',');
                    else
                        insValue.Append(_MsSqlGetDate).Append(',');
                }
            }
        }
        #endregion

        #region Delete Sql
        public override string TruncateSql(string tableName)
        {
            return string.Format(_MsSqlTruncate, tableName);
        }
        #endregion

        #region Private Functions
        /// <summary>
        /// 生成筛选SQL
        /// </summary>
        /// <param name="listParam"></param>
        /// <param name="isPage"></param>
        /// <returns></returns>
        protected override string GenFilterParamsSql(FilterParams listParam, bool isPage)
        {
            if (listParam != null && listParam.Count > 0)
            {
                StringBuilder sbWhere = new StringBuilder();
                int index = 0;
                if (!isPage)
                    sbWhere.Append("WHERE ");
                foreach (SqlParam para in listParam)
                {
                    if (string.IsNullOrEmpty(para.FieldName))
                    {
                        if (para.FieldValue.ToString() == ")")
                        {
                            string tmp = TrimSql(sbWhere.ToString());
                            sbWhere = new StringBuilder();
                            sbWhere.Append(tmp).Append(para.FieldValue).Append(Enums.ExpressionString(para.Expression));
                        }
                        else
                        {
                            sbWhere.Append(para.FieldValue);
                        }
                    }
                    else if (para.Operator == Enums.Relation.IN || para.Operator == Enums.Relation.NotIN
                        || para.Operator == Enums.Relation.IN_InsertSQL || para.Operator == Enums.Relation.NotIN_InsertSQL)
                    {
                        StringBuilder inSql = new StringBuilder();
                        string[] strList = GetSQL_IN_Value(para.FieldValue);
                        if (strList == null)
                        {
                            continue;
                        }

                        if (para.Operator == Enums.Relation.IN || para.Operator == Enums.Relation.NotIN)
                        {
                            foreach (string s in strList)
                            {
                                inSql.AppendFormat(_MsSqlParam, (para.ParamName != null ? para.ParamName : "T") + index).Append(',');
                                index++;
                            }
                        }
                        else
                        {
                            string tmpFormat = _StringFormat;
                            FieldMappingInfo f = FieldMappingInfo.GetFieldInfo(typeof(T), para.FieldName);
                            if (f != null)
                            {
                                if (IsNumType(f.DataTypeCode))
                                {
                                    tmpFormat = _DecimalFormat;
                                }

                                foreach (string s in strList)
                                {
                                    inSql.AppendFormat(tmpFormat, s).Append(',');
                                }
                            }
                        }

                        if (!string.IsNullOrEmpty(inSql.ToString()))
                        {
                            sbWhere.AppendFormat(_MsSqlFieldFmt, para.FieldName).AppendFormat(Enums.RelationString(para.Operator), inSql.ToString().TrimEnd(',')).Append(Enums.ExpressionString(para.Expression));
                        }
                    }
                    else
                    {
                        sbWhere.Append(GetCondition(para, true, isPage));
                    }
                }
                //格式化最后的表达式，
                return base.TrimSql(sbWhere.ToString());
            }
            else
                return string.Empty;
        }
        protected override string GetCondition(SqlParam para, bool isFilter, bool isPage)
        {
            StringBuilder sbStr = new StringBuilder();
            string __MsSqlParam = string.Empty;
            if (isFilter)
                __MsSqlParam = _MsSqlWhereParam;
            else
                __MsSqlParam = _MsSqlParam;

            sbStr.AppendFormat(_MsSqlFieldFmt, para.FieldName).Append(Enums.RelationString(para.Operator));

            if (para.Operator == Enums.Relation.IsNotNull || para.Operator == Enums.Relation.IsNull)
            {
                //sbStr.Append(para.Expression.ToSqlString());
            }
            else if (isPage)
            {
                sbStr.Append('\'');//.Append('\'');
                if (IsDatabaseDate(para))
                    sbStr.Append(_MsSqlGetDate);
                else
                    sbStr.Append(para.FieldValue.ToString());
                sbStr.Append('\'');//.Append('\'');
            }
            else if (IsDatabaseDate(para))
                sbStr.Append(_MsSqlGetDate);
            else
                sbStr.AppendFormat(__MsSqlParam, para.ParamName != null ? para.ParamName : para.FieldName);

            sbStr.Append(Enums.ExpressionString(para.Expression));
            return sbStr.ToString();
        }
        private string GetNoLock(bool isNoLock)
        {
            if (isNoLock)
                return "(NOLOCK)";
            else
                return string.Empty;
        }
        private SqlParameter GetSqlParameter(FieldMappingInfo field, T entity)
        {
            object value = field.Property.GetValue(entity, null);
            if (!IsDatabaseDate(field.DataTypeCode, value))
            {
                SqlParameter dp = new SqlParameter();
                dp.DbType = field.DataTypeCode;
                dp.ParameterName = string.Format(_MsSqlParam, field.FieldName);
                dp.Value = CheckValue(dp, value);
                return dp;
            }
            return null;
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

        #region Public Functions
        public List<SqlParameter> GenParameter(UpdateParam updateParam)
        {
            if (updateParam != null)
            {
                List<SqlParameter> LstDP = new List<SqlParameter>();
                foreach (UpdateFields up in updateParam)
                {
                    if (!IsDatabaseDate(up))
                    {
                        FieldMappingInfo f = FieldMappingInfo.GetFieldInfo(typeof(T), up.FieldName);
                        if (f != null)
                        {
                            SqlParameter dp = new SqlParameter();
                            dp.DbType = f.DataTypeCode;
                            dp.ParameterName = string.Format(_MsSqlParam, up.FieldName);
                            dp.Value = CheckValue(dp, up.FieldValue);
                            LstDP.Add(dp);
                        }
                    }
                }
                return LstDP;
            }
            else
            {
                return null;
            }
        }
        public List<SqlParameter> GenParameter(FilterParams filterParam)
        {
            if (filterParam != null)
            {
                List<SqlParameter> LstDP = new List<SqlParameter>();
                int index = 0;
                foreach (SqlParam sp in filterParam)
                {
                    if (IsDatabaseDate(sp))
                        continue;
                    if (sp.Operator == Enums.Relation.IN || sp.Operator == Enums.Relation.NotIN)
                    {
                        string[] strList = GetSQL_IN_Value(sp.FieldValue);
                        if (strList == null)
                        {
                            continue;
                        }

                        FieldMappingInfo f = FieldMappingInfo.GetFieldInfo(typeof(T), sp.FieldName);
                        if (f != null)
                        {
                            foreach (string s in strList)
                            {
                                SqlParameter p = new SqlParameter();
                                p.DbType = f.DataTypeCode;
                                p.ParameterName = (sp.ParamName != null ? sp.ParamName : "T") + index;
                                p.Value = s;
                                LstDP.Add(p);
                                index++;
                            }
                        }
                    }
                    else if (sp.Operator == Enums.Relation.IN_InsertSQL || sp.Operator == Enums.Relation.NotIN_InsertSQL)
                    {
                    }
                    else if (sp.Operator == Enums.Relation.IsNotNull || sp.Operator == Enums.Relation.IsNull)
                    {
                    }
                    else
                    {
                        FieldMappingInfo f = FieldMappingInfo.GetFieldInfo(typeof(T), sp.FieldName);
                        if (f != null)
                        {
                            SqlParameter dp = new SqlParameter();
                            dp.DbType = f.DataTypeCode;
                            dp.ParameterName = string.Format(_MsSqlWhereParam, sp.ParamName != null ? sp.ParamName : sp.FieldName);
                            dp.Value = sp.FieldValue;
                            LstDP.Add(dp);
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
            if (entity.GetAssignedStatus())
            {
                foreach (FieldMappingInfo f in FieldMappingInfo.GetFieldMapping(typeof(T)))
                {
                    if (entity.GetAssigned().IndexOf(f.FieldName) != -1)
                    {
                        SqlParameter dp = GetSqlParameter(f, entity);
                        if (dp != null)
                            LstDP.Add(dp);
                    }
                }
            }
            else
            {
                foreach (FieldMappingInfo f in FieldMappingInfo.GetFieldMapping(typeof(T)))
                {
                    SqlParameter dp = GetSqlParameter(f, entity);
                    if (dp != null)
                        LstDP.Add(dp);
                }
            }
            return LstDP;
        }
        #endregion
    }
}
