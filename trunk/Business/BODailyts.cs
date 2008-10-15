using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using WongTung.Entity;
using WongTung.DataAccess;

namespace WongTung.Business
{
    public class BODailyts
    {
        private DADailyts DADailyts = new DADailyts();
        private DADailyts2 DADailyts2 = new DADailyts2();
        public TimeSpan timeSpan { get; set; }
        public List<Entity.Table.dailyts> GetList(int count)
        {
            List<Entity.Table.dailyts> lst = new List<WongTung.Entity.Table.dailyts>();
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
    }
}
