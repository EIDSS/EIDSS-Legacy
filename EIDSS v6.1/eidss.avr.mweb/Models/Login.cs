using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using bv.common.Configuration;
using bv.common.Core;
using eidss.model.Core;
using eidss.model.Core.Security;
using eidss.web.common.Utils;
using eidss.avr.mweb.Utils;
using bv.common.Resources;

namespace eidss.avr.mweb.Models
{
    public class Login
    {
        public Login()
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

        [LocalizedDisplayName("OldPassword")]
        public string OldPassword { get; set; }

        [LocalizedDisplayName("NewPassword")]
        public string NewPassword { get; set; }

        [LocalizedDisplayName("ConfirmPassword")]
        public string ConfirmPassword { get; set; }


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

        public bool ChangePassword()
        {
            ErrorMessage = PasswordValidatorHelper.ChangePassword(Organization, UserName, OldPassword, NewPassword,
                                                                 ConfirmPassword);
            return ErrorMessage == null;
        }

        /*public bool ValidateOnChange()
        {
            if (NewPassword != ConfirmPassword)
            {
                ErrorMessage = Translator.GetMessageString("msgConfirmPasswordError");
                return false;
            }
            var security = new EidssSecurityManager();
            var result = security.LogIn(Organization, UserName, OldPassword);
            if (result == 0) //authorized
            {                
                return true;
            }
            else
            {
                ErrorMessage = SecurityMessages.GetLoginErrorMessage(result);
                return false;
            }            
        }*/

        public bool Authorize()
        {
            var security = new EidssSecurityManager();
            var result = security.LogIn(Organization, UserName, Password);
            switch (result)
            {
                case 0:
                    EidssUserContext.CurrentLanguage = Cultures.GetLanguageAbbreviation(LanguagePreference);
                    System.Web.Security.FormsAuthentication.SetAuthCookie(this.UserName, false);
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
