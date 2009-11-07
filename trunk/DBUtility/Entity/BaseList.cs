using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using hwj.DBUtility;
using hwj.DBUtility.TableMapping;

namespace hwj.DBUtility.Entity
{
    public class BaseList<T, TS> : List<T>
        where T : BaseTable<T>, new()
        where TS : List<T>, new()
    {
        private Enum tmpField;
        private object tmpValue = null;
        private T tmpFindObj = null;
        public T ExFind(Enum field, object value)
        {
            if (field.Equals(tmpField) && value.Equals(tmpValue))
                return tmpFindObj;
            foreach (T t in this)
            {
                if (MatchData(field, value, t))
                {
                    tmpField = field;
                    tmpValue = value;
                    tmpFindObj = t;
                    return t;
                }
            }
            return null;
        }
        public List<T> ExFindAll(Enum field, object value)
        {
            List<T> lst = new List<T>();
            foreach (T t in this)
            {
                if (MatchData(field, value, t))
                    lst.Add(t);
            }
            return lst;
        }
        private bool MatchData(Enum field, object value, T entity)
        {
            FieldMappingInfo f = new FieldMappingInfo(FieldMappingInfo.GetFieldInfo(typeof(T), field.ToString()));
            return f.Property.GetValue(entity, null).Equals(value);
        }

        //public void SetSession(string key)
        //{
        //    HttpContext.Current.Session[key] = this;
        //}
        //public static TS GetSession(string key)
        //{
        //    if (HttpContext.Current.Session[key] != null)
        //        return (TS)HttpContext.Current.Session[key];
        //    else
        //        return null;
        //}
    }
}
