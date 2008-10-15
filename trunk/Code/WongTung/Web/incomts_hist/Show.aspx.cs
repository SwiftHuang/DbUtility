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
namespace WongTung.Web.incomts_hist
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
		WongTung.BLL.incomts_hist bll=new WongTung.BLL.incomts_hist();
		WongTung.Model.incomts_hist model=bll.GetModel();
		this.lblIST_CO_CODE.Text=model.IST_CO_CODE;
		this.lblIST_OFFICE_CODE.Text=model.IST_OFFICE_CODE;
		this.lblIST_WORK_DATE.Text=model.IST_WORK_DATE.ToString();
		this.lblIST_USER_CODE.Text=model.IST_USER_CODE;
		this.lblIST_USER_NAME.Text=model.IST_USER_NAME;
		this.lblIST_INPUT_OK.Text=model.IST_INPUT_OK;
		this.lblIST_APP.Text=model.IST_APP;
		this.lblIST_NOR_HR.Text=model.IST_NOR_HR.ToString();
		this.lblIST_OT_HR.Text=model.IST_OT_HR.ToString();
		this.lblIST_PERIOD.Text=model.IST_PERIOD;

	}


    }
}
