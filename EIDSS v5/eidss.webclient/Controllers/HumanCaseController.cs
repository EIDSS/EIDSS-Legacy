using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BLToolkit.EditableObjects;
using bv.model.BLToolkit;
using eidss.model.Core;
using eidss.model.Reports;
using eidss.model.Reports.Common;
using eidss.model.Schema;
using bv.model.Model.Core;
using eidss.webclient.Utils;
using eidss.model.Resources;

namespace eidss.webclient.Controllers
{
    [AuthorizeEIDSS]
    public class HumanCaseController : Controller
    {
        private ValidationEventArgs m_Validation;

        public ActionResult Demographic()
        {
            return View();
        }

        public ActionResult Investigation()
        {
            return View();
        }
        public ActionResult Test()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var acc = HumanCase.Accessor.Instance(null);
                return View(acc.SelectByKey(manager, 14920000241).Patient);
            }
        }
        
        public ActionResult Index()
        {
            var accessor = HumanCaseListItem.Accessor.Instance(null);
            IObject initObject = null;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                initObject = accessor.CreateNew(manager, null);
            }
            ViewBag.InitObject = initObject;
            ViewBag.Filter = SearchPanelHelper.GetDefaultFilter(accessor.SearchPanelMeta, initObject);

            
            return View(accessor);         
          
        }
        
        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            FilterParams filter = SearchPanelHelper.SearchPanelParseValues(form, HumanCaseListItem.Accessor.Instance(null).SearchPanelMeta);
            ViewBag.Filter = filter;
            ViewBag.InitObject = null;
            HumanCaseListItem.HumanCaseListItemGridModelList list = GetGridModelList(filter);
            ModelStorage.Put(Session.SessionID, AutoGridRoots.HumanCaseList, AutoGridRoots.HumanCaseList, "Grid", list);
            int totalRows = list.Count;
            return Json(new { data = list, total = totalRows }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Duplicates()
        {
            ViewBag.Filter = SearchPanelHelper.DuplicatesFilter(Request);
            return View(HumanCaseDeduplicationListItem.Accessor.Instance(null));
        }
        
        [HttpGet]
        public ActionResult TestFF()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                HumanCase.Accessor acc = HumanCase.Accessor.Instance(null);
                manager.BeginTransaction();

                HumanCase hc = acc.CreateNewT(manager, null);

                #region mandatory fields

                // mandatory for posting
                hc.Patient.strLastName = "last";
                hc.Patient.strFirstName = "first";
                hc.Patient.CurrentResidenceAddress.Country =
                    hc.Patient.CurrentResidenceAddress.CountryLookup.Where(c => c.strCountryName == "Georgia").
                        SingleOrDefault();
                hc.Patient.CurrentResidenceAddress.Region =
                    hc.Patient.CurrentResidenceAddress.RegionLookup.Where(c => c.strRegionName == "Abkhazia").
                        SingleOrDefault();
                hc.Patient.CurrentResidenceAddress.Rayon =
                    hc.Patient.CurrentResidenceAddress.RayonLookup.Where(c => c.strRayonName == "Gagra").
                        SingleOrDefault();

                #endregion

                //первоначальный диагноз
                hc.TentativeDiagnosis =
                    hc.TentativeDiagnosisLookup.Where(a => a.name == "Diphtheria").SingleOrDefault();

                ModelStorage.Put(Session.SessionID, hc.idfCase, hc.idfCase, null, hc);
                
                return View(hc);
            }
        }

        [HttpPost]
        public ActionResult TestFF(FormCollection form)
        {
            var key = long.Parse(form["idfCase"]);
            var hc = ModelStorage.Get(Session.SessionID, key, null) as HumanCase;

            if (hc != null)
            {
                //TODO использовать FFPresenterModel

                /*
                //переносим в модель данные по FF Epi)
                if (hc.idfsEPIFormTemplate.HasValue && hc.idfEpiObservation.HasValue)
                {
                    hc.EpiActivityParameters.ExtractFromCollection(form
                                                                   , hc.EpiFormTemplate
                                                                   , hc.idfEpiObservation.Value);
                }
                //переносим в модель данные по FF Cs
                if (hc.idfsCSFormTemplate.HasValue && hc.idfCSObservation.HasValue)
                {
                    hc.CsActivityParameters.ExtractFromCollection(form
                                                                  , hc.CsFormTemplate
                                                                  , hc.idfCSObservation.Value);
                }
                */
            }
            HumanCase.Accessor acc = HumanCase.Accessor.Instance(null);
            using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                acc.Post(manager, hc);
            }
            return View(hc);
        }
        
        void hc_Validation(object sender, ValidationEventArgs args)
        {
            ViewData["ErrorMessage"] = Translator.GetErrorMessage(args);
        }
        
        class Info
        {
            public readonly Dictionary<string, string> Values;
            public readonly Dictionary<string, bool> Enables;

            public Info()
            {
                Values = new Dictionary<string, string>();
                Enables = new Dictionary<string, bool>();
            }
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetValidation(string property, string value, string property2)
        {           
            var ii = new Info();
            ii.Values.Add(property, value);
            ii.Enables.Add(property2, false);
            var json = new JsonResult { Data = ii, JsonRequestBehavior = JsonRequestBehavior.AllowGet};
            return json;
        }

        [Authorize]
        [HttpGet]
        public ActionResult Details(long? id) //TODO возможно стоит сделать просто long, когда будет обязательно вызываться с id (для нового id=0)
        {
            if (!id.HasValue) 
            {
                id = 0; //новый случай //TODO вынести id нового в константу
            }

            if (id == 0)
            {
                ViewBag.IsNewCase = "true";
            }

            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var acc = HumanCase.Accessor.Instance(null);
                var hc = id.Value.Equals(0) ? acc.CreateNewT(manager, null) : acc.SelectByKey(manager, id.Value); //TODO extender helper для проверки

                ModelStorage.Put(Session.SessionID, hc.idfCase, hc.idfCase, null, hc);
                ModelStorage.Put(Session.SessionID, hc.idfCase, hc.idfCase, hc.ObjectIdent + "AntimicrobialTherapy", hc.AntimicrobialTherapy);

                ViewBag.IdfEpiObservation = hc.idfEpiObservation;
                ViewBag.IdfCSObservation = hc.idfCSObservation;
                ViewBag.DiagnosisId = hc.idfsFinalDiagnosis.HasValue ? hc.idfsFinalDiagnosis : hc.idfsTentativeDiagnosis;

                IObjectPermissions permission = hc.GetPermissions();
                ViewBag.IsReadOnlyForEdit = permission == null ? false : permission.IsReadOnlyForEdit;

                return View(hc);
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult Details(FormCollection form)
        {
            var key = long.Parse(form["idfCase"]);
            var hc = ModelStorage.Get(Session.SessionID, key, null) as HumanCase;
            var clone = (IObject)hc.Clone();

            ViewData["ErrorMessage"] = null;
            m_ignoreErr = form["ignore_rule"] == "1";
            hc.Validation += hc_ValidationDetails;
            hc.ParseFormCollection(form);
            if (ViewData["ErrorMessage"] == null)
            {
                using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                {
                    HumanCase.Accessor acc = HumanCase.Accessor.Instance(null);
                    acc.Post(manager, hc);
                }
            }
            hc.Validation -= hc_ValidationDetails;
            ViewBag.IsNewCase = "";
            var comparision = new CompareModel();

            if (ViewData["ErrorMessage"] != null)
            {
                comparision.Add("ErrorMessage", "ErrorMessage", m_validation.ShouldAsk ? "AskPostMessage" : "ErrorMessage",
                                ViewData["ErrorMessage"].ToString(),
                                false, false, false);
            }
            else
            {
                comparision = hc.Compare(clone);
            }

            return Json(comparision, JsonRequestBehavior.AllowGet);
            //return View(hc);
        }

        [HttpPost]
        public ActionResult StoreCase(FormCollection form)
        {
            var key = long.Parse(form["idfCase"]);
            var humanCase = (HumanCase)ModelStorage.Get(Session.SessionID, key, null);
            humanCase.ParseFormCollection(form);
            return new JsonResult { Data = null, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        private ValidationEventArgs m_validation = null;
        private bool m_ignoreErr;
        void hc_ValidationDetails(object sender, ValidationEventArgs args)
        {
            if (m_ignoreErr)
            {
                args.Continue = true;
            }
            else
            {
                m_validation = args;
                ViewData["ErrorMessage"] = Translator.GetErrorMessage(args);
            }
        }

        [HttpGet]
        public ActionResult HumanCasePicker()
        {
            var accessor = HumanCaseListItem.Accessor.Instance(null);
            IObject initObject = null;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                initObject = accessor.CreateNew(manager, null);
            }
            ViewBag.InitObject = initObject;
            FilterParams filter = SearchPanelHelper.GetDefaultFilter(accessor.SearchPanelMeta, initObject);
            ViewBag.Filter = filter;
            HumanCaseListItem.HumanCaseListItemGridModelList list = GetGridModelList(filter);
            ViewBag.GridItems = list;
            ModelStorage.Put(Session.SessionID, 0, AutoGridRoots.HumanCasePopUpSelectList, "Grid", list);

            return View(accessor);    
        }
        
        [HttpPost]
        public ActionResult HumanCasePicker(string formData)
        {
            FilterParams filter = SearchPanelHelper.SearchPanelParseValues(formData, HumanCaseListItem.Accessor.Instance(null).SearchPanelMeta);
            ViewBag.Filter = filter;
            ViewBag.InitObject = null;
            HumanCaseListItem.HumanCaseListItemGridModelList list = GetGridModelList(filter);
            ModelStorage.Put(Session.SessionID, 0, AutoGridRoots.HumanCasePopUpSelectList, "Grid", list);
            int totalRows = list.Count;
            return Json(new { data = list, total = totalRows }, JsonRequestBehavior.AllowGet);
        }

        private static HumanCaseListItem.HumanCaseListItemGridModelList GetGridModelList(FilterParams filter)
        {
            List<HumanCaseListItem> items = GetHumanCaseList(filter);
            var list = new HumanCaseListItem.HumanCaseListItemGridModelList(AutoGridRoots.HumanCasePopUpSelectList, items);                       
            return list;
        }

        private static List<HumanCaseListItem> GetHumanCaseList(FilterParams filter)
        {
            var accessor = HumanCaseListItem.Accessor.Instance(null);
            using (var dbmanager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                List<HumanCaseListItem> items = accessor.SelectListT(dbmanager, filter);
                var sample = accessor.CreateNewT(dbmanager, null);
                if (sample.IsHiddenPersonalData("GeoLocationName"))
                {
                    AddressStringHelper.RearrangeAddressDisplayString(sample, items);
                }
                return items;
            }
        }

        [HttpGet]
        public ActionResult HumanAntimicrobialTherapyPicker(long key, string name, long id)
        {
            var list = ModelStorage.Get(Session.SessionID, key, name) as EditableList<AntimicrobialTherapy>;
            IObject rootobj = (IObject) ModelStorage.GetRoot(Session.SessionID, key, null);
            var root = (long)rootobj.Key;
            if (id == 0)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    var accessor = AntimicrobialTherapy.Accessor.Instance(null);
                    AntimicrobialTherapy item = accessor.Create(manager, rootobj, key);
                    item.NewObject = true;
                    ModelStorage.Put(Session.SessionID, root, item.idfAntimicrobialTherapy, null, item);
                    return View(item);
                }
            }
            else
            {
                var item = list.Where(c => c.idfAntimicrobialTherapy == id).SingleOrDefault();
                var cloneItem = (AntimicrobialTherapy)item.Clone();
                ModelStorage.Put(Session.SessionID, root, cloneItem.idfAntimicrobialTherapy, null, cloneItem);
                return View(cloneItem);
            }
        }

        [HttpPost]
        public ActionResult SetHumanAntimicrobialTherapy(FormCollection form)
        {
            //var form = formstr.Split('&').Aggregate(new FormCollection(), (f, c) => { var m = c.Split('='); f.Add(m[0], m[1]); return f; });
            long idfAntimicrobialTherapy = long.Parse(form["idfAntimicrobialTherapy"]);
            var antibiotic = ModelStorage.Get(Session.SessionID, idfAntimicrobialTherapy, null) as AntimicrobialTherapy;
            var root = ModelStorage.Get(Session.SessionID, antibiotic.idfHumanCase, null) as HumanCase;
            m_Validation = null;
            if (antibiotic.NewObject)
            {
                antibiotic.Validation += obj_Validation;
                antibiotic.ParseFormCollection(form);
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    AntimicrobialTherapy.Accessor acc = AntimicrobialTherapy.Accessor.Instance(null);
                    acc.Validate(manager, antibiotic, true, true, true);
                }
                antibiotic.Validation -= obj_Validation;
                if (m_Validation == null)
                {
                    antibiotic.NewObject = false;
                    root.AntimicrobialTherapy.Add(antibiotic);
                }
            }
            else
            {
                antibiotic.Validation += obj_Validation;
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    AntimicrobialTherapy.Accessor acc = AntimicrobialTherapy.Accessor.Instance(null);
                    acc.Validate(manager, antibiotic, true, true, true);
                }
                antibiotic.Validation -= obj_Validation;

                if (m_Validation == null)
                {
                    var originalAntibiotic = root.AntimicrobialTherapy.Where(c => c.idfAntimicrobialTherapy == idfAntimicrobialTherapy).SingleOrDefault();
                    originalAntibiotic.ParseFormCollection(form);
                }
            }

            var data = new CompareModel();
            if (m_Validation != null)
            {
                string errorMessage = Translator.GetErrorMessage(m_Validation);
                data.Add("ErrorMessage", "ErrorMessage", "ErrorMessage", errorMessage, false, false, false);
            }
            else
            {
                ModelStorage.Remove(Session.SessionID, idfAntimicrobialTherapy, null);
            }

            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = data };
        }

        void obj_Validation(object sender, ValidationEventArgs args)
        {
            m_Validation = args;
        }

        [HttpGet]
        public ActionResult HumanContactedCasePersonPicker(long key, string name, long id)
        {
            var list = ModelStorage.Get(Session.SessionID, key, name) as EditableList<ContactedCasePerson>;
            var rootobj = (IObject) ModelStorage.GetRoot(Session.SessionID, key, null);
            var root = (long)rootobj.Key;
            if (id == 0)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    var accessor = ContactedCasePerson.Accessor.Instance(null);
                    ContactedCasePerson item = accessor.Create(manager, rootobj, key);
                    item.NewObject = true;
                    ModelStorage.Put(Session.SessionID, root, item.idfContactedCasePerson, null, item);
                    return View(item);
                }
            }
            else
            {
                var item = list.Where(c => c.idfContactedCasePerson == id).SingleOrDefault();
                ContactedCasePerson cloneItem = item.CloneWithSetup();
                ModelStorage.Put(Session.SessionID, root, cloneItem.idfContactedCasePerson, null, cloneItem);
                return View(cloneItem);
            }
        }

        [HttpPost]
        public ActionResult SetHumanContactedCasePerson(FormCollection form)
        {
            long idfContactedCasePerson = long.Parse(form["idfContactedCasePerson"]);
            var contactedPerson = ModelStorage.Get(Session.SessionID, idfContactedCasePerson, null) as ContactedCasePerson;
            var root = ModelStorage.Get(Session.SessionID, contactedPerson.idfHumanCase, null) as HumanCase;
            m_Validation = null;
            if (contactedPerson.NewObject)
            {
                var tempPerson = contactedPerson.Person.CloneWithSetup();
                contactedPerson.Validation += obj_Validation;
                contactedPerson.ParseFormCollection(form);
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    ContactedCasePerson.Accessor acc = ContactedCasePerson.Accessor.Instance(null);
                    acc.Validate(manager, contactedPerson, true, true, true);
                }
                contactedPerson.Validation -= obj_Validation;
                if (m_Validation == null)
                {
                    contactedPerson.NewObject = false;
                    contactedPerson.Person = tempPerson.CopyFrom(contactedPerson.Person);
                    root.ContactedPerson.Add(contactedPerson);
                }
            }
            else
            {
                contactedPerson.Validation += obj_Validation;
                contactedPerson.ParseFormCollection(form);
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    ContactedCasePerson.Accessor acc = ContactedCasePerson.Accessor.Instance(null);
                    acc.Validate(manager, contactedPerson, true, true, true);
                }
                contactedPerson.Validation -= obj_Validation;
                if (m_Validation == null)
                {
                    var originalContactedPerson = root.ContactedPerson.Where(c => c.idfContactedCasePerson == idfContactedCasePerson).SingleOrDefault();
                    var tempPerson = contactedPerson.Person.CloneWithSetup();
                    originalContactedPerson.ParseFormCollection(form);
                    originalContactedPerson.Person = tempPerson.CopyFrom(originalContactedPerson.Person);
                }
            }

            var data = new CompareModel();
            if (m_Validation != null)
            {
                string errorMessage = Translator.GetErrorMessage(m_Validation);
                data.Add("ErrorMessage", "ErrorMessage", "ErrorMessage", errorMessage, false, false, false);
            }
            else
            {
                ModelStorage.Remove(Session.SessionID, idfContactedCasePerson, null);
            }

            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = data };
        }

        [HttpPost]
        public ActionResult SetSelectedPatient(string root, string selectedId)
        {
            long idfHumanActual = long.Parse(selectedId);
            long key = long.Parse(root);
            long rootKey = (long)((IObject)ModelStorage.GetRoot(Session.SessionID, key, null)).Key;
            var rootHumanCase = ModelStorage.Get(Session.SessionID, rootKey, null) as HumanCase;
            var data = new CompareModel();
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var patientAccessor = Patient.Accessor.Instance(null);
                Patient patient = patientAccessor.SelectByKey(manager, idfHumanActual);
                if(string.IsNullOrEmpty(patient.strLastName))
                {
                    return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = data };
                }
                var contactedPersonAccessor = ContactedCasePerson.Accessor.Instance(null);
                ContactedCasePerson contactedPerson = contactedPersonAccessor.Create(manager, rootHumanCase, rootKey);
                contactedPerson.Person = contactedPerson.Person.CopyFrom(patient);
                long idfPatientRootHuman = patient.idfRootHuman.HasValue ? patient.idfRootHuman.Value : patient.idfHuman;
                List<ContactedCasePerson> selectedContacts = rootHumanCase.ContactedPerson.Where(x => !x.IsMarkedToDelete).ToList();
                int contactedPersonCount = selectedContacts.Where(x => x.Person.idfRootHuman.Value == idfPatientRootHuman).Count();
                if (contactedPersonCount > 0)
                {
                    string errorMessage = EidssMessages.Get("errContactedPersonDuplicates");
                    data.Add("ErrorMessage", "ErrorMessage", "ErrorMessage", errorMessage, false, false, false);
                }
                else if (rootHumanCase.Patient.idfRootHuman == idfPatientRootHuman)
                {
                    string errorMessage = EidssMessages.Get("errContactedPersonDuplicateRootHuman");
                    data.Add("ErrorMessage", "ErrorMessage", "ErrorMessage", errorMessage, false, false, false);
                }
                else
                {
                    rootHumanCase.ContactedPerson.Add(contactedPerson);
                }
            }
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = data };
        }

        public ActionResult GetCCFlexForm(long root)
        {
            var humanCase = ModelStorage.Get(Session.SessionID, root, null, false) as HumanCase;
            if ((humanCase != null) && (humanCase.FFPresenterCs != null) && (humanCase.FFPresenterCs.CurrentObservation.HasValue))
            {
                HumanCase.Accessor humanCaseAccessor = HumanCase.Accessor.Instance(null);
                humanCase.FFPresenterCs.ReadOnly = humanCaseAccessor.IsReadOnlyForEdit || humanCase.IsClosed;
                ModelStorage.Put(Session.SessionID, humanCase.idfCase, humanCase.idfCase, humanCase.FFPresenterCs.CurrentObservation.Value.ToString(), humanCase.FFPresenterCs);
                var ffDivContent = this.RenderPartialView("CCFlexForm", humanCase);
                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = ffDivContent };
            }

            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = Translator.GetMessageString("msgNowTemplate") };
        }

        public ActionResult GetEpiFlexForm(long root)
        {
            var humanCase = ModelStorage.Get(Session.SessionID, root, null, false) as HumanCase;
            if ((humanCase != null) && (humanCase.FFPresenterEpi != null) && (humanCase.FFPresenterEpi.CurrentObservation.HasValue))
            {
                HumanCase.Accessor humanCaseAccessor = HumanCase.Accessor.Instance(null);
                humanCase.FFPresenterEpi.ReadOnly = humanCaseAccessor.IsReadOnlyForEdit || humanCase.IsClosed;
                ModelStorage.Put(Session.SessionID, humanCase.idfCase, humanCase.idfCase, humanCase.FFPresenterEpi.CurrentObservation.Value.ToString(), humanCase.FFPresenterEpi);
                var ffDivContent = this.RenderPartialView("EpiFlexForm", humanCase);
                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = ffDivContent };
            }

            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = Translator.GetMessageString("msgNowTemplate") };
        }

        public ActionResult DiagnosisChange(long root, string cbFinalId, string previousDiagnosis, string newValue)
        {
            ViewBag.HumanCaseId = root;
            ViewBag.CbFinalDiagnosisId = cbFinalId;
            ViewBag.PreviousDiagnosis = previousDiagnosis;
            ViewBag.NewDiagnosis = newValue;
            
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var acc = ChangeDiagnosisHistory.Accessor.Instance(null);
                ChangeDiagnosisHistory history = acc.CreateNewT(manager, null);
                return PartialView(history.ChangeDiagnosisReasonLookup); 
            }
        }

        [HttpPost]
        public ActionResult SetNewDiagnosis(string root, string newDiagnosis, string changeDiagnosisReason)
        {
            long key = long.Parse(root);
            long rootKey = (long)((IObject)ModelStorage.GetRoot(Session.SessionID, key, null)).Key;
            var humanCase = ModelStorage.Get(Session.SessionID, rootKey, null) as HumanCase;
            HumanCase cloneHumanCase = humanCase.CloneWithSetup();
            long? newDiagnosisId = string.IsNullOrEmpty(newDiagnosis) ? 0 : Int64.Parse(newDiagnosis);
            humanCase.FinalDiagnosis = humanCase.FinalDiagnosisLookup.Where(a => a.idfsDiagnosis == newDiagnosisId).SingleOrDefault();
            int count = humanCase.DiagnosisHistory.Count;
            long? changeDiagnosisReasonId = string.IsNullOrEmpty(changeDiagnosisReason) ? 0 : Int64.Parse(changeDiagnosisReason);
            ChangeDiagnosisHistory historyItem = humanCase.DiagnosisHistory[count - 1];
            humanCase.DiagnosisHistory[count - 1].ChangeDiagnosisReason = historyItem.ChangeDiagnosisReasonLookup.FirstOrDefault(x=>x.idfsBaseReference == changeDiagnosisReasonId);
            humanCase.idfsChangeDiagnosisReason = changeDiagnosisReasonId;
            CompareModel data = humanCase.Compare(cloneHumanCase);
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = data };
        }

        [HttpGet]
        public ActionResult EmergencyNotificationReport(long id)
        {
            byte[] report;
            using (var wrapper = new ReportClientWrapper())
            {
                report = wrapper.Client.ExportHumUrgentyNotification( 
                    new BaseIdModel(ModelUserContext.CurrentLanguage, id, ModelUserContext.Instance.IsArchiveMode));
            }
            const string fileName = "EmergencyNotificationReport.pdf";
            Response.AppendHeader("content-disposition", "inline; filename=" + fileName);
            return File(report, "application/pdf", fileName);
        }

        [HttpGet]
        public ActionResult HumanInvestigationReport(long caseId, long epiId, long csId, long diagnosisId)
        {
            byte[] report;
            using (var wrapper = new ReportClientWrapper())
            {
                var model = new HumIdModel(ModelUserContext.CurrentLanguage, caseId, epiId, csId, diagnosisId,
                                           ModelUserContext.Instance.IsArchiveMode)
                    {
                        OrganizationId = Convert.ToInt64(EidssUserContext.User.OrganizationID),
                        ForbiddenGroups = EidssUserContext.User.ForbiddenPersonalDataGroups
                    };
                report = wrapper.Client.ExportHumCaseInvestigation(model);
            }
            const string fileName = "HumanInvestigationReport.pdf";
            Response.AppendHeader("content-disposition", "inline; filename=" + fileName);
            return File(report, "application/pdf", fileName);
        }
    }
}
