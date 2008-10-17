using System;
using System.Reflection;

namespace TableMapping
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FieldMappingAttribute : System.Attribute
    {
        public FieldMappingAttribute(string dataFieldName, object nullValue, Type dataType)
            : base()
        {
            _dataFieldName = dataFieldName;
            _nullValue = nullValue;
            _dataType = dataType;
        }

        //public FieldMappingAttribute(object nullValue) : this(string.Empty, nullValue, Type.String) { }
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
        private Type _dataType;
        public Type DataType
        {
            get { return _dataType; }
        }

        #endregion
    }

    public class FieldInfo
    {
        public FieldInfo(PropertyInfo property, string fieldName, object nullValue, Type dataType, int fieldIndex)
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
