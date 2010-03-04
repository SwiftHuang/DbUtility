using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace hwj.MarkTableObject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = txtConn.Text;
            //string sql = "EXEC [SP_RPT_ARAPBalances]	'GT','1001','G113','','AR','PRM'";// txtSql.Text;
            string sql = txtSql.Text;

            Entity.EntityInfo inf = new hwj.MarkTableObject.Entity.EntityInfo();
            inf.ColumnInfoList = BLL.BuilderEntity.GetColumnInfo(connectionString, sql);
            inf.EntityName = "ARTx";
            string str = BLL.BuilderEntity.CreatEntity(inf);
        }
    }
}
