using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace hwj.MarkTableObject.Forms
{
    public partial class GeneralFrm : Form
    {
        #region Property
        private SelectObjFrm SelObjFrm = null;
        public Entity.ProjectInfo ProjectInfo { get; set; }
        public List<string> TableList { get; set; }
        public List<string> ViewList { get; set; }
        #endregion

        public GeneralFrm()
        {
            InitializeComponent();
            TableList = new List<string>();
            ViewList = new List<string>();
            Common.InitTemplateCombox(cboTemplateType);
        }

        private void GeneralFrm_Load(object sender, EventArgs e)
        {
            if (ProjectInfo != null)
            {
                btnPre.Visible = SelObjFrm != null;

                txtBLLNameSpace.Text = ProjectInfo.BusinessNamespace;
                lblBLLFileName.Text = ProjectInfo.BusinessPath;
                txtBLLPrefixChar.Text = ProjectInfo.BusinessPrefixChar;
                txtBLLConnection.Text = ProjectInfo.BusinessConnection;

                txtDALNameSpace.Text = ProjectInfo.DataAccessNamespace;
                lblDALFileName.Text = ProjectInfo.DataAccessPath;
                txtDALPrefixChar.Text = ProjectInfo.DataAccessPrefixChar;

                txtEntityNameSpace.Text = ProjectInfo.EntityNamespace;
                lblEntityFileName.Text = ProjectInfo.EntityPath;
                txtEntityPrefixChar.Text = ProjectInfo.EntityPrefixChar;
                cboTemplateType.SelectedIndex = ProjectInfo.Template == TemplateType.DataAccess ? 0 : 1;
            }
            else
            {
                Common.MsgWarn(Properties.Resources.InvalidProjectInfo);
                this.Close();
            }
        }

        public void SetSelctFrm(SelectObjFrm frm)
        {
            SelObjFrm = frm;
        }
        private void UpdateProjectInfo()
        {
            ProjectInfo.BusinessNamespace = txtBLLNameSpace.Text.Trim();
            ProjectInfo.BusinessPrefixChar = txtBLLPrefixChar.Text.Trim();
            ProjectInfo.BusinessConnection = txtBLLConnection.Text.Trim();
            ProjectInfo.DataAccessNamespace = txtDALNameSpace.Text.Trim();
            ProjectInfo.DataAccessPrefixChar = txtDALPrefixChar.Text.Trim();
            ProjectInfo.EntityNamespace = txtEntityNameSpace.Text.Trim();
            ProjectInfo.EntityPrefixChar = txtEntityPrefixChar.Text.Trim();
            ProjectInfo.Template = cboTemplateType.SelectedIndex == 0 ? TemplateType.DataAccess : TemplateType.Business;
            ProjectInfo.SaveXML();
        }

        #region Event Method
        private void btnGeneral_Click(object sender, EventArgs e)
        {
            UpdateProjectInfo();

            GeneralMethodInfo methodInfo = new GeneralMethodInfo();
            methodInfo.Exists = chkExists.Checked;
            methodInfo.Add = chkAdd.Checked;
            methodInfo.Update = chkUpdate.Checked;
            methodInfo.Delete = chkDelete.Checked;
            methodInfo.GetEntity = chkEntity.Checked;
            methodInfo.Page = chkGetPage.Checked;
            methodInfo.List = chkGetList.Checked;
            methodInfo.AllList = chkGetAllList.Checked;

            foreach (string s in TableList)
            {
                if (chkEntity.Checked)
                {
                    BLL.BuilderEntity.CreateTableFile(ProjectInfo, s);
                }
                if (chkDAL.Checked)
                {
                    BLL.BuilderDAL.CreateTableFile(ProjectInfo, s, methodInfo);
                }
                if (chkBLL.Checked)
                {
                    BLL.BuilderBLL.CreateTableFile(ProjectInfo, s, methodInfo);
                }
            }
            Common.MsgInfo("操作完成");
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnPre_Click(object sender, EventArgs e)
        {
            if (SelObjFrm != null)
                SelObjFrm.Show();
        }
        private void lblBLLFileName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Cursor = Cursors.AppStarting;
            try
            {
                LinkLabel lbl = sender as LinkLabel;
                if (lbl != null)
                {
                    Common.OpenPath(lbl.Text);
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
        private void cboTemplateType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTemplateType.SelectedIndex == 0)
            {
                chkBLL.Checked = false;
                txtBLLNameSpace.Enabled = false;
                txtBLLConnection.Enabled = false;
                txtBLLPrefixChar.Enabled = false;
            }
            else
            {
                chkBLL.Checked = true;
                txtBLLNameSpace.Enabled = true;
                txtBLLConnection.Enabled = true;
                txtBLLPrefixChar.Enabled = true;
            }
        }
        #endregion
    }
}
