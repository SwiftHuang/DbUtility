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
namespace WongTung.Web.changepw
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
					//ShowInfo(CP_USER_CODE);
				}
			}
		}
			
	private void ShowInfo(string CP_USER_CODE)
	{
		WongTung.BLL.changepw bll=new WongTung.BLL.changepw();
		WongTung.Model.changepw model=bll.GetModel(CP_USER_CODE);
		this.txtCP_CO_CODE.Text=model.CP_CO_CODE;
		this.lblCP_USER_CODE.Text=model.CP_USER_CODE;
		this.txtCP_NEW_PWD.Text=model.CP_NEW_PWD;

	}

		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
	string strErr="";
	if(this.txtCP_CO_CODE.Text =="")
	{
		strErr+="CP_CO_CODE不能为空！\\n";	
	}
	if(this.txtCP_NEW_PWD.Text =="")
	{
		strErr+="CP_NEW_PWD不能为空！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	string CP_CO_CODE=this.txtCP_CO_CODE.Text;
	string CP_NEW_PWD=this.txtCP_NEW_PWD.Text;


	WongTung.Model.changepw model=new WongTung.Model.changepw();
	model.CP_CO_CODE=CP_CO_CODE;
	model.CP_NEW_PWD=CP_NEW_PWD;

	WongTung.BLL.changepw bll=new WongTung.BLL.changepw();
	bll.Update(model);

		}

    }
}
