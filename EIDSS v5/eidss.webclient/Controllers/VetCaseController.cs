using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using eidss.model.Reports;
using eidss.model.Reports.Common;
using eidss.model.Schema;
using bv.model.BLToolkit;
using eidss.model.Core;
using eidss.webclient.Utils;
using bv.model.Model.Core;
using eidss.model.Resources;
using eidss.model.Enums;

namespace eidss.webclient.Controllers
{
    [AuthorizeEIDSS]
    public class VetCaseController : Controller
    {
        //
        // GET: /VetCase/
        // commented because  never used
        //private string m_ErrorMsg;

        public ActionResult Index()
        {
            var accessor = VetCaseListItem.Accessor.Instance(null);
            IObject initObject = null;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                initObject = accessor.CreateNew(manager, null);
            }
            ViewBag.InitObject = initObject;
            ViewBag.Filter = SearchPanelHelper.GetDefaultFilter(accessor.SearchPanelMeta, initObject);

            return View(accessor);           
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            FilterParams filter = SearchPanelHelper.SearchPanelParseValues(form, VetCaseListItem.Accessor.Instance(null).SearchPanelMeta);
            ViewBag.Filter = filter;
            ViewBag.InitObject = null;
            VetCaseListItem.VetCaseListItemGridModelList list = GetGridModelList(filter);
            ModelStorage.Put(Session.SessionID, AutoGridRoots.VetCaseList, AutoGridRoots.VetCaseList, "Grid", list);
            int totalRows = list.Count;
            return Json(new { data = list, total = totalRows }, JsonRequestBehavior.AllowGet);
        }    


        public ActionResult ViewDetails(long idfCase)
        {
            var vetcase = ModelStorage.Get(Session.SessionID, idfCase, null) as VetCase;
            return View("Details", vetcase);
        }

