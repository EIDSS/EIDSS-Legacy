using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Globalization;
using System.Web.Mvc;

using bv.common.Resources;
using bv.common.Core;
using bv.common.Configuration;

using eidss.model.Core;
using eidss.model.Core.Security;
using eidss.smartphone.web.Utils;
using eidss.web.common.Utils;

namespace eidss.smartphone.web.Models
{
    public class LoginModel
    {
        public LoginModel()
        {
            //Organization = "NCDC&PH";//"CRL";
            //UserName = "test_admin";
        }

        [LocalizedDisplayName("Organization")]
        public string Organization { get; set; }

        [LocalizedDisplayName("Login")]
        public string UserName { get; set; }

        [LocalizedDisplayName("Password")]
        public string Password { get; set; }

        [LocalizedDisplayName("PreferredLanguage")]
        public string LanguagePreference { get; set; }


        public List<SelectListItem> SupportedLanguages
        {
            get
            {
                string[] langs = Config.GetSetting("SupportedLanguages", Localizer.SupportedLanguages.Keys.Aggregate("", (s, i) => s + "," + i)).Split(',');
                return new List<SelectListItem>(
                    Localizer.SupportedLanguages.Keys.Intersect(langs).Select(c =>
                        new SelectListItem { Text = Localizer.GetMenuLanguageName(c), Value = CustomCultureHelper.GetCustomCultureName(c) }
                        )
                    );
            }
        }

        public string ErrorMessage { get; set; }

        public bool Authorize()
        {
            var security = new EidssSecurityManager();
            var result = security.LogIn(Organization, UserName, Password);/*,
                () =>
                    {
                    },
                () =>
                    {
                        EidssUserContext.CurrentLanguage = Cultures.GetLanguageAbbreviation(LanguagePreference);
                        System.Web.Security.FormsAuthentication.SetAuthCookie(UserName, false);
                    });*/
            switch (result)
            {
                case 0:
                    var clientId = Guid.NewGuid().ToString();
                    if (HttpContext.Current.Response.Cookies["ClientID"] != null)
                        HttpContext.Current.Response.Cookies["ClientID"].Value = clientId;
                    else
                        HttpContext.Current.Response.Cookies.Add(new HttpCookie("ClientID", clientId));


                    EidssUserContext.CurrentLanguage = Cultures.GetLanguageAbbreviation(LanguagePreference);
                    FormsAuthentication.SetAuthCookie(UserName, false);
                    return true;
                case 6:
                    int lockInMinutes = security.GetAccountLockTimeout(this.Organization, this.UserName);
                    string err = BvMessages.Get("ErrLoginIsLocked", "You have exceeded the number of incorrect login attempts. Please try again in {0} minutes.");
                    ErrorMessage = string.Format(err, lockInMinutes);
                    return false;
                default:
                    ErrorMessage = SecurityMessages.GetLoginErrorMessage(result);
                    return false;
            }

        }
    }
}
