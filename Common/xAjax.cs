using System;
using System.Collections.Generic;
using System.Text;

namespace WongTung.Common
{
    public class xAjax
    {
        public static void Alert(System.Web.UI.Page xPage, string xText, string xKey)
        {
            string _sKey = xAjax.GeneralScriptKey(xKey);
            System.Web.UI.ScriptManager.RegisterStartupScript(xPage, xPage.GetType(), _sKey, "alert('" + xText + "');", true);
        }
        public static void Alert(System.Web.UI.Page xPage, string xText)
        {
            string _sKey = xAjax.GeneralScriptKey("");
            System.Web.UI.ScriptManager.RegisterStartupScript(xPage, xPage.GetType(), _sKey, "alert('" + xText + "');", true);
        }

        public static void ExecScript(System.Web.UI.Page xPage, string xScript)
        {
            if (xScript.Trim().Length != 0)
            {
                string _sKey = GeneralScriptKey("");
                System.Web.UI.ScriptManager.RegisterStartupScript(xPage, xPage.GetType(), _sKey, xScript, true);
            }
        }
        public static void ExecScript(System.Web.UI.Page xPage, string xScript, string xKey)
        {
            if (xScript.Trim().Length != 0)
            {
                string _sKey = GeneralScriptKey(xKey);
                System.Web.UI.ScriptManager.RegisterStartupScript(xPage, xPage.GetType(), _sKey, xScript, true);
            }
        }

        public static string GeneralScriptKey(string xKey)
        {
            if (xKey.Trim().Length == 0)
            {
                int iSeed = 0;
                string sDateKey;

                sDateKey = DateTime.Now.ToString("yyyymmddhhmmss");
                iSeed = Convert.ToInt16(sDateKey.Substring(sDateKey.Length - 1));
                Random ra = new Random(iSeed);

                return String.Format("{0}{1}", sDateKey, ra.Next());
            }
            else
            {
                return xKey;
            }

        }
    }
}
