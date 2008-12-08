using System.Collections.Generic;
using System.Data.SqlClient;
namespace hwj.DBUtility
{
    public class SqlEntity
    {
        public string Sql { get; set; }
        public List<SqlParameter> Parameters { get; set; }
        public SqlEntity()
        {
            Sql = string.Empty;
            Parameters = null;
        }
        public SqlEntity(string sql, List<SqlParameter> ListParameter)
        {
            Sql = sql;
            Parameters = ListParameter;
        }
    }
}
