using System;
using System.Data;
using System.Collections.Generic;
using hwj.DBUtility;
using Test.DB.DAL;
using Test.DB.Entity;

namespace Test.DB.BLL
{
    /// <summary>
    /// Business [BOAptx]
    /// </summary>
    public class BOAptx
    {
        private static DAAptx da = new DAAptx("Data Source=192.168.1.200;Initial Catalog=eAccount;Persist Security Info=True;User ID=sa;Password=113502");
        public BOAptx()
        { }
        public static bool Exists(string CompanyCode, string APTxNum)
        {
            FilterParams fp = new FilterParams();
            fp.AddParam(tbAptx.Fields.CompanyCode, CompanyCode, Enums.Relation.Equal, Enums.Expression.AND);
            fp.AddParam(tbAptx.Fields.APTxNum, APTxNum, Enums.Relation.Equal, Enums.Expression.AND);
            return da.RecordCount(fp) > 0;
        }

        public static bool Add(tbAptx entity)
        {
            return da.Add(entity);
        }

        public static bool Update(tbAptx updateEntity, string CompanyCode, string APTxNum)
        {
            FilterParams fp = new FilterParams();
            fp.AddParam(tbAptx.Fields.CompanyCode, CompanyCode, Enums.Relation.Equal, Enums.Expression.AND);
            fp.AddParam(tbAptx.Fields.APTxNum, APTxNum, Enums.Relation.Equal, Enums.Expression.AND);
            return da.Update(updateEntity, fp);
        }

        public static bool Delete(string CompanyCode, string APTxNum)
        {
            FilterParams fp = new FilterParams();
            fp.AddParam(tbAptx.Fields.CompanyCode, CompanyCode, Enums.Relation.Equal, Enums.Expression.AND);
            fp.AddParam(tbAptx.Fields.APTxNum, APTxNum, Enums.Relation.Equal, Enums.Expression.AND);
            return da.Delete(fp);
        }

        public static tbAptx GetEntity(string CompanyCode, string APTxNum)
        {
            FilterParams fp = new FilterParams();
            fp.AddParam(tbAptx.Fields.CompanyCode, CompanyCode, Enums.Relation.Equal, Enums.Expression.AND);
            fp.AddParam(tbAptx.Fields.APTxNum, APTxNum, Enums.Relation.Equal, Enums.Expression.AND);
            return da.GetEntity(fp);
        }

        public static tbAptxs GetList(string CompanyCode, string APTxNum)
        {
            FilterParams fp = new FilterParams();
            fp.AddParam(tbAptx.Fields.CompanyCode, CompanyCode, Enums.Relation.Equal, Enums.Expression.AND);
            fp.AddParam(tbAptx.Fields.APTxNum, APTxNum, Enums.Relation.Equal, Enums.Expression.AND);
            fp.AddParam(tbAptx.Fields.UpdateBy, "", Enums.Relation.Equal, Enums.Expression.AND);
            //fp.AddParam(tbAptx.Fields.APTxDesc, "", Enums.Relation.Equal, Enums.Expression.AND);
            return da.GetList(null, fp);
        }

        public static tbAptxs GetList(string CompanyCode, int top)
        {
            FilterParams fp = new FilterParams();
            fp.AddParam(tbAptx.Fields.CompanyCode, CompanyCode, Enums.Relation.Equal, Enums.Expression.AND);
            return da.GetList(null, fp, null, top);
        }

        public static tbAptxPage GetPage(int pageIndex, int pageSize)
        {
            int RecordCount;
            tbAptxPage page = new tbAptxPage();
            DisplayFields pk = new DisplayFields();
            pk.Add(tbAptx.Fields.CompanyCode);
            pk.Add(tbAptx.Fields.APTxNum);
            page.PageSize = pageSize;
            page.Result = da.GetPage(null, null, null, pk, pageIndex, page.PageSize, out RecordCount);
            page.RecordCount = RecordCount;
            return page;
        }

    }
}

