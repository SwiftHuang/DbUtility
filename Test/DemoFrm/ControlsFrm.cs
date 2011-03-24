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

        private void button1_Click(object sender, EventArgs e)
        {
            bgw2.RunWorkerAsync();
            bgw1.RunWorkerAsync();
        }

        private void bgw1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                //DB.BLL.BOAptx.GetList("GT"); 
                DB.BLL.BOAptx.GetEntity("GT", "0000049903");
            }

        }

        private void bgw2_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                //DB.BLL.BOAptx.GetList("GT") ;
                DB.BLL.BOAptx.GetEntity("GT", "0000049903");
            }
        }

        private void bgw1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {

            }
        }

        private void bgw2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {

            }
        }

        private void ControlsFrm_Load(object sender, EventArgs e)
        {
            DataTable tb = new DataTable();
            tb.ReadXml(@"C:\AccountChartL1_6.xml");
            suggestBoxView1.ValueMember = tb.Columns[0].ColumnName;
            suggestBoxView1.FirstMember = tb.Columns[8].ColumnName;
            //suggestBoxView1.SecondMember = tb.Columns[1].ColumnName;
            //suggestBoxView1.SecondColumnMode = true;
            suggestBoxView1.DataSource = tb;
            suggestBoxView1.FilterString = string.Format("{1} Like '%{0}%' or {2} Like '%{0}%'", hwj.UserControls.Suggest.View.SuggestBoxView.ValueFlag, suggestBoxView1.ValueMember, suggestBoxView1.FirstMember);
        }

        private void suggestBoxView1_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void suggestBoxView1_OnSelected(hwj.UserControls.Suggest.View.SelectedItem e)
        {
            xTextBox2.Text = e.Key;
            xTextBox3.Text = e.FirstColumnValue;
        }


    }
}
