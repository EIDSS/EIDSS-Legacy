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
using eidss.openapi.bll.Bll;
using eidss.openapi.contract;
using eidss.openapi.bll.Exceptions;

namespace eidss.openapi.web.Utils
{
    // http://kevin-junghans.blogspot.ru/2013/02/mixing-forms-authentication-basic.html

    [AttributeUsageAttribute(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class EidssBasicAuthorizeAttribute : AuthorizeAttribute
    {
        public EIDSSPermissionObject InsertPermission { get; set; }
        public EIDSSPermissionObject UpdatePermission { get; set; }
        public EIDSSPermissionObject SelectPermission { get; set; }
        public EIDSSPermissionObject DeletePermission { get; set; }

        private const string Realm = "eidss.openapi.web.api";

        private enum AuthType { basic, cookie };

        private OpenApiException Error;

        private string DecodeFrom64(string encodedData)
        {
            byte[] encodedDataAsBytes = System.Convert.FromBase64String(encodedData);
            string returnValue = System.Text.Encoding.ASCII.GetString(encodedDataAsBytes);
            return returnValue;
        }

        private bool GetUserNameAndPassword(HttpActionContext actionContext, out string orgname, out string username, out string password, out string language, out string external, out AuthType authType)
        {
            authType = AuthType.basic;
            var gotIt = false;
            orgname = string.Empty;
            username = string.Empty;
            password = string.Empty;
            language = string.Empty;
            external = string.Empty;
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
                        string usernameAndOther = unpw[0];
                        string[] usernameAndOthers = usernameAndOther.Split(new char[] { '@' });
                        if (usernameAndOthers.Length > 0)
                            orgname = usernameAndOthers[0];
                        if (usernameAndOthers.Length > 1)
                            username = usernameAndOthers[1];
                        if (usernameAndOthers.Length > 2)
                            language = usernameAndOthers[2];
                        if (usernameAndOthers.Length > 3)
                            external = usernameAndOthers[3];
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

        private bool Authenticate(HttpActionContext actionContext)
        {
            bool isAuthenticated = false;
            string orgname = string.Empty;
            string username = string.Empty;
            string password = string.Empty;
            string language = string.Empty;
            string external = string.Empty;
            AuthType authenticationType;

            if (GetUserNameAndPassword(actionContext, out orgname, out username, out password, out language, out external, out authenticationType))
            {
                if (authenticationType == AuthType.basic)
                {
                    try
                    {
                        LoginBll.Authorize(new Login() { organization = orgname, user = username, password = password, language = language, externalSystem = external });
                        isAuthenticated = true;
                    }
                    catch (OpenApiException e)
                    {
                        Error = e;
                    }
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
                (InsertPermission == 0 || Check(PermissionHelper.InsertPermission(InsertPermission))) &&
                (UpdatePermission == 0 || Check(PermissionHelper.UpdatePermission(UpdatePermission))) &&
                (SelectPermission == 0 || Check(PermissionHelper.SelectPermission(SelectPermission))) &&
                (DeletePermission == 0 || Check(PermissionHelper.DeletePermission(DeletePermission)));

            return authorized;
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            Error = null;
            if (Authenticate(actionContext))
            {
                if (!isAuthorized())
                {
                    Error = new AuthAccessException();
                    actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);
                }
            }
            else
            {
                actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
                actionContext.Response.Headers.Add("WWW-Authenticate", string.Format("Basic realm=\"{0}\"", Realm));
                if (Error == null)
                    Error = new AuthRequiredException();
            }

            if (Error != null)
            {
                actionContext.Response.ReasonPhrase = Error.ErrorCode;
                actionContext.Response.Headers.Add("ErrorCode", Error.ErrorCode);
                actionContext.Response.Headers.Add("ErrorMessage", Error.Message);
            }
        }
    }
}