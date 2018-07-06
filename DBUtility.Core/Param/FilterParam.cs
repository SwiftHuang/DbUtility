using System;
using System.Collections.Generic;

namespace hwj.DBUtility
{
    public class FilterParams : List<SqlParam>
    {
        public FilterParams(Enum fieldName, object fieldValue, Enums.Relation oper, Enums.Expression exp)
            : base()
        {
            this.AddParam(fieldName, fieldValue, oper, exp);
        }

        public FilterParams(Enum fieldName, object fieldValue, Enums.Relation oper)
            : base()
        {
            this.AddParam(fieldName, fieldValue, oper);
        }

        public FilterParams(Enum fieldName, object fieldValue)
            : base()
        {
            this.AddParam(fieldName, fieldValue);
        }

        public FilterParams()
            : base()
        {
        }

        /// <summary>
        /// Add a left brackets
        /// </summary>
        public void MarkedLeftBrackets()
        {
            this.Add(new SqlParam(string.Empty, "(", Enums.Relation.Equal, Enums.Expression.None));
        }

        /// <summary>
        /// Add a right brackets
        /// </summary>
        public void MarkedRightBrackets()
        {
            this.Add(new SqlParam(string.Empty, ")", Enums.Relation.Equal, Enums.Expression.None));
        }

        /// <summary>
        /// Add a right brackets
        /// </summary>
        /// <param name="expression"></param>
        public void MarkedRightBrackets(Enums.Expression expression)
        {
            this.Add(new SqlParam(string.Empty, ")", Enums.Relation.Equal, expression));
        }

        #region Add Param

        public void AddParam(Enum fieldName, object fieldValue, Enums.Relation oper, Enums.Expression exp, string paramName, bool isUnicode)
        {
            this.Add(new SqlParam(fieldName, fieldValue, oper, exp, paramName, isUnicode));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="fieldValue"></param>
        /// <param name="oper"></param>
        /// <param name="exp"></param>
        /// <param name="paramName">自定义参数名(不需要@)</param>
        public void AddParam(Enum fieldName, object fieldValue, Enums.Relation oper, Enums.Expression exp, string paramName)
        {
            this.Add(new SqlParam(fieldName, fieldValue, oper, exp, paramName));
        }

        public void AddParam(Enum fieldName, object fieldValue, Enums.Relation oper, Enums.Expression exp)
        {
            this.Add(new SqlParam(fieldName, fieldValue, oper, exp));
        }

        public void AddParam(Enum fieldName, object fieldValue, Enums.Relation oper)
        {
            this.Add(new SqlParam(fieldName, fieldValue, oper));
        }

        public void AddParam(Enum fieldName, object fieldValue)
        {
            this.Add(new SqlParam(fieldName, fieldValue));
        }

        /// <summary>
        /// 列名作为表达式的值。
        /// </summary>
        /// <param name="fieldName1">列名1</param>
        /// <param name="fieldName2">列名2</param>
        /// <param name="oper"></param>
        /// <param name="exp"></param>
        public void AddFieldParam(Enum fieldName1, Enum fieldName2, Enums.Relation oper, Enums.Expression exp)
        {
            string text = string.Format("{0}{1}{2}", fieldName1.ToString(), Enums.RelationString(oper), fieldName2.ToString());
            AddCustomParam(text, exp);
        }

        /// <summary>
        /// 自定义SQL语句条件。
        /// eg. Where Field1=Field2 AND Field3='VINSON'
        /// Field1=Field2可以用以下语句实现:
        /// AddCustomParam("Field1=Field2", Enums.Expression.AND);
        /// </summary>
        /// <param name="text"></param>
        /// <param name="exp"></param>
        public void AddCustomParam(string text, Enums.Expression exp)
        {
            this.Add(new SqlParam(text, exp));
        }

        #endregion Add Param
    }
}