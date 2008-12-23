using System.Collections.Generic;
using System;
namespace hwj.DBUtility.TableMapping
{
    public class BaseTable
    {
        protected BaseTable()
        {
            _assigned = new List<String>();
        }
        private List<String> _assigned = null;
        /// <summary>
        /// 获取或设置被赋值字段
        /// </summary>
        public List<String> Assigned
        {
            get { return _assigned; }
            set { _assigned = value; }
        }
    }
}
