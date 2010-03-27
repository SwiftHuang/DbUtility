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
        public Entity.ProjectInfo ProjectInfo { get; set; }
        public List<string> TableList { get; set; }
        public List<string> ViewList { get; set; }
        public GeneralFrm()
        {
            InitializeComponent();
        }

        private void GeneralFrm_Load(object sender, EventArgs e)
        {
            if (ProjectInfo != null)
            {
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
            }
            else
            {
                Common.MsgWarn(Properties.Resources.InvalidProjectInfo);
                this.Close();
            }
        }

        private void btnGeneral_Click(object sender, EventArgs e)
        {
            UpdateProjectInfo();
            foreach (string s in TableList)
            {
                if (chkEntity.Checked)
                    BLL.BuilderEntity.CreateTableFile(ProjectInfo, s);
                if (chkDAL.Checked)
                    BLL.BuilderDAL.CreateTableFile(ProjectInfo, s);
                if (chkBLL.Checked)
                    BLL.BuilderBLL.CreateTableFile(ProjectInfo, s,
                        chkExists.Checked, chkAdd.Checked, chkUpdate.Checked, chkDelete.Checked, chkEntity.Checked, chkGetPage.Checked, chkGetList.Checked, chkGetAllList.Checked);
            }
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
            ProjectInfo.SaveXML();
        }
    }
}
