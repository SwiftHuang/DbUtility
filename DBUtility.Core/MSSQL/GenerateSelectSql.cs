using hwj.DBUtility.TableMapping;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace hwj.DBUtility.MSSQL
{
    public class GenerateSelectSql<T> : BaseGenSelectSql<T> where T : class, new()
    {
        //private const string _MsSqlInsertLastID = "SELECT @@IDENTITY AS 'Identity';";
        private const string _MsSqlSelectString = "SELECT {0} {1} FROM {2} {3} {4} {5};";

        private const string _MsSqlTopCount = "top {0}";
        private const string _MsSqlPaging_RowCount = "EXEC dbo.Hwj_Paging_RowCount @TableName,@FieldKey,@Sort,@PageIndex,@PageSize,@DisplayField,@Where,@Group,@_PTotalCount output";
        private const string _MsSqlPageView = "EXEC dbo.sp_PageView @TableName,@FieldKey,@PageIndex,@PageSize,@DisplayField,@Sort,@Where,@_RecordCount output";
        private const string _MsSqlParam = "@{0}";
        private const string _MsSqlWhereParam = "@_{0}";
        private const string _MsSqlGetDate = "GetDate()";
        private const string _MsSqlFieldFormat = "[{0}]";
        internal const string _ViewSqlFormat = "({0}) AS TEMPHWJ";

        /// <summary>
        /// SQL生成类
        /// </summary>
        public GenerateSelectSql()
        {
            base.DatabaseGetDateSql = _MsSqlGetDate;
            _FieldFormat = _MsSqlFieldFormat;
            _SqlParam = _MsSqlParam;
            _SqlWhereParam = _MsSqlWhereParam;
        }

        #region Select Sql

        public string SelectServerDateTime()
        {
            return "SELECT GETDATE() AS [DateTime]";
        }

        public override string SelectSql(string tableName, DisplayFields displayFields, FilterParams filterParams, SortParams sortFields, int? maxCount)
        {
            return SelectSql(tableName, displayFields, filterParams, sortFields, maxCount, new List<Enums.LockType>() { Enums.LockType.NoLock });
        }

        public string SelectSql(string tableName, DisplayFields displayFields, FilterParams filterParams, SortParams sortFields, int? maxCount, List<Enums.LockType> lockTypes)
        {
            string sMaxCount = string.Empty;

            if (maxCount.HasValue && maxCount >= 0)
            {
                sMaxCount = string.Format(_MsSqlTopCount, maxCount);
            }
            return string.Format(_MsSqlSelectString, sMaxCount, GenDisplayFieldsSql(displayFields), tableName, GetNoLocks(lockTypes), GenFilterParamsSql(filterParams), GenSortParamsSql(sortFields));
        }

        /// <summary>
        /// 数据分页
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="displayFields">需要显示的字段</param>
        /// <param name="filterParam">筛选条件</param>
        /// <param name="sortParams">排序</param>
        /// <param name="PK">分页依据(关键字)</param>
        /// <param name="groupParam">分组显示</param>
        /// <param name="pageNumber">页数</param>
        /// <param name="pageSize">每页显示记录数</param>
        /// <returns></returns>
        //public string GetGroupPageSql(string tableName, DisplayFields displayFields, FilterParams filterParam, SortParams sortParams, GroupParams groupParam, DisplayFields PK, int pageNumber, int pageSize)
        //{
        //    string _SelectFields = GenDisplayFieldsSql(displayFields);
        //    string _FilterParam = GenFilterParamsSql(filterParam, true);
        //    string _OrderParam = GenSortParamsSql(sortParams, true);
        //    return string.Format(_MsSqlPaging_RowCount, tableName, GenDisplayFieldsSql(PK, true), _OrderParam, pageNumber, pageSize, _SelectFields, _FilterParam, GenGroupParamsSql(groupParam));
        //}
        /// <summary>
        /// 数据分页
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="displayFields">需要显示的字段</param>
        /// <param name="filterParams">筛选条件</param>
        /// <param name="sortParams">排序</param>
        /// <param name="PK">分页依据(关键字)</param>
        /// <param name="groupParam">分组显示</param>
        /// <param name="pageNumber">页数</param>
        /// <param name="pageSize">每页显示记录数</param>
        /// <returns></returns>
        public SqlEntity GetGroupPageSqlEntity(string tableName, DisplayFields displayFields, FilterParams filterParams, SortParams sortParams, GroupParams groupParam, DisplayFields PK, int pageNumber, int pageSize)
        {
            SqlEntity SE = new SqlEntity();
            SE.CommandText = _MsSqlPaging_RowCount;
            SE.Parameters = new List<IDbDataParameter>();
            SE.Parameters.Add(new SqlParameter("@TableName", tableName));
            SE.Parameters.Add(new SqlParameter("@FieldKey", GenDisplayFieldsSql(PK, true)));
            SE.Parameters.Add(new SqlParameter("@PageIndex", pageNumber));
            SE.Parameters.Add(new SqlParameter("@PageSize", pageSize));
            SE.Parameters.Add(new SqlParameter("@DisplayField", GenDisplayFieldsSql(displayFields)));
            SE.Parameters.Add(new SqlParameter("@Sort", GenSortParamsSql(sortParams, true)));
            SE.Parameters.Add(new SqlParameter("@Where", GenFilterParamsSql(filterParams, true)));
            SE.Parameters.Add(new SqlParameter("@Group", GenGroupParamsSql(groupParam)));
            return SE;
        }

        //public string SelectPageSql2(string tableName, DisplayFields displayFields, FilterParams filterParam, SortParams sortParams, DisplayFields PK, int pageNumber, int pageSize)
        //{
        //    string _SelectFields = GenDisplayFieldsSql(displayFields);
        //    string _FilterParam = GenFilterParamsSql(filterParam, true);
        //    string _OrderParam = GenSortParamsSql(sortParams, true);
        //    return string.Format(_MsSqlPageView, tableName, GenDisplayFieldsSql(PK, true), pageNumber, pageSize, _SelectFields, _OrderParam, _FilterParam);
        //}
        public SqlEntity GetPageSqlEntity(string tableName, DisplayFields displayFields, FilterParams filterParams, SortParams sortParams, DisplayFields PK, int pageNumber, int pageSize)
        {
            SqlEntity SE = new SqlEntity();
            SE.CommandText = _MsSqlPageView;
            SE.Parameters = new List<IDbDataParameter>();
            SE.Parameters.Add(new SqlParameter("@TableName", tableName));
            SE.Parameters.Add(new SqlParameter("@FieldKey", GenDisplayFieldsSql(PK, true)));
            SE.Parameters.Add(new SqlParameter("@PageIndex", pageNumber));
            SE.Parameters.Add(new SqlParameter("@PageSize", pageSize));
            SE.Parameters.Add(new SqlParameter("@DisplayField", GenDisplayFieldsSql(displayFields)));
            //SQL的SP_PageView没有修正这个没有Order的问题，现在只靠代码来处理。
            if (sortParams != null && sortParams.Count > 0)
            {
                SE.Parameters.Add(new SqlParameter("@Sort", GenSortParamsSql(sortParams, true)));
            }
            else
            {
                SortParams sort = new SortParams();
                foreach (Enum e in PK)
                {
                    sort.AddParam(e, Enums.OrderBy.Ascending);
                }
                SE.Parameters.Add(new SqlParameter("@Sort", GenSortParamsSql(sort, true)));
            }
            SE.Parameters.Add(new SqlParameter("@Where", GenFilterParamsSql(filterParams, true)));
            return SE;
        }

        #endregion Select Sql

        #region Private Functions

        ///// <summary>
        ///// 生成筛选SQL
        ///// </summary>
        ///// <param name="listParam"></param>
        ///// <param name="isPage"></param>
        ///// <returns></returns>
        //protected override string GenFilterParamsSql(FilterParams listParam, bool isPage)
        //{
        //    if (listParam != null && listParam.Count > 0)
        //    {
        //        string strWhere = "WHERE ";
        //        StringBuilder sbWhere = new StringBuilder();
        //        int index = 0;
        //        if (!isPage)
        //            sbWhere.Append(strWhere);
        //        foreach (SqlParam para in listParam)
        //        {
        //            if (string.IsNullOrEmpty(para.FieldName))
        //            {
        //                if (para.FieldValue.ToString() == ")")
        //                {
        //                    string tmp = TrimSql(sbWhere.ToString());
        //                    sbWhere = new StringBuilder();
        //                    sbWhere.Append(tmp).Append(para.FieldValue).Append(Enums.ExpressionString(para.Expression));
        //                }
        //                else
        //                {
        //                    sbWhere.Append(para.FieldValue);
        //                }
        //            }
        //            else if (para.Operator == Enums.Relation.IN || para.Operator == Enums.Relation.NotIN
        //                || para.Operator == Enums.Relation.IN_InsertSQL || para.Operator == Enums.Relation.NotIN_InsertSQL)
        //            {
        //                StringBuilder inSql = new StringBuilder();
        //                string[] strList = GetSQL_IN_Value(para.FieldValue);
        //                if (strList == null || strList.Length == 0)
        //                {
        //                    sbWhere.Append(" 1=0 ").Append(Enums.ExpressionString(para.Expression));
        //                    continue;
        //                }
        //                if (!isPage)
        //                {
        //                    if (para.Operator == Enums.Relation.IN || para.Operator == Enums.Relation.NotIN)
        //                    {
        //                        foreach (string s in strList)
        //                        {
        //                            inSql.AppendFormat(_MsSqlParam, (para.ParamName != null ? para.ParamName : "T") + index).Append(',');
        //                            index++;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        string tmpFormat = _StringFormat;
        //                        FieldMappingInfo f = FieldMappingInfo.GetFieldInfo(typeof(T), para.FieldName);
        //                        if (f != null)
        //                        {
        //                            if (IsNumType(f.DataTypeCode))
        //                            {
        //                                tmpFormat = _DecimalFormat;
        //                            }

        //                            foreach (string s in strList)
        //                            {
        //                                inSql.AppendFormat(tmpFormat, s).Append(',');
        //                            }
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    FieldMappingInfo f = FieldMappingInfo.GetFieldInfo(typeof(T), para.FieldName);
        //                    if (f != null)
        //                    {
        //                        if (IsNumType(f.DataTypeCode))
        //                        {
        //                            foreach (string s in strList)
        //                            {
        //                                inSql.AppendFormat(_DecimalFormat, s).Append(',');
        //                            }
        //                        }
        //                        else
        //                        {
        //                            foreach (string s in strList)
        //                            {
        //                                inSql.Append('N').AppendFormat(_StringFormat, s).Append(',');
        //                            }
        //                        }
        //                    }
        //                }

        //                if (!string.IsNullOrEmpty(inSql.ToString()))
        //                {
        //                    sbWhere.AppendFormat(_MsSqlFieldFmt, para.FieldName).AppendFormat(Enums.RelationString(para.Operator), inSql.ToString().TrimEnd(',')).Append(Enums.ExpressionString(para.Expression));
        //                }
        //            }
        //            else
        //            {
        //                sbWhere.Append(GetCondition(para, true, isPage));
        //            }
        //        }
        //        //格式化最后的表达式，
        //        if (sbWhere.ToString() == strWhere)
        //            return string.Empty;
        //        else
        //            return base.TrimSql(sbWhere.ToString());
        //    }
        //    else
        //        return string.Empty;
        //}
        //protected override string GetCondition(SqlParam para, bool isFilter, bool isPage)
        //{
        //    StringBuilder sbStr = new StringBuilder();
        //    string __MsSqlParam = string.Empty;
        //    if (isFilter)
        //    {
        //        __MsSqlParam = _MsSqlWhereParam;
        //    }
        //    else
        //    {
        //        __MsSqlParam = _MsSqlParam;
        //    }

        //    sbStr.AppendFormat(_MsSqlFieldFormat, para.FieldName).Append(Enums.RelationString(para.Operator));

        //    if (para.Operator == Enums.Relation.IsNotNull || para.Operator == Enums.Relation.IsNull)
        //    {
        //        //sbStr.Append(para.Expression.ToSqlString());
        //    }
        //    else if (isPage)
        //    {
        //        if (para.IsUnicode)
        //        {
        //            sbStr.Append("N");//.Append('\'');
        //        }
        //        sbStr.Append('\'');

        //        if (IsDatabaseDate(para))
        //        {
        //            sbStr.Append(_MsSqlGetDate);
        //        }
        //        else
        //        {
        //            if (para.Operator == Enums.Relation.Like || para.Operator == Enums.Relation.NotLike)
        //            {
        //                sbStr.Append(para.FieldValue.ToString().Replace("'", "''").Replace("[", "[[]"));
        //            }
        //            else
        //            {
        //                sbStr.Append(para.FieldValue.ToString().Replace("'", "''"));
        //            }
        //        }

        //        sbStr.Append('\'');//.Append('\'');
        //    }
        //    else if (IsDatabaseDate(para))
        //    {
        //        sbStr.Append(_MsSqlGetDate);
        //    }
        //    else
        //    {
        //        sbStr.AppendFormat(__MsSqlParam, !string.IsNullOrEmpty(para.ParamName) ? para.ParamName : para.FieldName);
        //    }

        //    sbStr.Append(Enums.ExpressionString(para.Expression));
        //    return sbStr.ToString();
        //}
        private string GetNoLocks(List<Enums.LockType> lockTypes)
        {
            if (lockTypes != null && lockTypes.Count > 0)
            {
                string str = string.Empty;
                StringBuilder sb = new StringBuilder();
                foreach (var t in lockTypes)
                {
                    str = GetNoLockByEnums(t);
                    if (!string.IsNullOrEmpty(str) && !sb.ToString().Contains(str))
                    {
                        sb.AppendFormat("{0},", str);
                    }
                }
                str = sb.ToString().TrimEnd(',');
                if (!string.IsNullOrEmpty(str))
                {
                    return string.Format("WITH ({0})", str);
                }
            }
            return string.Empty;
        }

        private string GetNoLockByEnums(Enums.LockType lockType)
        {
            switch (lockType)
            {
                case Enums.LockType.None:
                    return string.Empty;

                case Enums.LockType.NoLock:
                    return "NOLOCK";

                case Enums.LockType.HoldLock:
                    return "HOLDLOCK";

                case Enums.LockType.RowLock:
                    return "ROWLOCK";

                case Enums.LockType.UpdLock:
                    return "UPDLOCK";

                default:
                    return "NOLOCK";
            }
        }

        //private SqlParameter GetSqlParameter(FieldMappingInfo field, T entity)
        //{
        //    object value = field.Property.GetValue(entity, null);
        //    if (!IsDatabaseDate(field.DataTypeCode, value))
        //    {
        //        SqlParameter dp = new SqlParameter();
        //        dp.DbType = field.DataTypeCode;
        //        dp.ParameterName = string.Format(_MsSqlParam, field.FieldName);
        //        dp.Value = CheckValue(dp, value);
        //        return dp;
        //    }
        //    return null;
        //}
        private object CheckValue(IDbDataParameter param, object value)
        {
            if (Common.IsDateType(param.DbType))
            {
                if (Convert.ToDateTime(value) == DateTime.MinValue)
                    return DBNull.Value;
            }
            return value;
        }

        #endregion Private Functions

        #region Public Functions

        public List<IDbDataParameter> GenParameter(FilterParams filterParams)
        {
            if (filterParams != null)
            {
                int index = 0;
                List<IDbDataParameter> LstDP = new List<IDbDataParameter>();
                foreach (SqlParam sp in filterParams)
                {
                    if (IsDatabaseDate(sp))
                        continue;
                    if (sp.Operator == Enums.Relation.IN || sp.Operator == Enums.Relation.NotIN)
                    {
                        string[] strList = GetSQL_IN_Value(sp.FieldValue);
                        if (strList == null || strList.Length == 0)
                            continue;

                        FieldMappingInfo f = FieldMappingInfo.GetFieldInfo(typeof(T), sp.FieldName);
                        if (f != null)
                        {
                            foreach (string s in strList)
                            {
                                IDbDataParameter p = new SqlParameter();
                                p.DbType = f.DataTypeCode;
                                p.ParameterName = (sp.ParamName != null ? sp.ParamName : "T") + index;
                                p.Value = s.ToString();
                                LstDP.Add(p);
                                index++;
                            }
                        }
                    }
                    else if (sp.Operator == Enums.Relation.IN_InsertSQL || sp.Operator == Enums.Relation.NotIN_InsertSQL
                        || sp.Operator == Enums.Relation.IN_SelectSQL || sp.Operator == Enums.Relation.NotIN_SelectSQL)
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
                            IDbDataParameter dp = new SqlParameter();
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
            {
                return null;
            }
        }

        #endregion Public Functions
    }
}