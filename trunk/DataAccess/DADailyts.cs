using System;
using System.Collections.Generic;
using System.Text;

namespace WongTung.DataAccess
{
    public class DADailyts : WongTung.DBUtility.DALBase<Entity.Table.dailyts>
    {
    }
    public class DADailyts2 : WongTung.DBUtility.DALBase<Entity.Table.dailyts2>
    {
        public DADailyts2()
        {
            TableName = Entity.Table.dailyts.TableName;
        }
    }
}
