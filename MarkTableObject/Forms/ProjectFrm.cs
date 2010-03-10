using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using hwj.MarkTableObject.Entity;
using System.IO;

namespace hwj.MarkTableObject.Forms
{
    public partial class ProjectFrm : Form
    {
        public ProjectInfo Project = null;
        public bool IsAddMode { get; set; }
        public ConnectionDataSourceType ConnectionDataSource { get; set; }
        public ProjectFrm()
        {
            InitializeComponent();
        }

        private void btnDBSet_Click(object sender, EventArgs e)
        {
            DatabaseFrm db = new DatabaseFrm();
            db.ShowDialog();
            lblDataSource.Text = db.DataSourceName;
            txtConnStr.Text = db.ConnectionString;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Project = null;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ProjectInfo prj = new ProjectInfo();
                prj.Name = txtPrjName.Text.Trim();
                prj.MainPath = txtPrjPath.Text.Trim();
                prj.BusinessNameSpace = txtBLLName.Text.Trim();
                prj.BusinessPath = txtBLLPath.Text.Trim();
                prj.DataAccessNameSpace = txtDALName.Text.Trim();
                prj.DataAccessPath = txtDALPath.Text.Trim();
                prj.EntityNameSpace = txtEntityName.Text.Trim();
                prj.EntityPath = txtEntityPath.Text.Trim();
                prj.ConnectionString = txtConnStr.Text.Trim();
                prj.ConnectionDataSource = ConnectionDataSource;
                prj.Key = DateTime.Now.ToString("yyyyMMddhhmmss");
                prj.FileName = prj.Key + ".xml";

                string xml = hwj.CommonLibrary.Object.SerializationHelper.SerializeToXml(prj);
                string xmlPath = Properties.Settings.Default.ProjectPath + "\\" + prj.FileName;
                if (!Directory.Exists(Properties.Settings.Default.ProjectPath))
                    Directory.CreateDirectory(Properties.Settings.Default.ProjectPath);

                using (StreamWriter sw = new StreamWriter(xmlPath, false))
                {
                    sw.Write(xml);
                }
                Project = prj;
                this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
