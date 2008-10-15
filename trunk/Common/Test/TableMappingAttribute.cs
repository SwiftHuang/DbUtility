using System;
using System.Reflection;

namespace TableMapping
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FieldMappingAttribute : System.Attribute
    {
        public FieldMappingAttribute(string dataFieldName, object nullValue, TypeCode dataType)
            : base()
        {
            _dataFieldName = dataFieldName;
            _nullValue = nullValue;
            _dataType = dataType;
        }

        public FieldMappingAttribute(object nullValue) : this(string.Empty, nullValue, TypeCode.String) { }
        #region Attributes
        private string _dataFieldName;
        public string DataFieldName
        {
            get { return _dataFieldName; }
        }
        private object _nullValue;
        public object NullValue
        {
            get { return _nullValue; }
        }
        private TypeCode _dataType;
        public TypeCode DataType
        {
            get { return _dataType; }
        }

        #endregion
    }

    public class FieldInfo
    {
        public FieldInfo(PropertyInfo property, string fieldName, object nullValue, TypeCode dataType, int fieldIndex)
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
        public TypeCode DataType { get; set; }
        public int FieldIndex { get; set; }
    }
}
