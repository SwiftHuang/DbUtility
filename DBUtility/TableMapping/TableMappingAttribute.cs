using System;
using System.Data;

namespace hwj.DBUtility.TableMapping
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FieldMappingAttribute : System.Attribute
    {
        public FieldMappingAttribute(string dataFieldName, DbType dataTypeCode, object nullValue)
            : base()
        {
            _dataFieldName = dataFieldName;
            _nullValue = nullValue;
            _dataTypeCode = dataTypeCode;
        }

        public FieldMappingAttribute(string dataFieldName, DbType dataTypeCode) : this(dataFieldName, dataTypeCode, null) { }

        #region Property
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
        private DbType _dataTypeCode;
        public DbType DataTypeCode
        {
            get { return _dataTypeCode; }
        }
        #endregion
    }
}
