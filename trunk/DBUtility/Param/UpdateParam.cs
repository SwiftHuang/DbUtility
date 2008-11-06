using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hwj.DBUtility
{
    public class UpdateParam : List<UpdateFields>
    {

    }
    public class UpdateFields : SqlParam
    {
        public UpdateFields(Enum fieldName, object fieldValue)
            : base(fieldName, fieldValue, Enums.Operator.Equal)
        {
        }
    }
    public class SelectFields : List<Enum>
    {
    }
}
