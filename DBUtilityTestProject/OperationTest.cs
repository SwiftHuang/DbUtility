﻿using hwj.DBUtility;
using hwj.DBUtility.MSSQL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TestProject.DBUtility.DataAccess;
using TestProject.DBUtility.Entity;

namespace TestProject
{
    [TestClass]
    public class OperationTest
    {
        [ClassInitialize()]
        public static void InitDate(TestContext testContext)
        {
            string errMsg = null;
            try
            {
                using (DbConnection conn = new DbConnection(TestCommon.ConnString))
                {
                    try
                    {
                        DATestTable da = new DATestTable(conn);
                        conn.BeginTransaction();
                        da.Truncate();
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
                errMsg = ex.Message;
            }
            Assert.IsNull(errMsg);
        }

        [TestMethod]
        public void Add4Identity()
        {
            string errMsg = null;
            string xmlRS = string.Empty;
            string xmlRQ = string.Empty;

            try
            {
                tbTestTable dataRS = null;
                tbTestTable dataRQ = TestCommon.GenData("Identity");

                using (DbConnection conn = new DbConnection(TestCommon.ConnString))
                {
                    try
                    {
                        DATestTable da = new DATestTable(conn);
                        conn.BeginTransaction();
                        decimal id = da.AddReturnIdentity(dataRQ);
                        dataRQ.Id = (int)id;

                        conn.CommitTransaction();

                        FilterParams fp = new FilterParams();
                        fp.AddParam(tbTestTable.Fields.Key_EN, dataRQ.Key_EN, Enums.Relation.Equal);
                        dataRS = da.GetEntity(fp);
                    }
                    catch
                    {
                        conn.RollbackTransaction();
                        throw;
                    }
                }
                //Assert.AreEqual(dataRQ.CreateOn.ToString("yyyy/MM/dd hh:mm:ss"), dataRS.CreateOn.ToString("yyyy/MM/dd hh:mm:ss"));
                //dataRQ.CreateOn = dataRS.CreateOn = DateTime.MinValue;

                xmlRQ = hwj.CommonLibrary.Object.SerializationHelper.SerializeToXml(dataRQ);
                xmlRS = hwj.CommonLibrary.Object.SerializationHelper.SerializeToXml(dataRS);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }

            Assert.IsNull(errMsg);
            Assert.AreEqual(xmlRQ, xmlRS);
        }

        [TestMethod]
        public void AddList()
        {
            string dataKey = "AddListI";
            string errMsg = null;
            string xmlRS = string.Empty;
            string xmlRQ = string.Empty;
            bool isSuccess4Add = false;
            try
            {
                tbTestTables rsLst = null;
                tbTestTables rqLst = new tbTestTables();
                for (int i = 0; i < 100; i++)
                {
                    tbTestTable dataRQ = TestCommon.GenData(string.Format("{0}{1}", dataKey, i));
                    rqLst.Add(dataRQ);
                }

                using (DbConnection conn = new DbConnection(TestCommon.ConnString))
                {
                    try
                    {
                        conn.BeginTransaction();

                        DATestTable da = new DATestTable(conn);

                        isSuccess4Add = da.AddList(rqLst);

                        conn.CommitTransaction();
                        
                        FilterParams fp = new FilterParams();
                        fp.AddParam(tbTestTable.Fields.Key_EN, dataKey + "%", Enums.Relation.Like);
                        SortParams sps = new SortParams(tbTestTable.Fields.Id, Enums.OrderBy.Ascending);
                        rsLst = da.GetList(null, fp, sps);
                        rsLst.ForEach(c => c.Id = 0);

                        xmlRQ = hwj.CommonLibrary.Object.SerializationHelper.SerializeToXml(rqLst);
                        xmlRS = hwj.CommonLibrary.Object.SerializationHelper.SerializeToXml(rsLst);
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
                errMsg = ex.Message;
            }
            Assert.IsNull(errMsg);
            Assert.IsTrue(isSuccess4Add);
            Assert.AreEqual(xmlRQ, xmlRS);
        }

        [TestMethod]
        public void AddList_Missing()
        {
            string dataKey = "AddListM";
            string errMsg = null;
            string xmlRS = string.Empty;
            string xmlRQ = string.Empty;
            bool isSuccess4Add = false;
            try
            {
                tbTestTables rsLst = null;
                tbTestTables rqLst = new tbTestTables();
                for (int i = 0; i < 100; i++)
                {
                    tbTestTable dataRQ = TestCommon.GenData(string.Format("{0}{1}", dataKey, i), true);
                    rqLst.Add(dataRQ);
                }

                using (DbConnection conn = new DbConnection(TestCommon.ConnString))
                {
                    try
                    {
                        conn.BeginTransaction();

                        DATestTable da = new DATestTable(conn);

                        isSuccess4Add = da.AddList(rqLst);

                        conn.CommitTransaction();

                        FilterParams fp = new FilterParams();
                        fp.AddParam(tbTestTable.Fields.Key_EN, dataKey + "%", Enums.Relation.Like);
                        SortParams sps = new SortParams(tbTestTable.Fields.Id, Enums.OrderBy.Ascending);
                        rsLst = da.GetList(null, fp, sps);
                        rsLst.ForEach(c => c.Id = 0);

                        foreach (var d in rqLst)
                        {
                            d.Amt_Int = 99;
                        }
                        xmlRQ = hwj.CommonLibrary.Object.SerializationHelper.SerializeToXml(rqLst);
                        xmlRS = hwj.CommonLibrary.Object.SerializationHelper.SerializeToXml(rsLst);
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
                errMsg = ex.Message;
            }
            Assert.IsNull(errMsg);
            Assert.IsTrue(isSuccess4Add);
            Assert.AreEqual(xmlRQ, xmlRS);
        }

        [TestMethod]
        public void AddList_ByDbEntity()
        {
            string dataKey = "AddListN";
            string errMsg = null;
            string xmlRS = string.Empty;
            string xmlRQ = string.Empty;
            bool isSuccess4Add = false;
            try
            {
                tbTestTables rsLst = null;
                tbTestTables rqLst = new tbTestTables();
                for (int i = 0; i < 100; i++)
                {
                    tbTestTable dataRQ = TestCommon.GenData(string.Format("{0}{1}", dataKey, i));
                    rqLst.Add(dataRQ);
                }

                using (DbConnection conn = new DbConnection(TestCommon.ConnString))
                {
                    try
                    {
                        conn.BeginTransaction();

                        DATestTable da = new DATestTable(conn);
                        da.AddList(rqLst);

                        FilterParams fp = new FilterParams();
                        fp.AddParam(tbTestTable.Fields.Key_EN, dataKey + "%", Enums.Relation.Like);
                        SortParams sps = new SortParams(tbTestTable.Fields.Id, Enums.OrderBy.Ascending);

                        var addEntityList = da.GetList(null, fp, sps);
                        isSuccess4Add = da.AddList(addEntityList);

                        conn.CommitTransaction();

                        addEntityList.ForEach(c => c.Id = 0);
                        rqLst.AddRange(addEntityList);

                        rsLst = da.GetList(null, fp, sps);
                        rsLst.ForEach(c => c.Id = 0);

                        xmlRQ = hwj.CommonLibrary.Object.SerializationHelper.SerializeToXml(rqLst);
                        xmlRS = hwj.CommonLibrary.Object.SerializationHelper.SerializeToXml(rsLst);
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
                errMsg = ex.Message;
            }
            Assert.IsNull(errMsg);
            Assert.IsTrue(isSuccess4Add);
            Assert.AreEqual(xmlRQ, xmlRS);
        }

        [TestMethod]
        public void Add()
        {
            string errMsg = null;
            string xmlRS = string.Empty;
            string xmlRQ = string.Empty;
            bool isSuccess4Add = false;
            try
            {
                tbTestTable dataRS = null;
                tbTestTable dataRQ = TestCommon.GenData("ADD");

                using (DbConnection conn = new DbConnection(TestCommon.ConnString))
                {
                    try
                    {
                        DATestTable da = new DATestTable(conn);
                        conn.BeginTransaction();
                        isSuccess4Add = da.Add(dataRQ);

                        conn.CommitTransaction();

                        FilterParams fp = new FilterParams();
                        fp.AddParam(tbTestTable.Fields.Key_EN, dataRQ.Key_EN, Enums.Relation.Equal);
                        dataRS = da.GetEntity(fp);

                        dataRS.Id = 0;
                        xmlRS = hwj.CommonLibrary.Object.SerializationHelper.SerializeToXml(dataRS);
                    }
                    catch
                    {
                        conn.RollbackTransaction();
                        throw;
                    }
                }

                xmlRQ = hwj.CommonLibrary.Object.SerializationHelper.SerializeToXml(dataRQ);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            Assert.IsNull(errMsg);
            Assert.IsTrue(isSuccess4Add);
            Assert.AreEqual(xmlRQ, xmlRS);
        }

        [TestMethod]
        public void Add_Missing()
        {
            string errMsg = null;
            string xmlRS = string.Empty;
            string xmlRQ = string.Empty;
            bool isSuccess4Add = false;
            try
            {
                tbTestTable dataRS = null;
                tbTestTable dataRQ = TestCommon.GenData("ADD_MISS", true);

                using (DbConnection conn = new DbConnection(TestCommon.ConnString))
                {
                    try
                    {
                        DATestTable da = new DATestTable(conn);
                        conn.BeginTransaction();
                        isSuccess4Add = da.Add(dataRQ);

                        conn.CommitTransaction();

                        FilterParams fp = new FilterParams();
                        fp.AddParam(tbTestTable.Fields.Key_EN, dataRQ.Key_EN, Enums.Relation.Equal);
                        dataRS = da.GetEntity(fp);

                        dataRS.Id = 0;
                        xmlRS = hwj.CommonLibrary.Object.SerializationHelper.SerializeToXml(dataRS);
                    }
                    catch
                    {
                        conn.RollbackTransaction();
                        throw;
                    }
                }

                dataRQ.Amt_Int = 99;
                xmlRQ = hwj.CommonLibrary.Object.SerializationHelper.SerializeToXml(dataRQ);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }

            Assert.IsNull(errMsg);
            Assert.IsTrue(isSuccess4Add);
            Assert.AreEqual(xmlRQ, xmlRS);
        }

        [TestMethod]
        public void Add_ByDbEntity()
        {
            string errMsg = null;
            string xmlRS = string.Empty;
            string xmlRQ = string.Empty;
            bool isSuccess4Add = false;
            try
            {
                tbTestTable dataRS = null;
                tbTestTable addRQ = null;
                tbTestTable dataRQ = TestCommon.GenData("ADD");

                using (DbConnection conn = new DbConnection(TestCommon.ConnString))
                {
                    try
                    {
                        DATestTable da = new DATestTable(conn);
                        conn.BeginTransaction();

                        decimal id = da.AddReturnIdentity(dataRQ);
                        FilterParams fp = new FilterParams();
                        fp.AddParam(tbTestTable.Fields.Id, id);
                        addRQ = da.GetEntity(fp);

                        decimal id_AddByDbEntity = da.AddReturnIdentity(addRQ);
                        isSuccess4Add = id_AddByDbEntity > decimal.Zero;

                        conn.CommitTransaction();

                        FilterParams fp_AddByDbEntity = new FilterParams();
                        fp_AddByDbEntity.AddParam(tbTestTable.Fields.Id, id_AddByDbEntity);
                        dataRS = da.GetEntity(fp_AddByDbEntity);
                        dataRS.Id = 0;
                    }
                    catch
                    {
                        conn.RollbackTransaction();
                        throw;
                    }
                }

                xmlRS = hwj.CommonLibrary.Object.SerializationHelper.SerializeToXml(dataRS);
                xmlRQ = hwj.CommonLibrary.Object.SerializationHelper.SerializeToXml(dataRQ);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            Assert.IsNull(errMsg);
            Assert.IsTrue(isSuccess4Add);
            Assert.AreEqual(xmlRQ, xmlRS);
        }

        [TestMethod]
        public void Update()
        {
            string errMsg = null;
            string xmlRS = string.Empty;
            string xmlRQ = string.Empty;
            bool isSuccess4Update = false;

            try
            {
                tbTestTable dataRS = null;
                tbTestTable insRQ = TestCommon.GenData("INSERT");
                tbTestTable updateRQ = TestCommon.GenData("UPDATE");
                updateRQ.Key_CN = "键值2".PadRight(10, ' ');
                updateRQ.Boolean = true;
                updateRQ.Amt_Decimal = 111.11m;
                updateRQ.Amt_Float = 111111111111111f;
                updateRQ.Amt_Int = 222;
                updateRQ.Amt_Numeric = 555.55m;
                updateRQ.Desc_CN = "测试数据2";
                updateRQ.Desc_EN = "Test Data2";
                updateRQ.Remark_CN = @"测试数据2[]~!@#$%^&*()_+{}"":?><,./;'|";
                updateRQ.Remark_EN = @"Test Data2[]~!@#$%^&*()_+{}"":?><,./;'|";
                updateRQ.XML_Data = "<TEST><DATA>测试数据2</DATA></TEST>";

                using (DbConnection conn = new DbConnection(TestCommon.ConnString))
                {
                    try
                    {
                        DATestTable da = new DATestTable(conn);
                        conn.BeginTransaction();
                        decimal id = da.AddReturnIdentity(insRQ);

                        FilterParams upFP = new FilterParams();
                        upFP.AddParam(tbTestTable.Fields.Id, id);
                        isSuccess4Update = da.Update(updateRQ, upFP);

                        conn.CommitTransaction();

                        dataRS = da.GetEntity(upFP);
                        updateRQ.Id = (int)id;
                    }
                    catch
                    {
                        conn.RollbackTransaction();
                        throw;
                    }
                }

                xmlRQ = hwj.CommonLibrary.Object.SerializationHelper.SerializeToXml(updateRQ);
                xmlRS = hwj.CommonLibrary.Object.SerializationHelper.SerializeToXml(dataRS);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }

            Assert.IsNull(errMsg);
            Assert.IsTrue(isSuccess4Update);
            Assert.AreEqual(xmlRQ, xmlRS);
        }

        [TestMethod]
        public void Update_Missing()
        {
            string errMsg = null;
            string xmlRS = string.Empty;
            string xmlRQ = string.Empty;
            bool isSuccess4Update = false;

            try
            {
                tbTestTable dataRS = null;
                tbTestTable insRQ = TestCommon.GenData("INSERT",true);
                tbTestTable updateRQ = TestCommon.GenData("UPDATE", true);
                updateRQ.Key_CN = "键值2".PadRight(10, ' ');
                updateRQ.Boolean = true;
                updateRQ.Amt_Decimal = 111.11m;
                updateRQ.Amt_Float = 111111111111111f;
                //updateRQ.Amt_Int = 222;
                updateRQ.Amt_Numeric = 555.55m;
                updateRQ.Desc_CN = "测试数据2";
                //updateRQ.Desc_EN = "Test Data2";
                updateRQ.Remark_CN = @"测试数据2[]~!@#$%^&*()_+{}"":?><,./;'|";
                updateRQ.Remark_EN = @"Test Data2[]~!@#$%^&*()_+{}"":?><,./;'|";
                updateRQ.XML_Data = "<TEST><DATA>测试数据2</DATA></TEST>";

                using (DbConnection conn = new DbConnection(TestCommon.ConnString))
                {
                    try
                    {
                        DATestTable da = new DATestTable(conn);
                        conn.BeginTransaction();
                        decimal id = da.AddReturnIdentity(insRQ);

                        FilterParams upFP = new FilterParams();
                        upFP.AddParam(tbTestTable.Fields.Id, id);
                        isSuccess4Update = da.Update(updateRQ, upFP);

                        conn.CommitTransaction();

                        dataRS = da.GetEntity(upFP);
                        updateRQ.Id = (int)id;
                    }
                    catch
                    {
                        conn.RollbackTransaction();
                        throw;
                    }
                }
                updateRQ.Amt_Int = 99;
                updateRQ.Desc_EN = null;
                xmlRQ = hwj.CommonLibrary.Object.SerializationHelper.SerializeToXml(updateRQ);
                xmlRS = hwj.CommonLibrary.Object.SerializationHelper.SerializeToXml(dataRS);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }

            Assert.IsNull(errMsg);
            Assert.IsTrue(isSuccess4Update);
            Assert.AreEqual(xmlRQ, xmlRS);
        }

        [TestMethod]
        public void Update_ByDbEntity()
        {
            string errMsg = null;
            string xmlRS = string.Empty;
            string xmlRQ = string.Empty;
            bool isSuccess4Update = false;

            try
            {
                tbTestTable dataRS = null;
                tbTestTable insRQ = TestCommon.GenData("INSERT");
                tbTestTable updateRQ = null;
                using (DbConnection conn = new DbConnection(TestCommon.ConnString))
                {
                    try
                    {
                        DATestTable da = new DATestTable(conn);
                        conn.BeginTransaction();

                        decimal id = da.AddReturnIdentity(insRQ);

                        FilterParams fp = new FilterParams();
                        fp.AddParam(tbTestTable.Fields.Id, id);

                        updateRQ = da.GetEntity(fp);
                        updateRQ.Key_CN = "键值2".PadRight(10, ' ');
                        updateRQ.Boolean = true;
                        updateRQ.Amt_Decimal = 111.11m;
                        updateRQ.Amt_Float = 111111111111111f;
                        updateRQ.Amt_Int = 222;
                        updateRQ.Amt_Numeric = 555.55m;
                        updateRQ.Desc_CN = "测试数据2";
                        updateRQ.Desc_EN = "Test Data2";
                        updateRQ.Remark_CN = @"测试数据2[]~!@#$%^&*()_+{}"":?><,./;'|";
                        updateRQ.Remark_EN = @"Test Data2[]~!@#$%^&*()_+{}"":?><,./;'|";
                        updateRQ.XML_Data = "<TEST><DATA>测试数据2</DATA></TEST>";

                        isSuccess4Update = da.Update(updateRQ, fp);

                        conn.CommitTransaction();

                        dataRS = da.GetEntity(fp);
                        updateRQ.Id = (int)id;
                    }
                    catch
                    {
                        conn.RollbackTransaction();
                        throw;
                    }
                }

                xmlRQ = hwj.CommonLibrary.Object.SerializationHelper.SerializeToXml(updateRQ);
                xmlRS = hwj.CommonLibrary.Object.SerializationHelper.SerializeToXml(dataRS);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }

            Assert.IsNull(errMsg);
            Assert.IsTrue(isSuccess4Update);
            Assert.AreEqual(xmlRQ, xmlRS);
        }

        public void Delete()
        {
        }

        public void GetList()
        {
            using (DbConnection conn = new DbConnection(TestCommon.ConnString))
            {
                DATestTable da = new DATestTable(conn);
                DateTime dd = da.GetServerDateTime();
                FilterParams fp = new FilterParams();
                fp.AddParam(tbTestTable.Fields.Key_EN, "AddList%", Enums.Relation.Like);
                SortParams sps = new SortParams(tbTestTable.Fields.Id, Enums.OrderBy.Ascending);
                tbTestTables rsLst = da.GetList(null, fp, sps);
            }
        }

        [TestMethod]
        public void GetList2()
        {
            Console.WriteLine("----------主程序开始，线程ID是{0}-----------------", Thread.CurrentThread.ManagedThreadId);

            TaskFactory taskFactory = new TaskFactory();

            for (int i = 0; i < 500; i++)
            {
                Action<object> action = t =>
                {
                    GetList();

                    Console.WriteLine("当前参数是{0},当前线程是{1}", t, Thread.CurrentThread.ManagedThreadId);
                };

                taskFactory.StartNew(action, i);
            }
            Console.WriteLine("----------主程序结束，线程ID是{0}-----------------", Thread.CurrentThread.ManagedThreadId);
        }

        [TestMethod]
        public void GetList_IN()
        {
            string errMsg = null;
            string xmlRS = string.Empty;
            string xmlRQ = string.Empty;
            try
            {
                using (DbConnection conn = new DbConnection(TestCommon.ConnString))
                {
                    try
                    {
                        //测试各种IN
                        var rq1 = TestCommon.GenData("GetListIN1");
                        rq1.F_Guid = Guid.NewGuid();
                        var rq2 = TestCommon.GenData("GetListIN2");
                        rq2.Amt_Decimal = Math.Round((rq2.Amt_Decimal / 2), 2);
                        rq2.Amt_Float = Math.Round((rq2.Amt_Float / 2), 2);
                        rq2.F_Guid = Guid.NewGuid();

                        DATestTable da = new DATestTable(conn);

                        conn.BeginTransaction();

                        rq1.Id = (int)da.AddReturnIdentity(rq1);
                        rq2.Id = (int)da.AddReturnIdentity(rq2);

                        conn.CommitTransaction();

                        FilterParams fp = new FilterParams();
                        List<string> keys = new List<string> { rq1.Key_EN, rq2.Key_EN, null };//(field type = char and some value is null)
                        fp.AddParam(tbTestTable.Fields.Key_EN, new List<string> { "NOT IN 1", "NOT IN 2" }, Enums.Relation.NotIN, Enums.Expression.AND, "NIP");
                        fp.AddParam(tbTestTable.Fields.Key_EN, keys, Enums.Relation.IN, Enums.Expression.AND, "INP");
                        fp.AddParam(tbTestTable.Fields.Key_EN, string.Format("'{0}'", string.Join("','", keys.FindAll(k => k != null))), Enums.Relation.IN_SelectSQL, Enums.Expression.AND, "INSP");
                        fp.AddParam(tbTestTable.Fields.Id, new List<int> { rq1.Id, rq2.Id }, Enums.Relation.IN, Enums.Expression.AND);
                        fp.AddParam(tbTestTable.Fields.Amt_Decimal, new List<decimal> { rq1.Amt_Decimal, rq2.Amt_Decimal }, Enums.Relation.IN, Enums.Expression.AND);
                        fp.AddParam(tbTestTable.Fields.Amt_Float, new List<double> { rq1.Amt_Float, rq2.Amt_Float }, Enums.Relation.IN, Enums.Expression.AND);
                        fp.AddParam(tbTestTable.Fields.F_Guid, new List<Guid> { rq1.F_Guid, rq2.F_Guid}, Enums.Relation.IN, Enums.Expression.AND);
                        SortParams sps = new SortParams(tbTestTable.Fields.Id, Enums.OrderBy.Ascending);
                        var rsLst = da.GetList(null, fp, sps);
                        string sql = da.SqlEntity.CommandText;

                        tbTestTables rqLst = new tbTestTables { rq1, rq2 };
                        xmlRQ = hwj.CommonLibrary.Object.SerializationHelper.SerializeToXml(rqLst);
                        xmlRS = hwj.CommonLibrary.Object.SerializationHelper.SerializeToXml(rsLst);
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
                errMsg = ex.Message;
            }
            Assert.IsNull(errMsg);
            Assert.AreEqual(xmlRQ, xmlRS);
        }

        public void GetPage()
        {
        }
    }
}