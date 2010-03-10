using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace hwj.MarkTableObject.Forms
{
    public partial class DatabaseFrm : Form
    {
        public string DataSourceName { get; private set; }
        public ConnectionDataSourceType DataSource { get; private set; }
        public string ConnectionString { get; private set; }
        public DatabaseFrm()
        {
            InitializeComponent();
            cboDataSourceType.SelectedIndex = 0;
        }

        private void cboDataSourceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (panel1.Controls.Count > 0)
                panel1.Controls.RemoveAt(0);
            if (cboDataSourceType.SelectedIndex == 0)
            {
                Components.MSSQLCtrl ctrl = new Components.MSSQLCtrl();
                ctrl.Dock = DockStyle.Fill;
                panel1.Controls.Add(ctrl);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cboDataSourceType.SelectedIndex == 0)
            {
                DataSourceName = cboDataSourceType.SelectedItem.ToString();
                DataSource = ConnectionDataSourceType.MSSQL;
                Components.MSSQLCtrl ctrl = panel1.Controls[0] as Components.MSSQLCtrl;
                if (ctrl != null)
                    ConnectionString = ctrl.GetConnectionString();
            }
            this.Close();
        }
    }
}
