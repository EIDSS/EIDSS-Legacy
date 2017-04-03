using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.mobileclient.Attributes;
using eidss.mobileclient.Utils;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Reports;
using eidss.model.Reports.Common;
using eidss.model.Schema;
using System.Web.Routing;

namespace eidss.mobileclient.Controllers
{
    [Authorize]
    public class HumanCaseController : Controller
    {
        private ValidationEventArgs m_Validation;

        public ActionResult HumanModule()
        {
            HumanCase.Accessor humanCaseAccessor = HumanCase.Accessor.Instance(null);
            ViewBag.IsCreateButtonVisible = humanCaseAccessor.CanInsert;
            ViewBag.IsSearchButtonVisible = humanCaseAccessor.CanSelect;
            return View();
        }

        public ActionResult ExtendedSearch()
        {
            var accessor = SmallHumanCaseListItem.Accessor.Instance(null);
            IObject initObject;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                initObject = accessor.CreateNew(manager, null);
            }
            ViewBag.InitObject = initObject;
            ViewBag.Filter = SearchPanelHelper.GetDefaultFilter(accessor.SearchPanelMeta);
            return View(accessor);
        }

        [SessionExpireFilter]
        public ActionResult ExtendedSearchResult()
        {
            FilterParams filter = SearchPanelHelper.SearchPanelParseValues(Request.QueryString);
            Session["Filter"] = filter;
            filter.Add("idfPerson", "=", false);
            return RedirectToAction("ListForm", new { isExtendedSearch = true });
        }

        [SessionExpireFilter]
        public ActionResult ThisWeekSearch()
        {
            var filter = new FilterParams();
            filter.Add("datEnteredDate", ">=", DateTime.Today.AddDays(-7));
            filter.Add("idfPerson", "=", false);
            Session["Filter"] = filter;
            return RedirectToAction("ListForm");
        }

        [SessionExpireFilter]
        public ActionResult TodaySearch()
        {
            var filter = new FilterParams();
            filter.Add("datEnteredDate", ">=", DateTime.Now.Date);
            filter.Add("idfPerson", "=", false);
            Session["Filter"] = filter;
            return RedirectToAction("ListForm");
        }

        [SessionExpireFilter]
        public ActionResult MyCasesSearch()
        {
            var filter = new FilterParams();
            filter.Add("idfPerson", "=", true);
            Session["Filter"] = filter;
            return RedirectToAction("ListForm");
        }

