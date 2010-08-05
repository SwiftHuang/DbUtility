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
            dgList.AutoGenerateColumns = false;
            dataListPage1.CheckBoxColumn = Column1;
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            //dgList.DataSource = DB.BLL.BOTestOutput.GetAllList();

            //dgList.DataSource = Acct.BLL.BOSqlEntity.GetList("GT");
        }

        private void dgList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void xButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vinson");
        }

        private void dgFrm_Load(object sender, EventArgs e)
        {
            dgList.DataSource = Test.DB.BLL.BOAptx.GetList("GT", 100);
            hwj.UserControls.DataList.xDataGridViewTextBoxCell cell1 = dgList[Column3.Index, 0] as hwj.UserControls.DataList.xDataGridViewTextBoxCell;
            cell1.ContentType = hwj.UserControls.CommonControls.ContentType.Numberic;

            hwj.UserControls.DataList.xDataGridViewTextBoxCell cell2 = dgList[Column3.Index, 1] as hwj.UserControls.DataList.xDataGridViewTextBoxCell;
            cell2.ContentType = hwj.UserControls.CommonControls.ContentType.Numberic;
            cell2.Style.Format = "N1";
            cell2.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //hwj.UserControls.DataList.xDataGridViewTextBoxCell cell3 = dgList[Column2.Index, 2] as hwj.UserControls.DataList.xDataGridViewTextBoxCell;
            //cell3.ContentType = hwj.UserControls.CommonControls.ContentType.Email;
            ////btnGet.PerformClick();
        }
    }
}
