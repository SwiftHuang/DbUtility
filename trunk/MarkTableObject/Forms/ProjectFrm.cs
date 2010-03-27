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
                prj.BusinessNamespace = txtBLLName.Text.Trim();
                prj.BusinessPath = txtBLLPath.Text.Trim();
                prj.BusinessPrefixChar = txtBLLPrefixChar.Text.Trim();
                prj.BusinessConnection = txtBLLConnection.Text.Trim();
                prj.DataAccessNamespace = txtDALName.Text.Trim();
                prj.DataAccessPath = txtDALPath.Text.Trim();
                prj.DataAccessPrefixChar = txtDALPrefixChar.Text.Trim();
                prj.EntityNamespace = txtEntityName.Text.Trim();
                prj.EntityPath = txtEntityPath.Text.Trim();
                prj.EntityPrefixChar = txtEntityPrefixChar.Text.Trim();
                prj.ConnectionString = txtConnStr.Text.Trim();
                prj.ConnectionDataSource = ConnectionDataSource;
                prj.DataSourceName = lblDataSource.Text;
                if (Project == null)
                    prj.Key = DateTime.Now.ToString("yyyyMMddhhmmss");
                else
                    prj.Key = Project.Key;
                prj.FileName = Common.GetProjectFileName(prj.Key);

                prj.SaveXML();

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

                txtBLLName.Text = Project.BusinessNamespace;
                txtBLLPath.Text = Project.BusinessPath;
                txtBLLPrefixChar.Text = Project.BusinessPrefixChar;
                txtBLLConnection.Text = Project.BusinessConnection;

                txtDALName.Text = Project.DataAccessNamespace;
                txtDALPath.Text = Project.DataAccessPath;
                txtDALPrefixChar.Text = Project.DataAccessPrefixChar;

                txtEntityName.Text = Project.EntityNamespace;
                txtEntityPath.Text = Project.EntityPath;
                txtEntityPrefixChar.Text = Project.EntityPrefixChar;

                txtConnStr.Text = Project.ConnectionString;
                lblDataSource.Text = Project.DataSourceName;
                ConnectionDataSource = Project.ConnectionDataSource;
            }
        }

        private void btnBLLPath_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtBLLPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

    }
}
