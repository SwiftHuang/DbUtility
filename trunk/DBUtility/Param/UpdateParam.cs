using System;
using System.Collections.Generic;

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
        public UpdateFields(string fieldName, object fieldValue)
            : base(fieldName, fieldValue, Enums.Operator.Equal)
        {
        }
    }
    public class DisplayFields : List<Enum>
    {
        public DisplayFields(params Enum[] enums)
            : base()
        {
            foreach (Enum e in enums)
            {
                this.Add(e);
            }
        }
    }
    public class GroupParams : List<Enum>
    {
        public GroupParams(params Enum[] enums)
            : base()
        {
            foreach (Enum e in enums)
            {
                this.Add(e);
            }
        }
    }
}
