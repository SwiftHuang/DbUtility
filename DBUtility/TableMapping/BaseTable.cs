using System;
using System.Collections.Generic;

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

        #endregion Use Assigned Status

        #region Assigned List

        private List<String> _assigned = null;

        /// <summary>
        /// 获取或设置被赋值字段
        /// </summary>
        public List<String> GetAssigned()
        {
            return _assigned;
        }

        public void RemoveAssigned(Enum fieldName)
        {
            RemoveAssigned(fieldName.ToString());
        }

        public void RemoveAssigned(string fieldName)
        {
            if (_assigned != null)
                _assigned.Remove(fieldName);
        }

        protected void AddAssigned(string fieldName)
        {
            if (_assigned != null && !_assigned.Contains(fieldName))
            {
                _assigned.Add(fieldName);
            }
        }

        #endregion Assigned List

        #region CustomSqlText

        private List<KeyValuePair<string, string>> _CustomSqlText = null;

        public List<KeyValuePair<string, string>> GetCustomSqlText()
        {
            return _CustomSqlText;
        }

        public void RemoveCustomSqlText(Enum fieldName)
        {
            RemoveCustomSqlText(fieldName.ToString());
        }

        public void RemoveCustomSqlText(string fieldName)
        {
            if (_CustomSqlText != null)
                _CustomSqlText.RemoveAll(c => c.Key == fieldName);
        }

        /// <summary>
        /// 标示列为自定义SQL语句
        /// eg.INSERT INTO Table (Field1) Value(@@DBTS)
        /// AddCustomSqlText("Field1","@@DBTS")
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="sqlText"></param>
        public void AddCustomSqlText(Enum fieldName, string sqlText)
        {
            AddCustomSqlText(fieldName.ToString(), sqlText);
        }

        /// <summary>
        /// 标示列为自定义SQL语句
        /// eg.INSERT INTO Table (Field1) Value(@@DBTS)
        /// AddCustomSqlText("Field1","@@DBTS")
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="sqlText"></param>
        public void AddCustomSqlText(string fieldName, string sqlText)
        {
            if (_CustomSqlText == null)
                _CustomSqlText = new List<KeyValuePair<string, string>>();

            if (_CustomSqlText != null && !_CustomSqlText.Exists(c => c.Key == fieldName))
                _CustomSqlText.Add(new KeyValuePair<string, string>(fieldName, sqlText));
        }

        public bool ExistCustomSqlText(string fieldName)
        {
            if (_CustomSqlText == null)
                return false;
            else
            {
                return _CustomSqlText.Exists(c => c.Key == fieldName);
            }
        }

        internal string GetCustomSqlTextValue(string fieldName)
        {
            if (_CustomSqlText == null)
                return null;
            else
            {
                return _CustomSqlText.Find(c => c.Key == fieldName).Value;
            }
        }

        #endregion CustomSqlText

        #region Ignore UnInsert

        private List<String> _ignUnInsertList = null;

        internal bool ExistIgnoreUnInsert(string fieldName)
        {
            if (_ignUnInsertList != null && _ignUnInsertList.Count > 0)
            {
                return _ignUnInsertList.Contains(fieldName);
            }
            return false;
        }

        public void RemoveIgnoreUnInsert(Enum fieldName)
        {
            RemoveIgnoreUnInsert(fieldName.ToString());
        }

        public void RemoveIgnoreUnInsert(string fieldName)
        {
            if (_ignUnInsertList != null)
                _ignUnInsertList.Remove(fieldName);
        }

        public void AddIgnoreUnInsert(Enum fieldName)
        {
            AddIgnoreUnInsert(fieldName.ToString());
        }

        public void AddIgnoreUnInsert(string fieldName)
        {
            if (_ignUnInsertList == null)
                _ignUnInsertList = new List<string>();
            if (!_ignUnInsertList.Contains(fieldName))
            {
                _ignUnInsertList.Add(fieldName);
            }
        }

        #endregion Ignore UnInsert

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