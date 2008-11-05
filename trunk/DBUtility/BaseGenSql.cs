using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WongTung.DBUtility.TableMapping;

namespace WongTung.DBUtility
{
    public abstract class BaseGenSql<T>
    {
        protected const string _DeleteString = "DELETE FROM {0} WHERE {1};";
        protected const string _SelectCountString = "SELECT COUNT(*) FROM {0} {1};";
        protected const string _UpdateString = "UPDATE {0} SET {1} {2};";
        protected const string _InsertString = "INSERT INTO {0} ({1}) VALUE({2});";
        protected const string _StringFormat = "'{0}'";
        protected const string _DecimalFormat = "{0}";

        #region Property
        protected string GetTableName()
        {
            return GetTableName(null);
        }
        protected string GetTableName(string tableName)
        {
            if (tableName != null && tableName != string.Empty)
                return tableName;
            else
                return typeof(T).Name.ToString().Trim();
        }
        #endregion

        #region Public Functions

        #region Delete Sql
        public string DeleteSql(IList<SqlParam> whereParam)
        {
            StringBuilder sbWhere = new StringBuilder();
            if (whereParam.Count > 0)
            {
                foreach (SqlParam para in whereParam)
                {
                    sbWhere.Append(GetCondition(para));
                }
            }
            else
                sbWhere.Append("1=1");

            return string.Format(_DeleteString, GetTableName(), sbWhere.ToString().TrimEnd(','));
        }
        #endregion

        #region Update Sql
        public string UpdateSql(IList<SqlParam> updateParam, IList<SqlParam> whereParam)
        {
            return string.Format(_UpdateString, GetTableName(), GetFieldSql(updateParam), GetWhereSql(whereParam));
        }
        #endregion

        #region Insert Sql
        public abstract string InsertLastIDSql();
        public abstract string InsertSql(T entity);
        #endregion

        public abstract string SelectSql(string tableName, IList<Enum> selectFields, IList<SqlParam> whereParam, IList<OrderParam> orderParam, int? maxCount);

        #region Record Count Sql
        public string SelectCountSql(string tableName, IList<SqlParam> whereParam)
        {
            return string.Format(_SelectCountString, GetTableName(tableName), GetWhereSql(whereParam));
        }
        #endregion

        #endregion

        #region Private Functions
        protected bool IsNumType(TypeCode typeCode)
        {
            if (typeCode == TypeCode.Decimal || typeCode == TypeCode.Int16 || typeCode == TypeCode.Int32 || typeCode == TypeCode.Int64)
                return true;
            else
                return false;
        }
        protected bool IsDateType(TypeCode typeCode)
        {
            if (typeCode == TypeCode.DateTime)
                return true;
            else
                return false;
        }

        protected abstract string GetCondition(SqlParam para);
        protected string GetFieldSql(IList<SqlParam> listParam)
        {
            if (listParam != null && listParam.Count > 0)
            {
                StringBuilder sbUpdate = new StringBuilder();
                foreach (SqlParam para in listParam)
                {
                    sbUpdate.Append(GetCondition(para));
                }
                return sbUpdate.ToString().TrimEnd(',');
            }
            else
                return string.Empty;
        }
        protected string GetWhereSql(IList<SqlParam> listParam)
        {
            if (listParam != null && listParam.Count > 0)
            {
                StringBuilder sbWhere = new StringBuilder();
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
        protected string GetOrderBySql(OrderParam o)
        {
            return string.Format("{0} {1},", o.FieldName, o.OrderBy.ToSqlString());
        }

        protected string GetSelectFields(IList<Enum> fields)
        {
            if (fields != null && fields.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (Enum s in fields)
                {
                    sb.Append(s.ToString()).Append(',');
                }
                return sb.ToString().TrimEnd(',');
            }
            return "*";
        }
        protected string GetSelectFields(IList<string> fields)
        {
            if (fields != null && fields.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (string s in fields)
                {
                    sb.Append(s.ToString()).Append(',');
                }
                return sb.ToString().TrimEnd(',');
            }
            return "*";
        }

        protected string GetOrderByFields(IList<OrderParam> orders)
        {
            if (orders != null)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("ORDER BY ");
                foreach (OrderParam o in orders)
                {
                    sb.Append(GetOrderBySql(o));
                }
                return sb.ToString().TrimEnd(',');
            }
            else
                return string.Empty;
        }
        #endregion
    }
}
