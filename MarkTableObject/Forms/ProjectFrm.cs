using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using hwj.MarkTableObject.Entity;
using System.IO;
using hwj.UserControls.CommonControls;

namespace hwj.MarkTableObject.Forms
{
    public partial class ProjectFrm : Form
    {
        public ProjectInfo Project = null;
        public bool IsAddMode { get; set; }
        public DatabaseEnum ConnectionDataSource { get; set; }
        public ProjectFrm()
        {
            InitializeComponent();
        }

        private void ProjectFrm_Load(object sender, EventArgs e)
        {
            InitData();
        }

        #region Private Event Function
        private void btnDBSet_Click(object sender, EventArgs e)
        {
            DatabaseFrm db = new DatabaseFrm();
            if (Project == null)
                Project = new ProjectInfo();
            db.Database = Project.Database;
            db.ShowDialog();
            Project.Database = db.Database;
            lblDataSource.Text = Project.Database.ServerVersion;
            txtConnStr.Text = Project.Database.ConnectionString;
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
                prj.Database = Project.Database;
                prj.Template = cboTemplateType.SelectedIndex == 0 ? TemplateType.DataAccess : TemplateType.Business;
                //prj.Database.ConnectionString = txtConnStr.Text.Trim();
                //prj.Database.DatabaseType = ConnectionDataSource;
                //prj.Database.ServerVersion = lblDataSource.Text;
                if (Project == null || (Project != null && string.IsNullOrEmpty(Project.Key)))
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

        private void btnPrjPath_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtPrjPath.Text = folderBrowserDialog1.SelectedPath;
                txtBLLPath.Text = txtPrjPath.Text + "\\Business";
                txtDALPath.Text = txtPrjPath.Text + "\\DataAccess";
                txtEntityPath.Text = txtPrjPath.Text + "\\Entity";
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
        private void btnDALPath_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtDALPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }
        private void btnEntityPath_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtEntityPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void txtPrjPath_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.AppStarting;
            try
            {
                xTextBox txt = sender as xTextBox;
                if (txt != null)
                {
                    Common.OpenPath(txt.Text);
                }
            }
            catch (Exception ex)
            {
                Common.MsgWarn(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        #endregion

        #region Private Function
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
                if (Project.Database != null)
                {
                    txtConnStr.Text = Project.Database.ConnectionString;
                    lblDataSource.Text = Project.Database.ServerVersion;
                    ConnectionDataSource = Project.Database.DatabaseType;
                }
                cboTemplateType.SelectedIndex = Project.Template == TemplateType.DataAccess ? 0 : 1;

            }
        }
        #endregion

    }
}
