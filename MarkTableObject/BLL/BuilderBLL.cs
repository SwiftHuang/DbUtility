using System;
using System.Collections.Generic;
using System.Text;
using hwj.CommonLibrary.Object;
using hwj.MarkTableObject.Entity;

namespace hwj.MarkTableObject.BLL
{
    public class BuilderBLL
    {
        public static void CreateTableFile(GeneralInfo genInfo, string tableName, GeneralMethodInfo methodInfo)
        {
            BLLInfo bllInfo = new BLLInfo(genInfo, DBModule.Table, tableName);
            string text = CreateBLLCode(bllInfo, DBModule.Table, methodInfo);
            hwj.MarkTableObject.Common.CreateFile(bllInfo.FileName, text);
        }
        public static string CreateBLLCode(BLLInfo bllInfo, DBModule moudul, GeneralMethodInfo methodInfo)
        {
            StringHelper.SpaceString strclass = new StringHelper.SpaceString();
            strclass.AppendLine("using System;");
            strclass.AppendLine("using System.Data;");
            strclass.AppendLine("using System.Collections.Generic;");
            strclass.AppendLine("using hwj.DBUtility;");

            strclass.AppendLine("using " + bllInfo.DALInfo.Namespace + ";");
            strclass.AppendLine("using " + bllInfo.EntityInfo.NameSpace + ";");

            strclass.AppendLine("");
            strclass.AppendLine("namespace " + bllInfo.Namespace);
            strclass.AppendLine("{");
            strclass.AppendLine(1, "/// <summary>");
            strclass.AppendLine(1, "/// Business [" + bllInfo.BLLName + "]");
            strclass.AppendLine(1, "/// </summary>");
            strclass.AppendLine(1, "public class " + bllInfo.BLLName);
            strclass.AppendLine(1, "{");

            strclass.AppendLine(2, "private static " + bllInfo.DALInfo.DALName + " da = new " + bllInfo.DALInfo.DALName + "(" + bllInfo.Connection + ");");
            strclass.AppendLine(2, "public " + bllInfo.BLLName + "()");
            strclass.AppendLine(2, "{ }");

            GeneralMethod(methodInfo, TemplateType.Business, bllInfo.EntityInfo, ref strclass);

            strclass.AppendLine(1, "}");
            strclass.AppendLine("}");
            strclass.AppendLine("");

            return strclass.ToString();
        }

        #region Private Class
        public static void GeneralMethod(GeneralMethodInfo methodInfo, TemplateType templateType, EntityInfo info, ref StringHelper.SpaceString strclass)
        {
            strclass.AppendLine("");
            if (methodInfo.Exists)
            {
                strclass.AppendLine(CreatExistsMethod(info, templateType));
            }
            if (methodInfo.Add)
            {
                strclass.AppendLine(CreatAddMethod(info, templateType));
            }
            if (methodInfo.Update)
            {
                strclass.AppendLine(CreatUpdateMethod(info, templateType));
            }
            if (methodInfo.Delete)
            {
                strclass.AppendLine(CreatDeleteMethod(info, templateType));
            }
            if (methodInfo.GetEntity)
            {
                strclass.AppendLine(CreatGetEntityMethod(info, templateType));
            }
            if (methodInfo.List)
            {
                strclass.AppendLine(CreatGetListMethod(info, templateType));
            }
            if (methodInfo.AllList)
            {
                strclass.AppendLine(CreatGetAllListMethod(info, templateType));
            }
            if (methodInfo.Page)
            {
                strclass.AppendLine(CreatGetPageMethod(info, templateType));
            }
        }

        private static void GetFilterParam(EntityInfo inf, ref StringHelper.SpaceString strclass)
        {
            strclass.AppendLine(3, "FilterParams fp = new FilterParams();");
            foreach (ColumnInfo c in inf.PKColumnInfoList)
            {
                strclass.AppendLine(3, "fp.AddParam(" + inf.EntityName + ".Fields." + c.ColumnName + ", " + c.ColumnParamName + ", Enums.Relation.Equal, Enums.Expression.AND);");
            }
        }
        private static void GetPKParam(EntityInfo inf, ref StringHelper.SpaceString strclass)
        {
            strclass.AppendLine(3, "DisplayFields pk = new DisplayFields();");
            foreach (ColumnInfo c in inf.PKColumnInfoList)
            {
                strclass.AppendLine(3, "pk.Add(" + inf.EntityName + ".Fields." + c.ColumnName + ");");
            }
        }

