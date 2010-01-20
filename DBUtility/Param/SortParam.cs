using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace hwj.DBUtility
{
    /// <summary>
    /// Sort parameter
    /// </summary>
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


        public void AddParam(string fieldName, ListSortDirection sort, bool filterRepeat)
        {
            this.AddParam(fieldName, sort == ListSortDirection.Descending ? Enums.OrderBy.Descending : Enums.OrderBy.Ascending, filterRepeat);
        }
        public void AddParam(Enum fieldName, Enums.OrderBy order, bool filterRepeat)
        {
            if (filterRepeat)
            {
                foreach (SortParam p in this)
                {
                    if (p.FieldName.ToUpper() == fieldName.ToString().ToUpper())
                        return;
                }
            }
            this.Add(new SortParam(fieldName, order));
        }
        public void AddParam(string fieldName, Enums.OrderBy order, bool filterRepeat)
        {
            if (filterRepeat)
            {
                foreach (SortParam p in this)
                {
                    if (p.FieldName.ToUpper() == fieldName.ToUpper())
                        return;
                }
            }
            this.Add(new SortParam(fieldName, order));
        }
        public void AddParam(Enum fieldName, Enums.OrderBy order)
        {
            this.Add(new SortParam(fieldName, order));
        }
        public void AddParam(string fieldName, Enums.OrderBy order)
        {
            this.Add(new SortParam(fieldName, order));
        }
    }

    //public static class OrderParamExtensions
    //{
    //    public static SortParams AddParam(this SortParams lst, string fieldName, ListSortDirection sort, bool filterRepeat)
    //    {
    //        return AddParam(lst, fieldName, sort == ListSortDirection.Descending ? Enums.OrderBy.Descending : Enums.OrderBy.Ascending, filterRepeat);
    //    }
    //    public static SortParams AddParam(this SortParams lst, Enum fieldName, Enums.OrderBy order, bool filterRepeat)
    //    {
    //        if (filterRepeat)
    //        {
    //            foreach (SortParam p in lst)
    //            {
    //                if (p.FieldName.ToUpper() == fieldName.ToString().ToUpper())
    //                    return lst;
    //            }
    //        }
    //        lst.Add(new SortParam(fieldName, order));
    //        return lst;
    //    }
    //    public static SortParams AddParam(this SortParams lst, string fieldName, Enums.OrderBy order, bool filterRepeat)
    //    {
    //        if (filterRepeat)
    //        {
    //            foreach (SortParam p in lst)
    //            {
    //                if (p.FieldName.ToUpper() == fieldName.ToUpper())
    //                    return lst;
    //            }
    //        }
    //        lst.Add(new SortParam(fieldName, order));
    //        return lst;
    //    }
    //    public static SortParams AddParam(this SortParams lst, Enum fieldName, Enums.OrderBy order)
    //    {
    //        lst.Add(new SortParam(fieldName, order));
    //        return lst;
    //    }
    //    public static SortParams AddParam(this SortParams lst, string fieldName, Enums.OrderBy order)
    //    {
    //        lst.Add(new SortParam(fieldName, order));
    //        return lst;
    //    }
    //}
}
