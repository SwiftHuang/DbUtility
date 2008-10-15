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
namespace WongTung.Web.prriod
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
		WongTung.BLL.prriod bll=new WongTung.BLL.prriod();
		WongTung.Model.prriod model=bll.GetModel();
		this.lblPR_CO_CODE.Text=model.PR_CO_CODE;
		this.lblPR_NO.Text=model.PR_NO.ToString();
		this.lblPR_FROM.Text=model.PR_FROM;
		this.lblPR_TO.Text=model.PR_TO;

	}


    }
}
