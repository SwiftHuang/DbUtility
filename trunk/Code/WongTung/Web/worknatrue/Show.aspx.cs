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
namespace WongTung.Web.worknatrue
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
					//ShowInfo(WN_CODE);
				}
			}
		}
		
	private void ShowInfo(string WN_CODE)
	{
		WongTung.BLL.worknatrue bll=new WongTung.BLL.worknatrue();
		WongTung.Model.worknatrue model=bll.GetModel(WN_CODE);
		this.lblWN_CO_CODE.Text=model.WN_CO_CODE;
		this.lblWN_DESC.Text=model.WN_DESC;
		this.lblWN_DESC_T.Text=model.WN_DESC_T;
		this.lblWN_DESC_S.Text=model.WN_DESC_S;

	}


    }
}
