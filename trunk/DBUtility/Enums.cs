using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WongTung.DBUtility
{
    public class Enums
    {
        public enum Operator
        {
            Equal,
            Unequal,
            IsNull
        }
        public enum DBType
        {
            None,
            MySql,
            MsSql
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
                    return "is null";
                default:
                    throw new Exception("Enums.Operator error");
            }
            throw new Exception("Enums.Operator error");
        }
    }
}
