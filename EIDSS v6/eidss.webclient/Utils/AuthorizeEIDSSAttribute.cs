using System;
using System.Web;
using System.Web.Mvc;

namespace eidss.webclient.Utils
{
    public class AuthorizeEIDSSAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool result = base.AuthorizeCore(httpContext);

            result = result && eidss.model.Core.EidssUserContext.User != null && !String.IsNullOrEmpty(eidss.model.Core.EidssUserContext.User.FullName);

            if (result && httpContext.Session != null)
            {
                httpContext.Session["LastAccess"] = new DateTime?(DateTime.Now);
            }

            return result;
        }
    }
}