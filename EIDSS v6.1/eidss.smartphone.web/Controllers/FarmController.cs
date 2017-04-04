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
    public class FarmController : ApiController
    {
        public IEnumerable<FarmInfoIn> Get(long id)
        {
            return FarmInfoIn.GetList(id);
        }
    }
}
