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
using eidss.model.Core;
using eidss.smartphone.web.Utils;
using eidss.model.Enums;

namespace eidss.smartphone.web.Controllers
{
    [BasicAuthorize]
    public class ASSessionController : ApiController
    {
        public IEnumerable<ASSessionInfoIn> Get(long id)
        {
            return ASSessionInfoIn.GetList(id);
        }

        [BasicAuthorize(
            InsertPermission = new[] { EIDSSPermissionObject.MonitoringSession, EIDSSPermissionObject.AccessToFarmData },
            UpdatePermission = new[] { EIDSSPermissionObject.MonitoringSession, EIDSSPermissionObject.AccessToFarmData })
        ]
        public ASSessionInfoOut Post([FromBody]ASSessionInfoIn vc)
        {
            string lang = string.IsNullOrEmpty(vc.lang) ? Localizer.lngEn : vc.lang;
            if (Localizer.SupportedLanguages[lang] == null) lang = Localizer.lngEn;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Localizer.SupportedLanguages[lang]);
            Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture;
            EidssUserContext.CurrentLanguage = lang;
            return vc.Save();
        }
    }
}
