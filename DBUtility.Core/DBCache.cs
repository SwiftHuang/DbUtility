using System.Collections.Generic;

namespace hwj.DBUtility.Core
{   
    public static class DBCache
    {
        private static Dictionary<string, List<TableMapping.FieldMappingInfo>> cache = new Dictionary<string, List<TableMapping.FieldMappingInfo>>();

        public static List<TableMapping.FieldMappingInfo> GetCache(string typeName)
        {
            List<TableMapping.FieldMappingInfo> info = null;
            try
            {
                info = (List<TableMapping.FieldMappingInfo>)cache[typeName];
            }
            catch (KeyNotFoundException) { }

            return info;
        }

        public static void SetCache(string typeName, List<TableMapping.FieldMappingInfo> mappingInfoList)
        {
            try
            {
                cache[typeName] = mappingInfoList;
            }
            catch
            {
                cache = new Dictionary<string, List<TableMapping.FieldMappingInfo>>();
                cache[typeName] = mappingInfoList;
            }
        }

        public static void ClearCache()
        {
            cache.Clear();
        }
    }
}