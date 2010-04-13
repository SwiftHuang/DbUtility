using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test
{
    public partial class dgFrm : Form
    {
        public dgFrm()
        {
            InitializeComponent();
            //dgList.AutoGenerateColumns = false;
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            //dgList.DataSource = DB.BLL.BOTestOutput.GetAllList();
            dgList.DataSource = Acct.BLL.BOAptx.GetList("GT", "0000000099");
            //dgList.DataSource = Acct.BLL.BOSqlEntity.GetList("GT");
        }
    }
}
