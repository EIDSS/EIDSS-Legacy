using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLToolkit.EditableObjects;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Schema;
using eidss.webclient.Utils;
using Telerik.Web.Mvc;
using Telerik.Web.Mvc.UI;

namespace eidss.webclient.Areas.Therapy.Controllers
{
    public class TherapyController : Controller
    {
        public ActionResult ShowHumanAntimicrobialTherapy(long root, string name, EditableList<AntimicrobialTherapy> antibiotic, bool isReadOnly)
        {
            ViewData["AntimicrobialTherapyName"] = name;
            ViewData["IsReadOnly"] = isReadOnly;

            ModelStorage.Put(Session.SessionID, root, root, name, antibiotic);
            var model = new AntimicrobialTherapy.AntimicrobialTherapyGridModelList(root, antibiotic);
            return PartialView(model);
        }

        //[HttpPost]
        //public ActionResult SelectFieldCollectedByPerson(long idfMaterial)
        //{
        //    HumanCaseSample o = ModelStorage.Get(Session.SessionID, idfMaterial, null) as HumanCaseSample;
        //    return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new SelectList(o.FieldCollectedByPersonLookup, "idfPerson", "FullName") };
        //}
    }
}
