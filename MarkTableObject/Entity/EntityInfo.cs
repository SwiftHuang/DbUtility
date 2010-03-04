using System;
using System.Collections.Generic;
using System.Text;

namespace hwj.MarkTableObject.Entity
{
    public class EntityInfo
    {
        public string EntityName { get; set; }
        public string EntityPath { get; set; }
        public string NameSpace { get; set; }
        public ColumnInfos ColumnInfoList { get; set; }

        public EntityInfo()
        {
            ColumnInfoList = new ColumnInfos();
        }
    }
}
