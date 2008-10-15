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
namespace WongTung.Web.dailyts
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
		WongTung.BLL.dailyts bll=new WongTung.BLL.dailyts();
		WongTung.Model.dailyts model=bll.GetModel();
		this.txtDT_CO_CODE.Text=model.DT_CO_CODE;
		this.txtDT_STAFF_CODE.Text=model.DT_STAFF_CODE;
		this.txtDT_WORK_DATE.Text=model.DT_WORK_DATE.ToString();
		this.txtDT_LINE_NO.Text=model.DT_LINE_NO.ToString();
		this.txtDT_APP_CODE.Text=model.DT_APP_CODE;
		this.txtDT_JOB_CODE.Text=model.DT_JOB_CODE;
		this.txtDT_SER_CODE.Text=model.DT_SER_CODE;
		this.txtDT_NOR_HOUR.Text=model.DT_NOR_HOUR.ToString();
		this.txtDT_OVER_HOUR.Text=model.DT_OVER_HOUR.ToString();
		this.txtDT_TYPE.Text=model.DT_TYPE;
		this.txtDT_PERIOD.Text=model.DT_PERIOD;
		this.txtDT_SUBMIT.Text=model.DT_SUBMIT;
		this.txtDT_UPDATE.Text=model.DT_UPDATE;
		this.txtDT_RAMNO.Text=model.DT_RAMNO;
		this.txtDT_UPDATE_DATE.Text=model.DT_UPDATE_DATE.ToString();

	}

		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
	string strErr="";
	if(this.txtDT_CO_CODE.Text =="")
	{
		strErr+="DT_CO_CODE不能为空！\\n";	
	}
	if(this.txtDT_STAFF_CODE.Text =="")
	{
		strErr+="DT_STAFF_CODE不能为空！\\n";	
	}
	if(!PageValidate.IsDateTime(txtDT_WORK_DATE.Text))
	{
		strErr+="DT_WORK_DATE不是时间格式！\\n";	
	}
	if(!PageValidate.IsDecimal(txtDT_LINE_NO.Text))
	{
		strErr+="DT_LINE_NO不是数字！\\n";	
	}
	if(this.txtDT_APP_CODE.Text =="")
	{
		strErr+="DT_APP_CODE不能为空！\\n";	
	}
	if(this.txtDT_JOB_CODE.Text =="")
	{
		strErr+="DT_JOB_CODE不能为空！\\n";	
	}
	if(this.txtDT_SER_CODE.Text =="")
	{
		strErr+="DT_SER_CODE不能为空！\\n";	
	}
	if(!PageValidate.IsDecimal(txtDT_NOR_HOUR.Text))
	{
		strErr+="DT_NOR_HOUR不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtDT_OVER_HOUR.Text))
	{
		strErr+="DT_OVER_HOUR不是数字！\\n";	
	}
	if(this.txtDT_TYPE.Text =="")
	{
		strErr+="DT_TYPE不能为空！\\n";	
	}
	if(this.txtDT_PERIOD.Text =="")
	{
		strErr+="DT_PERIOD不能为空！\\n";	
	}
	if(this.txtDT_SUBMIT.Text =="")
	{
		strErr+="DT_SUBMIT不能为空！\\n";	
	}
	if(this.txtDT_UPDATE.Text =="")
	{
		strErr+="DT_UPDATE不能为空！\\n";	
	}
	if(this.txtDT_RAMNO.Text =="")
	{
		strErr+="DT_RAMNO不能为空！\\n";	
	}
	if(!PageValidate.IsDateTime(txtDT_UPDATE_DATE.Text))
	{
		strErr+="DT_UPDATE_DATE不是时间格式！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	string DT_CO_CODE=this.txtDT_CO_CODE.Text;
	string DT_STAFF_CODE=this.txtDT_STAFF_CODE.Text;
	DateTime DT_WORK_DATE=DateTime.Parse(this.txtDT_WORK_DATE.Text);
	decimal DT_LINE_NO=decimal.Parse(this.txtDT_LINE_NO.Text);
	string DT_APP_CODE=this.txtDT_APP_CODE.Text;
	string DT_JOB_CODE=this.txtDT_JOB_CODE.Text;
	string DT_SER_CODE=this.txtDT_SER_CODE.Text;
	decimal DT_NOR_HOUR=decimal.Parse(this.txtDT_NOR_HOUR.Text);
	decimal DT_OVER_HOUR=decimal.Parse(this.txtDT_OVER_HOUR.Text);
	string DT_TYPE=this.txtDT_TYPE.Text;
	string DT_PERIOD=this.txtDT_PERIOD.Text;
	string DT_SUBMIT=this.txtDT_SUBMIT.Text;
	string DT_UPDATE=this.txtDT_UPDATE.Text;
	string DT_RAMNO=this.txtDT_RAMNO.Text;
	DateTime DT_UPDATE_DATE=DateTime.Parse(this.txtDT_UPDATE_DATE.Text);


	WongTung.Model.dailyts model=new WongTung.Model.dailyts();
	model.DT_CO_CODE=DT_CO_CODE;
	model.DT_STAFF_CODE=DT_STAFF_CODE;
	model.DT_WORK_DATE=DT_WORK_DATE;
	model.DT_LINE_NO=DT_LINE_NO;
	model.DT_APP_CODE=DT_APP_CODE;
	model.DT_JOB_CODE=DT_JOB_CODE;
	model.DT_SER_CODE=DT_SER_CODE;
	model.DT_NOR_HOUR=DT_NOR_HOUR;
	model.DT_OVER_HOUR=DT_OVER_HOUR;
	model.DT_TYPE=DT_TYPE;
	model.DT_PERIOD=DT_PERIOD;
	model.DT_SUBMIT=DT_SUBMIT;
	model.DT_UPDATE=DT_UPDATE;
	model.DT_RAMNO=DT_RAMNO;
	model.DT_UPDATE_DATE=DT_UPDATE_DATE;

	WongTung.BLL.dailyts bll=new WongTung.BLL.dailyts();
	bll.Update(model);

		}

    }
}
