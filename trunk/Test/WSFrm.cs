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
    public partial class WSFrm : Form
    {
        public WSFrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hwj.CommonLibrary.Object.WebServiceHelper.InvokeWebService(textBox1.Text, "GetInvoice", new string[] { "GT", "" });
        }
    }
}
