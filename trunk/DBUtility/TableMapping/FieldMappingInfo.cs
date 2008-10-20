using System;
using System.Collections.Generic;
using System.Reflection;

namespace WongTung.DBUtility.TableMapping
{
    public class FieldMappingInfo
    {
        public FieldMappingInfo(PropertyInfo property, string fieldName, object nullValue, Type dataType, int fieldIndex)
        {
            Property = property;
            FieldName = fieldName;
            NullValue = NullValue;
            DataType = dataType;
            FieldIndex = fieldIndex;
        }
        public PropertyInfo Property { get; set; }
        public string FieldName { get; set; }
        public object NullValue { get; set; }
        public Type DataType { get; set; }
        public int FieldIndex { get; set; }
        public static List<FieldMappingInfo> GetFieldMapping(Type type)
        {
            string entityID = type.ToString();
            List<FieldMappingInfo> lstFieldInfo = new List<FieldMappingInfo>();

            if (DBCache.GetCache(entityID) == null)
            {
                foreach (PropertyInfo Property in type.GetProperties())
                {
                    foreach (FieldMappingAttribute Field in Property.GetCustomAttributes(typeof(FieldMappingAttribute), false))
                    {
                        lstFieldInfo.Add(new FieldMappingInfo(Property, Field.DataFieldName, Field.NullValue, Field.DataType, -1));
                    }
                }
                DBCache.SetCache(entityID, lstFieldInfo);
            }
            else
                lstFieldInfo = (List<FieldMappingInfo>)DBCache.GetCache(entityID);

            return lstFieldInfo;
        }
    }
}
