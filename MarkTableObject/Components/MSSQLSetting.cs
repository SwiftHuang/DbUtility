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
    public partial class MSSQLSetting : hwj.UserControls.Other.MSSQLConnSetting
    {
        DatabaseInfo Database = null;

        public MSSQLSetting(DatabaseInfo databaseInfo)
        {
            InitializeComponent();
            Database = databaseInfo;
            InitData();
        }

        private void InitData()
        {
            if (Database != null)
            {
                SetConnectionString(Database.ConnectionString);
            }
        }

        public DatabaseInfo GetDatabaseInfo()
        {
            DatabaseInfo inf = new DatabaseInfo();
            inf.DatabaseType = DatabaseEnum.MSSQL;
            inf.ConnectionString = ConnectionString;// hwj.CommonLibrary.Object.StringHelper.GetMSSQLConnectionString(txtDataSource.Text, BLL.Common.GetStringValue(cboDatabase.SelectedValue), txtUser.Text, txtPassword.Text, cboVerificationType.SelectedIndex == 1);


            SqlConnStringBuilder = new SqlConnectionStringBuilder(ConnectionString);

            if (SqlConnStringBuilder != null)
            {
                inf.DataSource = SqlConnStringBuilder.DataSource;

                inf.DatabaseName = SqlConnStringBuilder.InitialCatalog;

                if (SqlConnStringBuilder.IntegratedSecurity == false)
                {
                    inf.VerificationType = "0";

                    inf.User = SqlConnStringBuilder.UserID;
                    inf.Password = SqlConnStringBuilder.Password;
                }
                else
                {
                    inf.VerificationType = "1";
                }
            }


            //inf.ServerVersion = cboServerType.SelectedItem.ToString();

            return inf;
        }
    }
}
