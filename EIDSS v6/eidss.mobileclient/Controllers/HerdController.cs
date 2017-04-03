using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BLToolkit.EditableObjects;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.mobileclient.Attributes;
using eidss.mobileclient.Utils;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Resources;
using eidss.model.Schema;

namespace eidss.mobileclient.Controllers
{
    [Authorize]
    public class HerdController : Controller
    {
        [SessionExpireFilter]
        public ActionResult SpeciesDetails(long rootKey, string name, long? idfSpecies)
        {
            VetCase.Accessor vetCaseAccessor = VetCase.Accessor.Instance(null);
            ViewBag.CanUpdate = vetCaseAccessor.CanUpdate;
            ViewBag.RootKey = rootKey;
            ViewBag.Name = name;
            bool isNew = !idfSpecies.HasValue || idfSpecies.Value <= 0;
            ViewBag.IsNewSpecies = isNew;
            VetFarmTree species = VetFarmTreeProcessor.GetSpecies(Session.SessionID, rootKey, name, idfSpecies, HACode.Livestock);
            Int64 selectedHerd = isNew ? 0 : species.idfParentParty.Value;
            List<SelectListItem> herds = VetFarmTreeProcessor.GetHerdsOfCase(Session.SessionID, rootKey, selectedHerd).ToList();
            ViewBag.HerdsList = herds;
            return View(species);
        }

        [HttpPost]
        [SessionExpireFilter]
        public ActionResult SpeciesDetails(long rootKey, string name, bool isNew, string formData)
        {
            ViewBag.RootKey = rootKey;
            ViewBag.Name = name;
            NameValueCollection formCollection = HttpUtility.ParseQueryString(formData);
            var form = new FormCollection(formCollection);
            string errormsg;
            if (VetFarmTreeProcessor.UpdateSpecies(Session.SessionID, rootKey, name, isNew, form, HACode.Livestock, out errormsg))
            {
                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = null };
            }
            return new JsonResult {JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = errormsg};
        }
    }
}
