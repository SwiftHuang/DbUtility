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
        EntityInfo EntyInfo = null;
        public ProjectInfo PrjInfo { get; set; }
        private DBModule _Module = DBModule.SQL;
        public DBModule Module
        {
            get { return _Module; }
            set
            {
                _Module = value;
                switch (_Module)
                {
                    case DBModule.Table:
                        cboSQLType.SelectedIndex = 2;
                        break;
                    case DBModule.View:
                        cboSQLType.SelectedIndex = 3;
                        break;
                    case DBModule.SQL:
                        cboSQLType.SelectedIndex = 0;
                        break;
                    case DBModule.SP:
                        cboSQLType.SelectedIndex = 1;
                        break;
                    default:
                        Module = DBModule.SQL;
                        cboSQLType.SelectedIndex = 0;
                        break;
                }
            }
        }
        private string _ClassName = "SqlEntity";
        public string ClassName
        {
            get { return _ClassName; }
            set
            {
                _ClassName = value;
                txtTableName.Text = value;
            }
        }

        public GenSQLCtrl()
        {
            InitializeComponent();
            dgList.AutoGenerateColumns = false;
            cboSQLType.SelectedIndex = 0;
        }

        private void cboPrjInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DesignMode) return;
            if (cboPrjInfo.SelectedValue != null && !string.IsNullOrEmpty(cboPrjInfo.SelectedValue.ToString()))
            {
                PrjInfo = Common.GetProjectInfoByKey(cboPrjInfo.SelectedValue.ToString());
            }
        }
        private void cboSQLType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                if (cboSQLType.SelectedIndex == 0)
                {
                    Module = DBModule.SQL;
                    tblSP.Visible = false;
                    txtTableName.ReadOnly = false;
                }
                else if (cboSQLType.SelectedIndex == 1)
                {
                    Module = DBModule.SP;
                    tblSP.Visible = true;
                    txtTableName.ReadOnly = false;
                }
                else if (cboSQLType.SelectedIndex == 2)
                {
                    Module = DBModule.Table;
                    tblSP.Visible = false;
                    txtTableName.ReadOnly = true;
                }
                else if (cboSQLType.SelectedIndex == 3)
                {
                    Module = DBModule.View;
                    tblSP.Visible = false;
                    txtTableName.ReadOnly = true;
                }
                if (cboSQLType.SelectedItem != null)
                    gpSQL.Text = cboSQLType.SelectedItem.ToString();
            }
        }

        private void GenSQLCtrl_Enter(object sender, EventArgs e)
        {
            if (!DesignMode && cboPrjInfo.DataSource == null)
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
                EntyInfo = new EntityInfo(PrjInfo, Module, txtTableName.Text.Trim());
                EntyInfo.CommandText = txtSQL.Text.Trim();
                EntyInfo.SPName = txtSPName.Text.Trim();
                switch (PrjInfo.ConnectionDataSource)
                {
                    case ConnectionDataSourceType.MSSQL:
                        dgList.DataSource = BLL.MSSQL.BuilderColumn.GetColumnInfoForTable(EntyInfo);
                        if (Module == DBModule.SP)
                        {
                            EntyInfo.SPParamInfos = BLL.MSSQL.BuilderColumn.GetColumnInfoForSPParam(EntyInfo);
                            EntyInfo.InitSPParamString();
                            txtSPParam.Text = EntyInfo.SPParamString;
                        }
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
            try
            {
                ColumnInfos colList = dgList.DataSource as ColumnInfos;
                if (colList != null)
                {
                    BLLInfo inf = new BLLInfo(PrjInfo, Module, txtTableName.Text.Trim(), txtSQL.Text.Trim(), colList);
                    inf.EntityInfo.SPParamInfos = EntyInfo.SPParamInfos;
                    inf.EntityInfo.SPParamString = EntyInfo.SPParamString;
                    inf.EntityInfo.CommandText = EntyInfo.CommandText;
                    TextBox txt = tpEntity.Controls["txtEntityCode"] as TextBox;
                    if (txt != null)
                        txt.Text = BLL.BuilderEntity.CreatEntity(inf.EntityInfo);

                    txt = tpBLL.Controls["txtBLLCode"] as TextBox;
                    if (txt != null)
                    {
                        txt.Text = BLL.BuilderBLL.CreateBLLCode(inf, DBModule.SQL, false, false, false, false, true, Module == DBModule.SQL, true, false);
                    }

                    txt = tpDAL.Controls["txtDALCode"] as TextBox;
                    if (txt != null)
                        txt.Text = BLL.BuilderDAL.CreateDALCode(inf.DALInfo);

                    tabGen.SelectedTab = tpEntity;
                }
            }
            catch (Exception ex)
            {
                Common.MsgError(ex.Message, ex);
            }
        }


    }
}
