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
namespace WongTung.Web.emp_job_tem
{
    public partial class Show : System.Web.UI.Page
    {        
        		protected void Page_LoadComplete(object sender, EventArgs e)
		{
			(Master.FindControl("lblTitle") as Label).Text = "œÍœ∏–≈œ¢";
		}
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null || Request.Params["id"].Trim() != "")
				{
					string id = Request.Params["id"];
					//ShowInfo(EJ_CO_CODE,EJ_EMP_CODE);
				}
			}
		}
		
	private void ShowInfo(string EJ_CO_CODE,string EJ_EMP_CODE)
	{
		WongTung.BLL.emp_job_tem bll=new WongTung.BLL.emp_job_tem();
		WongTung.Model.emp_job_tem model=bll.GetModel(EJ_CO_CODE,EJ_EMP_CODE);
		this.lblEJ_LAST_DATE.Text=model.EJ_LAST_DATE.ToString();
		this.lblEJ_LAST_NUM.Text=model.EJ_LAST_NUM.ToString();
		this.lblEJ_JOB_1.Text=model.EJ_JOB_1;
		this.lblEJ_JOB_2.Text=model.EJ_JOB_2;
		this.lblEJ_JOB_3.Text=model.EJ_JOB_3;
		this.lblEJ_JOB_4.Text=model.EJ_JOB_4;
		this.lblEJ_JOB_5.Text=model.EJ_JOB_5;
		this.lblEJ_JOB_6.Text=model.EJ_JOB_6;
		this.lblEJ_JOB_7.Text=model.EJ_JOB_7;
		this.lblEJ_JOB_8.Text=model.EJ_JOB_8;
		this.lblEJ_JOB_9.Text=model.EJ_JOB_9;
		this.lblEJ_JOB_10.Text=model.EJ_JOB_10;
		this.lblEJ_JOB_11.Text=model.EJ_JOB_11;
		this.lblEJ_JOB_12.Text=model.EJ_JOB_12;
		this.lblEJ_JOB_13.Text=model.EJ_JOB_13;
		this.lblEJ_JOB_14.Text=model.EJ_JOB_14;
		this.lblEJ_JOB_15.Text=model.EJ_JOB_15;
		this.lblEJ_JOB_16.Text=model.EJ_JOB_16;
		this.lblEJ_JOB_17.Text=model.EJ_JOB_17;
		this.lblEJ_JOB_18.Text=model.EJ_JOB_18;
		this.lblEJ_JOB_19.Text=model.EJ_JOB_19;
		this.lblEJ_JOB_20.Text=model.EJ_JOB_20;

	}


    }
}
