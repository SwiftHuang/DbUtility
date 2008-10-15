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
namespace WongTung.Web.backspecial
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
					//ShowInfo(BS_CODE);
				}
			}
		}
		
	private void ShowInfo(string BS_CODE)
	{
		WongTung.BLL.backspecial bll=new WongTung.BLL.backspecial();
		WongTung.Model.backspecial model=bll.GetModel(BS_CODE);
		this.lblBS_CO_CODE.Text=model.BS_CO_CODE;
		this.lblBS_DATE.Text=model.BS_DATE.ToString();
		this.lblBS_CURDATE.Text=model.BS_CURDATE.ToString();

	}


    }
}
