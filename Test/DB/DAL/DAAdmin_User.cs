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
    /// DataAccess [Table:Admin_User]
    /// </summary>
    public class DAAdmin_User : BaseDAL<tbAdmin_User, tbAdmin_Users>
    {
        public DAAdmin_User(string connectionString)
            : base(connectionString)
        {
            TableName = tbAdmin_User.DBTableName;
        }
    }
}

