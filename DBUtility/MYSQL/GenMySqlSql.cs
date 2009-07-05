using System;
using System.Collections.Generic;
using System.Text;
using hwj.DBUtility.TableMapping;
using MySql.Data.MySqlClient;

namespace hwj.DBUtility.MYSQL
{
    public class GenerateSql<T> : BaseGenSql<T> where T : BaseTable<T>, new()
    {
        private const string _MySqlSelectString = "SELECT {0} FROM {1} {2} {3} {4};";
        private const string _MySqlDateFormat = "yyyy-MM-dd hh:mm:ss";
        private const string _MySqlLimitCount = "limit {0}";
        private const string _MySqlInsertLastID = "SELECT LAST_INSERT_ID();";
        private const string _MySqlParam = "?{0}";
        private const string _MySqlWhereParam = "?_{0}";
        private const string _MySqlTruncate = "TRUNCATE TABLE {0};";

        #region Insert Sql
        public override string InsertLastIDSql()
        {
            return _MySqlInsertLastID;
        }
        public override string InsertSql(T entity)
        {
            StringBuilder sbInsField = new StringBuilder();
            StringBuilder sbInsValue = new StringBuilder();

            foreach (FieldMappingInfo f in FieldMappingInfo.GetFieldMapping(typeof(T)))
            {
                object obj = f.Property.GetValue(entity, null);
                if (obj != null)
                {
                    sbInsField.Append(f.FieldName).Append(',');
                    sbInsValue.AppendFormat(_MySqlParam, f.FieldName).Append(',');
                }
            }
            return string.Format(_InsertString, entity.GetType().Name, sbInsField.ToString().TrimEnd(','), sbInsValue.ToString().TrimEnd(','));
        }
        #endregion
        #region Delete Sql
        public override string TruncateSql(string tableName)
        {
            return string.Format(_MySqlTruncate, tableName);
        }
        #endregion
        #region Select Sql
        public override string SelectSql(string tableName, DisplayFields displayFields, FilterParams filterParam, SortParams sortFields, int? maxCount)
        {
            string sMaxCount = string.Empty;

            if (maxCount.HasValue && maxCount > 0)
            {
                sMaxCount = string.Format(_MySqlLimitCount, maxCount);
            }
            return string.Format(_MySqlSelectString, GenDisplayFieldsSql(displayFields), GetTableName(tableName), GenFilterParamsSql(filterParam), GenSortParamsSql(sortFields), sMaxCount);
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
                    sbWhere.Append(GetCondition(para, true, true));
                }
                return sbWhere.ToString().TrimEnd(',');
            }
            else
                return string.Empty;
        }
        protected override string GetCondition(SqlParam para, bool isWhere, bool isPage)
        {
            StringBuilder sbStr = new StringBuilder();
            FieldMappingInfo f = new FieldMappingInfo(FieldMappingInfo.GetFieldInfo(typeof(T), para.FieldName));

            string __MySqlParam = string.Empty;
            if (isWhere)
                __MySqlParam = _MySqlWhereParam;
            else
                __MySqlParam = _MySqlParam;

            if (para.Operator == Enums.Relation.IsNotNull || para.Operator == Enums.Relation.IsNull)
                sbStr.Append(para.FieldName).Append(para.Operator.ToSqlString()).Append(para.Expression.ToSqlString());
            else
                sbStr.Append(para.FieldName).Append(para.Operator.ToSqlString()).AppendFormat(__MySqlParam, para.FieldName).Append(para.Expression.ToSqlString());
            //else
            //{
            //    if (IsNumType(f.DataTypeCode))
            //        sbStr.Append(para.FieldName).Append(para.Operator.ToSqlString()).AppendFormat(_DecimalFormat, para.FieldValue).Append(para.Expression.ToSqlString());
            //    else if (IsDateType(f.DataTypeCode))
            //        sbStr.Append(para.FieldName).Append(para.Operator.ToSqlString()).AppendFormat(_StringFormat, Convert.ToDateTime(para.FieldValue).ToString(_MySqlDateFormat)).Append(para.Expression.ToSqlString());
            //    else
            //        sbStr.Append(para.FieldName).Append(para.Operator.ToSqlString()).AppendFormat(__MySqlParam, para.FieldName).Append(para.Expression.ToSqlString());
            //}
            return sbStr.ToString();
        }
        #endregion

        #region Public Functions
        public List<MySqlParameter> GenParameter(UpdateParam updateParam)
        {
            if (updateParam != null)
            {
                List<MySqlParameter> LstDP = new List<MySqlParameter>();
                foreach (UpdateFields up in updateParam)
                {
                    foreach (FieldMappingInfo f in FieldMappingInfo.GetFieldMapping(typeof(T)))
                    {
                        if (up.FieldName == f.FieldName)
                        {
                            MySqlParameter dp = new MySqlParameter();
                            dp.DbType = f.DataTypeCode;
                            dp.ParameterName = string.Format(_MySqlParam, up.FieldName);
                            dp.Value = up.FieldValue;
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
        public List<MySqlParameter> GenParameter(FilterParams filterParam)
        {
            if (filterParam != null)
            {
                List<MySqlParameter> LstDP = new List<MySqlParameter>();
                foreach (SqlParam sp in filterParam)
                {
                    foreach (FieldMappingInfo f in FieldMappingInfo.GetFieldMapping(typeof(T)))
                    {
                        if (sp.FieldName == f.FieldName)
                        {
                            MySqlParameter dp = new MySqlParameter();
                            dp.DbType = f.DataTypeCode;
                            dp.ParameterName = string.Format(_MySqlWhereParam, sp.FieldName);
                            dp.Value = sp.FieldValue;
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
        public List<MySqlParameter> GenParameter(T entity)
        {
            List<MySqlParameter> LstDP = new List<MySqlParameter>();
            foreach (FieldMappingInfo f in FieldMappingInfo.GetFieldMapping(typeof(T)))
            {
                MySqlParameter dp = new MySqlParameter();
                object _value = f.Property.GetValue(entity, null);
                dp.DbType = f.DataTypeCode;
                dp.ParameterName = string.Format(_MySqlParam, f.FieldName);
                if (IsDateType(f.DataTypeCode))
                {
                    if (Convert.ToDateTime(_value) == DateTime.MinValue)
                        dp.Value = DBNull.Value;
                    else
                        dp.Value = _value;
                }
                else
                    dp.Value = _value;
                LstDP.Add(dp);
            }
            return LstDP;
        }
        #endregion
    }
}
