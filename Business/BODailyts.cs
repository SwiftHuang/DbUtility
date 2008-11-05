using System;
using System.Collections.Generic;
using System.Data;
using WongTung.DataAccess;
using WongTung.DBUtility;
using WongTung.Entity.Table;

namespace WongTung.Business
{
    public class BODailyts
    {
        private DADailyts DADailyts = new DADailyts();
        private DADailyts2 DADailyts2 = new DADailyts2();
        public TimeSpan timeSpan { get; set; }
        public IList<Entity.Table.dailyts> GetList(int count)
        {
            IList<Entity.Table.dailyts> lst = new List<WongTung.Entity.Table.dailyts>();
            lst = DADailyts.GetList("LIMIT " + count.ToString());
            timeSpan = DADailyts.timeSpan;
            return lst;
        }
        public List<Entity.Table.dailyts2> GetList2(int count)
        {
            List<Entity.Table.dailyts2> lst = new List<WongTung.Entity.Table.dailyts2>();
            lst = DADailyts2.GetList2("LIMIT " + count.ToString());
            timeSpan = DADailyts2.timeSpan;
            return lst;
        }
        public DataTable GetTable(int count)
        {
            DataTable t = new DataTable();
            t = DADailyts.GetTable("LIMIT " + count.ToString());
            timeSpan = DADailyts.timeSpan;
            return t;
        }
        public void Add(Entity.Table.dailyts entity)
        {
            DADailyts.Add(entity);
        }
        public void Update()
        {
            IList<SqlParam> upLst = new List<SqlParam>();
            upLst.Add(new SqlParam(dailyts.Fields.DT_UPDATE_DATE, DateTime.Now, Enums.Operator.Equal));
            upLst.Add(new SqlParam(dailyts.Fields.DT_UPDATE_DATE, "2000-01-01", Enums.Operator.Equal));

            IList<SqlParam> whereLst = new List<SqlParam>();
            whereLst.Add(new SqlParam(dailyts.Fields.DT_UPDATE_DATE, "2000-01-01", Enums.Operator.Equal, Enums.Expression.AND));
            whereLst.Add(new SqlParam("DT_UPDATE_DATE", "2000-01-01", Enums.Operator.Equal, Enums.Expression.None));
            DADailyts.Update(upLst, whereLst);
        }
        public void Delete()
        {
            IList<SqlParam> whereLst = new List<SqlParam>();
            whereLst.Add(new SqlParam("DT_UPDATE_DATE", DateTime.Now, Enums.Operator.Equal, Enums.Expression.OR));
            whereLst.Add(new SqlParam("DT_UPDATE_DATE", DateTime.Now, Enums.Operator.Equal, Enums.Expression.None));
            DADailyts.Delete(whereLst);
        }

        public string UpdateSql()
        {
            IList<SqlParam> upLst = new List<SqlParam>();
            upLst.Add(new SqlParam(dailyts.Fields.DT_UPDATE_DATE, DateTime.Now, Enums.Operator.Equal));
            upLst.Add(new SqlParam(dailyts.Fields.DT_UPDATE_DATE, "2000-01-01", Enums.Operator.Equal));

            IList<SqlParam> whereLst = new List<SqlParam>();
            whereLst.Add(new SqlParam(dailyts.Fields.DT_UPDATE_DATE, "2000-01-01", Enums.Operator.Equal, Enums.Expression.AND));
            whereLst.Add(new SqlParam(dailyts.Fields.DT_UPDATE_DATE, "2000-01-01", Enums.Operator.Equal, Enums.Expression.None));
            DADailyts.Update(upLst, whereLst);
            return DADailyts.Sql;
        }
        public string DeleteSql()
        {
            IList<SqlParam> whereLst = new List<SqlParam>();
            whereLst.Add(new SqlParam("DT_UPDATE_DATE", DateTime.Now, Enums.Operator.Equal, Enums.Expression.OR));
            whereLst.Add(new SqlParam("DT_UPDATE_DATE", DateTime.Now, Enums.Operator.Equal, Enums.Expression.None));
            DADailyts.Delete(whereLst);
            return DADailyts.Sql;
        }
        public string InsertSql(Entity.Table.dailyts entity)
        {
            DADailyts.Add_GetInsertID(entity);
            return DADailyts.Sql;
        }
        public string SelectSql()
        {
            List<SqlParam> wParam = new List<SqlParam>();
            wParam.AddParam(dailyts.Fields.DT_UPDATE_DATE, "2000-01-01", Enums.Operator.Unequal, Enums.Expression.OR);
            wParam.AddParam(dailyts.Fields.DT_CO_CODE, "", Enums.Operator.Unequal, Enums.Expression.AND);
            wParam.AddParam(dailyts.Fields.DT_JOB_CODE, "", Enums.Operator.Equal);

            //whereParam.Add(new SqlParam(dailyts.Fields.DT_UPDATE_DATE, "2000-01-01", Enums.Operator.Unequal, Enums.Expression.OR));
            //whereParam.Add(new SqlParam(dailyts.Fields.DT_CO_CODE, "", Enums.Operator.IsNull, Enums.Expression.AND));
            //whereParam.Add(new SqlParam(dailyts.Fields.DT_LINE_NO, "", Enums.Operator.IsNotNull, Enums.Expression.AND));
            //whereParam.Add(new SqlParam(dailyts.Fields.DT_CO_CODE, "", Enums.Operator.Unequal, Enums.Expression.None));

            DADailyts.Select(wParam);
            return DADailyts.Sql;
        }
        public string InsertTestTable()
        {
            Entity.Table.testtable t = new testtable();
            t.Name = "vinson";
            t.Phone = 123;
            t.CreateOn = DateTime.Now;
            DATestTable d = new DATestTable();
            return d.Add_GetInsertID(t).ToString();
        }
    }
}
