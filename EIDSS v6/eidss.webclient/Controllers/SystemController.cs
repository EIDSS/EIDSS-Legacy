using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using BLToolkit.EditableObjects;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Model.FlexibleForms.Helpers;
using eidss.model.Schema;
using eidss.web.common.Controllers;
using eidss.web.common.Utils;
using eidss.webclient.Utils;
using bv.common.Enums;

namespace eidss.webclient.Controllers
{
    [AuthorizeEIDSS]
    [OutputCache(Location = OutputCacheLocation.None, NoStore = true, Duration = 0, VaryByParam = "*")]
    public class SystemController : BvController
    {
        private ValidationEventArgs m_Validation;
        private int m_IgnoreErr;
        private const string EidssAssemblyName = ", eidss.model, Version=4.0.0.0, Culture=neutral, PublicKeyToken=null";


        [HttpPost]
        public ActionResult CheckChanges(long id, string formData)
        {
            var bChanged = true;
            var o = ModelStorage.Get(Session.SessionID, id, null) as IObject;
            if (o != null)
            {
                bChanged = o.HasChanges;
                if (!bChanged)
                {
                    var formCollection = HttpUtility.ParseQueryString(formData);
                    if (string.IsNullOrEmpty(formCollection.Get("NotToCloneInCheckChanges")))
                    {
                        using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                        {
                            var clone = o.CloneWithSetup(manager, true);
                            clone.DeepAcceptChanges();
                            clone.ParseFormCollection(formCollection, false);
                            bChanged = clone.HasChanges;
                        }
                    }
                    //ICloneable cloneable = o as ICloneable;
                    //IObject clone = cloneable.Clone() as IObject;
                    //clone.DeepAcceptChanges();
                    //clone.ParseFormCollection(formCollection, false, true);
                    //bChanged = clone.HasChanges;
                }
            }
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = bChanged };
        }

