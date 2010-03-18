using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test.DemoFrm
{
    public partial class ControlsFrm : Form
    {
        public ControlsFrm()
        {
            InitializeComponent();
        }

        private void btnAddText_Click(object sender, EventArgs e)
        {
            loginComboBox1.AddText();
        }
    }
}
