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
namespace WongTung.Web.leave_bak
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
					ShowInfo();
				}
			}
		}
			
	private void ShowInfo()
	{
		WongTung.BLL.leave_bak bll=new WongTung.BLL.leave_bak();
		WongTung.Model.leave_bak model=bll.GetModel();
		this.txtCO_CODE.Text=model.CO_CODE;
		this.txtLEVAE_CODE.Text=model.LEVAE_CODE;
		this.txtLEVAE_DESC.Text=model.LEVAE_DESC;

	}

		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
	string strErr="";
	if(this.txtCO_CODE.Text =="")
	{
		strErr+="CO_CODE不能为空！\\n";	
	}
	if(this.txtLEVAE_CODE.Text =="")
	{
		strErr+="LEVAE_CODE不能为空！\\n";	
	}
	if(this.txtLEVAE_DESC.Text =="")
	{
		strErr+="LEVAE_DESC不能为空！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	string CO_CODE=this.txtCO_CODE.Text;
	string LEVAE_CODE=this.txtLEVAE_CODE.Text;
	string LEVAE_DESC=this.txtLEVAE_DESC.Text;


	WongTung.Model.leave_bak model=new WongTung.Model.leave_bak();
	model.CO_CODE=CO_CODE;
	model.LEVAE_CODE=LEVAE_CODE;
	model.LEVAE_DESC=LEVAE_DESC;

	WongTung.BLL.leave_bak bll=new WongTung.BLL.leave_bak();
	bll.Update(model);

		}

    }
}
