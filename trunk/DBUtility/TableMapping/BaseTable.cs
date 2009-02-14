using System.Collections.Generic;
using System;
namespace hwj.DBUtility.TableMapping
{
    public class BaseTable<T> where T : BaseTable<T>
    {
        protected BaseTable()
        {
            _assigned = new List<String>();
        }
        private bool _useAssigned = true;
        /// <summary>
        /// 是否使用赋值字段检测
        /// </summary>
        public bool UseAssigned
        {
            get { return _useAssigned; }
            set
            {
                _useAssigned = value;
                if (value)
                    _assigned = new List<string>();
                else
                    _assigned = null;
            }
        }

        private List<String> _assigned = null;
        /// <summary>
        /// 获取或设置被赋值字段
        /// </summary>
        public List<String> Assigned
        {
            get { return _assigned; }
        }
        protected void AddAssigned(string columnName)
        {
            if (_assigned != null)
                _assigned.Add(columnName);
        }
        public static void SetValue(T entity, string fieldName, object value)
        {
            if (value != null)
            {
                FieldMappingInfo f = TableMapping.FieldMappingInfo.GetFieldInfo(typeof(T), fieldName);
                switch (f.DataTypeCode)
                {
                    case System.Data.DbType.DateTime:
                        value = Convert.ToDateTime(value);
                        break;
                    case System.Data.DbType.Decimal:
                        value = Convert.ToDecimal(value);
                        break;
                    case System.Data.DbType.Double:
                        value = Convert.ToDouble(value);
                        break;
                    case System.Data.DbType.Int16:
                        value = Convert.ToInt16(value);
                        break;
                    case System.Data.DbType.Int32:
                        value = Convert.ToInt32(value);
                        break;
                    case System.Data.DbType.Int64:
                        value = Convert.ToInt64(value);
                        break;
                    case System.Data.DbType.UInt16:
                        value = Convert.ToUInt16(value);
                        break;
                    case System.Data.DbType.UInt32:
                        value = Convert.ToUInt32(value);
                        break;
                    case System.Data.DbType.UInt64:
                        value = Convert.ToUInt64(value);
                        break;
                    default:
                        break;
                }
                f.Property.SetValue(entity, value, null);
            }
        }
    }
}
