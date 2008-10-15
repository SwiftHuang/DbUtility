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
namespace WongTung.Web.plan_pos
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
					//ShowInfo(PLA_POS_CO,PLA_POS_OFF,PLA_POS_CODE);
				}
			}
		}
			
	private void ShowInfo(string PLA_POS_CO,string PLA_POS_OFF,string PLA_POS_CODE)
	{
		WongTung.BLL.plan_pos bll=new WongTung.BLL.plan_pos();
		WongTung.Model.plan_pos model=bll.GetModel(PLA_POS_CO,PLA_POS_OFF,PLA_POS_CODE);
		this.lblPLA_POS_CO.Text=model.PLA_POS_CO;
		this.lblPLA_POS_OFF.Text=model.PLA_POS_OFF;
		this.lblPLA_POS_CODE.Text=model.PLA_POS_CODE;
		this.txtPLA_POS_NUM.Text=model.PLA_POS_NUM.ToString();
		this.txtPLA_POS_NOR.Text=model.PLA_POS_NOR.ToString();
		this.txtPLA_POS_OT1.Text=model.PLA_POS_OT1.ToString();
		this.txtPLA_POS_OT2.Text=model.PLA_POS_OT2.ToString();
		this.txtPLA_POS_OT3.Text=model.PLA_POS_OT3.ToString();
		this.txtPLA_POS_T1.Text=model.PLA_POS_T1.ToString();
		this.txtPLA_POS_T2.Text=model.PLA_POS_T2.ToString();
		this.txtPLA_POS_T3.Text=model.PLA_POS_T3.ToString();

	}

		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
	string strErr="";
	if(!PageValidate.IsNumber(txtPLA_POS_NUM.Text))
	{
		strErr+="PLA_POS_NUM不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtPLA_POS_NOR.Text))
	{
		strErr+="PLA_POS_NOR不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtPLA_POS_OT1.Text))
	{
		strErr+="PLA_POS_OT1不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtPLA_POS_OT2.Text))
	{
		strErr+="PLA_POS_OT2不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtPLA_POS_OT3.Text))
	{
		strErr+="PLA_POS_OT3不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtPLA_POS_T1.Text))
	{
		strErr+="PLA_POS_T1不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtPLA_POS_T2.Text))
	{
		strErr+="PLA_POS_T2不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtPLA_POS_T3.Text))
	{
		strErr+="PLA_POS_T3不是数字！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	int PLA_POS_NUM=int.Parse(this.txtPLA_POS_NUM.Text);
	decimal PLA_POS_NOR=decimal.Parse(this.txtPLA_POS_NOR.Text);
	decimal PLA_POS_OT1=decimal.Parse(this.txtPLA_POS_OT1.Text);
	decimal PLA_POS_OT2=decimal.Parse(this.txtPLA_POS_OT2.Text);
	decimal PLA_POS_OT3=decimal.Parse(this.txtPLA_POS_OT3.Text);
	decimal PLA_POS_T1=decimal.Parse(this.txtPLA_POS_T1.Text);
	decimal PLA_POS_T2=decimal.Parse(this.txtPLA_POS_T2.Text);
	decimal PLA_POS_T3=decimal.Parse(this.txtPLA_POS_T3.Text);


	WongTung.Model.plan_pos model=new WongTung.Model.plan_pos();
	model.PLA_POS_NUM=PLA_POS_NUM;
	model.PLA_POS_NOR=PLA_POS_NOR;
	model.PLA_POS_OT1=PLA_POS_OT1;
	model.PLA_POS_OT2=PLA_POS_OT2;
	model.PLA_POS_OT3=PLA_POS_OT3;
	model.PLA_POS_T1=PLA_POS_T1;
	model.PLA_POS_T2=PLA_POS_T2;
	model.PLA_POS_T3=PLA_POS_T3;

	WongTung.BLL.plan_pos bll=new WongTung.BLL.plan_pos();
	bll.Update(model);

		}

    }
}
