using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eidss.smartphone.web.Utils
{
    public class AuthorizeEIDSSAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool result = base.AuthorizeCore(httpContext);

            result = result && eidss.model.Core.EidssUserContext.User != null && !String.IsNullOrEmpty(eidss.model.Core.EidssUserContext.User.FullName);

            return result;
        }
    }
}