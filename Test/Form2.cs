using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Test
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> args = new List<string>();
            args.Add("1");
            args.Add("2");

            object obj = hwj.CommonLibrary.Object.WebServiceHelper.InvokeWebService("http://localhost/AutoSyncWebSvc/SyncTest.asmx", "GetList", args.ToArray());
            obj = null;
            //System.GC.Collect();
        }

        private void xButton1_Click(object sender, EventArgs e)
        {
            DB.Entity.tbTestOutputs list = DB.BLL.BOTestOutput.GetAllList();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Reset();
            stopWatch.Start();


            DB.Entity.tbTestOutputs tmp = list.Like(DB.Entity.tbTestOutput.Fields.Name, "黄");// list.ExFindAll(DB.Entity.tbTestOutput.Fields.Name, "Vinson Test 985");

            TimeSpan ts = stopWatch.Elapsed;
            stopWatch.Stop();
            //labelTime.Text = stopWatch.Elapsed.ToString(); 
            labelTime.Text = ts.TotalSeconds.ToString();// String.Format("{0:00}:{1:00}:{2:00}.{3:0000}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
        }
    }
}
