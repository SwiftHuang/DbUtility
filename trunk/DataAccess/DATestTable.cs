using System.Collections.Generic;
using System.Data;
using hwj.DBUtility.MYSQL;
namespace WongTung.DataAccess
{
    public class DATestTable : BaseDAL<Entity.Table.testtable>
    {
        public DATestTable()
        {
            DbHelper.ConnectionString = Common.WebConfig.DatabaseConnection;
            TableName = Entity.Table.testtable.TableName;
        }

        public List<Entity.Table.testtable> GetSpecialEntity()
        {
            string sql = "SELECT Name as Name1 FROM testtable";
            return base.CreateListEntity(DbHelper.ExecuteReader(sql));
        }

        public DataTable GetDataTable()
        {
            string sql = "SELECT Name as Name1 FROM testtable";
            return base.CreateDataTable(DbHelper.ExecuteReader(sql));
        }
    }
}
