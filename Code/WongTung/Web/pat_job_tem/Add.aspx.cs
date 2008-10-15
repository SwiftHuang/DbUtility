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
namespace WongTung.Web.pat_job_tem
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
	if(!PageValidate.IsDateTime(txtAJ_LAST_DATE.Text))
	{
	strErr+="AJ_LAST_DATE不是时间格式！\\n";	
	}
	if(!PageValidate.IsDecimal(txtAJ_LAST_NUM.Text))
	{
		strErr+="AJ_LAST_NUM不是数字！\\n";	
	}
	if(this.txtAJ_JOB_1.Text =="")
	{
		strErr+="AJ_JOB_1不能为空！\\n";	
	}
	if(this.txtAJ_JOB_2.Text =="")
	{
		strErr+="AJ_JOB_2不能为空！\\n";	
	}
	if(this.txtAJ_JOB_3.Text =="")
	{
		strErr+="AJ_JOB_3不能为空！\\n";	
	}
	if(this.txtAJ_JOB_4.Text =="")
	{
		strErr+="AJ_JOB_4不能为空！\\n";	
	}
	if(this.txtAJ_JOB_5.Text =="")
	{
		strErr+="AJ_JOB_5不能为空！\\n";	
	}
	if(this.txtAJ_JOB_6.Text =="")
	{
		strErr+="AJ_JOB_6不能为空！\\n";	
	}
	if(this.txtAJ_JOB_7.Text =="")
	{
		strErr+="AJ_JOB_7不能为空！\\n";	
	}
	if(this.txtAJ_JOB_8.Text =="")
	{
		strErr+="AJ_JOB_8不能为空！\\n";	
	}
	if(this.txtAJ_JOB_9.Text =="")
	{
		strErr+="AJ_JOB_9不能为空！\\n";	
	}
	if(this.txtAJ_JOB_10.Text =="")
	{
		strErr+="AJ_JOB_10不能为空！\\n";	
	}
	if(this.txtAJ_JOB_11.Text =="")
	{
		strErr+="AJ_JOB_11不能为空！\\n";	
	}
	if(this.txtAJ_JOB_12.Text =="")
	{
		strErr+="AJ_JOB_12不能为空！\\n";	
	}
	if(this.txtAJ_JOB_13.Text =="")
	{
		strErr+="AJ_JOB_13不能为空！\\n";	
	}
	if(this.txtAJ_JOB_14.Text =="")
	{
		strErr+="AJ_JOB_14不能为空！\\n";	
	}
	if(this.txtAJ_JOB_15.Text =="")
	{
		strErr+="AJ_JOB_15不能为空！\\n";	
	}
	if(this.txtAJ_JOB_16.Text =="")
	{
		strErr+="AJ_JOB_16不能为空！\\n";	
	}
	if(this.txtAJ_JOB_17.Text =="")
	{
		strErr+="AJ_JOB_17不能为空！\\n";	
	}
	if(this.txtAJ_JOB_18.Text =="")
	{
		strErr+="AJ_JOB_18不能为空！\\n";	
	}
	if(this.txtAJ_JOB_19.Text =="")
	{
		strErr+="AJ_JOB_19不能为空！\\n";	
	}
	if(this.txtAJ_JOB_20.Text =="")
	{
		strErr+="AJ_JOB_20不能为空！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	DateTime AJ_LAST_DATE=DateTime.Parse(this.txtAJ_LAST_DATE.Text);
	decimal AJ_LAST_NUM=decimal.Parse(this.txtAJ_LAST_NUM.Text);
	string AJ_JOB_1=this.txtAJ_JOB_1.Text;
	string AJ_JOB_2=this.txtAJ_JOB_2.Text;
	string AJ_JOB_3=this.txtAJ_JOB_3.Text;
	string AJ_JOB_4=this.txtAJ_JOB_4.Text;
	string AJ_JOB_5=this.txtAJ_JOB_5.Text;
	string AJ_JOB_6=this.txtAJ_JOB_6.Text;
	string AJ_JOB_7=this.txtAJ_JOB_7.Text;
	string AJ_JOB_8=this.txtAJ_JOB_8.Text;
	string AJ_JOB_9=this.txtAJ_JOB_9.Text;
	string AJ_JOB_10=this.txtAJ_JOB_10.Text;
	string AJ_JOB_11=this.txtAJ_JOB_11.Text;
	string AJ_JOB_12=this.txtAJ_JOB_12.Text;
	string AJ_JOB_13=this.txtAJ_JOB_13.Text;
	string AJ_JOB_14=this.txtAJ_JOB_14.Text;
	string AJ_JOB_15=this.txtAJ_JOB_15.Text;
	string AJ_JOB_16=this.txtAJ_JOB_16.Text;
	string AJ_JOB_17=this.txtAJ_JOB_17.Text;
	string AJ_JOB_18=this.txtAJ_JOB_18.Text;
	string AJ_JOB_19=this.txtAJ_JOB_19.Text;
	string AJ_JOB_20=this.txtAJ_JOB_20.Text;

	WongTung.Model.pat_job_tem model=new WongTung.Model.pat_job_tem();
	model.AJ_LAST_DATE=AJ_LAST_DATE;
	model.AJ_LAST_NUM=AJ_LAST_NUM;
	model.AJ_JOB_1=AJ_JOB_1;
	model.AJ_JOB_2=AJ_JOB_2;
	model.AJ_JOB_3=AJ_JOB_3;
	model.AJ_JOB_4=AJ_JOB_4;
	model.AJ_JOB_5=AJ_JOB_5;
	model.AJ_JOB_6=AJ_JOB_6;
	model.AJ_JOB_7=AJ_JOB_7;
	model.AJ_JOB_8=AJ_JOB_8;
	model.AJ_JOB_9=AJ_JOB_9;
	model.AJ_JOB_10=AJ_JOB_10;
	model.AJ_JOB_11=AJ_JOB_11;
	model.AJ_JOB_12=AJ_JOB_12;
	model.AJ_JOB_13=AJ_JOB_13;
	model.AJ_JOB_14=AJ_JOB_14;
	model.AJ_JOB_15=AJ_JOB_15;
	model.AJ_JOB_16=AJ_JOB_16;
	model.AJ_JOB_17=AJ_JOB_17;
	model.AJ_JOB_18=AJ_JOB_18;
	model.AJ_JOB_19=AJ_JOB_19;
	model.AJ_JOB_20=AJ_JOB_20;

	WongTung.BLL.pat_job_tem bll=new WongTung.BLL.pat_job_tem();
	bll.Add(model);

		}

    }
}
