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
namespace WongTung.Web.worknatrue
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
					//ShowInfo(WN_CODE);
				}
			}
		}
			
	private void ShowInfo(string WN_CODE)
	{
		WongTung.BLL.worknatrue bll=new WongTung.BLL.worknatrue();
		WongTung.Model.worknatrue model=bll.GetModel(WN_CODE);
		this.txtWN_CO_CODE.Text=model.WN_CO_CODE;
		this.lblWN_CODE.Text=model.WN_CODE;
		this.txtWN_DESC.Text=model.WN_DESC;
		this.txtWN_DESC_T.Text=model.WN_DESC_T;
		this.txtWN_DESC_S.Text=model.WN_DESC_S;

	}

		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
	string strErr="";
	if(this.txtWN_CO_CODE.Text =="")
	{
		strErr+="WN_CO_CODE不能为空！\\n";	
	}
	if(this.txtWN_DESC.Text =="")
	{
		strErr+="WN_DESC不能为空！\\n";	
	}
	if(this.txtWN_DESC_T.Text =="")
	{
		strErr+="WN_DESC_T不能为空！\\n";	
	}
	if(this.txtWN_DESC_S.Text =="")
	{
		strErr+="WN_DESC_S不能为空！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	string WN_CO_CODE=this.txtWN_CO_CODE.Text;
	string WN_DESC=this.txtWN_DESC.Text;
	string WN_DESC_T=this.txtWN_DESC_T.Text;
	string WN_DESC_S=this.txtWN_DESC_S.Text;


	WongTung.Model.worknatrue model=new WongTung.Model.worknatrue();
	model.WN_CO_CODE=WN_CO_CODE;
	model.WN_DESC=WN_DESC;
	model.WN_DESC_T=WN_DESC_T;
	model.WN_DESC_S=WN_DESC_S;

	WongTung.BLL.worknatrue bll=new WongTung.BLL.worknatrue();
	bll.Update(model);

		}

    }
}
