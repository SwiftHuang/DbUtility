using System;
using System.Collections.Generic;
using System.Text;

namespace hwj.MarkTableObject.Entity
{
    public class DALInfo
    {
        public EntityInfo EntityInfo { get; set; }
        public string Namespace { get; set; }
        public string FileName { get; set; }
        public DatabaseEnum ConnType { get; set; }
        public DBModule Module { get; set; }
        /// <summary>
        /// 前缀字符
        /// </summary>
        public string PrefixChar { get; set; }
        public string DALName { get; set; }

        public DALInfo(GeneralInfo genInfo, DBModule module, string tableName)
            : this(genInfo, module, tableName, string.Empty, null)
        {
        }
        public DALInfo(GeneralInfo genInfo, DBModule module, string tableName, string commandText, ColumnInfos columnInfos)
        {
            EntityInfo = new EntityInfo(genInfo, module, tableName);
            EntityInfo.CommandText = commandText;
            if (columnInfos == null)
            {
                EntityInfo.InitColumnInfoList();
            }
            else
            {
                EntityInfo.InitColumnInfoList(columnInfos);
            }
            Namespace = genInfo.DataAccessNamespace;
            ConnType = genInfo.Database.DatabaseType;
            Module = module;
            PrefixChar = genInfo.DataAccessPrefixChar;

            DALName = PrefixChar + tableName;
            FileName = string.Format("{0}\\{1}.cs", genInfo.DataAccessPath.TrimEnd('\\'), DALName);
        }

    }
}
