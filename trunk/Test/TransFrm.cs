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
                //string connStr = "Data Source=192.168.123.131;Initial Catalog=wtlemos;Persist Security Info=True;User ID=sa;Password=113502";
                string connStr = "Data Source=10.100.133.83;Initial Catalog=wtlemos;Persist Security Info=True;User ID=sa;Password=gzuat";
                DB.DAEMOSSETUP da = new Test.DB.DAEMOSSETUP(connStr);
                DB.tbEMOSSETUP setup = da.GetEntity("BKGREF", "JT", "J");

                using (hwj.DBUtility.MSSQL.DbTransaction trans = new hwj.DBUtility.MSSQL.DbTransaction(connStr))
                {
                    try
                    {

                        DB.tbEMOSSETUP setup2 = da.GetEntity(trans, "BKGREF", "JT", "J");
                        trans.Commit();
                        return;
                        //trans.Commit();
                        //string tmp = GetNewBkgRefKey(trans, "V", "VI", "BKGREF", 1);

                        DB.tbEMOSSETUP s1 = new Test.DB.tbEMOSSETUP();
                        s1.BranchCode = "V";
                        s1.CompanyCode = "VI";
                        //s1.ID = "BKGREF-BKGREF";
                        s1.ID = "BKGREF";
                        s1.VALUE = "0000000006";

                        DB.DAEMOSSETUP.Update(trans, s1, s1.ID, s1.CompanyCode, s1.BranchCode);
                        //trans.ExecuteSql(DB.DAEMOSSETUP.AddSqlEntity(s1));

                        //using (hwj.DBUtility.MSSQL.DbTransaction trans2 = new hwj.DBUtility.MSSQL.DbTransaction(connStr))
                        //{
                        //    DB.tbEMOSSETUP setup1 = da.GetEntity(trans2, "BKGREF", "VI", "V");
                        //}

                        hwj.DBUtility.FilterParams fp = new hwj.DBUtility.FilterParams();
                        fp.AddParam(DB.tbEMOSSETUP.Fields.CompanyCode, s1.CompanyCode, hwj.DBUtility.Enums.Relation.Equal, hwj.DBUtility.Enums.Expression.AND);
                        fp.AddParam(DB.tbEMOSSETUP.Fields.ID, s1.ID, hwj.DBUtility.Enums.Relation.Equal, hwj.DBUtility.Enums.Expression.AND);

                        DB.DAEMOSSETUP.Update(trans, s1, fp);

                        //trans.ExecuteSqlList(new hwj.DBUtility.SqlList() { DB.DAEMOSSETUP.DeleteSqlEntity(fp) });

                        s1.ID = "BKGREF8";
                        trans.ExecuteSql(DB.DAEMOSSETUP.AddSqlEntity(s1));
                        //trans.ExecuteSqlTran(new hwj.DBUtility.SqlList() { DB.DAEMOSSETUP.AddSqlEntity(s1) }, -1);
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        trans.SqlConn.Close();
                        //throw;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private string GetNewBkgRefKey(hwj.DBUtility.MSSQL.DbTransaction trans, string branchCode, string companyCode, string moduleCode, int numOfKey)
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

        private void xButton2_Click(object sender, EventArgs e)
        {
            string connStr = "Data Source=10.100.133.83;Initial Catalog=wtlemos;Persist Security Info=True;User ID=sa;Password=gzuat";
            hwj.DBUtility.MSSQL.DbTransaction trans = new hwj.DBUtility.MSSQL.DbTransaction(connStr);
            DB.DAEMOSSETUP da = new Test.DB.DAEMOSSETUP(trans);
            
            DB.tbEMOSSETUP s1 = da.GetEntity("BKGREF", "JT", "J");

            trans.Commit();

            trans.Begin();
            DB.tbEMOSSETUP s2 = da.GetEntity("BKGREF", "JT", "J");
            trans.Commit();
        }
    }
}
