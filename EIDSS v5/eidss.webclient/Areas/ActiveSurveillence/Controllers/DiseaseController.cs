using System.Linq;
using System.Web.Mvc;
using BLToolkit.EditableObjects;
using eidss.model.Schema;
using bv.model.BLToolkit;
using eidss.webclient.Utils;
using bv.model.Model.Core;
using System.Collections.Generic;
using System;
using eidss.model.Resources;



namespace eidss.webclient.Areas.ActiveSurveillence.Controllers
{
    public class DiseaseController : Controller
    {
        private void SetViewData(long root, string name)
        {
            ViewData["root"] = root;
            ViewData["name"] = name;
        }
        private string m_errorMsg = "";
        private const string KEY_FOR_TEMP_ITEM_STORAGE = "DiseaseListItemEditions";
        private const string KEY_FOR_TEMP_SESSION_ITEM_STORAGE = "SessionDiseaseListItemEditions";

        #region By Campaign
        public ActionResult ByCampaign(long root, string name, EditableList<AsDisease> items, bool isReadOnly)
        {
            SetViewData(root, name);
            ViewData["IsReadOnly"] = isReadOnly;
            ModelStorage.Put(Session.SessionID, root, root, name, items);
            var model = new AsDisease.AsDiseaseGridModelList(root, items.OrderBy(x=>x.intOrder));
            return PartialView(model);
        }


        public ActionResult Details(long key, string name, long? idfAsDisease)
        {
            idfAsDisease = idfAsDisease == 0 ? null : idfAsDisease;            

            SetViewData(key, name);
            AsDisease item = null;
            if (idfAsDisease.HasValue && idfAsDisease.Value > 0)
            {
                item = (ModelStorage.Get(Session.SessionID, key, name) as EditableList<AsDisease>)
                        .Where(a => a.idfCampaignToDiagnosis == idfAsDisease).FirstOrDefault();
            }
            else
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    item = (AsDisease)AsDisease.Accessor.Instance(null).CreateNew(manager, null);
                    item.idfCampaign = key;
                    idfAsDisease = item.idfCampaignToDiagnosis;
                }
            }
            
