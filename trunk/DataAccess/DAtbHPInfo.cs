using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using hwj.DBUtility.MSSQL;
using WongTung.Entity;
namespace WongTung.DataAccess
{
    public class DAtbHPInfo : BaseDAL<Entity.Table.tbHPInfo>
    {
        public DAtbHPInfo()
        {
            TableName = Entity.Table.tbHPInfo.TableName;
        }
    }
}