        public ActionResult DeleteObject(string accessor, long id)
        {
            var isSuccess = false;
            var typename = accessor.Replace(".BLToolkitExtension.Accessor", EidssAssemblyName);
            var typeacc = Type.GetType(typename);
            if (typeacc != null)
            {
                var meta = ObjectAccessor.MetaInterface(typeacc);
                if (meta != null)
                {
                    var action = meta.Actions.SingleOrDefault(c => c.ActionType == ActionTypes.Delete);
                    if (action != null)
                    {
                        var data = ModelStorage.Get(Session.SessionID, id, null) as IObject;
                        if (data != null && action.IsEnable(data, data.GetPermissions()))
                        {
                            using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                            {
                                isSuccess = action.RunAction(manager, data, new List<object> { id }).result;
                            }
                        }
                    }
                }
            }
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = isSuccess };
        }

        public ActionResult DeleteListObject(string accessor, long id)
        {
            var isSuccess = false;
            var typename = accessor.Replace(".BLToolkitExtension.Accessor", EidssAssemblyName);
            var typeacc = Type.GetType(typename);
            if (typeacc != null)
            {
                var meta = ObjectAccessor.MetaInterface(typeacc);
                if (meta != null)
                {
                    var action = meta.Actions.SingleOrDefault(c => c.ActionType == ActionTypes.Delete);
                    if (action != null)
                    {
                        using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                        {
                            isSuccess = action.RunAction(manager, null as IObject, new List<object> { id }).result;
                        }
                    }
                }
            }
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = isSuccess };
        }


        [HttpGet]
        public ActionResult DetailsObject(long id)
        {
            using (var dbmanager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                if (OutbreakListItem.Accessor.Instance(null).SelectListT(dbmanager, new FilterParams().Add("idfOutbreak", "=", id)).Count > 0)
                    return RedirectToAction("Details", "Outbreak", new { id = id });
                if (HumanCaseListItem.Accessor.Instance(null).SelectListT(dbmanager, new FilterParams().Add("idfCase", "=", id)).Count > 0)
                    return RedirectToAction("Details", "HumanCase", new { id = id });
                if (VetCaseListItem.Accessor.Instance(null).SelectListT(dbmanager, new FilterParams().Add("idfCase", "=", id)).Count > 0)
                    return RedirectToAction("Details", "VetCase", new { id = id });
                if (VsSessionListItem.Accessor.Instance(null).SelectListT(dbmanager, new FilterParams().Add("idfVectorSurveillanceSession", "=", id)).Count > 0)
                    return RedirectToAction("Details", "VsSession", new { id = id });
            }
            return null;
        }


        [HttpGet]
        public ActionResult GeoLocationPicker(long idfGeoLocation)
        {
            var originalGeoLocation = ModelStorage.Get(Session.SessionID, idfGeoLocation, null) as GeoLocation;
            if (originalGeoLocation.idfsGeoLocationType == null)
            {
                originalGeoLocation.idfsGeoLocationType = (long)GeoLocationTypeEnum.ExactPoint;
            }
            var root = (long)((IObject)ModelStorage.GetRoot(Session.SessionID, idfGeoLocation, null)).Key;
            var cloneGeoLocation = originalGeoLocation.GetForEdit();
            /*GeoLocation cloneGeoLocation = originalGeoLocation.CloneWithSetup();
            var hc = (HumanCase)ModelStorage.Get(Session.SessionID, root, null);
            if (hc.PointGeoLocation.IsNull)
            {
                cloneGeoLocation.Country = hc.Patient.CurrentResidenceAddress.Country;
                cloneGeoLocation.Region = hc.Patient.CurrentResidenceAddress.Region;
                cloneGeoLocation.Rayon = hc.Patient.CurrentResidenceAddress.Rayon;
            }*/
            cloneGeoLocation.idfGeoLocation = cloneGeoLocation.idfGeoLocation + 1;
            ModelStorage.Put(Session.SessionID, root, cloneGeoLocation.idfGeoLocation, null, cloneGeoLocation);
            ViewData["Root"] = root;
            return View(cloneGeoLocation);
        }

        [HttpGet]
        public ActionResult GeoLocationFullPicker(long idfGeoLocation)
        {
            GeoLocation originalGeoLocation = ModelStorage.Get(Session.SessionID, idfGeoLocation, null) as GeoLocation;
            if (originalGeoLocation.idfsGeoLocationType == null)
            {
                originalGeoLocation.idfsGeoLocationType = (long)GeoLocationTypeEnum.ExactPoint;
            }
            var root = (long)((IObject)ModelStorage.GetRoot(Session.SessionID, idfGeoLocation, null)).Key;
            GeoLocation cloneGeoLocation = originalGeoLocation.GetForEdit();
            cloneGeoLocation.idfGeoLocation = cloneGeoLocation.idfGeoLocation + 1;
            ModelStorage.Put(Session.SessionID, root, cloneGeoLocation.idfGeoLocation, null, cloneGeoLocation);
            ViewData["Root"] = root;
            return View(cloneGeoLocation);
        }


        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult SetGeoLocation(long idfGeoLocation, string formData)
        {
            var cloneGeoLocation = (GeoLocation)ModelStorage.Get(Session.SessionID, idfGeoLocation, null);
            long originalIdfGeoLocation = idfGeoLocation - 1;
            var originalGeoLocation = (GeoLocation)ModelStorage.Get(Session.SessionID, originalIdfGeoLocation, null);

            CompareModel data = new CompareModel();
            ValidateGeoLocation(originalGeoLocation, cloneGeoLocation, formData);

            if (m_Validation != null)
            {
                //if (m_validation.MessageId == "msgCoordinatesAutoCorrection")
                //{
                //    var tempGeoLocation = m_validation.Obj as GeoLocation;
                //    ModifyOriginalGeoLocation(originalGeoLocation, cloneGeoLocation, formData);
                //    data = originalGeoLocation.Compare(tempGeoLocation);
                //}
                string errorMessage = Translator.GetErrorMessage(m_Validation);
                data.Add("ErrorMessage", "ErrorMessage", "ErrorMessage", errorMessage, false, false, false);

            }
            else
            {
                GeoLocation tempGeoLocation = originalGeoLocation.CloneWithSetup();
                ModifyOriginalGeoLocation(originalGeoLocation, cloneGeoLocation, formData);
                data = originalGeoLocation.Compare(tempGeoLocation);
                ModelStorage.Remove(Session.SessionID, idfGeoLocation, null);
            }

            var json = new JsonResult { Data = data ?? new CompareModel(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return json;
        }

        private void ValidateGeoLocation(GeoLocation originalGeoLocation, GeoLocation cloneGeoLocation, string formData)
        {
            GeoLocation tempGeoLocation = originalGeoLocation.CloneWithSetup();

            ModifyOriginalGeoLocation(tempGeoLocation, cloneGeoLocation, formData);

            tempGeoLocation.Validation += obj_Validation;
            if (m_Validation == null)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                {
                    GeoLocation.Accessor acch = GeoLocation.Accessor.Instance(null);
                    acch.Validate(manager, tempGeoLocation, true, true, true);
                }
            }
            tempGeoLocation.Validation -= obj_Validation;
        }
        void Geolocation_Validation(object sender, ValidationEventArgs args)
        {
            if (args.MessageId == "msgCoordinatesAutoCorrection")
            {
                var geoLocation = args.Obj as GeoLocation;
                if (geoLocation != null)
                {
                    geoLocation.Region =
                        geoLocation.RegionLookup.Single(c => c.idfsRegion == (long?)args.Pars[0]);
                    geoLocation.Rayon = geoLocation.RayonLookup.Single(c => c.idfsRayon == (long?)args.Pars[1]);
                }
            }
            if (m_IgnoreErr == 1)
            {
                args.Continue = true;
            }
            else
            {
                m_Validation = args;
            }
        }

        private static double? parseDouble(NameValueCollection formCollection, string objectIdent, string name, double? origVal)
        {
            string val = formCollection[objectIdent + name];
            if (!string.IsNullOrEmpty(val))
            {
                double ret;
                if (double.TryParse(val, out ret))
                    return ret;
                if (double.TryParse(val, NumberStyles.AllowDecimalPoint, new NumberFormatInfo() { NumberDecimalSeparator = "." }, out ret))
                    return ret;
            }
            return origVal;
        }

        private static void ModifyOriginalGeoLocation(GeoLocation originalGeoLocation, GeoLocation cloneGeoLocation, string formData)
        {
            originalGeoLocation.GeoLocationType = originalGeoLocation.GeoLocationTypeLookup.SingleOrDefault(c => c.idfsBaseReference == cloneGeoLocation.idfsGeoLocationType);
            originalGeoLocation.Country = originalGeoLocation.CountryLookup.SingleOrDefault(c => c.idfsCountry == cloneGeoLocation.idfsCountry);
            originalGeoLocation.Region = originalGeoLocation.RegionLookup.SingleOrDefault(c => c.idfsRegion == cloneGeoLocation.idfsRegion);
            originalGeoLocation.Rayon = originalGeoLocation.RayonLookup.SingleOrDefault(c => c.idfsRayon == cloneGeoLocation.idfsRayon);
            originalGeoLocation.Settlement = originalGeoLocation.SettlementLookup.SingleOrDefault(c => c.idfsSettlement == cloneGeoLocation.idfsSettlement);
            originalGeoLocation.GroundType = originalGeoLocation.GroundTypeLookup.SingleOrDefault(c => c.idfsBaseReference == cloneGeoLocation.idfsGroundType);
            NameValueCollection formCollection = HttpUtility.ParseQueryString(formData);
            string objectIdent = cloneGeoLocation.ObjectIdent;
            originalGeoLocation.strDescription = formCollection[objectIdent + "strDescription"];
            originalGeoLocation.strForeignAddress = formCollection[objectIdent + "strForeignAddress"];
            var bSave = originalGeoLocation.bCancelCoordinationValidation;
            originalGeoLocation.bCancelCoordinationValidation = true;
            originalGeoLocation.dblLongitude = parseDouble(formCollection, objectIdent, "dblLongitude", originalGeoLocation.dblLongitude);
            originalGeoLocation.dblLatitude = parseDouble(formCollection, objectIdent, "dblLatitude", originalGeoLocation.dblLatitude);
            originalGeoLocation.bCancelCoordinationValidation = bSave;
            originalGeoLocation.dblAccuracy = parseDouble(formCollection, objectIdent, "dblAccuracy", originalGeoLocation.dblAccuracy);
            originalGeoLocation.dblAlignment = parseDouble(formCollection, objectIdent, "dblAlignment", originalGeoLocation.dblAlignment);
            originalGeoLocation.dblDistance = parseDouble(formCollection, objectIdent, "dblDistance", originalGeoLocation.dblDistance);
            originalGeoLocation.dblRelLatitude = parseDouble(formCollection, objectIdent, "dblRelLatitude", originalGeoLocation.dblRelLatitude);
            originalGeoLocation.dblRelLongitude = parseDouble(formCollection, objectIdent, "dblRelLongitude", originalGeoLocation.dblRelLongitude);
        }


        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult SetFreezer(long idfMaterial, long idfSubdivision)
        {
            var sample = ModelStorage.Get(Session.SessionID, idfMaterial, null) as LabSample;
            var temp = sample.CloneWithSetup();
            sample.Freezer = sample.FreezerLookup.Where(c => c.ID == idfSubdivision).SingleOrDefault();
            var data = sample.Compare(temp);
            var json = new JsonResult { Data = data ?? new CompareModel(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return json;
        }


        #region Patient

        [HttpGet]
        public ActionResult PatientPicker(string onPatientPickerSelect, string strLastName)
        {
            var accessor = PatientListItem.Accessor.Instance(null);
            PatientListItem initObject = null;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                initObject = accessor.CreateNewT(manager, null);
                initObject.strLastName = strLastName;
            }
            ViewBag.InitObject = initObject;
            var filter = SearchPanelHelper.GetDefaultFilter(accessor.SearchPanelMeta, initObject);
            ViewBag.Filter = filter;
            ViewBag.OnPatientPickerSelect = onPatientPickerSelect;
            return View(accessor);
        }

        /*[HttpPost]
        public ActionResult ReloadPatientPicker(string formData)
        {
            FilterParams filter = SearchPanelHelper.SearchPanelParseValues(formData, PatientListItem.Accessor.Instance(null).SearchPanelMeta);
            ViewBag.Filter = filter;
            ViewBag.InitObject = null;
            PatientListItem.PatientListItemGridModelList list = GetPatientsGridModelList(filter);
            ModelStorage.Put(Session.SessionID, 0, (long)AutoGridRoots.PatientSelectList, "Grid", list);
            int totalRows = list.Count;
            return Json(new { data = list, total = totalRows }, JsonRequestBehavior.AllowGet);
        }*/

        /*private static PatientListItem.PatientListItemGridModelList GetPatientsGridModelList(FilterParams filter)
        {
            List<PatientListItem> items = GetPatientList(filter);
            var list = new PatientListItem.PatientListItemGridModelList((long)AutoGridRoots.PatientSelectList, items);
            return list;
        }*/

        /*private static List<PatientListItem> GetPatientList(FilterParams filter)
        {
            var accessor = PatientListItem.Accessor.Instance(null);
            using (var dbmanager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                List<PatientListItem> items = accessor.SelectListT(dbmanager, filter);
                return items;
            }
        }
        */
        #endregion


        #region Organizations

        [HttpGet]
        public ActionResult OrganizationPicker(string objectId, string idfsOrganizationPropertyName, string strOrganizationPropertyName,
            string idfsEmployeePropertyName, string strEmployeePropertyName, bool showInInternalWindow, int HACode)
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
                initObject = accessor.CreateWithHACode(manager, null, HACode);
            }
            ViewBag.InitObject = initObject;
            FilterParams filter = SearchPanelHelper.GetDefaultFilter(accessor.SearchPanelMeta, initObject);
            ViewBag.Filter = filter;

            return View(accessor);
        }

        /*[HttpPost]
        public ActionResult OrganizationPicker(string formData)
        {
            FilterParams filter = SearchPanelHelper.SearchPanelParseValues(formData, OrganizationListItem.Accessor.Instance(null).SearchPanelMeta);
            ViewBag.Filter = filter;
            ViewBag.InitObject = null;
            OrganizationListItem.OrganizationListItemGridModelList list = GetOrganizationsGridModelList(filter);
            ModelStorage.Put(Session.SessionID, 0, (long)AutoGridRoots.OrganizationSelectList, "Grid", list);
            int totalRows = list.Count;
            return Json(new { data = list, total = totalRows }, JsonRequestBehavior.AllowGet);
        }

        private static OrganizationListItem.OrganizationListItemGridModelList GetOrganizationsGridModelList(FilterParams filter)
        {
            List<OrganizationListItem> items = GetOrganizationsList(filter);
            var list = new OrganizationListItem.OrganizationListItemGridModelList((long)AutoGridRoots.OrganizationSelectList, items);
            return list;
        }*/

        /*private static List<OrganizationListItem> GetOrganizationsList(FilterParams filter)
        {
            var accessor = OrganizationListItem.Accessor.Instance(null);
            using (var dbmanager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                List<OrganizationListItem> items = accessor.SelectListT(dbmanager, filter);
                return items;
            }
        }*/

        [HttpPost]
        public ActionResult SetSelectedOrganization(string objectId, string idfsOrganizationPropertyName, string strOrganizationPropertyName,
            string idfsEmployeePropertyName, string strEmployeePropertyName, string selectedItemId)
        {
            long key = long.Parse(objectId);
            var rootObject = (IObject)ModelStorage.Get(Session.SessionID, key, null);
            CompareModel data;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                IObject cloneObject = rootObject.CloneWithSetup(manager, true);
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
            filter.Add("Lookup_idfInstitution", "=", rootObject.GetValue(idfsOrganizationPropertyName));

            ViewBag.Filter = filter;
            ViewBag.IdfsOrganization = rootObject.GetValue(idfsOrganizationPropertyName);
            ViewBag.OrganizationAbbreaviation = rootObject.GetValue(strOrganizationPropertyName);

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
            ModelStorage.Put(Session.SessionID, 0, (long)AutoGridRoots.PersonSelectList, "Grid", list);
            int totalRows = list.Count;
            return Json(new { data = list, total = totalRows }, JsonRequestBehavior.AllowGet);
        }

        private static PersonListItem.PersonListItemGridModelList GetPersonsGridModelList(FilterParams filter)
        {
            List<PersonListItem> items = GetPersonList(filter);
            var list = new PersonListItem.PersonListItemGridModelList((long)AutoGridRoots.PersonSelectList, items);
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
                IObject cloneObject = rootObject.CloneWithSetup(manager, true);
                /*object previousEmployeeId = rootObject.GetValue(idfsEmployeePropertyName);
                if (previousEmployeeId != null)
                {
                    cloneObject.SetValue(idfsEmployeePropertyName, previousEmployeeId.ToString());
                }*/
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

        //[HttpGet]
        //public ActionResult PersonEditor(string rootId, string propertyForUpdate, string setSelectedItemUrl, long idfPerson)
        //{
        //    ViewBag.ObjectId = rootId;
        //    ViewBag.PropertyName = propertyForUpdate;
        //    ViewBag.SetSelectedItemPostUrl = setSelectedItemUrl;
        //    var person = ModelStorage.Get(Session.SessionID, idfPerson, null) as Person;
        //    return View(person);
        //}
        #endregion



        #region Full & Select Grid Actions

        //[GridAction]
        //public ActionResult _SelectGridBinding(long key, string name)
        //{
        //    var list = ModelStorage.Get(Session.SessionID, key, name) as IEnumerable<IGridModelItem>;
        //    return PartialView(new GridModel() { Data = list });
        //}

        //[GridAction]
        //public ActionResult _FullGridBinding(long key, string name, string type)
        //{
        //    var list = ModelStorage.Get(Session.SessionID, key, name) as IEnumerable<object>;
        //    return PartialView(new GridModel() { Data = list});
        //}

        //[GridAction]
        //public ActionResult _FullGridDelete(long key, string name, string type, long id)
        //{
        //    var list = ModelStorage.Get(Session.SessionID, key, name) as IEnumerable<object>;
        //    list.Cast<IObject>().Where(c => (long)c.Key == id).Single().MarkToDelete();

        //    string typename = type + EidssAssemblyName;
        //    Type typemodel = Type.GetType(typename);
        //    var model = typemodel.GetConstructor(new[] { typeof(long), typeof(IEnumerable), typeof(string) }).Invoke(new object[] { key, list, null }) as IEnumerable;
        //    return PartialView(new GridModel() { Data = model });
        //}
        #endregion
        #region Grid actions

        public ActionResult _GridBinding([DataSourceRequest]DataSourceRequest request, long key, string gridName, string type)
        {
            if (type.Contains(" "))
            {
                type = type.Replace(" ", "+");
            }
            var list = ModelStorage.Get(Session.SessionID, key, gridName) as IEnumerable; // EditableArrayList;
            string typename = type + EidssAssemblyName;
            Type typemodel = Type.GetType(typename);
            var model = typemodel.GetConstructor(new[] { typeof(long), typeof(IEnumerable), typeof(string) }).Invoke(new object[] { key, list, null }) as IEnumerable;
            if (model is IGridModelListSequence)
            {
                int sequence = 1;
                foreach (IGridModelItemSequence c in model)
                {
                    c.SequenceNumber = sequence++;
                }
            }

            DataSourceResult result = model.ToDataSourceResult(request);

            /*var result = new DataSourceResult { AggregateResults = null, Data = model, Errors = null, Total = list.Count };*/
            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult _GridUpdate([DataSourceRequest]DataSourceRequest request, long key, string gridName, string type, FormCollection form)
        {
            var list = ModelStorage.Get(Session.SessionID, key, gridName) as IEnumerable;
            foreach (var o in list)
            {
                var obj = o as IObject;
                if (obj.Key.ToString() == form["ItemKey"])
                {
                    var newform = new FormCollection();
                    form.AllKeys.ToList().ForEach(c => newform.Add(obj.ObjectIdent + (c.EndsWith(".Key") ? c.Substring(0, c.LastIndexOf(".Key")) : c), form[c]));
                    obj.ParseFormCollection(newform, true, false);
                    break;
                }
            }
            //return _GridBinding(request, key, gridName, type);
            //return Json(null);
            //var json = new JsonResult { Data = new CompareModel(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            //return json;
            return new EmptyResult();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditingCustom_Create([DataSourceRequest]DataSourceRequest request, string area, long key, string gridName, string type)
        {
            return Json(null);
        }


        public ActionResult _GridDelete(long key, string name, string type, long id)
        {
            var list = ModelStorage.Get(Session.SessionID, key, name) as IEnumerable; // EditableArrayList;
            var obj = list.Cast<IObject>().Single(c => (long)c.Key == id && !c.IsMarkedToDelete);
            obj.Validation += new ValidationEvent(obj_Validation);
            obj.MarkToDelete();
            obj.Validation -= new ValidationEvent(obj_Validation);

            CompareModel data = null;
            if (m_Validation != null)
            {
                data = new CompareModel();
                data.Add("ErrorMessage", "ErrorMessage", "ErrorMessage",
                    string.Format(Translator.GetBvOrEidssMessageString(m_Validation.MessageId), m_Validation.PropertyName),
                    false, false, false);
            }

            var json = new JsonResult { Data = data ?? new CompareModel(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return json;

            //bool iSuccess = obj.IsMarkedToDelete;
            //return new JsonResult { Data = iSuccess, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        #endregion
        /*
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
        */
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult TryDeleteFromGridAndCompare(long key, string name, long id)
        {
            var list = ModelStorage.Get(Session.SessionID, key, name) as EditableArrayList;
            var obj = list.Cast<IObject>().Single(c => (long)c.Key == id);
            using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                obj = obj.CloneWithSetup(manager, true);
            }
            obj.Validation += obj_Validation;
            obj.MarkToDelete();
            obj.Validation -= obj_Validation;

            CompareModel data;
            if (m_Validation != null)
            {
                data = new CompareModel();
                data.Add("ErrorMessage", "ErrorMessage", "ErrorMessage",
                    string.Format(Translator.GetMessageString(m_Validation.MessageId), m_Validation.PropertyName),
                    false, false, false);
            }
            else
            {
                var root = ModelStorage.Get(Session.SessionID, key, null) as IObject;
                IObject rootclone;
                using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    rootclone = root.CloneWithSetup(manager, true);
                }
                obj = list.Cast<IObject>().Single(c => (long)c.Key == id);
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
            var keyparts = key.Split('_');
            //обычные контролы имеют трёхчастные ключи
            //контролы FF имеют четырёхчастные ключи
            //над контролами FF не нужно проводить валидации, но к ним нужно применить бизнес-правила
            if (keyparts.Length == 3)
            {
                #region Обычный контрол

                var k = long.Parse(keyparts[1]);
                var obj = ModelStorage.Get(Session.SessionID, k, null, false) as IObject;
                var root = ModelStorage.GetRoot(Session.SessionID, k, null, false) as IObject;
                if (obj != null)
                {
                    var name = keyparts[2];
                    value = value == "null" ? null : value;
                    var oldvalue = obj.GetValue(name);
                    var stroldvalue = oldvalue == null
                                          ? null
                                          : (oldvalue is Boolean
                                                 ? ((bool) oldvalue ? "true" : "false")
                                                 : oldvalue.ToString());
                    if (stroldvalue != value)
                    {
                        var cloneable = (ICloneable) obj;
                        var clone = cloneable.Clone() as IObject;
                        m_IgnoreErr = ignoreErr;
                        obj.Validation += obj_Validation;
                        if (root != null)
                            root.Validation += obj_Validation;
                        obj.SetValue(name, value);
                        if (root != null)
                            root.Validation -= obj_Validation;
                        obj.Validation -= obj_Validation;
                        data = obj.Compare(clone);
                        if (m_Validation != null)
                        {
                            var val = obj.GetValue(name);
                            var type = obj.GetType(name);
                            var valstr = val == null ? String.Empty : val.ToString();
                            data.Add(name, key, type, valstr, obj.IsReadOnly(name), obj.IsInvisible(name),
                                     obj.IsRequired(name));
                            data.Add(key, value, m_Validation.ShouldAsk ? "AskMessage" : "ErrorMessage",
                                     Translator.GetErrorMessage(m_Validation),
                                     //string.Format(Translator.GetMessageString(m_validation.MessageId), m_validation.PropertyName),
                                     false, false, false);
                        }
                    }
                }

                #endregion
            }
            else if (keyparts.Length == 4)
            {
                #region FF контрол

                var isFFControl = (keyparts[0].Substring(0, 1) == "o")
                                  && (keyparts[1].Substring(0, 1) == "p")
                                  && (keyparts[2].Substring(0, 1) == "r")
                                  && (keyparts[3].Substring(0, 1) == "k");
                if (isFFControl)
                {
                    var idObservation = long.Parse(keyparts[0].Substring(1));
                    var idParameter = long.Parse(keyparts[1].Substring(1));
                    var idRow = long.Parse(keyparts[2].Substring(1));
                    var idKey = long.Parse(keyparts[3].Substring(1));

                    long valueLong;
                    if (Int64.TryParse(value, out valueLong) && (valueLong < 0)) value = null;

                    if ((idObservation > 0) && (idParameter > 0) && (idKey > 0))
                    {
                        var ff = ModelStorage.Get(Session.SessionID, idKey, idObservation.ToString(), false) as FFPresenterModel;
                        if (ff != null)
                        {
                            data = new CompareModel();
                            ff.GetChangesAfterRules(ref data, idObservation, idParameter, idRow, idKey, value, FFRuleCheckPointType.OnValueChanged);
                        }
                    }
                }

                #endregion
            }
            var json = new JsonResult { Data = data ?? new CompareModel(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return json;
        }

        void obj_Validation(object sender, ValidationEventArgs args)
        {
            if (m_IgnoreErr == 1)
            {
                args.Continue = true;
            }
            else
            {
                m_Validation = args;
            }
        }


        public ActionResult SelectGeneric(long id, string lookup, string keyname, string textname)
        {
            var o = ModelStorage.Get(Session.SessionID, id, null) as IObject;
            var bvList = o.GetList(lookup);
            return Json(bvList.items.Cast<IObject>().Select(c => new
                {
                    id = string.IsNullOrEmpty(keyname) ? c.Key : c.GetValue(keyname),
                    name = string.IsNullOrEmpty(textname) ? c.ToStringProp : c.GetValue(textname),
                }), JsonRequestBehavior.AllowGet);
            //return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new SelectList(bvList.items, bvList.dataValueField, bvList.dataTextField) };
        }

        public ActionResult SelectAnimalAge()
        {
            using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var ret = eidss.model.Schema.AnimalAgeLookup.Accessor.Instance(null).SelectLookupList(manager, null)
                    .Where(c => c.intRowStatus == 0).ToList();
                ret.Insert(0, eidss.model.Schema.AnimalAgeLookup.Accessor.Instance(null).CreateNewT(manager, null));
                return Json(ret.Select(c => new 
                    {
                        Key = c.idfsReference,
                        c.name,
                        c.idfsSpeciesType
                    }), JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult SelectAnimalGender()
        {
            using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var ret = eidss.model.Schema.BaseReference.Accessor.Instance(null).rftAnimalSex_SelectList(manager)
                    .Where(c => c.intRowStatus == 0 && ((c.intHACode.GetValueOrDefault() & (int)HACode.Livestock) != 0) || !c.intHACode.HasValue)
                    .ToList();
                ret.Insert(0, eidss.model.Schema.BaseReference.Accessor.Instance(null).CreateNewT(manager, null));
                return Json(ret.Select(c => new
                {
                    Key = c.idfsBaseReference,
                    c.name
                }), JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult SelectSampleType()
        {
            using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var ret = eidss.model.Schema.SampleTypeForDiagnosisLookup.Accessor.Instance(null).SelectList(manager)
                    .Where(c => c.intRowStatus == 0 && c.idfsDiagnosis == 0 && ((c.intHACode & (int)HACode.Livestock) != 0) && c.idfsReference != (long)SampleTypeEnum.Unknown)
                    .ToList();
                ret.Insert(0, eidss.model.Schema.SampleTypeForDiagnosisLookup.Accessor.Instance(null).CreateNewT(manager, null));
                return Json(ret.Select(c => new
                {
                    Key = c.idfsReference,
                    c.name
                }), JsonRequestBehavior.AllowGet);
            }
        }



        public ActionResult SelectDiagnosisOrDiagnosisGroup(long id, string lookup)
        {
            var o = ModelStorage.Get(Session.SessionID, id, null) as IObject;
            var bvList = o.GetList(lookup);
            return Json(bvList.items.Cast<DiagnosesAndGroupsLookup>().Select(c => new
                {
                    id = c.idfsDiagnosisOrDiagnosisGroup,
                    name = c.ToStringProp,
                    classname = c.blnGroup.HasValue && c.blnGroup.Value ? "clsGroup" : (c.idfsDiagnosisGroup != 0 ? "clsDiagInGroup" : "clsDiag")
                }), JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult PaperForms()
        {
            return View();
        }

    }

    [AuthorizeEIDSS]
    public class SystemCachedController : BvController
    {
        //[OutputCache(Location = OutputCacheLocation.Client, NoStore = false, Duration = 60)]
        public ActionResult SelectOrganizations()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                var list = new List<OrganizationLookup>();
                list.Add(OrganizationLookup.Accessor.Instance(null).CreateNewT(manager, null));
                list.AddRange(OrganizationLookup.Accessor.Instance(null).SelectLookupList(manager, null, null)
                    .Where(c => c.intRowStatus == 0).ToList());

                //Response.Headers[""] BaseSettings.CacheOfOrganizationLookupHours * 3600
                //Response.Headers["Cache-Control"] = "private, max-age=60, s-maxage=0";
                //Cache-Control: private, max-age=60, s-maxage=0
                //Expires: Thu, 09 Oct 2014 11:38:20 GMT

                return Json(list.Cast<IObject>().Select(c => new
                {
                    id = c.Key,
                    name = c.ToStringProp
                }), JsonRequestBehavior.AllowGet);
            }
        }

        /*[OutputCache(Location = OutputCacheLocation.Client, NoStore = false, Duration = 60)]
        public ActionResult SelectOrganizationsForSearch()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                var list = OrganizationLookup.Accessor.Instance(null).SelectLookupList(manager, null, null);
                return Json(list.Cast<IObject>().Select(c => new
                {
                    Value = c.Key,
                    Text = c.ToStringProp
                }), JsonRequestBehavior.AllowGet);
            }
        }*/
    }

}