            ModelStorage.Put(Session.SessionID, key, key, KEY_FOR_TEMP_ITEM_STORAGE, item);
            return View(item);
        }

        [HttpPost]
        public ActionResult Details(long key, string name, long? idfAsDisease, FormCollection form)
        {
            var desease = ModelStorage.Get(Session.SessionID, key, KEY_FOR_TEMP_ITEM_STORAGE) as AsDisease;
            desease.ParseFormCollection(form);
            desease.Validation += object_ValidationDetails;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(eidss.model.Core.EidssUserContext.Instance))
            {
                var acc = AsDisease.Accessor.Instance(null);
                acc.Validate(manager, desease, true, false, false, false);
            }
            desease.Validation -= object_ValidationDetails;
            if (!String.IsNullOrWhiteSpace(m_errorMsg))
            {
                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = m_errorMsg };
            }
            
            
            if (!idfAsDisease.HasValue || idfAsDisease == 0)
            {
                var campaign = ModelStorage.Get(Session.SessionID, key, null) as AsCampaign;                
                desease.intOrder = campaign.Diseases.Count > 0 ? campaign.Diseases.Max(x => x.intOrder) + 1 : 1;
                campaign.Validation += object_ValidationDetails;
                campaign.Diseases.Add(desease);
                campaign.Validation -= object_ValidationDetails;
            }

            if (!String.IsNullOrWhiteSpace(m_errorMsg))
            {
                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = m_errorMsg };
            }

            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = "ok" };
        }

        public ActionResult MoveItem(long key, string name, long? idfAsDisease, int moveDirection)
        {
            var list = ModelStorage.Get(Session.SessionID, key, name) as EditableList<AsDisease>;
            if (list.Count(d=>!d.IsMarkedToDelete) > 0)
            {
                var d1 = list.Single(d => d.idfCampaignToDiagnosis == idfAsDisease);
                var newseq = d1.intOrder + moveDirection;

                if (list.Where(d => d.intOrder == newseq && !d.IsMarkedToDelete).Count() > 0)
                {
                    list.Where(d => d.intOrder == newseq && !d.IsMarkedToDelete).First().intOrder -= moveDirection;
                    d1.intOrder = newseq;
                }
            }
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = "ok" };
        }


        void object_ValidationDetails(object sender, ValidationEventArgs args)
        {
            m_errorMsg = EidssMessages.GetValidationErrorMessage(args);
        }

        #endregion

        #region session disease

        public ActionResult BySession(long root, string name, EditableList<AsSessionDisease> items, bool isReadOnly)
        {
            SetViewData(root, name);
            ViewData["IsReadOnly"] = isReadOnly;
            ModelStorage.Put(Session.SessionID, root, root, name, items);
            var model = new AsSessionDisease.AsSessionDiseaseGridModelList(root, items);
            return PartialView(model);
        }


        public ActionResult SessionDetails(long key, string name, long? idfAsSessionDisease)
        {
            // check if session has a campaign
            idfAsSessionDisease = idfAsSessionDisease == 0 ? null : idfAsSessionDisease;
            var assession = ModelStorage.Get(Session.SessionID, key, null) as AsSession;

            SetViewData(key, name);
            AsSessionDisease item = null;
            if (idfAsSessionDisease.HasValue && idfAsSessionDisease.Value > 0)
            {
                item = (ModelStorage.Get(Session.SessionID, key, name) as EditableList<AsSessionDisease>)
                        .Where(a => a.idfMonitoringSessionToDiagnosis == idfAsSessionDisease).FirstOrDefault();
                item.idfMonitoringSession = key;
            }
            else
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    item = (AsSessionDisease)AsSessionDisease.Accessor.Instance(null).CreateNew(manager, assession);
                    idfAsSessionDisease = item.idfMonitoringSessionToDiagnosis;
                    item.idfMonitoringSession = key;
                }
            }

            ModelStorage.Put(Session.SessionID, key, key, KEY_FOR_TEMP_SESSION_ITEM_STORAGE, item);
            ViewBag.idfAsCampaign = assession.idfCampaign;
            
            if (!assession.idfCampaign.HasValue && assession.CampaignInRamOnly == null)
            {
                ViewBag.FullDiagnosisList = true;
            }
            else
            {
                var campaign = assession.CampaignInRamOnly;                

                if (campaign == null)
                {
                    using (DbManagerProxy manager = DbManagerFactory.Factory.Create(eidss.model.Core.EidssUserContext.Instance))
                    {
                        var acc = AsCampaign.Accessor.Instance(null);
                        campaign = (AsCampaign)acc.SelectDetail(manager, assession.idfCampaign);                        
                    }
                }

                ModelStorage.Put(Session.SessionID, key, key, "SessionCampaign", campaign);

                ViewBag.FullDiagnosisList = false;

                ViewBag.Diagnosis = new SelectList(campaign.Diseases.Select(d => new { name = d.Diagnosis.name, id = d.idfsDiagnosis }).Distinct(), "id", "name", item.idfsDiagnosis);
                ViewBag.Species = new SelectList(campaign.Diseases.Select(d => new { name = d.SpeciesType.name, id = d.idfsSpeciesType }), "id", "name", item.idfsSpeciesType);
            }
            return View(item);
        }

        public ActionResult GetSpeciesList(long key, long idfSessionDisease, long? idfAsCampaign, long? idfsDiagnosis)
        {            
            var campaign = ModelStorage.Get(Session.SessionID, key, "SessionCampaign") as AsCampaign;
            if (campaign == null)
                return Json("error", JsonRequestBehavior.AllowGet);
            else
            {
                var specList = campaign.Diseases.Where(d => d.idfsDiagnosis == idfsDiagnosis && d.idfsSpeciesType.HasValue).Select(d => new {name=d.SpeciesType.name, id=d.idfsSpeciesType });
                SelectList list;
                if (specList.Count() == 0)
                {
                    var disease = ModelStorage.Get(Session.SessionID, key, KEY_FOR_TEMP_SESSION_ITEM_STORAGE) as AsSessionDisease;
                    list = new SelectList(disease.SpeciesTypeLookup, "idfsBaseReference", "name");
                }
                else 
                    list = new SelectList(specList, "id", "name");
                return Json(list, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult SessionDetails(long key, string name, long? idfAsSessionDisease, FormCollection form)
        {
            var desease = ModelStorage.Get(Session.SessionID, key, KEY_FOR_TEMP_SESSION_ITEM_STORAGE) as AsSessionDisease;

            var campaign = ModelStorage.Get(Session.SessionID, key, "SessionCampaign", false) as AsCampaign;

            ViewBag.idfAsCampaign = (campaign == null) ? 0 : campaign.idfCampaign;
            desease.ParseFormCollection(form);
            
            desease.Validation += object_ValidationDetails;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(eidss.model.Core.EidssUserContext.Instance))
            {
                var acc = AsSessionDisease.Accessor.Instance(null);
                acc.Validate(manager, desease, true, false, false, false);
            }

            desease.Validation -= object_ValidationDetails;
            if (!String.IsNullOrWhiteSpace(m_errorMsg))
            {
                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = m_errorMsg };
            }


            if (!idfAsSessionDisease.HasValue || idfAsSessionDisease == 0)
            {
                var session = ModelStorage.Get(Session.SessionID, key, null) as AsSession;
                session.Validation += object_ValidationDetails;
                session.Diseases.Add(desease);
                //ModelStorage.Put(Session.SessionID, session.idfMonitoringSession, session.idfMonitoringSession, name, session.Diseases.Where(d => !d.IsMarkedToDelete).ToArray());                
                session.Validation -= object_ValidationDetails;
            }

            if (!String.IsNullOrWhiteSpace(m_errorMsg))
            {
                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = m_errorMsg };
            }
            else
            {
                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = "ok" };
            }
        }
        #endregion
    }
}
