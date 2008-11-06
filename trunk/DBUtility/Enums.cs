using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hwj.DBUtility
{
    public class Enums
    {
        public enum Operator
        {
            Equal,
            Unequal,
            Greater,
            Lesser,
            Geq,
            Leq,
            IsNull,
            IsNotNull
        }
        public enum DBType
        {
            None,
            MySql,
            MsSql
        }
        public enum Expression
        {
            None,
            AND,
            OR
        }
        public enum OrderBy
        {
            Descending,
            Ascending,
            None
        }
    }
    public static class EnumsExtensions
    {
        public static string ToSqlString(this Enums.Operator oper)
        {
            switch (oper)
            {
                case Enums.Operator.Equal:
                    return "=";
                case Enums.Operator.Unequal:
                    return "<>";
                case Enums.Operator.IsNull:
                    return " is null ";
                case Enums.Operator.IsNotNull:
                    return " is not null";
                case Enums.Operator.Geq:
                    return ">=";
                case Enums.Operator.Greater:
                    return ">";
                case Enums.Operator.Lesser:
                    return "<";
                case Enums.Operator.Leq:
                    return "<=";
                default:
                    throw new Exception("Enums.Operator error");
            }
            throw new Exception("Enums.Operator error");
        }
        public static string ToSqlString(this Enums.Expression exp)
        {
            switch (exp)
            {
                case Enums.Expression.AND:
                    return " AND ";
                case Enums.Expression.OR:
                    return " OR ";
                case Enums.Expression.None:
                    return ",";
                default:
                    throw new Exception("Enums Expression error");
            }
            throw new Exception("Enums Expression error");
        }
        public static string ToSqlString(this Enums.OrderBy ord)
        {
            switch (ord)
            {
                case Enums.OrderBy.Descending:
                    return "desc";
                case Enums.OrderBy.Ascending:
                    return string.Empty;
                case Enums.OrderBy.None:
                    return string.Empty;
                default:
                    return string.Empty;
            }
        }
    }
}
