using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLToolkit.EditableObjects;
using bv.model.BLToolkit;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Reports;
using eidss.model.Reports.Common;
using eidss.model.Schema;
using bv.model.Model.Core;
using eidss.webclient.Utils;
using eidss.model.Resources;
using eidss.web.common.Controllers;
using eidss.web.common.Utils;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.ComponentModel;

namespace eidss.webclient.Controllers
{
    [AuthorizeEIDSS]
    public class HumanCaseController : BvController
    {
        public ActionResult Demographic()
        {
            return View();
        }

        public ActionResult Investigation()
        {
            return View();
        }

        public ActionResult Index()
        {
            return IndexInternal
                <HumanCaseListItem.Accessor, HumanCaseListItem, HumanCaseListItem.HumanCaseListItemGridModelList>
                (HumanCaseListItem.Accessor.Instance(null), AutoGridRoots.HumanCaseList, false);
        }

        public ActionResult IndexAjax([DataSourceRequest] DataSourceRequest request, FormCollection form)
        {
            return IndexInternalAjax
                <HumanCaseListItem.Accessor, HumanCaseListItem, HumanCaseListItem.HumanCaseListItemGridModelList>
                (form, HumanCaseListItem.Accessor.Instance(null), AutoGridRoots.HumanCaseList, request);
        }

        public ActionResult GetDeduplicates([DataSourceRequest] DataSourceRequest request, FormCollection form)
        {
            var strCaseID = form["String_strCaseID"];
            form.Remove("String_strCaseID");
            if (!string.IsNullOrEmpty(strCaseID))
            {
                var param = new FilterParams();
                param.Add("strCaseID", "!=", strCaseID);
                form.Add("StaticFilter", param.Serialize());
            }

            var newForm = new FormCollection();
            foreach (var p in form.AllKeys)
            {
                var str = HttpUtility.UrlDecode(form[p]);
                newForm.Add(p, str);
            }

            return IndexInternalAjax
                <HumanCaseDeduplicationListItem.Accessor, HumanCaseDeduplicationListItem,
                    HumanCaseDeduplicationListItem.HumanCaseDeduplicationListItemGridModelList>
                (newForm, HumanCaseDeduplicationListItem.Accessor.Instance(null), AutoGridRoots.HumanCaseDeduplicationList,
                 request);
        }

        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request, HumanCaseListItem item)
        {
            var result = item.MarkToDelete();
            return Json(new[] {item}.ToDataSourceResult(request, ModelState));
        }


        public ActionResult Duplicates()
        {
            return View(HumanCaseDeduplicationListItem.Accessor.Instance(null));
        }

        [HttpGet]
        public ActionResult Details(long? id)
        {
            return DetailsInternal<HumanCase.Accessor, HumanCase>(id, HumanCase.Accessor.Instance(null),
                 (int) HACode.Human, null, null, null, c => { 
                     ModelStorage.Put(Session.SessionID, c.idfCase, c.idfCase, c.ObjectIdent + "AntimicrobialTherapy", c.AntimicrobialTherapy);
                     ViewBag.IdfEpiObservation = c.idfEpiObservation; ViewBag.IdfCSObservation = c.idfCSObservation;
                     ViewBag.DiagnosisId = c.idfsFinalDiagnosis.HasValue ? c.idfsFinalDiagnosis : c.idfsTentativeDiagnosis; 
                 });
        }

