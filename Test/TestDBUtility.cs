using hwj.DBUtility;
using hwj.DBUtility.MSSQL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Westminster.MOE.DataAccess.MOEDB.Table;
using Westminster.MOE.Entity.MOEDB.Table;

namespace Test
{
    public partial class TestDBUtility : Form
    {
        public TestDBUtility()
        {
            InitializeComponent();
        }

        private void xButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string connStr = "Data Source=10.100.133.83;Initial Catalog=MOE_Dev;Persist Security Info=True;User ID=sa;Password=gzuat";
                using (DbConnection conn = new DbConnection(connStr, 30, Enums.LockType.None, true))
                {
                    DAMOE_BookFolder da = new DAMOE_BookFolder(conn);
                    FilterParams fp = new FilterParams();
                    fp.AddParam(tbMOE_BookFolder.Fields.BFStatus, "O", Enums.Relation.Equal, Enums.Expression.AND);

                    tbMOE_BookFolders lst1 = da.GetList(null, fp, Enums.LockType.UpdLock);
                    tbMOE_BookFolders lst2 = da.GetList(null, fp, null, 10, new List<Enums.LockType>() { Enums.LockType.HoldLock, Enums.LockType.UpdLock });
                    tbMOE_BookFolders lst3 = da.GetList(null, fp, null, 10);
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void btnBulkCopy_Click(object sender, EventArgs e)
        {
            try
            {
                tbMOE_BookFolders lst1 = new tbMOE_BookFolders();
                string connStr = "Data Source=10.100.133.83;Initial Catalog=MOE_Dev;Persist Security Info=True;User ID=sa;Password=gzuat";
                using (DbConnection conn = new DbConnection(connStr, 30, Enums.LockType.None, true))
                {
                    DAMOE_BookFolder da = new DAMOE_BookFolder(conn);
                    FilterParams fp = new FilterParams();
                    //fp.AddParam(tbMOE_BookFolder.Fields.BFStatus, "O", Enums.Relation.Equal, Enums.Expression.AND);

                    lst1 = da.GetList(null, fp, null, 20000, Enums.LockType.UpdLock);
                }

                tbMOE_BookFolders lst2 = new tbMOE_BookFolders();
                string connStr2 = "Data Source=10.100.133.83;Initial Catalog=MOE;Persist Security Info=True;User ID=sa;Password=gzuat";
                using (DbConnection conn2 = new DbConnection(connStr2, 30, Enums.LockType.None, true))
                {
                    DAMOE_BookFolder da2 = new DAMOE_BookFolder(conn2);
                    FilterParams fp2 = new FilterParams();
                    //fp2.AddParam(tbMOE_BookFolder.Fields.BFStatus, "O", Enums.Relation.Equal, Enums.Expression.AND);

                    lst2 = da2.GetList(null, fp2, null, 10000, Enums.LockType.UpdLock);
                }
                tbMOE_BookFolder_VINs lst3 = new tbMOE_BookFolder_VINs();
                using (DbConnection conn3 = new DbConnection(connStr2, 30, Enums.LockType.None, true))
                {
                    Stopwatch sw = new Stopwatch();
                    DAMOE_BookFolder_VIN da3 = new DAMOE_BookFolder_VIN(conn3);
                    da3.InnerConnection.BeginTransaction();

                    lst2.AddRange(lst1);

                    foreach (var data in lst2)
                    {
                        tbMOE_BookFolder_VIN t = new tbMOE_BookFolder_VIN()
                        {
                            BFRef = data.BFRef,
                            OwnerBranch = data.OwnerBranch,
                            OwnerStaff = data.OwnerStaff,
                            OwnerTeam = data.OwnerTeam,
                            CreateOn = data.CreateOn,
                            BFSales = data.BFSales,
                            Deadline = data.Deadline,
                        };
                        lst3.Add(t);
                    }

                    sw.Start();
                    da3.AddList(lst3);
                    da3.InnerConnection.CommitTransaction();
                    sw.Stop();
                    Console.WriteLine(sw.ElapsedMilliseconds);
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}