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
namespace WongTung.Web.ptl_job_tem
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
					//ShowInfo(TJ_CO_CODE,TJ_EMP_CODE);
				}
			}
		}
		
	private void ShowInfo(string TJ_CO_CODE,string TJ_EMP_CODE)
	{
		WongTung.BLL.ptl_job_tem bll=new WongTung.BLL.ptl_job_tem();
		WongTung.Model.ptl_job_tem model=bll.GetModel(TJ_CO_CODE,TJ_EMP_CODE);
		this.lblTJ_LAST_DATE.Text=model.TJ_LAST_DATE.ToString();
		this.lblTJ_LAST_NUM.Text=model.TJ_LAST_NUM.ToString();
		this.lblTJ_JOB_1.Text=model.TJ_JOB_1;
		this.lblTJ_JOB_2.Text=model.TJ_JOB_2;
		this.lblTJ_JOB_3.Text=model.TJ_JOB_3;
		this.lblTJ_JOB_4.Text=model.TJ_JOB_4;
		this.lblTJ_JOB_5.Text=model.TJ_JOB_5;
		this.lblTJ_JOB_6.Text=model.TJ_JOB_6;
		this.lblTJ_JOB_7.Text=model.TJ_JOB_7;
		this.lblTJ_JOB_8.Text=model.TJ_JOB_8;
		this.lblTJ_JOB_9.Text=model.TJ_JOB_9;
		this.lblTJ_JOB_10.Text=model.TJ_JOB_10;
		this.lblTJ_JOB_11.Text=model.TJ_JOB_11;
		this.lblTJ_JOB_12.Text=model.TJ_JOB_12;
		this.lblTJ_JOB_13.Text=model.TJ_JOB_13;
		this.lblTJ_JOB_14.Text=model.TJ_JOB_14;
		this.lblTJ_JOB_15.Text=model.TJ_JOB_15;
		this.lblTJ_JOB_16.Text=model.TJ_JOB_16;
		this.lblTJ_JOB_17.Text=model.TJ_JOB_17;
		this.lblTJ_JOB_18.Text=model.TJ_JOB_18;
		this.lblTJ_JOB_19.Text=model.TJ_JOB_19;
		this.lblTJ_JOB_20.Text=model.TJ_JOB_20;

	}


    }
}
