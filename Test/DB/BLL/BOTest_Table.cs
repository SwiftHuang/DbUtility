using System;
using System.Data;
using System.Collections.Generic;
using hwj.DBUtility;
using Test.DB.DAL;
using Test.DB.Entity;

namespace Test.DB.BLL
{
    /// <summary>
    /// Business [BOTest_Table]
    /// </summary>
    public class BOTest_Table
    {
        private static DATest_Table da = new DATest_Table("Data Source=10.100.133.83;Initial Catalog=YL;Persist Security Info=True;User ID=sa;Password=gzuat");
        public BOTest_Table()
        { }
        public static bool Exists(Int32 Test_ID)
        {
            FilterParams fp = new FilterParams();
            fp.AddParam(tbTest_Table.Fields.Test_ID, Test_ID, Enums.Relation.Equal, Enums.Expression.AND);
            return da.RecordCount(fp) > 0;
        }

        public static bool Add(tbTest_Table entity)
        {
            return da.Add(entity);
        }

        public static bool Update(tbTest_Table updateEntity, Int32 Test_ID)
        {
            FilterParams fp = new FilterParams();
            fp.AddParam(tbTest_Table.Fields.Test_ID, Test_ID, Enums.Relation.Equal, Enums.Expression.AND);
            return da.Update(updateEntity, fp);
        }

        public static bool Delete(Int32 Test_ID)
        {
            FilterParams fp = new FilterParams();
            fp.AddParam(tbTest_Table.Fields.Test_ID, Test_ID, Enums.Relation.Equal, Enums.Expression.AND);
            return da.Delete(fp);
        }

        public static tbTest_Table GetEntity(Int32 Test_ID)
        {
            FilterParams fp = new FilterParams();
            fp.AddParam(tbTest_Table.Fields.Test_ID, Test_ID, Enums.Relation.Equal, Enums.Expression.AND);
            return da.GetEntity(fp);
        }

        public static tbTest_Tables GetList(Int32 Test_ID)
        {
            FilterParams fp = new FilterParams();
            fp.AddParam(tbTest_Table.Fields.Test_ID, Test_ID, Enums.Relation.Equal, Enums.Expression.AND);
            return da.GetList(null, fp);
        }

        public static tbTest_Tables GetList(Int32 Test_ID, int top)
        {
            FilterParams fp = new FilterParams();
            fp.AddParam(tbTest_Table.Fields.Test_ID, Test_ID, Enums.Relation.Equal, Enums.Expression.AND);
            return da.GetList(null, fp, null, top);
        }

        public static tbTest_TablePage GetPage(int pageIndex, int pageSize)
        {
            int RecordCount;
            tbTest_TablePage page = new tbTest_TablePage();
            DisplayFields pk = new DisplayFields();
            pk.Add(tbTest_Table.Fields.Test_ID);
            page.PageSize = pageSize;
            page.Result = da.GetPage(null, null, null, pk, pageIndex, page.PageSize, out RecordCount);
            page.RecordCount = RecordCount;
            return page;
        }

    }
}

