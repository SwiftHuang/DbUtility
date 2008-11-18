using System;
using System.Text;

using hwj.DBUtility.TableMapping;

namespace hwj.DBUtility.MSSQL
{
    public class GenerateSql<T> : BaseGenSql<T> where T : class, new()
    {
        private const string _MsSqlSelectString = "SELECT {0} {1} FROM {2} {3} {4} {5};";
        private const string _MsSqlTopCount = "top {0}";
        private const string _MsSqlInsertLastID = "SELECT @@IDENTITY AS 'Identity';";//没Test过可否使用

        #region Public Functions

        #region Insert Sql
        public override string InsertLastIDSql()
        {
            return _MsSqlInsertLastID;
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
                    if (IsDateType(f.DataTypeCode))
                    {
                        if (DateTime.MinValue != (DateTime)obj)
                        {
                            sbInsField.AppendFormat(_DecimalFormat, f.FieldName);
                            sbInsValue.AppendFormat(_StringFormat, Convert.ChangeType(obj, f.DataTypeCode));
                        }
                        else
                            continue;
                    }
                    else
                    {
                        sbInsField.AppendFormat(_DecimalFormat, f.FieldName);
                        if (IsNumType(f.DataTypeCode))
                            sbInsValue.AppendFormat(_DecimalFormat, Convert.ChangeType(obj, f.DataTypeCode));
                        else
                            sbInsValue.AppendFormat(_StringFormat, Convert.ChangeType(obj, f.DataTypeCode));
                    }
                    sbInsField.Append(',');
                    sbInsValue.Append(',');
                }
            }
            return string.Format(_InsertString, entity.GetType().Name, sbInsField.ToString().TrimEnd(','), sbInsValue.ToString().TrimEnd(','));
        }
        #endregion

        #region Select Sql
        public override string SelectSql(string tableName, SelectFields selectFields, WhereParam whereParam, OrderFields orderParam, int? maxCount)
        {
            return SelectSql(tableName, selectFields, whereParam, orderParam, maxCount, true);
        }
        public string SelectSql(string tableName, SelectFields selectFields, WhereParam whereParam, OrderFields orderParam, int? maxCount, bool isNoLock)
        {
            string sMaxCount = string.Empty;

            if (maxCount.HasValue && maxCount > 0)
            {
                sMaxCount = string.Format(_MsSqlTopCount, maxCount);
            }
            return string.Format(_MsSqlSelectString, sMaxCount, GenerateSelectFieldsSql(selectFields), GetTableName(tableName), GetNoLock(isNoLock), GenerateWhereSql(whereParam), GenerateOrderByFieldsSql(orderParam));
        }
        #endregion

        #endregion

        #region Private Functions
        protected override string GetCondition(SqlParam para)
        {
            StringBuilder sbStr = new StringBuilder();
            FieldMappingInfo f = new FieldMappingInfo(FieldMappingInfo.GetFieldInfo(typeof(T), para.FieldName));

            if (para.Operator == Enums.Operator.IsNotNull || para.Operator == Enums.Operator.IsNull)
                sbStr.Append(para.FieldName).Append(para.Operator.ToSqlString()).Append(para.Expression.ToSqlString());
            else
            {
                if (IsNumType(f.DataTypeCode))
                    sbStr.Append(para.FieldName).Append(para.Operator.ToSqlString()).AppendFormat(_DecimalFormat, para.FieldValue).Append(para.Expression.ToSqlString());
                else
                {
                    if (IsDateType(f.DataTypeCode))
                        sbStr.Append(para.FieldName).Append(para.Operator.ToSqlString()).AppendFormat(_StringFormat, Convert.ToDateTime(para.FieldValue) == DateTime.MinValue ? Convert.ToDateTime("1900-01-01") : para.FieldValue).Append(para.Expression.ToSqlString());
                    else
                        sbStr.Append(para.FieldName).Append(para.Operator.ToSqlString()).AppendFormat(_StringFormat, para.FieldValue).Append(para.Expression.ToSqlString());
                }
            }
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
    }
}
