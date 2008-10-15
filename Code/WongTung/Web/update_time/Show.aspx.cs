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
namespace WongTung.Web.update_time
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
					//ShowInfo(UT_CODE);
				}
			}
		}
		
	private void ShowInfo(string UT_CODE)
	{
		WongTung.BLL.update_time bll=new WongTung.BLL.update_time();
		WongTung.Model.update_time model=bll.GetModel(UT_CODE);
		this.lblUT_DATE.Text=model.UT_DATE.ToString();
		this.lblUT_TIME.Text=model.UT_TIME;
		this.lblUT_FRE.Text=model.UT_FRE.ToString();
		this.lblUT_UPDATE_USER.Text=model.UT_UPDATE_USER;
		this.lblUT_UPDATE_DT.Text=model.UT_UPDATE_DT.ToString();
		this.lblUT_INF.Text=model.UT_INF;

	}


    }
}
