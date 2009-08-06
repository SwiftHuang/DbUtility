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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);
        }

        void Form1_Load(object sender, EventArgs e)
        {
            xTextBox1.Text = "vinson";
            suggestBox1.Text = "vinson";
            suggestBox1.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                decimal i = 0;
                decimal.TryParse("-", out i);
                hwj.CommonLibrary.Object.NumberHelper.RoundDown(2.5);
                List<string> v = new List<string>();
                v.Add("2");
                Test(out v);
                //dataGridView1.DataSource = BLL.Table.BOtbDistrict.TestSql().Result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Test(out List<string> vin)
        {
            vin.Add("1");
        }

    }
}
