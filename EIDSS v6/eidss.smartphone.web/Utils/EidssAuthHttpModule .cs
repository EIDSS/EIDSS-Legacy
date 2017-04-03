using eidss.model.Core;
using eidss.model.Core.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;

namespace eidss.smartphone.web.Utils
{
    /*
    public class EidssAuthHttpModule : IHttpModule
    {
        private const string Realm = "eidss.smartphone.web.api";

        public void Init(HttpApplication context)
        {
            // Register event handlers
            context.AuthenticateRequest += OnApplicationAuthenticateRequest;
            context.EndRequest += OnApplicationEndRequest;
        }

        private static void SetPrincipal(IPrincipal principal)
        {
            Thread.CurrentPrincipal = principal;
            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }
        }

        private static bool CheckPassword(string org, string username, string password)
        {
            var security = new EidssSecurityManager();
            var result = security.LogIn(org, username, password);
            switch (result)
            {
                case 0:
                    return true;
                case 6:
                    //int lockInMinutes = security.GetAccountLockTimeout(this.Organization, this.UserName);
                    //string err = BvMessages.Get("ErrLoginIsLocked", "You have exceeded the number of incorrect login attempts. Please try again in {0} minutes.");
                    //ErrorMessage = string.Format(err, lockInMinutes);
                    return false;
                default:
                    //ErrorMessage = SecurityMessages.GetLoginErrorMessage(result);
                    return false;
            }
        }

        private static bool AuthenticateUser(string credentials)
        {
            bool validated = false;
            try
            {
                var encoding = Encoding.GetEncoding("iso-8859-1");
                credentials = encoding.GetString(Convert.FromBase64String(credentials));

                int separator = credentials.IndexOf(':');
                string nameAndOrg = credentials.Substring(0, separator);
                int separatorOrg = nameAndOrg.IndexOf('@');
                string org = nameAndOrg.Substring(0, separatorOrg);
                string name = nameAndOrg.Substring(separatorOrg + 1);
                string password = credentials.Substring(separator + 1);

                validated = CheckPassword(org, name, password);
                if (validated)
                {
                    var identity = new GenericIdentity(name);
                    SetPrincipal(new GenericPrincipal(identity, null));
                }
            }
            catch (Exception)
            {
                // Credentials were not formatted correctly.
                validated = false;

            }
            return validated;
        }

        private static void OnApplicationAuthenticateRequest(object sender, EventArgs e)
        {
            var request = HttpContext.Current.Request;
            var authHeader = request.Headers["Authorization"];
            if (authHeader != null)
            {
                var authHeaderVal = AuthenticationHeaderValue.Parse(authHeader);

                // RFC 2617 sec 1.2, "scheme" name is case-insensitive
                if (authHeaderVal.Scheme.Equals("basic",
                        StringComparison.OrdinalIgnoreCase) &&
                    authHeaderVal.Parameter != null)
                {
                    AuthenticateUser(authHeaderVal.Parameter);
                }
            }
        }

        // If the request was unauthorized, add the WWW-Authenticate header 
        // to the response.
        private static void OnApplicationEndRequest(object sender, EventArgs e)
        {
            var response = HttpContext.Current.Response;
            if (response.StatusCode == 401)
            {
                response.Headers.Add("WWW-Authenticate", string.Format("Basic realm=\"{0}\"", Realm));
            }
        }

        public void Dispose()
        {
        }
    }
    */
}