using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Test
{
    public partial class TransFrm : Form
    {
        public TransFrm()
        {
            InitializeComponent();
        }

        private void xButton1_Click(object sender, EventArgs e)
        {
            try
            {


                string connStr = "Data Source=192.168.123.131;Initial Catalog=wtlemos;Persist Security Info=True;User ID=sa;Password=113502";
                DB.DAEMOSSETUP da = new Test.DB.DAEMOSSETUP(connStr);
                DB.tbEMOSSETUP setup = da.GetEntity("BKGREF", "JT", "J");

                using (hwj.DBUtility.MSSQL.TransactionHelper trans = new hwj.DBUtility.MSSQL.TransactionHelper(connStr))
                {
                    string tmp = GetNewBkgRefKey(trans, "V", "VI", "BKGREF", 1);

                    DB.tbEMOSSETUP s1 = new Test.DB.tbEMOSSETUP();
                    s1.BranchCode = "V";
                    s1.CompanyCode = "VI";
                    s1.ID = "BKGREF-BKGREF";
                    s1.VALUE = "0000000000";
                    trans.ExecuteSqlTran(new hwj.DBUtility.SqlList() { DB.DAEMOSSETUP.AddSqlEntity(s1) }, -1);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private string GetNewBkgRefKey(hwj.DBUtility.MSSQL.TransactionHelper trans, string branchCode, string companyCode, string moduleCode, int numOfKey)
        {

            SqlCommand cmd = new SqlCommand("SP_CREATEBKGKEY", trans.SqlConn, trans.SqlTrans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@IN_MODULECODE", moduleCode));
            cmd.Parameters.Add(new SqlParameter("@IN_BRANCHCODE", branchCode));
            cmd.Parameters.Add(new SqlParameter("@IN_NUMOFKEY", numOfKey));
            cmd.Parameters.Add(new SqlParameter("@IN_COMPANYCODE", companyCode));

            SqlParameter sp = new SqlParameter("@OUT_PEONYREF", SqlDbType.VarChar, 10);
            sp.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(sp);
            cmd.ExecuteScalar();
            return sp.Value.ToString();
        }
    }
}
