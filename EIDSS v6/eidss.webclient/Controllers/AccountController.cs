using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using bv.common.Core;
using bv.model.ResourcesUsage;
using bv.common.Configuration;
using bv.common.Resources.TranslationTool;
using bv.model.BLToolkit;
using eidss.model.Core;
using eidss.model.Core.Security;
using eidss.model.Enums;
using eidss.webclient.Models;
using eidss.webclient.Utils;
using System.Web.Security;
using eidss.web.common.Utils;

namespace eidss.webclient.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        private static readonly int LifetimeSeconds = Config.GetIntSetting("LifetimeSeconds", 1200);
        //[HttpPost]
        public ActionResult Heartbeat(long id)
        {
            bool isTimeout = false;
            /*if (id != 0)
            {
                if (!ModelStorage.Heartbeat(Session.SessionID, id))
                {
                    MenuHelper.ClearMenuCache();
                    LoginHelper.Logout(this);
                    isTimeout = true;
                }
            }*/
            if (Session["LastAccess"] != null)
            {
                var dateLastAccess = Session["LastAccess"] as DateTime?;
                if (dateLastAccess.HasValue)
                {
                    if ((DateTime.Now - dateLastAccess.Value).TotalSeconds > LifetimeSeconds)
                    {
                        MenuHelper.ClearMenuCache();
                        LoginHelper.Logout(this);
                        isTimeout = true;
                    }
                }
            }
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = isTimeout };
        }


        public ActionResult Login()
        {
            SetSelectedLanguage();
            return View(new eidss.webclient.Models.Login());
        }

        [HttpPost]
        public ActionResult Login(Login login)
        {
            string returnUrl =/* Request["ReturnUrl"] ??*/ "/en-US/Account/Home";

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


        [HttpPost]
        public ActionResult ChangePassword(Login login)
        {
            if (login.ChangePassword())
            {
                login.ErrorMessage = "success";
                return View(login);
            }

            return View(login);
        }

        public ActionResult ChangePassword(string organization, string userName)
        {
            var model = new Login { Organization = organization, UserName = userName };
            return View(model);
        }


        
        [AuthorizeEIDSS]
        public ActionResult Home()
        {
            return View();
        }

        [AuthorizeEIDSS]
        public ActionResult Actual()
        {
            EidssUserContext.Instance.ResetArchiveMode();
            EidssUserContext.Instance.CurrentUser.RestoreWritePermissions();
            MenuHelper.ClearMenuCache();
            return View();
        }

        [AuthorizeEIDSS]
        public ActionResult Archive()
        {
            var m_ConnectionCredentials = new ConnectionCredentials(null, "Archive");
            //DbManagerFactory.SetSqlFactory(m_ConnectionCredentials.ConnectionString);
            EidssUserContext.Instance.SetArchiveMode(m_ConnectionCredentials.ConnectionString);
            EidssUserContext.Instance.CurrentUser.RevokeWritePermissions();
            MenuHelper.ClearMenuCache();
            return View();
        }

        [AuthorizeEIDSS]
        public ActionResult About()
        {
            return View();
        }

        [AuthorizeEIDSS]
        public ActionResult Logout()
        {
            MenuHelper.ClearMenuCache();
            LoginHelper.Logout(this);

            return RedirectToAction("Login");
        }



        [AuthorizeEIDSS]
        public ActionResult LaunchAVR()
        {
            var culture = Url.RequestContext.RouteData.Values.ContainsKey("culture") ? Url.RequestContext.RouteData.Values["culture"].ToString() : "en-US";
            var login = new EidssSecurityManager();
            var ticket = login.CreateTicket((long)EidssUserContext.User.ID);

            string url = Config.GetSetting("AvrUrl");
            var avrUrl = string.Format("{0}?ticket={1}&lang={2}", url, ticket, culture);
            return Redirect(avrUrl);
        }

        [AuthorizeEIDSS]
        public ActionResult LaunchAVRReport(long queryId, long layoutId)
        {
            var culture = Url.RequestContext.RouteData.Values.ContainsKey("culture") ? Url.RequestContext.RouteData.Values["culture"].ToString() : "en-US";
            var login = new EidssSecurityManager();
            var ticket = login.CreateTicket((long)EidssUserContext.User.ID);
            string url = Config.GetSetting("AvrUrl");
            var avrUrl = string.Format("{0}/Account/Layout?queryId={1}&layoutId={2}&ticket={3}&lang={4}", url, queryId, layoutId, ticket, culture);
            return Redirect(avrUrl);
        }

        [AuthorizeEIDSS]
        [HttpPost]
        public ActionResult RequestReplication()
        {
            ForcedReplicationClient.Instance.StartReplication();
            // for debug
            //ForcedReplicationClient.Instance.CreateClientEvent(EventType.ForcedReplicationExpired, -1);
            //ForcedReplicationClient.Instance.CreateClientEvent(EventType.ForcedReplicationConfirmed, -1);
            return new EmptyResult();
        }

        [AuthorizeEIDSS]
        [HttpGet]
        public ActionResult GetReplicationStatus()
        {
            var evnts = ForcedReplicationClient.Instance.GetReplicationEvents();
            if (evnts == null || evnts.Length == 0)
                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new { isFinished = false } };

            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, 
                Data = new { isFinished = true, messages = evnts.Select(c => new { message = c["EventName"].ToString(), messageDateTime = c["datEventDatatime"].ToString() }).ToArray() } };
        }


        #region Translation
        [HttpGet]
        public ActionResult Translation(string aspclassname)
        {
            ViewBag.AspClassname = aspclassname;
            return View();//model);
        }

        public ActionResult _SelectTranslationAjaxEditing([DataSourceRequest]DataSourceRequest request, string classname)
        {
            TranslatorContainer model = TranslationToolOnlineStorage.GetTranslated(classname);
            var result = model.Where(c => c.IsValueExists).ToDataSourceResult(request);
            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult _SaveTranslationAjaxEditing([DataSourceRequest]DataSourceRequest request, TranslatorItem item, string classname)
        {
            if (item != null && ModelState.IsValid)
            {
                TranslatorContainer model = TranslationToolOnlineStorage.GetTranslated(classname);
                if (item.Split == "true")
                {
                    string[] keys = item.Key.Split('*');
                    string page = keys[0];
                    string locale = keys[1];
                    string resname = keys[2];
                    string reskey = keys[3];
                    ResourceSplitter.Split(page, resname, reskey, item.Val);
                }
                else
                {
                    TranslationToolOnlineStorage.SetTranslated(item);
                }
            }
            return Json(new[] { item }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CheckTranslation(string id, string split)
        {
            string[] keys = id.Split('*');
            string page = keys[0];
            string locale = keys[1];
            string resname = keys[2];
            string reskey = keys[3];
            bool bAccept = (split == "true") ? true : WebResourceUsage.Instance.DisplayResourceUsage(page, "", resname, reskey, reskey) == ResourceAction.Accept;
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = bAccept };
        }

        [HttpGet]
        public ActionResult ResourceUsage(string id)
        {
            string[] keys = id.Split('*');
            string page = keys[0];
            string locale = keys[1];
            string resname = keys[2];
            string reskey = keys[3];
            var ret = WebResourceUsage.Instance.ResourceUsageList(page, resname, reskey);
            return View(ret);
        }
        #endregion
    }
}
