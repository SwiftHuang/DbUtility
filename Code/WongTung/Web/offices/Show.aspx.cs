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
namespace WongTung.Web.offices
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
					//ShowInfo(OFF_CODE);
				}
			}
		}
		
	private void ShowInfo(string OFF_CODE)
	{
		WongTung.BLL.offices bll=new WongTung.BLL.offices();
		WongTung.Model.offices model=bll.GetModel(OFF_CODE);
		this.lblOFF_CO_CODE.Text=model.OFF_CO_CODE;
		this.lblOFF_NAME.Text=model.OFF_NAME;
		this.lblOFF_ENDORSE.Text=model.OFF_ENDORSE;

	}


    }
}
