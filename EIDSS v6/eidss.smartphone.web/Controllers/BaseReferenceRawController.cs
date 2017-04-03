using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using eidss.smartphone.web.Models;
using eidss.smartphone.web.Utils;

namespace eidss.smartphone.web.Controllers
{
    [BasicAuthorize]
    public class BaseReferenceRawController : ApiController
    {
        public IEnumerable<BaseReferenceRaw> Get(long id)
        {
            return BaseReferenceRaw.GetList(id);
        }
    }
}
