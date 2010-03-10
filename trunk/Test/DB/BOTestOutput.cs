using System;
using System.Data;
using System.Collections.Generic;
using hwj.DBUtility;
using Test.DB.Entity;
using Test.DB.DAL;

namespace Test.DB.BLL
{
    /// <summary>
    /// Business [BOTestOutput]
    /// </summary>
    public class BOTestOutput
    {
        private static DATestOutput da = new DATestOutput("Data Source=192.168.1.200;Initial Catalog=AutoSync;Persist Security Info=True;User ID=sa;Password=113502");
        public BOTestOutput()
        { }
        public static bool Exists(int ID)
        {
            FilterParams fp = new FilterParams();
            fp.AddParam(tbTestOutput.Fields.ID, ID, Enums.Relation.Equal, Enums.Expression.AND);
            return da.RecordCount(fp) > 0;
        }

        public static bool Add(tbTestOutput entity)
        {
            return da.Add(entity);
        }

        public static bool Update(tbTestOutput updateEntity, int ID)
        {
            FilterParams fp = new FilterParams();
            fp.AddParam(tbTestOutput.Fields.ID, ID, Enums.Relation.Equal, Enums.Expression.AND);
            return da.Update(updateEntity, fp);
        }

        public static bool Delete(int ID)
        {
            FilterParams fp = new FilterParams();
            fp.AddParam(tbTestOutput.Fields.ID, ID, Enums.Relation.Equal, Enums.Expression.AND);
            return da.Delete(fp);
        }

        public static tbTestOutput GetEntity(int ID)
        {
            FilterParams fp = new FilterParams();
            fp.AddParam(tbTestOutput.Fields.ID, ID, Enums.Relation.Equal, Enums.Expression.AND);
            return da.GetEntity(fp);
        }

        public static tbTestOutputs GetList()
        {
            FilterParams fp = new FilterParams();
            fp.AddParam(tbTestOutput.Fields.Status, "N", Enums.Relation.Equal, Enums.Expression.AND);

            return da.GetList(null, fp);
        }

        public static tbTestOutputs GetAllList()
        {
            return da.GetList();
        }

        public static tbTestOutputPage GetPage(int pageIndex, int pageSize)
        {
            int RecordCount;
            tbTestOutputPage page = new tbTestOutputPage();
            DisplayFields pk = new DisplayFields();
            pk.Add(tbTestOutput.Fields.ID);
            page.PageSize = pageSize;
            page.Result = da.GetPage(null, null, null, pk, pageIndex, page.PageSize, out RecordCount);
            page.RecordCount = RecordCount;
            return page;
        }

    }
}

