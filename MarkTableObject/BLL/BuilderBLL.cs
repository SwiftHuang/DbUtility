using System;
using System.Collections.Generic;
using System.Text;
using hwj.CommonLibrary.Object;
using hwj.MarkTableObject.Entity;

namespace hwj.MarkTableObject.BLL
{
    public class BuilderBLL
    {
        public static void CreateTableFile(ProjectInfo projectInfo, string tableName,
            bool Exists, bool Add, bool Update, bool Delete, bool GetEntity, bool Page, bool List, bool AllList)
        {
            BLLInfo bllInfo = new BLLInfo(projectInfo, DBModule.Table, tableName);
            string text = CreateBLLCode(bllInfo, DBModule.Table, Exists, Add, Update, Delete, GetEntity, Page, List, AllList);
            hwj.MarkTableObject.Common.CreateFile(bllInfo.FileName, text);
        }
        public static string CreateBLLCode(BLLInfo bllInfo, DBModule moudul,
            bool Exists, bool Add, bool Update, bool Delete, bool GetEntity, bool Page, bool List, bool AllList)
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

            #region  方法代码
            if (Exists)
            {
                strclass.AppendLine(CreatExistsMethod(bllInfo));
            }
            if (Add)
            {
                strclass.AppendLine(CreatADDMethod(bllInfo));
            }
            if (Update)
            {
                strclass.AppendLine(CreatUpdateMethod(bllInfo));
            }
            if (Delete)
            {
                strclass.AppendLine(CreatDeleteMethod(bllInfo));
            }
            if (GetEntity)
            {
                strclass.AppendLine(CreatGetEntityMethod(bllInfo));
            }
            if (List)
            {
                strclass.AppendLine(CreatGetListMethod(bllInfo));

            }
            if (AllList)
                strclass.AppendLine(CreatGetAllListMethod(bllInfo));
            if (Page)
                strclass.AppendLine(CreatGetPageMethod(bllInfo));

            #endregion
            strclass.AppendLine(1, "}");
            strclass.AppendLine("}");
            strclass.AppendLine("");

            return strclass.ToString();
        }

