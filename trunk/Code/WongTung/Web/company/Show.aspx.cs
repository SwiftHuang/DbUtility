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
namespace WongTung.Web.company
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
		WongTung.BLL.company bll=new WongTung.BLL.company();
		WongTung.Model.company model=bll.GetModel();
		this.lblCO_CODE.Text=model.CO_CODE;
		this.lblCO_SCR_NAME.Text=model.CO_SCR_NAME;
		this.lblCO_RPT_NAME.Text=model.CO_RPT_NAME;
		this.lblCO_LB_DATE.Text=model.CO_LB_DATE.ToString();
		this.lblCO_LE_DATE.Text=model.CO_LE_DATE.ToString();
		this.lblCO_CB_DATE.Text=model.CO_CB_DATE.ToString();
		this.lblCO_CE_DATE.Text=model.CO_CE_DATE.ToString();
		this.lblCO_CURR.Text=model.CO_CURR;
		this.lblCO_PERIOD_FROM.Text=model.CO_PERIOD_FROM.ToString();
		this.lblCO_PERIOD_TO.Text=model.CO_PERIOD_TO.ToString();

	}


    }
}