        [SessionExpireFilter]
        public ActionResult ListForm(bool isExtendedSearch = false)
        {
            var accessor = SmallHumanCaseListItem.Accessor.Instance(null);
            IObject initObject;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                initObject = accessor.CreateNew(manager, null);
            }
            ViewBag.InitObject = initObject;
            var filterParams = (FilterParams)Session["Filter"];
            List<SmallHumanCaseListItem> list = GetHumanCaseListItem(filterParams);
            ViewBag.ItemsCount = list == null ? 0 : list.Count;
            HumanCase.Accessor humanCaseAccessor = HumanCase.Accessor.Instance(null);
            ViewBag.IsEditButtonVisible = humanCaseAccessor.CanUpdate;
            ViewBag.isExtendedSearch = isExtendedSearch;
            List<SmallHumanCaseListItem> resultList = list == null ? null : list.Take(100).ToList();
            List<SmallHumanCaseListItem> result = AddressStringHelper.RearrangeAddressDisplayString(initObject, resultList).ToList();
            return View(result);
        }

        private List<SmallHumanCaseListItem> GetHumanCaseListItem(FilterParams filterParams)
        {
            var list = new List<SmallHumanCaseListItem>();
            ViewBag.ErrorMessage = string.Empty;
            try
            {
                var accessor = SmallHumanCaseListItem.Accessor.Instance(null);
                using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                {
                    list = accessor.SelectListT(manager, filterParams);
                }
            }
            catch
            {
                ViewBag.ErrorMessage = string.Format("{0}", Translator.GetMessageString("errDataBaseException"));
            }
            return list;
        }

        [HttpPost]
        [SessionExpireFilter]
        public ActionResult Details(FormCollection form)
        {
            string errorMessage;
            bool isDatesValid = DateTimeHelper.TryParseCustomDates(form, out errorMessage) && DateTimeHelper.TryParseMobileSafariDates(form, out errorMessage);
            var data = new CompareModel();
            if (!isDatesValid)
            {
                data.Add("ErrorMessage", "ErrorMessage", "ErrorMessage", errorMessage, false, false, false);
                return new JsonResult { Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

            long key = long.Parse(Session["IdfCase"].ToString());
            var humanCase = (HumanCase)ModelStorage.Get(Session.SessionID, key, null);
            
            var cloneHumanCase = (HumanCase)humanCase.Clone();

            m_Validation = null;
            humanCase.Validation += hc_ValidationDetails;
            humanCase.ParseFormCollection(form);
            if (m_Validation != null)
            {
                humanCase.Validation -= hc_ValidationDetails;
                errorMessage = Translator.GetErrorMessage(m_Validation);
                data.Add("ErrorMessage", "ErrorMessage", "ErrorMessage", errorMessage, false, false, false);
                return new JsonResult { Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                HumanCase.Accessor acc = HumanCase.Accessor.Instance(null);
                acc.Validate(manager, humanCase, true, true, true);
                if (m_Validation == null)
                {
                    acc.Post(manager, humanCase);
                }
            }
            humanCase.Validation -= hc_ValidationDetails;
            if (m_Validation != null)
            {
                errorMessage = Translator.GetErrorMessage(m_Validation);
                data.Add("ErrorMessage", "ErrorMessage", "ErrorMessage", errorMessage, false, false, false);
            }
            else
            {
                data = humanCase.Compare(cloneHumanCase);
            }
            return new JsonResult { Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        private void hc_ValidationDetails(object sender, ValidationEventArgs args)
        {
            m_Validation = args;
        }

        [HttpPost]
        [SessionExpireFilter]
        public ActionResult StoreCase(FormCollection form)
        {
            var key = Int64.Parse(Session["IdfCase"].ToString());
            var humanCase = (HumanCase) ModelStorage.Get(Session.SessionID, key, null);
            string errorMessage;
            bool isDatesValid = DateTimeHelper.TryParseCustomDates(form, out errorMessage) &&
                                DateTimeHelper.TryParseMobileSafariDates(form, out errorMessage);
            var data = new CompareModel();
            if (!isDatesValid)
            {
                data.Add("ErrorMessage", "ErrorMessage", "ErrorMessage", errorMessage, false, false, false);
                return new JsonResult {Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet};
            }

            m_Validation = null;
            humanCase.Validation += hc_ValidationDetails;
            humanCase.ParseFormCollection(form);
            if (m_Validation != null)
            {
                humanCase.Validation -= hc_ValidationDetails;
                errorMessage = Translator.GetErrorMessage(m_Validation);
                data.Add("ErrorMessage", "ErrorMessage", "ErrorMessage", errorMessage, false, false, false);
                return new JsonResult { Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            
            return new JsonResult {Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet};
        }

        [HttpGet]
        [SessionExpireFilter]
        public ActionResult Notification(long id, bool getFromSession = true)
        {
            HumanCase.Accessor humanCaseAccessor = HumanCase.Accessor.Instance(null);
            ViewBag.CanUpdate = humanCaseAccessor.CanUpdate;
            if (getFromSession)
            {
                var humanCase = (HumanCase) ModelStorage.Get(Session.SessionID, id, null);
                Session["IdfCase"] = humanCase.idfCase;
                return View(humanCase);
            }

            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var acc = HumanCase.Accessor.Instance(null);
                var humanCase = id.Equals(0) ? acc.CreateNewT(manager, null) : acc.SelectByKey(manager, id); //TODO extender helper для проверки
                if(id.Equals(0))
                {
                    humanCase.datNotificationDate = humanCase.datEnteredDate;
                    humanCase.RegistrationAddress.Country = null;
                }
                ModelStorage.Put(Session.SessionID, humanCase.idfCase, humanCase.idfCase, null, humanCase);
                ModelStorage.Put(Session.SessionID, humanCase.idfCase, humanCase.Patient.idfHuman, null, humanCase.Patient);
                Session["IdfCase"] = humanCase.idfCase;

                return View(humanCase);
            }
        }

        [HttpGet]
        [SessionExpireFilter]
        public ActionResult Investigation(long id)
        {
            HumanCase.Accessor humanCaseAccessor = HumanCase.Accessor.Instance(null);
            ViewBag.CanUpdate = humanCaseAccessor.CanUpdate;
            var humanCase = (HumanCase) ModelStorage.Get(Session.SessionID, id, null);
            Session["IdfCase"] = humanCase.idfCase;
            return View(humanCase);
        }

        [HttpGet]
        [SessionExpireFilter]
        public ActionResult ContactList(long id)
        {
            HumanCase.Accessor humanCaseAccessor = HumanCase.Accessor.Instance(null);
            ViewBag.CanUpdate = humanCaseAccessor.CanUpdate;
            var humanCase = (HumanCase)ModelStorage.Get(Session.SessionID, id, null);
            ViewBag.IsHiddenPersonalData = humanCase.IsHiddenPersonalData("ContactedPersonList");
            Session["IdfCase"] = humanCase.idfCase;
            return View(humanCase);
        }

        [HttpGet]
        [SessionExpireFilter]
        public ActionResult ClinicalSigns(long id)
        {
            HumanCase.Accessor humanCaseAccessor = HumanCase.Accessor.Instance(null);
            ViewBag.CanUpdate = humanCaseAccessor.CanUpdate;
            var humanCase = (HumanCase)ModelStorage.Get(Session.SessionID, id, null);
            Session["IdfCase"] = humanCase.idfCase;
            Session["ReturnUrl"] = Url.Action("ClinicalSigns", "HumanCase", new { id = humanCase.idfCase.ToString() });
            if (humanCase.FFPresenterCs.CurrentObservation.HasValue)
            {
                humanCase.FFPresenterCs.ReadOnly = humanCaseAccessor.IsReadOnlyForEdit;
                ModelStorage.Put(Session.SessionID, humanCase.idfCase, humanCase.idfCase,
                                 humanCase.FFPresenterCs.CurrentObservation.Value.ToString(), humanCase.FFPresenterCs);
            }
            return View(humanCase);
        }
        
        public ActionResult SearchModeMenu()
        {
            return View();
        }

        [HttpGet]
        public ActionResult HumanInvestigationReport(long id)
        {
            byte[] report = null;
            using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var acc = HumanCase.Accessor.Instance(null);
                var humanCase = acc.SelectByKey(manager, id);
                long diagnosisId = humanCase.idfsFinalDiagnosis.HasValue 
                    ? humanCase.idfsFinalDiagnosis.Value 
                    : humanCase.idfsTentativeDiagnosis.Value;
                if (humanCase.FFPresenterCs.CurrentObservation.HasValue && humanCase.FFPresenterEpi.CurrentObservation.HasValue)
                {
                    using (var wrapper = new ReportClientWrapper())
                    {
                        // todo: take papameters from singletone

                        var model = new HumIdModel(ModelUserContext.CurrentLanguage,
                                                   humanCase.idfCase,
                                                   humanCase.FFPresenterEpi.CurrentObservation.Value,
                                                   humanCase.FFPresenterCs.CurrentObservation.Value,
                                                   diagnosisId,
                                                   ModelUserContext.Instance.IsArchiveMode)
                            {
                                OrganizationId = Convert.ToInt64(EidssUserContext.User.OrganizationID),
                                ForbiddenGroups = EidssUserContext.User.ForbiddenPersonalDataGroups
                            };

                        report = wrapper.Client.ExportHumCaseInvestigation( model);
                    }
                }
            }
            return File(report, "application/pdf", "HumanInvestigationReport.pdf");
        }

        [SessionExpireFilter]
        public ActionResult LocationOfExposure(HumanCase humanCase)
        {
            long root = humanCase.idfCase;
            ViewBag.IdfCase = root;
            GeoLocation geoLocation = humanCase.PointGeoLocation;
            ModelStorage.Put(Session.SessionID, root, geoLocation.idfGeoLocation, null, geoLocation);
            return PartialView(geoLocation);
        }

        [SessionExpireFilter]
        public ActionResult LocationDetails(long rootKey)
        {
            HumanCase.Accessor humanCaseAccessor = HumanCase.Accessor.Instance(null);
            ViewBag.CanUpdate = humanCaseAccessor.CanUpdate;
            ViewBag.RootKey = rootKey;
            var humanCase = (HumanCase)ModelStorage.Get(Session.SessionID, rootKey, null);
            GeoLocation cloneGeoLocation = GetCloneOfOriginalGeoLocation(humanCase);
            cloneGeoLocation.idfGeoLocation = cloneGeoLocation.idfGeoLocation + 1;
            ModelStorage.Put(Session.SessionID, rootKey, cloneGeoLocation.idfGeoLocation, null, cloneGeoLocation);
            return PartialView(cloneGeoLocation);
        }

        [HttpPost]
        [SessionExpireFilter]
        public ActionResult SaveLocationOfExposure(FormCollection form)
        {
            long key = long.Parse(Session["IdfCase"].ToString());
            var humanCase = (HumanCase)ModelStorage.Get(Session.SessionID, key, null);

            Int64 originalIdfGeoLocation = humanCase.PointGeoLocation.idfGeoLocation;
            var originalGeoLocation = (GeoLocation)ModelStorage.Get(Session.SessionID, originalIdfGeoLocation, null);
            Int64 cloneIdfGeoLocation = originalIdfGeoLocation + 1;
            var cloneGeoLocation = (GeoLocation)ModelStorage.Get(Session.SessionID, cloneIdfGeoLocation, null);

            var data = new CompareModel();
            ValidateGeoLocation(originalGeoLocation, cloneGeoLocation, form);

            if (m_Validation != null)
            {
                string errorMessage = Translator.GetErrorMessage(m_Validation);
                data.Add("ErrorMessage", "ErrorMessage", "ErrorMessage", errorMessage, false, false, false);
            }
            else
            {
                GeoLocation tempGeoLocation = originalGeoLocation.CloneWithSetup();
                ModifyOriginalGeoLocation(originalGeoLocation, cloneGeoLocation, form);
                ModelStorage.Remove(Session.SessionID, cloneIdfGeoLocation, null);
                data = originalGeoLocation.Compare(tempGeoLocation);
            }
            
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = data };
        }

        private void ValidateGeoLocation(GeoLocation originalGeoLocation, GeoLocation cloneGeoLocation, FormCollection formData)
        {
            GeoLocation tempGeoLocation = originalGeoLocation.CloneWithSetup();

            ModifyOriginalGeoLocation(tempGeoLocation, cloneGeoLocation, formData);

            tempGeoLocation.Validation += hc_ValidationDetails;
            if (m_Validation == null)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                {
                    GeoLocation.Accessor acch = GeoLocation.Accessor.Instance(null);
                    acch.Validate(manager, tempGeoLocation, true, true, true);
                }
            }
            tempGeoLocation.Validation -= hc_ValidationDetails;
        }
        
        private static GeoLocation GetCloneOfOriginalGeoLocation(HumanCase humanCase)
        {
            GeoLocation originalGeoLocation = humanCase.PointGeoLocation;
            originalGeoLocation.idfsGeoLocationType = (long)GeoLocationTypeEnum.ExactPoint;
            GeoLocation cloneGeoLocation = originalGeoLocation.CloneWithSetup();
            if (humanCase.PointGeoLocation.IsNull)
            {
                cloneGeoLocation.Country = humanCase.Patient.CurrentResidenceAddress.Country;
                cloneGeoLocation.Region = humanCase.Patient.CurrentResidenceAddress.Region;
                cloneGeoLocation.Rayon = humanCase.Patient.CurrentResidenceAddress.Rayon;
            }
            return cloneGeoLocation;
        }
        
        private static void ModifyOriginalGeoLocation(GeoLocation originalGeoLocation, GeoLocation cloneGeoLocation, FormCollection formCollection)
        {
            originalGeoLocation.Country = originalGeoLocation.CountryLookup.Where(c => c.idfsCountry == cloneGeoLocation.idfsCountry).SingleOrDefault();
            originalGeoLocation.Region = originalGeoLocation.RegionLookup.Where(c => c.idfsRegion == cloneGeoLocation.idfsRegion).SingleOrDefault();
            originalGeoLocation.Rayon = originalGeoLocation.RayonLookup.Where(c => c.idfsRayon == cloneGeoLocation.idfsRayon).SingleOrDefault();
            originalGeoLocation.Settlement = originalGeoLocation.SettlementLookup.Where(c => c.idfsSettlement == cloneGeoLocation.idfsSettlement).SingleOrDefault();
            string objectIdent = cloneGeoLocation.ObjectIdent;
            originalGeoLocation.strDescription = formCollection[objectIdent + "strDescription"];
            string longitude = formCollection[objectIdent + "dblLongitude"];
            if (!string.IsNullOrEmpty(longitude))
            {
                originalGeoLocation.dblLongitude = double.Parse(longitude);
            }
            else
            {
                originalGeoLocation.dblLongitude = null;
            }
            string latitude = formCollection[objectIdent + "dblLatitude"];
            if (!string.IsNullOrEmpty(latitude))
            {
                originalGeoLocation.dblLatitude = double.Parse(latitude);
            }
            else
            {
                originalGeoLocation.dblLatitude = null;
            }
        }
    }
}
