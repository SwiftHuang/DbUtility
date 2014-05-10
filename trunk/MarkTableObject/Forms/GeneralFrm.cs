using hwj.MarkTableObject.Entity;
using System;
using System.Collections.Generic;
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

        #endregion Property

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

                txtBLLConnection.Text = ProjectInfo.BusinessConnection;

                txtBLLNameSpace.Text = ProjectInfo.BusinessNamespace;
                lblBLLFileName.Text = ProjectInfo.BusinessPath;
                txtBLLPrefixChar.Text = ProjectInfo.BusinessPrefixChar;

                txtBLLNameSpace4View.Text = ProjectInfo.BusinessNamespace4View;
                lblBLLFileName4View.Text = ProjectInfo.BusinessPath4View;
                txtBLLPrefixChar4View.Text = ProjectInfo.BusinessPrefixChar4View;

                txtDALNameSpace.Text = ProjectInfo.DataAccessNamespace;
                lblDALFileName.Text = ProjectInfo.DataAccessPath;
                txtDALPrefixChar.Text = ProjectInfo.DataAccessPrefixChar;

                txtDALNameSpace4View.Text = ProjectInfo.DataAccessNamespace4View;
                lblDALFileName4View.Text = ProjectInfo.DataAccessPath4View;
                txtDALPrefixChar4View.Text = ProjectInfo.DataAccessPrefixChar4View;

                txtEntityNameSpace.Text = ProjectInfo.EntityNamespace;
                lblEntityFileName.Text = ProjectInfo.EntityPath;
                txtEntityPrefixChar.Text = ProjectInfo.EntityPrefixChar;

                txtEntityNameSpace4View.Text = ProjectInfo.EntityNamespace4View;
                lblEntityFileName4View.Text = ProjectInfo.EntityPath4View;
                txtEntityPrefixChar4View.Text = ProjectInfo.EntityPrefixChar4View;

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
            ProjectInfo.BusinessConnection = txtBLLConnection.Text.Trim();

            ProjectInfo.BusinessNamespace = txtBLLNameSpace.Text.Trim();
            ProjectInfo.BusinessPrefixChar = txtBLLPrefixChar.Text.Trim();

            ProjectInfo.BusinessNamespace4View = txtBLLNameSpace4View.Text.Trim();
            ProjectInfo.BusinessPrefixChar4View = txtBLLPrefixChar4View.Text.Trim();

            ProjectInfo.DataAccessNamespace = txtDALNameSpace.Text.Trim();
            ProjectInfo.DataAccessPrefixChar = txtDALPrefixChar.Text.Trim();

            ProjectInfo.DataAccessNamespace4View = txtDALNameSpace4View.Text.Trim();
            ProjectInfo.DataAccessPrefixChar4View = txtDALPrefixChar4View.Text.Trim();

            ProjectInfo.EntityNamespace = txtEntityNameSpace.Text.Trim();
            ProjectInfo.EntityPrefixChar = txtEntityPrefixChar.Text.Trim();

            ProjectInfo.EntityNamespace4View = txtEntityNameSpace4View.Text.Trim();
            ProjectInfo.EntityPrefixChar4View = txtEntityPrefixChar4View.Text.Trim();

            ProjectInfo.Template = cboTemplateType.SelectedIndex == 0 ? TemplateType.DataAccess : TemplateType.Business;
            ProjectInfo.SaveXML();
        }

        private void GeneralTable()
        {
            if (TableList != null && TableList.Count > 0)
            {
                GeneralInfo genInfo = new GeneralInfo(ProjectInfo, DBModule.Table);

                GeneralMethodInfo methodInfo = new GeneralMethodInfo();
                methodInfo.Exists = chkExists.Checked;
                methodInfo.Add = chkAdd.Checked;
                methodInfo.Update = chkUpdate.Checked;
                methodInfo.Delete = chkDelete.Checked;
                methodInfo.GetEntity = true;
                methodInfo.Page = chkGetPage.Checked;
                methodInfo.List = chkGetList.Checked;
                methodInfo.AllList = chkGetAllList.Checked;

                foreach (string s in TableList)
                {
                    if (chkEntity.Checked)
                    {
                        BLL.BuilderEntity.CreateTableFile(genInfo, s);
                    }
                    if (chkDAL.Checked)
                    {
                        BLL.BuilderDAL.CreateTableFile(genInfo, s, methodInfo);
                    }
                    if (chkBLL.Checked)
                    {
                        BLL.BuilderBLL.CreateTableFile(genInfo, s, methodInfo);
                    }
                }
            }
        }

        private void GeneralView()
        {
            if (ViewList != null && ViewList.Count > 0)
            {
                GeneralInfo genInfo = new GeneralInfo(ProjectInfo, DBModule.View);

                GeneralMethodInfo methodInfo = new GeneralMethodInfo();
                methodInfo.Exists = chkExists4View.Checked;
                methodInfo.Add = chkAdd4View.Checked;
                methodInfo.Update = chkUpdate4View.Checked;
                methodInfo.Delete = chkDelete4View.Checked;
                methodInfo.GetEntity = true;
                methodInfo.Page = chkGetPage4View.Checked;
                methodInfo.List = chkGetList4View.Checked;
                methodInfo.AllList = chkGetAllList4View.Checked;

                foreach (string s in ViewList)
                {
                    if (chkEntity.Checked)
                    {
                        BLL.BuilderEntity.CreateTableFile(genInfo, s);
                    }
                    if (chkDAL.Checked)
                    {
                        BLL.BuilderDAL.CreateTableFile(genInfo, s, methodInfo);
                    }
                    if (chkBLL.Checked)
                    {
                        BLL.BuilderBLL.CreateTableFile(genInfo, s, methodInfo);
                    }
                }
            }
        }

        #region Event Method

        private void btnGeneral_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateProjectInfo();

                GeneralTable();
                GeneralView();

                Common.MsgInfo("操作完成");
            }
            catch (Exception ex)
            {
                Common.MsgError(ex.Message, ex);
            }
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
                txtBLLConnection.Enabled = false;
                txtBLLNameSpace.Enabled = txtBLLNameSpace4View.Enabled = false;
                txtBLLPrefixChar.Enabled = txtBLLPrefixChar4View.Enabled = false;
            }
            else
            {
                chkBLL.Checked = true;
                txtBLLConnection.Enabled = true;

                txtBLLNameSpace.Enabled = txtBLLNameSpace4View.Enabled = true;
                txtBLLPrefixChar.Enabled = txtBLLPrefixChar4View.Enabled = true;
            }
        }

        #endregion Event Method
    }
}