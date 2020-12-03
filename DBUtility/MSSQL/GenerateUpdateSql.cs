using hwj.DBUtility.TableMapping;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

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
            _SqlParam = _MsSqlParam;
            _SqlWhereParam = _MsSqlWhereParam;
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

        public override string InsertSql(T entity, out List<IDbDataParameter> dbDataParameters)
        {
            int index = 0;
            dbDataParameters = new List<IDbDataParameter>();
            StringBuilder sbInsField = new StringBuilder();
            StringBuilder sbInsValue = new StringBuilder();

            if (entity.GetAssignedStatus())
            {
                foreach (FieldMappingInfo f in FieldMappingInfo.GetFieldMapping(typeof(T)))
                {
                    if (entity.Source == Enums.EntitySource.DB || entity.GetAssigned().IndexOf(f.FieldName) != -1)//插入字段时,不一定所有字段插入(例如:A字段int类型默认值为99).
                    {
                        IDbDataParameter dp = null;
                        InsertSqlString(ref sbInsField, ref sbInsValue, f, entity, _ParamPrefix + index.ToString(), out dp);
                        if (dp != null)
                        {
                            dbDataParameters.Add(dp);
                        }
                        index++;
                    }
                }
            }
            else
            {
                foreach (FieldMappingInfo f in FieldMappingInfo.GetFieldMapping(typeof(T)))
                {
                    IDbDataParameter dp = null;
                    InsertSqlString(ref sbInsField, ref sbInsValue, f, entity, _ParamPrefix + index.ToString(), out dp);
                    if (dp != null)
                    {
                        dbDataParameters.Add(dp);
                    }
                    index++;
                }
            }
            return string.Format(_InsertString, entity.GetTableName(), sbInsField.ToString().TrimEnd(','), sbInsValue.ToString().TrimEnd(','));
        }

        private void InsertSqlString(ref StringBuilder insField, ref StringBuilder insValue, FieldMappingInfo field, T entity, string paramName, out IDbDataParameter dbDataParameter)
        {
            bool existCustomSqlText = entity.ExistCustomSqlText(field.FieldName);
            object obj = field.Property.GetValue(entity, null);
            if (obj != null)
            {
                if (entity.ExistIgnoreUnInsert(field.FieldName) || !field.IsUnInsert)
                {
                    //insField.Append(field.FieldName).Append(',');
                    insField.AppendFormat(_MsSqlFieldFmt, field.FieldName).Append(',');
                    if (existCustomSqlText)
                    {
                        string value = entity.GetCustomSqlTextValue(field.FieldName);
                        insValue.Append(value).Append(',');
                    }
                    else if (!IsDatabaseDate(field.DataTypeCode, obj))
                    {
                        insValue.AppendFormat(_MsSqlParam, string.IsNullOrEmpty(paramName) ? field.FieldName : paramName).Append(',');
                    }
                    else
                    {
                        insValue.Append(_MsSqlGetDate).Append(',');
                    }
                }
            }

            dbDataParameter = null;
            if (!existCustomSqlText)
            {
                dbDataParameter = GetSqlParameter(field, obj, paramName);
            }
        }

        #endregion Insert Sql

        #region Delete Sql

        public override string TruncateSql(string tableName)
        {
            return string.Format(_MsSqlTruncate, tableName);
        }

        #endregion Delete Sql

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
        //        StringBuilder sbWhere = new StringBuilder();
        //        int index = 0;
        //        if (!isPage)
        //            sbWhere.Append("WHERE ");
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
        //        return base.TrimSql(sbWhere.ToString());
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
        //    sbStr.AppendFormat(_MsSqlFieldFmt, para.FieldName).Append(Enums.RelationString(para.Operator));

        //    if (para.Operator == Enums.Relation.IsNotNull || para.Operator == Enums.Relation.IsNull)
        //    {
        //        //sbStr.Append(para.Expression.ToSqlString());
        //    }
        //    else if (isPage)
        //    {
        //        sbStr.Append('\'');//.Append('\'');
        //        if (IsDatabaseDate(para))
        //            sbStr.Append(_MsSqlGetDate);
        //        else
        //            sbStr.Append(para.FieldValue.ToString());
        //        sbStr.Append('\'');//.Append('\'');
        //    }
        //    else if (IsDatabaseDate(para))
        //        sbStr.Append(_MsSqlGetDate);
        //    else
        //        sbStr.AppendFormat(__MsSqlParam, para.ParamName != null ? para.ParamName : para.FieldName);

        //    sbStr.Append(Enums.ExpressionString(para.Expression));
        //    return sbStr.ToString();
        //}
        private string GetNoLock(bool isNoLock)
        {
            if (isNoLock)
                return "(NOLOCK)";
            else
                return string.Empty;
        }

        private IDbDataParameter GetSqlParameter(FieldMappingInfo field, T entity)
        {
            object value = field.Property.GetValue(entity, null);
            if (!IsDatabaseDate(field.DataTypeCode, value))
            {
                IDbDataParameter dp = new SqlParameter();
                dp.DbType = field.DataTypeCode;
                dp.ParameterName = string.Format(_MsSqlParam, field.FieldName);
                dp.Value = CheckValue(dp, value);
                return dp;
            }
            return null;
        }

        private object CheckValue(IDbDataParameter param, object value)
        {
            if (Common.IsDateType(param.DbType))
            {
                if (Convert.ToDateTime(value) == DateTime.MinValue)
                {
                    return DBNull.Value;
                }
            }
            return value;
        }

        #endregion Private Functions

        #region Public Functions

        public List<IDbDataParameter> GenParameter(UpdateParam updateParam)
        {
            if (updateParam != null)
            {
                List<IDbDataParameter> LstDP = new List<IDbDataParameter>();
                foreach (UpdateFields up in updateParam)
                {
                    if (!IsDatabaseDate(up) && !up.IsCustomText)
                    {
                        FieldMappingInfo f = FieldMappingInfo.GetFieldInfo(typeof(T), up.FieldName);
                        if (f != null)
                        {
                            IDbDataParameter dp = new SqlParameter();
                            dp.DbType = f.DataTypeCode;
                            dp.ParameterName = string.Format(_MsSqlParam, string.IsNullOrEmpty(up.ParamName) ? up.FieldName : up.ParamName);
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
                                if (f.DataTypeCode == DbType.AnsiStringFixedLength && p.Size == 0)
                                {
                                    //案例: 字段BfRef系Char(10)，IN List传了两个Value: "DF00000157", null
                                    //传了空值时p.Size=0，而char的长度是不能为0的，系统不知道char参数的长度，将其识别为char(8000)(为什么这样我也不知，sqlprofile捕捉到的最终sql就是这样)。
                                    //char类型参数自动补位至8000，而sp_executesql整体长度最大支持8000，这样整体肯定超出长度了。而ADO查询不直接报错，只是GetList没有记录，较难发现
                                    p.Size = f.Size;
                                }
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

        public List<IDbDataParameter> GenParameter(T entity)
        {
            List<IDbDataParameter> LstDP = new List<IDbDataParameter>();
            if (entity.GetAssignedStatus())
            {
                foreach (FieldMappingInfo f in FieldMappingInfo.GetFieldMapping(typeof(T)))
                {
                    if (entity.GetAssigned().IndexOf(f.FieldName) != -1 && !entity.ExistCustomSqlText(f.FieldName))
                    {
                        IDbDataParameter dp = GetSqlParameter(f, entity);
                        if (dp != null)
                            LstDP.Add(dp);
                    }
                }
            }
            else
            {
                foreach (FieldMappingInfo f in FieldMappingInfo.GetFieldMapping(typeof(T)))
                {
                    if (!entity.ExistCustomSqlText(f.FieldName))
                    {
                        IDbDataParameter dp = GetSqlParameter(f, entity);
                        if (dp != null)
                            LstDP.Add(dp);
                    }
                }
            }
            return LstDP;
        }

        #endregion Public Functions

        internal override IDbDataParameter GetSqlParameter(FieldMappingInfo field, object value, string paramName)
        {
            if (!IsDatabaseDate(field.DataTypeCode, value))
            {
                IDbDataParameter dp = new SqlParameter();
                dp.DbType = field.DataTypeCode;
                dp.ParameterName = string.Format(_MsSqlParam, string.IsNullOrEmpty(paramName) ? field.FieldName : paramName);
                dp.Value = CheckValue(dp, value);
                return dp;
            }
            return null;
        }
    }
}