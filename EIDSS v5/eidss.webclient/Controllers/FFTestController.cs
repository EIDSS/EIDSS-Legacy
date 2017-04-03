using System.Web.Mvc;

namespace eidss.webclient.Controllers
{
    [Authorize]
    public class FFTestController : Controller
    {
        //
        // GET: /FFTest/

        public ActionResult Index()
        {
            return View();
        }

    }
}
