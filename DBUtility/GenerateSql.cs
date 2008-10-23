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
        private const string _SelectString = "SELECT * FROM {0} {1}";
        private const string _UpdateString = "UPDATE {0} SET {1} WHERE {2}";
        private const string _InsertString = "INSERT INTO {0} ({1}) VALUE({2})";
        private const string _AndString = " AND ";
        private const string _StringFormat = "'{0}',";
        private const string _DecimalFormat = "{0},";
        private const string _MySqlDateFormat = "yyyy-MM-dd hh:mm:ss";

        #region Property
        private static string GetTableName()
        {
            return typeof(T).Name.ToString().Trim();
        }
        #endregion

        #region Public Functons
        public static string DeleteSql(List<GenerateSqlPara<T>> wherePara)
        {
            StringBuilder sbWhere = new StringBuilder();
            if (wherePara.Count > 0)
            {
                foreach (GenerateSqlPara<T> para in wherePara)
                {
                    sbWhere.Append(GetCondition(para, true));
                }
            }
            else
                sbWhere.Append("1=1");

            return string.Format(_DecimalFormat, GetTableName(), sbWhere.ToString());
        }
        public static string UpdateSql(List<GenerateSqlPara<T>> updatePara, List<GenerateSqlPara<T>> wherePara)
        {
            StringBuilder sbUpdate = new StringBuilder();
            StringBuilder sbWhere = new StringBuilder();

            foreach (GenerateSqlPara<T> para in updatePara)
            {
                sbUpdate.Append(GetCondition(para, false));
            }
            if (wherePara.Count > 0)
            {
                foreach (GenerateSqlPara<T> para in wherePara)
                {
                    sbWhere.Append(GetCondition(para, true));
                }
            }
            else
                sbWhere.Append("1=1");

            return string.Format(_UpdateString, GetTableName(), sbUpdate.ToString().TrimEnd(','), sbWhere.ToString().TrimEnd(','));
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
                            sbInsField.AppendFormat(_StringFormat, f.FieldName);
                            if (PubConstant.DatabaseType == Enums.DBType.MySql)
                                sbInsValue.AppendFormat(_StringFormat, Convert.ToDateTime(obj).ToString(_MySqlDateFormat));
                            else
                                sbInsValue.AppendFormat(_StringFormat, Convert.ChangeType(obj, f.DataTypeCode));
                        }
                    }
                    else
                    {
                        sbInsField.AppendFormat(_StringFormat, f.FieldName);
                        if (IsNumType(f.DataTypeCode))
                            sbInsValue.AppendFormat(_DecimalFormat, Convert.ChangeType(obj, f.DataTypeCode));
                        else
                            sbInsValue.AppendFormat(_StringFormat, Convert.ChangeType(obj, f.DataTypeCode));
                    }
                }
            }
            return string.Format(_InsertString, entity.GetType().Name, sbInsField.ToString().TrimEnd(','), sbInsValue.ToString().TrimEnd(','));
        }
        public static string SelectSql(string strWhere)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(_SelectString, GetTableName(), strWhere);
            return sb.ToString();
        }
        public static string SelectSql(string strWhere, string tableName)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(_SelectString, tableName, strWhere);
            return sb.ToString();
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
        private static string GetCondition(GenerateSqlPara<T> para, bool isWhere)
        {
            StringBuilder sbStr = new StringBuilder();
            FieldMappingInfo f = new FieldMappingInfo(FieldMappingInfo.GetFieldInfo(typeof(T), para.FieldName));

            if (IsNumType(f.DataTypeCode))
                sbStr.Append(para.FieldName).Append(para.Operator.ToSqlString()).AppendFormat(_DecimalFormat, para.FieldValue);
            else if (IsDateType(f.DataTypeCode) && PubConstant.DatabaseType == Enums.DBType.MySql)
                sbStr.Append(para.FieldName).Append(para.Operator.ToSqlString()).AppendFormat(_StringFormat, Convert.ToDateTime(para.FieldValue).ToString(_MySqlDateFormat));
            else
                sbStr.Append(para.FieldName).Append(para.Operator.ToSqlString()).AppendFormat(_StringFormat, para.FieldValue);

            if (isWhere)
                return sbStr.ToString().TrimEnd(',') + _AndString;
            else
                return sbStr.ToString();
        }
        private static string GetFieldSql()
        { }
        private static string GetWhereSql()
        {
        }
        #endregion
    }
}
