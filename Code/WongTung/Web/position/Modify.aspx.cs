using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using LTP.Common;
namespace WongTung.Web.position
{
    public partial class Modify : System.Web.UI.Page
    {       

        		protected void Page_LoadComplete(object sender, EventArgs e)
		{
			(Master.FindControl("lblTitle") as Label).Text = "信息修改";
		}
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null || Request.Params["id"].Trim() != "")
				{
					string id = Request.Params["id"];
					//ShowInfo(POS_CODE);
				}
			}
		}
			
	private void ShowInfo(string POS_CODE)
	{
		WongTung.BLL.position bll=new WongTung.BLL.position();
		WongTung.Model.position model=bll.GetModel(POS_CODE);
		this.txtPOS_CO_CODE.Text=model.POS_CO_CODE;
		this.lblPOS_CODE.Text=model.POS_CODE;
		this.txtPOS_DESC.Text=model.POS_DESC;
		this.txtPOS_FEE_LEV1.Text=model.POS_FEE_LEV1.ToString();
		this.txtPOS_FEE_LEV2.Text=model.POS_FEE_LEV2.ToString();
		this.txtPOS_FEE_LEV3.Text=model.POS_FEE_LEV3.ToString();
		this.txtPOS_RATE_OUT.Text=model.POS_RATE_OUT.ToString();
		this.txtPOS_RATE_DAILY.Text=model.POS_RATE_DAILY.ToString();
		this.txtPOS_RATE_MON.Text=model.POS_RATE_MON.ToString();
		this.txtPOS_RATE_OT.Text=model.POS_RATE_OT.ToString();
		this.txtPOS_MON_TOTAL.Text=model.POS_MON_TOTAL.ToString();
		this.txtPOS_MON_UTILIST.Text=model.POS_MON_UTILIST.ToString();
		this.txtPOS_MON_REV.Text=model.POS_MON_REV.ToString();
		this.txtPOS_SAL_FROM.Text=model.POS_SAL_FROM.ToString();
		this.txtPOS_SAL_TO.Text=model.POS_SAL_TO.ToString();
		this.txtPOS_DALIY_COST.Text=model.POS_DALIY_COST.ToString();
		this.txtPOS_MON_COST.Text=model.POS_MON_COST.ToString();
		this.txtPOS_CLASS.Text=model.POS_CLASS.ToString();
		this.txtPOS_PLAN.Text=model.POS_PLAN;

	}

		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
	string strErr="";
	if(this.txtPOS_CO_CODE.Text =="")
	{
		strErr+="POS_CO_CODE不能为空！\\n";	
	}
	if(this.txtPOS_DESC.Text =="")
	{
		strErr+="POS_DESC不能为空！\\n";	
	}
	if(!PageValidate.IsDecimal(txtPOS_FEE_LEV1.Text))
	{
		strErr+="POS_FEE_LEV1不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtPOS_FEE_LEV2.Text))
	{
		strErr+="POS_FEE_LEV2不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtPOS_FEE_LEV3.Text))
	{
		strErr+="POS_FEE_LEV3不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtPOS_RATE_OUT.Text))
	{
		strErr+="POS_RATE_OUT不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtPOS_RATE_DAILY.Text))
	{
		strErr+="POS_RATE_DAILY不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtPOS_RATE_MON.Text))
	{
		strErr+="POS_RATE_MON不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtPOS_RATE_OT.Text))
	{
		strErr+="POS_RATE_OT不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtPOS_MON_TOTAL.Text))
	{
		strErr+="POS_MON_TOTAL不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtPOS_MON_UTILIST.Text))
	{
		strErr+="POS_MON_UTILIST不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtPOS_MON_REV.Text))
	{
		strErr+="POS_MON_REV不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtPOS_SAL_FROM.Text))
	{
		strErr+="POS_SAL_FROM不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtPOS_SAL_TO.Text))
	{
		strErr+="POS_SAL_TO不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtPOS_DALIY_COST.Text))
	{
		strErr+="POS_DALIY_COST不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtPOS_MON_COST.Text))
	{
		strErr+="POS_MON_COST不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtPOS_CLASS.Text))
	{
		strErr+="POS_CLASS不是数字！\\n";	
	}
	if(this.txtPOS_PLAN.Text =="")
	{
		strErr+="POS_PLAN不能为空！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	string POS_CO_CODE=this.txtPOS_CO_CODE.Text;
	string POS_DESC=this.txtPOS_DESC.Text;
	decimal POS_FEE_LEV1=decimal.Parse(this.txtPOS_FEE_LEV1.Text);
	decimal POS_FEE_LEV2=decimal.Parse(this.txtPOS_FEE_LEV2.Text);
	decimal POS_FEE_LEV3=decimal.Parse(this.txtPOS_FEE_LEV3.Text);
	decimal POS_RATE_OUT=decimal.Parse(this.txtPOS_RATE_OUT.Text);
	decimal POS_RATE_DAILY=decimal.Parse(this.txtPOS_RATE_DAILY.Text);
	decimal POS_RATE_MON=decimal.Parse(this.txtPOS_RATE_MON.Text);
	decimal POS_RATE_OT=decimal.Parse(this.txtPOS_RATE_OT.Text);
	decimal POS_MON_TOTAL=decimal.Parse(this.txtPOS_MON_TOTAL.Text);
	decimal POS_MON_UTILIST=decimal.Parse(this.txtPOS_MON_UTILIST.Text);
	decimal POS_MON_REV=decimal.Parse(this.txtPOS_MON_REV.Text);
	decimal POS_SAL_FROM=decimal.Parse(this.txtPOS_SAL_FROM.Text);
	decimal POS_SAL_TO=decimal.Parse(this.txtPOS_SAL_TO.Text);
	decimal POS_DALIY_COST=decimal.Parse(this.txtPOS_DALIY_COST.Text);
	decimal POS_MON_COST=decimal.Parse(this.txtPOS_MON_COST.Text);
	decimal POS_CLASS=decimal.Parse(this.txtPOS_CLASS.Text);
	string POS_PLAN=this.txtPOS_PLAN.Text;


	WongTung.Model.position model=new WongTung.Model.position();
	model.POS_CO_CODE=POS_CO_CODE;
	model.POS_DESC=POS_DESC;
	model.POS_FEE_LEV1=POS_FEE_LEV1;
	model.POS_FEE_LEV2=POS_FEE_LEV2;
	model.POS_FEE_LEV3=POS_FEE_LEV3;
	model.POS_RATE_OUT=POS_RATE_OUT;
	model.POS_RATE_DAILY=POS_RATE_DAILY;
	model.POS_RATE_MON=POS_RATE_MON;
	model.POS_RATE_OT=POS_RATE_OT;
	model.POS_MON_TOTAL=POS_MON_TOTAL;
	model.POS_MON_UTILIST=POS_MON_UTILIST;
	model.POS_MON_REV=POS_MON_REV;
	model.POS_SAL_FROM=POS_SAL_FROM;
	model.POS_SAL_TO=POS_SAL_TO;
	model.POS_DALIY_COST=POS_DALIY_COST;
	model.POS_MON_COST=POS_MON_COST;
	model.POS_CLASS=POS_CLASS;
	model.POS_PLAN=POS_PLAN;

	WongTung.BLL.position bll=new WongTung.BLL.position();
	bll.Update(model);

		}

    }
}
