using System;
using System.Linq;
using System.Web.Mvc;
using bv.model.BLToolkit;
using eidss.model.Core;
using eidss.model.Schema;
using eidss.webclient.Utils;
using bv.model.Model.Core;

namespace eidss.webclient.Controllers
{
    [AuthorizeEIDSS]
    public class EmployeeController : Controller
    {
        private ValidationEventArgs m_Validation = null;

        public ActionResult InlineEmployeePicker(IObject obj, long objectId, string idfsEmployeePropertyName, string strEmployeePropertyName, 
            string idfsOrganizationPropertyName, string strOrganizationPropertyName, bool showInInternalWindow = false)
        {
            ViewBag.IdfsEmployeePropertyName = idfsEmployeePropertyName;
            ViewBag.StrEmployeePropertyName = strEmployeePropertyName;
            ViewBag.MainDivId = string.Format("divEmpSearchPicker_{0}_{1}", objectId, idfsEmployeePropertyName);
            ViewBag.BtnSearchPicker = string.Format("btnEmpSearchPicker_{0}_{1}", objectId, idfsEmployeePropertyName);
            ViewBag.BtnClianPicker = string.Format("btnEmpClian_{0}_{1}", objectId, idfsEmployeePropertyName);
            ViewBag.BtnAddNew = string.Format("btnEmpAddNew_{0}_{1}", objectId, idfsEmployeePropertyName);

            SetButtonsReadOnlyInViewBag(objectId, idfsEmployeePropertyName, idfsOrganizationPropertyName);

            string language = Cultures.GetSiteLanguage(Request);
            string onSelectItemClick = string.Format("ShowEmployeeSearchPicker(\"/{0}/System/EmployeePicker?objectId={1}&" +
                "idfsEmployeePropertyName={2}&strEmployeePropertyName={3}&idfsOrganizationPropertyName={4}&" +
                "strOrganizationPropertyName={5}&showInInternalWindow={6}\", \"{6}\")",
                language, objectId, idfsEmployeePropertyName, strEmployeePropertyName, idfsOrganizationPropertyName, 
                strOrganizationPropertyName, showInInternalWindow);

            ViewBag.OnSelectItemClick = onSelectItemClick;

            string onClianButtonClick = string.Format("onEmployeePickerValueChanged(\"{0}\", \"{1}\", \"{2}\", \"\", \"{3}\")",
                objectId, idfsEmployeePropertyName, strEmployeePropertyName, showInInternalWindow);

            ViewBag.OnClianButtonClick = onClianButtonClick;

            string onAddButtonClick = string.Format("ShowEmployeeCreator(\"/{0}/Employee/EmployeeCreator?objectId={1}&" +
                "idfsEmployeePropertyName={2}&strEmployeePropertyName={3}&idfsOrganizationPropertyName={4}&" +
                "showInInternalWindow={5}\", \"{5}\")",
                language, objectId, idfsEmployeePropertyName, strEmployeePropertyName, idfsOrganizationPropertyName, showInInternalWindow);

            ViewBag.OnAddButtonClick = onAddButtonClick;

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
        public ActionResult EmployeeCreator(string objectId, string idfsEmployeePropertyName, string strEmployeePropertyName,
            string idfsOrganizationPropertyName, bool showInInternalWindow = false)
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
                var accessor = Person.Accessor.Instance(null);
                var person = (Person)accessor.CreateNew(manager, rootObject);
                person.NewObject = true;
                person.Institution = person.InstitutionLookup.Where(p => p.idfInstitution == Convert.ToInt64(organizationId)).SingleOrDefault();
                ModelStorage.Put(Session.SessionID, person.idfPerson, person.idfPerson, null, person);
                ViewBag.NewEmployeeId = person.idfPerson;
                return View(person);
            }
        }

        [HttpPost]
        public ActionResult AddNewEmployee(FormCollection form)
        {
            long newEmployeeId = long.Parse(form["idfPerson"]);
            var person = (Person)ModelStorage.Get(Session.SessionID, newEmployeeId, null);
            m_Validation = null;
            person.Validation += obj_Validation;
            person.ParseFormCollection(form);
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                Person.Accessor acc = Person.Accessor.Instance(null);
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
                ModelStorage.Remove(Session.SessionID, newEmployeeId, null);
            }
            return new JsonResult { Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        void obj_Validation(object sender, ValidationEventArgs args)
        {
            m_Validation = args;
        }
    }
}
