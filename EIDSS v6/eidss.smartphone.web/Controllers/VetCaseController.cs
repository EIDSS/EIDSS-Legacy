using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using eidss.smartphone.web.Models;
using System.Threading;
using System.Globalization;
using eidss.model.Core;
using eidss.smartphone.web.Utils;
using eidss.model.Enums;

namespace eidss.smartphone.web.Controllers
{
    [BasicAuthorize(
        InsertPermission = new[]{EIDSSPermissionObject.VetCase,EIDSSPermissionObject.AccessToFarmData},
        UpdatePermission = new[]{EIDSSPermissionObject.VetCase,EIDSSPermissionObject.AccessToFarmData})
    ]
    public class VetCaseController : ApiController
    {
        public VetCaseInfoOut Post([FromBody]VetCaseInfoIn vc)
        {
            EidssUserContext.CurrentLanguage = vc.lang;
            return vc.Save();
        }
    }
}