        public ActionResult Details(string type, long? id)
        {
            int hacode = (int)HACode.Livestock;
            if (!String.IsNullOrWhiteSpace(type))
            {
                if (type.Equals("avian", StringComparison.InvariantCultureIgnoreCase))
                {                    
                    hacode = (int)HACode.Avian;
                }               
            }
            if (id == 0)
                id = null;            
            using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var acc = VetCase.Accessor.Instance(null);

                var vc = id.HasValue ? acc.SelectByKey(manager, id.Value) : acc.CreateNewT(manager, null, hacode);
                ModelStorage.Put(Session.SessionID, vc.idfCase, vc.idfCase, null, vc);
                ModelStorage.Put(Session.SessionID, vc.idfCase, vc.Farm.idfFarm, null, vc.Farm);
                ViewBag.Title = Translator.GetMessageString((vc._HACode == (int)HACode.Avian) ? "pageTitleAvianDetails" : "pageTitleLvstkDetails");
                ViewBag.DiagnosisId = vc.idfsFinalDiagnosis ?? vc.idfsTentativeDiagnosis;
                return View("Details", vc);
            }
            
        }

        public ActionResult CreateLivestock(long? id)
        {
            return RedirectToAction("Details", new { type = "Lvstck" });
        }

        public ActionResult CreateAvian(long? id)
        {
            return RedirectToAction("Details", new { type = "Avian"});         
        }

        [HttpPost]
        public ActionResult Details(FormCollection form)
        {
            //TODO сделать нормальную проверку, чтобы приложение не падало, когда в коллекции нет ключа idfCase
            if (!form.AllKeys.Contains("idfCase")) return View();
            var key = long.Parse(form["idfCase"]);
            var vc = ModelStorage.Get(Session.SessionID, key, null) as VetCase;
            var clone = (IObject)vc.Clone();
            //get ff
            if (vc != null)
            {
                if (vc.FFPresenterControlMeasures != null)
                    vc.FFPresenterControlMeasures.ParseFormCollection(form);
                if (vc.Farm.FFPresenterEpi != null)
                    vc.Farm.FFPresenterEpi.ParseFormCollection(form);
            }


            ViewBag.Title = Translator.GetMessageString((vc._HACode == (int)HACode.Avian) ? "pageTitleAvianDetails" : "pageTitleLvstkDetails");

            ViewData["ErrorMessage"] = null;

            vc.ParseFormCollection(form);
            double? longt = vc.Farm.Location.dblLongitude;
            double? latt = vc.Farm.Location.dblLatitude;            

            vc.Farm.Location.CopyAddressValues(vc.Farm.Address);

            vc.Farm.Location.dblLatitude = latt;
            vc.Farm.Location.dblLongitude = longt;

            vc.Farm.Location.bCancelCoordinationValidation = true;

            vc.Validation += vc_ValidationDetails;            
            
            if (ViewData["ErrorMessage"] == null)
            {
                using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                {
                    var acc = VetCase.Accessor.Instance(null);
                    acc.Post(manager, vc);
                }
            }
            
            
            vc.Validation -= vc_ValidationDetails;
            
            ViewData["SaveAndExitClick"] = form["SaveAndExitClick"];
            ViewBag.DiagnosisId = vc.idfsFinalDiagnosis ?? vc.idfsTentativeDiagnosis;
            ViewBag.ShowCIVetCaseReportClick = form["ShowCIVetCaseReportClick"];
            ViewBag.ShowTestsReportClick = form["ShowTestsReportClick"];


            CompareModel comparision = new CompareModel();

            if (ViewData["ErrorMessage"] != null)
            {
                comparision.Add("ErrorMessage", "ErrorMessage", "ErrorMessage",
                                ViewData["ErrorMessage"].ToString(),
                                false, false, false);
            }
            else
            {
                comparision = vc.Compare(clone);
            }

            return Json(comparision, JsonRequestBehavior.AllowGet);
        }

        void vc_ValidationDetails(object sender, ValidationEventArgs args)
        {
            var message = EidssMessages.GetValidationErrorMessage(args);
            ViewData["ErrorMessage"] = message;
        }

        [HttpPost]
        public ActionResult StoreCase(FormCollection form)
        {
            var key = long.Parse(form["idfCase"]);
            var vetCase = (VetCase)ModelStorage.Get(Session.SessionID, key, null);
            vetCase.ParseFormCollection(form);
            return new JsonResult { Data = null, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public ActionResult GetEpiFlexForm(long root)
        {
            //TODO нужно ли это? Использовать vc.Farm.FFPresenter ?
            var vc = ModelStorage.Get(Session.SessionID, root, null) as VetCase;
            if (vc == null) return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data =  Translator.GetMessageString("msgVetCaseIsNotAvailable") };
            if (vc.Farm.idfsFormTemplate.HasValue && vc.Farm.FFPresenterEpi != null)
            {
                vc.Farm.FFPresenterEpi.ReadOnly = vc.ReadOnly || vc.IsClosed;
                return PartialView("EpiFFHolder", vc.Farm);
            }
            else
                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = Translator.GetMessageString("msgNowTemplate") };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public ActionResult GetCMFlexForm(long root)
        {
            //TODO нужно ли это? Использовать vc.FFPresenter ?
            var vc = ModelStorage.Get(Session.SessionID, root, null) as VetCase;
            if (vc == null) return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = Translator.GetMessageString("msgVetCaseIsNotAvailable") };
            if ((vc.idfsFormTemplate.HasValue && vc.FFPresenterControlMeasures != null))
            {
                vc.FFPresenterControlMeasures.ReadOnly = vc.ReadOnly || vc.IsClosed;
                return PartialView("ControlMeasures", vc);
            }
            else
                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = Translator.GetMessageString("msgNowTemplate") };
        }

        [HttpGet]
        public ActionResult VetCasePicker()
        {
            var accessor = VetCaseListItem.Accessor.Instance(null);
            IObject initObject = null;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                initObject = accessor.CreateNew(manager, null);
            }
            ViewBag.InitObject = initObject;
            FilterParams filter = SearchPanelHelper.GetDefaultFilter(accessor.SearchPanelMeta, initObject);
            ViewBag.Filter = filter;
            VetCaseListItem.VetCaseListItemGridModelList list = GetGridModelList(filter);
            ViewBag.GridItems = list;
            ModelStorage.Put(Session.SessionID, AutoGridRoots.VetCasePopUpSelectList, AutoGridRoots.VetCasePopUpSelectList, "Grid", list);

            return View(accessor);
        }

        [HttpPost]
        public ActionResult VetCasePicker(string formData)
        {
            FilterParams filter = SearchPanelHelper.SearchPanelParseValues(formData, VetCaseListItem.Accessor.Instance(null).SearchPanelMeta);
            ViewBag.Filter = filter;
            ViewBag.InitObject = null;
            VetCaseListItem.VetCaseListItemGridModelList list = GetGridModelList(filter);
            ModelStorage.Put(Session.SessionID, AutoGridRoots.VetCasePopUpSelectList, AutoGridRoots.VetCasePopUpSelectList, "Grid", list);
            int totalRows = list.Count;
            return Json(new { data = list, total = totalRows }, JsonRequestBehavior.AllowGet);
        }

        private static VetCaseListItem.VetCaseListItemGridModelList GetGridModelList(FilterParams filter)
        {
            List<VetCaseListItem> items = GetVetCaseList(filter);
            var list = new VetCaseListItem.VetCaseListItemGridModelList(AutoGridRoots.VetCasePopUpSelectList, items);
            return list;
        }

        private static List<VetCaseListItem> GetVetCaseList(FilterParams filter)
        {
            var accessor = VetCaseListItem.Accessor.Instance(null);
            using (var dbmanager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                List<VetCaseListItem> items = accessor.SelectListT(dbmanager, filter);
                var sample = accessor.CreateNewT(dbmanager, null);
                if (sample.IsHiddenPersonalData("AddressName"))
                {
                    AddressStringHelper.RearrangeAddressDisplayString(sample, items);
                }
                return items;
            }
        }

        [HttpGet]
        public ActionResult VetInvestigationReport(long caseId, long diagnosisId)
        {
            byte[] report;
            var vc = ModelStorage.Get(Session.SessionID, caseId, null) as VetCase;
            if (vc == null)
            {
                throw new BvModelException(@"Can't get Vet Case");
            }
            using (var wrapper = new ReportClientWrapper())
            {
                var model = new VetIdModel(ModelUserContext.CurrentLanguage, caseId, diagnosisId, ModelUserContext.Instance.IsArchiveMode)
                    {
                        OrganizationId = Convert.ToInt64(EidssUserContext.User.OrganizationID),
                        ForbiddenGroups = EidssUserContext.User.ForbiddenPersonalDataGroups
                    };
                report = vc._HACode == (int) HACode.Livestock
                             ? wrapper.Client.ExportVetLivestockInvestigation( model)
                             : wrapper.Client.ExportVetAvianInvestigation( model);
            }
            const string fileName = "VetInvestigationReport.pdf";
            Response.AppendHeader("content-disposition", "inline; filename=" + fileName);
            return File(report, "application/pdf", fileName);
        }
    }
}
