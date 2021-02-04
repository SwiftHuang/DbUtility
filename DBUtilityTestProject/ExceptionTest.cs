using hwj.DBUtility;
using hwj.DBUtility.MSSQL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestProject.DBUtility.DataAccess;
using TestProject.DBUtility.Entity;

namespace TestProject
{
    [TestClass]
    public class ExceptionTest
    {


        [TestMethod]
        public void AddList()
        {
            string expected = "Table:TestTable,Fields:[Desc_EN:20->80,Key_EN:10->11]";
            string result = string.Empty;
            try
            {
                tbTestTables lst = new tbTestTables();
                for (int i = 0; i < 10; i++)
                {
                    tbTestTable tb = new tbTestTable()
                    {
                        CreateOn = DateTime.Now,
                        Remark_EN = "Test",
                        Remark_CN = "测试",
                        Key_EN = "01234567890",
                        Desc_EN = "01234567890123456789012345678901234567890123456789012345678901234567890123456789",
                        //todo:批量数字异常没解决.
                        //Amt_Decimal = 4456,
                    };
                    lst.Add(tb);
                }

                using (DbConnection conn = new DbConnection(TestCommon.ConnString))
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
            catch (Exception ex)
            {
                result = Common.GetExData(ex, Common.ExceptionFieldsKey);
            }
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Add()
        {
            string expected = "Table:TestTable,Fields:[Amt_Decimal:3->6,Desc_EN:20->80,Key_EN:10->11,F_Guid:16->36]";
            string result = string.Empty;
            try
            {
                tbTestTable tb = new tbTestTable()
                {
                    CreateOn = DateTime.Now,
                    Remark_EN = "Test",
                    Remark_CN = "测试",
                    Key_EN = "01234567890",
                    Desc_EN = "01234567890123456789012345678901234567890123456789012345678901234567890123456789",
                    Amt_Decimal = 123456,
                };

                using (DbConnection conn = new DbConnection(TestCommon.ConnString))
                {
                    try
                    {
                        DATestTable da = new DATestTable(conn);
                        conn.BeginTransaction();
                        da.Add(tb);
                        conn.CommitTransaction();
                    }
                    catch
                    {
                        conn.RollbackTransaction();
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                result = Common.GetExData(ex, Common.ExceptionFieldsKey);
            }
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Update()
        {
            string expected = "Table:TestTable,Fields:[Amt_Decimal:3->6,Desc_EN:20->80,F_Guid:16->36]";
            string result = string.Empty;
            try
            {
                tbTestTable tb = new tbTestTable()
                {
                    CreateOn = DateTime.Now,
                    Remark_EN = "Test_UPDATE",
                    Remark_CN = "测试",
                    Key_EN = "UPDATEDATA",
                };

                using (DbConnection conn = new DbConnection(TestCommon.ConnString))
                {
                    try
                    {
                        DATestTable da = new DATestTable(conn);
                        conn.BeginTransaction();

                        da.Add(tb);

                        tb.Amt_Decimal = 123456;
                        tb.Desc_EN = "01234567890123456789012345678901234567890123456789012345678901234567890123456789";
                        FilterParams fp = new FilterParams();
                        fp.AddParam(tbTestTable.Fields.Key_EN, "UPDATEDATA", Enums.Relation.Equal);
                        da.Update(tb, fp);

                        conn.CommitTransaction();
                    }
                    catch
                    {
                        conn.RollbackTransaction();
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                result = Common.GetExData(ex, Common.ExceptionFieldsKey);
            }
            Assert.AreEqual(expected, result);
        }
    }
}