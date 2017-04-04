using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using bv.common.Core;
using bv.model.Model.Core;
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
using System.Web.UI;
using System.Text;
using bv.common.Resources;
using eidss.model.Resources;

namespace eidss.webclient.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        private static readonly int LifetimeSeconds = Config.GetIntSetting("LifetimeSeconds", 1200);

        public ActionResult Heartbeat(long id)
        {
            int iResult = 0;
            string urlToRedirect = "";
            if (id > 0)
            {
                //ModelStorage.Heartbeat(ModelUserContext.ReadonlyWebClientID, id);
                ObjectStorage.Heartbeat(ModelUserContext.ReadonlyWebClientID, id);
            }
            if (Request.Cookies["LastAccess"] != null)
            {
                DateTime dateLastAccess;
                if (DateTime.TryParseExact(Request.Cookies["LastAccess"].Value, "yyyy-MM-ddTHH:mm:ss", null, DateTimeStyles.None, out dateLastAccess))
                {
                    if ((DateTime.Now - dateLastAccess).TotalSeconds > LifetimeSeconds)
                    {
                        MenuHelper.ClearMenuCache();
                        LoginHelper.Logout(this);
                        iResult = 1;
                    }
                }
            }

            if (iResult == 0)
            {
                if (eidss.model.Core.EidssUserContext.User != null && !String.IsNullOrEmpty(eidss.model.Core.EidssUserContext.User.FullName))
                {
                    if (EidssUserContext.CurrentLanguage != Cultures.GetLanguageAbbreviation(Thread.CurrentThread.CurrentUICulture.Name))
                    {
                        string strLangToRedirect = Cultures.GetCulture(EidssUserContext.CurrentLanguage);
                        urlToRedirect = "/" + strLangToRedirect + "/";
                        for (int i = 2; i < Request.UrlReferrer.Segments.Length; i++)
                        {
                            urlToRedirect += Request.UrlReferrer.Segments[i];
                        }
                        urlToRedirect += Request.UrlReferrer.Query;

                        iResult = 2;
                    }
                }
            }

            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new { result = iResult, url = urlToRedirect } };
        }


        private static List<string> g_ResKeys = new List<string>() { 
            "errUnknownError",
            "ErrObjectCantBeDeleted",
            "ErrWebTemporarilyUnavailableFunction",
            "titleHumanAggregateCasesList",
            "titleVetAggregateCasesList",
            "titleVetAggregateActionsList",
            "titleAddDisease",
            "AsCampaign_GetSessionRemovalConfirmation",
            "titleSelectCampaign",
            "titleASSessionList",
            "titleAddDisease",
            "Species",
            "titleAnimalSampleInfo",
            "titleAnimalsSamplesInfo",
            "titleAction",
            "titleCopySample",
            "msgTooManyDiagnosis",
            "notFoundMessageKey",
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
            "titleEmployeeList",
            "noEmployeeSelectedErrorMessage",
            "titleEmployeeDetails",
            "titleSelectFarm",
            "AddParameter",
            "titleGeoLocation",
            "titleAntibiotic",
            "titleDuplicates",
            "msgWrongDiagnosis",
            "titleDiagnosisHistory",
            "titleDiagnosisChange",
            "strChangeDiagnosisReason_msgId",
            "ErrWebTemporarilyUnavailableFunction",
            "titleHumanCaseList",
            "titleCreateAliquot",
            "titleCreateDerivative",
            "titleTransferOutSample",
            "titleStartTest",
            "titleSetTestResult",
            "titleValidateTestResult",
            "titleSetAccessionDate",
            "titleAccessionInComment",
            "titleTestResultChange",
            "menuAssignTest",
            "titleCreateSample",
            "titleGroupAccessionIn",
            "tabTitleSampleTest",
            "strInfo",
            "strMap",
            "titleOrganizationList",
            "titleOutbreakList",
            "titleHumanCaseList",
            "titleVeterinaryCaseList",
            "titleVsSessionList",
            "titleOutbreakNote",
            "ErrAllMandatoryFieldsRequired",
            "msgComparativeReportIQCorrectYear",
            "msgComparativeReportTHCorrectYear",
            "titlePersonsList",
            "titleContactInformation",
            "titleResultSummary",
            "titleSampleDetails",
            "titleTestResultDetails",
            "titleTestDetails",
            "titlePensideTest",
            "msgTooBigRecordsCount",
            "strSearchPanelMandatoryFields_msgId",
            "titleVaccination",
            "titleAnimals",
            "titleClinicalSigns",
            "titleVeterinaryCaseList",
            "Species",
            "titleClinicalInvestigation",
            "titleVetCaseLog",
            "titleVsSessionList",
            "titleCopyVector",
            "titleVectorFieldTestDetails",
            "titleDetectedDisease",
            "msgRemoveCaseFromOutbreak",
            "msgNotPossibleToSave",
            "btTitleFindInPersonIdentityService",
            "btTitleFindInPersonIdentityServiceGG",
            "msgRestoreToDefault",
            "msgExternalComparativeReportCorrectYear",
            "msgInfectiousDiseasesCorrectDate",
            "msgReportAzSamplesNotFound",
            "msgReportAzCaseNotFound",
            "titleSystemPreferences",
            "msgAskRestoreToDefault",
            "msgExternalComparativeReportCorrectYear",
            "msgReportAzCaseNotFound",
            "msgTooManySpeciesType",
            "msgTooCheckedItems",
            "msgReportAzSampleNotFound",
            "msgReportAzDepartmentsNotFound"
        };
        [OutputCache(Location = OutputCacheLocation.Client, NoStore = false, Duration = 60000)]
        public ActionResult MessagesScript(string version)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("var EIDSS = { BvMessages: {");
            g_ResKeys.ForEach(key => {
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

        public ActionResult Incomliance(string url)
        {
            ViewBag.UrlToRedirect = url;
            return View();
        }

        [HttpPost]
        public ActionResult Incomliance(FormCollection form)
        {
            string url = form["urlToRedirect"];
            return new RedirectResult(url);
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
        public ActionResult CheckTranslation(string id, string split, string classname)
        {
            string[] keys = id.Split('*');
            string page = keys[0];
            string locale = keys[1];
            string resname = keys[2];
            string reskey = keys[3];

            TranslatorContainer model = TranslationToolOnlineStorage.GetTranslated(classname);
            TranslatorItem item = model.FirstOrDefault(c => c.Key == id);
            if (item != null)
            {
                try
                {
                    TranslationToolOnlineStorage.SetTranslated(item);
                }
                catch(Exception)
                {
                    return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = -1 };
                }
            }

            int bAccept = (split == "true") ? 0 : (WebResourceUsage.Instance.DisplayResourceUsage(page, "", resname, reskey, reskey) == ResourceAction.Accept ? 0 : 1);
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
