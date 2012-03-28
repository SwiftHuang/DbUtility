using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using hwj.DBUtility;
using hwj.DBUtility.TableMapping;
using System.ComponentModel;

namespace hwj.DBUtility.Entity
{
    [Serializable]
    public class BaseList<T, TS> : List<T>
        where T : BaseSqlTable<T>, new()
        where TS : List<T>, new()
    {
        //private object tmpValue = null;
        //private T tmpFindObj = null;

        private Enum tmpBSField;
        private object tmpBSValue = null;
        private T tmpBSObj = null;

        public bool Exists(Enum field, object value)
        {
            T obj = Find(field, value);
            if (obj != null)
                return true;
            else
                return false;
        }
        public T Find(Enum field, object value)
        {
            return ExFind(field, value);
        }
        /// <summary>
        /// 请使用Find代替ExFind
        /// </summary>
        /// <param name="field">列枚举</param>
        /// <param name="value">列值</param>
        /// <returns></returns>
        public T ExFind(Enum field, object value)
        {
            //if (field != null && value != null && field.Equals(tmpField) && value.Equals(tmpValue))
            //    return tmpFindObj;
            //else
            //{
            FieldMappingInfo f = new FieldMappingInfo(FieldMappingInfo.GetFieldInfo(typeof(T), field.ToString()));

            foreach (T t in this)
            {
                if (MatchData(f, value, t))
                {
                    //tmpField = field;
                    //tmpValue = value;
                    //tmpFindObj = t;
                    return t;
                }
            }
            return null;
            //}
        }
        public T BinarySearch(Enum field, string value)
        {
            if (field != null && value != null && field.Equals(tmpBSField) && value.Equals(tmpBSValue))
                return tmpBSObj;
            else
            {
                FieldMappingInfo f = new FieldMappingInfo(FieldMappingInfo.GetFieldInfo(typeof(T), field.ToString()));
                T entity = BinarySearch(f, value);
                tmpBSField = field;
                tmpBSValue = value;
                tmpBSObj = entity;
                return entity;
            }
        }

        public TS FindAll(Enum field, object value)
        {
            return ExFindAll(field, value);
        }
        /// <summary>
        /// 请使用FindAll代替ExFindAll
        /// </summary>
        /// <param name="field">列枚举</param>
        /// <param name="value">列值</param>
        /// <returns></returns>
        public TS ExFindAll(Enum field, object value)
        {
            TS lst = new TS();
            FieldMappingInfo f = new FieldMappingInfo(FieldMappingInfo.GetFieldInfo(typeof(T), field.ToString()));

            foreach (T t in this)
            {
                if (MatchData(f, value, t))
                    lst.Add(t);
            }
            return lst;
        }
        public TS Like(Enum field, string value)
        {
            TS lst = new TS();
            FieldMappingInfo f = new FieldMappingInfo(FieldMappingInfo.GetFieldInfo(typeof(T), field.ToString()));

            foreach (T t in this)
            {
                if (MatchLikeData(f, value, t))
                    lst.Add(t);
            }
            return lst;
        }

        public List<T> Sort(Enum field, ListSortDirection direction)
        {
            return Sort(field.ToString(), direction);
        }
        public List<T> Sort(string fieldName, ListSortDirection direction)
        {
            Reverser<T> reverser = new Reverser<T>(this.GetType(), fieldName, direction);
            Sort(reverser);
            return this;
        }

        private bool MatchData(FieldMappingInfo fieldMappingInfo, object value, T entity)
        {
            return fieldMappingInfo.Property.GetValue(entity, null).Equals(value);
        }
        private bool MatchLikeData(FieldMappingInfo fieldMappingInfo, string value, T entity)
        {
            object obj = fieldMappingInfo.Property.GetValue(entity, null);
            if (obj != null)
                return obj.ToString().IndexOf(value) > -1;
            return false;
        }
        private bool LessThanData(FieldMappingInfo fieldMappingInfo, string value, T entity)
        {
            return value.CompareTo(fieldMappingInfo.Property.GetValue(entity, null)) < 0;
        }
        /// <summary>
        ///  二分法
        /// </summary>
        /// <param name="fieldMappingInfo"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private T BinarySearch(FieldMappingInfo fieldMappingInfo, string value)
        {
            if (value == null)
                return null;
            int low = 0;
            int high = this.Count - 1;

            while (low <= high)
            {
                int mid = (low + high) / 2;
                T entity = this[mid];// list[mid];
                if (MatchData(fieldMappingInfo, value, entity))
                {
                    return entity;
                }
                else
                {
                    if (LessThanData(fieldMappingInfo, value, entity))
                    {
                        high = mid - 1;
                    }
                    else
                    {
                        low = mid + 1;
                    }
                }
            }

            return null;
        }
        //private void ClearTemp()
        //{
        //    tmpValue = null;
        //    tmpFindObj = null;
        //}
        //public new bool Remove(T item)
        //{
        //    ClearTemp();
        //    return this.Remove(item);

        //}
        //public new TS RemoveAt(int index)
        //{
        //    ClearTemp();
        //    return this.RemoveAt(index);
        //}

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
