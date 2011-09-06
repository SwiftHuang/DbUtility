using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using hwj.DBUtility.TableMapping;

namespace hwj.DBUtility
{
    public abstract class BaseGenSql<T> where T : class, new()
    {
        protected const string _StringFormat = "'{0}'";
        protected const string _DecimalFormat = "{0}";
        protected static string _FieldFormat = string.Empty;
        /// <summary>
        /// 获取数据库SQL
        /// </summary>
        protected string DatabaseGetDateSql = string.Empty;

        private static readonly int andL = Enums.ExpressionString(Enums.Expression.AND).Length;
        private static readonly int andR = Enums.ExpressionString(Enums.Expression.OR).Length;

        #region Protected Functions
        protected abstract string GetCondition(SqlParam para, bool isWhere, bool isPage);

        protected abstract string GenFilterParamsSql(FilterParams listParam, bool isPage);
        protected string GenFilterParamsSql(FilterParams listParam)
        {
            return GenFilterParamsSql(listParam, false);
        }
        protected string GenGroupParamsSql(GroupParams param)
        {
            return GenDisplayFieldsSql(param, true);
        }
        protected string GenDisplayFieldsSql(DisplayFields fields)
        {
            return GenDisplayFieldsSql(fields, false);
        }
        protected string GenDisplayFieldsSql(List<Enum> fields, bool isPage)
        {
            if (fields != null && fields.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (Enum s in fields)
                {
                    sb.AppendFormat(_FieldFormat, s.ToString()).Append(',');
                }
                return sb.ToString().TrimEnd(',');
            }
            if (!isPage)
                return "*";
            else
                return "";
        }
        protected string GenSortParamsSql(SortParams orders)
        {
            return GenSortParamsSql(orders, false);
        }
        protected string GenSortParamsSql(SortParams orders, bool isPage)
        {
            if (orders != null)
            {
                StringBuilder sb = new StringBuilder();
                if (!isPage)
                    sb.Append("ORDER BY ");
                foreach (SortParam o in orders)
                {
                    sb.AppendFormat(_FieldFormat + " {1},", o.FieldName, Enums.OrderByString(o.OrderBy));
                }
                return sb.ToString().TrimEnd(',');
            }
            else
                return string.Empty;
        }

        /// <summary>
        /// 格式化最后的表达式
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        protected string TrimSql(string sql)
        {
            if (sql.Substring(sql.Length - andL, andL) == Enums.ExpressionString(Enums.Expression.AND))
                sql = sql.Substring(0, sql.Length - andL);
            if (sql.Substring(sql.Length - andR, andR) == Enums.ExpressionString(Enums.Expression.OR))
                sql = sql.Substring(0, sql.Length - andR);
            return sql.TrimEnd(',');
        }
        ///// <summary>
        ///// 检查非法字符
        ///// </summary>
        ///// <param name="str"></param>
        ///// <returns></returns>
        //protected string CheckSql(string str)
        //{
        //    string s = string.Empty;
        //    if (str == null)
        //    {
        //        s = string.Empty;
        //    }
        //    else
        //    {
        //        s = str.Replace("'", "").Replace("*", "").Replace("select", "")
        //               .Replace("where", "").Replace(";", "").Replace("drop", "").Replace("DROP", "").Replace("and", "").Replace("or", "").Replace("delete", "").Replace("asc", "").Replace("<", "").Replace(">", "").Replace("=", "").Replace(";", "").Replace("&", "").Replace("*", "");
        //    }
        //    return s;
        //}

        protected bool IsNumType(DbType typeCode)
        {
            if (typeCode == DbType.Decimal || typeCode == DbType.Int16 || typeCode == DbType.Int32 || typeCode == DbType.Int64
                || typeCode == DbType.Double || typeCode == DbType.Single || typeCode == DbType.UInt16 || typeCode == DbType.UInt32 || typeCode == DbType.UInt64)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected bool IsDateType(DbType typeCode)
        {
            if (typeCode == DbType.DateTime)
                return true;
            else
                return false;
        }
        protected bool IsDatabaseDate(SqlParam param)
        {
            if (param.FieldValue is DateTime && Convert.ToDateTime(param.FieldValue) == SqlParam.DatabaseDate)
                return true;
            return false;
        }
        protected bool IsDatabaseDate(System.Data.DbType dbType, object value)
        {
            if (IsDateType(dbType) && Convert.ToDateTime(value) == SqlParam.DatabaseDate)
                return true;
            else
                return false;
        }

        protected string[] GetSQL_IN_Value(object obj)
        {
            if (obj == null)
                return null;
            else if (obj is List<string>)
                return ((List<string>)obj).ToArray();
            else if (obj is string)
                return new string[] { obj.ToString() };
            else
                return (string[])obj;
        }
        #endregion
    }
}
