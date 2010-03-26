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
                if (Project == null)
                    prj.Key = DateTime.Now.ToString("yyyyMMddhhmmss");
                else
                    prj.Key = Project.Key;
                prj.FileName = Common.GetProjectFileName(prj.Key);

                string xml = hwj.CommonLibrary.Object.SerializationHelper.SerializeToXml(prj);
                if (!Directory.Exists(Path.GetDirectoryName(prj.FileName)))
                    Directory.CreateDirectory(Path.GetDirectoryName(prj.FileName));

                using (StreamWriter sw = new StreamWriter(prj.FileName, false))
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

        private void ProjectFrm_Load(object sender, EventArgs e)
        {
            InitData();
        }
        private void InitData()
        {
            if (Project != null)
            {
                txtPrjName.Text = Project.Name;
                txtPrjPath.Text = Project.MainPath;
                txtBLLName.Text = Project.BusinessNameSpace;
                txtBLLPath.Text = Project.BusinessPath;
                txtDALName.Text = Project.DataAccessNameSpace;
                txtDALPath.Text = Project.DataAccessPath;
                txtEntityName.Text = Project.EntityNameSpace;
                txtEntityPath.Text = Project.EntityPath;
                txtConnStr.Text = Project.ConnectionString;
                ConnectionDataSource = Project.ConnectionDataSource;
            }
        }

    }
}
