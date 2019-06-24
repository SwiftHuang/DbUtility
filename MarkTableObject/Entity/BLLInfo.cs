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
        public DatabaseEnum ConnType { get; set; }
        public bool IsNetCore { get; set; }

        public BLLInfo(GeneralInfo genInfo, DBModule module, string tableName)
            : this(genInfo, module, tableName, string.Empty, null)
        {

        }

        public BLLInfo(GeneralInfo genInfo, DBModule module, string tableName, string commandText, ColumnInfos columnInfos)
        {
            DALInfo = new DALInfo(genInfo, module, tableName, commandText, columnInfos);
            EntityInfo = DALInfo.EntityInfo;

            Namespace = genInfo.BusinessNamespace;
            ConnType = genInfo.Database.DatabaseType;
            Module = module;
            PrefixChar = genInfo.BusinessPrefixChar;
            Connection = genInfo.BusinessConnection;

            BLLName = PrefixChar + tableName;
            FileName = string.Format("{0}\\{1}.cs", genInfo.BusinessPath.TrimEnd('\\'), BLLName);
            IsNetCore = genInfo.IsNetCore;
        }
    }
}
