using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using hwj.DBUtility.MYSQL;
namespace WongTung.DataAccess
{
    public class DATestTable : hwj.DBUtility.MYSQL.BaseDAL<Entity.Table.testtable>
    {
        public DATestTable()
        {
            TableName = Entity.Table.testtable.TableName;
        }

        public List<Entity.Table.testtable> GetSpecialEntity()
        {
            string sql = "SELECT Name as Name1 FROM testtable";
            return base.CreateListEntity(DbHelperMySQL.ExecuteReader(sql));
        }

        public DataTable GetDataTable()
        {
            string sql = "SELECT Name as Name1 FROM testtable";
            return base.CreateDataTable(DbHelperMySQL.ExecuteReader(sql));
        }
    }
}
