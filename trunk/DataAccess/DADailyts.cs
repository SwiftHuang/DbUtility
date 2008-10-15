using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WongTung.DataAccess
{
    public class DADailyts : BaseDataAccess<Entity.Table.dailyts>
    {
        public DADailyts()
        {
            TableName = "dailyts";
        }
    }
    public class DADailyts2 : BaseDataAccess<Entity.Table.dailyts2>
    {
        public DADailyts2()
        {
            TableName = "dailyts";
        }
    }
}
