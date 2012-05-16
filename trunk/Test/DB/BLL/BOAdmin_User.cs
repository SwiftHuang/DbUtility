using System;
using System.Data;
using System.Collections.Generic;
using hwj.DBUtility;
using Test.DB.DAL;
using Test.DB.Entity;

namespace Test.DB.BLL
{
    /// <summary>
    /// Business [BOAdmin_User]
    /// </summary>
    public class BOAdmin_User
    {
        private static DAAdmin_User da = new DAAdmin_User("Data Source=10.100.133.83;Initial Catalog=YL;Persist Security Info=True;User ID=sa;Password=gzuat");
        public BOAdmin_User()
        { }
        public static bool Exists(Int32 Account_ID)
        {
            FilterParams fp = new FilterParams();
            fp.AddParam(tbAdmin_User.Fields.Account_ID, Account_ID, Enums.Relation.Equal, Enums.Expression.AND);
            return da.RecordCount(fp) > 0;
        }

        public static decimal Add(tbAdmin_User entity)
        {
            try
            {
                //SqlList list = new SqlList();
                //list.Add(DAAdmin_User.AddSqlEntity(entity));
                //da.ExecuteSqlTran(list);
                //return 0;
                return da.AddReturnIdentity(entity);
            }
            catch
            {
                throw;
            }
        }

        public static bool Update(tbAdmin_User updateEntity, Int32 Account_ID)
        {
            FilterParams fp = new FilterParams();
            fp.AddParam(tbAdmin_User.Fields.Account_ID, Account_ID, Enums.Relation.Equal, Enums.Expression.AND);
            return da.Update(updateEntity, fp);
        }

        public static bool Delete(Int32 Account_ID)
        {
            FilterParams fp = new FilterParams();
            fp.AddParam(tbAdmin_User.Fields.Account_ID, Account_ID, Enums.Relation.Equal, Enums.Expression.AND);
            return da.Delete(fp);
        }

        public static tbAdmin_User GetEntity(Int32 Account_ID)
        {
            FilterParams fp = new FilterParams();
            fp.AddParam(tbAdmin_User.Fields.Account_ID, Account_ID, Enums.Relation.Equal, Enums.Expression.AND);
            return da.GetEntity(fp);
        }

        public static tbAdmin_Users GetList(Int32 Account_ID)
        {
            FilterParams fp = new FilterParams();
            fp.AddParam(tbAdmin_User.Fields.Account_ID, Account_ID, Enums.Relation.Equal, Enums.Expression.AND);
            return da.GetList(null, fp);
        }

        public static tbAdmin_Users GetList(Int32 Account_ID, int top)
        {
            FilterParams fp = new FilterParams();
            fp.AddParam(tbAdmin_User.Fields.Account_ID, Account_ID, Enums.Relation.Equal, Enums.Expression.AND);
            return da.GetList(null, fp, null, top);
        }

        public static tbAdmin_UserPage GetPage(int pageIndex, int pageSize)
        {
            int RecordCount;
            tbAdmin_UserPage page = new tbAdmin_UserPage();
            DisplayFields pk = new DisplayFields();
            pk.Add(tbAdmin_User.Fields.Account_ID);
            page.PageSize = pageSize;
            page.Result = da.GetPage(null, null, null, pk, pageIndex, page.PageSize, out RecordCount);
            page.RecordCount = RecordCount;
            return page;
        }

    }
}

