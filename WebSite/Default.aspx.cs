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
            TimeSpan ts;
            int Count = 10000;

            if (Request["C"] != null)
                Count = Convert.ToInt32(Request["C"].ToString());

            BOJob BJJob = new BOJob();
            BJJob.GetList();

            BODailyts BJ = new BODailyts();
            DateTime dStart = new DateTime();

            List<Entity.Table.dailyts2> lst = new List<WongTung.Entity.Table.dailyts2>();
            dStart = DateTime.Now;
            lst = BJ.GetList2(Count);
            ts = DateTime.Now - dStart;
            Label4.Text = (ts.TotalMilliseconds - BJ.timeSpan.TotalMilliseconds).ToString();
            Label5.Text = ((ts.TotalMilliseconds - BJ.timeSpan.TotalMilliseconds) / 1000).ToString();


            dStart = DateTime.Now;
            BJ.GetTable(Count);
            ts = DateTime.Now - dStart;
            Label6.Text = (ts.TotalMilliseconds - BJ.timeSpan.TotalMilliseconds).ToString();
            Label7.Text = ((ts.TotalMilliseconds - BJ.timeSpan.TotalMilliseconds) / 1000).ToString();

            
            List<Entity.Table.dailyts> lst1 = new List<WongTung.Entity.Table.dailyts>();
            dStart = DateTime.Now;
            lst1 = BJ.GetList(Count);
            Label1.Text = lst1.Count.ToString();
            ts = DateTime.Now - dStart;
            Label2.Text = (ts.TotalMilliseconds - BJ.timeSpan.TotalMilliseconds).ToString();
            Label3.Text = ((ts.TotalMilliseconds - BJ.timeSpan.TotalMilliseconds) / 1000).ToString();
        }
    }
}
