using System;

namespace hwj.DBUtility
{
    public class SqlParam
    {
        private static DateTime _DatabaseDate = DateTime.Parse("9999-09-09");

        /// <summary>
        /// 设置为数据库当前时间日期
        /// </summary>
        public static DateTime DatabaseDate
        {
            get { return _DatabaseDate; }
        }

        #region Property

        /// <summary>
        /// 设置字段名
        /// </summary>
        public string FieldName { get; set; }

        /// <summary>
        /// 设置字段内容
        /// </summary>
        public object FieldValue { get; set; }

        /// <summary>
        /// 设置字段关系
        /// </summary>
        public Enums.Relation Operator { get; set; }

        /// <summary>
        /// 设置逻辑运算符
        /// </summary>
        public Enums.Expression Expression { get; set; }

        /// <summary>
        /// 设置为Unicode（值前加N）
        /// </summary>
        public bool? IsUnicode { get; set; }

        /// <summary>
        /// 自定义参数名(防止相同的参数名)
        /// </summary>
        public string ParamName { get; set; }

        /// <summary>
        /// 自定义SQL语句条件。
        /// eg. Where Field1=Field2 AND Field3='VINSON'
        /// Field1=Field2可以用以下语句实现:
        /// AddCustomParam("Field1=Field2", Enums.Expression.AND);
        /// </summary>
        public string CustomText { get; set; }

        /// <summary>
        /// 是否自定义SQL语句条件
        /// </summary>
        public bool IsCustomText { get; private set; }

        #endregion Property

        public SqlParam(Enum fieldName, object fieldValue, Enums.Relation oper, Enums.Expression exp, string paramName, bool? isUnicode)
            : this(fieldName.ToString(), fieldValue, oper, exp, paramName, isUnicode)
        {
        }

        public SqlParam(string fieldName, object fieldValue, Enums.Relation oper, Enums.Expression exp, string paramName, bool? isUnicode)
        {
            FieldName = fieldName.ToString();
            FieldValue = fieldValue;
            Operator = oper;
            Expression = exp;
            ParamName = paramName;
            IsUnicode = isUnicode;
            IsCustomText = false;
        }

        public SqlParam(Enum fieldName, object fieldValue, Enums.Relation oper, Enums.Expression exp, string paramName)
            : this(fieldName, fieldValue, oper, exp, paramName, null)
        {
        }

        public SqlParam(string fieldName, object fieldValue, Enums.Relation oper, Enums.Expression exp, string paramName)
            : this(fieldName, fieldValue, oper, exp, paramName, null)
        {
        }

        public SqlParam(Enum fieldName, object fieldValue, Enums.Relation oper, Enums.Expression exp)
            : this(fieldName, fieldValue, oper, exp, null, null)
        {
        }

        public SqlParam(string fieldName, object fieldValue, Enums.Relation oper, Enums.Expression exp)
            : this(fieldName, fieldValue, oper, exp, null, null)
        {
        }

        public SqlParam(Enum fieldName, object fieldValue, Enums.Relation oper)
            : this(fieldName, fieldValue, oper, Enums.Expression.Comma, null, null)
        {
        }

        public SqlParam(string fieldName, object fieldValue, Enums.Relation oper)
            : this(fieldName, fieldValue, oper, Enums.Expression.Comma, null, null)
        {
        }

        public SqlParam(Enum fieldName, object fieldValue)
            : this(fieldName, fieldValue, Enums.Relation.Equal, Enums.Expression.Comma, null, null)
        {
        }

        public SqlParam(string fieldName, object fieldValue)
            : this(fieldName, fieldValue, Enums.Relation.Equal, Enums.Expression.Comma, null, null)
        {
        }

        public SqlParam(string customText, Enums.Expression exp)
        {
            FieldName = null;
            FieldValue = null;
            CustomText = customText;
            Expression = exp;
            IsCustomText = true;
        }
    }

    //public static class SqlParamExtensions
    //{
    //    /// <summary>
    //    ///
    //    /// </summary>
    //    /// <param name="lst"></param>
    //    /// <param name="fieldName"></param>
    //    /// <param name="fieldValue"></param>
    //    /// <param name="oper"></param>
    //    /// <param name="exp"></param>
    //    /// <param name="paramName">自定义参数名(不需要@)</param>
    //    /// <returns></returns>
    //    public static List<SqlParam> AddParam(this List<SqlParam> lst, Enum fieldName, object fieldValue, Enums.Relation oper, Enums.Expression exp, string paramName)
    //    {
    //        lst.Add(new SqlParam(fieldName, fieldValue, oper, exp, paramName));
    //        return lst;
    //    }
    //    public static List<SqlParam> AddParam(this List<SqlParam> lst, Enum fieldName, object fieldValue, Enums.Relation oper, Enums.Expression exp)
    //    {
    //        lst.Add(new SqlParam(fieldName, fieldValue, oper, exp));
    //        return lst;
    //    }
    //    public static List<SqlParam> AddParam(this List<SqlParam> lst, Enum fieldName, object fieldValue, Enums.Relation oper)
    //    {
    //        lst.Add(new SqlParam(fieldName, fieldValue, oper));
    //        return lst;
    //    }
    //    public static List<SqlParam> AddParam(this List<SqlParam> lst, Enum fieldName, object fieldValue)
    //    {
    //        lst.Add(new SqlParam(fieldName, fieldValue));
    //        return lst;
    //    }

    //    public static List<SqlParam> AddParam(this List<SqlParam> lst, SqlParam sqlParam)
    //    {
    //        lst.Add(sqlParam);
    //        return lst;
    //    }
    //    public static List<UpdateFields> AddParam(this List<UpdateFields> lst, Enum fieldName, object fieldValue)
    //    {
    //        lst.Add(new UpdateFields(fieldName, fieldValue));
    //        return lst;
    //    }
    //    public static List<UpdateFields> AddParam(this List<UpdateFields> lst, string fieldName, object fieldValue)
    //    {
    //        lst.Add(new UpdateFields(fieldName, fieldValue));
    //        return lst;
    //    }
    //}
}