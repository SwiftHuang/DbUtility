using hwj.DBUtility.Core.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.DBUtility.DataAccess;
using TestProject.DBUtility.Entity;

namespace TestProject.DBUtility
{
    public class BODBUtility
    {
        const string connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DBUtility;Integrated Security=True";
        public void AddList()
        {
            tbTestTables lst = new tbTestTables();
            for (int i = 0; i < 10; i++)
            {
                tbTestTable tb = new tbTestTable()
                {
                    CreateOn = DateTime.Now,
                    Text = "Test",
                    NText = "测试",
                    Char = "01234567890",

                };
                lst.Add(tb);
            }

            using (DbConnection conn = new DbConnection(connStr))
            {
                try
                {
                    DATestTable da = new DATestTable(conn);
                    conn.BeginTransaction();
                    da.AddList(lst);
                    conn.CommitTransaction();
                }
                catch
                {
                    conn.RollbackTransaction();
                    throw;
                }
            }
        }
    }
}
