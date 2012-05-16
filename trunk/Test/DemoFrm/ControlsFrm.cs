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
        protected hwj.UserControls.Function.Verify.ValueChangedHandle ValueChanged1 = null;
        protected hwj.UserControls.Function.Verify.RequiredHandle Required = null;
        public ControlsFrm()
        {
            ValueChanged1 = new hwj.UserControls.Function.Verify.ValueChangedHandle();
            ValueChanged1.ClearCheckObject();
            ValueChanged1.SetCheckObject();
            Required = new hwj.UserControls.Function.Verify.RequiredHandle();
            InitializeComponent();

        }

        private void xButton1_Click(object sender, EventArgs e)
        {
            ValueChanged1.ClearCheckObject();
            ValueChanged1.SetCheckObject();

        }


    }
}
