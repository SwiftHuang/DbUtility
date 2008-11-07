using System;
using System.Web;
using System.IO;
using System.Web.UI;
using System.Data;
using System.Data.OleDb;
using WongTung.Business;
namespace WongTung.WebSite.Components
{
    public partial class ImportExcel : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string filepath = Server.MapPath("~") + @"\UploadResult\result.xls";
            string sheetname = "result";
            string strConn;
            strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filepath + ";Extended Properties=Excel 8.0;";
            OleDbConnection conn = new OleDbConnection(strConn);
            OleDbDataAdapter oada = new OleDbDataAdapter("select * from [" + sheetname + "$A67:M75]", strConn);
            DataSet ds = new DataSet();
            oada.Fill(ds);
            //数据绑定   
            this.GridView1.DataSource = ds;
            this.GridView1.DataBind();

            export(this.Page, BODemo.GetDataTable(), "Vinson.xls");
        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            // Specify the path on the server to
            // save the uploaded file to.
            String savePath = Server.MapPath("~") + @"\UploadResult\";

            // Before attempting to perform operations
            // on the file, verify that the FileUpload 
            // control contains a file.
            if (FileUpload1.HasFile)
            {
                // Get the name of the file to upload.
                String fileName = FileUpload1.FileName;

                // Append the name of the file to upload to the path.
                savePath += fileName;


                // Call the SaveAs method to save the 
                // uploaded file to the specified path.
                // This example does not perform all
                // the necessary error checking.               
                // If a file with the same name
                // already exists in the specified path,  
                // the uploaded file overwrites it.
                FileUpload1.SaveAs(savePath);

                // Notify the user of the name of the file
                // was saved under.
                UploadStatusLabel.Text = "Your file was saved as " + fileName;
            }
            else
            {
                // Notify the user that a file was not uploaded.
                UploadStatusLabel.Text = "You did not specify a file to upload.";
            }

        }

        /// <summary> 
        /// 将datatable中的数据导出到指定的excel文件中 
        /// </summary> 
        /// <param name="page">web页面对象</param> 
        /// <param name="tab">包含被导出数据的datatable对象</param> 
        /// <param name="filename">excel文件的名称</param> 
        public void export(Page page, DataTable tab, string filename)
        {
            HttpResponse httpresponse = page.Response;
            System.Web.UI.WebControls.GridView gv = new System.Web.UI.WebControls.GridView();
            gv.DataSource = tab.DefaultView;
            gv.AllowPaging = false;
            gv.HeaderStyle.BackColor = System.Drawing.Color.Green;
            gv.HeaderStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Center;
            gv.HeaderStyle.Font.Bold = true;
            gv.DataBind();
            httpresponse.AppendHeader("content-disposition", "attachment;filename=" + HttpUtility.UrlEncode(filename, System.Text.Encoding.UTF8)); //filename="*.xls"; 
            httpresponse.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
            httpresponse.ContentType = "application/ms-excel";
            StringWriter tw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(tw);
            gv.RenderControl(hw);

            string filepath = Server.MapPath("~") + "\\UploadResult\\" + filename;
            StreamWriter sw = File.CreateText(filepath);
            sw.Write(tw.ToString());
            sw.Close();

            downfile(httpresponse, filename, filepath);

            httpresponse.End();
        }
        private bool downfile(HttpResponse response, string filename, string fullpath)
        {
            try
            {
                response.ContentType = "application/octet-stream";

                response.AppendHeader("content-disposition", "attachment;filename=" +
                HttpUtility.UrlEncode(filename, System.Text.Encoding.UTF8) + ";charset=gb2312");
                FileStream fs = File.OpenRead(fullpath);
                long flen = fs.Length;
                int size = 102400;//每100k同时下载数据 
                byte[] readdata = new byte[size];//指定缓冲区的大小 
                if (size > flen) size = Convert.ToInt32(flen);
                long fpos = 0;
                bool isend = false;
                while (!isend)
                {
                    if ((fpos + size) > flen)
                    {
                        size = Convert.ToInt32(flen - fpos);
                        readdata = new byte[size];
                        isend = true;
                    }
                    fs.Read(readdata, 0, size);//读入一个压缩块 
                    response.BinaryWrite(readdata);
                    fpos += size;
                }
                fs.Close();
                File.Delete(fullpath);
                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}