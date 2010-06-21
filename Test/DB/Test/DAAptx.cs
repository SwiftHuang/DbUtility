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
    /// DataAccess [Table:Aptx]
    /// </summary>
    public class DAAptx : BaseDAL<tbAptx, tbAptxs>
    {
        public DAAptx(string connectionString)
            : base(connectionString)
        {
            TableName = tbAptx.DBTableName;
        }
    }
}

