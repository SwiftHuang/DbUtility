using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test.Demo
{
    public partial class XMLTest : Form
    {
        public XMLTest()
        {
            InitializeComponent();
        }

        private void btnGeneral_Click(object sender, EventArgs e)
        {
            DB.Entity.tbCustomer obj = hwj.CommonLibrary.Object.SerializationHelper.FromXmlExcludeXMLNS<DB.Entity.tbCustomer>(xTextBox1.Text);
        }
    }
}
