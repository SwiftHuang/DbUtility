using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using hwj.CommonLibrary.Object;
using hwj.MarkTableObject.Entity;
using System.IO;

namespace hwj.MarkTableObject.BLL
{
    public class BuilderDAL
    {
        public static void CreateTableFile(ProjectInfo projectInfo, string tableName)
        {
            DALInfo dalInfo = new DALInfo(projectInfo, DBModule.Table, tableName);
            string text = CreateDALCode(dalInfo);
            hwj.MarkTableObject.Common.CreateFile(dalInfo.FileName, text);
        }
        private static string CreateDALCode(DALInfo dalInfo)
        {
            StringHelper.SpaceString strclass = new StringHelper.SpaceString();
            strclass.AppendLine("using System;");
            strclass.AppendLine("using System.Data;");
            strclass.AppendLine("using System.Text;");
            switch (dalInfo.ConnType)
            {
                case ConnectionDataSourceType.MSSQL:
                    strclass.AppendLine("using System.Data.SqlClient;");
                    break;
                case ConnectionDataSourceType.MYSQL:
                    strclass.AppendLine("using MySql.Data.MySqlClient;");
                    break;
                case ConnectionDataSourceType.OleDb:
                    strclass.AppendLine("using System.Data.OleDb;");
                    break;
                default:
                    break;
            }
            strclass.AppendLine("using hwj.DBUtility;");
            strclass.AppendLine("using hwj.DBUtility.MSSQL;");
            strclass.AppendLine("using " + dalInfo.EntityInfo.NameSpace + ";");
            strclass.AppendLine("");
            strclass.AppendLine("namespace " + dalInfo.Namespace);
            strclass.AppendLine("{");
            strclass.AppendLine(1, "/// <summary>");
            strclass.AppendLine(1, "/// DataAccess [" + dalInfo.Module.ToString() + ":" + dalInfo.EntityInfo.TableName + "]");
            strclass.AppendLine(1, "/// </summary>");
            strclass.AppendLine(1, "public class " + dalInfo.DALName + " : BaseDAL<" + dalInfo.EntityInfo.EntityName + ", " + dalInfo.EntityInfo.EntityName + "s>");
            strclass.AppendLine(1, "{");
            strclass.AppendLine(2, "public " + dalInfo.DALName + "(string connectionString)");
            strclass.AppendLine(3, ": base(connectionString)");
            strclass.AppendLine(2, "{");
            strclass.AppendLine(3, "TableName = " + dalInfo.EntityInfo.EntityName + ".DBTableName;");
            strclass.AppendLine(2, "}");

            strclass.AppendLine(1, "}");
            strclass.AppendLine("}");
            strclass.AppendLine("");

            return strclass.ToString();
        }
    }
}
