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
    public class BuilderEntity
    {
        public static void CreateTableFile(ProjectInfo projectInfo, string tableName)
        {
            EntityInfo e = new EntityInfo();
            e.ConnectionString = projectInfo.ConnectionString;
            e.EntityName = tableName;
            e.EntityPath = string.Format("{0}tb{1}.cs", projectInfo.EntityPath, tableName);

            string text = CreatEntity(e, projectInfo.ConnectionDataSource, DBModule.Table);
            hwj.MarkTableObject.Common.CreateFile(e.EntityPath);
            using (StreamWriter sw = new StreamWriter(e.EntityPath, false, System.Text.Encoding.UTF8))
            {
                sw.Write(text);
            }

        }
        public static string CreatEntity(EntityInfo entity, ConnectionDataSourceType connType, DBModule module)
        {
            string strModule = string.Empty;
            switch (module)
            {
                case DBModule.Table:
                    entity.ColumnInfoList = GetColumnInfoForTable(connType, entity.ConnectionString, entity.EntityName);
                    strModule = "Table:";
                    break;
                case DBModule.View:
                    strModule = "View:";
                    break;
                case DBModule.SP:
                    strModule = "SP:";
                    break;
                default:
                    break;
            }

            StringHelper.SpaceString strclass = new StringHelper.SpaceString();
            strclass.AppendLine("using System;");
            strclass.AppendLine("using System.Collections.Generic;");
            strclass.AppendLine("using System.Data;");
            strclass.AppendLine("using hwj.DBUtility;");
            strclass.AppendLine("using hwj.DBUtility.Entity;");
            strclass.AppendLine("using hwj.DBUtility.TableMapping;");
            strclass.AppendLine("");
            strclass.AppendLine("namespace " + entity.NameSpace);
            strclass.AppendLine("{");
            strclass.AppendLine(1, "/// <summary>");
            strclass.AppendLine(1, "/// " + strModule + entity.EntityName);
            strclass.AppendLine(1, "/// </summary>");
            strclass.AppendLine(1, "[Serializable]");
            strclass.AppendLine(1, "public class " + entity.EntityName + " : BaseTable<" + entity.EntityName + ">");
            strclass.AppendLine(1, "{");
            strclass.AppendLine(2, "public " + entity.EntityName + "()");
            strclass.AppendLine(3, ": base(DBTableName)");
            strclass.AppendLine(2, "{ }");
            strclass.AppendLine(CreatTableName(entity.EntityName));
            strclass.AppendLine(CreatFieldsEnum(entity));
            strclass.AppendLine(CreatModelMethod(entity));
            strclass.AppendLine(1, "}");
            strclass.AppendLine(1, "public class " + entity.EntityName + "s : BaseList<" + entity.EntityName + ", " + entity.EntityName + "s> { }");
            strclass.AppendLine(1, "public class " + entity.EntityName + "Page : PageResult<" + entity.EntityName + ", " + entity.EntityName + "s> { }");
            strclass.AppendLine("}");
            strclass.AppendLine("");

            return strclass.ToString();
        }
        private static string CreatTableName(string modelName)
        {
            if (modelName.IndexOf("tb") != -1)
                modelName = modelName.Substring(2);
            StringHelper.SpaceString strclass = new StringHelper.SpaceString();
            strclass.AppendLine(2, "public const string DBTableName = \"" + modelName + "\";");
            return strclass.ToString();
        }
        private static string CreatFieldsEnum(EntityInfo entity)
        {
            //修正视图重复字段的问题
            string tmpColumnName = string.Empty;
            StringHelper.SpaceString strclass = new StringHelper.SpaceString();
            strclass.AppendLine(2, "public enum Fields");
            strclass.AppendLine(2, "{");
            foreach (ColumnInfo c in entity.ColumnInfoList)
            {
                if (tmpColumnName != c.ColumnName)
                {
                    strclass.AppendLine(3, "/// <summary>");
                    strclass.AppendLine(3, "///" + c.BaseSchemaName);
                    strclass.AppendLine(3, "/// </summary>");
                    strclass.AppendLine(3, c.ColumnName + ",");
                }
                tmpColumnName = c.ColumnName;
            }
            strclass.AppendLine(2, "}");
            return strclass.ToString();
        }
        private static string CreatModelMethod(EntityInfo entity)
        {
            //修正视图重复字段的问题
            string tmpColumnName = string.Empty;
            string sFieldFormat = "[FieldMapping(\"{0}\", {1}{2})]";
            string sFieldFormat_isPK = "[FieldMapping(\"{0}\", {1}, Enums.DataHandle.UnInsert, Enums.DataHandle.UnUpdate{2})]";
            string sUnNull = string.Empty;// ", Enums.DataHandle.UnNull";//需要时再打开该属性
            string sDescIsPK = "PK";
            string sDescCanNull = "Allow Null";
            string sDescCanntNull = "Un-Null";
            StringHelper.SpaceString strclass = new StringHelper.SpaceString();
            StringHelper.SpaceString strclass1 = new StringHelper.SpaceString();
            StringHelper.SpaceString strclass2 = new StringHelper.SpaceString();

            strclass.AppendLine(2, "#region Model");
            foreach (ColumnInfo c in entity.ColumnInfoList)
            {
                if (tmpColumnName != c.ColumnName)
                {
                    string columnName = c.ColumnName;
                    string columnType = c.DataType;
                    bool IsIdentity = c.IsAutoIncrement;
                    bool ispk = c.IsKey;
                    bool cisnull = c.AllowDBNull;
                    string deText = c.Description;
                    //columnType = CodeCommon.DbTypeToCS(columnType);
                    string isnull = "";
                    //if (CodeCommon.isValueType(columnType))
                    //{
                    //    if ((!IsIdentity) && (!ispk) && (cisnull))
                    //    {
                    //        //isnull = "?";//代表可空类型
                    //    }
                    //}

                    strclass1.AppendLine(2, "private " + SetFirstUpper(columnType) + isnull + " _" + columnName.ToLower() + ";");//私有变量
                    strclass2.AppendLine(2, "/// <summary>");
                    strclass2.AppendLine(2, "/// " + deText + "[" +
                                                                string.Format("{0}/{1}/{2}({3})/{4}",
                                                               (ispk ? sDescIsPK : ""),
                                                                (cisnull ? sDescCanNull : sDescCanntNull),
                                                                c.DataTypeName,
                                                                c.ColumnSize,
                                                                string.IsNullOrEmpty(c.DefaultValue) ? "" : "Default:" + c.DefaultValue).TrimEnd('/').TrimStart('/')
                                                                + "]");
                    strclass2.AppendLine(2, "/// </summary>");
                    string _sUnNull = sUnNull;
                    if (cisnull)
                        _sUnNull = string.Empty;
                    if (IsIdentity)
                        strclass2.AppendLine(2, string.Format(sFieldFormat_isPK, columnName, GetTypeCode(columnType), _sUnNull));
                    else
                        strclass2.AppendLine(2, string.Format(sFieldFormat, columnName, GetTypeCode(columnType), _sUnNull));
                    strclass2.AppendLine(2, "public " + SetFirstUpper(columnType) + isnull + " " + columnName);//属性
                    strclass2.AppendLine(2, "{");
                    strclass2.AppendLine(3, "set{AddAssigned(\"" + columnName + "\");" + " _" + columnName.ToLower() + "=value;}");
                    strclass2.AppendLine(3, "get{return " + "_" + columnName.ToLower() + ";}");
                    strclass2.AppendLine(2, "}");
                }
                tmpColumnName = c.ColumnName;
            }
            strclass.Append(strclass1.ToString());
            strclass.Append(strclass2.ToString());
            strclass.AppendLine(2, "#endregion Model");

            return strclass.ToString();
        }
        private static string SetFirstUpper(string value)
        {
            if (value == "int")
                value = "Int32";
            return (value.Substring(0, 1).ToUpper() + value.Substring(1)).Replace("System.", "");
        }
        private static string GetTypeCode(string columnType)
        {
            return "DbType." + SetFirstUpper(columnType);
        }

        private static ColumnInfos GetColumnInfoForTable(ConnectionDataSourceType connType, string connectionString, string tablName)
        {
            switch (connType)
            {
                case ConnectionDataSourceType.MSSQL:
                    return BLL.MSSQL.BuilderColumn.GetColumnInfoForTable(connectionString, tablName);
                case ConnectionDataSourceType.MYSQL:
                    break;
                case ConnectionDataSourceType.OleDb:
                    return BLL.OleDb.BuilderColumn.GetColumnInfoForTable(connectionString, tablName);
                default:
                    break;
            }
            return null;
        }
    }
}
