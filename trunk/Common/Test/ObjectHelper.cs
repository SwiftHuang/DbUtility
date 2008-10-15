using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Data;
using DataMapping;

namespace DataMapping
{
    public static class ObjectHelper
    {
        private static List<PropertyMappingInfo> LoadPropertyMappingInfo(Type objType)
        {
            Dictionary<string, PropertyInfo> ffff = new Dictionary<string, PropertyInfo>();
            List<PropertyMappingInfo> mapInfoList = new List<PropertyMappingInfo>();
            foreach (PropertyInfo info in objType.GetProperties())
            {
                MappingAttribute mapAttr = (MappingAttribute)Attribute.GetCustomAttribute(info, typeof(MappingAttribute));
                if (mapAttr != null)
                {
                    PropertyMappingInfo mapInfo = new PropertyMappingInfo(mapAttr.DataFieldName, mapAttr.NullValue, info);
                    mapInfoList.Add(mapInfo);
                }
            }
            return mapInfoList;
        }


        public static List<PropertyMappingInfo> GetProperties(Type objType)
        {
            List<PropertyMappingInfo> info = MappingInfoCache.GetCache(objType.Name);
            if (info == null)
            {
                info = LoadPropertyMappingInfo(objType);
                MappingInfoCache.SetCache(objType.Name, info);
            }
            return info;
        }


        private static int[] GetOrdinals(List<PropertyMappingInfo> propMapList, IDataReader dr)
        {
            int[] ordinals = new int[propMapList.Count];
            if (dr != null)
            {
                for (int i = 0; i <= propMapList.Count - 1; i++)
                {
                    ordinals[i] = -1;
                    try
                    {
                        ordinals[i] = dr.GetOrdinal(propMapList[i].DataFieldName);
                    }
                    catch (IndexOutOfRangeException)
                    {

                    }
                }
            }

            return ordinals;
        }

        private static T CreateObject<T>(IDataReader dr, List<PropertyMappingInfo> propInfoList, int[] ordinals) where T : class, new()
        {
            T obj = new T();
            for (int i = 0; i <= propInfoList.Count - 1; i++)
            {

                Type type = propInfoList[i].PropertyInfo.PropertyType;
                object value = propInfoList[i].DefaultValue;
                try
                {
                    if (ordinals[i] != -1)
                    {
                        value = dr.GetValue(ordinals[i]);
                        try
                        {
                            if (DBNull.Value != value)
                                propInfoList[i].PropertyInfo.SetValue(obj, value, null);
                        }
                        catch
                        {
                            try
                            {
                                if (!string.IsNullOrEmpty(value.ToString()))
                                {
                                    if (type.BaseType.Equals(typeof(System.Enum)))
                                    {
                                        propInfoList[i].PropertyInfo.SetValue(obj, System.Enum.ToObject(type, value), null);
                                    }
                                    else
                                    {
                                        propInfoList[i].PropertyInfo.SetValue(obj, Convert.ChangeType(value, type), null);
                                    }
                                }
                            }
                            catch
                            {

                            }
                        }
                    }
                    else
                    {
                        if (type == typeof(Int32) || type == typeof(int) || type == typeof(Int16) || type == typeof(Int64) || type == typeof(Decimal) || type == typeof(Double))
                            value = 0;
                        else if (type == typeof(Boolean))
                            value = false;
                        else if (type == typeof(DateTime))
                            value = DateTime.MinValue;
                        else
                            value = string.Empty;
                    }
                }
                catch { }

            }
            return obj;
        }

        public static T FillObject<T>(Type objType, IDataReader dr) where T : class, new()
        {
            T obj = null;
            try
            {
                List<PropertyMappingInfo> mapInfo = GetProperties(objType);
                int[] ordinals = GetOrdinals(mapInfo, dr);
                if (dr.Read())
                {
                    obj = CreateObject<T>(dr, mapInfo, ordinals);
                }
            }
            finally
            {
                if (dr.IsClosed == false)
                {
                    dr.Close();
                }
            }
            return obj;
        }

        public static C FillCollection<T, C>(Type objType, IDataReader dr)
            where T : class, new()
            where C : ICollection<T>, new()
        {
            C coll = new C();
            try
            {
                List<PropertyMappingInfo> mapInfo = GetProperties(objType);
                int[] ordinals = GetOrdinals(mapInfo, dr);
                while (dr.Read())
                {
                    T obj = CreateObject<T>(dr, mapInfo, ordinals);
                    coll.Add(obj);
                }
            }
            catch (Exception ex) { throw new Exception(ex.ToString()); }
            //finally
            //{
            //    if (dr.IsClosed == false && dr.NextResult() == false)
            //    {
            //        dr.Close();
            //    }
            //}
            return coll;
        }




    }
}
