using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using bv.common.Resources;
using eidss.model.Core;
using eidss.model.Core.Security;
using System.Globalization;
using bv.common.Core;

namespace eidss.smartphone.web.Models
{
    public class LoginModel
    {
        public LoginModel()
        {
            //Organization = "NCDC&PH";//"CRL";
            //UserName = "test_admin";
        }

        [Required]
        [Display(Name = "Organization")]
        public string Organization { get; set; }

        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public bool Authorize()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Localizer.SupportedLanguages[bv.common.Core.Localizer.lngEn]);
            Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture;
            var security = new EidssSecurityManager();
            var result = security.LogIn(Organization, UserName, Password);
            switch (result)
            {
                case 0:
                    EidssUserContext.CurrentLanguage = bv.common.Core.Localizer.lngEn;
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