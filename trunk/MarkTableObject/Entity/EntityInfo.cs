using System;
using System.Collections.Generic;
using System.Text;

namespace hwj.MarkTableObject.Entity
{
    public class EntityInfo
    {
        public string EntityName { get; set; }
        public string TableName { get; set; }
        public string ConnectionString { get; set; }
        public string FileName { get; set; }
        public string NameSpace { get; set; }
        public ColumnInfos ColumnInfoList { get; set; }
        public ColumnInfos PKColumnInfoList { get; set; }
        public string PKColumnParam { get; set; }
        public ConnectionDataSourceType ConnType { get; set; }
        public DBModule Module { get; set; }
        public string CommandText { get; set; }
        /// <summary>
        /// 前缀字符
        /// </summary>
        public string PrefixChar { get; set; }

        public EntityInfo()
        {
            ColumnInfoList = new ColumnInfos();
        }

        public EntityInfo(ProjectInfo prjInfo, DBModule module, string tableName)
        {
            Module = module;
            ConnType = prjInfo.ConnectionDataSource;
            ConnectionString = prjInfo.ConnectionString;
            NameSpace = prjInfo.EntityNamespace;
            TableName = tableName;
            PrefixChar = prjInfo.EntityPrefixChar;

            EntityName = PrefixChar + TableName;
            FileName = string.Format("{0}\\{1}.cs", prjInfo.EntityPath.TrimEnd('\\'), EntityName);
        }
        public void InitColumnInfoList()
        {
            ColumnInfoList = BLL.MSSQL.BuilderColumn.GetColumnInfoForTable(this);
            InitColumnInfoList(ColumnInfoList);
        }
        public void InitColumnInfoList(ColumnInfos columnInfoList)
        {
            switch (this.ConnType)
            {
                case ConnectionDataSourceType.MSSQL:
                    StringBuilder sb = new StringBuilder();
                    PKColumnInfoList = new ColumnInfos();
                    ColumnInfoList = columnInfoList;

                    foreach (ColumnInfo c in ColumnInfoList)
                    {
                        if (c.IsKey)
                        {
                            PKColumnInfoList.Add(c);
                            sb.Append(FormatParam(c));
                        }
                    }
                    PKColumnParam = sb.ToString().TrimEnd(',').Trim();
                    break;
                case ConnectionDataSourceType.MYSQL:
                    break;
                case ConnectionDataSourceType.OleDb:
                    break;
                default:
                    break;
            }
        }
        private string FormatParam(ColumnInfo col)
        {
            string strType = col.DataType.Replace("System.", "");
            strType = strType.Substring(0, 1).ToLower() + strType.Substring(1);
            return string.Format(" {0} {1},", strType, col.ColumnName);
        }
    }
}
