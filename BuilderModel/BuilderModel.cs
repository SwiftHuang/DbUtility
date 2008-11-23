using System;
using System.Collections.Generic;
using System.Text;
using LTP.Utility;
using LTP.CodeHelper;
namespace LTP.BuilderModel
{
    /// <summary>
    /// Model代码生成组件
    /// </summary>
    public class BuilderModel : LTP.IBuilder.IBuilderModel
    {
        #region 公有属性
        protected string _modelname = ""; //model类名
        protected string _namespace = "Maticsoft"; //顶级命名空间名
        protected string _modelpath = "";//实体类的命名空间
        protected List<ColumnInfo> _fieldlist;

        /// <summary>
        /// 顶级命名空间名 
        /// </summary>        
        public string NameSpace
        {
            set { _namespace = value; }
            get { return _namespace; }
        }
        /// <summary>
        /// 实体类的命名空间
        /// </summary>
        public string Modelpath
        {
            set { _modelpath = value; }
            get { return _modelpath; }
        }
        /// <summary>
        /// model类名
        /// </summary>
        public string ModelName
        {
            set { _modelname = value; }
            get { return _modelname; }
        }
        /// <summary>
        /// 选择的字段集合
        /// </summary>
        public List<ColumnInfo> Fieldlist
        {
            set { _fieldlist = value; }
            get { return _fieldlist; }
        }

        #endregion

        public BuilderModel()
        {
        }

        #region 生成完整Model类
        /// <summary>
        /// 生成完整sModel类
        /// </summary>		
        public string CreatModel()
        {
            StringPlus strclass = new StringPlus();
            strclass.AppendLine("using System;");
            strclass.AppendLine("using System.Collections.Generic;");
            strclass.AppendLine("using System.Data;");
            strclass.AppendLine("using hwj.DBUtility;");
            strclass.AppendLine("using hwj.DBUtility.TableMapping;");
            strclass.AppendLine("namespace Entity.Table");
            strclass.AppendLine("{");
            strclass.AppendSpaceLine(1, "/// <summary>");
            strclass.AppendSpaceLine(1, "/// 实体类" + _modelname + " 。(属性说明自动提取数据库字段的描述信息)");
            strclass.AppendSpaceLine(1, "/// </summary>");
            strclass.AppendSpaceLine(1, "[Serializable]");
            strclass.AppendSpaceLine(1, "public class " + _modelname + " : iTable");
            strclass.AppendSpaceLine(1, "{");
            strclass.AppendSpaceLine(2, "public " + _modelname + "()");
            strclass.AppendSpaceLine(2, "{}");
            strclass.AppendLine(CreatFieldsEnum());
            strclass.AppendLine(CreatTableName(_modelname));
            strclass.AppendLine(CreatModelMethod());
            strclass.AppendSpaceLine(1, "}");
            strclass.AppendSpaceLine(1, "public class " + _modelname + "s : List<" + _modelname + "> { }");
            strclass.AppendSpaceLine(1, "public class " + _modelname + "Page : PageResult<" + _modelname + "> { }");
            strclass.AppendLine("}");
            strclass.AppendLine("");

            return strclass.ToString();
        }
        #endregion

        #region 生成Model属性部分
        /// <summary>
        /// 生成实体类的属性
        /// </summary>
        /// <returns></returns>
        public string CreatModelMethod()
        {
            string sFieldFormat = "[FieldMapping(\"{0}\", {1})]";

            StringPlus strclass = new StringPlus();
            StringPlus strclass1 = new StringPlus();
            StringPlus strclass2 = new StringPlus();

            strclass.AppendSpaceLine(2, "#region Model");
            foreach (ColumnInfo field in Fieldlist)
            {
                string columnName = field.ColumnName;
                string columnType = field.TypeName;
                bool IsIdentity = field.IsIdentity;
                bool ispk = field.IsPK;
                bool cisnull = field.cisNull;
                string deText = field.DeText;
                columnType = CodeCommon.DbTypeToCS(columnType);
                string isnull = "";
                if (CodeCommon.isValueType(columnType))
                {
                    if ((!IsIdentity) && (!ispk) && (cisnull))
                    {
                        //isnull = "?";//代表可空类型
                    }
                }

                strclass1.AppendSpaceLine(2, "private " + SetFirstUpper(columnType) + isnull + " _" + columnName.ToLower() + ";");//私有变量
                strclass2.AppendSpaceLine(2, "/// <summary>");
                strclass2.AppendSpaceLine(2, "/// " + deText);
                strclass2.AppendSpaceLine(2, "/// </summary>");
                strclass2.AppendSpaceLine(2, string.Format(sFieldFormat, columnName, GetTypeCode(columnType)));
                strclass2.AppendSpaceLine(2, "public " + SetFirstUpper(columnType) + isnull + " " + columnName);//属性
                strclass2.AppendSpaceLine(2, "{");
                strclass2.AppendSpaceLine(3, "set{" + " _" + columnName.ToLower() + "=value;}");
                strclass2.AppendSpaceLine(3, "get{return " + "_" + columnName.ToLower() + ";}");
                strclass2.AppendSpaceLine(2, "}");
                //strclass2.AppendSpaceLine(2, "public static string " + columnName);
                //strclass2.AppendSpaceLine(2, "{");
                //strclass2.AppendSpaceLine(3, "get{return \"" + columnName.ToString().Trim() + "\";}");
                //strclass2.AppendSpaceLine(2, "}");
            }
            strclass.Append(strclass1.Value);
            strclass.Append(strclass2.Value);
            strclass.AppendSpaceLine(2, "#endregion Model");

            return strclass.ToString();
        }
        public string CreatFieldsEnum()
        {
            StringPlus strclass = new StringPlus();
            strclass.AppendSpaceLine(2, "public enum Fields");
            strclass.AppendSpaceLine(2, "{");
            foreach (ColumnInfo f in Fieldlist)
            {
                strclass.AppendSpaceLine(3, f.ColumnName + ",");
            }
            strclass.AppendSpaceLine(2, "}");
            return strclass.ToString();
        }
        public string CreatTableName(string tableName)
        {
            StringPlus strclass = new StringPlus();
            strclass.AppendSpaceLine(2, "public static string TableName");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "get { return \"" + tableName + "\"; }");
            strclass.AppendSpaceLine(2, "}");
            return strclass.ToString();
        }
        private string GetTypeCode(string columnType)
        {
            string s = string.Empty;

            s = "DbType." + SetFirstUpper(columnType) + "";
            return s;
        }
        private string SetFirstUpper(string value)
        {
            return value.Substring(0, 1).ToUpper() + value.Substring(1);
        }
        #endregion
    }
}
