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
namespace WongTung.Web.budgetot
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
		WongTung.BLL.budgetot bll=new WongTung.BLL.budgetot();
		WongTung.Model.budgetot model=bll.GetModel();
		this.lblBG_CO_CODE.Text=model.BG_CO_CODE;
		this.lblBG_JOB_CODE.Text=model.BG_JOB_CODE;
		this.lblBG_SER_CODE.Text=model.BG_SER_CODE;
		this.lblBG_POS.Text=model.BG_POS;
		this.lblBG_HOUR.Text=model.BG_HOUR.ToString();
		this.lblBG_EXP_BUDGET.Text=model.BG_EXP_BUDGET.ToString();

	}


    }
}
