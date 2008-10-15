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
namespace WongTung.Web.icpinq
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
		WongTung.BLL.icpinq bll=new WongTung.BLL.icpinq();
		WongTung.Model.icpinq model=bll.GetModel();
		this.txtICP_CO_CODE.Text=model.ICP_CO_CODE;
		this.txtICP_OFFICE_CODE.Text=model.ICP_OFFICE_CODE;
		this.txtICP_OFFICE_NAME.Text=model.ICP_OFFICE_NAME;
		this.txtICP_EMP_CODE.Text=model.ICP_EMP_CODE;
		this.txtICP_EMP_NAME.Text=model.ICP_EMP_NAME;

	}

		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
	string strErr="";
	if(this.txtICP_CO_CODE.Text =="")
	{
		strErr+="ICP_CO_CODE不能为空！\\n";	
	}
	if(this.txtICP_OFFICE_CODE.Text =="")
	{
		strErr+="ICP_OFFICE_CODE不能为空！\\n";	
	}
	if(this.txtICP_OFFICE_NAME.Text =="")
	{
		strErr+="ICP_OFFICE_NAME不能为空！\\n";	
	}
	if(this.txtICP_EMP_CODE.Text =="")
	{
		strErr+="ICP_EMP_CODE不能为空！\\n";	
	}
	if(this.txtICP_EMP_NAME.Text =="")
	{
		strErr+="ICP_EMP_NAME不能为空！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	string ICP_CO_CODE=this.txtICP_CO_CODE.Text;
	string ICP_OFFICE_CODE=this.txtICP_OFFICE_CODE.Text;
	string ICP_OFFICE_NAME=this.txtICP_OFFICE_NAME.Text;
	string ICP_EMP_CODE=this.txtICP_EMP_CODE.Text;
	string ICP_EMP_NAME=this.txtICP_EMP_NAME.Text;


	WongTung.Model.icpinq model=new WongTung.Model.icpinq();
	model.ICP_CO_CODE=ICP_CO_CODE;
	model.ICP_OFFICE_CODE=ICP_OFFICE_CODE;
	model.ICP_OFFICE_NAME=ICP_OFFICE_NAME;
	model.ICP_EMP_CODE=ICP_EMP_CODE;
	model.ICP_EMP_NAME=ICP_EMP_NAME;

	WongTung.BLL.icpinq bll=new WongTung.BLL.icpinq();
	bll.Update(model);

		}

    }
}
