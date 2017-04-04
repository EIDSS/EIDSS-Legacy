using System.Web.Http;
using eidss.model.Model.Smartphone;
using eidss.smartphone.web.Utils;

namespace eidss.smartphone.web.Controllers
{
    [BasicAuthorize]
    public class FFController : ApiController
    {
        public FFModel Get()
        {
            return FFModel.Get();
        }
    }
}
