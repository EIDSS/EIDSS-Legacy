using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using bv.common.Core;
using bv.common.Resources;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.model.Core.Security;
using eidss.model.Resources;
using eidss.model.Schema;
using eidss.openapi.contract;
using eidss.openapi.bll.Converters;
using eidss.openapi.bll.Exceptions;

namespace eidss.openapi.bll.Bll
{
    public class LoginBll
    {
        public static Dictionary<string, string> SupportedExternalSystem = new Dictionary<string, string>()
            {
                { "HMIS", "" },
                { "e-TB", "" }
            };

        public static void Authorize(Login login)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Localizer.SupportedLanguages[bv.common.Core.Localizer.lngEn]);
            Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture;

            if (string.IsNullOrEmpty(login.language) || !Localizer.SupportedLanguages.ContainsKey(login.language))
                throw new AuthLanguageException();

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Localizer.SupportedLanguages[login.language]);
            Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture;

            if (!string.IsNullOrEmpty(login.externalSystem) && !SupportedExternalSystem.ContainsKey(login.externalSystem))
                throw new AuthExternalException();

            var security = new EidssSecurityManager();
            var result = security.LogIn(login.organization, login.user, login.password);
            switch (result)
            {
                case 0:
                    break;
                case 1:
                    throw new AuthEmptyException();
                case 2:
                    throw new AuthNotFoundException();
                case 3:
                case 4:
                case 5:
                    throw new AuthVersionException();
                case 6:
                    throw new AuthLockedException(security.GetAccountLockTimeout(login.organization, login.user));
                case 9:
                    throw new AuthExpiredException();
                default:
                    throw new AuthFailedException();
            }

            EidssUserContext.CurrentLanguage = login.language;
        }
    }
}