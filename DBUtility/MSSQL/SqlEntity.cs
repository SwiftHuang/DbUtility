using System.Collections.Generic;
using System.Data.SqlClient;
namespace hwj.DBUtility.MSSQL
{
    public class SqlEntity
    {
        public string Sql { get; set; }
        public List<SqlParameter> Params { get; set; }
    }
}