        [HttpPost]
        public ActionResult Details(FormCollection form)
        {
            try
            {
                return DetailsInternalAjax<HumanCase.Accessor, HumanCase>(form, HumanCase.Accessor.Instance(null), null,
                    (o, c) =>
                        {
                            if (c.idfsCaseProgressStatus == (long)CaseStatusEnum.Closed)
                                c.SetChange();
                        }, null, null);
            }
            catch (DbModelRaiserrorException ex)
            {
                if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
                {
                    string errorMessage;
                    if (ex.InnerException.Message == "msgNotUniquePatientID")
                    {
                        string formKey = form.AllKeys.FirstOrDefault(x => x.Contains("_strPersonID"));
                        string strPersonId = formKey == null ? "" : form[formKey];
                        errorMessage = string.Format(Translator.GetMessageString(ex.InnerException.Message), strPersonId);
                    }
                    else
                    {
                        errorMessage = Translator.GetMessageString(ex.InnerException.Message);
                    }
                    var comparision = new CompareModel();
                    comparision.Add("ErrorMessage", "ErrorMessage", "ErrorMessage", errorMessage, false, false, false);
                    return Json(comparision, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    throw;
                }
            }
        }

        [HttpPost]
        public ActionResult StoreCase(FormCollection form)
        {
            var key = long.Parse(form["idfCase"]);
            var humanCase = (HumanCase)ModelStorage.Get(Session.SessionID, key, null);
            humanCase.ParseFormCollection(form);
            return new JsonResult { Data = "", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }


        private ActionResult _HumanCasePicker(string objectId, string functionName, bool isMultiSelection, bool showInInternalWindow, FilterParams filter)
        {
            ViewBag.ObjectId = objectId;
            ViewBag.FunctionName = functionName;
            ViewBag.ShowInInternalWindow = showInInternalWindow;
            ViewBag.IsMultiSelection = isMultiSelection;

            return IndexInternal<HumanCaseListItem.Accessor, HumanCaseListItem, HumanCaseListItem.HumanCaseListItemGridModelList>
                (HumanCaseListItem.Accessor.Instance(null), AutoGridRoots.HumanCasePopUpSelectList, true, filter, "HumanCasePicker");
            }

        [HttpGet]
        public ActionResult HumanCasePickerForOutbreak(string objectId, string functionName, bool isMultiSelection, bool showInInternalWindow)
        {
            var rootObject = (Outbreak)ModelStorage.Get(Session.SessionID, long.Parse(objectId), null);
            FilterParams filter = null;
            if (rootObject.Diagnosis != null)
            {
                filter = new FilterParams();
                if (rootObject.Diagnosis.blnGroup.HasValue && rootObject.Diagnosis.blnGroup.Value)
                    filter.Add("idfsDiagnosisGroup", "=", rootObject.Diagnosis.idfsDiagnosisOrDiagnosisGroup);
                else if (rootObject.Diagnosis.idfsDiagnosisGroup.HasValue && rootObject.Diagnosis.idfsDiagnosisGroup.Value != 0)
                    filter.Add("idfsDiagnosisGroup", "=", rootObject.Diagnosis.idfsDiagnosisGroup);
                else
                    filter.Add("idfsDiagnosis", "=", rootObject.Diagnosis.idfsDiagnosisOrDiagnosisGroup, true);
            }
            return _HumanCasePicker(objectId, functionName, isMultiSelection, showInInternalWindow, filter);
        }
        
        [HttpGet]
        public ActionResult HumanCasePicker(string objectId, string functionName, bool isMultiSelection, bool showInInternalWindow)
        {
            return _HumanCasePicker(objectId, functionName, isMultiSelection, showInInternalWindow, null);
        }

        [HttpGet]
        public ActionResult HumanAntimicrobialTherapyPicker(long key, string name, long id)
        {
            return PickerInternal<AntimicrobialTherapy.Accessor, AntimicrobialTherapy, HumanCase>(key, id, name, AntimicrobialTherapy.Accessor.Instance(null), null,
                null,
                (m, a, p) => a.Create(m, p, p.idfCase),
                null);
        }

        [HttpPost]
        public ActionResult SetHumanAntimicrobialTherapy(FormCollection form)
        {
            return PickerInternal<AntimicrobialTherapy.Accessor, AntimicrobialTherapy, HumanCase>(form, AntimicrobialTherapy.Accessor.Instance(null), null, 
                p => p.AntimicrobialTherapy,
                (i, o) => i.idfAntimicrobialTherapy == o.idfAntimicrobialTherapy,
                null);
        }


        [HttpGet]
        public ActionResult HumanContactedCasePersonPicker(long key, string name, long id)
        {
            return PickerInternal<ContactedCasePerson.Accessor, ContactedCasePerson, HumanCase>(key, id, name, ContactedCasePerson.Accessor.Instance(null), null,
                null, 
                (m, a, p) => a.Create(m, p, p.idfCase), 
                null);
        }

        [HttpPost]
        public ActionResult SetHumanContactedCasePerson(FormCollection form)
        {
            return PickerInternal<ContactedCasePerson.Accessor, ContactedCasePerson, HumanCase>(form,
                ContactedCasePerson.Accessor.Instance(null), null, p => p.ContactedPerson,
                (i, o) => i.idfContactedCasePerson == o.idfContactedCasePerson, null);
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
                contactedPerson.Person = contactedPerson.Person.CopyFrom(manager, patient);
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


        private void SetAddressLookup<T>(CompareModel data, List<T> lookup, string starts, string ends, bool mandatory = false)
            where T : IObject
        {
            if (data.Values.Any(c => c.Key.StartsWith(starts) && c.Key.EndsWith(ends)))
            {
                var item = data.Values.FirstOrDefault(c => c.Key.StartsWith(starts) && c.Key.EndsWith(ends));
                item.Value.items = lookup.Select(c => new CompareModel.ComboBoxItem() { id = c.Key, name = c.ToStringProp }).ToArray();
                if (mandatory)
                    item.Value.mandatory = true;
            }
        }

        //SetSelectedPatientAsRoot
        [HttpPost]
        public ActionResult SetSelectedPatientAsRoot(string root, string selectedId)
        {
            long idfHumanActual = long.Parse(selectedId);
            long key = long.Parse(root);
            long rootKey = (long)((IObject)ModelStorage.GetRoot(Session.SessionID, key, null)).Key;
            var rootHumanCase = ModelStorage.Get(Session.SessionID, rootKey, null) as HumanCase;
            var clone = (IObject)rootHumanCase.Clone();
            var data = new CompareModel();
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var patientAccessor = Patient.Accessor.Instance(null);
                Patient patient = patientAccessor.SelectByKey(manager, idfHumanActual);
                rootHumanCase.Patient = rootHumanCase.Patient.CopyFrom(manager, patient);
                rootHumanCase.Patient.intPatientAgeFromCase = rootHumanCase.CalcPatientAge();
                rootHumanCase.Patient.HumanAgeType = rootHumanCase.Patient.HumanAgeTypeLookup.SingleOrDefault(a => a.idfsBaseReference == rootHumanCase.CalcPatientAgeType());
                HumanCase.Accessor.Instance(null).SetupChildHandlers(rootHumanCase, rootHumanCase.Patient);
                data = rootHumanCase.Compare(clone);

                SetAddressLookup(data, rootHumanCase.Patient.CurrentResidenceAddress.RegionLookup, "CurrentResidenceAddress_", "_Region", true);
                SetAddressLookup(data, rootHumanCase.Patient.CurrentResidenceAddress.RayonLookup, "CurrentResidenceAddress_", "_Rayon", true);
                SetAddressLookup(data, rootHumanCase.Patient.CurrentResidenceAddress.SettlementLookup, "CurrentResidenceAddress_", "_Settlement");
                SetAddressLookup(data, rootHumanCase.Patient.CurrentResidenceAddress.StreetLookup, "CurrentResidenceAddress_", "_Street");
                SetAddressLookup(data, rootHumanCase.Patient.CurrentResidenceAddress.PostCodeLookup, "CurrentResidenceAddress_", "_PostCode");
                SetAddressLookup(data, rootHumanCase.Patient.EmployerAddress.RegionLookup, "EmployerAddress_", "_Region");
                SetAddressLookup(data, rootHumanCase.Patient.EmployerAddress.RayonLookup, "EmployerAddress_", "_Rayon");
                SetAddressLookup(data, rootHumanCase.Patient.EmployerAddress.SettlementLookup, "EmployerAddress_", "_Settlement");
                SetAddressLookup(data, rootHumanCase.Patient.EmployerAddress.StreetLookup, "EmployerAddress_", "_Street");
                SetAddressLookup(data, rootHumanCase.Patient.EmployerAddress.PostCodeLookup, "EmployerAddress_", "_PostCode");
                SetAddressLookup(data, rootHumanCase.Patient.RegistrationAddress.RegionLookup, "RegistrationAddress_", "_Region");
                SetAddressLookup(data, rootHumanCase.Patient.RegistrationAddress.RayonLookup, "RegistrationAddress_", "_Rayon");
                SetAddressLookup(data, rootHumanCase.Patient.RegistrationAddress.SettlementLookup, "RegistrationAddress_", "_Settlement");
                SetAddressLookup(data, rootHumanCase.Patient.RegistrationAddress.StreetLookup, "RegistrationAddress_", "_Street");
                SetAddressLookup(data, rootHumanCase.Patient.RegistrationAddress.PostCodeLookup, "RegistrationAddress_", "_PostCode");

                ModelStorage.Put(Session.SessionID, rootKey, rootHumanCase.Patient.idfHuman, null, rootHumanCase.Patient);
                ModelStorage.Put(Session.SessionID, rootKey, rootHumanCase.Patient.CurrentResidenceAddress.idfGeoLocation, null, rootHumanCase.Patient.CurrentResidenceAddress);
                ModelStorage.Put(Session.SessionID, rootKey, rootHumanCase.Patient.EmployerAddress.idfGeoLocation, null, rootHumanCase.Patient.EmployerAddress);
                ModelStorage.Put(Session.SessionID, rootKey, rootHumanCase.Patient.RegistrationAddress.idfGeoLocation, null, rootHumanCase.Patient.RegistrationAddress);
            }
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = data };
        }

        [HttpPost]
        public ActionResult DeleteLinkToRootHuman(string root)
        {
            long key = long.Parse(root);
            long rootKey = (long)((IObject)ModelStorage.GetRoot(Session.SessionID, key, null)).Key;
            var rootHumanCase = ModelStorage.Get(Session.SessionID, rootKey, null) as HumanCase;
            var clone = (IObject)rootHumanCase.Clone();
            var data = new CompareModel();
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                rootHumanCase.Patient = rootHumanCase.Patient.Clear(manager);
                HumanCase.Accessor.Instance(null).SetupChildHandlers(rootHumanCase, rootHumanCase.Patient);
                data = rootHumanCase.Compare(clone);

                SetAddressLookup(data, rootHumanCase.Patient.CurrentResidenceAddress.RegionLookup, "CurrentResidenceAddress_", "_Region", true);
                SetAddressLookup(data, rootHumanCase.Patient.CurrentResidenceAddress.RayonLookup, "CurrentResidenceAddress_", "_Rayon", true);
                SetAddressLookup(data, rootHumanCase.Patient.CurrentResidenceAddress.SettlementLookup, "CurrentResidenceAddress_", "_Settlement");
                SetAddressLookup(data, rootHumanCase.Patient.CurrentResidenceAddress.StreetLookup, "CurrentResidenceAddress_", "_Street");
                SetAddressLookup(data, rootHumanCase.Patient.CurrentResidenceAddress.PostCodeLookup, "CurrentResidenceAddress_", "_PostCode");
                SetAddressLookup(data, rootHumanCase.Patient.EmployerAddress.RegionLookup, "EmployerAddress_", "_Region");
                SetAddressLookup(data, rootHumanCase.Patient.EmployerAddress.RayonLookup, "EmployerAddress_", "_Rayon");
                SetAddressLookup(data, rootHumanCase.Patient.EmployerAddress.SettlementLookup, "EmployerAddress_", "_Settlement");
                SetAddressLookup(data, rootHumanCase.Patient.EmployerAddress.StreetLookup, "EmployerAddress_", "_Street");
                SetAddressLookup(data, rootHumanCase.Patient.EmployerAddress.PostCodeLookup, "EmployerAddress_", "_PostCode");
                SetAddressLookup(data, rootHumanCase.Patient.RegistrationAddress.RegionLookup, "RegistrationAddress_", "_Region");
                SetAddressLookup(data, rootHumanCase.Patient.RegistrationAddress.RayonLookup, "RegistrationAddress_", "_Rayon");
                SetAddressLookup(data, rootHumanCase.Patient.RegistrationAddress.SettlementLookup, "RegistrationAddress_", "_Settlement");
                SetAddressLookup(data, rootHumanCase.Patient.RegistrationAddress.StreetLookup, "RegistrationAddress_", "_Street");
                SetAddressLookup(data, rootHumanCase.Patient.RegistrationAddress.PostCodeLookup, "RegistrationAddress_", "_PostCode");

                ModelStorage.Put(Session.SessionID, rootKey, rootHumanCase.Patient.idfHuman, null, rootHumanCase.Patient);
                ModelStorage.Put(Session.SessionID, rootKey, rootHumanCase.Patient.CurrentResidenceAddress.idfGeoLocation, null, rootHumanCase.Patient.CurrentResidenceAddress);
                ModelStorage.Put(Session.SessionID, rootKey, rootHumanCase.Patient.EmployerAddress.idfGeoLocation, null, rootHumanCase.Patient.EmployerAddress);
                ModelStorage.Put(Session.SessionID, rootKey, rootHumanCase.Patient.RegistrationAddress.idfGeoLocation, null, rootHumanCase.Patient.RegistrationAddress);
            }
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = data };
        }

        public ActionResult GetCCFlexForm(long root)
        {
            var humanCase = ModelStorage.Get(Session.SessionID, root, null, false) as HumanCase;
            if ((humanCase != null) && (humanCase.FFPresenterCs != null) && (humanCase.FFPresenterCs.CurrentObservation.HasValue) && humanCase.idfsDiagnosis.HasValue)
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
            if ((humanCase != null) && (humanCase.FFPresenterEpi != null) && (humanCase.FFPresenterEpi.CurrentObservation.HasValue) && humanCase.idfsDiagnosis.HasValue)
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

        public ActionResult IsDiagnosisChanged(long root)
        {
            var humanCase = ModelStorage.Get(Session.SessionID, root, null) as HumanCase;
            var data = new CompareModel();
            if (!humanCase.DiagnosisHistory.Any(c => !c.IsMarkedToDelete))
            {
                string errorMessage = EidssMessages.Get("mbEmptyChangeDiagnosisHistory");
                data.Add("ErrorMessage", "ErrorMessage", "ErrorMessage", errorMessage, false, false, false);
            }
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = data };
        }

        public ActionResult DiagnosisHistory(long root)
        {
            var humanCase = ModelStorage.Get(Session.SessionID, root, null) as HumanCase;
            ModelStorage.Put(Session.SessionID, humanCase.idfCase, humanCase.idfCase, humanCase.ObjectIdent + "DiagnosisHistory", humanCase.DiagnosisHistory);
            return View(humanCase);
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
            try
            {
                byte[] report;
                using (var wrapper = new ReportClientWrapper())
                {
                    var model = new BaseIdModel(ModelUserContext.CurrentLanguage, id, ModelUserContext.Instance.IsArchiveMode);
                    report = wrapper.Client.ExportHumUrgentyNotification(model);
                }
                return ReportResponse(report, "EmergencyNotificationReport.pdf");
            }
            catch
            {
                return new JsonResult {JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = null};
            }
        }

        [HttpGet]
        public ActionResult HumanInvestigationReport(long caseId, long epiId, long csId, long diagnosisId)
        {
            try
            {
            byte[] report;
            using (var wrapper = new ReportClientWrapper())
            {
                var model = new HumIdModel(ModelUserContext.CurrentLanguage, caseId, epiId, csId, diagnosisId,ModelUserContext.Instance.IsArchiveMode);
                report = wrapper.Client.ExportHumCaseInvestigation(model);
            }
            return ReportResponse(report, "HumanInvestigationReport.pdf");
        }
            catch
            {
                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = null };
            }
        }
    }
}
