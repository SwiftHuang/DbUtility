﻿using System;
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
        private SelectObjFrm SelObjFrm = null;
        public Entity.ProjectInfo ProjectInfo { get; set; }
        public List<string> TableList { get; set; }
        public List<string> ViewList { get; set; }

        public GeneralFrm()
        {
            InitializeComponent();
            TableList = new List<string>();
            ViewList = new List<string>();
        }


        public void SetSelctFrm(SelectObjFrm frm)
        {
            SelObjFrm = frm;
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
            Common.MsgInfo("操作完成");
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            if (SelObjFrm != null)
                SelObjFrm.Show();
        }

        private void lblBLLFileName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.AppStarting;
            try
            {
                Label lbl = sender as Label;
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
    }
}
