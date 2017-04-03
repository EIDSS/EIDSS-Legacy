using System.Web.Mvc;
using eidss.model.Schema;
using eidss.webclient.Utils;

namespace eidss.webclient.Controllers
{
    [AuthorizeEIDSS]
    public class PersonnelController : Controller
    {
        //
        // GET: /Personnel/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Select(VetCase vetCase, string idfsOfficePropertyName, string strOfficePropertyName, 
            string idfsPersonPropertyName, string strPersonPropertyName, long? idfPerson)
        {
            ViewBag.IdfsOfficePropertyName = idfsOfficePropertyName;
            ViewBag.StrOfficePropertyName = strOfficePropertyName;
            ViewBag.IdfsPersonPropertyName = idfsPersonPropertyName;
            ViewBag.StrPersonPropertyName = strPersonPropertyName;
            return View(vetCase);
        }
    }
}
