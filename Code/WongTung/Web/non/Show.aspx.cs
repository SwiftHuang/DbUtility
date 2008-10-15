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
namespace WongTung.Web.non
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
		WongTung.BLL.non bll=new WongTung.BLL.non();
		WongTung.Model.non model=bll.GetModel();
		this.lblCO_CODE.Text=model.CO_CODE;
		this.lblSTAFF_CODE.Text=model.STAFF_CODE;
		this.lblDATE.Text=model.DATE.ToString();
		this.lblTYPE.Text=model.TYPE;
		this.lblANNUAL.Text=model.ANNUAL.ToString();
		this.lblSICK.Text=model.SICK.ToString();
		this.lblADMIN.Text=model.ADMIN.ToString();
		this.lblOT_PAY.Text=model.OT_PAY.ToString();

	}


    }
}
