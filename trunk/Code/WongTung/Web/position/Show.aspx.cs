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
namespace WongTung.Web.position
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
					//ShowInfo(POS_CODE);
				}
			}
		}
		
	private void ShowInfo(string POS_CODE)
	{
		WongTung.BLL.position bll=new WongTung.BLL.position();
		WongTung.Model.position model=bll.GetModel(POS_CODE);
		this.lblPOS_CO_CODE.Text=model.POS_CO_CODE;
		this.lblPOS_DESC.Text=model.POS_DESC;
		this.lblPOS_FEE_LEV1.Text=model.POS_FEE_LEV1.ToString();
		this.lblPOS_FEE_LEV2.Text=model.POS_FEE_LEV2.ToString();
		this.lblPOS_FEE_LEV3.Text=model.POS_FEE_LEV3.ToString();
		this.lblPOS_RATE_OUT.Text=model.POS_RATE_OUT.ToString();
		this.lblPOS_RATE_DAILY.Text=model.POS_RATE_DAILY.ToString();
		this.lblPOS_RATE_MON.Text=model.POS_RATE_MON.ToString();
		this.lblPOS_RATE_OT.Text=model.POS_RATE_OT.ToString();
		this.lblPOS_MON_TOTAL.Text=model.POS_MON_TOTAL.ToString();
		this.lblPOS_MON_UTILIST.Text=model.POS_MON_UTILIST.ToString();
		this.lblPOS_MON_REV.Text=model.POS_MON_REV.ToString();
		this.lblPOS_SAL_FROM.Text=model.POS_SAL_FROM.ToString();
		this.lblPOS_SAL_TO.Text=model.POS_SAL_TO.ToString();
		this.lblPOS_DALIY_COST.Text=model.POS_DALIY_COST.ToString();
		this.lblPOS_MON_COST.Text=model.POS_MON_COST.ToString();
		this.lblPOS_CLASS.Text=model.POS_CLASS.ToString();
		this.lblPOS_PLAN.Text=model.POS_PLAN;

	}


    }
}
