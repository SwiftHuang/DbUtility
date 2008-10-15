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
namespace WongTung.Web.userinf
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
					//ShowInfo(USER_CODE);
				}
			}
		}
			
	private void ShowInfo(string USER_CODE)
	{
		WongTung.BLL.userinf bll=new WongTung.BLL.userinf();
		WongTung.Model.userinf model=bll.GetModel(USER_CODE);
		this.txtUSER_CO_CODE.Text=model.USER_CO_CODE;
		this.lblUSER_CODE.Text=model.USER_CODE;
		this.txtUSER_NAME.Text=model.USER_NAME;
		this.txtUSER_EMP_CODE.Text=model.USER_EMP_CODE;
		this.txtUSER_RAND.Text=model.USER_RAND;
		this.txtUSER_CURDATE.Text=model.USER_CURDATE.ToString();
		this.txtUSER_RAND_BACK.Text=model.USER_RAND_BACK;
		this.txtUSER_ACTIVATE.Text=model.USER_ACTIVATE;
		this.txtUSER_CHNAME.Text=model.USER_CHNAME;

	}

		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
	string strErr="";
	if(this.txtUSER_CO_CODE.Text =="")
	{
		strErr+="USER_CO_CODE不能为空！\\n";	
	}
	if(this.txtUSER_NAME.Text =="")
	{
		strErr+="USER_NAME不能为空！\\n";	
	}
	if(this.txtUSER_EMP_CODE.Text =="")
	{
		strErr+="USER_EMP_CODE不能为空！\\n";	
	}
	if(this.txtUSER_RAND.Text =="")
	{
		strErr+="USER_RAND不能为空！\\n";	
	}
	if(!PageValidate.IsDateTime(txtUSER_CURDATE.Text))
	{
		strErr+="USER_CURDATE不是时间格式！\\n";	
	}
	if(this.txtUSER_RAND_BACK.Text =="")
	{
		strErr+="USER_RAND_BACK不能为空！\\n";	
	}
	if(this.txtUSER_ACTIVATE.Text =="")
	{
		strErr+="USER_ACTIVATE不能为空！\\n";	
	}
	if(this.txtUSER_CHNAME.Text =="")
	{
		strErr+="USER_CHNAME不能为空！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	string USER_CO_CODE=this.txtUSER_CO_CODE.Text;
	string USER_NAME=this.txtUSER_NAME.Text;
	string USER_EMP_CODE=this.txtUSER_EMP_CODE.Text;
	string USER_RAND=this.txtUSER_RAND.Text;
	DateTime USER_CURDATE=DateTime.Parse(this.txtUSER_CURDATE.Text);
	string USER_RAND_BACK=this.txtUSER_RAND_BACK.Text;
	string USER_ACTIVATE=this.txtUSER_ACTIVATE.Text;
	string USER_CHNAME=this.txtUSER_CHNAME.Text;


	WongTung.Model.userinf model=new WongTung.Model.userinf();
	model.USER_CO_CODE=USER_CO_CODE;
	model.USER_NAME=USER_NAME;
	model.USER_EMP_CODE=USER_EMP_CODE;
	model.USER_RAND=USER_RAND;
	model.USER_CURDATE=USER_CURDATE;
	model.USER_RAND_BACK=USER_RAND_BACK;
	model.USER_ACTIVATE=USER_ACTIVATE;
	model.USER_CHNAME=USER_CHNAME;

	WongTung.BLL.userinf bll=new WongTung.BLL.userinf();
	bll.Update(model);

		}

    }
}
