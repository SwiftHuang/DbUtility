using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using hwj.UserControls.Function.Verify;
namespace Test
{
    public partial class Form2 : Form
    {
        hwj.UserControls.Function.Verify.RequiredHandle Rq = new RequiredHandle();
        public Form2()
        {
            InitializeComponent();
        }

        private void xButton1_Click(object sender, EventArgs e)
        {
            if (Rq.HasRequired)
                MessageBox.Show("RQ");
        }
    }
}
