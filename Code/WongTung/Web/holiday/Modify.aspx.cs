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
namespace WongTung.Web.holiday
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
		WongTung.BLL.holiday bll=new WongTung.BLL.holiday();
		WongTung.Model.holiday model=bll.GetModel();
		this.txtHD_CO_CODE.Text=model.HD_CO_CODE;
		this.txtHD_EMP_CODE.Text=model.HD_EMP_CODE;
		this.txtHD_LINE_NO.Text=model.HD_LINE_NO.ToString();
		this.txtHD_DATE.Text=model.HD_DATE.ToString();
		this.txtHD_LEVE_CODE.Text=model.HD_LEVE_CODE;

	}

		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
	string strErr="";
	if(this.txtHD_CO_CODE.Text =="")
	{
		strErr+="HD_CO_CODE不能为空！\\n";	
	}
	if(this.txtHD_EMP_CODE.Text =="")
	{
		strErr+="HD_EMP_CODE不能为空！\\n";	
	}
	if(!PageValidate.IsDecimal(txtHD_LINE_NO.Text))
	{
		strErr+="HD_LINE_NO不是数字！\\n";	
	}
	if(!PageValidate.IsDateTime(txtHD_DATE.Text))
	{
		strErr+="HD_DATE不是时间格式！\\n";	
	}
	if(this.txtHD_LEVE_CODE.Text =="")
	{
		strErr+="HD_LEVE_CODE不能为空！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	string HD_CO_CODE=this.txtHD_CO_CODE.Text;
	string HD_EMP_CODE=this.txtHD_EMP_CODE.Text;
	decimal HD_LINE_NO=decimal.Parse(this.txtHD_LINE_NO.Text);
	DateTime HD_DATE=DateTime.Parse(this.txtHD_DATE.Text);
	string HD_LEVE_CODE=this.txtHD_LEVE_CODE.Text;


	WongTung.Model.holiday model=new WongTung.Model.holiday();
	model.HD_CO_CODE=HD_CO_CODE;
	model.HD_EMP_CODE=HD_EMP_CODE;
	model.HD_LINE_NO=HD_LINE_NO;
	model.HD_DATE=HD_DATE;
	model.HD_LEVE_CODE=HD_LEVE_CODE;

	WongTung.BLL.holiday bll=new WongTung.BLL.holiday();
	bll.Update(model);

		}

    }
}
