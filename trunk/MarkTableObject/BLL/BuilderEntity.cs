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
            EntityInfo e = new EntityInfo(projectInfo, DBModule.Table, tableName);
            e.InitColumnInfoList();
            string text = CreatEntity(e);
            hwj.MarkTableObject.Common.CreateFile(e.FileName, text);
        }
        public static string CreatEntity(EntityInfo entity)
        {
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
            strclass.AppendLine(1, "/// " + entity.Module.ToString() + ":" + entity.TableName);
            strclass.AppendLine(1, "/// </summary>");
            strclass.AppendLine(1, "[Serializable]");
            if (entity.Module == DBModule.SQL || entity.Module == DBModule.SP)
            {
                strclass.AppendLine(1, "public class " + entity.EntityName + " : BaseSqlTable<" + entity.EntityName + ">");
                strclass.AppendLine(1, "{");
                strclass.AppendLine(2, "public " + entity.EntityName + "()");
                strclass.AppendLine(3, ": base(CommandText)");
                strclass.AppendLine(2, "{ }");
                strclass.AppendLine(2, @"public const string CommandText = @""" + entity.CommandText.Replace("\r\n", "\r\n".PadRight(48, ' ')) + "\";");
            }
            else
            {
                strclass.AppendLine(1, "public class " + entity.EntityName + " : BaseTable<" + entity.EntityName + ">");
                strclass.AppendLine(1, "{");
                strclass.AppendLine(2, "public " + entity.EntityName + "()");
                strclass.AppendLine(3, ": base(DBTableName)");
                strclass.AppendLine(2, "{ }");
                strclass.AppendLine(CreatTableName(entity.TableName));
            }
            strclass.AppendLine("");
            strclass.AppendLine(CreatFieldsEnum(entity));
            strclass.AppendLine(CreatModelMethod(entity));
            strclass.AppendLine(1, "}");
            strclass.AppendLine(1, "[Serializable]");
            strclass.AppendLine(1, "public class " + entity.EntityName + "s : BaseList<" + entity.EntityName + ", " + entity.EntityName + "s> { }");
            if (entity.Module != DBModule.SP)
                strclass.AppendLine(1, "public class " + entity.EntityName + "Page : PageResult<" + entity.EntityName + ", " + entity.EntityName + "s> { }");
            strclass.AppendLine("}");
            strclass.AppendLine("");

            return strclass.ToString();
        }
        private static string CreatTableName(string modelName)
        {
            //if (modelName.IndexOf("tb") != -1)
            //    modelName = modelName.Substring(2);
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
                    strclass.AppendLine(3, c.ColumnName.Trim().Replace(' ', '_') + ",");
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
            string sFieldFormat = "[FieldMapping(\"{0}\", {1}, {2}{3})]";
            string sFieldFormat_isPK = "[FieldMapping(\"{0}\", {1}, {2}, Enums.DataHandle.UnInsert, Enums.DataHandle.UnUpdate{3})]";
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
                    string columnName = c.ColumnName.Trim().Replace(' ', '_');
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
                                                                GetSizeForComment(c),
                                                                string.IsNullOrEmpty(c.DefaultValue) ? "" : "Default:" + c.DefaultValue).TrimEnd('/').TrimStart('/')
                                                                + "]");
                    strclass2.AppendLine(2, "/// </summary>");
                    string _sUnNull = sUnNull;
                    if (cisnull)
                        _sUnNull = string.Empty;
                    if (IsIdentity)
                        strclass2.AppendLine(2, string.Format(sFieldFormat_isPK, c.ColumnName, GetTypeCode(c), GetSize(c), _sUnNull));
                    else
                        strclass2.AppendLine(2, string.Format(sFieldFormat, c.ColumnName, GetTypeCode(c), GetSize(c), _sUnNull));
                    strclass2.AppendLine(2, "public " + SetFirstUpper(columnType) + isnull + " " + columnName);//属性
                    strclass2.AppendLine(2, "{");
                    if (entity.Module == DBModule.Table)
                        strclass2.AppendLine(3, "set { AddAssigned(\"" + columnName + "\");" + " _" + columnName.ToLower() + " = value; }");
                    else
                        strclass2.AppendLine(3, "set { _" + columnName.ToLower() + " = value; }");
                    strclass2.AppendLine(3, "get { return " + "_" + columnName.ToLower() + "; }");
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
        private static string GetTypeCode(ColumnInfo column)
        {
            if (column.DataType == "System.String")
            {
                if (column.DataTypeName.ToLower() == "char")
                    return "DbType.AnsiStringFixedLength";
                else if (column.DataTypeName.ToLower() == "varchar")
                    return "DbType.AnsiString";
                else if (column.DataTypeName.ToLower() == "nchar")
                    return "DbType.StringFixedLength";
                else if (column.DataTypeName.ToLower() == "nvarchar")
                    return "DbType.String";
            }
            return "DbType." + SetFirstUpper(column.DataType);
        }
        private static string GetSizeForComment(ColumnInfo column)
        {
            DbType dbType = (DbType)System.Enum.Parse(typeof(DbType), column.DataType.Replace("System.", ""), true);
            if (hwj.DBUtility.Common.IsNumType(dbType))
            {
                if (column.NumericScale == 255)
                {
                    return column.NumericPrecision.ToString();
                }
                else
                {
                    return string.Format("{0},{1}", column.NumericPrecision, column.NumericScale);
                }
            }
            else
            {
                return column.ColumnSize.ToString();
            }
        }
        private static int GetSize(ColumnInfo column)
        {
            DbType dbType = (DbType)System.Enum.Parse(typeof(DbType), column.DataType.Replace("System.", ""), true);
            if (hwj.DBUtility.Common.IsNumType(dbType))
            {
                if (column.NumericScale == 255)
                {
                    return column.NumericPrecision;
                }
                else
                {
                    return column.NumericPrecision - column.NumericScale;
                }
            }
            else
            {
                return column.ColumnSize;
            }
        }

        private static ColumnInfos GetColumnInfoForTable(EntityInfo entity)
        {
            switch (entity.ConnType)
            {
                case DatabaseEnum.MSSQL:
                    return BLL.MSSQL.BuilderColumn.GetColumnInfoForTable(entity);
                case DatabaseEnum.MYSQL:
                    break;
                case DatabaseEnum.OleDb:
                    return BLL.OleDb.BuilderColumn.GetColumnInfoForTable(entity);
                default:
                    break;
            }
            return null;
        }
    }
}
