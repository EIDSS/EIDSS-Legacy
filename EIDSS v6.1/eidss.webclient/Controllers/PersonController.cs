using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BLToolkit.EditableObjects;
using Kendo.Mvc.UI;
using bv.model.BLToolkit;
using eidss.model.Core;
using eidss.model.Schema;
using bv.model.Model.Core;
using eidss.web.common.Controllers;
using eidss.web.common.Utils;
using eidss.webclient.Utils;
using eidss.model.Resources;

namespace eidss.webclient.Controllers
{
    [AuthorizeEIDSS]
    public class PersonController : BvController
    {
        public ActionResult Index()
        {
            return IndexInternal<PatientListItem.Accessor, PatientListItem, PatientListItem.PatientListItemGridModelList>
                (PatientListItem.Accessor.Instance(null), AutoGridRoots.PatientList, false);
        }

        [CompressFilter]
        public ActionResult IndexAjax([DataSourceRequest]DataSourceRequest request, FormCollection form)
        {
            return IndexInternalAjax<PatientListItem.Accessor, PatientListItem, PatientListItem.PatientListItemGridModelList>
                (form, PatientListItem.Accessor.Instance(null), AutoGridRoots.PatientList, request);
        }

        [HttpGet]
        public ActionResult Details(long? id)
        {
            return DetailsInternal<Patient.Accessor, Patient>(id, eidss.model.Schema.Patient.Accessor.Instance(null), null, null, null, null, null);
        }

