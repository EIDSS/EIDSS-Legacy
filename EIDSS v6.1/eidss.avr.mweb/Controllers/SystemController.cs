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
        public ActionResult LoadOnDemandConfirmation(string messageText, string yesFunction, string noFunction, string showCancel)
        {
            ViewBag.MessageText = messageText;
            ViewBag.YesFunction = yesFunction;
            ViewBag.NoFunction = noFunction;
            ViewBag.ShowCancel = (showCancel == null || showCancel.ToLowerInvariant() == "true");
            return PartialView("ConfirmationDlg");
        }

        public ActionResult LoadOnDemandInformation(string messageText)
        {
            ViewBag.MessageText = messageText;
            return PartialView("WarningDlg");
        }
        public ActionResult LoadOnDemandOkCancel(string messageText, string okFunction)
        {
            ViewBag.MessageText = messageText;
            ViewBag.OkFunction = okFunction;
            return PartialView("OkCancelDlg");
        }
    }
}
