using System;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using bv.model.Model.Core;
using eidss.model.Core;

namespace eidss.webclient.Utils
{
    public class AuthorizeEIDSSAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool result = base.AuthorizeCore(httpContext);

            result = result && eidss.model.Core.EidssUserContext.User != null && !String.IsNullOrEmpty(eidss.model.Core.EidssUserContext.User.FullName);

            if (result)
            {
                EidssUserContext.CurrentLanguage = Cultures.GetLanguageAbbreviation(Thread.CurrentThread.CurrentUICulture.Name);

                httpContext.Response.Cookies.Set(new HttpCookie("LastAccess", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")));
                //httpContext.Response.Cookies.Add(new HttpCookie("LastAccess", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")));

                /*if (httpContext.Response.Cookies["ClientID"] != null)
                    httpContext.Response.Cookies["ClientID"].Value = ModelUserContext.ClientID;
                else
                    httpContext.Response.Cookies.Add(new HttpCookie("ClientID", ModelUserContext.ClientID));*/
            }
            /*else
            {
                if (httpContext.Request.AcceptTypes != null)
                {
                    if (httpContext.Request.AcceptTypes.Any(c => c.ToLower().Contains("json")) &&
                        !httpContext.Request.AcceptTypes.Any(c => c.ToLower().Contains("html")))
                    {
                        httpContext.Response.StatusCode = 403;
                        httpContext.Response.End();
                        return true;
                    }
                }
            }*/

            return result;
        }
    }
}