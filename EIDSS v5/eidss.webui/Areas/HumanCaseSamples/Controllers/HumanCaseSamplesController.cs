using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLToolkit.EditableObjects;
using bv.model.BLToolkit;
using eidss.model.Schema;
using eidss.webui.Utils;
using Telerik.Web.Mvc;
using Telerik.Web.Mvc.UI;

namespace eidss.webui.Areas.HumanCaseSamples.Controllers
{
    public class HumanCaseSamplesController : Controller
    {
        //
        // GET: /HumanCaseSamples/HumanCaseSamples/

        public ActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        public ActionResult ShowHumanCaseSamples(long root, HumanCase hc)
        {
            using(DbManagerProxy manager = DbManagerFactory.Factory.Create())
            {
                ViewData["SampleType"] = BaseReference.Accessor.Instance(null).SampleTypeLookup_SelectList(manager).Select(c =>
                    new DropDownItem {Value = c.idfsBaseReference.ToString(), Text = c.name});
            }

            var model = new HumanCaseSample.HumanCaseSampleGridModelList(hc.idfCase, hc.Samples);
            return PartialView(model);
        }

        //public ActionResult SamplesBinding()
        //{
        //    return View();
        //}

        [GridAction]
        public ActionResult _SamplesBinding(long idfCase)
        {
            HumanCase hc = ModelStorage.Get(Session.SessionID, idfCase) as HumanCase;
            var model = new HumanCaseSample.HumanCaseSampleGridModelList(hc.idfCase, hc.Samples);
            return PartialView(new GridModel<HumanCaseSample.HumanCaseSampleGridModel> { Data = model });
            //return PartialView(model);
        }


        //[HttpPost]
        //public ActionResult SelectSampleType(long idfGeoLocation)
        //{
        //    HumanCase hc = Session[HumanCaseKey] as HumanCase;
        //    return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new SelectList(hc.Samples[0].SampleTypeLookup, "idfsBaseReference", "name") };
        //}

        //[HttpPost]
        [GridAction]
        public ActionResult _InsertSample(long idfCase)
        {
            HumanCase hc = ModelStorage.Get(Session.SessionID, idfCase) as HumanCase;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
            {
                var sample = (HumanCaseSample)HumanCaseSample.Accessor.Instance(null).CreateNew(manager, (int)hc.idfCase);
                hc.Samples.Add(sample);
                TryUpdateModel(sample);
                sample.SampleType = sample.SampleTypeLookup.Where(c => c.idfsBaseReference == sample.idfsSpecimenType).SingleOrDefault();
            }

            var model = new HumanCaseSample.HumanCaseSampleGridModelList(hc.idfCase, hc.Samples);
            return PartialView(new GridModel<HumanCaseSample.HumanCaseSampleGridModel> { Data = model });
        }

        //[HttpPost]
        [GridAction]
        public ActionResult _UpdateSample(long idfCase, long id)
        {
            HumanCase hc = ModelStorage.Get(Session.SessionID, idfCase) as HumanCase;
            HumanCaseSample sample = hc.Samples.Where(s => s.idfMaterial == id).Single();
            TryUpdateModel(sample);
            sample.SampleType = sample.SampleTypeLookup.Where(c => c.idfsBaseReference == sample.idfsSpecimenType).SingleOrDefault();

            var model = new HumanCaseSample.HumanCaseSampleGridModelList(hc.idfCase, hc.Samples);
            return PartialView(new GridModel<HumanCaseSample.HumanCaseSampleGridModel> { Data = model });
        }
        //[HttpPost]
        [GridAction]
        public ActionResult _DeleteSample(long idfCase, long id)
        {
            HumanCase hc = ModelStorage.Get(Session.SessionID, idfCase) as HumanCase;
            hc.Samples.Where(s => s.idfMaterial == id).Single().MarkToDelete();

            var model = new HumanCaseSample.HumanCaseSampleGridModelList(hc.idfCase, hc.Samples);
            return PartialView(new GridModel<HumanCaseSample.HumanCaseSampleGridModel> { Data = model });
        }
    
    }
}
