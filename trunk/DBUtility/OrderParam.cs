using System;
using System.Collections.Generic;

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


    public static class OrderParamExtensions
    {
        public static List<OrderParam> AddParam(this List<OrderParam> lst, Enum fieldName, Enums.OrderBy order)
        {
            lst.Add(new OrderParam(fieldName, order));
            return lst;
        }
        public static List<OrderParam> AddParam(this List<OrderParam> lst, string fieldName, Enums.OrderBy order)
        {
            lst.Add(new OrderParam(fieldName, order));
            return lst;
        }
    }
}
