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
namespace WongTung.Web.prriod
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
		WongTung.BLL.prriod bll=new WongTung.BLL.prriod();
		WongTung.Model.prriod model=bll.GetModel();
		this.txtPR_CO_CODE.Text=model.PR_CO_CODE;
		this.txtPR_NO.Text=model.PR_NO.ToString();
		this.txtPR_FROM.Text=model.PR_FROM;
		this.txtPR_TO.Text=model.PR_TO;

	}

		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
	string strErr="";
	if(this.txtPR_CO_CODE.Text =="")
	{
		strErr+="PR_CO_CODE不能为空！\\n";	
	}
	if(!PageValidate.IsDecimal(txtPR_NO.Text))
	{
		strErr+="PR_NO不是数字！\\n";	
	}
	if(this.txtPR_FROM.Text =="")
	{
		strErr+="PR_FROM不能为空！\\n";	
	}
	if(this.txtPR_TO.Text =="")
	{
		strErr+="PR_TO不能为空！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	string PR_CO_CODE=this.txtPR_CO_CODE.Text;
	decimal PR_NO=decimal.Parse(this.txtPR_NO.Text);
	string PR_FROM=this.txtPR_FROM.Text;
	string PR_TO=this.txtPR_TO.Text;


	WongTung.Model.prriod model=new WongTung.Model.prriod();
	model.PR_CO_CODE=PR_CO_CODE;
	model.PR_NO=PR_NO;
	model.PR_FROM=PR_FROM;
	model.PR_TO=PR_TO;

	WongTung.BLL.prriod bll=new WongTung.BLL.prriod();
	bll.Update(model);

		}

    }
}
