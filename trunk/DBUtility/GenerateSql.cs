using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WongTung.DBUtility.TableMapping;

namespace WongTung.DBUtility
{
    public class GenerateSql<T> where T : class, new()
    {
        private const string _DeleteString = "DELETE FROM {0} WHERE {1}";
        private const string _SelectString = "SELECT * FROM {0} {1} {2}";
        private const string _SelectFieldsString = "SELECT {0} FROM {1} {2} {3}";
        private const string _UpdateString = "UPDATE {0} SET {1} {2}";
        private const string _InsertString = "INSERT INTO {0} ({1}) VALUE({2})";
        private const string _StringFormat = "'{0}'";
        private const string _DecimalFormat = "{0}";
        private const string _MySqlDateFormat = "yyyy-MM-dd hh:mm:ss";

        #region Property
        private static string GetTableName()
        {
            return GetTableName(null);
        }
        private static string GetTableName(string tableName)
        {
            if (tableName != null && tableName != string.Empty)
                return tableName;
            else
                return typeof(T).Name.ToString().Trim();
        }
        #endregion

        #region Public Functons
        public static string DeleteSql(IList<SqlParam> wherePara)
        {
            StringBuilder sbWhere = new StringBuilder();
            if (wherePara.Count > 0)
            {
                foreach (SqlParam para in wherePara)
                {
                    sbWhere.Append(GetCondition(para));
                }
            }
            else
                sbWhere.Append("1=1");

            return string.Format(_DeleteString, GetTableName(), sbWhere.ToString().TrimEnd(','));
        }

        public static string UpdateSql(IList<SqlParam> updateParam, IList<SqlParam> whereParam)
        {
            return string.Format(_UpdateString, GetTableName(), GetFieldSql(updateParam), GetWhereSql(whereParam));
        }

        public static string InsertSql(T entity)
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
                            if (PubConstant.DatabaseType == Enums.DBType.MySql)
                                sbInsValue.AppendFormat(_StringFormat, Convert.ToDateTime(obj).ToString(_MySqlDateFormat));
                            else
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

        public static string SelectSql(string tableName)
        {
            return SelectSql(string.Empty, tableName);
        }
        public static string SelectSql(string tableName, string strWhere)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(_SelectString, GetTableName(tableName), strWhere, string.Empty);
            return sb.ToString();
        }
        public static string SelectSql(string tableName, IList<Enum> selectFields)
        {
            return string.Format(_SelectFieldsString, GetSelectFields(selectFields), GetTableName(tableName), string.Empty, string.Empty);
        }
        public static string SelectSql(string tableName, IList<Enum> selectFields, IList<SqlParam> whereParam)
        {
            return SelectSql(tableName,  selectFields,whereParam, null);
        }
        public static string SelectSql(string tableName, IList<Enum> selectFields, IList<SqlParam> whereParam, params OrderParam[] orderFields)
        {
            if (selectFields.Count > 0)
                return string.Format(_SelectFieldsString, GetSelectFields(selectFields), GetTableName(tableName), GetWhereSql(whereParam), GetOrderByFields(orderFields));
            else
                return string.Format(_SelectString, GetTableName(tableName), GetWhereSql(whereParam), GetOrderByFields(orderFields));
        }

        #endregion

        #region Private Functions
        private static bool IsNumType(TypeCode typeCode)
        {
            if (typeCode == TypeCode.Decimal || typeCode == TypeCode.Int16 || typeCode == TypeCode.Int32 || typeCode == TypeCode.Int64)
                return true;
            else
                return false;
        }
        private static bool IsDateType(TypeCode typeCode)
        {
            if (typeCode == TypeCode.DateTime)
                return true;
            else
                return false;
        }
        private static string GetCondition(SqlParam para)
        {
            StringBuilder sbStr = new StringBuilder();
            FieldMappingInfo f = new FieldMappingInfo(FieldMappingInfo.GetFieldInfo(typeof(T), para.FieldName));

            if (para.Operator == Enums.Operator.IsNotNull || para.Operator == Enums.Operator.IsNull)
                sbStr.Append(para.FieldName).Append(para.Operator.ToSqlString()).Append(para.Expression.ToSqlString());
            else
            {
                if (IsNumType(f.DataTypeCode))
                    sbStr.Append(para.FieldName).Append(para.Operator.ToSqlString()).AppendFormat(_DecimalFormat, para.FieldValue).Append(para.Expression.ToSqlString());
                else if (IsDateType(f.DataTypeCode) && PubConstant.DatabaseType == Enums.DBType.MySql)
                    sbStr.Append(para.FieldName).Append(para.Operator.ToSqlString()).AppendFormat(_StringFormat, Convert.ToDateTime(para.FieldValue).ToString(_MySqlDateFormat)).Append(para.Expression.ToSqlString());
                else
                    sbStr.Append(para.FieldName).Append(para.Operator.ToSqlString()).AppendFormat(_StringFormat, para.FieldValue).Append(para.Expression.ToSqlString());
            }
            return sbStr.ToString();
        }
        private static string GetFieldSql(IList<SqlParam> listParam)
        {
            StringBuilder sbUpdate = new StringBuilder();
            foreach (SqlParam para in listParam)
            {
                sbUpdate.Append(GetCondition(para));
            }
            return sbUpdate.ToString().TrimEnd(',');
        }
        private static string GetWhereSql(IList<SqlParam> listParam)
        {
            StringBuilder sbWhere = new StringBuilder();
            if (listParam.Count > 0)
            {
                sbWhere.Append("WHERE ");
                foreach (SqlParam para in listParam)
                {
                    sbWhere.Append(GetCondition(para));
                }
                return sbWhere.ToString().TrimEnd(',');
            }
            else
                return string.Empty;
        }
        private static string GetOrderBySql(OrderParam o)
        {
            return string.Format("{0} {1},", o.FieldName, o.OrderBy.ToSqlString());
        }
        private static string GetSelectFields(IList<Enum> fields)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Enum s in fields)
            {
                sb.Append(s.ToString()).Append(',');
            }
            return sb.ToString().TrimEnd(',');
        }
        private static string GetSelectFields(IList<string> fields)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string s in fields)
            {
                sb.Append(s.ToString()).Append(',');
            }
            return sb.ToString().TrimEnd(',');
        }
        private static string GetOrderByFields(OrderParam[] orders)
        {
            StringBuilder sb = new StringBuilder();
            foreach (OrderParam o in orders)
            {
                sb.Append(GetOrderBySql(o));
            }
            return sb.ToString().TrimEnd(',');
        }
        #endregion
    }
}