        private static void GetFilterParam(BLLInfo inf, ref StringHelper.SpaceString strclass)
        {
            strclass.AppendLine(3, "FilterParams fp = new FilterParams();");
            foreach (ColumnInfo c in inf.EntityInfo.PKColumnInfoList)
            {
                strclass.AppendLine(3, "fp.AddParam(" + inf.EntityInfo.EntityName + ".Fields." + c.ColumnName + ", " + c.ColumnName + ", Enums.Relation.Equal, Enums.Expression.AND);");
            }
        }
        private static void GetPKParam(BLLInfo inf, ref StringHelper.SpaceString strclass)
        {
            strclass.AppendLine(3, "DisplayFields pk = new DisplayFields();");
            foreach (ColumnInfo c in inf.EntityInfo.PKColumnInfoList)
            {
                strclass.AppendLine(3, "pk.Add(" + inf.EntityInfo.EntityName + ".Fields." + c.ColumnName + ");");
            }
        }
        private static string CreatExistsMethod(BLLInfo inf)
        {
            StringHelper.SpaceString strclass = new StringHelper.SpaceString();
            if (inf.EntityInfo.PKColumnInfoList.Count > 0)
            {
                strclass.AppendLine(2, "public static bool Exists(" + inf.EntityInfo.PKColumnParam + ")");
                strclass.AppendLine(2, "{");
                if (!string.IsNullOrEmpty(inf.EntityInfo.PKColumnParam))
                {
                    GetFilterParam(inf, ref strclass);
                    strclass.AppendLine(3, "return da.RecordCount(fp) > 0;");
                }
                else
                    strclass.AppendLine(3, "return da.RecordCount() > 0;");
                strclass.AppendLine(2, "}");
            }
            return strclass.ToString();
        }
        private static string CreatADDMethod(BLLInfo inf)
        {
            StringHelper.SpaceString strclass = new StringHelper.SpaceString();
            strclass.AppendLine(2, "public static bool Add(" + inf.EntityInfo.EntityName + " entity)");
            strclass.AppendLine(2, "{");
            strclass.AppendLine(3, "return da.Add(entity);");
            strclass.AppendLine(2, "}");
            return strclass.ToString();
        }
        private static string CreatUpdateMethod(BLLInfo inf)
        {
            StringHelper.SpaceString strclass = new StringHelper.SpaceString();
            if (inf.EntityInfo.PKColumnInfoList.Count > 0)
            {
                strclass.AppendLine(2, "public static bool Update(" + inf.EntityInfo.EntityName + " updateEntity, " + inf.EntityInfo.PKColumnParam + ")");
                strclass.AppendLine(2, "{");
                GetFilterParam(inf, ref strclass);
                strclass.AppendLine(3, "return da.Update(updateEntity, fp);");
            }
            else
            {
                strclass.AppendLine(2, "public static bool Update(" + inf.EntityInfo.EntityName + " updateEntity)");
                strclass.AppendLine(2, "{");
                strclass.AppendLine(3, "return da.Update(updateEntity, null);");
            }

            strclass.AppendLine(2, "}");
            return strclass.ToString();
        }
        private static string CreatDeleteMethod(BLLInfo inf)
        {
            StringHelper.SpaceString strclass = new StringHelper.SpaceString();
            strclass.AppendLine(2, "public static bool Delete(" + inf.EntityInfo.PKColumnParam + ")");
            strclass.AppendLine(2, "{");
            if (inf.EntityInfo.PKColumnInfoList.Count > 0)
            {
                GetFilterParam(inf, ref strclass);
                strclass.AppendLine(3, "return da.Delete(fp);");
            }
            else
                strclass.AppendLine(3, "return da.Delete();");
            strclass.AppendLine(2, "}");
            return strclass.ToString();
        }
        private static string CreatGetEntityMethod(BLLInfo inf)
        {
            StringHelper.SpaceString strclass = new StringHelper.SpaceString();
            strclass.AppendLine(2, "public static " + inf.EntityInfo.EntityName + " GetEntity(" + inf.EntityInfo.PKColumnParam + ")");
            strclass.AppendLine(2, "{");
            if (inf.EntityInfo.PKColumnInfoList.Count > 0)
            {
                GetFilterParam(inf, ref strclass);
                strclass.AppendLine(3, "return da.GetEntity(fp);");
            }
            else
                strclass.AppendLine(3, "return da.GetEntity();");
            strclass.AppendLine(2, "}");
            return strclass.ToString();

        }
        private static string CreatGetListMethod(BLLInfo inf)
        {
            StringHelper.SpaceString strclass = new StringHelper.SpaceString();
            strclass.AppendLine(2, "public static " + inf.EntityInfo.EntityName + "s GetList(" + inf.EntityInfo.PKColumnParam + ")");
            strclass.AppendLine(2, "{");
            if (inf.EntityInfo.PKColumnInfoList.Count > 0)
            {
                GetFilterParam(inf, ref strclass);
                strclass.AppendLine(3, "return da.GetList(null, fp);");
            }
            else
                strclass.AppendLine(3, "return da.GetList();");
            strclass.AppendLine(2, "}");

            strclass.AppendLine("");

            if (inf.EntityInfo.PKColumnInfoList.Count > 0)
            {
                strclass.AppendLine(2, "public static " + inf.EntityInfo.EntityName + "s GetList(" + inf.EntityInfo.PKColumnParam + ", int top)");
                strclass.AppendLine(2, "{");
                GetFilterParam(inf, ref strclass);
                strclass.AppendLine(3, "return da.GetList(null, fp, null, top);");
            }
            else
            {
                strclass.AppendLine(2, "public static " + inf.EntityInfo.EntityName + "s GetList(int top)");
                strclass.AppendLine(2, "{");
                strclass.AppendLine(3, "return da.GetList(null, null, null, top);");
            }
            strclass.AppendLine(2, "}");


            return strclass.ToString();

        }
        private static string CreatGetAllListMethod(BLLInfo inf)
        {
            StringHelper.SpaceString strclass = new StringHelper.SpaceString();
            strclass.AppendLine(2, "public static " + inf.EntityInfo.EntityName + "s GetAllList()");
            strclass.AppendLine(2, "{");
            strclass.AppendLine(3, "return da.GetList();");
            strclass.AppendLine(2, "}");

            return strclass.ToString();
        }
        private static string CreatGetPageMethod(BLLInfo inf)
        {
            StringHelper.SpaceString strclass = new StringHelper.SpaceString();
            strclass.AppendLine(2, "public static " + inf.EntityInfo.EntityName + "Page GetPage(int pageIndex, int pageSize)");
            strclass.AppendLine(2, "{");
            strclass.AppendLine(3, "int RecordCount;");
            strclass.AppendLine(3, inf.EntityInfo.EntityName + "Page page = new " + inf.EntityInfo.EntityName + "Page();");
            GetPKParam(inf, ref strclass);
            strclass.AppendLine(3, "page.PageSize = pageSize;");
            strclass.AppendLine(3, "page.Result = da.GetPage(null, null, null, pk, pageIndex, page.PageSize, out RecordCount);");
            strclass.AppendLine(3, "page.RecordCount = RecordCount;");
            strclass.AppendLine(3, "return page;");

            strclass.AppendLine(2, "}");

            return strclass.ToString();
        }
    }
}
