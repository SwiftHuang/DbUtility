using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Test
{
    public partial class Form1 : Form
    {
        protected hwj.UserControls.Function.Verify.ValueChangedHandle ValueChanged1 = new hwj.UserControls.Function.Verify.ValueChangedHandle();
        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);
        }

        void Form1_Load(object sender, EventArgs e)
        {
            string url = "http://webservice.webxml.com.cn/WebServices/WeatherWS.asmx";
            string[] args = new string[2];
            args[0] = "2350";
            //args[1] = "China";
            object result = hwj.CommonLibrary.Object.WebServiceHelper.InvokeWebService(url, "getWeather", args);
            textBox1.Text = hwj.CommonLibrary.Object.SerializationHelper.SerializeToXml(result);
            ValueChanged1.ClearCheckObject();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> lst = new List<int>();
                lst.Add(1);
                lst.Add(2);
                lst.Add(3);
                lst.Add(6);
                lst.Add(8);
                lst.Add(12);
                lst.Add(15);

                List<int> r = hwj.CommonLibrary.Object.NumberHelper.GetBreakSeqNum(lst, lst[0], lst[lst.Count - 1]);
                return;
                if (ValueChanged1.IsChanged)
                    MessageBox.Show("OK");
                else
                    return;
                //MemoryStream memoryStream = new MemoryStream();
                //Pdf.PdfReader reader = Pdf.PdfReader.GetPdfReader();
                //Console.WriteLine("Number of fields: " + reader.Fields.Length);
                //memoryStream.Position = 0;
                //reader.WritePdf(memoryStream);

                Pdf.PdfReader reader = Pdf.PdfReader.GetPdfReader(@"C:\0830429ZCZD20090408.pdf");

                foreach (Pdf.PdfField field in reader.Fields)
                {
                    Console.WriteLine(field.FieldName);
                }

                FileStream fileStream = new FileStream(@"C:\pdf.txt", System.IO.FileMode.Create);
                reader.WritePdf(fileStream);
                fileStream.Close();




                decimal i = 0;
                decimal.TryParse("-", out i);
                hwj.CommonLibrary.Object.NumberHelper.RoundDown(2.5);
                //dataGridView1.DataSource = BLL.Table.BOtbDistrict.TestSql().Result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



    }
}
