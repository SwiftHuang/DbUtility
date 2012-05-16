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
    public partial class LogFrm : Form
    {
        hwj.CommonLibrary.Object.LogHelper log = new hwj.CommonLibrary.Object.LogHelper();

        public LogFrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            log.InfoWithoutEmail("Info Test");
            log.WarnWithoutEmail("Warn Test");
            log.ErrorWithoutEmail("Error Test");
        }

        private void LogFrm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            log.ChangeInfoOutputFile("D:\\VinLog\\Test\\Info\\");
            log.ChangeWarnOutputFile("D:\\VinLog\\Test\\Warn\\");
            log.ChangeErrorOutputFile("D:\\VinLog\\Test\\Error\\");
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            string smtp = "10.100.111.82";
            try
            {
                hwj.CommonLibrary.Object.EmailHelper.Send(smtp, "VinsonHuang.gz@cn.wtltravel.com", "password", "vinsonhwj@hotmail.com", null, "SMTP Txn", "Test", false);
            }
            catch (Exception ex)
            {

            }
        }

        private void xButton1_Click(object sender, EventArgs e)
        {
            label1.Text = "PERERA WAHALATHANTRIGE U P & PERERA PADMINI &VIN ";
            xLabel1.Text = "PERERA WAHALATHANTRIGE U P & PERERA PADMINI ";
        }

        private void xButton2_Click(object sender, EventArgs e)
        {
            Stream s = hwj.CommonLibrary.Object.FileHelper.FileToStream(@"C:\1.xls");
            MemoryStream ms = hwj.CommonLibrary.Object.TextHelper.StreamToMemoryStream(s, true);

            //hwj.CommonLibrary.Object.FileHelper.StreamToFile(ms, @"C:\2.gz");

            //Stream ds = hwj.CommonLibrary.Object.TextHelper.Decompress(ms);
            //hwj.CommonLibrary.Object.FileHelper.StreamToFile(ds, @"C:\2.xls");

        }

        private void xButton3_Click(object sender, EventArgs e)
        {
            DB.Entity.tbAptx ap = DB.BLL.BOAptx.GetEntity("GT", "0000000001");

            //string tmpXml = hwj.CommonLibrary.Object.SerializationHelper.SerializeToXml<DB.Entity.tbAptx>(typeof(DB.Entity.tbAptx), ap);

            //A a = new A();
            //a.Name = "VIN1";
            //a.DecValue = 100;
            //a.A1P.Name = "A1";

            //A b = new A();
            //b.Name = "VIN";
            //b.DecValue = 100;
            //b.A1P.Name = "A2";

            //string error = string.Empty;
            //if (hwj.CommonLibrary.Object.SerializationHelper.CompareObject(a, b, null, out error))
            //{
            //}

            //List<string> errorList = new List<string>();
            //if (hwj.CommonLibrary.Object.SerializationHelper.CompareObject(a, b, null, out errorList))
            //{
            //}
        }

        public class A
        {
            public string Name { get; set; }
            public decimal DecValue { get; set; }
            public A1 A1P { get; set; }

            public A()
            {
                A1P = new A1();
            }

            public class A1
            {
                public string Name { get; set; }
                public A1()
                {

                }
            }
        }

        private void xButton4_Click(object sender, EventArgs e)
        {
            xTextBox1.ReadOnly = true;
            xTextBox1.BackColor = Color.AliceBlue;
        }

        private void xButton5_Click(object sender, EventArgs e)
        {
            try
            {
                DB.Entity.tbAptxs lst1 = DB.BLL.BOAptx.GetList("GT", 1000);
                List<string> strList = new List<string>();

                foreach (DB.Entity.tbAptx ap in lst1)
                {
                    strList.Add(ap.APTxNum);
                }
                //strList.Add("VINSON'");
                DB.Entity.tbAptxs lst2 = DB.BLL.BOAptx.GetListForAPTxNumList("GT", strList);
                DB.Entity.tbAptxs lst3 = DB.BLL.BOAptx.GetListForAPTxNumList2("GT", strList);

                DB.BLL.BOAptx.UpdateList("GT", strList);
                DB.BLL.BOAptx.UpdateList2("GT", strList);
                //DB.Entity.tbAptxs lst3 = DB.BLL.BOAptx.GetListForAmtList("GT", new List<string>() { "1000'", "2000" });
            }
            catch
            {
            }
        }

        private void xButton6_Click(object sender, EventArgs e)
        {
            try
            {
                //hwj.CommonLibrary.Object.FileHelper.CreateFile("C:\\Vinson");
                //hwj.CommonLibrary.Object.FileHelper.DeleteFolder("C:\\Vinson1\\");
                for (int i = 0; i < 1; i++)
                {
                    DB.Entity.tbAdmin_User user = new Test.DB.Entity.tbAdmin_User();
                    user.Login_Account = string.Format("Vin-6 XXXXXCCXXXXXXXXXXXXXX [{0}]", DateTime.Now.ToString());

                    //decimal x = DB.BLL.BOAdmin_User.Add(user);

                    user.Amount1 = 551.55M;

                    DB.BLL.BOAdmin_User.Update(user, 1);

                    //xTextBox2.AppendText(string.Format("{0}={1}\r\n", x, user.Login_Account));
                }
            }
            catch
            {
            }
        }

        private void xButton7_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 1000; i++)
            {
                DB.Entity.tbAdmin_User user = new Test.DB.Entity.tbAdmin_User();
                user.Login_Account = string.Format("Vin-7 [{0}]", DateTime.Now.ToString());

                decimal x = DB.BLL.BOAdmin_User.Add(user);

                xTextBox2.AppendText(string.Format("{0}={1}\r\n", x, user.Login_Account));
            }
        }

    }
}
