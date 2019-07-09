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
        public static void CreateTableFile(GeneralInfo genInfo, string tableName, GeneralMethodInfo methodInfo)
        {
            DALInfo dalInfo = new DALInfo(genInfo, DBModule.Table, tableName);
            string text = CreateDALCode(dalInfo, genInfo.Template, methodInfo);
            hwj.MarkTableObject.Common.CreateFile(dalInfo.FileName, text);
        }
        public static string CreateDALCode(DALInfo dalInfo, TemplateType templateType, GeneralMethodInfo methodInfo)
        {
            StringHelper.SpaceString strclass = new StringHelper.SpaceString();
            strclass.AppendLine("using System;");
            strclass.AppendLine("using System.Collections.Generic;");
            strclass.AppendLine("using System.Text;");
            switch (dalInfo.ConnType)
            {
                case DatabaseEnum.MSSQL:
                    strclass.AppendLine("using System.Data.SqlClient;");
                    break;
                case DatabaseEnum.MYSQL:
                    strclass.AppendLine("using MySql.Data.MySqlClient;");
                    break;
                case DatabaseEnum.OleDb:
                    strclass.AppendLine("using System.Data.OleDb;");
                    break;
                default:
                    break;
            }
            strclass.AppendLine("using System.Data;");
            strclass.AppendLine("using hwj.DBUtility;".GetNamespace(dalInfo.IsNetCore));
            if (templateType == TemplateType.DataAccess)
            {
                strclass.AppendLine("using hwj.DBUtility.Interface;".GetNamespace(dalInfo.IsNetCore));
            }
            else if (templateType == TemplateType.DataAccess2)
            {
                strclass.AppendLine("using hwj.DBUtility.MSSQL.Interface;".GetNamespace(dalInfo.IsNetCore));
            }
            strclass.AppendLine("using hwj.DBUtility.MSSQL;".GetNamespace(dalInfo.IsNetCore));
            strclass.AppendLine("using " + dalInfo.EntityInfo.NameSpace + ";");
            strclass.AppendLine("");
            strclass.AppendLine("namespace " + dalInfo.Namespace);
            strclass.AppendLine("{");
            strclass.AppendLine(1, "/// <summary>");
            strclass.AppendLine(1, "/// DataAccess [" + dalInfo.Module.ToString() + ":" + dalInfo.EntityInfo.TableName + "]");
            strclass.AppendLine(1, "/// </summary>");

            if (dalInfo.Module == DBModule.SQL || dalInfo.Module == DBModule.SP)
            {
                if (templateType == TemplateType.Business)
                {
                    strclass.AppendLine(1, "public partial class " + dalInfo.DALName + " : BaseSqlDAL<" + dalInfo.EntityInfo.EntityName + ", " + dalInfo.EntityInfo.EntityName + "s>");
                }
                else
                {
                    strclass.AppendLine(1, "public partial class " + dalInfo.DALName + " : SelectDALDependency<" + dalInfo.EntityInfo.EntityName + ", " + dalInfo.EntityInfo.EntityName + "s>");
                }
            }
            else
            {
                if (templateType == TemplateType.Business)
                {
                    strclass.AppendLine(1, "public partial class " + dalInfo.DALName + " : BaseDAL<" + dalInfo.EntityInfo.EntityName + ", " + dalInfo.EntityInfo.EntityName + "s>");
                }
                else
                {
                    strclass.AppendLine(1, "public partial class " + dalInfo.DALName + " : DALDependency<" + dalInfo.EntityInfo.EntityName + ", " + dalInfo.EntityInfo.EntityName + "s>");
                }
            }

            strclass.AppendLine(1, "{");

            if (templateType == TemplateType.DataAccess)
            {
                strclass.AppendLine(2, "public " + dalInfo.DALName + "(IConnection conn)");
                strclass.AppendLine(3, ": base(conn)");
                strclass.AppendLine(2, "{ }");
            }
            else if (templateType == TemplateType.DataAccess2)
            {
                strclass.AppendLine(2, "public " + dalInfo.DALName + "(IMSSQLConnection conn)");
                strclass.AppendLine(3, ": base(conn)");
                strclass.AppendLine(2, "{ }");
            }
            else
            {
                strclass.AppendLine(2, "public " + dalInfo.DALName + "(string connectionString)");
                strclass.AppendLine(3, ": base(connectionString)");
                strclass.AppendLine(2, "{");

                if (dalInfo.Module == DBModule.SQL || dalInfo.Module == DBModule.SP)
                {
                    strclass.AppendLine(3, "CommandText = " + dalInfo.EntityInfo.EntityName + ".CommandText;");
                }
                else
                {
                    strclass.AppendLine(3, "TableName = " + dalInfo.EntityInfo.EntityName + ".DBTableName;");
                }
                strclass.AppendLine(2, "}");
            }

            if (templateType == TemplateType.DataAccess || templateType == TemplateType.DataAccess2)
            {
                BLL.BuilderBLL.GeneralMethod(methodInfo, templateType, dalInfo.EntityInfo, ref strclass);
            }

            GeneralSPParams(dalInfo, ref strclass);

            strclass.AppendLine(1, "}");
            strclass.AppendLine("}");
            strclass.AppendLine("");

            return strclass.ToString();
        }

        private static void GeneralSPParams(DALInfo dalInfo, ref  StringHelper.SpaceString strclass)
        {
            if (dalInfo.EntityInfo.SPParamInfos != null && dalInfo.EntityInfo.SPParamInfos.Count > 0)
            {
                strclass.AppendLine("");
                strclass.AppendLine(2, "public " + dalInfo.EntityInfo.EntityName + "s GetList(" + dalInfo.EntityInfo.SPParamString + ")");
                strclass.AppendLine(2, "{");
                strclass.AppendLine(3, "List<SqlParameter> param = new List<SqlParameter>();");
                foreach (SPParamColumnInfo c in dalInfo.EntityInfo.SPParamInfos)
                {
                    strclass.AppendLine(3, string.Format("param.Add(new SqlParameter(\"@{0}\", {1}));", c.ParameterName, c.ParameterName));
                }
                strclass.AppendLine(3, "return this.GetList(CommandText, param);");
                strclass.AppendLine(2, "}");
            }
        }
    }
}
