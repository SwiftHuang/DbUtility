using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Test.DemoFrm
{
    public partial class ControlsFrm : Form
    {
        public ControlsFrm()
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-us");
            InitializeComponent();
        }

        private void btnAddText_Click(object sender, EventArgs e)
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFrom(@"C:\Microsoft.ReportViewer.WinForms.dll");
            assembly.GetName().GetPublicKeyToken();
            loginComboBox1.AddText();
        }

        private void xButton1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
