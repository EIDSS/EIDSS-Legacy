using System;
using System.Linq;
using System.Web.Mvc;
using eidss.model.Schema;
using eidss.webclient.Utils;
using BLToolkit.EditableObjects;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Resources;
using eidss.model.Enums;
using System.Collections.Generic;

namespace eidss.webclient.Areas.ActiveSurveillence.Controllers
{
    public class SummaryController : Controller
    {
        private void SetViewData(long root, string name)
        {
            ViewData["root"] = root;
            ViewData["name"] = name;
        }
        // commented because  never used
        //private string m_errorMsg = "";
        private const string KEY_FOR_TEMP_ITEM_STORAGE = "SummaryListItemEditions";
        public ActionResult Index(long root, string name, EditableList<AsSessionSummary> items, bool isReadOnly)
        {
            SetViewData(root, name);
            ViewData["IsReadOnly"] = isReadOnly;
            ModelStorage.Put(Session.SessionID, root, root, name, items);
            var model = new AsSessionSummary.AsSessionSummaryGridModelList(root, items);
            return PartialView(model);
        }


        private void SetSpeciesList(AsSession session, AsSessionSummary summary)
        {
            if ((summary.idfFarm > 0))
            {
                ViewBag.SpeciesList = new SelectList(
                    session.ASSpecies.Where(s => s.idfFarm == summary.idfFarm),
                    "idfSpecies", "DisplayName",
                    summary.idfSpecies);
            }
            else
            {
                ViewBag.SpeciesList = new SelectList(new List<SelectListItem>());
            }
        }
        public ActionResult Details(long root, string name, long idfSummary)
        {
            SetViewData(root, name);
            ViewBag.Close = false;
            var session = ModelStorage.Get(Session.SessionID, root, "") as AsSession;
            AsSessionSummary summary;
            if (idfSummary == 0)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    summary = AsSessionSummary.Accessor.Instance(null).CreateFromSession(manager, session, session);
                }
            
            }
            else
            {
                summary = session.SummaryItems.Single(x => x.idfMonitoringSessionSummary == idfSummary);
            }
            SetSpeciesList(session, summary);

