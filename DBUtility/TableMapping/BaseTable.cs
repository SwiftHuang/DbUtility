using System.Collections.Generic;
using System;
using System.Xml.Serialization;

namespace hwj.DBUtility.TableMapping
{
    [Serializable]
    public abstract class BaseTable<T> : BaseSqlTable<T>
        where T : class, new()
    {

        public BaseTable(string tableName)
            : base(tableName)
        {
            _assigned = new List<String>();
            DBTableName = tableName;
        }

        private string DBTableName = string.Empty;
        public string GetTableName()
        {
            return DBTableName;
        }

        #region Use Assigned Status
        private bool _useAssigned = true;
        /// <summary>
        /// 设置是否使用赋值字段检测
        /// </summary>
        public void SetAssignedStatus(bool use)
        {
            _useAssigned = use;
        }
        /// <summary>
        /// 获取当前赋值字段检测状态
        /// </summary>
        public bool GetAssignedStatus()
        {
            return _useAssigned;
        }
        #endregion

        #region Assigned List
        private List<String> _assigned = null;
        /// <summary>
        /// 获取或设置被赋值字段
        /// </summary>
        public List<String> GetAssigned()
        {
            return _assigned;
        }
        public void RemoveAssigned(string fieldName)
        {
            if (_assigned != null)
                _assigned.Remove(fieldName);
        }
        protected void AddAssigned(string fieldName)
        {
            if (_assigned != null)
                _assigned.Add(fieldName);
        }
        #endregion

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

        public T Clone()
        {
            return (this.MemberwiseClone() as T);
        }

    }
}
