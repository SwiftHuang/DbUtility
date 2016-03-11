using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Test.DB.BLL;
using Test.DB.Entity;

namespace Test
{
    public partial class ImgTestFrm : Form
    {
        private decimal ImgId = 0;
        public ImgTestFrm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //try
            //{
            FileStream fs = File.OpenRead(txtPath.Text);
            byte[] imageb = new byte[fs.Length];
            fs.Read(imageb, 0, imageb.Length);
            fs.Close();

            tbTest_IMG tb = new tbTest_IMG();
            tb.Img = imageb;

            ImgId = BOTest_IMG.Add(tb);
            pic.Image = null;
            //}
            //catch (Exception ex)
            //{

            //    //   throw;
            //}
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            tbTest_IMG tb = BOTest_IMG.GetEntity(ImgId);

            if (tb != null && tb.Img.Length > 0)
            {
                MemoryStream stream = new MemoryStream(tb.Img, true);
                stream.Write(tb.Img, 0, tb.Img.Length);
                pic.Image = new Bitmap(stream);
                stream.Close();
            }
        }


    }
}
