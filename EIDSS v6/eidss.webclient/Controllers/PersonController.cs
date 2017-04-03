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

        public ActionResult IndexAjax([DataSourceRequest]DataSourceRequest request, FormCollection form)
        {
            return IndexInternalAjax<PatientListItem.Accessor, PatientListItem, PatientListItem.PatientListItemGridModelList>
                (form, PatientListItem.Accessor.Instance(null), AutoGridRoots.PatientList, request);
        }

        public ActionResult Details(long? id)
        {
            return DetailsInternal<Patient.Accessor, Patient>(id, eidss.model.Schema.Patient.Accessor.Instance(null), null, null, null, null, null);
        }

        [HttpPost]
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
            ModelStorage.Put(Session.SessionID, root, patient.idfHuman, null, patient);
            ViewBag.Root = root;
            ViewBag.IsAgeVisible = isAgeVisible;
            ViewBag.IsCoordinatesFieldsVisible = isCoordinatesFieldsVisible;
            ViewBag.IsLastNameSearchVisible = isLastNameSearchVisible;
            return PartialView(patient);
        }

        public ActionResult PatientInTwoColumns(long root, Patient patient, bool isAgeVisible = true, bool isCoordinatesFieldsVisible = false)
        {
            ModelStorage.Put(Session.SessionID, root, patient.idfHuman, null, patient);
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
            var rootObject = (IObject)ModelStorage.Get(Session.SessionID, objectId, null);

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
            ViewBag.IsClianButtonReadOnly = isControlReadOnly || patientId == 0;

            ViewBag.IsViewButtonReadOnly = patientId == 0;
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

        [HttpGet]
        public ActionResult SetSelectedPersonWithIgnore(string objectId, string idfsPatientPropertyName, string strPatientPropertyName, string selectedItemId, int ignoreErr)
        {
            long key = long.Parse(objectId);
            var rootObject = (IObject)ModelStorage.Get(Session.SessionID, key, null);
            var data = new CompareModel();
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                IObject cloneObject = rootObject.CloneWithSetup(manager);


                m_ignoreErr = ignoreErr;
                ViewBag.ErrorMessage = null;
                rootObject.Validation += ValidationDetails;
                rootObject.SetValue(idfsPatientPropertyName, selectedItemId);
                rootObject.Validation -= ValidationDetails;

                if (ViewBag.ErrorMessage != null)
                {
                    data.Add("ErrorMessage", "/Person/SetSelectedPersonWithIgnore?objectId=" + objectId + "&idfsPatientPropertyName=" + idfsPatientPropertyName + "&strPatientPropertyName=" + strPatientPropertyName + "&selectedItemId=" + selectedItemId + "&ignoreErr=1",
                        validation.ShouldAsk ? "AskUrlMessage" : "ErrorMessage",
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
            return new JsonResult { Data = data ?? new CompareModel(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
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
