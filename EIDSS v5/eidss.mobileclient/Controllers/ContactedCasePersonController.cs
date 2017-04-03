using System;
using System.Collections.Generic;
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
    public class ContactedCasePersonController : Controller
    {
        private ValidationEventArgs m_Validation;

        [HttpGet]
        [SessionExpireFilter]
        public ActionResult ContactDetails(long rootKey, long contactedCasePersonId, bool getFromSession = true)
        {
            HumanCase.Accessor humanCaseAccessor = HumanCase.Accessor.Instance(null);
            ViewBag.CanUpdate = humanCaseAccessor.CanUpdate;

            ViewBag.RootKey = rootKey;

            if (getFromSession)
            {
                var contactedCasePerson =
                    (ContactedCasePerson) ModelStorage.Get(Session.SessionID, contactedCasePersonId, null);
                return View(contactedCasePerson);
            }

            var humanCase = (HumanCase) ModelStorage.GetRoot(Session.SessionID, rootKey, null);
            EditableList<ContactedCasePerson> list = humanCase.ContactedPerson;
            var root = (long) ((HumanCase) ModelStorage.GetRoot(Session.SessionID, rootKey, null)).Key;
            ContactedCasePerson item;
            if (contactedCasePersonId == 0)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    var accessor = ContactedCasePerson.Accessor.Instance(null);
                    item = accessor.Create(manager, humanCase, rootKey);
                    item.NewObject = true;
                    ModelStorage.Put(Session.SessionID, root, item.idfContactedCasePerson, null, item);
                    return View(item);
                }
            }

            item = list.SingleOrDefault(c => c.idfContactedCasePerson == contactedCasePersonId);
            ModelStorage.Put(Session.SessionID, root, item.idfContactedCasePerson, null, item);
            return View(item);
        }

        [HttpPost]
        [SessionExpireFilter]
        public ActionResult StoreContactDetails(FormCollection form)
        {
            var key = Int64.Parse(form["idfContactedCasePerson"]);
            var contactedCasePerson = (ContactedCasePerson)ModelStorage.Get(Session.SessionID, key, null);
            string errorMessage;
            bool isDatesValid = DateTimeHelper.TryParseCustomDates(form, out errorMessage);
            var data = new CompareModel();
            if (!isDatesValid)
            {
                data.Add("ErrorMessage", "ErrorMessage", "ErrorMessage", errorMessage, false, false, false);
            }
            else
            {
                contactedCasePerson.ParseFormCollection(form);
            }
            return new JsonResult { Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        [SessionExpireFilter]
        public ActionResult SaveContactedCasePerson(FormCollection form)
        {
            string errorMessage;
            bool isDatesValid = DateTimeHelper.TryParseCustomDates(form, out errorMessage);
            var data = new CompareModel();
            if (!isDatesValid)
            {
                data.Add("ErrorMessage", "ErrorMessage", "ErrorMessage", errorMessage, false, false, false);
                return new JsonResult { Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

            long idfContactedCasePerson = long.Parse(form["idfContactedCasePerson"]);
            var contactedPerson = (ContactedCasePerson)ModelStorage.Get(Session.SessionID, idfContactedCasePerson, null);
            var humanCase = (HumanCase)ModelStorage.Get(Session.SessionID, contactedPerson.idfHumanCase, null);
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
                    humanCase.ContactedPerson.Add(contactedPerson);
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
                    var originalContactedPerson = humanCase.ContactedPerson.Where(c => c.idfContactedCasePerson == idfContactedCasePerson).SingleOrDefault();
                    var tempPerson = contactedPerson.Person.CloneWithSetup();
                    originalContactedPerson.ParseFormCollection(form);
                    originalContactedPerson.Person = tempPerson.CopyFrom(originalContactedPerson.Person);
                }
            }

            if (m_Validation != null)
            {
                errorMessage = Translator.GetErrorMessage(m_Validation);
                data.Add("ErrorMessage", "ErrorMessage", "ErrorMessage", errorMessage, false, false, false);
            }
            else
            {
                ModelStorage.Remove(Session.SessionID, idfContactedCasePerson, null);
            }

            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = data };
        }

        [HttpPost]
        [SessionExpireFilter]
        public ActionResult RemoveContactedCasePerson(long rootKey, long contactedCasePersonId)
        {
            var humanCase = (HumanCase)ModelStorage.GetRoot(Session.SessionID, rootKey, null);
            EditableList<ContactedCasePerson> list = humanCase.ContactedPerson;
            ContactedCasePerson item = list.Where(c => c.idfContactedCasePerson == contactedCasePersonId).SingleOrDefault();
            list.Remove(item);
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = null };
        }

        [HttpGet]
        [SessionExpireFilter]
        public ActionResult PatientsList(long rootKey, long contactedCasePersonId)
        {
            ViewBag.IdfCase = rootKey;
            ViewBag.ContactedCasePersonId = contactedCasePersonId;
            var contactedPerson = (ContactedCasePerson)ModelStorage.Get(Session.SessionID, contactedCasePersonId, null);
            List<PatientListItem> patients = GetPatientsList(contactedPerson.Person);
            ViewBag.ItemsCount = patients == null ? 0 : patients.Count;
            List<PatientListItem> resultList = patients == null ? patients : patients.Take(100).ToList();
            return View(resultList);
        }

        private static List<PatientListItem> GetPatientsList(Patient patientInfoForSearch)
        {
            var accessor = PatientListItem.Accessor.Instance(null);
            FilterParams filter = GetFilterForPatientsList(patientInfoForSearch);
            using (var dbmanager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                List<PatientListItem> patients = accessor.SelectListT(dbmanager, filter);
                List<PatientListItem> resultPatients = patients.Where(x => !string.IsNullOrEmpty(x.strLastName.Trim())).ToList();
                return resultPatients;
            }
        }

        private static FilterParams GetFilterForPatientsList(Patient patientInfoForSearch)
        {
            var filter = new FilterParams();
            if (patientInfoForSearch.CurrentResidenceAddress.Region != null)
            {
                filter.Add("idfsRegion", "=", patientInfoForSearch.CurrentResidenceAddress.Region.idfsRegion);
            }
            if (patientInfoForSearch.CurrentResidenceAddress.Rayon != null)
            {
                filter.Add("idfsRayon", "=", patientInfoForSearch.CurrentResidenceAddress.Rayon.idfsRayon);
            }
            if (!string.IsNullOrEmpty(patientInfoForSearch.strFirstName))
            {
                filter.Add("strFirstName", "like", String.Format("%{0}%", patientInfoForSearch.strFirstName));
            }
            if (!string.IsNullOrEmpty(patientInfoForSearch.strSecondName))
            {
                filter.Add("strSecondName", "like", String.Format("%{0}%", patientInfoForSearch.strSecondName));
            }
            if (!string.IsNullOrEmpty(patientInfoForSearch.strLastName))
            {
                filter.Add("strLastName", "like", String.Format("%{0}%", patientInfoForSearch.strLastName));
            }
            if (patientInfoForSearch.datDateofBirth.HasValue)
            {
                filter.Add("datDateofBirth", ">=", patientInfoForSearch.datDateofBirth.Value);
                filter.Add("datDateofBirth", "<", patientInfoForSearch.datDateofBirth.Value.AddDays(1));
            }
            return filter;
        }

        [HttpPost]
        [SessionExpireFilter]
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
                var contactedPersonAccessor = ContactedCasePerson.Accessor.Instance(null);
                ContactedCasePerson contactedPerson = contactedPersonAccessor.Create(manager, rootHumanCase, rootKey);
                contactedPerson.Person = contactedPerson.Person.CopyFrom(patient);
                long idfPatientRootHuman = patient.idfRootHuman.HasValue ? patient.idfRootHuman.Value : patient.idfHuman;
                int contactedPersonCount = rootHumanCase.ContactedPerson.Where(x => x.Person.idfRootHuman.Value == idfPatientRootHuman).Count();
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
                    //rootHumanCase.ContactedPerson.Add(contactedPerson);
                    //TODO: remove previous contact
                    contactedPerson.NewObject = true;
                    ModelStorage.Put(Session.SessionID, key, contactedPerson.idfContactedCasePerson, null, contactedPerson);
                    data.Add("idfContactedCasePerson", "", "", contactedPerson.idfContactedCasePerson.ToString(), false, false, false);
                }
            }
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = data };
        }

        void obj_Validation(object sender, ValidationEventArgs args)
        {
            m_Validation = args;
        }
    }
}
