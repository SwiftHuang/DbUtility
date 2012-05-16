using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Test.DemoFrm
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            DataTable tb = new DataTable();
            tb.ReadXml(@"C:\Documents and Settings\VSH\Application Data\eAccount\Data\WM\AccountChartL1_6.xml");
            suggestBoxView1.DataSource = tb;
        }

        private void btnDBTest_Click(object sender, EventArgs e)
        {
            BackgroundWorker b1 = new BackgroundWorker();
            b1.DoWork += new DoWorkEventHandler(b1_DoWork);
            b1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(b1_RunWorkerCompleted);

            BackgroundWorker b2 = new BackgroundWorker();
            b2.DoWork += new DoWorkEventHandler(b2_DoWork);
            b2.RunWorkerCompleted += new RunWorkerCompletedEventHandler(b2_RunWorkerCompleted);

            b1.RunWorkerAsync();
            b2.RunWorkerAsync();
            //DB.BLL.BOAptx.GetList("GT", 100);
        }

        void b2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
            }
        }

        void b1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
            }
        }

        void b2_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 50000; i++)
            {
                DB.BLL.BOAptx.Exists("GT", "0000000001");
            }
        }

        void b1_DoWork(object sender, DoWorkEventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Reset();
            stopWatch.Start();
            for (int i = 0; i < 50000; i++)
            {
                DB.BLL.BOAptx.Exists("GT", "000");
            }
            TimeSpan ts = stopWatch.Elapsed;
            stopWatch.Stop();
        }

        private void btnSVCDLL_Click(object sender, EventArgs e)
        {
            hwj.CommonLibrary.Object.WebServiceHelper.InvokeWebServiceByDLL("ff", "ff", "ff", "ff", null);
        }
    }
}
