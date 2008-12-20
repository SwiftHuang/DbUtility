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
        public List<String> Assigned
        {
            get { return _assigned; }
            set { _assigned = value; }
        }
    }
}
