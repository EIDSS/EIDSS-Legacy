using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eidss.model.Resources;
using eidss.model.Schema;

namespace eidss.webclient.Utils
{
    public static class UserContextHelper
    {        
        public static string UserFullName()
        {
            return eidss.model.Core.EidssUserContext.User.FullName;
        }

        public static string UserOrganization()
        {
            return OrganizationLookup.OrganizationNational;
        }

        public static string ContextSiteCode()
        {
            return eidss.model.Core.EidssSiteContext.Instance.SiteCode;
        }

        public static string ContextCountry()
        {
            return eidss.model.Core.EidssSiteContext.Instance.CountryName;
        }

    }
}