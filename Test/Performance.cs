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
    public partial class Performance : Form
    {
        public Performance()
        {
            InitializeComponent();
        }

        private void btnFillAll_Click(object sender, EventArgs e)
        {
            DB.Entity.tbTestOutputs list = DB.BLL.BOTestOutput.GetAllList();
            int times = 0;
            double Seconds = 0;
            for (int i = 0; i < 10; i++)
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Reset();
                stopWatch.Start();


                DB.Entity.tbTestOutputs tmp = list.ExFindAll(DB.Entity.tbTestOutput.Fields.Name, "Vinson Test 980");

                TimeSpan ts = stopWatch.Elapsed;
                stopWatch.Stop();
                Seconds += ts.TotalSeconds;

                times++;
            }
            lblFindAll.Text = (Seconds / times).ToString();
        }

        private void btnLike_Click(object sender, EventArgs e)
        {
            DB.Entity.tbTestOutputs list = DB.BLL.BOTestOutput.GetAllList();
            int times = 0;
            double Seconds = 0;
            for (int i = 0; i < 10; i++)
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Reset();
                stopWatch.Start();


                DB.Entity.tbTestOutputs tmp = list.Like(DB.Entity.tbTestOutput.Fields.Name, "黄");

                TimeSpan ts = stopWatch.Elapsed;
                stopWatch.Stop();
                Seconds += ts.TotalSeconds;

                times++;
            }
            lblLike.Text = (Seconds / times).ToString();

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            DB.Entity.tbTestOutputs list = DB.BLL.BOTestOutput.GetAllList();
            int times = 0;
            double Seconds = 0;
            for (int i = 0; i < 10; i++)
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Reset();
                stopWatch.Start();


                DB.Entity.tbTestOutput tmp = list.Find(DB.Entity.tbTestOutput.Fields.Name, "Vinson Test 983");

                TimeSpan ts = stopWatch.Elapsed;
                stopWatch.Stop();
                Seconds += ts.TotalSeconds;

                times++;
            }
            lblFind.Text = (Seconds / times).ToString("0.##############");
        }

        private void btnBinary_Click(object sender, EventArgs e)
        {
            DB.Entity.tbTestOutputs list = DB.BLL.BOTestOutput.GetAllListOrderByName();
            int times = 0;
            double Seconds = 0;
            for (int i = 0; i < 10; i++)
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Reset();
                stopWatch.Start();

                DB.Entity.tbTestOutput tmp = list.BinarySearch(DB.Entity.tbTestOutput.Fields.Name, "Vinson Test 941");

                TimeSpan ts = stopWatch.Elapsed;
                stopWatch.Stop();
                Seconds += ts.TotalSeconds;

                times++;
            }
            lblBinary.Text = (Seconds / times).ToString("0.##############");
        }

        private void btnGetTable_Click(object sender, EventArgs e)
        {
            int times = 0;
            double Seconds = 0;
            for (int i = 0; i < 10; i++)
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Reset();
                stopWatch.Start();

                DataTable list = DB.BLL.BOTestOutput.GetTable();

                TimeSpan ts = stopWatch.Elapsed;
                stopWatch.Stop();
                Seconds += ts.TotalSeconds;

                times++;
            }
            lblGetTable.Text = (Seconds / times).ToString();
        }

        private void btnGetList_Click(object sender, EventArgs e)
        {
            int times = 0;
            double Seconds = 0;
            for (int i = 0; i < 10; i++)
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Reset();
                stopWatch.Start();

                DB.Entity.tbTestOutputs list = DB.BLL.BOTestOutput.GetAllList();

                TimeSpan ts = stopWatch.Elapsed;
                stopWatch.Stop();
                Seconds += ts.TotalSeconds;

                times++;
            }
            lblGetList.Text = (Seconds / times).ToString();
        }

    }
}
