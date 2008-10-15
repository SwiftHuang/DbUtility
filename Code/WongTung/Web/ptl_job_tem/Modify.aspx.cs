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
namespace WongTung.Web.ptl_job_tem
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
					//ShowInfo(TJ_CO_CODE,TJ_EMP_CODE);
				}
			}
		}
			
	private void ShowInfo(string TJ_CO_CODE,string TJ_EMP_CODE)
	{
		WongTung.BLL.ptl_job_tem bll=new WongTung.BLL.ptl_job_tem();
		WongTung.Model.ptl_job_tem model=bll.GetModel(TJ_CO_CODE,TJ_EMP_CODE);
		this.lblTJ_CO_CODE.Text=model.TJ_CO_CODE;
		this.lblTJ_EMP_CODE.Text=model.TJ_EMP_CODE;
		this.txtTJ_LAST_DATE.Text=model.TJ_LAST_DATE.ToString();
		this.txtTJ_LAST_NUM.Text=model.TJ_LAST_NUM.ToString();
		this.txtTJ_JOB_1.Text=model.TJ_JOB_1;
		this.txtTJ_JOB_2.Text=model.TJ_JOB_2;
		this.txtTJ_JOB_3.Text=model.TJ_JOB_3;
		this.txtTJ_JOB_4.Text=model.TJ_JOB_4;
		this.txtTJ_JOB_5.Text=model.TJ_JOB_5;
		this.txtTJ_JOB_6.Text=model.TJ_JOB_6;
		this.txtTJ_JOB_7.Text=model.TJ_JOB_7;
		this.txtTJ_JOB_8.Text=model.TJ_JOB_8;
		this.txtTJ_JOB_9.Text=model.TJ_JOB_9;
		this.txtTJ_JOB_10.Text=model.TJ_JOB_10;
		this.txtTJ_JOB_11.Text=model.TJ_JOB_11;
		this.txtTJ_JOB_12.Text=model.TJ_JOB_12;
		this.txtTJ_JOB_13.Text=model.TJ_JOB_13;
		this.txtTJ_JOB_14.Text=model.TJ_JOB_14;
		this.txtTJ_JOB_15.Text=model.TJ_JOB_15;
		this.txtTJ_JOB_16.Text=model.TJ_JOB_16;
		this.txtTJ_JOB_17.Text=model.TJ_JOB_17;
		this.txtTJ_JOB_18.Text=model.TJ_JOB_18;
		this.txtTJ_JOB_19.Text=model.TJ_JOB_19;
		this.txtTJ_JOB_20.Text=model.TJ_JOB_20;

	}

		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
	string strErr="";
	if(!PageValidate.IsDateTime(txtTJ_LAST_DATE.Text))
	{
		strErr+="TJ_LAST_DATE不是时间格式！\\n";	
	}
	if(!PageValidate.IsDecimal(txtTJ_LAST_NUM.Text))
	{
		strErr+="TJ_LAST_NUM不是数字！\\n";	
	}
	if(this.txtTJ_JOB_1.Text =="")
	{
		strErr+="TJ_JOB_1不能为空！\\n";	
	}
	if(this.txtTJ_JOB_2.Text =="")
	{
		strErr+="TJ_JOB_2不能为空！\\n";	
	}
	if(this.txtTJ_JOB_3.Text =="")
	{
		strErr+="TJ_JOB_3不能为空！\\n";	
	}
	if(this.txtTJ_JOB_4.Text =="")
	{
		strErr+="TJ_JOB_4不能为空！\\n";	
	}
	if(this.txtTJ_JOB_5.Text =="")
	{
		strErr+="TJ_JOB_5不能为空！\\n";	
	}
	if(this.txtTJ_JOB_6.Text =="")
	{
		strErr+="TJ_JOB_6不能为空！\\n";	
	}
	if(this.txtTJ_JOB_7.Text =="")
	{
		strErr+="TJ_JOB_7不能为空！\\n";	
	}
	if(this.txtTJ_JOB_8.Text =="")
	{
		strErr+="TJ_JOB_8不能为空！\\n";	
	}
	if(this.txtTJ_JOB_9.Text =="")
	{
		strErr+="TJ_JOB_9不能为空！\\n";	
	}
	if(this.txtTJ_JOB_10.Text =="")
	{
		strErr+="TJ_JOB_10不能为空！\\n";	
	}
	if(this.txtTJ_JOB_11.Text =="")
	{
		strErr+="TJ_JOB_11不能为空！\\n";	
	}
	if(this.txtTJ_JOB_12.Text =="")
	{
		strErr+="TJ_JOB_12不能为空！\\n";	
	}
	if(this.txtTJ_JOB_13.Text =="")
	{
		strErr+="TJ_JOB_13不能为空！\\n";	
	}
	if(this.txtTJ_JOB_14.Text =="")
	{
		strErr+="TJ_JOB_14不能为空！\\n";	
	}
	if(this.txtTJ_JOB_15.Text =="")
	{
		strErr+="TJ_JOB_15不能为空！\\n";	
	}
	if(this.txtTJ_JOB_16.Text =="")
	{
		strErr+="TJ_JOB_16不能为空！\\n";	
	}
	if(this.txtTJ_JOB_17.Text =="")
	{
		strErr+="TJ_JOB_17不能为空！\\n";	
	}
	if(this.txtTJ_JOB_18.Text =="")
	{
		strErr+="TJ_JOB_18不能为空！\\n";	
	}
	if(this.txtTJ_JOB_19.Text =="")
	{
		strErr+="TJ_JOB_19不能为空！\\n";	
	}
	if(this.txtTJ_JOB_20.Text =="")
	{
		strErr+="TJ_JOB_20不能为空！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	DateTime TJ_LAST_DATE=DateTime.Parse(this.txtTJ_LAST_DATE.Text);
	decimal TJ_LAST_NUM=decimal.Parse(this.txtTJ_LAST_NUM.Text);
	string TJ_JOB_1=this.txtTJ_JOB_1.Text;
	string TJ_JOB_2=this.txtTJ_JOB_2.Text;
	string TJ_JOB_3=this.txtTJ_JOB_3.Text;
	string TJ_JOB_4=this.txtTJ_JOB_4.Text;
	string TJ_JOB_5=this.txtTJ_JOB_5.Text;
	string TJ_JOB_6=this.txtTJ_JOB_6.Text;
	string TJ_JOB_7=this.txtTJ_JOB_7.Text;
	string TJ_JOB_8=this.txtTJ_JOB_8.Text;
	string TJ_JOB_9=this.txtTJ_JOB_9.Text;
	string TJ_JOB_10=this.txtTJ_JOB_10.Text;
	string TJ_JOB_11=this.txtTJ_JOB_11.Text;
	string TJ_JOB_12=this.txtTJ_JOB_12.Text;
	string TJ_JOB_13=this.txtTJ_JOB_13.Text;
	string TJ_JOB_14=this.txtTJ_JOB_14.Text;
	string TJ_JOB_15=this.txtTJ_JOB_15.Text;
	string TJ_JOB_16=this.txtTJ_JOB_16.Text;
	string TJ_JOB_17=this.txtTJ_JOB_17.Text;
	string TJ_JOB_18=this.txtTJ_JOB_18.Text;
	string TJ_JOB_19=this.txtTJ_JOB_19.Text;
	string TJ_JOB_20=this.txtTJ_JOB_20.Text;


	WongTung.Model.ptl_job_tem model=new WongTung.Model.ptl_job_tem();
	model.TJ_LAST_DATE=TJ_LAST_DATE;
	model.TJ_LAST_NUM=TJ_LAST_NUM;
	model.TJ_JOB_1=TJ_JOB_1;
	model.TJ_JOB_2=TJ_JOB_2;
	model.TJ_JOB_3=TJ_JOB_3;
	model.TJ_JOB_4=TJ_JOB_4;
	model.TJ_JOB_5=TJ_JOB_5;
	model.TJ_JOB_6=TJ_JOB_6;
	model.TJ_JOB_7=TJ_JOB_7;
	model.TJ_JOB_8=TJ_JOB_8;
	model.TJ_JOB_9=TJ_JOB_9;
	model.TJ_JOB_10=TJ_JOB_10;
	model.TJ_JOB_11=TJ_JOB_11;
	model.TJ_JOB_12=TJ_JOB_12;
	model.TJ_JOB_13=TJ_JOB_13;
	model.TJ_JOB_14=TJ_JOB_14;
	model.TJ_JOB_15=TJ_JOB_15;
	model.TJ_JOB_16=TJ_JOB_16;
	model.TJ_JOB_17=TJ_JOB_17;
	model.TJ_JOB_18=TJ_JOB_18;
	model.TJ_JOB_19=TJ_JOB_19;
	model.TJ_JOB_20=TJ_JOB_20;

	WongTung.BLL.ptl_job_tem bll=new WongTung.BLL.ptl_job_tem();
	bll.Update(model);

		}

    }
}
