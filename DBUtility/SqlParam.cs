using System;
using System.Collections.Generic;

namespace WongTung.DBUtility
{
    public class SqlParam
    {
        #region Property
        public string FieldName { get; set; }
        public object FieldValue { get; set; }
        public Enums.Operator Operator { get; set; }
        public Enums.Expression Expression { get; set; }
        #endregion

        public SqlParam(Enum fieldName, object fieldValue, Enums.Operator oper, Enums.Expression exp)
            : base()
        {
            FieldName = fieldName.ToString();
            FieldValue = fieldValue;
            Operator = oper;
            Expression = exp;
        }
        public SqlParam(string fieldName, object fieldValue, Enums.Operator oper, Enums.Expression exp)
            : base()
        {
            FieldName = fieldName;
            FieldValue = fieldValue;
            Operator = oper;
            Expression = exp;
        }

        
        public SqlParam(string fieldName, object fieldValue, Enums.Operator oper)
            : base()
        {
            FieldName = fieldName;
            FieldValue = fieldValue;
            Operator = oper;
            Expression = Enums.Expression.None;
        }
        public SqlParam(Enum fieldName, object fieldValue, Enums.Operator oper)
            : base()
        {
            FieldName = fieldName.ToString();
            FieldValue = fieldValue;
            Operator = oper;
            Expression = Enums.Expression.None;
        }

    }

    public static class SqlParamExtensions
    {
        public static List<SqlParam> AddParam(this List<SqlParam> lst, Enum fieldName, object fieldValue, Enums.Operator oper, Enums.Expression exp)
        {
            lst.Add(new SqlParam(fieldName, fieldValue, oper, exp));
            return lst;
        }
        public static List<SqlParam> AddParam(this List<SqlParam> lst, string fieldName, object fieldValue, Enums.Operator oper, Enums.Expression exp)
        {
            lst.Add(new SqlParam(fieldName, fieldValue, oper, exp));
            return lst;
        }
        public static List<SqlParam> AddParam(this List<SqlParam> lst, Enum fieldName, object fieldValue, Enums.Operator oper)
        {
            lst.Add(new SqlParam(fieldName, fieldValue, oper));
            return lst;
        }
        public static List<SqlParam> AddParam(this List<SqlParam> lst, string fieldName, object fieldValue, Enums.Operator oper)
        {
            lst.Add(new SqlParam(fieldName, fieldValue, oper));
            return lst;
        }
        public static List<SqlParam> AddParam(this List<SqlParam> lst, SqlParam sqlParam)
        {
            lst.Add(sqlParam);
            return lst;
        }
    }
}
