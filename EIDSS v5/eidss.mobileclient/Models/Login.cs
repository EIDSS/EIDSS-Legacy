using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bv.common.Configuration;
using bv.common.Core;
using eidss.mobileclient.Utils;
using eidss.model.Core;
using eidss.model.Core.Security;

namespace eidss.mobileclient.Models
{
    public class Login
    {
        public Login()
        {
            
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
                        new SelectListItem { Text = Localizer.GetMenuLanguageName(c), Value = Localizer.SupportedLanguages[c] }
                        )
                    );
            }
        }

        public string ErrorMessage { get; set; }

        public bool Authorize()
        {
            var security = new EidssSecurityManager();
            var result = security.LogIn(Organization, UserName, Password);
            if (result == 0) //authorized
            {
                //set current language
                EidssUserContext.CurrentLanguage = Cultures.GetLanguageAbbreviation(LanguagePreference);
                System.Web.Security.FormsAuthentication.SetAuthCookie(this.UserName, false);
                HttpContext.Current.Session["UserName"] = UserName;
                return true;
            }
            else
            {
                ErrorMessage = SecurityMessages.GetLoginErrorMessage(result);
                return false;
            }

        }
    }
}
