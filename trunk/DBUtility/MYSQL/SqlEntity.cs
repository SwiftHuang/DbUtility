using System.Collections.Generic;
using MySql.Data.MySqlClient;
namespace hwj.DBUtility.MYSQL
{
    public class SqlEntity 
    {
        public string Sql { get; set; }
        public List<MySqlParameter> Parameters { get; set; }
        public SqlEntity(string sql, List<MySqlParameter> ListParameter)
        {
            Sql = sql;
            Parameters = ListParameter;
        }
    }
}