        private static string CreatExistsMethod(EntityInfo inf, MarkTableObject.TemplateType templateType)
        {
            FormatString fs = new FormatString(templateType);
            StringHelper.SpaceString strclass = new StringHelper.SpaceString();
            if (inf.PKColumnInfoList.Count > 0)
            {
                strclass.AppendLine(2, string.Format("public {0}bool Exists({1})", fs.StaticString, inf.PKColumnParam));
                strclass.AppendLine(2, "{");
                if (!string.IsNullOrEmpty(inf.PKColumnParam))
                {
                    GetFilterParam(inf, ref strclass);
                    strclass.AppendLine(3, string.Format("return {0}RecordCount(fp) > 0;", fs.DALString));
                }
                else
                {
                    strclass.AppendLine(3, string.Format("return {0}RecordCount() > 0;", fs.DALString));
                }
                strclass.AppendLine(2, "}");
            }
            return strclass.ToString();
        }
        private static string CreatAddMethod(EntityInfo inf, MarkTableObject.TemplateType templateType)
        {
            FormatString fs = new FormatString(templateType);
            StringHelper.SpaceString strclass = new StringHelper.SpaceString();
            strclass.AppendLine(2, string.Format("public {0}bool Add({1} entity)", fs.StaticString, inf.EntityName));
            strclass.AppendLine(2, "{");
            strclass.AppendLine(3, string.Format("return {0}Add(entity);", fs.DALString));
            strclass.AppendLine(2, "}");
            return strclass.ToString();
        }
        private static string CreatUpdateMethod(EntityInfo inf, MarkTableObject.TemplateType templateType)
        {
            FormatString fs = new FormatString(templateType);
            StringHelper.SpaceString strclass = new StringHelper.SpaceString();
            if (inf.PKColumnInfoList.Count > 0)
            {
                strclass.AppendLine(2, string.Format("public {0}bool Update({1} updateEntity, {2})", fs.StaticString, inf.EntityName, inf.PKColumnParam));
                strclass.AppendLine(2, "{");
                GetFilterParam(inf, ref strclass);
                strclass.AppendLine(3, string.Format("return {0}Update(updateEntity, fp);", fs.DALString));
            }
            else
            {
                //strclass.AppendLine(2, "public static bool Update(" + inf.EntityInfo.EntityName + " updateEntity)");
                strclass.AppendLine(2, string.Format("public {0}bool Update({1} updateEntity)", fs.StaticString, inf.EntityName));
                strclass.AppendLine(2, "{");
                strclass.AppendLine(3, string.Format("return {0}Update(updateEntity, null);", fs.DALString));
            }

            strclass.AppendLine(2, "}");
            return strclass.ToString();
        }
        private static string CreatDeleteMethod(EntityInfo inf, MarkTableObject.TemplateType templateType)
        {
            FormatString fs = new FormatString(templateType);
            StringHelper.SpaceString strclass = new StringHelper.SpaceString();
            strclass.AppendLine(2, string.Format("public {0}bool Delete({1})", fs.StaticString, inf.PKColumnParam));
            strclass.AppendLine(2, "{");
            if (inf.PKColumnInfoList.Count > 0)
            {
                GetFilterParam(inf, ref strclass);
                strclass.AppendLine(3, string.Format("return {0}Delete(fp);", fs.DALString));
            }
            else
            {
                strclass.AppendLine(3, string.Format("return {0}Delete();", fs.DALString));
            }
            strclass.AppendLine(2, "}");
            return strclass.ToString();
        }
        private static string CreatGetEntityMethod(EntityInfo inf, MarkTableObject.TemplateType templateType)
        {
            FormatString fs = new FormatString(templateType);
            StringHelper.SpaceString strclass = new StringHelper.SpaceString();
            //strclass.AppendLine(2, "public static " + inf.EntityInfo.EntityName + " GetEntity(" + inf.EntityInfo.PKColumnParam + ")");
            strclass.AppendLine(2, string.Format("public {0}{1} GetEntity({2})", fs.StaticString, inf.EntityName, inf.PKColumnParam));
            strclass.AppendLine(2, "{");
            if (inf.PKColumnInfoList.Count > 0)
            {
                GetFilterParam(inf, ref strclass);
                strclass.AppendLine(3, string.Format("return {0}GetEntity(fp);", fs.DALString));
            }
            else
            {
                strclass.AppendLine(3, string.Format("return {0}GetEntity();", fs.DALString));
            }
            strclass.AppendLine(2, "}");
            return strclass.ToString();

        }
        private static string CreatGetListMethod(EntityInfo inf, MarkTableObject.TemplateType templateType)
        {
            FormatString fs = new FormatString(templateType);
            StringHelper.SpaceString strclass = new StringHelper.SpaceString();
            //strclass.AppendLine(2, "public static " + inf.EntityInfo.EntityName + "s GetList(" + inf.EntityInfo.PKColumnParam + ")");
            strclass.AppendLine(2, string.Format("public {0}{1}s GetList({2})", fs.StaticString, inf.EntityName, inf.PKColumnParam));
            strclass.AppendLine(2, "{");
            if (inf.PKColumnInfoList.Count > 0)
            {
                GetFilterParam(inf, ref strclass);
                strclass.AppendLine(3, string.Format("return {0}GetList(null, fp);", fs.DALString));
            }
            else
            {
                strclass.AppendLine(3, string.Format("return {0}GetList();", fs.DALString));
            }
            strclass.AppendLine(2, "}");
            
            //Suspend by Vinson 2012-06-06
            //strclass.AppendLine("");
            //if (inf.PKColumnInfoList.Count > 0)
            //{
            //    strclass.AppendLine(2, string.Format("public {0}{1}s GetList({2}, int top)", fs.StaticString, inf.EntityName, inf.PKColumnParam));
            //    strclass.AppendLine(2, "{");
            //    GetFilterParam(inf, ref strclass);
            //    strclass.AppendLine(3, string.Format("return {0}GetList(null, fp, null, top);", fs.DALString));
            //}
            //else
            //{
            //    strclass.AppendLine(2, string.Format("public {0}{1}s GetList(int top)", fs.StaticString, inf.EntityName));
            //    strclass.AppendLine(2, "{");
            //    strclass.AppendLine(3, string.Format("return {0}GetList(null, null, null, top);", fs.DALString));
            //}
            //strclass.AppendLine(2, "}");

            return strclass.ToString();
        }
        private static string CreatGetAllListMethod(EntityInfo inf, MarkTableObject.TemplateType templateType)
        {
            FormatString fs = new FormatString(templateType);
            StringHelper.SpaceString strclass = new StringHelper.SpaceString();
            //strclass.AppendLine(2, "public static " + inf.EntityInfo.EntityName + "s GetAllList()");
            strclass.AppendLine(2, string.Format("public {0}{1}s GetAllList()", fs.StaticString, inf.EntityName));
            strclass.AppendLine(2, "{");
            strclass.AppendLine(3, string.Format("return {0}GetList();", fs.DALString));
            strclass.AppendLine(2, "}");

            return strclass.ToString();
        }
        private static string CreatGetPageMethod(EntityInfo inf, MarkTableObject.TemplateType templateType)
        {
            FormatString fs = new FormatString(templateType);
            StringHelper.SpaceString strclass = new StringHelper.SpaceString();
            //strclass.AppendLine(2, "public static " + inf.EntityInfo.EntityName + "Page GetPage(int pageIndex, int pageSize)");
            strclass.AppendLine(2, string.Format("public {0}{1}Page GetPage(int pageIndex, int pageSize)", fs.StaticString, inf.EntityName));
            strclass.AppendLine(2, "{");
            strclass.AppendLine(3, "int RecordCount;");
            strclass.AppendLine(3, inf.EntityName + "Page page = new " + inf.EntityName + "Page();");
            GetPKParam(inf, ref strclass);
            strclass.AppendLine(3, "page.PageSize = pageSize;");
            strclass.AppendLine(3, string.Format("page.Result = {0}GetPage(null, null, null, pk, pageIndex, page.PageSize, out RecordCount);", fs.DALString));
            strclass.AppendLine(3, "page.RecordCount = RecordCount;");
            strclass.AppendLine(3, "return page;");

            strclass.AppendLine(2, "}");

            return strclass.ToString();
        }
        #endregion

        private class FormatString
        {
            public string StaticString { get; set; }
            public string DALString { get; set; }
            public FormatString(MarkTableObject.TemplateType templateType)
            {
                GetTemplateString(templateType);
            }
            private void GetTemplateString(MarkTableObject.TemplateType templateType)
            {
                if (templateType == TemplateType.Business)
                {
                    this.StaticString = "static ";
                    this.DALString = "da.";
                }
                else
                {
                    this.StaticString = string.Empty;
                    this.DALString = "base.";
                }

            }
        }

    }
}
