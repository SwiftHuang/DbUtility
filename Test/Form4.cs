using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Test
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = hwj.CommonLibrary.Object.FileHelper.ReadFile("C:\\1.xml");
            TXML t = hwj.CommonLibrary.Object.SerializationHelper.FromXml<TXML>(str);

            string test = hwj.CommonLibrary.Object.SerializationHelper.SerializeToXml<TXML>(t.GetType(), t);
            textBox1.Text = test;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AcctEntry.Refund r = new Test.AcctEntry.Refund();
            r.CompanyCode = "WM";
            r.DocNum = "9993785378964";
            r.CltCode = "HA0020";
            r.SuppCode = "HBSP105";
            r.BkgRef = "000001667";
            r.InvNum = "Vin";
            r.IssueOn = DateTime.Now;

            AcctEntry.AcctEntrySoapClient svc = new Test.AcctEntry.AcctEntrySoapClient();
            AcctEntry.Result rs = svc.Refund(r);
        }
    }

    [Serializable]
    public class TXML : ISerializable
    {
        public bool a2 { get; set; }

        [XmlElement(ElementName = "a3")]
        public string a3 { get; set; }

        public bool a4 { get; set; }

        public string a5 { get; set; }

        public TXML()
        {

        }

        #region ISerializable Members

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new Exception("vi");
        }

        #endregion
    }
}
