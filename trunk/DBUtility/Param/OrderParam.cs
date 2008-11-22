using System;
using System.Collections.Generic;

namespace hwj.DBUtility
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
    public class SortFields : List<OrderParam>
    {
    }

    public static class OrderParamExtensions
    {
        public static SortFields AddParam(this SortFields lst, Enum fieldName, Enums.OrderBy order)
        {
            lst.Add(new OrderParam(fieldName, order));
            return lst;
        }
        public static SortFields AddParam(this SortFields lst, string fieldName, Enums.OrderBy order)
        {
            lst.Add(new OrderParam(fieldName, order));
            return lst;
        }
    }
}
