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
            TableMapping.FieldMappingInfo.GetFieldInfo(typeof(T), fieldName).Property.SetValue(entity, value, null);
        }
    }
}
