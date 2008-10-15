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
namespace WongTung.Web.non_hist
{
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        		protected void Page_LoadComplete(object sender, EventArgs e)
		{
			(Master.FindControl("lblTitle") as Label).Text = "信息添加";
		}
		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
	string strErr="";
	if(this.txtCO_CODE.Text =="")
	{
		strErr+="CO_CODE不能为空！\\n";	
	}
	if(this.txtSTAFF_CODE.Text =="")
	{
		strErr+="STAFF_CODE不能为空！\\n";	
	}
	if(!PageValidate.IsDateTime(txtDATE.Text))
	{
	strErr+="DATE不是时间格式！\\n";	
	}
	if(this.txtTYPE.Text =="")
	{
		strErr+="TYPE不能为空！\\n";	
	}
	if(!PageValidate.IsDecimal(txtANNUAL.Text))
	{
		strErr+="ANNUAL不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtSICK.Text))
	{
		strErr+="SICK不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtADMIN.Text))
	{
		strErr+="ADMIN不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtOT_PAY.Text))
	{
		strErr+="OT_PAY不是数字！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	string CO_CODE=this.txtCO_CODE.Text;
	string STAFF_CODE=this.txtSTAFF_CODE.Text;
	DateTime DATE=DateTime.Parse(this.txtDATE.Text);
	string TYPE=this.txtTYPE.Text;
	decimal ANNUAL=decimal.Parse(this.txtANNUAL.Text);
	decimal SICK=decimal.Parse(this.txtSICK.Text);
	decimal ADMIN=decimal.Parse(this.txtADMIN.Text);
	decimal OT_PAY=decimal.Parse(this.txtOT_PAY.Text);

	WongTung.Model.non_hist model=new WongTung.Model.non_hist();
	model.CO_CODE=CO_CODE;
	model.STAFF_CODE=STAFF_CODE;
	model.DATE=DATE;
	model.TYPE=TYPE;
	model.ANNUAL=ANNUAL;
	model.SICK=SICK;
	model.ADMIN=ADMIN;
	model.OT_PAY=OT_PAY;

	WongTung.BLL.non_hist bll=new WongTung.BLL.non_hist();
	bll.Add(model);

		}

    }
}
