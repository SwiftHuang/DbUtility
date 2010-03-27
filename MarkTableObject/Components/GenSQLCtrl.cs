using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using hwj.MarkTableObject.Entity;

namespace hwj.MarkTableObject.Components
{
    public partial class GenSQLCtrl : UserControl
    {
        ProjectInfo PrjInfo = null;
        EntityInfo EntInfo = null;
        public GenSQLCtrl()
        {
            InitializeComponent();

        }

        private void cboPrjInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DesignMode) return;
            if (cboPrjInfo.SelectedValue != null && !string.IsNullOrEmpty(cboPrjInfo.SelectedValue.ToString()))
            {
                PrjInfo = Common.GetProjectInfoByKey(cboPrjInfo.SelectedValue.ToString());
            }
        }

        private void GenSQLCtrl_Enter(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                cboPrjInfo.DisplayMember = "Title";
                cboPrjInfo.ValueMember = "Key";
                cboPrjInfo.DataSource = XMLHelper.GetPrjDataTable();
            }
        }

        private void btnGenSql_Click(object sender, EventArgs e)
        {
            try
            {
                EntInfo = new EntityInfo(PrjInfo, DBModule.SQL, txtTableName.Text.Trim());
                EntInfo.CommandText = txtSQL.Text.Trim();
                switch (PrjInfo.ConnectionDataSource)
                {
                    case ConnectionDataSourceType.MSSQL:
                        dgList.DataSource = BLL.MSSQL.BuilderColumn.GetColumnInfoForTable(EntInfo);
                        break;
                    case ConnectionDataSourceType.MYSQL:
                        break;
                    case ConnectionDataSourceType.OleDb:
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Common.MsgWarn(ex.Message, ex);
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            ColumnInfos colList = dgList.DataSource as ColumnInfos;
            if (colList != null)
            {
                EntInfo.InitColumnInfoList(colList);
                TextBox txt = tpEntity.Controls["txtEntityCode"] as TextBox;
                txt.Text = BLL.BuilderEntity.CreatEntity(EntInfo);
            }
        }
    }
}
