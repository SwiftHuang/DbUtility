using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using hwj.DBUtility;
using hwj.DBUtility.MSSQL;
using Test.DB.Entity;

namespace Test.DB.DAL
{
    /// <summary>
    /// DataAccess [Table:Test_IMG]
    /// </summary>
    public partial class DATest_IMG : BaseDAL<tbTest_IMG, tbTest_IMGs>
    {
        public DATest_IMG(string connectionString)
            : base(connectionString)
        {
            TableName = tbTest_IMG.DBTableName;
        }
    }
}

