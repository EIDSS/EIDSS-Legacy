using System;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using bv.model.BLToolkit;
using eidss.model.Core;
using eidss.model.Schema;
using eidss.web.common.Controllers;
using eidss.web.common.Utils;
using eidss.webclient.Utils;
using bv.model.Model.Core;

namespace eidss.webclient.Controllers
{
    [AuthorizeEIDSS]
    public class EmployeeController : BvController
    {
        private ValidationEventArgs m_Validation = null;

        public ActionResult InlineEmployeePicker(IObject obj, long objectId, string idfsEmployeePropertyName, string strEmployeePropertyName, 
            string idfsOrganizationPropertyName, string strOrganizationPropertyName, bool showInInternalWindow = false, bool showEditButton = false)
        {
            ViewBag.IdfsEmployeePropertyName = idfsEmployeePropertyName;
            ViewBag.StrEmployeePropertyName = strEmployeePropertyName;
            ViewBag.ShowEditButton = showEditButton;
            ViewBag.ShowInInternalWindow = showInInternalWindow;
            ViewBag.MainDivId = string.Format("divEmpSearchPicker_{0}_{1}", objectId, idfsEmployeePropertyName);
            ViewBag.BtnSearchPicker = string.Format("btnEmpSearchPicker_{0}_{1}", objectId, idfsEmployeePropertyName);
            ViewBag.BtnClianPicker = string.Format("btnEmpClian_{0}_{1}", objectId, idfsEmployeePropertyName);
            ViewBag.BtnAddNew = string.Format("btnEmpAddNew_{0}_{1}", objectId, idfsEmployeePropertyName);
            ViewBag.BtnEdit = string.Format("btnEmpEdit_{0}_{1}", objectId, idfsEmployeePropertyName);

            SetButtonsReadOnlyInViewBag(objectId, idfsEmployeePropertyName, idfsOrganizationPropertyName);
            
            string onSelectItemClick = string.Format("employee.showSearchPicker(\"{0}\", \"{1}\", \"{2}\", \"{3}\", \"{4}\", \"{5}\")",
                objectId, idfsEmployeePropertyName, strEmployeePropertyName, idfsOrganizationPropertyName, strOrganizationPropertyName, showInInternalWindow);

            ViewBag.OnSelectItemClick = onSelectItemClick;

            string onClianButtonClick = string.Format("employee.onPickerValueChanged(\"{0}\", \"{1}\", \"{2}\", \"\", \"{3}\")",
                objectId, idfsEmployeePropertyName, strEmployeePropertyName, showInInternalWindow);

            ViewBag.OnClianButtonClick = onClianButtonClick;

            string onAddButtonClick = string.Format("employee.showEditor(\"{0}\", \"{1}\", \"{2}\", \"{3}\", true, \"{4}\")",
                objectId, idfsEmployeePropertyName, strEmployeePropertyName, idfsOrganizationPropertyName, showInInternalWindow);

            ViewBag.OnAddButtonClick = onAddButtonClick;

            string onEditButtonClick = string.Format("employee.showEditor(\"{0}\", \"{1}\", \"{2}\", \"{3}\", false, \"{4}\")",
                objectId, idfsEmployeePropertyName, strEmployeePropertyName, idfsOrganizationPropertyName, showInInternalWindow);

            ViewBag.OnEditButtonClick = onEditButtonClick;

            return PartialView(obj);
        }

        private void SetButtonsReadOnlyInViewBag(long objectId, string idfsEmployeePropertyName, string idfsOrganizationPropertyName)
        {
            var rootObject = (IObject)ModelStorage.Get(Session.SessionID, objectId, null);

            IObjectPermissions permission = rootObject.GetPermissions();
            bool isRootReadOnly = permission == null ? false : permission.IsReadOnlyForEdit;

            bool isControlReadOnly = rootObject.IsReadOnly(idfsEmployeePropertyName) || isRootReadOnly;

            object organization = rootObject.GetValue(idfsOrganizationPropertyName);
            Int64 organizationId = 0;
            if (organization != null)
            {
                Int64.TryParse(organization.ToString(), out organizationId);
            }

            ViewBag.IsSearchButtonReadOnly = isControlReadOnly || organizationId == 0;

            ViewBag.IsAddButtonReadOnly = isControlReadOnly || organizationId == 0;

            object employee = rootObject.GetValue(idfsEmployeePropertyName);
            Int64 employeeId = 0;
            if (employee != null)
            {
                Int64.TryParse(employee.ToString(), out employeeId);
            }

            ViewBag.IsClianButtonReadOnly = isControlReadOnly || organizationId == 0 || employeeId == 0;
        }
        
        [HttpGet]
        public ActionResult EmployeeEditor(string objectId, string idfsEmployeePropertyName, string strEmployeePropertyName,
            string idfsOrganizationPropertyName, bool isNewEmployee, bool showInInternalWindow = false)
        {
            ViewBag.ObjectId = objectId;
            ViewBag.IdfsEmployeePropertyName = idfsEmployeePropertyName;
            ViewBag.StrEmployeePropertyName = strEmployeePropertyName;
            ViewBag.IdfsOrganizationPropertyName = idfsOrganizationPropertyName;
            ViewBag.ShowInInternalWindow = showInInternalWindow;

            long key = long.Parse(objectId);
            var rootObject = (IObject)ModelStorage.Get(Session.SessionID, key, null);
            object organizationId = rootObject.GetValue(idfsOrganizationPropertyName);

            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var accessor = PersonLite.Accessor.Instance(null);
                PersonLite person;
                if (isNewEmployee)
                {
                    person = (PersonLite)accessor.CreateNew(manager, rootObject);
                    person.Institution = person.InstitutionLookup.Where(p => p.idfInstitution == Convert.ToInt64(organizationId)).SingleOrDefault();
                    ViewBag.IsNewEmployee = true;
                }
                else
                {
                    object employeeId = rootObject.GetValue(idfsEmployeePropertyName);
                    person = accessor.SelectByKey(manager, Convert.ToInt64(employeeId));
                    ViewBag.IsNewEmployee = false;
                }
                ModelStorage.Put(Session.SessionID, person.idfPerson, person.idfPerson, null, person);
                ViewBag.EmployeeId = person.idfPerson;
                return View(person);
            }
        }

        [HttpPost]
        public ActionResult SaveEmployee(FormCollection form)
        {
            long employeeId = long.Parse(form["idfPerson"]);
            var person = (PersonLite)ModelStorage.Get(Session.SessionID, employeeId, null);
            m_Validation = null;
            person.Validation += obj_Validation;
            person.ParseFormCollection(form);
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                PersonLite.Accessor acc = PersonLite.Accessor.Instance(null);
                acc.Post(manager, person);
            }
            person.Validation -= obj_Validation;
            var data = new CompareModel();
            if (m_Validation != null)
            {
                string errorMessage = Translator.GetErrorMessage(m_Validation);
                data.Add("ErrorMessage", "ErrorMessage", "ErrorMessage", errorMessage, false, false, false);
            }
            else
            {
                ModelStorage.Remove(Session.SessionID, employeeId, null);
            }
            return new JsonResult { Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        void obj_Validation(object sender, ValidationEventArgs args)
        {
            m_Validation = args;
        }

        public ActionResult IndexAjax([DataSourceRequest]DataSourceRequest request, FormCollection form)
        {
            return IndexInternalAjax<PersonListItem.Accessor, PersonListItem, PersonListItem.PersonListItemGridModelList>
                (form, PersonListItem.Accessor.Instance(null), AutoGridRoots.PersonSelectList, request);
        }
    }
}
