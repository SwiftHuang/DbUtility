using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WongTung.DataAccess
{
    public class DATestTable : WongTung.DBUtility.DALBase<Entity.Table.testtable>
    {
        public DATestTable()
        {
            TableName = Entity.Table.testtable.TableName;
        }
    }
}
