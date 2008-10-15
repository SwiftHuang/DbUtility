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
namespace WongTung.Web.changepw
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
					//ShowInfo(CP_USER_CODE);
				}
			}
		}
		
	private void ShowInfo(string CP_USER_CODE)
	{
		WongTung.BLL.changepw bll=new WongTung.BLL.changepw();
		WongTung.Model.changepw model=bll.GetModel(CP_USER_CODE);
		this.lblCP_CO_CODE.Text=model.CP_CO_CODE;
		this.lblCP_NEW_PWD.Text=model.CP_NEW_PWD;

	}


    }
}
