using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
namespace WongTung.Entity
{
    public abstract class BaseEntity<T> where T : class
    {
        public void SetSession()
        {
            HttpContext.Current.Session[SessionKeys] = this as T;
        }
        public void ClearSession()
        {
            HttpContext.Current.Session.Remove(SessionKeys);
        }
        public string SessionKeys
        {
            get
            {
                LoginInfo login = new LoginInfo();
                LoginInfo.GetSessionTo(ref login);
                string myUserID = (login == null ? string.Empty : login.UserID);
                string mySessionKeys = myUserID + "_" + this.GetType().ToString();

                return mySessionKeys;
            }
        }
        public static void GetSessionTo(ref T entity)
        {
            LoginInfo login = new LoginInfo();
            LoginInfo.GetSessionTo(ref login);
            string myUserID = (login == null ? string.Empty : login.UserID);
            string mySessionKeys = myUserID + "_" + entity.GetType().ToString();

            if (HttpContext.Current.Session[mySessionKeys] == null)
                entity = null;
            else
                entity = HttpContext.Current.Session[mySessionKeys] as T;
        }
    }
}
