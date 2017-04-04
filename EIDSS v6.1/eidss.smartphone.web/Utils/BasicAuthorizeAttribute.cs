using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using bv.common.Core;
using bv.common.Resources;
using eidss.model.Core;
using eidss.model.Core.Security;
using eidss.model.Enums;
using System.Globalization;

namespace eidss.smartphone.web.Utils
{
    // http://kevin-junghans.blogspot.ru/2013/02/mixing-forms-authentication-basic.html

    [AttributeUsageAttribute(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class BasicAuthorizeAttribute : AuthorizeAttribute
    {
        public EIDSSPermissionObject[] InsertPermission { get; set; }
        public EIDSSPermissionObject[] UpdatePermission { get; set; }

        private const string Realm = "eidss.smartphone.web.api";

        private enum AuthType { basic, cookie };

        private string DecodeFrom64(string encodedData)
        {
            byte[] encodedDataAsBytes = System.Convert.FromBase64String(encodedData);
            string returnValue = System.Text.Encoding.ASCII.GetString(encodedDataAsBytes);
            return returnValue;
        }

        private bool GetUserNameAndPassword(HttpActionContext actionContext, out string orgname, out string username, out string password, out AuthType authType)
        {
            authType = AuthType.basic;
            bool gotIt = false;
            orgname = string.Empty;
            username = string.Empty;
            password = string.Empty;
            IEnumerable<string> headerVals;
            if (actionContext.Request.Headers.TryGetValues("Authorization", out headerVals))
            {
                try
                {
                    string authHeader = headerVals.FirstOrDefault();
                    char[] delims = { ' ' };
                    string[] authHeaderTokens = authHeader.Split(new char[] { ' ' });
                    if (authHeaderTokens[0].Contains("Basic"))
                    {
                        string decodedStr = DecodeFrom64(authHeaderTokens[1]);
                        string[] unpw = decodedStr.Split(new char[] { ':' });
                        string usernameAndOrg = unpw[0];
                        string[] usernameAndOrgs = usernameAndOrg.Split(new char[] { '@' });
                        orgname = usernameAndOrgs[0];
                        username = usernameAndOrgs[1];
                        password = unpw[1];
                    }
                    else
                    {
                        if (authHeaderTokens.Length > 1)
                            username = DecodeFrom64(authHeaderTokens[1]);
                        authType = AuthType.cookie;
                    }

                    gotIt = true;
                }
                catch { gotIt = false; }
            }

            return gotIt;
        }

        public string ErrorMessage { get; set; }

        private bool CheckPassword(string org, string username, string password)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Localizer.SupportedLanguages[bv.common.Core.Localizer.lngEn]);
            Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture;
            var security = new EidssSecurityManager();
            var result = security.LogIn(org, username, password);
            switch (result)
            {
                case 0:
                    EidssUserContext.CurrentLanguage = bv.common.Core.Localizer.lngEn;
                    EidssUserContext.SmartphoneContext = true;
                    return true;
                case 6:
                    int lockInMinutes = security.GetAccountLockTimeout(org, username);
                    string err = BvMessages.Get("ErrLoginIsLocked", "You have exceeded the number of incorrect login attempts. Please try again in {0} minutes.");
                    ErrorMessage = string.Format(err, lockInMinutes);
                    return false;
                case 9:
                    ErrorMessage = BvMessages.Get("ErrPasswordExpiredToSmartphone", "Your password has expired. Please specify a new password on web or desktop.");
                    return false;
                default:
                    ErrorMessage = SecurityMessages.GetLoginErrorMessage(result);
                    return false;
            }
        }

        private bool Authenticate(HttpActionContext actionContext)
        {
            bool isAuthenticated = false;
            string orgname = string.Empty;
            string username = string.Empty;
            string password = string.Empty;
            AuthType authenticationType;

            if (GetUserNameAndPassword(actionContext, out orgname, out username, out password, out authenticationType))
            {

                if (authenticationType == AuthType.basic)
                {
                    isAuthenticated = CheckPassword(orgname, username, password);
                }
                else //authType == cookie
                {
                    isAuthenticated = false;
                }
            }
            else
            {
                actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            }

            return isAuthenticated;
        }

        private bool Check(string permission)
        {
            return permission == null || EidssUserContext.User.HasPermission(permission) == true;
        }

        private bool isAuthorized()
        {
            bool authorized =
                (InsertPermission == null || InsertPermission.Aggregate(true, (r,c) => r && Check(PermissionHelper.InsertPermission(c)))) &&
                (UpdatePermission == null || UpdatePermission.Aggregate(true, (r, c) => r && Check(PermissionHelper.UpdatePermission(c))));

            return authorized;
        }

        private string EncodeTo64(string data)
        {
            return System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("UTF-8").GetBytes(data));
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (Authenticate(actionContext))
            {
                if (!isAuthorized())
                    actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);
            }
            else
            {
                actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
                actionContext.Response.Headers.Add("WWW-Authenticate", string.Format("Basic realm=\"{0}\"", Realm));
                if (!string.IsNullOrEmpty(ErrorMessage))
                {
                    actionContext.Response.Headers.Add("ErrorMessage", EncodeTo64(ErrorMessage));
                }
            }
        }
    }
}