            ModelStorage.Put(Session.SessionID, root, summary.idfMonitoringSessionSummary, "", summary);
            ModelStorage.Put(Session.SessionID, root, root, KEY_FOR_TEMP_ITEM_STORAGE, summary);
            return View(summary);
        }

        [HttpPost]
        public ActionResult Details(long root, string name, FormCollection form)
        {
            SetViewData(root, name);
            AsSessionSummary summary = ModelStorage.Get(Session.SessionID,root,KEY_FOR_TEMP_ITEM_STORAGE) as AsSessionSummary ;
            var session = ModelStorage.Get(Session.SessionID, summary.idfMonitoringSession, "", true) as AsSession;

            if( summary == null || session == null)
                return Json(EidssMessages.Get("Error_SessionExpired"), JsonRequestBehavior.AllowGet);

            summary.Validation += object_Validation;
            summary.ParseFormCollection(form);            
                        
            if (summary.idfSpecies != null)
            {
                var species = session.ASSpecies.Single(x => x.idfSpecies == summary.idfSpecies);
                summary.idfsSpeciesType = species.idfsReference;
                summary.strSpecies = species.name;
            }
            SetSpeciesList(session, summary);

            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                AsSessionSummary.Accessor.Instance(null).Validate(manager, summary, true, false, false);
            }
            
            summary.Validation -= object_Validation;
            if (String.IsNullOrWhiteSpace(ViewBag.ErrorMessage) && !session.SummaryItems.Contains(summary))
            {                                
                session.Validation += object_Validation;
                session.SummaryItems.Add(summary);
                ModelStorage.Put(Session.SessionID, session.idfMonitoringSession, session.idfMonitoringSession, name, session.SummaryItems);
                session.Validation -= object_Validation;
            }
            
            ViewBag.Close = String.IsNullOrWhiteSpace(ViewBag.ErrorMessage);
            return View(summary);            


        }

        void object_Validation(object sender, ValidationEventArgs args)
        {
            ViewBag.ErrorMessage = EidssMessages.GetValidationErrorMessage(args);
            ViewBag.ErrorText = "error occured";
        }


        [HttpGet]
        public ActionResult GetTotals(long root)
        {
            var session = ModelStorage.Get(Session.SessionID, root, "") as AsSession;
            Dictionary<string, int> totals = new Dictionary<string, int>();

            totals.Add(String.Format("#{0}intTotalSampledAnimals", session.ObjectIdent), session.intTotalSampledAnimals);
            totals.Add(String.Format("#{0}intTotalPositiveAnimals", session.ObjectIdent), session.intTotalPositiveAnimals);
            totals.Add(String.Format("#{0}intTotalSamples", session.ObjectIdent), session.intTotalSamples);                            

            return Json(
                totals,
                JsonRequestBehavior.AllowGet
                );
        }

        public ActionResult SampleTypes(long idfMonitoringSessionSummary)
        {
            ViewBag.idfMonitoringSessionSummary = idfMonitoringSessionSummary;
            var summary = ModelStorage.Get(Session.SessionID, idfMonitoringSessionSummary, "") as AsSessionSummary;

            ViewBag.Samples = summary.Samples.Where(x => x.blnChecked.Value).Select(x => x.idfsSampleType).ToArray();

            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                var sampleTypes = BaseReference.Accessor.Instance(null).rftSpecimenType_SelectList(manager);
                return View(sampleTypes);
            }
        }

        [HttpPost]
        public ActionResult SampleTypes(long idfMonitoringSessionSummary, FormCollection form)
        {
            string strSamples = String.Empty;
            var summary = ModelStorage.Get(Session.SessionID, idfMonitoringSessionSummary, "", true) as AsSessionSummary;
            summary.Samples.ForEach(x => x.blnChecked = false);
            if (!String.IsNullOrWhiteSpace(form["SampleType"]))
            {                
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    AsSessionSummarySample sampleType;
                    long idfsSampleType;
                    var sampleAccessor = AsSessionSummarySample.Accessor.Instance(null);
                    foreach (string sample in form["SampleType"].Split(new char[] { ',' }))
                    {
                        idfsSampleType = Convert.ToInt64(sample);

                        sampleType = summary.Samples.Where(x => x.idfsSampleType == idfsSampleType).Count() > 0 ? summary.Samples.Single(x => x.idfsSampleType == idfsSampleType) : null;
                        if (sampleType != null)
                        {
                            sampleType.blnChecked = true;
                        }
                        else
                        {
                            sampleType = sampleAccessor.CreateNew(manager, summary) as AsSessionSummarySample;
                            sampleType.idfMonitoringSessionSummary = idfMonitoringSessionSummary;
                            sampleType.idfsSampleType = idfsSampleType;
                            sampleType.blnChecked = true;
                            sampleType.SampleType = sampleType.SampleTypeLookup.Where(s => s.idfsBaseReference == idfsSampleType).First();
                            summary.Samples.Add(sampleType);
                        }
                        strSamples += String.Format(",{0}", sampleType.strSampleType);
                    }
                }
            }

            strSamples = strSamples.Length > 0 ? strSamples.Substring(1) : "";
            summary.strSamples = strSamples;
            return Json(strSamples, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Diagnosis(long idfMonitoringSessionSummary)
        {
            var summary = ModelStorage.Get(Session.SessionID, idfMonitoringSessionSummary, "") as AsSessionSummary;
            var session = ModelStorage.Get(Session.SessionID, summary.idfMonitoringSession, "") as AsSession;

            ViewBag.DiagnosisList = session.Diseases.Where(x => !x.IsMarkedToDelete).Select(d=>d.Diagnosis).Distinct().ToDictionary(x => x.idfsDiagnosis, x => x.name);
            ViewBag.Diagnosis = summary.Diagnosis.Where(x => x.blnChecked).Select(x => x.idfsDiagnosis).ToArray();

            return View();
        }

        [HttpPost]
        public ActionResult Diagnosis(long idfMonitoringSessionSummary, FormCollection form)
        {
            string strDiagnosis = String.Empty;
            var summary = ModelStorage.Get(Session.SessionID, idfMonitoringSessionSummary, "", true) as AsSessionSummary;
            summary.Diagnosis.ForEach(x => x.blnChecked = false);
            if (!String.IsNullOrWhiteSpace(form["Diagnosis"]))
            {                                
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    AsSessionSummaryDiagnosis diagnosis;
                    long idfsDiagnosis;
                    var diagnosisAccessor = AsSessionSummaryDiagnosis.Accessor.Instance(null);
                    foreach (string sample in form["Diagnosis"].Split(new char[] { ',' }))
                    {
                        idfsDiagnosis = Convert.ToInt64(sample);

                        diagnosis = summary.Diagnosis.Where(x => x.idfsDiagnosis == idfsDiagnosis).Count() > 0 ? summary.Diagnosis.Single(x => x.idfsDiagnosis == idfsDiagnosis) : null;
                        if (diagnosis != null)
                        {
                            diagnosis.blnChecked = true;
                        }
                        else
                        {
                            diagnosis = diagnosisAccessor.CreateNew(manager, summary) as AsSessionSummaryDiagnosis;
                            diagnosis.idfMonitoringSessionSummary = idfMonitoringSessionSummary;
                            diagnosis.idfsDiagnosis = idfsDiagnosis;
                            diagnosis.Diagnosis = diagnosis.DiagnosisLookup.Single(d => d.idfsDiagnosis == idfsDiagnosis);
                            diagnosis.blnChecked = true;

                            summary.Diagnosis.Add(diagnosis);
                        }
                        strDiagnosis += String.Format(",{0}", diagnosis.strDiagnosis);
                    }
                }
            }
            strDiagnosis = strDiagnosis.Length > 0 ? strDiagnosis.Substring(1) : "";
            summary.strDiagnosis = strDiagnosis;
            return Json(strDiagnosis, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetSpeciesList(long idfAsSessionSummary, long? idfFarmActual, long? idfFarm)
        {
            var summary = ModelStorage.Get(Session.SessionID, idfAsSessionSummary, "", true) as AsSessionSummary;
            if (summary == null)
                return Json(EidssMessages.Get("Error_SummaryNotFound"), JsonRequestBehavior.AllowGet);
            var session = ModelStorage.Get(Session.SessionID, summary.idfMonitoringSession, "") as AsSession;

            summary.idfFarm = session.GetNewFarmForChild(idfFarmActual.Value, idfFarm);
            
            
            return Json(data: eidss.webclient.Areas.ActiveSurveillence.Helpers.Utils.GetSpeciesListDictionarySessionChildRefresh(session, summary.idfFarm, summary.strFarmCode, summary.ObjectIdent),
                        behavior: JsonRequestBehavior.AllowGet);
        }



    }
}
