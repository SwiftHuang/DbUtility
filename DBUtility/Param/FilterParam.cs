using System;
using System.Collections.Generic;

namespace hwj.DBUtility
{
    public class FilterParams : List<SqlParam>
    {
        public FilterParams(Enum fieldName, object fieldValue, Enums.Operator oper, Enums.Expression exp)
            : base()
        {
            this.AddParam(fieldName, fieldValue, oper, exp);
        }
        public FilterParams(Enum fieldName, object fieldValue, Enums.Operator oper)
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
    }
}
