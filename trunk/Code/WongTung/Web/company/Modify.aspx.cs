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
using LTP.Common;
namespace WongTung.Web.company
{
    public partial class Modify : System.Web.UI.Page
    {       

        		protected void Page_LoadComplete(object sender, EventArgs e)
		{
			(Master.FindControl("lblTitle") as Label).Text = "信息修改";
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
		this.txtCO_CODE.Text=model.CO_CODE;
		this.txtCO_SCR_NAME.Text=model.CO_SCR_NAME;
		this.txtCO_RPT_NAME.Text=model.CO_RPT_NAME;
		this.txtCO_LB_DATE.Text=model.CO_LB_DATE.ToString();
		this.txtCO_LE_DATE.Text=model.CO_LE_DATE.ToString();
		this.txtCO_CB_DATE.Text=model.CO_CB_DATE.ToString();
		this.txtCO_CE_DATE.Text=model.CO_CE_DATE.ToString();
		this.txtCO_CURR.Text=model.CO_CURR;
		this.txtCO_PERIOD_FROM.Text=model.CO_PERIOD_FROM.ToString();
		this.txtCO_PERIOD_TO.Text=model.CO_PERIOD_TO.ToString();

	}

		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
	string strErr="";
	if(this.txtCO_CODE.Text =="")
	{
		strErr+="CO_CODE不能为空！\\n";	
	}
	if(this.txtCO_SCR_NAME.Text =="")
	{
		strErr+="CO_SCR_NAME不能为空！\\n";	
	}
	if(this.txtCO_RPT_NAME.Text =="")
	{
		strErr+="CO_RPT_NAME不能为空！\\n";	
	}
	if(!PageValidate.IsDateTime(txtCO_LB_DATE.Text))
	{
		strErr+="CO_LB_DATE不是时间格式！\\n";	
	}
	if(!PageValidate.IsDateTime(txtCO_LE_DATE.Text))
	{
		strErr+="CO_LE_DATE不是时间格式！\\n";	
	}
	if(!PageValidate.IsDateTime(txtCO_CB_DATE.Text))
	{
		strErr+="CO_CB_DATE不是时间格式！\\n";	
	}
	if(!PageValidate.IsDateTime(txtCO_CE_DATE.Text))
	{
		strErr+="CO_CE_DATE不是时间格式！\\n";	
	}
	if(this.txtCO_CURR.Text =="")
	{
		strErr+="CO_CURR不能为空！\\n";	
	}
	if(!PageValidate.IsDateTime(txtCO_PERIOD_FROM.Text))
	{
		strErr+="CO_PERIOD_FROM不是时间格式！\\n";	
	}
	if(!PageValidate.IsDateTime(txtCO_PERIOD_TO.Text))
	{
		strErr+="CO_PERIOD_TO不是时间格式！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	string CO_CODE=this.txtCO_CODE.Text;
	string CO_SCR_NAME=this.txtCO_SCR_NAME.Text;
	string CO_RPT_NAME=this.txtCO_RPT_NAME.Text;
	DateTime CO_LB_DATE=DateTime.Parse(this.txtCO_LB_DATE.Text);
	DateTime CO_LE_DATE=DateTime.Parse(this.txtCO_LE_DATE.Text);
	DateTime CO_CB_DATE=DateTime.Parse(this.txtCO_CB_DATE.Text);
	DateTime CO_CE_DATE=DateTime.Parse(this.txtCO_CE_DATE.Text);
	string CO_CURR=this.txtCO_CURR.Text;
	DateTime CO_PERIOD_FROM=DateTime.Parse(this.txtCO_PERIOD_FROM.Text);
	DateTime CO_PERIOD_TO=DateTime.Parse(this.txtCO_PERIOD_TO.Text);


	WongTung.Model.company model=new WongTung.Model.company();
	model.CO_CODE=CO_CODE;
	model.CO_SCR_NAME=CO_SCR_NAME;
	model.CO_RPT_NAME=CO_RPT_NAME;
	model.CO_LB_DATE=CO_LB_DATE;
	model.CO_LE_DATE=CO_LE_DATE;
	model.CO_CB_DATE=CO_CB_DATE;
	model.CO_CE_DATE=CO_CE_DATE;
	model.CO_CURR=CO_CURR;
	model.CO_PERIOD_FROM=CO_PERIOD_FROM;
	model.CO_PERIOD_TO=CO_PERIOD_TO;

	WongTung.BLL.company bll=new WongTung.BLL.company();
	bll.Update(model);

		}

    }
}
