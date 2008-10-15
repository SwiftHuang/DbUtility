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
namespace WongTung.Web.plan_emp
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
					//ShowInfo(PLA_EMP_CO,PLA_EMP_OFF,PLA_EMP_POS,PLA_EMP_CODE);
				}
			}
		}
		
	private void ShowInfo(string PLA_EMP_CO,string PLA_EMP_OFF,string PLA_EMP_POS,string PLA_EMP_CODE)
	{
		WongTung.BLL.plan_emp bll=new WongTung.BLL.plan_emp();
		WongTung.Model.plan_emp model=bll.GetModel(PLA_EMP_CO,PLA_EMP_OFF,PLA_EMP_POS,PLA_EMP_CODE);
		this.lblPLA_EMP_NUM.Text=model.PLA_EMP_NUM.ToString();
		this.lblPLA_EMP_NOR.Text=model.PLA_EMP_NOR.ToString();
		this.lblPLA_EMP_OT1.Text=model.PLA_EMP_OT1.ToString();
		this.lblPLA_EMP_OT2.Text=model.PLA_EMP_OT2.ToString();
		this.lblPLA_EMP_OT3.Text=model.PLA_EMP_OT3.ToString();
		this.lblPLA_EMP_T1.Text=model.PLA_EMP_T1.ToString();
		this.lblPLA_EMP_T2.Text=model.PLA_EMP_T2.ToString();
		this.lblPLA_EMP_T3.Text=model.PLA_EMP_T3.ToString();

	}


    }
}
