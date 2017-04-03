using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bv.model.Model.Core;
using eidss.webclient.Utils;

namespace eidss.webclient.Areas.Freezer.Controllers
{
    public class FreezerController : Controller
    {
        public ActionResult ShowInlineFreezerPicker(long root, model.Schema.LabSample sample)
        {
            return PartialView(sample);
        }
    }
}
