using System;
using System.Collections.Generic;
using System.Text;

namespace hwj.MarkTableObject.Entity
{
    [Serializable]
    public class ProjectInfo
    {
        public string Name { get; set; }
        public string MainPath { get; set; }
        public string BusinessNameSpace { get; set; }
        public string BusinessPath { get; set; }
        public string DataAccessNameSpace { get; set; }
        public string DataAccessPath { get; set; }
        public string EntityNameSpace { get; set; }
        public string EntityPath { get; set; }
        public ConnectionDataSourceType ConnectionDataSource { get; set; }
        public string ConnectionString { get; set; }
        public string FileName { get; set; }
        public string Key { get; set; }

        public ProjectInfo()
        {

        }
    }
}
