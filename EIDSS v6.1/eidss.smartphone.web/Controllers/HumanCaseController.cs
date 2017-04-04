using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using bv.common.Core;
using eidss.smartphone.web.Models;
using System.Threading;
using System.Globalization;
using System.Web.Mvc;
using eidss.model.Core;
using eidss.smartphone.web.Utils;
using eidss.model.Enums;

namespace eidss.smartphone.web.Controllers
{
    [BasicAuthorize(InsertPermission = new[]{EIDSSPermissionObject.HumanCase}, UpdatePermission = new[]{EIDSSPermissionObject.HumanCase})]
    public class HumanCaseController : ApiController
    {
        public HumanCaseInfoOut Post([FromBody]HumanCaseInfoIn hc)
        {
            string lang = string.IsNullOrEmpty(hc.lang) ? Localizer.lngEn : hc.lang;
            if (Localizer.SupportedLanguages[lang] == null) lang = Localizer.lngEn;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Localizer.SupportedLanguages[lang]);
            Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture;
            EidssUserContext.CurrentLanguage = lang;
            return hc.Save();
        }
    }
}
