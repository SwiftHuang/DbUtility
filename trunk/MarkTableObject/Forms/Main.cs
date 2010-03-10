using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace hwj.MarkTableObject.Forms
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }


        private void tBtnAddPrj_Click(object sender, EventArgs e)
        {
            Forms.ProjectFrm prj = new ProjectFrm();
            prj.IsAddMode = true;
            prj.ShowDialog();

            if (prj.Project != null)
            {
                TreeNode node = new TreeNode(prj.Project.Name);
                node.Tag = prj.Project.FileName;
                tvServers.Nodes[0].Nodes.Add(node);
                XMLHelper.SaveTreeView(tvServers);
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            InitData();
        }

        private void InitData()
        {
            XMLHelper.GetMenu(ref tvServers);
        }
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    string connectionString = txtConn.Text;
        //    //string sql = "EXEC [SP_RPT_ARAPBalances]	'GT','1001','G113','','AR','PRM'";// txtSql.Text;
        //    string sql = txtSql.Text;

        //    connectionString = "Data Source=192.168.1.200;Initial Catalog=eAccount;Persist Security Info=True;User ID=sa;Password=113502";
        //    Entity.EntityInfo inf = new hwj.MarkTableObject.Entity.EntityInfo();
        //    inf.EntityName = "ARTx";
        //    inf.ConnectionString = connectionString;
        //    textBox1.Text = BLL.BuilderEntity.CreatEntity(inf, ConnType.MSSQL, DBModule.Table);
        //}

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    Entity.EntityInfo inf = new hwj.MarkTableObject.Entity.EntityInfo();
        //    inf.EntityName = "ARTx";
        //    inf.ConnectionString = "Provider=SQLOLEDB;Data Source=192.168.1.200;Password=113502;User ID=sa;Initial Catalog=eAccount";
        //    textBox1.Text = BLL.BuilderEntity.CreatEntity(inf, ConnType.OleDb, DBModule.Table);
        //}

    }
}
