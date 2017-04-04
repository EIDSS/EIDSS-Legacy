    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bv.common.Core;

namespace eidss.webclient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return new RedirectResult("/" + Localizer.DefaultLanguageLocale + "/Account/Login");
        }

    }
}