        [HttpPost]
        [CompressFilter]
        public ActionResult Details(FormCollection form)
        {
            try
            {
                return DetailsInternalAjax<Patient.Accessor, Patient>(form, model.Schema.Patient.Accessor.Instance(null), null, null, null, null);
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


        public ActionResult Patient(long root, Patient patient, bool isAgeVisible = true, bool isCoordinatesFieldsVisible = false, bool isLastNameSearchVisible = false)
        {
            ObjectStorage.Put(ModelUserContext.ClientID, root, patient.idfHuman, null, patient);
            ViewBag.Root = root;
            ViewBag.IsAgeVisible = isAgeVisible;
            ViewBag.IsCoordinatesFieldsVisible = isCoordinatesFieldsVisible;
            ViewBag.IsLastNameSearchVisible = isLastNameSearchVisible;
            return PartialView(patient);
        }

        public ActionResult PatientInTwoColumns(long root, Patient patient, bool isAgeVisible = true, bool isCoordinatesFieldsVisible = false)
        {
            ObjectStorage.Put(ModelUserContext.ClientID, root, patient.idfHuman, null, patient);
            ViewBag.IsAgeVisible = isAgeVisible;
            ViewBag.IsCoordinatesFieldsVisible = isCoordinatesFieldsVisible;
            return PartialView(patient);
        }


        public ActionResult InlinePersonPicker(IObject obj, long objectId, string idfsPatientPropertyName, string strPatientPropertyName, bool showInInternalWindow = false)
        {
            ViewBag.IdfsPatientPropertyName = idfsPatientPropertyName;
            ViewBag.StrPatientPropertyName = strPatientPropertyName;
            ViewBag.ShowInInternalWindow = showInInternalWindow;
            ViewBag.MainDivId = string.Format("divPatientSearchPicker_{0}_{1}", objectId, idfsPatientPropertyName);
            ViewBag.BtnViewPicker = string.Format("btnPatientViewPicker_{0}_{1}", objectId, idfsPatientPropertyName);
            ViewBag.BtnSearchPicker = string.Format("btnPatientSearchPicker_{0}_{1}", objectId, idfsPatientPropertyName);
            ViewBag.BtnClianPicker = string.Format("btnPatientClian_{0}_{1}", objectId, idfsPatientPropertyName);

            SetButtonsReadOnlyInViewBag(objectId, idfsPatientPropertyName);

            string onSelectItemClick = string.Format("person.showSearchPicker(\"{0}\", \"{1}\", \"{2}\", \"{3}\")",
                objectId, idfsPatientPropertyName, strPatientPropertyName, showInInternalWindow);
            ViewBag.OnSelectItemClick = onSelectItemClick;

            string onClianButtonClick = string.Format("person.onPickerValueChanged(\"{0}\", \"{1}\", \"{2}\", \"\", \"{3}\")",
                objectId, idfsPatientPropertyName, strPatientPropertyName, showInInternalWindow);
            ViewBag.OnClianButtonClick = onClianButtonClick;

            return PartialView(obj);
        }

        private void SetButtonsReadOnlyInViewBag(long objectId, string idfsPatientPropertyName)
        {
            //var rootObject = (IObject)ModelStorage.Get(ModelUserContext.ClientID, objectId, null);
            ObjectStorage.Using<IObject, bool>(rootObject =>
                {
                    IObjectPermissions permission = rootObject.GetPermissions();
                    bool isRootReadOnly = permission == null ? false : permission.IsReadOnlyForEdit;

                    bool isControlReadOnly = rootObject.IsReadOnly(idfsPatientPropertyName) || isRootReadOnly;
                    ViewBag.IsSearchButtonReadOnly = isControlReadOnly;

                    object patient = rootObject.GetValue(idfsPatientPropertyName);
                    Int64 patientId = 0;
                    if (patient != null)
                    {
                        Int64.TryParse(patient.ToString(), out patientId);
                    }
                    ViewBag.IsClianButtonReadOnly = isControlReadOnly/* || patientId == 0*/;

                    ViewBag.IsViewButtonReadOnly = patientId == 0;
                    return false;
                }, ModelUserContext.ClientID, objectId, null);
        }


        [HttpGet]
        public ActionResult PersonPicker(string objectId, string idfsPatientPropertyName, string strPatientPropertyName, bool showInInternalWindow = false)
        {
            ViewBag.ObjectId = objectId;
            ViewBag.IdfsPatientPropertyName = idfsPatientPropertyName;
            ViewBag.StrPatientPropertyName = strPatientPropertyName;
            ViewBag.ShowInInternalWindow = showInInternalWindow;

            IObject initObject = null;
            var accessor = PatientListItem.Accessor.Instance(null);
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                initObject = accessor.CreateNew(manager, null);
            }
            ViewBag.InitObject = initObject;
            FilterParams filter = SearchPanelHelper.GetDefaultFilter(accessor.SearchPanelMeta, initObject);
            ViewBag.Filter = filter;

            return View(accessor);
        }

        [HttpPost]
        public ActionResult SetSelectedPerson(string objectId, string idfsPatientPropertyName, string strPatientPropertyName, string selectedItemId)
        {
            return SetSelectedPersonWithIgnore(objectId, idfsPatientPropertyName, strPatientPropertyName, selectedItemId, 0);
        }

        [HttpPost]
        public ActionResult SetSelectedPersonWithIgnore(string objectId, string idfsPatientPropertyName, string strPatientPropertyName, string selectedItemId, int ignoreErr)
        {
            long key = long.Parse(objectId);
            //var rootObject = (IObject)ModelStorage.Get(ModelUserContext.ClientID, key, null);
            return ObjectStorage.Using<IObject, ActionResult>(rootObject =>
                {
                    var data = new CompareModel();
                    using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                    {
                        using (IObject cloneObject = rootObject.CloneWithSetup(manager))
                        {
                            m_ignoreErr = ignoreErr;
                            ViewBag.ErrorMessage = null;
                            rootObject.Validation += ValidationDetails;
                            rootObject.SetValue(idfsPatientPropertyName, selectedItemId);
                            rootObject.Validation -= ValidationDetails;

                            if (ViewBag.ErrorMessage != null)
                            {
                                data.Add("ErrorMessage", "/Person/SetSelectedPersonWithIgnore?objectId=" + objectId + "&idfsPatientPropertyName=" + idfsPatientPropertyName + "&strPatientPropertyName=" + strPatientPropertyName + "&selectedItemId=" + selectedItemId + "&ignoreErr=1",
                                    validation.ValidationType == ValidationEventType.Error ? "ErrorMessage" : (validation.ValidationType == ValidationEventType.Warning ? "WarningUrlMessage" : "AskUrlMessage"),
                                    ViewBag.ErrorMessage.ToString(),
                                    false, false, false);
                            }
                            else
                            {
                                string patientName = string.Empty;
                                if (!string.IsNullOrEmpty(selectedItemId))
                                {
                                    Int64 id = Int64.Parse(selectedItemId);
                                    patientName = GetPatientNameById(id);
                                }
                                rootObject.SetValue(strPatientPropertyName, patientName);

                                data = rootObject.Compare(cloneObject);
                            }
                        }
                    }
                    return new JsonResult { Data = data ?? new CompareModel(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }, ModelUserContext.ClientID, key, null);
        }

        [HttpGet]
        public ActionResult FindInPersonIdentityService(long idfCase, long idfHuman, long idfContactedCasePerson)
        {
            if (idfCase == 0 && idfContactedCasePerson == 0)
            {
                return ObjectStorage.Using<Patient, ActionResult>(patient =>
                {
                    using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    {
                        var clone = eidss.model.Schema.Patient.Accessor.Instance(null).CreateNewT(manager, patient);
                        clone.idfCase = idfCase;
                        clone.idfContactedCasePerson = idfContactedCasePerson;
                        clone.strPersonID = patient.strPersonID;
                        clone.strLastName = patient.strLastName;
                        clone.strFirstName = patient.strFirstName;
                        clone.datDateofBirth = patient.datDateofBirth;
                        clone.Gender = clone.GenderLookup.FirstOrDefault(i => i.idfsBaseReference == patient.idfsHumanGender);
                        clone.bPINMode = true;
                        var r = Customization.Instance.GetFromPersonIdentityService(clone);
                        if (r.Item1 == null)
                        {
                            var data = new CompareModel();
                            string errorMessage = Translator.GetMessageString(r.Item2);
                            data.Add("ErrorMessage", "ErrorMessage", "ErrorMessage", errorMessage, false, false, false);
                            return Json(data, JsonRequestBehavior.AllowGet);
                        }
                        clone = r.Item1;
                        ObjectStorage.Put(ModelUserContext.ClientID, 0, clone.idfHuman, null, clone);
                        return View(clone);
                    }
                }, ModelUserContext.ClientID, idfHuman, null);
            }
            else if (idfContactedCasePerson != 0)
            {
                return ObjectStorage.Using<ContactedCasePerson, ActionResult>(contactedCasePerson =>
                {
                    using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    {
                        var clone = eidss.model.Schema.Patient.Accessor.Instance(null).CreateNewT(manager, contactedCasePerson);
                        clone.idfCase = idfCase;
                        clone.idfContactedCasePerson = idfContactedCasePerson;
                        clone.strPersonID = contactedCasePerson.Person.strPersonID;
                        clone.strLastName = contactedCasePerson.Person.strLastName;
                        clone.strFirstName = contactedCasePerson.Person.strFirstName;
                        clone.datDateofBirth = contactedCasePerson.Person.datDateofBirth;
                        clone.Gender = clone.GenderLookup.FirstOrDefault(i => i.idfsBaseReference == contactedCasePerson.Person.idfsHumanGender);
                        clone.bPINMode = true;
                        var r = Customization.Instance.GetFromPersonIdentityService(clone);
                        if (r.Item1 == null)
                        {
                            var data = new CompareModel();
                            string errorMessage = Translator.GetMessageString(r.Item2);
                            data.Add("ErrorMessage", "ErrorMessage", "ErrorMessage", errorMessage, false, false, false);
                            return Json(data, JsonRequestBehavior.AllowGet);
                        }
                        clone = r.Item1;
                        ObjectStorage.Put(ModelUserContext.ClientID, contactedCasePerson.idfContactedCasePerson, clone.idfHuman, null, clone);
                        return View(clone);
                    }
                }, ModelUserContext.ClientID, idfContactedCasePerson, null);
            }
            else
            {
                return ObjectStorage.Using<HumanCase, ActionResult>(humanCase =>
                {
                    using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    {
                        var clone = eidss.model.Schema.Patient.Accessor.Instance(null).CreateNewT(manager, humanCase);
                        clone.idfCase = idfCase;
                        clone.idfContactedCasePerson = idfContactedCasePerson;
                        clone.strPersonID = humanCase.Patient.strPersonID;
                        clone.strLastName = humanCase.Patient.strLastName;
                        clone.strFirstName = humanCase.Patient.strFirstName;
                        clone.datDateofBirth = humanCase.Patient.datDateofBirth;
                        clone.Gender = clone.GenderLookup.FirstOrDefault(i => i.idfsBaseReference == humanCase.Patient.idfsHumanGender);
                        clone.bPINMode = true;
                        var r = Customization.Instance.GetFromPersonIdentityService(clone);
                        if (r.Item1 == null)
                        {
                            var data = new CompareModel();
                            string errorMessage = Translator.GetMessageString(r.Item2);
                            data.Add("ErrorMessage", "ErrorMessage", "ErrorMessage", errorMessage, false, false, false);
                            return Json(data, JsonRequestBehavior.AllowGet);
                        }
                        clone = r.Item1;
                        ObjectStorage.Put(ModelUserContext.ClientID, humanCase.idfCase, clone.idfHuman, null, clone);
                        return View(clone);
                    }
                }, ModelUserContext.ClientID, idfCase, null);
            }
        }

        [HttpPost]
        public ActionResult FindInPersonIdentityService(FormCollection form)
        {
            var idfCase = long.Parse(form["idfCase"]);
            var idfContactedCasePerson = long.Parse(form["idfContactedCasePerson"]);
            if (idfCase == 0 && idfContactedCasePerson == 0)
            {
                return PickerInternal<Patient.Accessor, Patient, Patient>(form, eidss.model.Schema.Patient.Accessor.Instance(null), null, null, null, null,
                    (o, p, c) =>
                    {
                        var data = new CompareModel();

                        using (var clone = p.Clone() as IObject)
                        {
                            p.PersonIDType = o.PersonIDType;
                            p.strPersonID = o.strPersonID;
                            p.strLastName = o.strLastName;
                            p.strFirstName = o.strFirstName;
                            p.datDateofBirth = o.datDateofBirth;
                            p.Gender = o.Gender;
                            data = p.Compare(clone);
                        }

                        return data;

                    }, bThrowIfNotFound: false);
            }
            else if (idfContactedCasePerson != 0)
            {
                return PickerInternal<Patient.Accessor, Patient, ContactedCasePerson>(form, eidss.model.Schema.Patient.Accessor.Instance(null), null, null, null, null,
                    (o, p, c) =>
                    {
                        var data = new CompareModel();

                        if (!o.idfRootHuman.HasValue)
                        {
                            data = HumanCaseController.SetRootPatient(p, o.idfHuman, o);
                        }
                        else
                        {
                            using (var clone = p.Clone() as IObject)
                            {
                                p.Person.PersonIDType = o.PersonIDType;
                                p.Person.strPersonID = o.strPersonID;
                                p.Person.strLastName = o.strLastName;
                                p.Person.strFirstName = o.strFirstName;
                                p.Person.datDateofBirth = o.datDateofBirth;
                                p.Person.Gender = o.Gender;
                                data = p.Compare(clone);
                            }
                        }

                        return data;
                    });
            }
            else
            {
                return PickerInternal<Patient.Accessor, Patient, HumanCase>(form, eidss.model.Schema.Patient.Accessor.Instance(null), null, null, null, null,
                    (o, p, c) =>
                    {
                        var data = new CompareModel();

                        if (!o.idfRootHuman.HasValue)
                        {
                            data = HumanCaseController.SetRootPatient(p, o.idfHuman, o);
                        }
                        else
                        {
                            using (var clone = p.Clone() as IObject)
                            {
                                p.Patient.PersonIDType = o.PersonIDType;
                                p.Patient.strPersonID = o.strPersonID;
                                p.Patient.strLastName = o.strLastName;
                                p.Patient.strFirstName = o.strFirstName;
                                p.Patient.datDateofBirth = o.datDateofBirth;
                                p.Patient.Gender = o.Gender;
                                data = p.Compare(clone);
                            }
                        }

                        return data;
                    });
            }
        }


        private string GetPatientNameById(Int64 id)
        {
            var patients = new List<PatientListItem>();
            var accessor = PatientListItem.Accessor.Instance(null);
            var filter = new FilterParams();
            filter.Add("idfHumanActual", "=", id);
            using (var dbmanager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                patients = accessor.SelectListT(dbmanager, filter);
            }

            if (patients.Count == 1)
            {
                return patients[0].strLastName;
            }

            return null;
        }

        private ValidationEventArgs validation = null;
        private int m_ignoreErr;
        void ValidationDetails(object sender, ValidationEventArgs args)
        {
            if (m_ignoreErr == 1)
            {
                args.Continue = true;
            }
            else
            {
                validation = args;
                ViewBag.ErrorMessage = Translator.GetErrorMessage(args);
            }
        }

    }
}
