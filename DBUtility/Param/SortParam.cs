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
        public SortParams(Enum filedName)
            : base()
        {
            this.AddParam(filedName, Enums.OrderBy.Ascending);
        }
        public SortParams(Enum filedName, Enums.OrderBy order)
            : base()
        {
            this.AddParam(filedName, order);
        }
        public SortParams()
            : base()
        {
        }
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
