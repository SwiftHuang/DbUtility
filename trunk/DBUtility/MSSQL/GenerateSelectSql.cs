using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using hwj.DBUtility.TableMapping;

namespace hwj.DBUtility.MSSQL
{
    public class GenerateSelectSql<T> : BaseGenSelectSql<T> where T : class, new()
    {
        private const string _MsSqlSelectString = "SELECT {0} {1} FROM {2} {3} {4} {5};";
        private const string _MsSqlTopCount = "top {0}";
        private const string _MsSqlInsertLastID = "SELECT @@IDENTITY AS 'Identity';";
        private const string _MsSqlPaging_RowCount = "EXEC dbo.Hwj_Paging_RowCount @TableName,@FieldKey,@Sort,@PageIndex,@PageSize,@DisplayField,@Where,@Group,@_PTotalCount output";
        private const string _MsSqlPageView = "EXEC dbo.sp_PageView @TableName,@FieldKey,@PageIndex,@PageSize,@DisplayField,@Sort,@Where,@_RecordCount output";
        private const string _MsSqlParam = "@{0}";
        private const string _MsSqlWhereParam = "@_{0}";
        private const string _MsSqlGetDate = "GetDate()";
        private const string _MsSqlFieldFmt = "[{0}]";

        /// <summary>
        /// SQL生成类
        /// </summary>
        public GenerateSelectSql()
        {
            base.DatabaseGetDateSql = _MsSqlGetDate;
            _FieldFormat = _MsSqlFieldFmt;
        }

        #region Select Sql
        public string SelectServerDateTime()
        {
            return "SELECT GETDATE() AS [DateTime]";
        }
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
            return string.Format(_MsSqlSelectString, sMaxCount, GenDisplayFieldsSql(displayFields), tableName, GetNoLock(isNoLock), GenFilterParamsSql(filterParam), GenSortParamsSql(sortFields));
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
        /// <param name="filterParam">筛选条件</param>
        /// <param name="sortParams">排序</param>
        /// <param name="PK">分页依据(关键字)</param>
        /// <param name="groupParam">分组显示</param>
        /// <param name="pageNumber">页数</param>
        /// <param name="pageSize">每页显示记录数</param>
        /// <returns></returns>
        public SqlEntity GetGroupPageSqlEntity(string tableName, DisplayFields displayFields, FilterParams filterParam, SortParams sortParams, GroupParams groupParam, DisplayFields PK, int pageNumber, int pageSize)
        {
            SqlEntity SE = new SqlEntity();
            SE.CommandText = _MsSqlPaging_RowCount;
            SE.Parameters = new List<SqlParameter>();
            SE.Parameters.Add(new SqlParameter("@TableName", tableName));
            SE.Parameters.Add(new SqlParameter("@FieldKey", GenDisplayFieldsSql(PK, true)));
            SE.Parameters.Add(new SqlParameter("@PageIndex", pageNumber));
            SE.Parameters.Add(new SqlParameter("@PageSize", pageSize));
            SE.Parameters.Add(new SqlParameter("@DisplayField", GenDisplayFieldsSql(displayFields)));
            SE.Parameters.Add(new SqlParameter("@Sort", GenSortParamsSql(sortParams, true)));
            SE.Parameters.Add(new SqlParameter("@Where", GenFilterParamsSql(filterParam, true)));
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
        public SqlEntity GetPageSqlEntity(string tableName, DisplayFields displayFields, FilterParams filterParam, SortParams sortParams, DisplayFields PK, int pageNumber, int pageSize)
        {
            SqlEntity SE = new SqlEntity();
            SE.CommandText = _MsSqlPageView;
            SE.Parameters = new List<SqlParameter>();
            SE.Parameters.Add(new SqlParameter("@TableName", tableName));
            SE.Parameters.Add(new SqlParameter("@FieldKey", GenDisplayFieldsSql(PK, true)));
            SE.Parameters.Add(new SqlParameter("@PageIndex", pageNumber));
            SE.Parameters.Add(new SqlParameter("@PageSize", pageSize));
            SE.Parameters.Add(new SqlParameter("@DisplayField", GenDisplayFieldsSql(displayFields)));
            SE.Parameters.Add(new SqlParameter("@Sort", GenSortParamsSql(sortParams, true)));
            SE.Parameters.Add(new SqlParameter("@Where", GenFilterParamsSql(filterParam, true)));
            return SE;
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
                    else if (para.Operator == Enums.Relation.IN || para.Operator == Enums.Relation.NotIN)
                    {
                        StringBuilder inSql = new StringBuilder();
                        string[] strList;
                        if (para.FieldValue == null)
                            continue;
                        else if (para.FieldValue is List<string>)
                            strList = ((List<string>)para.FieldValue).ToArray();
                        else if (para.FieldValue is string)
                            strList = new string[] { para.FieldValue.ToString() };
                        else
                            strList = (string[])para.FieldValue;

                        if (!isPage)
                        {
                            foreach (string s in strList)
                            {
                                inSql.AppendFormat(_MsSqlParam, (para.ParamName != null ? para.ParamName : "T") + index).Append(',');
                                index++;
                            }
                        }
                        else
                        {
                            foreach (string s in strList)
                            {
                                inSql.Append('N').AppendFormat(_StringFormat, s).Append(',');
                            }
                        }

                        sbWhere.AppendFormat(_MsSqlFieldFmt, para.FieldName).AppendFormat(Enums.RelationString(para.Operator), inSql.ToString().TrimEnd(',')).Append(Enums.ExpressionString(para.Expression));
                    }
                    else
                        sbWhere.Append(GetCondition(para, true, isPage));
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
                //List<FieldMappingInfo> FieldInfos = FieldMappingInfo.GetFieldMapping(typeof(T));
                //if (FieldInfos != null)
                //{
                //}else
                if (para.IsUnicode)
                    sbStr.Append("N");//.Append('\'');
                sbStr.Append('\'');
                if (IsDatabaseDate(para))
                    sbStr.Append(_MsSqlGetDate);
                else
                    sbStr.Append(para.FieldValue.ToString());
                sbStr.Append('\'');//.Append('\'');
            }
            else if (IsDatabaseDate(para))
                sbStr.Append(_MsSqlGetDate);
            else
                sbStr.AppendFormat(__MsSqlParam, !string.IsNullOrEmpty(para.ParamName) ? para.ParamName : para.FieldName);

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
        public List<SqlParameter> GenParameter(FilterParams filterParam)
        {
            if (filterParam != null)
            {
                int index = 0;
                List<SqlParameter> LstDP = new List<SqlParameter>();
                foreach (SqlParam sp in filterParam)
                {
                    if (IsDatabaseDate(sp))
                        continue;
                    if (sp.Operator == Enums.Relation.IN || sp.Operator == Enums.Relation.NotIN)
                    {
                        string[] strList;
                        if (sp.FieldValue == null)
                            continue;
                        else if (sp.FieldValue is List<string>)
                            strList = ((List<string>)sp.FieldValue).ToArray();
                        else if (sp.FieldValue is string)
                            strList = new string[] { sp.FieldValue.ToString() };
                        else
                            strList = (string[])sp.FieldValue;

                        foreach (string s in strList)
                        {
                            SqlParameter p = new SqlParameter();
                            p.ParameterName = (sp.ParamName != null ? sp.ParamName : "T") + index;
                            p.Value = s.ToString();
                            LstDP.Add(p);
                            index++;
                        }
                    }
                    else if (sp.Operator == Enums.Relation.IsNotNull || sp.Operator == Enums.Relation.IsNull)
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
        #endregion
    }
}
