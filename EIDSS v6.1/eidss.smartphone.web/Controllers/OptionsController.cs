using System.Web.Http;
using eidss.smartphone.web.Models;
using eidss.smartphone.web.Utils;

namespace eidss.smartphone.web.Controllers
{
    [BasicAuthorize]
    public class OptionsController : ApiController
    {
        public Options Get()
        {
            return Options.Get();
        }

    }
}
