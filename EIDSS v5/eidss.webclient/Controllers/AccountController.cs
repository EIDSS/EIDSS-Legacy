using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using bv.common.Configuration;
using bv.model.BLToolkit;
using eidss.model.Core;
using eidss.webclient.Models;
using eidss.webclient.Utils;
using System.Web.Security;

namespace eidss.webclient.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult Login()
        {
            var culture = Url.RequestContext.RouteData.Values.ContainsKey("culture") ? Url.RequestContext.RouteData.Values["culture"] : "en-US";
            ViewBag.SelectedLanguage = culture == null ? "en-US" : Url.RequestContext.RouteData.Values["culture"].ToString();
            return View(new eidss.webclient.Models.Login());
        }

        [Authorize]
        public ActionResult Home()
        {
            return View();
        }

        [Authorize]
        public ActionResult Actual()
        {
            EidssUserContext.Instance.ResetArchiveMode();
            EidssUserContext.Instance.CurrentUser.RestoreWritePermissions();
            MenuHelper.ClearMenuCache();
            return View();
        }

        [Authorize]
        public ActionResult Archive()
        {
            var m_ConnectionCredentials = new ConnectionCredentials(null, "Archive");
            EidssUserContext.Instance.SetArchiveMode(m_ConnectionCredentials.ConnectionString);
            EidssUserContext.Instance.CurrentUser.RevokeWritePermissions();
            MenuHelper.ClearMenuCache();
            return View();
        }

        [Authorize]
        public ActionResult About()
        {
            return View();
        }

        public ActionResult ChangePassword(string organization, string userName)
        {
            var model = new Login { Organization = organization, UserName = userName };
            return View(model);
        }

        [HttpPost]
        public ActionResult ChangePassword(Login login)
        {
            if (login.ChangePassword())
            {
                login.ErrorMessage = "closewin";
                return View(login);
            }
            
            return View(login);
        }

        [Authorize]
        public ActionResult Logout()
        {
            MenuHelper.ClearMenuCache();
            FormsAuthentication.SignOut();
            Session.Abandon();
            //System.Web.HttpContext.Current.Response.Cookies.Remove(FormsAuthentication.FormsCookieName);
            //return RedirectToAction("Login");

            // clear authentication cookie
            HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie1.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie1);

            // clear session cookie 
            HttpCookie cookie2 = new HttpCookie("ASP.NET_SessionId", "");
            cookie2.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie2);

            return RedirectToAction("Login");
        }

        [HttpPost]
        public ActionResult Login(Login login)
        {
            string returnUrl =/* Request["ReturnUrl"] ??*/ "/en-US/Account/Home";

            bool isAvr = false;
            if (!String.IsNullOrWhiteSpace(Request["ReturnUrl"]))
            {
                isAvr = Request["ReturnUrl"].Contains("AVR");
            }


            if (login.Authorize())
            {
                MenuHelper.ClearMenuCache();
                HttpCookie avrCookie = FormsAuthentication.GetAuthCookie(login.UserName, false);
                avrCookie.Domain = GetAvrPath();
                Response.AppendCookie(avrCookie);

                if (isAvr)
                {
                    return Redirect(String.Format("{0}?lang={1}", returnUrl, login.LanguagePreference));
                }
                else
                {
                    string adj = returnUrl.Replace("/", "");
                    if (!Cultures.StringIsCulture(adj))
                    {
                        returnUrl = returnUrl.Substring(returnUrl.Substring(1).IndexOf("/") + 1);
                    }
                    else
                    {
                        returnUrl = returnUrl.Replace(adj, "");
                    }

                    return Redirect(String.Format("/{0}{1}", login.LanguagePreference, returnUrl));
                }
            }

            return View(login);
        }

        private string GetAvrPath()
        {
            string port = Request.Url.IsDefaultPort ? "" : ":" + Request.Url.Port;
            string domainPath = Request.Url.Scheme + Uri.SchemeDelimiter + Request.Url.Host + port;
            return string.Format("{0}/{1}", domainPath, Config.GetSetting("AvrVirtualDirectoryName"));
        }

    }
}
