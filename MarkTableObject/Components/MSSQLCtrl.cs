using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using hwj.MarkTableObject.Entity;

namespace hwj.MarkTableObject.Components
{
    public partial class MSSQLCtrl : UserControl
    {
        DatabaseInfo Database = null;
        public MSSQLCtrl(DatabaseInfo databaseInfo)
        {
            InitializeComponent();
            Database = databaseInfo;
            InitData();
        }

        public DatabaseInfo GetDatabaseInfo()
        {
            DatabaseInfo inf = new DatabaseInfo();
            inf.ConnectionString = hwj.CommonLibrary.Object.StringHelper.GetMSSQLConnectionString(txtDataSource.Text, BLL.Common.GetStringValue(cboDatabase.SelectedValue), txtUser.Text, txtPassword.Text, cboVerificationType.SelectedIndex == 1);
            if (cboDatabase.SelectedValue != null)
                inf.DatabaseName = cboDatabase.SelectedValue.ToString();
            inf.DatabaseType = DatabaseEnum.MSSQL;
            inf.DataSource = txtDataSource.Text.Trim();
            inf.Password = txtPassword.Text;
            inf.ServerVersion = cboServerType.SelectedItem.ToString();
            inf.User = txtUser.Text;
            inf.VerificationType = cboVerificationType.SelectedItem.ToString();
            return inf;
        }
        private void InitData()
        {
            if (Database != null)
            {
                txtDataSource.Text = Database.DataSource;
                cboServerType.SelectedItem = Database.ServerVersion;
                cboVerificationType.SelectedItem = Database.VerificationType;
                txtUser.Text = Database.User;
                txtPassword.Text = Database.Password;
                btnRefreshDB.PerformClick();
                cboDatabase.SelectedValue = Database.DatabaseName;
            }
            else
            {
                cboVerificationType.SelectedIndex = 0;
                cboServerType.SelectedIndex = 0;
            }
        }
        private void btnRefreshDB_Click(object sender, EventArgs e)
        {
            DatabaseInfo inf = GetDatabaseInfo();
            if (inf != null)
            {
                using (SqlConnection connection = new SqlConnection(inf.ConnectionString))
                {
                    connection.Open();
                    DataTable tb1 = connection.GetSchema("Databases");
                    DataView dv = tb1.DefaultView;
                    dv.Sort = "database_name";
                    cboDatabase.DisplayMember = "database_name";
                    cboDatabase.ValueMember = "database_name";
                    cboDatabase.DataSource = dv;
                }
            }
        }

        private void cboDatabase_Click(object sender, EventArgs e)
        {
            btnRefreshDB.PerformClick();
        }
    }
}
