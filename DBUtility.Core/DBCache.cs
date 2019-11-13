using hwj.DBUtility.Core.TableMapping;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;

namespace hwj.DBUtility.Core
{
    public static class DBCache
    {
        private static ConcurrentDictionary<string, List<TableMapping.FieldMappingInfo>> cache = new ConcurrentDictionary<string, List<TableMapping.FieldMappingInfo>>();

        public static List<TableMapping.FieldMappingInfo> GetCache(Type type)
        {
            return cache.GetOrAdd(type.ToString(), (key) =>
              {
                  List<FieldMappingInfo> lstFieldInfo = new List<FieldMappingInfo>();
                  foreach (PropertyInfo Property in type.GetProperties())
                  {
                      foreach (FieldMappingAttribute field in Property.GetCustomAttributes(typeof(FieldMappingAttribute), false))
                      {
                          lstFieldInfo.Add(new FieldMappingInfo(Property, field.DataFieldName, field.DataTypeCode, field.NullValue, field.Size, field.DataHandles, -1));
                      }
                  }
                  return lstFieldInfo;
              });
        }

        //public static List<TableMapping.FieldMappingInfo> GetCache(string typeName)
        //{
        //    List<TableMapping.FieldMappingInfo> info = null;
        //    try
        //    {
        //        info = (List<TableMapping.FieldMappingInfo>)cache[typeName];
        //    }
        //    catch (KeyNotFoundException) { }

        //    return info;
        //}

        //public static void SetCache(string typeName, List<TableMapping.FieldMappingInfo> mappingInfoList)
        //{
        //    try
        //    {
        //        cache[typeName] = mappingInfoList;
        //    }
        //    catch
        //    {
        //        cache = new ConcurrentDictionary<string, List<TableMapping.FieldMappingInfo>>();
        //        cache[typeName] = mappingInfoList;
        //    }
        //}

        public static void ClearCache()
        {
            cache.Clear();
        }
    }
}