﻿using hwj.MarkTableObject.Entity;
using System;
using System.Windows.Forms;

namespace hwj.MarkTableObject.Components
{
    public partial class GenSQLCtrl : UserControl
    {
        private EntityInfo EntyInfo = null;

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
            Common.InitTemplateCombox(cboTemplateType);
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
                GeneralInfo genInfo = new GeneralInfo(PrjInfo, Module);
                EntyInfo = new EntityInfo(genInfo, Module, txtTableName.Text.Trim());
                EntyInfo.CommandText = txtSQL.Text.Trim();
                EntyInfo.SPName = txtSPName.Text.Trim();
                switch (PrjInfo.Database.DatabaseType)
                {
                    case DatabaseEnum.MSSQL:
                        dgList.DataSource = BLL.MSSQL.BuilderColumn.GetColumnInfoForTable(EntyInfo);
                        if (Module == DBModule.SP)
                        {
                            EntyInfo.SPParamInfos = BLL.MSSQL.BuilderColumn.GetColumnInfoForSPParam(EntyInfo);
                            EntyInfo.InitSPParamString();
                            txtSPParam.Text = EntyInfo.SPParamString;
                        }
                        break;

                    case DatabaseEnum.MYSQL:
                        break;

                    case DatabaseEnum.OleDb:
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
                    PrjInfo.EntityPrefixChar = string.Empty;
                    PrjInfo.Template = Common.GetTemplateTypeByComboxIndex(cboTemplateType.SelectedIndex);

                    GeneralInfo genInfo = new GeneralInfo(PrjInfo, Module);
                    BLLInfo inf = new BLLInfo(genInfo, Module, txtTableName.Text.Trim(), txtSQL.Text.Trim(), colList);
                    inf.EntityInfo.SPParamInfos = EntyInfo.SPParamInfos;
                    inf.EntityInfo.SPParamString = EntyInfo.SPParamString;
                    //inf.EntityInfo.CommandText = EntyInfo.CommandText;

                    txtEntityCode.Text = BLL.BuilderEntity.CreatEntity(inf.EntityInfo);

                    GeneralMethodInfo methodInfo = new GeneralMethodInfo();
                    methodInfo.Exists = false;
                    methodInfo.Add = false;
                    methodInfo.Update = false;
                    methodInfo.Delete = false;
                    methodInfo.GetEntity = true;
                    methodInfo.Page = Module == DBModule.SQL;
                    methodInfo.List = true;
                    methodInfo.AllList = false;

                    if (PrjInfo.Template == TemplateType.Business)
                    {
                        txtBLLCode.Text = BLL.BuilderBLL.CreateBLLCode(inf, DBModule.SQL, methodInfo);
                    }
                    else
                    {
                        if (Module == DBModule.Table)
                        {
                            methodInfo.Exists = true;
                            methodInfo.Add = true;
                            methodInfo.Update = true;
                            methodInfo.Delete = true;
                            methodInfo.GetEntity = true;
                            methodInfo.Page = true;
                            methodInfo.List = true;
                            methodInfo.AllList = true;
                        }

                        txtBLLCode.Clear();
                    }
                    txtDALCode.Text = BLL.BuilderDAL.CreateDALCode(inf.DALInfo, PrjInfo.Template, methodInfo);

                    tabGen.SelectedTab = tpEntity;
                }
            }
            catch (Exception ex)
            {
                Common.MsgError(ex.Message, ex);
            }
        }

        private void btnGenFile_Click(object sender, EventArgs e)
        {
        }

        private void btnEntityCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(txtEntityCode.Text);
        }

        private void btnDALCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(txtDALCode.Text);
        }

        private void btnBLLCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(txtBLLCode.Text);
        }
    }
}