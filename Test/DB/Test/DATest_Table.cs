using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using hwj.DBUtility;
using hwj.DBUtility.MSSQL;
using Test.DB.Entity;

namespace Test.DB.DAL
{
    /// <summary>
    /// DataAccess [Table:Test_Table]
    /// </summary>
    public class DATest_Table : BaseDAL<tbTest_Table, tbTest_Tables>
    {
        public DATest_Table(string connectionString)
            : base(connectionString)
        {
            TableName = tbTest_Table.DBTableName;
        }
    }
}

