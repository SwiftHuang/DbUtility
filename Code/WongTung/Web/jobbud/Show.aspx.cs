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
namespace WongTung.Web.jobbud
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
					//ShowInfo(JOB_CO_CODE,JOB_CODE,JOB_SER,JOB_POS);
				}
			}
		}
		
	private void ShowInfo(string JOB_CO_CODE,string JOB_CODE,string JOB_SER,string JOB_POS)
	{
		WongTung.BLL.jobbud bll=new WongTung.BLL.jobbud();
		WongTung.Model.jobbud model=bll.GetModel(JOB_CO_CODE,JOB_CODE,JOB_SER,JOB_POS);
		this.lblJOB_STAFF.Text=model.JOB_STAFF;
		this.lblJOB_BUD.Text=model.JOB_BUD.ToString();
		this.lblJOB_NOR.Text=model.JOB_NOR.ToString();
		this.lblJOB_NOR_EXP.Text=model.JOB_NOR_EXP.ToString();
		this.lblJOB_OT.Text=model.JOB_OT.ToString();
		this.lblJOB_OT_EXP.Text=model.JOB_OT_EXP.ToString();

	}


    }
}
