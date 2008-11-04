using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WongTung.DBUtility
{
    public class OrderParam
    {
        #region Property
        public string FieldName { get; set; }
        public Enums.OrderBy OrderBy { get; set; }
        #endregion

        public OrderParam(Enum fieldName, Enums.OrderBy order)
            : base()
        {
            FieldName = fieldName.ToString();
            OrderBy = order;
        }
        public OrderParam(string fieldName, Enums.OrderBy order)
            : base()
        {
            FieldName = fieldName;
            OrderBy = order;
        }



    }
}
