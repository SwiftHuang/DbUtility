using System;
using System.Collections.Generic;
using System.Text;

namespace WongTung.DataAccess
{
    public class DADailyts : WongTung.DBUtility.BaseDataAccess<Entity.Table.dailyts>
    {
    }
    public class DADailyts2 : WongTung.DBUtility.BaseDataAccess<Entity.Table.dailyts2>
    {
        public DADailyts2()
        {
            TableName = "dailyts";
        }
    }
}
