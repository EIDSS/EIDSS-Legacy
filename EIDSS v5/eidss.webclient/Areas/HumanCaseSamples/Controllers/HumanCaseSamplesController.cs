using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLToolkit.EditableObjects;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Enums;
using eidss.model.Schema;
using eidss.webclient.Utils;
using Telerik.Web.Mvc;
using Telerik.Web.Mvc.UI;

namespace eidss.webclient.Areas.HumanCaseSamples.Controllers
{
    public class HumanCaseSamplesController : Controller
    {
        //
        // GET: /HumanCaseSamples/HumanCaseSamples/

        //[HttpGet]
        public ActionResult ShowHumanCaseSamples(long root, string name, EditableList<HumanCaseSample> samples, bool isReadOnly)
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                ViewData["SampleType"] = BaseReference.Accessor.Instance(null).rftSpecimenType_SelectList(manager).Select(c =>
                    new DropDownItem {Value = c.idfsBaseReference.ToString(), Text = c.name});
            }
            ViewData["SampleName"] = name;
            ViewData["IsReadOnly"] = isReadOnly;

            ModelStorage.Put(Session.SessionID, root, root, name, samples);
            var model = new HumanCaseSample.HumanCaseSampleGridModelList(root, samples.Where(c => c.idfsSpecimenType != (long)SampleTypeEnum.Unknown));
            return PartialView(model);
        }

        //public ActionResult SamplesBinding()
        //{
        //    return View();
        //}
        /*
        [GridAction]
        public ActionResult _SamplesBinding(long key)
        {
            var samples = ModelStorage.Get(Session.SessionID, key) as EditableList<HumanCaseSample>;
            var model = new HumanCaseSample.HumanCaseSampleGridModelList(key, samples);
            return PartialView(new GridModel<HumanCaseSample.HumanCaseSampleGridModel> { Data = model });
        }
        

        //[HttpPost]
        [GridAction]
        public ActionResult _InsertSample(long key)
        {
            var samples = ModelStorage.Get(Session.SessionID, key) as EditableList<HumanCaseSample>;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                HumanCaseSample sample = HumanCaseSample.Accessor.Instance(null).Create(manager, key-1);
                samples.Add(sample);
                TryUpdateModel(sample);
                sample.SampleType = sample.SampleTypeLookup.Where(c => c.idfsBaseReference == sample.idfsSpecimenType).SingleOrDefault();
            }

            var model = new HumanCaseSample.HumanCaseSampleGridModelList(key, samples);
            return PartialView(new GridModel<HumanCaseSample.HumanCaseSampleGridModel> { Data = model });
        }
        

        //[HttpPost]
        [GridAction]
        public ActionResult _UpdateSample(long key, long id)
        {
            var samples = ModelStorage.Get(Session.SessionID, key) as EditableList<HumanCaseSample>;
            HumanCaseSample sample = samples.Where(s => s.idfMaterial == id).Single();
            TryUpdateModel(sample);
            sample.SampleType = sample.SampleTypeLookup.Where(c => c.idfsBaseReference == sample.idfsSpecimenType).SingleOrDefault();

            var model = new HumanCaseSample.HumanCaseSampleGridModelList(key, samples);
            return PartialView(new GridModel<HumanCaseSample.HumanCaseSampleGridModel> { Data = model });
        }
        //[HttpPost]
        [GridAction]
        public ActionResult _DeleteSample(long key, long id)
        {
            var samples = ModelStorage.Get(Session.SessionID, key) as EditableList<HumanCaseSample>;
            samples.Where(s => s.idfMaterial == id).Single().MarkToDelete();

            var model = new HumanCaseSample.HumanCaseSampleGridModelList(key, samples);
            return PartialView(new GridModel<HumanCaseSample.HumanCaseSampleGridModel> { Data = model });
        }
        */
    }
}
