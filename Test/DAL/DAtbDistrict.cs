using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using hwj.DBUtility;
using hwj.DBUtility.MSSQL;
using Test.Entity.Table;

namespace Test.DAL.Table
{
    /// <summary>
    /// DataAccess [Table:tbDistrict]
    /// </summary>
    public class DAtbDistrict : BaseDAL<tbDistrict, tbDistricts>
    {
        public DAtbDistrict(string connectionString)
        {
            DbHelper.ConnectionString = connectionString;
            TableName = tbDistrict.DBTableName;
        }
    }
}

