using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace hwj.DBUtility.TableMapping
{
    public class FieldMappingInfo
    {
        public FieldMappingInfo(FieldMappingInfo fieldMappingInfo)
        {
            Property = fieldMappingInfo.Property;
            FieldName = fieldMappingInfo.FieldName;
            NullValue = fieldMappingInfo.NullValue;
            DataTypeCode = fieldMappingInfo.DataTypeCode;
            FieldIndex = fieldMappingInfo.FieldIndex;
            DataHandles = fieldMappingInfo.DataHandles;
        }
        public FieldMappingInfo(PropertyInfo property, string fieldName, DbType typeCode, object nullValue, Enums.DataHandle[] dataHandles, int fieldIndex)
        {
            Property = property;
            FieldName = fieldName;
            NullValue = NullValue;
            DataTypeCode = typeCode;
            FieldIndex = fieldIndex;
            DataHandles = dataHandles;
        }

        #region Property
        public PropertyInfo Property { get; set; }
        public string FieldName { get; set; }
        public DbType DataTypeCode { get; set; }
        public object NullValue { get; set; }
        public int FieldIndex { get; set; }
        public Enums.DataHandle[] DataHandles { get; set; }
        #endregion

        #region Public Functions
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
                        lstFieldInfo.Add(new FieldMappingInfo(Property, Field.DataFieldName, Field.DataTypeCode, Field.NullValue, Field.DataHandles, -1));
                    }
                }
                DBCache.SetCache(entityID, lstFieldInfo);
            }
            else
                lstFieldInfo = (List<FieldMappingInfo>)DBCache.GetCache(entityID);

            return lstFieldInfo;
        }
        public static FieldMappingInfo GetFieldInfo(Type type, string fieldName)
        {
            foreach (FieldMappingInfo f in FieldMappingInfo.GetFieldMapping(type))
            {
                if (f.FieldName == fieldName)
                    return f;
            }
            return null;
        }
        #endregion
    }
}
