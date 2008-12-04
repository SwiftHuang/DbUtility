using System;
using System.Collections.Generic;

namespace hwj.DBUtility
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
            FieldName = fieldName.ToString();
            FieldValue = fieldValue;
            Operator = oper;
            Expression = exp;
        }
        public SqlParam(Enum fieldName, object fieldValue, Enums.Operator oper)
            : base()
        {
            FieldName = fieldName.ToString();
            FieldValue = fieldValue;
            Operator = oper;
            Expression = Enums.Expression.None;
        }
        public SqlParam(string fieldName, object fieldValue, Enums.Operator oper)
            : base()
        {
            FieldName = fieldName.ToString();
            FieldValue = fieldValue;
            Operator = oper;
            Expression = Enums.Expression.None;
        }
        public SqlParam(Enum fieldName, object fieldValue)
            : base()
        {
            FieldName = fieldName.ToString();
            FieldValue = fieldValue;
            Operator = Enums.Operator.Equal;
            Expression = Enums.Expression.None;
        }
        public SqlParam(string fieldName, object fieldValue)
            : base()
        {
            FieldName = fieldName.ToString();
            FieldValue = fieldValue;
            Operator = Enums.Operator.Equal;
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
        public static List<SqlParam> AddParam(this List<SqlParam> lst, Enum fieldName, object fieldValue, Enums.Operator oper)
        {
            lst.Add(new SqlParam(fieldName, fieldValue, oper));
            return lst;
        }
        public static List<SqlParam> AddParam(this List<SqlParam> lst, Enum fieldName, object fieldValue)
        {
            lst.Add(new SqlParam(fieldName, fieldValue));
            return lst;
        }
        public static List<SqlParam> AddParam(this List<SqlParam> lst, SqlParam sqlParam)
        {
            lst.Add(sqlParam);
            return lst;
        }
        public static List<UpdateFields> AddParam(this List<UpdateFields> lst, Enum fieldName, object fieldValue)
        {
            lst.Add(new UpdateFields(fieldName, fieldValue));
            return lst;
        }
        public static List<UpdateFields> AddParam(this List<UpdateFields> lst, string fieldName, object fieldValue)
        {
            lst.Add(new UpdateFields(fieldName, fieldValue));
            return lst;
        }
    }
}
