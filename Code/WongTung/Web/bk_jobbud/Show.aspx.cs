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
namespace WongTung.Web.bk_jobbud
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
					//ShowInfo(JOB_CO_CODE,JOB_CODE,JOB_SER,JOB_STAFF);
				}
			}
		}
		
	private void ShowInfo(string JOB_CO_CODE,string JOB_CODE,string JOB_SER,string JOB_STAFF)
	{
		WongTung.BLL.bk_jobbud bll=new WongTung.BLL.bk_jobbud();
		WongTung.Model.bk_jobbud model=bll.GetModel(JOB_CO_CODE,JOB_CODE,JOB_SER,JOB_STAFF);
		this.lblJOB_POS.Text=model.JOB_POS;
		this.lblJOB_BUD.Text=model.JOB_BUD.ToString();
		this.lblJOB_NOR.Text=model.JOB_NOR.ToString();
		this.lblJOB_NOR_EXP.Text=model.JOB_NOR_EXP.ToString();
		this.lblJOB_OT.Text=model.JOB_OT.ToString();
		this.lblJOB_OT_EXP.Text=model.JOB_OT_EXP.ToString();

	}


    }
}
