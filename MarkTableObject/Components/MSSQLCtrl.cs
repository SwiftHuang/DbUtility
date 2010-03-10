using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace hwj.MarkTableObject.Components
{
    public partial class MSSQLCtrl : UserControl
    {

        public MSSQLCtrl()
        {
            InitializeComponent();
            cboVerificationType.SelectedIndex = 0;
            cboServerType.SelectedIndex = 0;
        }

        public string GetConnectionString()
        {
            return hwj.CommonLibrary.Object.StringHelper.GetMSSQLConnectionString(txtServer.Text, BLL.Common.GetStringValue(cboDatabase.SelectedValue), txtUser.Text, txtPassword.Text, cboVerificationType.SelectedIndex == 1);
        }

        private void btnRefreshDB_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();
                DataTable tb1 = connection.GetSchema("Databases");

                cboDatabase.DisplayMember = "database_name";
                cboDatabase.ValueMember = "database_name";
                cboDatabase.DataSource = tb1;
            }
        }

        private void cboDatabase_Click(object sender, EventArgs e)
        {
            btnRefreshDB.PerformClick();
        }
    }
}
