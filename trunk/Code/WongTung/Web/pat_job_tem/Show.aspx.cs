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
namespace WongTung.Web.pat_job_tem
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
					//ShowInfo(AJ_CO_CODE,AJ_EMP_CODE);
				}
			}
		}
		
	private void ShowInfo(string AJ_CO_CODE,string AJ_EMP_CODE)
	{
		WongTung.BLL.pat_job_tem bll=new WongTung.BLL.pat_job_tem();
		WongTung.Model.pat_job_tem model=bll.GetModel(AJ_CO_CODE,AJ_EMP_CODE);
		this.lblAJ_LAST_DATE.Text=model.AJ_LAST_DATE.ToString();
		this.lblAJ_LAST_NUM.Text=model.AJ_LAST_NUM.ToString();
		this.lblAJ_JOB_1.Text=model.AJ_JOB_1;
		this.lblAJ_JOB_2.Text=model.AJ_JOB_2;
		this.lblAJ_JOB_3.Text=model.AJ_JOB_3;
		this.lblAJ_JOB_4.Text=model.AJ_JOB_4;
		this.lblAJ_JOB_5.Text=model.AJ_JOB_5;
		this.lblAJ_JOB_6.Text=model.AJ_JOB_6;
		this.lblAJ_JOB_7.Text=model.AJ_JOB_7;
		this.lblAJ_JOB_8.Text=model.AJ_JOB_8;
		this.lblAJ_JOB_9.Text=model.AJ_JOB_9;
		this.lblAJ_JOB_10.Text=model.AJ_JOB_10;
		this.lblAJ_JOB_11.Text=model.AJ_JOB_11;
		this.lblAJ_JOB_12.Text=model.AJ_JOB_12;
		this.lblAJ_JOB_13.Text=model.AJ_JOB_13;
		this.lblAJ_JOB_14.Text=model.AJ_JOB_14;
		this.lblAJ_JOB_15.Text=model.AJ_JOB_15;
		this.lblAJ_JOB_16.Text=model.AJ_JOB_16;
		this.lblAJ_JOB_17.Text=model.AJ_JOB_17;
		this.lblAJ_JOB_18.Text=model.AJ_JOB_18;
		this.lblAJ_JOB_19.Text=model.AJ_JOB_19;
		this.lblAJ_JOB_20.Text=model.AJ_JOB_20;

	}


    }
}
