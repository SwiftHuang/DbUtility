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
namespace WongTung.Web.department
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
					//ShowInfo(DEPT_CODE);
				}
			}
		}
			
	private void ShowInfo(string DEPT_CODE)
	{
		WongTung.BLL.department bll=new WongTung.BLL.department();
		WongTung.Model.department model=bll.GetModel(DEPT_CODE);
		this.txtDEPT_CO_CODE.Text=model.DEPT_CO_CODE;
		this.lblDEPT_CODE.Text=model.DEPT_CODE;
		this.txtDEPT_NAME.Text=model.DEPT_NAME;

	}

		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
	string strErr="";
	if(this.txtDEPT_CO_CODE.Text =="")
	{
		strErr+="DEPT_CO_CODE不能为空！\\n";	
	}
	if(this.txtDEPT_NAME.Text =="")
	{
		strErr+="DEPT_NAME不能为空！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	string DEPT_CO_CODE=this.txtDEPT_CO_CODE.Text;
	string DEPT_NAME=this.txtDEPT_NAME.Text;


	WongTung.Model.department model=new WongTung.Model.department();
	model.DEPT_CO_CODE=DEPT_CO_CODE;
	model.DEPT_NAME=DEPT_NAME;

	WongTung.BLL.department bll=new WongTung.BLL.department();
	bll.Update(model);

		}

    }
}
