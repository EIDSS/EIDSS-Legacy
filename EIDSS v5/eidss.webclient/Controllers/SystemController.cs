using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLToolkit.EditableObjects;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Reports;
using eidss.model.Reports.Common;
using eidss.model.Schema;
using Telerik.Web.Mvc;
using eidss.webclient.Utils;
using bv.common.Enums;

namespace eidss.webclient.Controllers
{
    [AuthorizeEIDSS]
    public class SystemController : Controller
    {
        private ValidationEventArgs m_validation = null;
        private int m_ignoreErr = 0;
        private const string EidssAssemblyName = ", eidss.model, Version=4.0.0.0, Culture=neutral, PublicKeyToken=null";

        //[HttpPost]
        public ActionResult Heartbeat(long id)
        {
            ModelStorage.Get(Session.SessionID, id, null);
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = null };
        }

        [HttpPost]
        public ActionResult CheckChanges(long id, string formData)
        {
            bool bChanged = true;
            IObject o = ModelStorage.Get(Session.SessionID, id, null) as IObject;
            if (o != null)
            {
                bChanged = o.HasChanges;
                if (!bChanged)
                {
                    NameValueCollection formCollection = HttpUtility.ParseQueryString(formData);
                    ICloneable cloneable = o as ICloneable;
                    IObject clone = cloneable.Clone() as IObject;
                    clone.DeepAcceptChanges();
                    clone.ParseFormCollection(formCollection, false, true);
                    bChanged = clone.HasChanges;
                }
            }
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = bChanged };
        }

        public ActionResult DeleteObject(string accessor, long id)
        {
            bool isSuccess = false;
            string typename = accessor.Replace(".BLToolkitExtension.Accessor", EidssAssemblyName);
            Type typeacc = Type.GetType(typename);
            if (typeacc != null)
            {
                IObjectMeta meta = ObjectAccessor.MetaInterface(typeacc);
                if (meta != null)
                {
                    var action = meta.Actions.Where(c => c.ActionType == ActionTypes.Delete).SingleOrDefault();
                    if (action != null)
                    {
                        var data = ModelStorage.Get(Session.SessionID, id, null) as IObject;
                        if (data != null && action.IsEnable(data, data.GetPermissions()))
                        {
                            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                            {
                                isSuccess = action.RunAction(manager, data, new List<object> {id}).result;
                            }
                        }
                    }
                }
            }
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = isSuccess };
        }

        public ActionResult DeleteListObject(string accessor, long id)
        {
            bool isSuccess = false;
            string typename = accessor.Replace(".BLToolkitExtension.Accessor", EidssAssemblyName);
            Type typeacc = Type.GetType(typename);
            if (typeacc != null)
            {
                IObjectMeta meta = ObjectAccessor.MetaInterface(typeacc);
                if (meta != null)
                {
                    var action = meta.Actions.Where(c => c.ActionType == ActionTypes.Delete).SingleOrDefault();
                    if (action != null)
                    {
                        using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                        {
                            isSuccess = action.RunAction(manager, null, new List<object> {id}).result;
                        }
                    }
                }
            }
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = isSuccess };
        }

        [HttpGet]
        public ActionResult AddressPicker(long idfGeoLocation)
        {
            Address originalAddress = ModelStorage.Get(Session.SessionID, idfGeoLocation, null) as Address;
            Address cloneAddress = originalAddress.CloneWithSetup();
            cloneAddress.idfGeoLocation = cloneAddress.idfGeoLocation + 1;
            var root = (long)((IObject)ModelStorage.GetRoot(Session.SessionID, idfGeoLocation, null)).Key;
            ModelStorage.Put(Session.SessionID, root, cloneAddress.idfGeoLocation, null, cloneAddress);
            return View(cloneAddress);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult SetAddress(long idfGeoLocation, string  strStreetName, string strPostCode, string strBuilding, string strApartment, string strHouse)
        {
            var cloneAddress = (Address)ModelStorage.Get(Session.SessionID, idfGeoLocation, null);
            long originalIdfGeoLocation = idfGeoLocation - 1;
            var originalAddress = (Address)ModelStorage.Get(Session.SessionID, originalIdfGeoLocation, null);

            Address tempAddress = originalAddress.CloneWithSetup();

            ModifyOriginalAddress(originalAddress, cloneAddress, strStreetName, strPostCode, strBuilding, strApartment,
                                  strHouse);

            ModelStorage.Remove(Session.SessionID, idfGeoLocation, null);

            CompareModel data = originalAddress.Compare(tempAddress);
            var json = new JsonResult { Data = data ?? new CompareModel(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return json;
        }

        private static void ModifyOriginalAddress(Address originalAddress, Address cloneAddress, string strStreetName, string strPostCode,
            string strBuilding, string strApartment, string strHouse)
        {
            originalAddress.Country = originalAddress.CountryLookup.Where(c => c.idfsCountry == cloneAddress.idfsCountry).SingleOrDefault();
            originalAddress.Region = originalAddress.RegionLookup.Where(c => c.idfsRegion == cloneAddress.idfsRegion).SingleOrDefault();
            originalAddress.Rayon = originalAddress.RayonLookup.Where(c => c.idfsRayon == cloneAddress.idfsRayon).SingleOrDefault();
            originalAddress.Settlement = originalAddress.SettlementLookup.Where(c => c.idfsSettlement == cloneAddress.idfsSettlement).SingleOrDefault();
            originalAddress.strStreetName = strStreetName;
            originalAddress.strPostCode = strPostCode;
            originalAddress.strBuilding = strBuilding;
            originalAddress.strApartment = strApartment;
            originalAddress.strHouse = strHouse;
        }

        [HttpGet]
        public ActionResult GeoLocationPicker(long idfGeoLocation)
        {
            GeoLocation originalGeoLocation = ModelStorage.Get(Session.SessionID, idfGeoLocation, null) as GeoLocation;
            originalGeoLocation.idfsGeoLocationType = (long)GeoLocationTypeEnum.ExactPoint;
            var root = (long)((IObject)ModelStorage.GetRoot(Session.SessionID, idfGeoLocation, null)).Key;
            GeoLocation cloneGeoLocation = originalGeoLocation.CloneWithSetup();
            var hc = (HumanCase)ModelStorage.Get(Session.SessionID, root, null);
            if (hc.PointGeoLocation.IsNull)
            {
                cloneGeoLocation.Country = hc.Patient.CurrentResidenceAddress.Country;
                cloneGeoLocation.Region = hc.Patient.CurrentResidenceAddress.Region;
                cloneGeoLocation.Rayon = hc.Patient.CurrentResidenceAddress.Rayon;
            }
            cloneGeoLocation.idfGeoLocation = cloneGeoLocation.idfGeoLocation + 1;
            ModelStorage.Put(Session.SessionID, root, cloneGeoLocation.idfGeoLocation, null, cloneGeoLocation);
            ViewData["Root"] = root;
            return View(cloneGeoLocation);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult SetGeoLocation(long idfGeoLocation, string formData, bool needCloseWindow)
        {
            var cloneGeoLocation = (GeoLocation)ModelStorage.Get(Session.SessionID, idfGeoLocation, null);
            long originalIdfGeoLocation = idfGeoLocation - 1;
            var originalGeoLocation = (GeoLocation)ModelStorage.Get(Session.SessionID, originalIdfGeoLocation, null);

            CompareModel data = new CompareModel();
            ValidateGeoLocation(originalGeoLocation, cloneGeoLocation, formData);
            if (m_validation != null)
            {
                string errorMessage = Translator.GetErrorMessage(m_validation);
                data.Add("ErrorMessage", "ErrorMessage", "ErrorMessage", errorMessage, false, false, false);
            }
            else
            {
                GeoLocation tempGeoLocation = originalGeoLocation.CloneWithSetup();
                ModifyOriginalGeoLocation(originalGeoLocation, cloneGeoLocation, formData);
                data = originalGeoLocation.Compare(tempGeoLocation);
                if (needCloseWindow)
                {
                    ModelStorage.Remove(Session.SessionID, idfGeoLocation, null);
                }
            }

            var json = new JsonResult { Data = data ?? new CompareModel(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return json;
        }

        private void ValidateGeoLocation(GeoLocation originalGeoLocation, GeoLocation cloneGeoLocation, string formData)
        {
            GeoLocation tempGeoLocation = originalGeoLocation.CloneWithSetup();

            ModifyOriginalGeoLocation(tempGeoLocation, cloneGeoLocation, formData);
            
            tempGeoLocation.Validation += obj_Validation;
            if (m_validation == null)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                {
                    GeoLocation.Accessor acch = GeoLocation.Accessor.Instance(null);
                    acch.Validate(manager, tempGeoLocation, true, true, true);
                }
            }
            tempGeoLocation.Validation -= obj_Validation;
        }

        private static void ModifyOriginalGeoLocation(GeoLocation originalGeoLocation, GeoLocation cloneGeoLocation, string formData)
        {
            originalGeoLocation.Country = originalGeoLocation.CountryLookup.Where(c => c.idfsCountry == cloneGeoLocation.idfsCountry).SingleOrDefault();
            originalGeoLocation.Region = originalGeoLocation.RegionLookup.Where(c => c.idfsRegion == cloneGeoLocation.idfsRegion).SingleOrDefault();
            originalGeoLocation.Rayon = originalGeoLocation.RayonLookup.Where(c => c.idfsRayon == cloneGeoLocation.idfsRayon).SingleOrDefault();
            originalGeoLocation.Settlement = originalGeoLocation.SettlementLookup.Where(c => c.idfsSettlement == cloneGeoLocation.idfsSettlement).SingleOrDefault();
            NameValueCollection formCollection = HttpUtility.ParseQueryString(formData);
            string objectIdent = cloneGeoLocation.ObjectIdent;
            originalGeoLocation.strDescription = formCollection[objectIdent + "strDescription"];
            string longitude = formCollection[objectIdent + "dblLongitude"];
            if (!string.IsNullOrEmpty(longitude))
            {
                originalGeoLocation.dblLongitude = double.Parse(longitude);
            }
            string latitude = formCollection[objectIdent + "dblLatitude"];
            if (!string.IsNullOrEmpty(latitude))
            {
                originalGeoLocation.dblLatitude = double.Parse(latitude);
            }
        }

        [HttpGet]
        public ActionResult FreezerPicker(long idfContainer)
        {
            var sample = ModelStorage.Get(Session.SessionID, idfContainer, null) as LabSample;
            return View(sample);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult SetFreezer(long idfContainer, long idfSubdivision)
        {
            var sample = ModelStorage.Get(Session.SessionID, idfContainer, null) as LabSample;
            var temp = sample.CloneWithSetup();
            sample.Freezer = sample.FreezerLookup.Where(c => c.ID == idfSubdivision).SingleOrDefault();
            var data = sample.Compare(temp);
            var json = new JsonResult { Data = data ?? new CompareModel(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return json;
        }

        [HttpGet]
        public ActionResult TestsReport(long id, bool isHuman)
        {
            byte[] report;
            using (var wrapper = new ReportClientWrapper())
            {
                var model = new LimTestModel(ModelUserContext.CurrentLanguage, id, isHuman, ModelUserContext.Instance.IsArchiveMode);
                report = wrapper.Client.ExportLimTest( model);
            }
            const string fileName = "TestsReport.pdf";
            Response.AppendHeader("content-disposition", "inline; filename=" + fileName);
            return File(report, "application/pdf", fileName);
        }

        #region Patient

        [HttpGet]
        public ActionResult PatientPicker(string onPatientPickerSelect)
        {
            var accessor = PatientListItem.Accessor.Instance(null);
            IObject initObject = null;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                initObject = accessor.CreateNew(manager, null);
            }
            ViewBag.InitObject = initObject;
            var filter = SearchPanelHelper.GetDefaultFilter(accessor.SearchPanelMeta, initObject);
            ViewBag.Filter = filter;
            PatientListItem.PatientListItemGridModelList list = GetPatientsGridModelList(filter);
            ViewBag.GridItems = list;
            ModelStorage.Put(Session.SessionID, 0, AutoGridRoots.PatientSelectList, "Grid", list);
            ViewBag.OnPatientPickerSelect = onPatientPickerSelect;
            return View(accessor);
        }

        [HttpPost]
        public ActionResult ReloadPatientPicker(string formData)
        {
            FilterParams filter = SearchPanelHelper.SearchPanelParseValues(formData, PatientListItem.Accessor.Instance(null).SearchPanelMeta);
            ViewBag.Filter = filter;
            ViewBag.InitObject = null;
            PatientListItem.PatientListItemGridModelList list = GetPatientsGridModelList(filter);
            ModelStorage.Put(Session.SessionID, 0, AutoGridRoots.PatientSelectList, "Grid", list);
            int totalRows = list.Count;
            return Json(new { data = list, total = totalRows }, JsonRequestBehavior.AllowGet);
        }

        private static PatientListItem.PatientListItemGridModelList GetPatientsGridModelList(FilterParams filter)
        {
            List<PatientListItem> items = GetPatientList(filter);
            var list = new PatientListItem.PatientListItemGridModelList(AutoGridRoots.PatientSelectList, items);
            return list;
        }

        private static List<PatientListItem> GetPatientList(FilterParams filter)
        {
            var accessor = PatientListItem.Accessor.Instance(null);
            using (var dbmanager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                List<PatientListItem> items = accessor.SelectListT(dbmanager, filter);
                return items;
            }
        }
        
        #endregion


        #region Organizations

        [HttpGet]
        public ActionResult OrganizationPicker(string objectId, string idfsOrganizationPropertyName, string strOrganizationPropertyName, 
            string idfsEmployeePropertyName, string strEmployeePropertyName, bool showInInternalWindow = false)
        {
            ViewBag.ObjectId = objectId;
            ViewBag.IdfsOrganizationPropertyName = idfsOrganizationPropertyName;
            ViewBag.StrOrganizationPropertyName = strOrganizationPropertyName;
            ViewBag.IdfsEmployeePropertyName = idfsEmployeePropertyName;
            ViewBag.StrEmployeePropertyName = strEmployeePropertyName;
            ViewBag.ShowInInternalWindow = showInInternalWindow;

            IObject initObject = null;
            var accessor = OrganizationListItem.Accessor.Instance(null);
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                initObject = accessor.CreateNew(manager, null);
            }
            ViewBag.InitObject = initObject;
            FilterParams filter = SearchPanelHelper.GetDefaultFilter(accessor.SearchPanelMeta, initObject);
            ViewBag.Filter = filter;
            OrganizationListItem.OrganizationListItemGridModelList list = GetOrganizationsGridModelList(filter);
            ViewBag.GridItems = list;
            ModelStorage.Put(Session.SessionID, 0, AutoGridRoots.OrganizationSelectList, "Grid", list);

            return View(accessor);                     
        }

        [HttpPost]
        public ActionResult OrganizationPicker(string formData)
        {
            FilterParams filter = SearchPanelHelper.SearchPanelParseValues(formData, OrganizationListItem.Accessor.Instance(null).SearchPanelMeta);
            ViewBag.Filter = filter;
            ViewBag.InitObject = null;
            OrganizationListItem.OrganizationListItemGridModelList list = GetOrganizationsGridModelList(filter);
            ModelStorage.Put(Session.SessionID, 0, AutoGridRoots.OrganizationSelectList, "Grid", list);
            int totalRows = list.Count;
            return Json(new { data = list, total = totalRows }, JsonRequestBehavior.AllowGet);
        }

        private static OrganizationListItem.OrganizationListItemGridModelList GetOrganizationsGridModelList(FilterParams filter)
        {
            List<OrganizationListItem> items = GetOrganizationsList(filter);
            var list = new OrganizationListItem.OrganizationListItemGridModelList(AutoGridRoots.OrganizationSelectList, items);
            return list;
        }

        private static List<OrganizationListItem> GetOrganizationsList(FilterParams filter)
        {
            var accessor = OrganizationListItem.Accessor.Instance(null);
            using (var dbmanager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                List<OrganizationListItem> items = accessor.SelectListT(dbmanager, filter);
                return items;
            }
        }
        
        [HttpPost]
        public ActionResult SetSelectedOrganization(string objectId, string idfsOrganizationPropertyName, string strOrganizationPropertyName,
            string idfsEmployeePropertyName, string strEmployeePropertyName, string selectedItemId)
        {
            long key = long.Parse(objectId);
            var rootObject = (IObject)ModelStorage.Get(Session.SessionID, key, null);
            CompareModel data;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                IObject cloneObject = rootObject.CloneWithSetup(manager);
                rootObject.SetValue(idfsOrganizationPropertyName, selectedItemId);
                string organizationName = string.Empty;
                if (!string.IsNullOrEmpty(selectedItemId))
                {
                    Int64 id = Int64.Parse(selectedItemId);
                    organizationName = GetOrganizationNameById(id);
                }
                rootObject.SetValue(strOrganizationPropertyName, organizationName);
                if (!string.IsNullOrEmpty(idfsEmployeePropertyName))
                {
                    rootObject.SetValue(idfsEmployeePropertyName, null);
                }
                if (!string.IsNullOrEmpty(strEmployeePropertyName))
                {
                    rootObject.SetValue(strEmployeePropertyName, null);
                }
                data = rootObject.Compare(cloneObject);
            }
            return new JsonResult { Data = data ?? new CompareModel(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        private string GetOrganizationNameById(Int64 id)
        {
            var organizations = new List<OrganizationListItem>();
            var accessor = OrganizationListItem.Accessor.Instance(null);
            var filter = new FilterParams();
            filter.Add("idfInstitution", "=", id);
            using (var dbmanager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                organizations = accessor.SelectListT(dbmanager, filter);
            }

            if (organizations.Count == 1)
            {
                return organizations[0].name;
            }

            return null;
        }
        #endregion

        #region Employee
        [HttpGet]
        public ActionResult EmployeePicker(string objectId, string idfsEmployeePropertyName, string strEmployeePropertyName,
            string idfsOrganizationPropertyName, string strOrganizationPropertyName, bool showInInternalWindow = false)
        {
            ViewBag.ObjectId = objectId;
            ViewBag.IdfsEmployeePropertyName = idfsEmployeePropertyName;
            ViewBag.StrEmployeePropertyName = strEmployeePropertyName;
            ViewBag.IdfsOrganizationPropertyName = idfsOrganizationPropertyName;
            ViewBag.ShowInInternalWindow = showInInternalWindow;

            long key = long.Parse(objectId);
            var rootObject = (IObject)ModelStorage.Get(Session.SessionID, key, null);

            var filter = new FilterParams();
            filter.Add("idfInstitution", "=", rootObject.GetValue(idfsOrganizationPropertyName));
            
            ViewBag.Filter = filter;

            ViewBag.OrganizationAbbreaviation = rootObject.GetValue(strOrganizationPropertyName);

            PersonListItem.PersonListItemGridModelList list = GetPersonsGridModelList(filter);
            ViewBag.GridItems = list;
            ModelStorage.Put(Session.SessionID, 0, AutoGridRoots.PersonSelectList, "Grid", list);

            return View(PersonListItem.Accessor.Instance(null));
        }

        [HttpPost]
        public ActionResult EmployeePicker(string objectId, string idfsOrganizationPropertyName, string formData)
        {
            FilterParams filter = SearchPanelHelper.SearchPanelParseValues(formData, PersonListItem.Accessor.Instance(null).SearchPanelMeta);
            ViewBag.Filter = filter;
            ViewBag.InitObject = null;
            long key = long.Parse(objectId);
            var rootObject = (IObject)ModelStorage.Get(Session.SessionID, key, null);
            filter.Add("idfInstitution", "=", rootObject.GetValue(idfsOrganizationPropertyName));
            PersonListItem.PersonListItemGridModelList list = GetPersonsGridModelList(filter);
            ModelStorage.Put(Session.SessionID, 0, AutoGridRoots.PersonSelectList, "Grid", list);
            int totalRows = list.Count;
            return Json(new { data = list, total = totalRows }, JsonRequestBehavior.AllowGet);
        }

        private static PersonListItem.PersonListItemGridModelList GetPersonsGridModelList(FilterParams filter)
        {
            List<PersonListItem> items = GetPersonList(filter);
            var list = new PersonListItem.PersonListItemGridModelList(AutoGridRoots.PersonSelectList, items);
            return list;
        }

        private static List<PersonListItem> GetPersonList(FilterParams filter)
        {
            var accessor = PersonListItem.Accessor.Instance(null);
            using (var dbmanager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                List<PersonListItem> items = accessor.SelectListT(dbmanager, filter);
                return items;
            }
        }
        
        [HttpPost]
        public ActionResult SetSelectedEmployee(string objectId, string idfsEmployeePropertyName, string strEmployeePropertyName, string selectedItemId)
        {
            long key = long.Parse(objectId);
            var rootObject = (IObject)ModelStorage.Get(Session.SessionID, key, null);
            CompareModel data;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                IObject cloneObject = rootObject.CloneWithSetup(manager);
                object previousEmployeeId = rootObject.GetValue(idfsEmployeePropertyName);
                if (previousEmployeeId != null)
                {
                    cloneObject.SetValue(idfsEmployeePropertyName, previousEmployeeId.ToString());
                }
                rootObject.SetValue(idfsEmployeePropertyName, selectedItemId);
                string employeeName = string.Empty;
                if (!string.IsNullOrEmpty(selectedItemId))
                {
                    Int64 id = Int64.Parse(selectedItemId);
                    employeeName = GetEmployeeNameById(id);
                }
                rootObject.SetValue(strEmployeePropertyName, employeeName);
                data = rootObject.Compare(cloneObject);
            }
            return new JsonResult { Data = data ?? new CompareModel(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        private string GetEmployeeNameById(Int64 id)
        {
            var employeeList = new List<PersonListItem>();
            var accessor = PersonListItem.Accessor.Instance(null);
            var filter = new FilterParams();
            filter.Add("idfEmployee", "=", id);
            using (var dbmanager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                employeeList = accessor.SelectListT(dbmanager, filter);
            }

            if (employeeList.Count == 1)
            {
                string strFamilyName = string.IsNullOrEmpty(employeeList[0].strFamilyName) ? "" : employeeList[0].strFamilyName;
                string strFirstName = string.IsNullOrEmpty(employeeList[0].strFirstName) ? "" : employeeList[0].strFirstName;
                string strSecondName = string.IsNullOrEmpty(employeeList[0].strSecondName) ? "" : employeeList[0].strSecondName;
                return string.Format("{0} {1} {2}", strFamilyName, strFirstName, strSecondName);
            }

            return null;
        }

        [HttpGet]
        public ActionResult PersonEditor(string rootId, string propertyForUpdate, string setSelectedItemUrl, long idfPerson)
        {
            ViewBag.ObjectId = rootId;
            ViewBag.PropertyName = propertyForUpdate;
            ViewBag.SetSelectedItemPostUrl = setSelectedItemUrl;
            var person = ModelStorage.Get(Session.SessionID, idfPerson, null) as Person;
            return View(person);
        }
        #endregion

        #region Full & Select Grid Actions

        [GridAction]
        public ActionResult _SelectGridBinding(long key, string name)
        {
            var list = ModelStorage.Get(Session.SessionID, key, name) as IEnumerable<IGridModelItem>;
            return PartialView(new GridModel() { Data = list });
        }

        [GridAction]
        public ActionResult _FullGridBinding(long key, string name, string type)
        {
            var list = ModelStorage.Get(Session.SessionID, key, name) as IEnumerable<object>;
            return PartialView(new GridModel() { Data = list});
        }

        [GridAction]
        public ActionResult _FullGridDelete(long key, string name, string type, long id)
        {
            var list = ModelStorage.Get(Session.SessionID, key, name) as IEnumerable<object>;
            list.Cast<IObject>().Where(c => (long)c.Key == id).Single().MarkToDelete();

            string typename = type + EidssAssemblyName;
            Type typemodel = Type.GetType(typename);
            var model = typemodel.GetConstructor(new[] { typeof(long), typeof(IEnumerable), typeof(string) }).Invoke(new object[] { key, list, null }) as IEnumerable;
            return PartialView(new GridModel() { Data = model });
        }
        #endregion
        #region Grid actions
        [GridAction]
        public ActionResult _GridBinding(long key, string name, string type)
        {
            if (type.Contains(" "))
                type = type.Replace(" ", "+");
            var list = ModelStorage.Get(Session.SessionID, key, name) as EditableArrayList;
            string typename = type + EidssAssemblyName;
            Type typemodel = Type.GetType(typename);
            var model = typemodel.GetConstructor(new [] { typeof(long), typeof(IEnumerable), typeof(string) }).Invoke(new object[] { key, list, null }) as IEnumerable;
            return PartialView(new GridModel() { Data = model });
        }

        /*
        [GridAction]
        public ActionResult _GridInsert(long key, string name, string type, FormCollection form)
        {
            var list = ModelStorage.Get(Session.SessionID, key, name) as EditableArrayList;
            var root = ModelStorage.GetRoot(Session.SessionID, key, name) as IObject;
            string objecttypename = type.Remove(type.LastIndexOf("+")) + EidssAssemblyName;
            Type typeobj = Type.GetType(objecttypename);
            IObjectCreator creator = ObjectAccessor.CreatorInterface(typeobj);
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                root.Validation += obj_Validation;
                IObject item = creator.CreateWithParams(manager, new List<object> { key });

                //TryUpdateModel(item); // this is not worked here
                foreach(var k in form.AllKeys)
                {
                    item.SetValue(k, form[k]);
                }
                item.MatchLookups();

                list.Add(item);
                root.Validation -= obj_Validation;
            }

            string errMes = null;
            if (m_validation != null)
            {
                errMes = m_validation.MessageId + ": " + m_validation.PropertyName;
            }

            string typename = type + EidssAssemblyName;
            Type typemodel = Type.GetType(typename);
            var model = typemodel.GetConstructor(new[] { typeof(long), typeof(IEnumerable), typeof(string) }).Invoke(new object[] { key, list, errMes }) as IEnumerable;
            return PartialView(new GridModel() { Data = model });
        }

        [GridAction]
        public ActionResult _GridUpdate(long key, string name, string type, long id, FormCollection form)
        {
            if (type.Contains(" "))
                type = type.Replace(" ", "+");
            var list = ModelStorage.Get(Session.SessionID, key, name) as EditableArrayList;
            var root = ModelStorage.GetRoot(Session.SessionID, key, name) as IObject;
            var item = list.Cast<IObject>().Where(c => (long)c.Key == id).Single();

            root.Validation += obj_Validation;
            //TryUpdateModel(item); // this is not worked here
            foreach (var k in form.AllKeys)
            {
                item.SetValue(k, form[k]);
            }
            item.MatchLookups();
            root.Validation -= obj_Validation;

            string errMes = null;
            if (m_validation != null)
            {
                errMes = m_validation.MessageId + ": " + m_validation.PropertyName;
            }

            string typename = type + EidssAssemblyName;
            Type typemodel = Type.GetType(typename);
            var model = typemodel.GetConstructor(new[] { typeof(long), typeof(IEnumerable), typeof(string) }).Invoke(new object[] { key, list, errMes }) as IEnumerable;
            return PartialView(new GridModel() { Data = model });
        }
        */

        [GridAction]
        public ActionResult _GridDelete(long key, string name, string type, long id)
        {
            if (type.Contains(" "))
                type = type.Replace(" ", "+");
            var list = ModelStorage.Get(Session.SessionID, key, name) as EditableArrayList;
            var obj = list.Cast<IObject>().Where(c => (long)c.Key == id).Single();
            obj.MarkToDelete();

            string typename = type + EidssAssemblyName;
            Type typemodel = Type.GetType(typename);
            var model = typemodel.GetConstructor(new[] { typeof(long), typeof(IEnumerable), typeof(string) }).Invoke(new object[] { key, list, null }) as IEnumerable;
            return PartialView(new GridModel() { Data = model });
        }

        #endregion

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult TryDeleteFromGrid(long key, string name, long id)
        {
            var list = ModelStorage.Get(Session.SessionID, key, name) as EditableArrayList;
            var obj = list.Cast<IObject>().Where(c => (long)c.Key == id).Single();
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                obj = obj.CloneWithSetup(manager);
            }
            obj.Validation += new ValidationEvent(obj_Validation);
            obj.MarkToDelete();
            obj.Validation -= new ValidationEvent(obj_Validation);

            CompareModel data = null;
            if (m_validation != null)
            {
                data = new CompareModel();
                data.Add("ErrorMessage", "ErrorMessage", "ErrorMessage",
                    string.Format(Translator.GetMessageString(m_validation.MessageId), m_validation.PropertyName),
                    false, false, false);
            }

            var json = new JsonResult { Data = data ?? new CompareModel(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return json;
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult TryDeleteFromGridAndCompare(long key, string name, long id)
        {
            var list = ModelStorage.Get(Session.SessionID, key, name) as EditableArrayList;
            var obj = list.Cast<IObject>().Where(c => (long)c.Key == id).Single();
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                obj = obj.CloneWithSetup(manager);
            }
            obj.Validation += new ValidationEvent(obj_Validation);
            obj.MarkToDelete();
            obj.Validation -= new ValidationEvent(obj_Validation);

            CompareModel data = null;
            if (m_validation != null)
            {
                data = new CompareModel();
                data.Add("ErrorMessage", "ErrorMessage", "ErrorMessage",
                    string.Format(Translator.GetMessageString(m_validation.MessageId), m_validation.PropertyName),
                    false, false, false);
            }
            else
            {
                IObject root = ModelStorage.Get(Session.SessionID, key, null) as IObject;
                IObject rootclone;
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    rootclone = root.CloneWithSetup(manager);
                }
                obj = list.Cast<IObject>().Where(c => (long)c.Key == id).Single();
                obj.MarkToDelete();
                data = root.Compare(rootclone);
            }

            var json = new JsonResult { Data = data ?? new CompareModel(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return json;
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult SetValue(string key, string value)
        {
            return SetValueWithIgnore(key, value, 0);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult SetValueWithIgnore(string key, string value, int ignoreErr)
        {
            CompareModel data = null;
            string[] keyparts = key.Split('_');
            if (keyparts.Length == 3)
            {
                IObject obj = ModelStorage.Get(Session.SessionID, long.Parse(keyparts[1]), null, false) as IObject;
                if (obj != null)
                {
                    string name = keyparts[2];
                    value = value == "null" ? null : value;
                    object oldvalue = obj.GetValue(name);
                    string stroldvalue = oldvalue == null ? null : (oldvalue is Boolean ? ((bool)oldvalue ? "true" : "false") : oldvalue.ToString());
                    if (stroldvalue != value)
                    {
                        ICloneable cloneable = obj as ICloneable;
                        IObject clone = cloneable.Clone() as IObject;
                        m_ignoreErr = ignoreErr;
                        obj.Validation += obj_Validation;
                        obj.SetValue(name, value);
                        obj.Validation -= obj_Validation;
                        data = obj.Compare(clone);
                        if (m_validation != null)
                        {
                            object val = obj.GetValue(name);
                            string type = obj.GetType(name);
                            string valstr = val == null ? "" : val.ToString();
                            data.Add(name, key, type, valstr, obj.IsReadOnly(name), obj.IsInvisible(name), obj.IsRequired(name));
                            data.Add(key, value, m_validation.ShouldAsk ? "AskMessage" : "ErrorMessage",
                                string.Format(Translator.GetMessageString(m_validation.MessageId), m_validation.PropertyName),
                                false, false, false);
                        }
                    }                    
                }
            }
            var json = new JsonResult { Data = data ?? new CompareModel(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return json;
        }

        void obj_Validation(object sender, ValidationEventArgs args)
        {
            if (m_ignoreErr == 1)
            {
                args.Continue = true;
            }
            else
            {
                m_validation = args;
            }
        }

        [HttpGet]
        public ActionResult PaperForms()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ShowGeneralCaseInvestigationForm()
        {
             byte[] report;
             using (var wrapper = new ReportClientWrapper())
             {
                 report = wrapper.Client.ExportHumCaseInvestigation(new HumIdModel(ModelUserContext.CurrentLanguage, -1, -1, -1, -1, ModelUserContext.Instance.IsArchiveMode));
                 
             }
             const string fileName = "HumanInvestigationReport.pdf";
             Response.AppendHeader("content-disposition", "inline; filename=" + fileName);
             return File(report, "application/pdf", fileName);
        }
    }
}
