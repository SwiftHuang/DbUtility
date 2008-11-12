using System;
using System.Collections.Generic;
using System.Data;
using hwj.DBUtility;
using WongTung.DataAccess;
using WongTung.Entity.Table;

namespace WongTung.Business
{
    public class BODemo
    {
        private static DATestTable da = new DATestTable();
        public static string GetSelect()
        {
            SelectFields sf = new SelectFields();
            sf.Add(testtable.Fields.Name);
            sf.Add(testtable.Fields.Phone);
            
            WhereParam wp = new WhereParam();
            wp.AddParam(testtable.Fields.CreateOn, DateTime.Now.AddDays(-1), Enums.Operator.Greater);

            OrderFields op = new OrderFields();
            op.AddParam(testtable.Fields.CreateOn, Enums.OrderBy.Descending);

            da.GetList(sf, wp, op, 1);
            return da.SqlCommand;
        }
        public static List<Entity.Table.testtable> GetAll()
        {
            return da.GetSpecialEntity();
        }
        public static Entity.Table.testtable GetSingle()
        {
            return da.GetEntity();
        }
        public static DataTable GetDataTable()
        {
            return da.GetDataTable();
        }
        public static string GetCount()
        {
            return da.RecordCount().ToString() + "\r\n" + da.SqlCommand;
        }
        public static string Add()
        {
            testtable t = new testtable();
            t.Name = "vinson";
            t.Phone = 123;
            t.CreateOn = DateTime.Now;
            da.Add(t);
            return da.SqlCommand;
        }
        public static string Update()
        {
            UpdateParam up = new UpdateParam();
            up.AddParam(testtable.Fields.CreateOn, DateTime.Now.AddYears(-1));
            WhereParam wp = new WhereParam();
            wp.AddParam(testtable.Fields.Name, "vinson", Enums.Operator.Equal);

            da.Update(up);
            return da.SqlCommand;
        }
        public static string Delete()
        {
            WhereParam wp = new WhereParam();
            wp.AddParam(testtable.Fields.Phone, "1234", Enums.Operator.Equal);

            da.Delete(wp);
            return da.SqlCommand;
        }

    }
}
