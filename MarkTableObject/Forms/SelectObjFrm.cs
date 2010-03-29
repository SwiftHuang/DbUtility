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
                BLL.MSSQL.BuilderColumn.GetTableList(PrjInfo.ConnectionString, out tableList, out viewList);

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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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

    }
}
