using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eidss.web.common.Utils;

namespace eidss.avr.mweb.Controllers
{
    public class SystemController : Controller
    {
        public ActionResult LoadOnDemandConfirmation(string messageText, string yesFunction, string noFunction)
        {
            ViewBag.MessageText = messageText;
            ViewBag.YesFunction = yesFunction;
            ViewBag.NoFunction = noFunction;
            return PartialView("ConfirmationDlg");
        }

        public ActionResult LoadOnDemandInformation(string messageText)
        {
            ViewBag.MessageText = messageText;
            return PartialView("WarningDlg");
        }
    }
}
