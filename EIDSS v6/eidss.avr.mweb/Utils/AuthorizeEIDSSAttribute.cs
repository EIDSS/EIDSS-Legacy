using System;
using System.Web;
using System.Web.Mvc;
using eidss.model.Core;

namespace eidss.avr.mweb.Utils
{
    public class AuthorizeEIDSSAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool result = base.AuthorizeCore(httpContext);

            result = result && EidssUserContext.User != null && !String.IsNullOrEmpty(EidssUserContext.User.FullName);

            if (result && httpContext.Session != null)
            {
                httpContext.Session["LastAccess"] = new DateTime?(DateTime.Now);
            }

            return result;
        }
    }
}