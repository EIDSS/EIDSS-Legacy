using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.Resources.TranslationTool;
using bv.model.ResourcesUsage;
using eidss.avr.mweb.Models;
using eidss.avr.mweb.Utils;
using eidss.model.Core;
using eidss.model.Core.Security;
using eidss.web.common.Utils;
using System.Web.UI;
using System.Text;
using bv.common.Resources;
using eidss.model.Resources;

namespace eidss.avr.mweb.Controllers
{
    public class AccountController : Controller
    {
        private static readonly int LifetimeSeconds = Config.GetIntSetting("LifetimeSeconds", 1200);
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

        public ActionResult Timeout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Timeout(FormCollection form)
        {
            return new RedirectResult("/" + GetSelectedLanguage() + "/Account/Login");
        }


        private static List<string> g_ResKeys = new List<string>() { 
            "msgDeleteAggregateColumn",
            "errLoginMandatoryFields",
            "msgConfimation",
            "Error",
            "Warning",
            "ErrAuthentication",
            "msgSavePrompt",
            "msgCancelPrompt",
            "msgOKPrompt",
            "msgDeletePrompt",
            "strOK_Id",
            "strCancel_Id",
            "strYes_Id",
            "strNo_Id",
            "btHideCustomizationWindow",
            "btShowCustomizationWindow",
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



        public ActionResult Login(string ticket = null, string lang = null)
        {
            //return new RedirectResult("/" + Localizer.DefaultLanguageLocale + "/Account/LoginLang");
            string url = "/" + Localizer.DefaultLanguageLocale + "/Account/LoginLang";
            if (ticket != null && lang != null)
                url = string.Format("{0}?ticket={1}&lang={2}", url, ticket, lang);
            return new RedirectResult(url);
        }

        public ActionResult LoginLang(string ticket = null, string lang = null)
        {
            //LoginHelper.Logout(this);
            if (!string.IsNullOrEmpty(ticket))
            {
                EidssSecurityManager target = new EidssSecurityManager();
                int res = target.LogIn(ticket);
                
                if (res == 0)
                {
                    System.Web.Security.FormsAuthentication.SetAuthCookie(EidssUserContext.User.LoginName, false);
                    if (!string.IsNullOrEmpty(lang))
                        EidssUserContext.CurrentLanguage = Cultures.GetLanguageAbbreviation(lang);
                    return Redirect(String.Format("/{0}{1}", lang, "/QueryLayoutTree/QueryLayoutTree"));
                }
            }

            SetSelectedLanguage();
            return View(new eidss.avr.mweb.Models.Login());
        }
        
        
        [AuthorizeEIDSS]
        public ActionResult Layout(string queryId, string layoutId, string ticket, string lang)
        {
            if (!string.IsNullOrEmpty(ticket))
            {
                EidssSecurityManager target = new EidssSecurityManager();
                int res = target.LogIn(ticket);

                if (res == 0)
                {
                    System.Web.Security.FormsAuthentication.SetAuthCookie(EidssUserContext.User.LoginName, false);
                    if (!string.IsNullOrEmpty(lang))
                        EidssUserContext.CurrentLanguage = Cultures.GetLanguageAbbreviation(lang);
                    return Redirect(String.Format("/{0}{1}?queryId={2}&layoutId={3}", lang, "/Layout/Layout", queryId, layoutId));
                }
            }

            SetSelectedLanguage();
            return View("LoginLang", new eidss.avr.mweb.Models.Login());
        }

        [HttpPost]
        public ActionResult LoginLang(Login login)
        {
            string returnUrl =/* Request["ReturnUrl"] ??*/ "/en-US/QueryLayoutTree/QueryLayoutTree";

            bool isAvr = false;
            //if (!String.IsNullOrWhiteSpace(Request["ReturnUrl"]))
            //{
            //    isAvr = Request["ReturnUrl"].Contains("AVR");
            //}


            if (login.Authorize())
            {
                ObjectStorage.Remove(Session.SessionID);
                //MenuHelper.ClearMenuCache();
                HttpCookie avrCookie = FormsAuthentication.GetAuthCookie(login.UserName, false);
                //avrCookie.Domain = GetAvrPath();
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

            SetSelectedLanguage();
            return View(login);
        }

        [Authorize]
        public ActionResult Logout()
        {
            LoginHelper.Logout(this);

            return RedirectToAction("Login");
        }


        #region Translation

        public ActionResult Translation(string curClassName)
        {
            ViewBag.AppClassName = curClassName;
            return PartialView("TranslationToolDlg", TranslationToolOnlineStorage.GetTranslated(curClassName));
        }

        public ActionResult TranslationGridPartial(string curClassName)
        {
            return PartialView("TranslationToolGrid", TranslationToolOnlineStorage.GetTranslated(curClassName));
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult TranslationGridUpdatePartial(string curClassName, string curAccept)
        {
            var transes = TranslationToolOnlineStorage.GetTranslated(curClassName);
            string id = Request.Params["Key"];
            var item = transes.First(c => c.Key == id);
            item.Val = Request.Params["Val"];

            if (ModelState.IsValid)
            {
                try
                {
                    if (item.Split == "true" || curAccept != null)
                    {
                        if (curAccept == "split")
                            item.Split = "true";

                        SaveTranslated(item);
                    }
                    else
                    {
                        string[] keys = id.Split('*');
                        if (WebResourceUsage.Instance.DisplayResourceUsage(keys[0], "", keys[2], keys[3], keys[3]) != ResourceAction.Accept)
                        {
                            var list = WebResourceUsage.Instance.ResourceUsageList(keys[0], keys[2], keys[3]);
                            ViewData["EditError"] = " ";//"This term is used in other forms. Do you want to save the term translation?";
                            ViewData["EditableProduct"] = item;
                            ViewData["ResourceUsage"] = list;
                        }
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else {
                ViewData["EditError"] = "Please, correct all errors.";
                ViewData["EditableProduct"] = item;
            }


            return PartialView("TranslationToolGrid", transes);
        }

        [HttpGet]
        public ActionResult TranslationSplitGridPartial(string id)
        {
            string[] keys = id.Split('*');
            var ret = WebResourceUsage.Instance.ResourceUsageList(keys[0], keys[2], keys[3]);
            return View(ret);
        }

        private void SaveTranslated(TranslatorItem item)
        {
            if (item.Split == "true")
            {
                string[] keys = item.Key.Split('*');
                ResourceSplitter.Split(keys[0], keys[2], keys[3], item.Val);
            }
            else
            {
                TranslationToolOnlineStorage.SetTranslated(item);
            }
        }

        #endregion

        #region private functions
        private string GetSelectedLanguage()
        {
            var culture = Url.RequestContext.RouteData.Values.ContainsKey("culture") ? Url.RequestContext.RouteData.Values["culture"] : "en-US";
            return (culture == null) ? "en-US" : Url.RequestContext.RouteData.Values["culture"].ToString();
        }

        private void SetSelectedLanguage()
        {
            ViewBag.SelectedLanguage = GetSelectedLanguage();
        }
        #endregion
    }
}
