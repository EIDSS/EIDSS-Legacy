using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eidss.mobileclient.Models;
using eidss.mobileclient.Utils;
using System.Web.Security;
using eidss.model.Core;
using eidss.model.Schema;
using System.Web.UI;
using System.Text;
using bv.common.Resources;
using eidss.model.Resources;

namespace eidss.mobileclient.Controllers
{
    public class AccountController : Controller
    {
        private static List<string> g_ResKeys = new List<string>() { 
            "errInternetConnection",
            "errAjaxRequestException",
            "msgConfimation",
            "strOK_Id",
            "strCancel_Id",
            "Error",
            "msgSavePrompt",
            "msgCancelPrompt",
            "msgOKPrompt",
            "msgDeletePrompt",
            "msgClosePrompt",
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
        // GET: /Account/

        public ActionResult Login()
        {
            return View(new eidss.mobileclient.Models.Login());
        }

        public ActionResult MainMenu()
        {
            ViewBag.Title = Translator.GetMessageString("titleMainMenu");
            HumanCase.Accessor humanCaseAccessor = HumanCase.Accessor.Instance(null);
            VetCase.Accessor vetCaseAccessor = VetCase.Accessor.Instance(null);
            ViewBag.IsHumanModuleVisible = humanCaseAccessor.CanSelect || humanCaseAccessor.CanInsert || humanCaseAccessor.CanUpdate;
            ViewBag.IsVetModuleVisible = vetCaseAccessor.CanSelect || vetCaseAccessor.CanInsert || vetCaseAccessor.CanUpdate;
            return View();
        }
        
        public ActionResult Logout()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            System.Web.HttpContext.Current.Response.Cookies.Remove(FormsAuthentication.FormsCookieName);
            return Redirect(Url.Action("Login"));
        }

        [HttpPost]
        public ActionResult Login(Login login)
        {
            string returnUrl = Request["ReturnUrl"] ?? "/en-US/Account/MainMenu";
            if (login.Authorize())
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
            return View(login);
        }
    }
}
