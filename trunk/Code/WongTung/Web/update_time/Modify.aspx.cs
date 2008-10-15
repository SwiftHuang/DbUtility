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
namespace WongTung.Web.update_time
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
					//ShowInfo(UT_CODE);
				}
			}
		}
			
	private void ShowInfo(string UT_CODE)
	{
		WongTung.BLL.update_time bll=new WongTung.BLL.update_time();
		WongTung.Model.update_time model=bll.GetModel(UT_CODE);
		this.lblUT_CODE.Text=model.UT_CODE;
		this.txtUT_DATE.Text=model.UT_DATE.ToString();
		this.txtUT_TIME.Text=model.UT_TIME;
		this.txtUT_FRE.Text=model.UT_FRE.ToString();
		this.txtUT_UPDATE_USER.Text=model.UT_UPDATE_USER;
		this.txtUT_UPDATE_DT.Text=model.UT_UPDATE_DT.ToString();
		this.txtUT_INF.Text=model.UT_INF;

	}

		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
	string strErr="";
	if(!PageValidate.IsDateTime(txtUT_DATE.Text))
	{
		strErr+="UT_DATE不是时间格式！\\n";	
	}
	if(this.txtUT_TIME.Text =="")
	{
		strErr+="UT_TIME不能为空！\\n";	
	}
	if(!PageValidate.IsNumber(txtUT_FRE.Text))
	{
		strErr+="UT_FRE不是数字！\\n";	
	}
	if(this.txtUT_UPDATE_USER.Text =="")
	{
		strErr+="UT_UPDATE_USER不能为空！\\n";	
	}
	if(!PageValidate.IsDateTime(txtUT_UPDATE_DT.Text))
	{
		strErr+="UT_UPDATE_DT不是时间格式！\\n";	
	}
	if(this.txtUT_INF.Text =="")
	{
		strErr+="UT_INF不能为空！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	DateTime UT_DATE=DateTime.Parse(this.txtUT_DATE.Text);
	string UT_TIME=this.txtUT_TIME.Text;
	int UT_FRE=int.Parse(this.txtUT_FRE.Text);
	string UT_UPDATE_USER=this.txtUT_UPDATE_USER.Text;
	DateTime UT_UPDATE_DT=DateTime.Parse(this.txtUT_UPDATE_DT.Text);
	string UT_INF=this.txtUT_INF.Text;


	WongTung.Model.update_time model=new WongTung.Model.update_time();
	model.UT_DATE=UT_DATE;
	model.UT_TIME=UT_TIME;
	model.UT_FRE=UT_FRE;
	model.UT_UPDATE_USER=UT_UPDATE_USER;
	model.UT_UPDATE_DT=UT_UPDATE_DT;
	model.UT_INF=UT_INF;

	WongTung.BLL.update_time bll=new WongTung.BLL.update_time();
	bll.Update(model);

		}

    }
}
