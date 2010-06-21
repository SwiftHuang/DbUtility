using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Test.DemoFrm
{
    public partial class ControlsFrm : Form
    {
        public ControlsFrm()
        {
            InitializeComponent();
        }

        private void xButton1_Click(object sender, EventArgs e)
        {
            string connStr = "Data Source=192.168.1.200;Initial Catalog=eAccount;Persist Security Info=True;User ID=sa;Password=113502";
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandTimeout = 60;
                    try
                    {
                        cmd.Connection = conn;

                        string sql_1 = "update customer set update=getdate() where companycode='GT' and cltcode='GA1016'";
                        string sql_2 = "update customer set update=getdate() where companycode='GT' and cltcode='GA1017'";
                        string sql_3 = "update customer set update=getdate() where companycode='GT' and cltcode='GA1018'";
                        string sql_4 = "update customer set update=getdate() where companycode='GT' and cltcode='GA1019'";

                        cmd.CommandText = sql_1;
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = sql_2;
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = sql_3;
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = sql_4;
                        cmd.ExecuteNonQuery();

                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }


    }
}
