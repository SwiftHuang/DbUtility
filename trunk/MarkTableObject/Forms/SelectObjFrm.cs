using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace hwj.MarkTableObject.Forms
{
    public partial class SelectObjFrm : Form
    {
        public Entity.ProjectInfo PrjInfo { get; set; }
        List<string> tableList = new List<string>();
        List<string> viewList = new List<string>();

        public SelectObjFrm()
        {
            InitializeComponent();
        }

        private void SelectObjFrm_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void RefreshList()
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
                    lstPrjObj.Items.Add(s);
                }
            }
        }

        #region Private Event Function
        private void lstPrjObj_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstPrjObj.SelectedItem != null)
            {
                lstGenObj.Items.Add(lstPrjObj.SelectedItem);
                lstPrjObj.Items.Remove(lstPrjObj.SelectedItem);
            }
        }

        private void lstGenObj_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstGenObj.SelectedItem != null)
            {
                lstPrjObj.Items.Add(lstGenObj.SelectedItem);
                lstGenObj.Items.Remove(lstGenObj.SelectedItem);
            }
        }

        private void btnTurnLeft_Click(object sender, EventArgs e)
        {
            lstGenObj.Items.AddRange(lstPrjObj.Items);
            lstPrjObj.Items.Clear();
        }
        private void btnTurnRight_Click(object sender, EventArgs e)
        {
            lstPrjObj.Items.AddRange(lstGenObj.Items);
            lstGenObj.Items.Clear();
        }

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
        #endregion
    }
}
