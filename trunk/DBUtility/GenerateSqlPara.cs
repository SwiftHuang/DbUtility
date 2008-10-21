using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WongTung.DBUtility
{
    public class GenerateSqlPara<T> where T : class, new()
    {
        #region Property
        public string FieldName { get; set; }
        public object FieldValue { get; set; }
        public Enums.Operator Operator { get; set; }
        #endregion

        public GenerateSqlPara(string fieldName, object fieldValue, Enums.Operator oper)
            : base()
        {
            FieldName = fieldName;
            FieldValue = fieldValue;
            Operator = oper;
        }

        public GenerateSqlPara(string fieldName, object fieldValue)
            : base()
        {
            FieldName = fieldName;
            FieldValue = fieldValue;
            Operator = Enums.Operator.Equal;
        }
    }
}
