using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test
{
    public partial class FrmAsync : Form
    {
        public FrmAsync()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();

            bwGetList.RunWorkerAsync();
            bwGetList2.RunWorkerAsync();
         

        }


        private void bwGetList_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            textBox1.AppendText("Completed");
        }

        private void bwGetList_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 1000; i++)
            {
                bwGetList.ReportProgress(i, DB.BLL.BOAptx.GetList1("GT"));
            }
        }

        private void bwGetList_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            textBox1.AppendText(string.Format("{0}:{1}\r\n", e.ProgressPercentage, e.UserState.ToString()));
        }

        private void bwGetList2_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                bwGetList2.ReportProgress(i, DB.BLL.BOAptx.GetList2("GT"));
            }
        }

        private void bwGetList2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            textBox2.AppendText(string.Format("{0}:{1}\r\n", e.ProgressPercentage, e.UserState.ToString()));
        }

        private void bwGetList2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            textBox2.AppendText("Completed");
        }
    }
}
