using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
using eidss.model.Reports;
using eidss.model.Reports.Common;
using eidss.model.Schema;
using bv.common.Configuration;

namespace eidss.mobileclient.Controllers
{
    [Authorize]
    public class VetCaseController : Controller
    {
        private ValidationEventArgs m_validation = null;
        private string m_FarmTreeSessionKey = "FarmTree";

        public ActionResult VetModule()
        {
            VetCase.Accessor vetCaseAccessor = VetCase.Accessor.Instance(null);
            ViewBag.IsCreateButtonVisible = vetCaseAccessor.CanInsert;
            ViewBag.IsSearchButtonVisible = vetCaseAccessor.CanSelect;
            return View();
        }

        public ActionResult ExtendedSearch()
        {
            var accessor = SmallVetCaseListItem.Accessor.Instance(null);
            IObject initObject;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                initObject = accessor.CreateNew(manager, null);
            }
            ViewBag.InitObject = initObject;
            ViewBag.Filter = SearchPanelHelper.GetDefaultFilter(accessor.SearchPanelMeta, initObject);
            return View(accessor);
        }

        [HttpGet]
        public ActionResult VetInvestigationReport(long id)
        {
            byte[] report;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                VetCase.Accessor acc = VetCase.Accessor.Instance(null);
                VetCase vetCase = acc.SelectByKey(manager, id);
                long diagnosisId = -1;
                if (vetCase.idfsFinalDiagnosis.HasValue || vetCase.idfsTentativeDiagnosis.HasValue)
                {
                    diagnosisId = vetCase.idfsFinalDiagnosis.HasValue
                                      ? vetCase.idfsFinalDiagnosis.Value
                                      : vetCase.idfsTentativeDiagnosis.Value;
                }
                using (var wrapper = new ReportClientWrapper())
                {
                    var model = new VetIdModel(ModelUserContext.CurrentLanguage,
                        vetCase.idfCase,
                        diagnosisId, BaseSettings.PrintMapInVetReports,
                        ModelUserContext.Instance.IsArchiveMode);
                    report = vetCase._HACode == (int) HACode.Livestock
                                 ? wrapper.Client.ExportVetLivestockInvestigation( model)
                                 : wrapper.Client.ExportVetAvianInvestigation( model);
                }
            }
            return File(report, "application/pdf", "VetInvestigationReport.pdf");
        }

        [SessionExpireFilter]
        public ActionResult ExtendedSearchResult()
        {
            FilterParams filter = SearchPanelHelper.SearchPanelParseValues(Request.QueryString);
            filter.Add("idfPerson", "=", false);
            Session["Filter"] = filter;
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
            var accessor = SmallVetCaseListItem.Accessor.Instance(null);
            IObject initObject;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                initObject = accessor.CreateNew(manager, null);
            }
            ViewBag.InitObject = initObject;
            var filterParams = (FilterParams)Session["Filter"];
            List<SmallVetCaseListItem> list = GetVetCaseListItem(filterParams);
            ViewBag.ItemsCount = list == null ? 0 : list.Count;
            VetCase.Accessor vetCaseAccessor = VetCase.Accessor.Instance(null);
            ViewBag.IsEditButtonVisible = vetCaseAccessor.CanUpdate;
            ViewBag.isExtendedSearch = isExtendedSearch;
            List<SmallVetCaseListItem> resultList = list == null ? null : list.Take(100).ToList();
            List<SmallVetCaseListItem> result = AddressStringHelper.RearrangeAddressDisplayString(initObject, resultList).ToList();
            return View(result);
        }

        private List<SmallVetCaseListItem> GetVetCaseListItem(FilterParams filterParams)
        {
            var list = new List<SmallVetCaseListItem>();
            ViewBag.ErrorMessage = string.Empty;
            try
            {
                var accessor = SmallVetCaseListItem.Accessor.Instance(null);
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
            form.AllKeys.ToList().ForEach(k => form[k] = EidssWebHelper.UnescapeHtml(form[k]));
            string errorMessage;
            bool isDatesValid = DateTimeHelper.TryParseCustomDates(form, out errorMessage);
            var data = new CompareModel();
            if (!isDatesValid)
            {
                data.Add("ErrorMessage", "ErrorMessage", "ErrorMessage", errorMessage, false, false, false);
                return new JsonResult { Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            bool isNumericValid = NumericHelper.TryParseInteger(form, out errorMessage);
            if (!isNumericValid)
            {
                data.Add("ErrorMessage", "ErrorMessage", "ErrorMessage", errorMessage, false, false, false);
                return new JsonResult { Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

            long key = long.Parse(Session["IdfCase"].ToString());
            var vetCase = (VetCase)ModelStorage.Get(Session.SessionID, key, null);

            #region Обработка FF
            //TODO:
            #endregion
            
            m_validation = null;
            vetCase.Validation += vc_ValidationDetails;
            vetCase.ParseFormCollection(form);
            if (m_validation != null)
            {
                vetCase.Validation -= vc_ValidationDetails;
                errorMessage = Translator.GetErrorMessage(m_validation);
                data.Add("ErrorMessage", "ErrorMessage", "ErrorMessage", errorMessage, false, false, false);
                return new JsonResult { Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                VetCase.Accessor acc = VetCase.Accessor.Instance(null);
                acc.Validate(manager, vetCase, true, true, true);
                if (m_validation == null)
                {
                    acc.Post(manager, vetCase);
                }
            }
            vetCase.Validation -= vc_ValidationDetails;
            if (m_validation != null)
            {
                errorMessage = Translator.GetErrorMessage(m_validation);
                data.Add("ErrorMessage", "ErrorMessage", "ErrorMessage", errorMessage, false, false, false);
            }
            else
            {
                ModelStorage.Remove(Session.SessionID, vetCase.idfCase, m_FarmTreeSessionKey);
            }

            return new JsonResult { Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        private void vc_ValidationDetails(object sender, ValidationEventArgs args)
        {
            m_validation = args;
        }

        [HttpPost]
        [SessionExpireFilter]
        public ActionResult StoreCase(FormCollection form)
        {
            var key = Int64.Parse(Session["IdfCase"].ToString());
            form.AllKeys.ToList().ForEach(k => form[k] = EidssWebHelper.UnescapeHtml(form[k]));
            var vetCase = (VetCase)ModelStorage.Get(Session.SessionID, key, null);
            string errorMessage;
            bool isDatesValid = DateTimeHelper.TryParseCustomDates(form, out errorMessage);
            var data = new CompareModel();
            if (!isDatesValid)
            {
                data.Add("ErrorMessage", "ErrorMessage", "ErrorMessage", errorMessage, false, false, false);
                return new JsonResult {Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet};
            }

            bool isNumericValid = NumericHelper.TryParseInteger(form, out errorMessage);
            if (!isNumericValid)
            {
                data.Add("ErrorMessage", "ErrorMessage", "ErrorMessage", errorMessage, false, false, false);
                return new JsonResult { Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

            m_validation = null;
            vetCase.Validation += vc_ValidationDetails;
            vetCase.ParseFormCollection(form);
            if (m_validation != null)
            {
                vetCase.Validation -= vc_ValidationDetails;
                errorMessage = Translator.GetErrorMessage(m_validation);
                data.Add("ErrorMessage", "ErrorMessage", "ErrorMessage", errorMessage, false, false, false);
                return new JsonResult { Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            
            return new JsonResult {Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet};
        }

        [HttpGet]
        [SessionExpireFilter]
        public ActionResult General(long id, int? caseType = null, bool getFromSession = true)
        {
            VetCase.Accessor vetCaseAccessor = VetCase.Accessor.Instance(null);
            ViewBag.CanUpdate = vetCaseAccessor.CanUpdate;

            VetCase vetCase;

            if (getFromSession)
            {
                vetCase = (VetCase)ModelStorage.Get(Session.SessionID, id, null);
            }
            else
            {
                if (!caseType.HasValue)
                {
                    caseType = (int)HACode.Livestock;
                }
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                {
                    var acc = VetCase.Accessor.Instance(null);
                    vetCase = id.Equals(0) ? acc.CreateNewT(manager, null, caseType.Value) : acc.SelectByKey(manager, id);
                    if (id.Equals(0))
                    {
                        SetDefaultValues(vetCase);
                    }
                    ModelStorage.Put(Session.SessionID, vetCase.idfCase, vetCase.idfCase, null, vetCase);
                    ModelStorage.Put(Session.SessionID, vetCase.idfCase, vetCase.Farm.idfFarm, null, vetCase.Farm);
                }
            }
            caseType = vetCase._HACode;
            Session["CaseType"] = caseType;
            Session["IdfCase"] = vetCase.idfCase;
            AddTitleData(vetCase._HACode);

            return View(vetCase);
        }

        private static void SetDefaultValues(VetCase vetCase)
        {
            vetCase.idfInvestigatedByOffice = Convert.ToInt64(EidssUserContext.User.OrganizationID);
            vetCase.strInvestigatedByOffice = OrganizationLookup.OrganizationNational; 
            vetCase.PersonInvestigatedBy =
                vetCase.PersonInvestigatedByLookup.Where(
                    x => x.idfPerson == Convert.ToInt64(EidssUserContext.User.EmployeeID)).SingleOrDefault();
            vetCase.datInvestigationDate = vetCase.datEnteredDate;
        }

        [HttpGet]
        [SessionExpireFilter]
        public ActionResult FarmDetails(long id)
        {
            VetCase.Accessor vetCaseAccessor = VetCase.Accessor.Instance(null);
            ViewBag.CanUpdate = vetCaseAccessor.CanUpdate;
            var vetCase = (VetCase)ModelStorage.Get(Session.SessionID, id, null);
            AddTitleData(vetCase._HACode);
            Session["IdfCase"] = vetCase.idfCase;
            return View(vetCase);
        }
        
        [HttpGet]
        [SessionExpireFilter]
        public ActionResult HerdDetails(long id, bool getFromSession = true)
        {
            VetCase.Accessor vetCaseAccessor = VetCase.Accessor.Instance(null);
            ViewBag.CanUpdate = vetCaseAccessor.CanUpdate;
            List<VetFarmTree> species = PrepareSpeciesForCase(id);
            return View(species);
        }

        [HttpGet]
        [SessionExpireFilter]
        public ActionResult FlockDetails(long id)
        {
            VetCase.Accessor vetCaseAccessor = VetCase.Accessor.Instance(null);
            ViewBag.CanUpdate = vetCaseAccessor.CanUpdate;
            List<VetFarmTree> species = PrepareSpeciesForCase(id);
            return View(species);
        }

        private List<VetFarmTree> PrepareSpeciesForCase(long caseId)
        {
            var vetCase = (VetCase)ModelStorage.Get(Session.SessionID, caseId, null);

            EditableList<VetFarmTree> farmTree = ModelStorage.Get(Session.SessionID, caseId, m_FarmTreeSessionKey) as EditableList<VetFarmTree>;
            if(farmTree == null && vetCase.Farm.FarmTree!=null)
            {
                ModelStorage.Put(Session.SessionID, caseId, caseId, m_FarmTreeSessionKey, vetCase.Farm.FarmTree);
                farmTree = vetCase.Farm.FarmTree;
            }

            AddTitleData(vetCase._HACode);
            Session["IdfCase"] = vetCase.idfCase;
            List<VetFarmTree> species = GetSpeciesForFarmTree(farmTree);
            return species;
        }

        private List<VetFarmTree> GetSpeciesForFarmTree(EditableList<VetFarmTree> farmTree)
        {
            IEnumerable<VetFarmTree> species = farmTree.Where(x => x.idfsPartyType == (long)PartyTypeEnum.Species);
            foreach (var item in species)
            {
                VetFarmTree parent = farmTree.Where(x => x.idfParty == item.idfParentParty).FirstOrDefault();
                item.strHerdName = parent.strHerdName;
            }
            return species.OrderBy(x => x.strHerdName).ToList();
        }

        private void AddTitleData(int? haCode)
        {
            ViewBag.Title = Translator.GetMessageString((haCode == (int)HACode.Avian) ? "titleAvianCaseDetails" : "titleLvstkCaseDetails");
        }

        [HttpPost]
        [SessionExpireFilter]
        public ActionResult RemoveSpecies(long rootKey, long speciesId)
        {
            var vetCase = (VetCase)ModelStorage.Get(Session.SessionID, rootKey, null);
            VetFarmTree item = vetCase.Farm.FarmTree.Where(x => x.idfParty == speciesId).SingleOrDefault();
            if (item != null)
            {
                vetCase.Farm.FarmTree.Remove(item);
            }
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = null };
        }

        public ActionResult SearchModeMenu()
        {
            return View();
        }

        [SessionExpireFilter]
        public ActionResult ClinicalSigns(long rootKey, string name, long idfSpecies)
        {
            VetCase.Accessor vetCaseAccessor = VetCase.Accessor.Instance(null);
            ViewBag.CanUpdate = vetCaseAccessor.CanUpdate;

            ViewBag.RootKey = rootKey;
            ViewBag.Name = name;
            ViewBag.IdfSpecies = idfSpecies;

            var vetCase = (VetCase)ModelStorage.Get(Session.SessionID, rootKey, null);
            EditableList<VetFarmTree> farmTree = ModelStorage.Get(Session.SessionID, rootKey, m_FarmTreeSessionKey) as EditableList<VetFarmTree>;
            if (farmTree == null && vetCase.Farm.FarmTree != null)
            {
                ModelStorage.Put(Session.SessionID, rootKey, rootKey, m_FarmTreeSessionKey, vetCase.Farm.FarmTree);
            }
            
            ViewBag.ReturnMethodName = vetCase._HACode == (int)HACode.Livestock ? "HerdDetails" : "FlockDetails";

            VetFarmTree species = VetFarmTreeProcessor.GetSpecies(Session.SessionID, rootKey, name, idfSpecies, HACode.Livestock);
            ViewBag.SpeciesName = species.SpeciesType.name;

            if (vetCase._HACode == (int)HACode.Livestock)
            {
                ViewBag.IsHerdDetails = true;
                ViewBag.HerdName = species.strHerdName;
            }
            else
            {
                ViewBag.IsHerdDetails = false;
                ViewBag.FlockName = species.strHerdName;
            }

            Session["ReturnUrl"] = Url.Action("ClinicalSigns", "VetCase", new { rootKey = ViewBag.RootKey, name = ViewBag.Name, idfSpecies = ViewBag.IdfSpecies });

            return View();
        }
    }
}
