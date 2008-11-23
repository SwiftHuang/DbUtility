using System;
using System.Data;

namespace hwj.DBUtility.TableMapping
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FieldMappingAttribute : System.Attribute
    {
        public FieldMappingAttribute(string dataFieldName, DbType dataTypeCode, object nullValue, params Enums.DataHandle[] dataHandles)
            : base()
        {
            _dataFieldName = dataFieldName;
            _nullValue = nullValue;
            _dataTypeCode = dataTypeCode;
            _dataHandles = dataHandles;
        }

        public FieldMappingAttribute(string dataFieldName, DbType dataTypeCode, params Enums.DataHandle[] dataHandles) : this(dataFieldName, dataTypeCode, null, dataHandles) { }
        public FieldMappingAttribute(string dataFieldName, DbType dataTypeCode) : this(dataFieldName, dataTypeCode, null, null) { }

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
        public Enums.DataHandle[] _dataHandles;
        public Enums.DataHandle[] DataHandles
        {
            get { return _dataHandles; }
        }
        #endregion
    }
}
