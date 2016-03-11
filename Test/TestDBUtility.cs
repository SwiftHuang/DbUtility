using hwj.DBUtility;
using hwj.DBUtility.MSSQL;
using System;
using System.Collections.Generic;
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
    }
}