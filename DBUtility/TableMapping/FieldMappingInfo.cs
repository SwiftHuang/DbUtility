using System;
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
    }
}
