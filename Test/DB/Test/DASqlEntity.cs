using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using hwj.DBUtility;
using hwj.DBUtility.MSSQL;
using Acct.Entity;

namespace Acct.DAL
{
    /// <summary>
    /// DataAccess [SQL:SqlEntity]
    /// </summary>
    public class DASqlEntity : BaseSqlDAL<tbSqlEntity, tbSqlEntitys>
    {
        public DASqlEntity(string connectionString)
            : base(connectionString)
        {
            CommandText = tbSqlEntity.CommandText;
        }
    }
}

