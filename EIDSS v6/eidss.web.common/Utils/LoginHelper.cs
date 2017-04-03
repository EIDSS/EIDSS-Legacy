using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace eidss.web.common.Utils
{
    public class LoginHelper
    {
        public static void Logout(Controller controller)
        {
            ModelStorage.Remove(controller.Session.SessionID);
            FormsAuthentication.SignOut();

            /*
                То что закомментарено ниже - попытка обойти странную проблему "засыпания" на 5 минут всего вебсервера
            */
            /*
            controller.Session.Abandon();
            
            // clear authentication cookie
            HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie1.Expires = DateTime.Now.AddYears(-1);
            controller.Response.Cookies.Add(cookie1);

            // clear session cookie 
            HttpCookie cookie2 = new HttpCookie("ASP.NET_SessionId", "");
            cookie2.Expires = DateTime.Now.AddYears(-1);
            controller.Response.Cookies.Add(cookie2);
            */
        }
    }
}
