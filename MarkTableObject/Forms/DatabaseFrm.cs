using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using hwj.MarkTableObject.Entity;

namespace hwj.MarkTableObject.Forms
{
    public partial class DatabaseFrm : Form
    {
        #region Property
        public DatabaseInfo Database { get; set; }
        #endregion

        public DatabaseFrm()
        {
            InitializeComponent();
        }

        private void DatabaseFrm_Load(object sender, EventArgs e)
        {
            if (Database != null)
            {
                switch (Database.DatabaseType)
                {
                    case DatabaseEnum.MSSQL:
                        cboDataSourceType.SelectedIndex = 0;
                        break;
                    case DatabaseEnum.MYSQL:
                        cboDataSourceType.SelectedIndex = 1;
                        break;
                    case DatabaseEnum.OleDb:
                        cboDataSourceType.SelectedIndex = 2;
                        break;
                    default:
                        cboDataSourceType.SelectedIndex = 0;
                        break;
                }
            }
            else
                cboDataSourceType.SelectedIndex = 0;
        }

        #region Private Event Function
        private void cboDataSourceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (panel1.Controls.Count > 0)
                panel1.Controls.RemoveAt(0);
            if (cboDataSourceType.SelectedIndex == 0)
            {
                Components.MSSQLCtrl ctrl = new Components.MSSQLCtrl(Database);
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
                Components.MSSQLCtrl ctrl = panel1.Controls[0] as Components.MSSQLCtrl;
                if (ctrl != null)
                    Database = ctrl.GetDatabaseInfo();
            }
            this.Close();
        }
        #endregion

    }
}
