using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WongTung.Entity
{
    public class LoginInfo
    {
        #region Attribue
        public string UserID { get; set; }
        public string UserCode { get; set; }
        public string UserName { get; set; }
        public DateTime LoginTime { get; set; }
        #endregion

        public LoginInfo()
        {
        }
        public LoginInfo(string usercode)
        {
            UserCode = usercode;
            UserName = string.Empty;
            LoginTime = DateTime.Now;
        }
        public LoginInfo(string usercode, string username)
        {
            UserCode = usercode;
            UserName = username;
            LoginTime = DateTime.Now;
        }

        public string SessionKeys
        { get { return this.GetType().ToString(); } }
        public static void GetSessionTo(ref LoginInfo entity)
        {
            string mySessionKeys = entity.GetType().ToString();
            if (HttpContext.Current.Session[mySessionKeys] == null)
                entity = null;
            else
                entity = HttpContext.Current.Session[mySessionKeys] as LoginInfo;
        }
        public void SetSession()
        {
            HttpContext.Current.Session[SessionKeys] = this as LoginInfo;
        }
        public void ClearSession()
        {
            HttpContext.Current.Session.Remove(SessionKeys);
        }
    }
}
