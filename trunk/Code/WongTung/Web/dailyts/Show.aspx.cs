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
namespace WongTung.Web.dailyts
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
					ShowInfo();
				}
			}
		}
		
	private void ShowInfo()
	{
		WongTung.BLL.dailyts bll=new WongTung.BLL.dailyts();
		WongTung.Model.dailyts model=bll.GetModel();
		this.lblDT_CO_CODE.Text=model.DT_CO_CODE;
		this.lblDT_STAFF_CODE.Text=model.DT_STAFF_CODE;
		this.lblDT_WORK_DATE.Text=model.DT_WORK_DATE.ToString();
		this.lblDT_LINE_NO.Text=model.DT_LINE_NO.ToString();
		this.lblDT_APP_CODE.Text=model.DT_APP_CODE;
		this.lblDT_JOB_CODE.Text=model.DT_JOB_CODE;
		this.lblDT_SER_CODE.Text=model.DT_SER_CODE;
		this.lblDT_NOR_HOUR.Text=model.DT_NOR_HOUR.ToString();
		this.lblDT_OVER_HOUR.Text=model.DT_OVER_HOUR.ToString();
		this.lblDT_TYPE.Text=model.DT_TYPE;
		this.lblDT_PERIOD.Text=model.DT_PERIOD;
		this.lblDT_SUBMIT.Text=model.DT_SUBMIT;
		this.lblDT_UPDATE.Text=model.DT_UPDATE;
		this.lblDT_RAMNO.Text=model.DT_RAMNO;
		this.lblDT_UPDATE_DATE.Text=model.DT_UPDATE_DATE.ToString();

	}


    }
}
