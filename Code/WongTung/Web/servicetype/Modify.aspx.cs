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
namespace WongTung.Web.servicetype
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
		WongTung.BLL.servicetype bll=new WongTung.BLL.servicetype();
		WongTung.Model.servicetype model=bll.GetModel();
		this.txtST_CO_CODE.Text=model.ST_CO_CODE;
		this.txtST_JOB_CODE.Text=model.ST_JOB_CODE;
		this.txtST_SER_CODE.Text=model.ST_SER_CODE;
		this.txtST_DESC.Text=model.ST_DESC;
		this.txtST_DESC1.Text=model.ST_DESC1;
		this.txtST_DESC_T1.Text=model.ST_DESC_T1;
		this.txtST_DESC_S1.Text=model.ST_DESC_S1;
		this.txtST_DESC_T2.Text=model.ST_DESC_T2;
		this.txtST_DESC_S2.Text=model.ST_DESC_S2;

	}

		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
	string strErr="";
	if(this.txtST_CO_CODE.Text =="")
	{
		strErr+="ST_CO_CODE不能为空！\\n";	
	}
	if(this.txtST_JOB_CODE.Text =="")
	{
		strErr+="ST_JOB_CODE不能为空！\\n";	
	}
	if(this.txtST_SER_CODE.Text =="")
	{
		strErr+="ST_SER_CODE不能为空！\\n";	
	}
	if(this.txtST_DESC.Text =="")
	{
		strErr+="ST_DESC不能为空！\\n";	
	}
	if(this.txtST_DESC1.Text =="")
	{
		strErr+="ST_DESC1不能为空！\\n";	
	}
	if(this.txtST_DESC_T1.Text =="")
	{
		strErr+="ST_DESC_T1不能为空！\\n";	
	}
	if(this.txtST_DESC_S1.Text =="")
	{
		strErr+="ST_DESC_S1不能为空！\\n";	
	}
	if(this.txtST_DESC_T2.Text =="")
	{
		strErr+="ST_DESC_T2不能为空！\\n";	
	}
	if(this.txtST_DESC_S2.Text =="")
	{
		strErr+="ST_DESC_S2不能为空！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	string ST_CO_CODE=this.txtST_CO_CODE.Text;
	string ST_JOB_CODE=this.txtST_JOB_CODE.Text;
	string ST_SER_CODE=this.txtST_SER_CODE.Text;
	string ST_DESC=this.txtST_DESC.Text;
	string ST_DESC1=this.txtST_DESC1.Text;
	string ST_DESC_T1=this.txtST_DESC_T1.Text;
	string ST_DESC_S1=this.txtST_DESC_S1.Text;
	string ST_DESC_T2=this.txtST_DESC_T2.Text;
	string ST_DESC_S2=this.txtST_DESC_S2.Text;


	WongTung.Model.servicetype model=new WongTung.Model.servicetype();
	model.ST_CO_CODE=ST_CO_CODE;
	model.ST_JOB_CODE=ST_JOB_CODE;
	model.ST_SER_CODE=ST_SER_CODE;
	model.ST_DESC=ST_DESC;
	model.ST_DESC1=ST_DESC1;
	model.ST_DESC_T1=ST_DESC_T1;
	model.ST_DESC_S1=ST_DESC_S1;
	model.ST_DESC_T2=ST_DESC_T2;
	model.ST_DESC_S2=ST_DESC_S2;

	WongTung.BLL.servicetype bll=new WongTung.BLL.servicetype();
	bll.Update(model);

		}

    }
}
