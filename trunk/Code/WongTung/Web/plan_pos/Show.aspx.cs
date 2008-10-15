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
namespace WongTung.Web.plan_pos
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
					//ShowInfo(PLA_POS_CO,PLA_POS_OFF,PLA_POS_CODE);
				}
			}
		}
		
	private void ShowInfo(string PLA_POS_CO,string PLA_POS_OFF,string PLA_POS_CODE)
	{
		WongTung.BLL.plan_pos bll=new WongTung.BLL.plan_pos();
		WongTung.Model.plan_pos model=bll.GetModel(PLA_POS_CO,PLA_POS_OFF,PLA_POS_CODE);
		this.lblPLA_POS_NUM.Text=model.PLA_POS_NUM.ToString();
		this.lblPLA_POS_NOR.Text=model.PLA_POS_NOR.ToString();
		this.lblPLA_POS_OT1.Text=model.PLA_POS_OT1.ToString();
		this.lblPLA_POS_OT2.Text=model.PLA_POS_OT2.ToString();
		this.lblPLA_POS_OT3.Text=model.PLA_POS_OT3.ToString();
		this.lblPLA_POS_T1.Text=model.PLA_POS_T1.ToString();
		this.lblPLA_POS_T2.Text=model.PLA_POS_T2.ToString();
		this.lblPLA_POS_T3.Text=model.PLA_POS_T3.ToString();

	}


    }
}
