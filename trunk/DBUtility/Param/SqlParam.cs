using System;
using System.Collections.Generic;

namespace hwj.DBUtility
{
    public class SqlParam
    {
        #region Property
        public string FieldName { get; set; }
        public object FieldValue { get; set; }
        public Enums.Relation Operator { get; set; }
        public Enums.Expression Expression { get; set; }
        /// <summary>
        /// 自定义参数名(防止From To的情况下相同的参数名)
        /// </summary>
        public string ParamName { get; set; }
        #endregion

        public SqlParam(Enum fieldName, object fieldValue, Enums.Relation oper, Enums.Expression exp, string paramName)
            : base()
        {
            FieldName = fieldName.ToString();
            FieldValue = fieldValue;
            Operator = oper;
            Expression = exp;
            ParamName = paramName;
        }
        public SqlParam(string fieldName, object fieldValue, Enums.Relation oper, Enums.Expression exp, string paramName)
            : base()
        {
            FieldName = fieldName.ToString();
            FieldValue = fieldValue;
            Operator = oper;
            Expression = exp;
            ParamName = paramName;
        }
        public SqlParam(Enum fieldName, object fieldValue, Enums.Relation oper, Enums.Expression exp)
            : base()
        {
            FieldName = fieldName.ToString();
            FieldValue = fieldValue;
            Operator = oper;
            Expression = exp;
            ParamName = null;
        }
        public SqlParam(string fieldName, object fieldValue, Enums.Relation oper, Enums.Expression exp)
            : base()
        {
            FieldName = fieldName.ToString();
            FieldValue = fieldValue;
            Operator = oper;
            Expression = exp;
            ParamName = null;
        }
        public SqlParam(Enum fieldName, object fieldValue, Enums.Relation oper)
            : base()
        {
            FieldName = fieldName.ToString();
            FieldValue = fieldValue;
            Operator = oper;
            Expression = Enums.Expression.Comma;
            ParamName = null;
        }
        public SqlParam(string fieldName, object fieldValue, Enums.Relation oper)
            : base()
        {
            FieldName = fieldName.ToString();
            FieldValue = fieldValue;
            Operator = oper;
            Expression = Enums.Expression.Comma;
            ParamName = null;
        }
        public SqlParam(Enum fieldName, object fieldValue)
            : base()
        {
            FieldName = fieldName.ToString();
            FieldValue = fieldValue;
            Operator = Enums.Relation.Equal;
            Expression = Enums.Expression.Comma;
            ParamName = null;
        }
        public SqlParam(string fieldName, object fieldValue)
            : base()
        {
            FieldName = fieldName.ToString();
            FieldValue = fieldValue;
            Operator = Enums.Relation.Equal;
            Expression = Enums.Expression.Comma;
            ParamName = null;
        }
    }

    public static class SqlParamExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lst"></param>
        /// <param name="fieldName"></param>
        /// <param name="fieldValue"></param>
        /// <param name="oper"></param>
        /// <param name="exp"></param>
        /// <param name="paramName">自定义参数名(不需要@)</param>
        /// <returns></returns>
        public static List<SqlParam> AddParam(this List<SqlParam> lst, Enum fieldName, object fieldValue, Enums.Relation oper, Enums.Expression exp, string paramName)
        {
            lst.Add(new SqlParam(fieldName, fieldValue, oper, exp, paramName));
            return lst;
        }
        public static List<SqlParam> AddParam(this List<SqlParam> lst, Enum fieldName, object fieldValue, Enums.Relation oper, Enums.Expression exp)
        {
            lst.Add(new SqlParam(fieldName, fieldValue, oper, exp));
            return lst;
        }
        public static List<SqlParam> AddParam(this List<SqlParam> lst, Enum fieldName, object fieldValue, Enums.Relation oper)
        {
            lst.Add(new SqlParam(fieldName, fieldValue, oper));
            return lst;
        }
        public static List<SqlParam> AddParam(this List<SqlParam> lst, Enum fieldName, object fieldValue)
        {
            lst.Add(new SqlParam(fieldName, fieldValue));
            return lst;
        }
       
        //public static List<SqlParam> AddParam(this List<SqlParam> lst, SqlParam sqlParam)
        //{
        //    lst.Add(sqlParam);
        //    return lst;
        //}
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
