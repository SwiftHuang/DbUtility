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
    public partial class XMLFrm : Form
    {
        public XMLFrm()
        {
            InitializeComponent();
        }

        private void btnGeneral_Click(object sender, EventArgs e)
        {
            try
            {
                eMosBooking.RTTKT obj = hwj.CommonLibrary.Object.SerializationHelper.FromXmlExcludeXMLNS<eMosBooking.RTTKT>(txtXML.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
