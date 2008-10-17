using System;
using System.Reflection;

namespace WongTung.DBUtility.TableMapping
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


}
