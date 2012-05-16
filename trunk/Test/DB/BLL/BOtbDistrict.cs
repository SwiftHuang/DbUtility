using System;
using System.Data;
using System.Collections.Generic;
using hwj.DBUtility;
using Test.Entity.Table;
using Test.DAL.Table;

namespace Test.BLL.Table
{
    /// <summary>
    /// Business [BOtbDistrict]
    /// </summary>
    public class BOtbDistrict
    {
        private static DAtbDistrict da = new DAtbDistrict("Data Source=127.0.0.1;Initial Catalog=HPMIS;Integrated Security=True");
        public BOtbDistrict()
        { }
        public bool Exists(string Code)
        {
            FilterParams fp = new FilterParams();
            fp.AddParam(tbDistrict.Fields.Code, Code, Enums.Relation.Equal, Enums.Expression.AND);
            return da.RecordCount(fp) > 0;
        }

        public static bool Add(tbDistrict entity)
        {
            return da.Add(entity);
        }

        public static bool Update(tbDistrict updateEntity, string Code)
        {
            FilterParams fp = new FilterParams();
            fp.AddParam(tbDistrict.Fields.Code, Code, Enums.Relation.Equal, Enums.Expression.AND);
            return da.Update(updateEntity, fp);
        }

        public static bool Delete(string Code)
        {
            FilterParams fp = new FilterParams();
            fp.AddParam(tbDistrict.Fields.Code, Code, Enums.Relation.Equal, Enums.Expression.AND);
            return da.Delete(fp);
        }

        public static tbDistrict GetEntity(string Code)
        {
            FilterParams fp = new FilterParams();
            fp.AddParam(tbDistrict.Fields.Code, Code, Enums.Relation.Equal, Enums.Expression.AND);
            return da.GetEntity(fp);
        }

        public static tbDistricts GetList(string Code)
        {
            FilterParams fp = new FilterParams();
            fp.AddParam(tbDistrict.Fields.Code, "%" + Code + "%", Enums.Relation.Like, Enums.Expression.AND);
            return da.GetList(null, fp);
        }

        public static tbDistricts GetList(string Code, int top)
        {
            FilterParams fp = new FilterParams();
            fp.AddParam(tbDistrict.Fields.Code, Code, Enums.Relation.Equal, Enums.Expression.AND);
            return da.GetList(null, fp, null, top);
        }

        public static tbDistricts GetAllList()
        {
            return da.GetList();
        }

        public static tbDistrictPage GetPage(int pageIndex, int pageSize)
        {
            int RecordCount;
            tbDistrictPage page = new tbDistrictPage();
            DisplayFields pk = new DisplayFields();
            pk.Add(tbDistrict.Fields.Code);
            page.PageSize = pageSize;
            page.Result = da.GetPage(null, null, null, pk, pageIndex, pageSize, out RecordCount);
            page.RecordCount = RecordCount;
            return page;
        }

        public static tbDistrictPage TestSql()
        {


            DisplayFields df = new DisplayFields();
            df.Add(tbDistrict.Fields.Code);
            FilterParams fp1 = new FilterParams();
            fp1.AddParam(tbDistrict.Fields.Code, new string[] { "9000", "9001" }, Enums.Relation.IN, Enums.Expression.AND);
            da.GetList(df, fp1);
            da.Delete(fp1);

            UpdateParam up = new UpdateParam();
            up.AddParam(tbDistrict.Fields.UpdateOn, DateTime.Now.AddDays(-1));
            da.Update(up, new FilterParams(tbDistrict.Fields.CreateOn, SqlParam.DatabaseDate, Enums.Relation.Less));

            tbDistrict d = new tbDistrict();
            d.Code = "000";
            da.Update(d, fp1);

            int RecordCount;
            tbDistrictPage page = new tbDistrictPage();
            DisplayFields pk = new DisplayFields();
            pk.Add(tbDistrict.Fields.Code);
            FilterParams fp = new FilterParams();
            //fp.AddParam(tbDistrict.Fields.CreateBy, "Y", Enums.Relation.Equal, Enums.Expression.AND);
            //fp.AddParam(tbDistrict.Fields.CreateOn, DateTime.Now, Enums.Relation.Less, Enums.Expression.AND);

            SortParams sp = new SortParams();
            //sp.AddParam(tbDistrict.Fields.Code, Enums.OrderBy.Descending);
            sp.AddParam(tbDistrict.Fields.CreateOn, Enums.OrderBy.Descending);
            page.PageSize = 10;
            page.Result = da.GetPage(null, fp, sp, pk, 1, page.PageSize, out RecordCount);
            page.RecordCount = RecordCount;
            return page;
        }
    }
}

