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
    }
}
