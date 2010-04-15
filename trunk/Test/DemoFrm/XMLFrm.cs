using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

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
                HotelSvc.AcctInvvchResult obj = hwj.CommonLibrary.Object.SerializationHelper.FromXml<HotelSvc.AcctInvvchResult>(txtXML.Text, true);
                //eMosBooking.RTINV obj = hwj.CommonLibrary.Object.SerializationHelper.FromXml<eMosBooking.RTINV>(txtXML.Text, true);
                //Acct.tbCustomer obj = hwj.CommonLibrary.Object.SerializationHelper.FromXml<Acct.tbCustomer>(txtXML.Text, true);
                txtOutput.Text = hwj.CommonLibrary.Object.SerializationHelper.SerializeToXml(obj);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTestTime_Click(object sender, EventArgs e)
        {
            int times = 0;
            double Seconds = 0;
            for (int i = 0; i < 10; i++)
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Reset();
                stopWatch.Start();

                //eMosBooking.RTTKT obj = hwj.CommonLibrary.Object.SerializationHelper.FromXml<eMosBooking.RTTKT>(txtXML.Text);
                eMosBooking.RTTKT obj = hwj.CommonLibrary.Object.SerializationHelper.FromXml<eMosBooking.RTTKT>(txtXML.Text, true);
                //Acct.tbCustomer obj = hwj.CommonLibrary.Object.SerializationHelper.FromXmlExcludeXMLNS<Acct.tbCustomer>(txtXML.Text);
                TimeSpan ts = stopWatch.Elapsed;
                stopWatch.Stop();
                Seconds += ts.TotalSeconds;

                times++;
            }
            lblTime.Text = (Seconds / times).ToString();
        }
    }
}
