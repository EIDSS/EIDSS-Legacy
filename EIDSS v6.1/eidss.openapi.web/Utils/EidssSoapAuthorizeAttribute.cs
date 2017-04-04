using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Web;
using System.Web.Mvc;
using bv.common.Core;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.openapi.bll.Exceptions;

namespace eidss.openapi.web.Utils
{
    /*
    // http://www.codeproject.com/Articles/380900/WCF-Authentication-and-Authorization-in-Enterprise

    [AttributeUsageAttribute(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class EidssSoapAuthorizeAttribute : AuthorizeAttribute
    {
        public EIDSSPermissionObject InsertPermission { get; set; }
        public EIDSSPermissionObject UpdatePermission { get; set; }
        public EIDSSPermissionObject SelectPermission { get; set; }
        public EIDSSPermissionObject DeletePermission { get; set; }

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

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool result = base.AuthorizeCore(httpContext);

            result = result && eidss.model.Core.EidssUserContext.User != null && !String.IsNullOrEmpty(eidss.model.Core.EidssUserContext.User.FullName);

            if (result)
            {
                if (!isAuthorized())
                {
                    throw new AuthAccessException();
                }
            }

            return result;
        }
    }
    */

}