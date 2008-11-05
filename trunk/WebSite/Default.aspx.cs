using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;

using WongTung.Business;
using WongTung.WebSite;

namespace WongTung.WebSite
{
    public partial class _Default : BasePage
    {
        public _Default()
        {
            this.EnabledLoginCheck = false;
            this.EnabledErrorHandle = true;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
 
            txtSelect.Text = BODemo.GetCount();
            txtInsert.Text = BODemo.GetSelect();
            
        }
    }
}
