using System;
using System.Collections.Generic;
using System.Text;

namespace hwj.MarkTableObject.Entity
{
    public class BLLInfo
    {
        public EntityInfo EntityInfo { get; set; }
        public DALInfo DALInfo { get; set; }
        public string Namespace { get; set; }
        public string FileName { get; set; }
        public DBModule Module { get; set; }
        /// <summary>
        /// 前缀字符
        /// </summary>
        public string PrefixChar { get; set; }
        public string Connection { get; set; }
        public string BLLName { get; set; }
        public ConnectionDataSourceType ConnType { get; set; }

        public BLLInfo(ProjectInfo prjInfo, DBModule module, string tableName)
        {
            DALInfo = new DALInfo(prjInfo, module, tableName);
            EntityInfo = DALInfo.EntityInfo;
            EntityInfo.InitColumnInfoList();
            Namespace = prjInfo.BusinessNamespace;
            ConnType = prjInfo.ConnectionDataSource;
            Module = module;
            PrefixChar = prjInfo.BusinessPrefixChar;
            Connection = prjInfo.BusinessConnection;

            BLLName = PrefixChar + tableName;
            FileName = string.Format("{0}\\{1}.cs", prjInfo.BusinessPath.TrimEnd('\\'), BLLName);
        }
    }
}
