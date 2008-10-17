using System;
using System.Collections.Generic;

namespace WongTung.DBUtility
{
    internal static class DBCache
    {
        private static Dictionary<string, List<TableMapping.FieldMappingInfo>> cache = new Dictionary<string, List<TableMapping.FieldMappingInfo>>();
        internal static List<TableMapping.FieldMappingInfo> GetCache(string typeName)
        {
            List<TableMapping.FieldMappingInfo> info = null;
            try
            {
                info = (List<TableMapping.FieldMappingInfo>)cache[typeName];

            }
            catch (KeyNotFoundException) { }

            return info;
        }

        internal static void SetCache(string typeName, List<TableMapping.FieldMappingInfo> mappingInfoList)
        {
            cache[typeName] = mappingInfoList;
        }

        public static void ClearCache()
        {
            cache.Clear();
        }
    }
}

