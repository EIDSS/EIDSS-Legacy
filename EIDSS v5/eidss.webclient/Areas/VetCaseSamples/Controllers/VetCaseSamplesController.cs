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

namespace eidss.webclient.Areas.VetCaseSamples.Controllers
{
    public class VetCaseSamplesController : Controller
    {
        //
        // GET: /VetCaseSamples/VetCaseSamples/

        public ActionResult ShowVetCaseSamples(long root, string name, EditableList<VetCaseSample> samples, bool isReadOnly, string exclude)
        {
            ViewData["SampleName"] = name;
            ViewData["IsReadOnly"] = isReadOnly;
            ViewData["ExcludeColumns"] = exclude;

            ModelStorage.Put(Session.SessionID, root, root, name, samples);
            var model = new VetCaseSample.VetCaseSampleGridModelList(root, samples);
            return PartialView(model);
        }

    }
}
