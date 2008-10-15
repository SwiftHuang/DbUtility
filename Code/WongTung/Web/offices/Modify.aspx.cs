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
namespace WongTung.Web.offices
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
					//ShowInfo(OFF_CODE);
				}
			}
		}
			
	private void ShowInfo(string OFF_CODE)
	{
		WongTung.BLL.offices bll=new WongTung.BLL.offices();
		WongTung.Model.offices model=bll.GetModel(OFF_CODE);
		this.txtOFF_CO_CODE.Text=model.OFF_CO_CODE;
		this.lblOFF_CODE.Text=model.OFF_CODE;
		this.txtOFF_NAME.Text=model.OFF_NAME;
		this.txtOFF_ENDORSE.Text=model.OFF_ENDORSE;

	}

		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
	string strErr="";
	if(this.txtOFF_CO_CODE.Text =="")
	{
		strErr+="OFF_CO_CODE不能为空！\\n";	
	}
	if(this.txtOFF_NAME.Text =="")
	{
		strErr+="OFF_NAME不能为空！\\n";	
	}
	if(this.txtOFF_ENDORSE.Text =="")
	{
		strErr+="OFF_ENDORSE不能为空！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	string OFF_CO_CODE=this.txtOFF_CO_CODE.Text;
	string OFF_NAME=this.txtOFF_NAME.Text;
	string OFF_ENDORSE=this.txtOFF_ENDORSE.Text;


	WongTung.Model.offices model=new WongTung.Model.offices();
	model.OFF_CO_CODE=OFF_CO_CODE;
	model.OFF_NAME=OFF_NAME;
	model.OFF_ENDORSE=OFF_ENDORSE;

	WongTung.BLL.offices bll=new WongTung.BLL.offices();
	bll.Update(model);

		}

    }
}
