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
namespace WongTung.Web.job
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
					//ShowInfo(JOB_CODE);
				}
			}
		}
		
	private void ShowInfo(string JOB_CODE)
	{
		WongTung.BLL.job bll=new WongTung.BLL.job();
		WongTung.Model.job model=bll.GetModel(JOB_CODE);
		this.lblJOB_CO_CODE.Text=model.JOB_CO_CODE;
		this.lblJOB_NAME.Text=model.JOB_NAME;
		this.lblJOB_CON.Text=model.JOB_CON.ToString();
		this.lblJOB_OPEN_BAL_HOUR.Text=model.JOB_OPEN_BAL_HOUR.ToString();
		this.lblJOB_YTD_HOUR.Text=model.JOB_YTD_HOUR.ToString();
		this.lblJOB_OPEN_BAL_AMT.Text=model.JOB_OPEN_BAL_AMT.ToString();
		this.lblJOB_YTD_AMT.Text=model.JOB_YTD_AMT.ToString();
		this.lblJOB_REC.Text=model.JOB_REC.ToString();
		this.lblJOB_OS_BAL.Text=model.JOB_OS_BAL.ToString();
		this.lblJOB_BUD_HOUR.Text=model.JOB_BUD_HOUR.ToString();
		this.lblJOB_CO_ORD.Text=model.JOB_CO_ORD.ToString();
		this.lblJOB_ADMIN.Text=model.JOB_ADMIN.ToString();
		this.lblJOB_DESIGN.Text=model.JOB_DESIGN.ToString();
		this.lblJOB_LEV1.Text=model.JOB_LEV1.ToString();
		this.lblJOB_LEV2.Text=model.JOB_LEV2.ToString();
		this.lblJOB_LEV3.Text=model.JOB_LEV3.ToString();
		this.lblJOB_CHARGE_OUT.Text=model.JOB_CHARGE_OUT.ToString();
		this.lblJOB_DAILY.Text=model.JOB_DAILY.ToString();
		this.lblJOB_MON.Text=model.JOB_MON.ToString();
		this.lblJOB_PERIOD.Text=model.JOB_PERIOD.ToString();
		this.lblJOB_PERIOD_VAL.Text=model.JOB_PERIOD_VAL.ToString();
		this.lblJOB_AUTH.Text=model.JOB_AUTH;
		this.lblJOB_OFF_INCHG_AD.Text=model.JOB_OFF_INCHG_AD;
		this.lblJOB_OFF_INCHG_DES.Text=model.JOB_OFF_INCHG_DES;
		this.lblJOB_AUTH_1.Text=model.JOB_AUTH_1;
		this.lblJOB_AUTH_2.Text=model.JOB_AUTH_2;
		this.lblJOB_AUTH_3.Text=model.JOB_AUTH_3;
		this.lblJOB_AUTH_4.Text=model.JOB_AUTH_4;
		this.lblJOB_AUTH_5.Text=model.JOB_AUTH_5;
		this.lblJOB_INDEX.Text=model.JOB_INDEX.ToString();
		this.lblJOB_NAME_S.Text=model.JOB_NAME_S;
		this.lblJOB_NAME_T.Text=model.JOB_NAME_T;

	}


    }
}
