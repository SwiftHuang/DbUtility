using System;
using System.Collections.Generic;
using System.Text;

namespace hwj.MarkTableObject.Entity
{
    public class GeneralInfo
    {
        public string FileName { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public string MainPath { get; set; }
        public DatabaseInfo Database { get; set; }
        public TemplateType Template { get; set; }
        public DBModule ObjectModule { get; set; }
        public string BusinessConnection { get; set; }

        public string BusinessNamespace { get; set; }
        public string BusinessPath { get; set; }
        public string BusinessPrefixChar { get; set; }


        public string DataAccessNamespace { get; set; }
        public string DataAccessPath { get; set; }
        public string DataAccessPrefixChar { get; set; }

        public string EntityNamespace { get; set; }
        public string EntityPath { get; set; }
        public string EntityPrefixChar { get; set; }

        //public string DataSourceName { get; set; }
        public bool IsNetCore { get; set; }

        public GeneralInfo()
        {

        }

        public GeneralInfo(ProjectInfo prjInfo, DBModule objectModule)
        {
            this.Template = prjInfo.Template;
            this.IsNetCore = prjInfo.IsNetCore;
            if (objectModule == DBModule.View)
            {
                this.Database = prjInfo.Database;
                this.ObjectModule = DBModule.View;
                this.BusinessConnection = prjInfo.BusinessConnection;

                this.BusinessNamespace = prjInfo.BusinessNamespace4View;
                this.BusinessPath = prjInfo.BusinessPath4View;
                this.BusinessPrefixChar = prjInfo.BusinessPrefixChar4View;

                this.DataAccessNamespace = prjInfo.DataAccessNamespace4View;
                this.DataAccessPath = prjInfo.DataAccessPath4View;
                this.DataAccessPrefixChar = prjInfo.DataAccessPrefixChar4View;

                this.EntityNamespace = prjInfo.EntityNamespace4View;
                this.EntityPath = prjInfo.EntityPath4View;
                this.EntityPrefixChar = prjInfo.EntityPrefixChar4View;
            }
            else
            {
                this.Database = prjInfo.Database;
                this.ObjectModule = objectModule;
                this.BusinessConnection = prjInfo.BusinessConnection;

                this.BusinessNamespace = prjInfo.BusinessNamespace;
                this.BusinessPath = prjInfo.BusinessPath;
                this.BusinessPrefixChar = prjInfo.BusinessPrefixChar;

                this.DataAccessNamespace = prjInfo.DataAccessNamespace;
                this.DataAccessPath = prjInfo.DataAccessPath;
                this.DataAccessPrefixChar = prjInfo.DataAccessPrefixChar;

                this.EntityNamespace = prjInfo.EntityNamespace;
                this.EntityPath = prjInfo.EntityPath;
                this.EntityPrefixChar = prjInfo.EntityPrefixChar;
            }
        }
    }
}
