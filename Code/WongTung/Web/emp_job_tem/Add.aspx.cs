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
namespace WongTung.Web.emp_job_tem
{
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        		protected void Page_LoadComplete(object sender, EventArgs e)
		{
			(Master.FindControl("lblTitle") as Label).Text = "信息添加";
		}
		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
	string strErr="";
	if(!PageValidate.IsDateTime(txtEJ_LAST_DATE.Text))
	{
	strErr+="EJ_LAST_DATE不是时间格式！\\n";	
	}
	if(!PageValidate.IsDecimal(txtEJ_LAST_NUM.Text))
	{
		strErr+="EJ_LAST_NUM不是数字！\\n";	
	}
	if(this.txtEJ_JOB_1.Text =="")
	{
		strErr+="EJ_JOB_1不能为空！\\n";	
	}
	if(this.txtEJ_JOB_2.Text =="")
	{
		strErr+="EJ_JOB_2不能为空！\\n";	
	}
	if(this.txtEJ_JOB_3.Text =="")
	{
		strErr+="EJ_JOB_3不能为空！\\n";	
	}
	if(this.txtEJ_JOB_4.Text =="")
	{
		strErr+="EJ_JOB_4不能为空！\\n";	
	}
	if(this.txtEJ_JOB_5.Text =="")
	{
		strErr+="EJ_JOB_5不能为空！\\n";	
	}
	if(this.txtEJ_JOB_6.Text =="")
	{
		strErr+="EJ_JOB_6不能为空！\\n";	
	}
	if(this.txtEJ_JOB_7.Text =="")
	{
		strErr+="EJ_JOB_7不能为空！\\n";	
	}
	if(this.txtEJ_JOB_8.Text =="")
	{
		strErr+="EJ_JOB_8不能为空！\\n";	
	}
	if(this.txtEJ_JOB_9.Text =="")
	{
		strErr+="EJ_JOB_9不能为空！\\n";	
	}
	if(this.txtEJ_JOB_10.Text =="")
	{
		strErr+="EJ_JOB_10不能为空！\\n";	
	}
	if(this.txtEJ_JOB_11.Text =="")
	{
		strErr+="EJ_JOB_11不能为空！\\n";	
	}
	if(this.txtEJ_JOB_12.Text =="")
	{
		strErr+="EJ_JOB_12不能为空！\\n";	
	}
	if(this.txtEJ_JOB_13.Text =="")
	{
		strErr+="EJ_JOB_13不能为空！\\n";	
	}
	if(this.txtEJ_JOB_14.Text =="")
	{
		strErr+="EJ_JOB_14不能为空！\\n";	
	}
	if(this.txtEJ_JOB_15.Text =="")
	{
		strErr+="EJ_JOB_15不能为空！\\n";	
	}
	if(this.txtEJ_JOB_16.Text =="")
	{
		strErr+="EJ_JOB_16不能为空！\\n";	
	}
	if(this.txtEJ_JOB_17.Text =="")
	{
		strErr+="EJ_JOB_17不能为空！\\n";	
	}
	if(this.txtEJ_JOB_18.Text =="")
	{
		strErr+="EJ_JOB_18不能为空！\\n";	
	}
	if(this.txtEJ_JOB_19.Text =="")
	{
		strErr+="EJ_JOB_19不能为空！\\n";	
	}
	if(this.txtEJ_JOB_20.Text =="")
	{
		strErr+="EJ_JOB_20不能为空！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	DateTime EJ_LAST_DATE=DateTime.Parse(this.txtEJ_LAST_DATE.Text);
	decimal EJ_LAST_NUM=decimal.Parse(this.txtEJ_LAST_NUM.Text);
	string EJ_JOB_1=this.txtEJ_JOB_1.Text;
	string EJ_JOB_2=this.txtEJ_JOB_2.Text;
	string EJ_JOB_3=this.txtEJ_JOB_3.Text;
	string EJ_JOB_4=this.txtEJ_JOB_4.Text;
	string EJ_JOB_5=this.txtEJ_JOB_5.Text;
	string EJ_JOB_6=this.txtEJ_JOB_6.Text;
	string EJ_JOB_7=this.txtEJ_JOB_7.Text;
	string EJ_JOB_8=this.txtEJ_JOB_8.Text;
	string EJ_JOB_9=this.txtEJ_JOB_9.Text;
	string EJ_JOB_10=this.txtEJ_JOB_10.Text;
	string EJ_JOB_11=this.txtEJ_JOB_11.Text;
	string EJ_JOB_12=this.txtEJ_JOB_12.Text;
	string EJ_JOB_13=this.txtEJ_JOB_13.Text;
	string EJ_JOB_14=this.txtEJ_JOB_14.Text;
	string EJ_JOB_15=this.txtEJ_JOB_15.Text;
	string EJ_JOB_16=this.txtEJ_JOB_16.Text;
	string EJ_JOB_17=this.txtEJ_JOB_17.Text;
	string EJ_JOB_18=this.txtEJ_JOB_18.Text;
	string EJ_JOB_19=this.txtEJ_JOB_19.Text;
	string EJ_JOB_20=this.txtEJ_JOB_20.Text;

	WongTung.Model.emp_job_tem model=new WongTung.Model.emp_job_tem();
	model.EJ_LAST_DATE=EJ_LAST_DATE;
	model.EJ_LAST_NUM=EJ_LAST_NUM;
	model.EJ_JOB_1=EJ_JOB_1;
	model.EJ_JOB_2=EJ_JOB_2;
	model.EJ_JOB_3=EJ_JOB_3;
	model.EJ_JOB_4=EJ_JOB_4;
	model.EJ_JOB_5=EJ_JOB_5;
	model.EJ_JOB_6=EJ_JOB_6;
	model.EJ_JOB_7=EJ_JOB_7;
	model.EJ_JOB_8=EJ_JOB_8;
	model.EJ_JOB_9=EJ_JOB_9;
	model.EJ_JOB_10=EJ_JOB_10;
	model.EJ_JOB_11=EJ_JOB_11;
	model.EJ_JOB_12=EJ_JOB_12;
	model.EJ_JOB_13=EJ_JOB_13;
	model.EJ_JOB_14=EJ_JOB_14;
	model.EJ_JOB_15=EJ_JOB_15;
	model.EJ_JOB_16=EJ_JOB_16;
	model.EJ_JOB_17=EJ_JOB_17;
	model.EJ_JOB_18=EJ_JOB_18;
	model.EJ_JOB_19=EJ_JOB_19;
	model.EJ_JOB_20=EJ_JOB_20;

	WongTung.BLL.emp_job_tem bll=new WongTung.BLL.emp_job_tem();
	bll.Add(model);

		}

    }
}
