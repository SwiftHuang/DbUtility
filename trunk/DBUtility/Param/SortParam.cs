using System;
using System.Collections.Generic;

namespace hwj.DBUtility
{
    public class SortParam
    {
        #region Property
        public string FieldName { get; set; }
        public Enums.OrderBy OrderBy { get; set; }
        #endregion

        public SortParam(Enum fieldName, Enums.OrderBy order)
            : base()
        {
            FieldName = fieldName.ToString();
            OrderBy = order;
        }
        public SortParam(string fieldName, Enums.OrderBy order)
            : base()
        {
            FieldName = fieldName;
            OrderBy = order;
        }
    }
    public class SortParams : List<SortParam>
    {
    }

    public static class OrderParamExtensions
    {
        public static SortParams AddParam(this SortParams lst, Enum fieldName, Enums.OrderBy order)
        {
            lst.Add(new SortParam(fieldName, order));
            return lst;
        }
        public static SortParams AddParam(this SortParams lst, string fieldName, Enums.OrderBy order)
        {
            lst.Add(new SortParam(fieldName, order));
            return lst;
        }
    }
}
