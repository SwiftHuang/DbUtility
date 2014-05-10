using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace hwj.MarkTableObject.Forms
{
    public partial class SelectObjFrm : Form
    {
        public Entity.ProjectInfo PrjInfo { get; set; }

        private List<string> tableList = new List<string>();
        private List<string> viewList = new List<string>();

        public SelectObjFrm()
        {
            InitializeComponent();
        }

        private void SelectObjFrm_Load(object sender, EventArgs e)
        {
            InitData();
        }

        private void InitData()
        {
            if (PrjInfo != null)
            {
                BLL.MSSQL.BuilderColumn.GetTableList(PrjInfo.Database.ConnectionString, out tableList, out viewList);

                foreach (string s in tableList)
                {
                    lstPrjObj.Items.Add(s);
                }
                foreach (string s in viewList)
                {
                    lstViewObj.Items.Add(s);
                }
            }
            RefreshCount();
        }

        private void RefreshCount()
        {
            lblTableCount.Text = string.Format("表: {0}个", lstGenObj.Items.Count);
            lblViewCount.Text = string.Format("视图: {0}个", lstGenViewObj.Items.Count);
        }

        #region Private Event Function

        #region Table Obj

        private void lstPrjObj_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstPrjObj.SelectedItem != null)
            {
                lstGenObj.Items.Add(lstPrjObj.SelectedItem);
                lstPrjObj.Items.Remove(lstPrjObj.SelectedItem);
            }
            RefreshCount();
        }

        private void lstGenObj_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstGenObj.SelectedItem != null)
            {
                lstPrjObj.Items.Add(lstGenObj.SelectedItem);
                lstGenObj.Items.Remove(lstGenObj.SelectedItem);
            }
            RefreshCount();
        }

        private void btnTurnLeft_Click(object sender, EventArgs e)
        {
            lstGenObj.Items.AddRange(lstPrjObj.Items);
            lstPrjObj.Items.Clear();
            RefreshCount();
        }

        private void btnTurnRight_Click(object sender, EventArgs e)
        {
            lstPrjObj.Items.AddRange(lstGenObj.Items);
            lstGenObj.Items.Clear();
            RefreshCount();
        }

        #endregion Table Obj

        #region View Obj

        private void btnTurnLeftByView_Click(object sender, EventArgs e)
        {
            lstGenViewObj.Items.AddRange(lstViewObj.Items);
            lstViewObj.Items.Clear();
            RefreshCount();
        }

        private void btnTurnRightByView_Click(object sender, EventArgs e)
        {
            lstViewObj.Items.AddRange(lstGenViewObj.Items);
            lstGenViewObj.Items.Clear();
            RefreshCount();
        }

        private void lstViewObj_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstViewObj.SelectedItem != null)
            {
                lstGenViewObj.Items.Add(lstViewObj.SelectedItem);
                lstViewObj.Items.Remove(lstViewObj.SelectedItem);
            }
            RefreshCount();
        }

        private void lstGenViewObj_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstGenViewObj.SelectedItem != null)
            {
                lstViewObj.Items.Add(lstGenViewObj.SelectedItem);
                lstGenViewObj.Items.Remove(lstGenViewObj.SelectedItem);
            }
            RefreshCount();
        }

        #endregion View Obj

        private void btnNext_Click(object sender, EventArgs e)
        {
            GeneralFrm frm = new GeneralFrm();
            frm.ProjectInfo = PrjInfo;
            for (int i = 0; i < lstGenObj.Items.Count; i++)
            {
                frm.TableList.Add(lstGenObj.Items[i].ToString());
            }
            for (int x = 0; x < lstGenViewObj.Items.Count; x++)
            {
                frm.ViewList.Add(lstGenViewObj.Items[x].ToString());
            }
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion Private Event Function
    }
}