using System;
using System.Data;
using System.Collections.Generic;
using hwj.DBUtility;
using Test.DB.DAL;
using Test.DB.Entity;

namespace Test.DB.BLL
{
    /// <summary>
    /// Business [BOTest_IMG]
    /// </summary>
    public class BOTest_IMG
    {
        private static DATest_IMG da = new DATest_IMG("Data Source=10.100.133.83;Initial Catalog=WMeAccount_Dev;Persist Security Info=True;User ID=sa;Password=gzuat");
        public BOTest_IMG()
        { }


        public static decimal Add(tbTest_IMG entity)
        {
            return da.AddReturnIdentity(entity);
        }

        public static bool Update(tbTest_IMG updateEntity)
        {
            return da.Update(updateEntity, null);
        }

        public static bool Delete()
        {
            return da.Delete();
        }

        public static tbTest_IMG GetEntity(decimal id)
        {
            FilterParams fp = new FilterParams();
            fp.AddParam(tbTest_IMG.Fields.Id, id, Enums.Relation.Equal);
            return da.GetEntity(fp);
        }

        public static tbTest_IMGs GetList()
        {
            return da.GetList();
        }

    }
}

