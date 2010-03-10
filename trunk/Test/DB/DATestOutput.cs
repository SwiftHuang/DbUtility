using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using hwj.DBUtility;
using hwj.DBUtility.MSSQL;
using Test.DB.Entity;

namespace Test.DB.DAL
{
    /// <summary>
    /// DataAccess [Table:TestOutput]
    /// </summary>
    public class DATestOutput : BaseDAL<tbTestOutput, tbTestOutputs>
    {
        public DATestOutput(string connectionString)
            : base(connectionString)
        {
            TableName = tbTestOutput.DBTableName;
        }
    }
}

