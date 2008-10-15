using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WongTung.Common;

namespace WongTung.WebSite
{
    public class BaseMaster : MasterPage
    {
        #region Attribut
        private string sLabelKeys = "ProgrameRunTimeKeys";
        private DateTime dStartTime = DateTime.Now;
        private DateTime dEndTime = DateTime.Now;

        private DateTime StartTime
        {
            get { return dStartTime; }
            set { dStartTime = value; }
        }
        private DateTime EndTime
        {
            get { return dEndTime; }
            set { dEndTime = value; }
        }
        public string RunTimeLabelClientID
        {
            get
            {
                if (ViewState[sLabelKeys] != null)
                    return ViewState[sLabelKeys] as string;
                else
                    return string.Empty;
            }
            set { ViewState[sLabelKeys] = value; }
        }
        #endregion

        public BaseMaster()
        {
            StartTime = DateTime.Now;
            EndTime = StartTime;
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            if (RunTimeLabelClientID != string.Empty)
                this.ProgramRunTime();
        }

        protected override void OnUnload(EventArgs e)
        {

            base.OnUnload(e);
        }
        private void ProgramRunTime()
        {
            if (StartTime == EndTime)
                EndTime = DateTime.Now;

            System.TimeSpan ts = EndTime - StartTime;
            string sStr = string.Format(Resources.Resource.RunningTime, Math.Round(ts.TotalSeconds, 2).ToString("0.00"));

            Label lbl = new Label();
            if (ViewState[sLabelKeys] != null)
            {
                string sScript = string.Format("document.getElementById('{0}').innerHTML='{1}';",
                    ViewState[sLabelKeys],
                    sStr);
                xAjax.ExecScript(this.Page, sScript, "__ProgramRunTime");
            }
            else
            {
                lbl.ID = "__lblProgrameRunTime";
                lbl.Text = sStr;
                this.Page.Controls.Add(lbl);

                ViewState[sLabelKeys] = lbl.ClientID;
            }
        }
    }
}
