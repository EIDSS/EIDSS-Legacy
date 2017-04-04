using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using bv.common.Core;
using eidss.model.Core;
using eidss.smartphone.web.Models;
using eidss.smartphone.web.Utils;
using eidss.web.common.Utils;
using System.Web.UI;
using System.Text;
using bv.common.Resources;
using eidss.model.Resources;

namespace eidss.smartphone.web.Controllers
{
    public class AccountController : Controller
    {
        private static readonly int LifetimeSeconds = bv.common.Configuration.Config.GetIntSetting("LifetimeSeconds", 1200);
        public ActionResult Heartbeat()
        {
            bool isTimeout = false;
            if (Session["LastAccess"] != null)
            {
                var dateLastAccess = Session["LastAccess"] as DateTime?;
                if (dateLastAccess.HasValue)
                {
                    if ((DateTime.Now - dateLastAccess.Value).TotalSeconds > LifetimeSeconds)
                    {
                        LoginHelper.Logout(this);
                        isTimeout = true;
                    }
                }
            }
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = isTimeout };
        }



        private static List<string> g_ResKeys = new List<string>() { 
            "errUnknownError",
            "ErrObjectCantBeDeleted",
            "ErrWebTemporarilyUnavailableFunction",
            "errLoginMandatoryFields",
            "msgConfimation",
            "Error",
            "Warning",
            "ErrAuthentication",
            "msgSavePrompt",
            "msgUnsavedRecordsPrompt",
            "msgCancelPrompt",
            "msgOKPrompt",
            "msgDeletePrompt",
            "msgDeleteRecordPrompt",
            "strOK_Id",
            "strCancel_Id",
            "strYes_Id",
            "strNo_Id",
            "strInfo",
            "uploadFile",
        };
        [OutputCache(Location = OutputCacheLocation.Client, NoStore = false, Duration = 60000)]
        public ActionResult MessagesScript(string version)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("var EIDSS = { BvMessages: {");
            g_ResKeys.ForEach(key =>
            {
                string val = BvMessages.Get(key);
                if (val == null || val == key)
                    val = EidssMessages.Get(key);
                if (val == null || val == key)
                    val = EidssFields.Get(key);
                if (val == null || val == key)
                    val = EidssMenu.Get(key, null);
                if (val == null || val == key)
                    val = key;
                val = val.Replace("'", "\\'");
                sb.AppendFormat("'{0}': '{1}',", key, val);
                sb.AppendLine();
            });
            sb.AppendLine("} }");
            return JavaScript(sb.ToString());
        }


        //
        // GET: /Account/Login

        public ActionResult Login()
        {
            SetSelectedLanguage();
            return View(new eidss.smartphone.web.Models.LoginModel());
        }

        [HttpPost]
        public ActionResult Login(LoginModel login)
        {
            string returnUrl =/* Request["ReturnUrl"] ??*/ "/en-US/Home/Index";

            EidssUserContext.Instance.ResetArchiveMode();
            if (login.Authorize())
            {
                MenuHelper.ClearMenuCache();

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

            SetSelectedLanguage();
            return View(login);
        }

        public ActionResult Timeout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Timeout(FormCollection form)
        {
            return new RedirectResult("/" + GetSelectedLanguage() + "/Account/Login");
        }

        public ActionResult ReLogin()
        {
            return new RedirectResult("/" + Localizer.DefaultLanguageLocale + "/Account/Login");
        }

        private string GetSelectedLanguage()
        {
            var culture = Url.RequestContext.RouteData.Values.ContainsKey("culture") ? Url.RequestContext.RouteData.Values["culture"] : "en-US";
            return (culture == null) ? "en-US" : Url.RequestContext.RouteData.Values["culture"].ToString();
        }

        private void SetSelectedLanguage()
        {
            ViewBag.SelectedLanguage = GetSelectedLanguage();
        }

        [AuthorizeEIDSS]
        public ActionResult About()
        {
            return View();
        }

        [Authorize]
        public ActionResult Logout()
        {
            MenuHelper.ClearMenuCache();
            LoginHelper.Logout(this);

            return RedirectToAction("Login");
        }

        //
        // POST: /Account/LogOff

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

    }
}
