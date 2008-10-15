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
namespace WongTung.Web.bk_jobbud
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
					//ShowInfo(JOB_CO_CODE,JOB_CODE,JOB_SER,JOB_STAFF);
				}
			}
		}
			
	private void ShowInfo(string JOB_CO_CODE,string JOB_CODE,string JOB_SER,string JOB_STAFF)
	{
		WongTung.BLL.bk_jobbud bll=new WongTung.BLL.bk_jobbud();
		WongTung.Model.bk_jobbud model=bll.GetModel(JOB_CO_CODE,JOB_CODE,JOB_SER,JOB_STAFF);
		this.lblJOB_CO_CODE.Text=model.JOB_CO_CODE;
		this.lblJOB_CODE.Text=model.JOB_CODE;
		this.lblJOB_SER.Text=model.JOB_SER;
		this.txtJOB_POS.Text=model.JOB_POS;
		this.lblJOB_STAFF.Text=model.JOB_STAFF;
		this.txtJOB_BUD.Text=model.JOB_BUD.ToString();
		this.txtJOB_NOR.Text=model.JOB_NOR.ToString();
		this.txtJOB_NOR_EXP.Text=model.JOB_NOR_EXP.ToString();
		this.txtJOB_OT.Text=model.JOB_OT.ToString();
		this.txtJOB_OT_EXP.Text=model.JOB_OT_EXP.ToString();

	}

		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
	string strErr="";
	if(this.txtJOB_POS.Text =="")
	{
		strErr+="JOB_POS不能为空！\\n";	
	}
	if(!PageValidate.IsDecimal(txtJOB_BUD.Text))
	{
		strErr+="JOB_BUD不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtJOB_NOR.Text))
	{
		strErr+="JOB_NOR不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtJOB_NOR_EXP.Text))
	{
		strErr+="JOB_NOR_EXP不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtJOB_OT.Text))
	{
		strErr+="JOB_OT不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtJOB_OT_EXP.Text))
	{
		strErr+="JOB_OT_EXP不是数字！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	string JOB_POS=this.txtJOB_POS.Text;
	decimal JOB_BUD=decimal.Parse(this.txtJOB_BUD.Text);
	decimal JOB_NOR=decimal.Parse(this.txtJOB_NOR.Text);
	decimal JOB_NOR_EXP=decimal.Parse(this.txtJOB_NOR_EXP.Text);
	decimal JOB_OT=decimal.Parse(this.txtJOB_OT.Text);
	decimal JOB_OT_EXP=decimal.Parse(this.txtJOB_OT_EXP.Text);


	WongTung.Model.bk_jobbud model=new WongTung.Model.bk_jobbud();
	model.JOB_POS=JOB_POS;
	model.JOB_BUD=JOB_BUD;
	model.JOB_NOR=JOB_NOR;
	model.JOB_NOR_EXP=JOB_NOR_EXP;
	model.JOB_OT=JOB_OT;
	model.JOB_OT_EXP=JOB_OT_EXP;

	WongTung.BLL.bk_jobbud bll=new WongTung.BLL.bk_jobbud();
	bll.Update(model);

		}

    }
}
