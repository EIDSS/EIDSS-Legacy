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
    public class BaseReferenceTranslationRawController : ApiController
    {
        public IEnumerable<BaseReferenceTranslationRaw> Get(long id, string lang)
        {
            return BaseReferenceTranslationRaw.GetList(id, lang);
        }
    }
}
