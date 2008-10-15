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
namespace WongTung.Web.workstage
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
					//ShowInfo(WT_CODE);
				}
			}
		}
			
	private void ShowInfo(string WT_CODE)
	{
		WongTung.BLL.workstage bll=new WongTung.BLL.workstage();
		WongTung.Model.workstage model=bll.GetModel(WT_CODE);
		this.txtWT_CO_CODE.Text=model.WT_CO_CODE;
		this.lblWT_CODE.Text=model.WT_CODE;
		this.txtWT_DESC.Text=model.WT_DESC;
		this.txtWT_DESC_T.Text=model.WT_DESC_T;
		this.txtWT_DESC_S.Text=model.WT_DESC_S;

	}

		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
	string strErr="";
	if(this.txtWT_CO_CODE.Text =="")
	{
		strErr+="WT_CO_CODE不能为空！\\n";	
	}
	if(this.txtWT_DESC.Text =="")
	{
		strErr+="WT_DESC不能为空！\\n";	
	}
	if(this.txtWT_DESC_T.Text =="")
	{
		strErr+="WT_DESC_T不能为空！\\n";	
	}
	if(this.txtWT_DESC_S.Text =="")
	{
		strErr+="WT_DESC_S不能为空！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	string WT_CO_CODE=this.txtWT_CO_CODE.Text;
	string WT_DESC=this.txtWT_DESC.Text;
	string WT_DESC_T=this.txtWT_DESC_T.Text;
	string WT_DESC_S=this.txtWT_DESC_S.Text;


	WongTung.Model.workstage model=new WongTung.Model.workstage();
	model.WT_CO_CODE=WT_CO_CODE;
	model.WT_DESC=WT_DESC;
	model.WT_DESC_T=WT_DESC_T;
	model.WT_DESC_S=WT_DESC_S;

	WongTung.BLL.workstage bll=new WongTung.BLL.workstage();
	bll.Update(model);

		}

    }
}
