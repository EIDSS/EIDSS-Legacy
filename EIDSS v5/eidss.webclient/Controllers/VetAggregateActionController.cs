using System;
using System.Collections.Generic;
using System.Web.Mvc;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.model.Reports;
using eidss.model.Reports.Common;
using eidss.model.Schema;
using eidss.webclient.Utils;

namespace eidss.webclient.Controllers
{
   [AuthorizeEIDSS]
    public class VetAggregateActionController : Controller
    {
        public ActionResult Index()
        {
            var accessor = VetAggregateActionListItem.Accessor.Instance(null);
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
            FilterParams filter = SearchPanelHelper.SearchPanelParseValues(form, VetAggregateActionListItem.Accessor.Instance(null).SearchPanelMeta);
            ViewBag.Filter = filter;
            ViewBag.InitObject = null;
            VetAggregateActionListItem.VetAggregateActionListItemGridModelList list = GetGridModelList(filter);
            ModelStorage.Put(Session.SessionID, AutoGridRoots.VetAggregateActionList, AutoGridRoots.VetAggregateActionList, "Grid", list);
            int totalRows = list.Count;
            return Json(new { data = list, total = totalRows }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(long? id) //TODO возможно стоит сделать просто long, когда будет обязательно вызываться с id (для нового id=0)
        {
            if (!id.HasValue)
            {
                id = 0; //новый случай //TODO вынести id нового в константу
            }

            VetAggregateAction aggregateCase = GetAggregateCaseById(id.Value);
            FillSessionValues(aggregateCase);
            return View(aggregateCase);
        }

        [HttpPost]
        public ActionResult Details(FormCollection form)
        {
            PostAggregateCase(form);
            var key = long.Parse(form["idfAggrCase"]);
            var hcr = ModelStorage.Get(Session.SessionID, key - 1, null) as VetAggregateAction;
            ViewData["SaveAndExitClick"] = form["SaveAndExitClick"];
            ViewBag.ShowVetAggregateActionReportClick = form["ShowVetAggregateActionReportClick"];
            return View(hcr);
        }

        [HttpPost]
        public ActionResult SaveAggregateCase(FormCollection form)
        {
            PostAggregateCase(form);
            return new JsonResult { Data = ViewData["ErrorMessage"], JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        private void PostAggregateCase(FormCollection form)
        {
            var key = long.Parse(form["idfAggrCase"]);
            var hc = ModelStorage.Get(Session.SessionID, key, null) as AggregateCaseHeader;

            ViewData["ErrorMessage"] = null;
            hc.Validation += hc_ValidationDetails;
            hc.ParseFormCollection(form);
            if (ViewData["ErrorMessage"] == null)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                {
                    AggregateCaseHeader.Accessor acc = AggregateCaseHeader.Accessor.Instance(null);
                    acc.Post(manager, hc);
                }
            }
            hc.Validation -= hc_ValidationDetails;
            ViewData["SaveAndExitClick"] = form["SaveAndExitClick"];
        }

        void hc_ValidationDetails(object sender, ValidationEventArgs args)
        {
            ViewData["ErrorMessage"] = Translator.GetErrorMessage(args);
        }


        public ActionResult CaseSummary()
        {
            ViewBag.HelpUrl =HelpPathConstants.m_VetAggregateActionSummaryPath;
            return View();
        }

        [HttpGet]
        public ActionResult VetAggregateActionEditor(long idfAggrCase)
        {
            VetAggregateAction aggregateCase = GetAggregateCaseById(idfAggrCase);
            FillSessionValues(aggregateCase);
            return View(aggregateCase);
        }

        private static VetAggregateAction GetAggregateCaseById(long idfAggrCase)
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var acc = VetAggregateAction.Accessor.Instance(null);
                var aggregateCase = idfAggrCase.Equals(0) ? acc.CreateNewT(manager, null) : acc.SelectByKey(manager, idfAggrCase); //TODO extender helper для проверки
                return aggregateCase;
            }
        }

        private void FillSessionValues(VetAggregateAction aggregateCase)
        {
            ModelStorage.Put(Session.SessionID, aggregateCase.idfAggrCase - 1, aggregateCase.idfAggrCase - 1, null, aggregateCase);
            ModelStorage.Put(Session.SessionID, aggregateCase.idfAggrCase, aggregateCase.idfAggrCase, null, aggregateCase.Header);
            if (aggregateCase.Header.FFPresenterDiagnostic.CurrentObservation.HasValue)
            {
                var idObservation = aggregateCase.Header.FFPresenterDiagnostic.CurrentObservation.Value;
                ModelStorage.Put(Session.SessionID, aggregateCase.idfAggrCase, aggregateCase.idfAggrCase, idObservation.ToString(), aggregateCase.Header.FFPresenterDiagnostic);
            }
            if (aggregateCase.Header.FFPresenterProphylactic.CurrentObservation.HasValue)
            {
                var idObservation = aggregateCase.Header.FFPresenterProphylactic.CurrentObservation.Value;
                ModelStorage.Put(Session.SessionID, aggregateCase.idfAggrCase, aggregateCase.idfAggrCase, idObservation.ToString(), aggregateCase.Header.FFPresenterProphylactic);
            }
            if (aggregateCase.Header.FFPresenterSanitary.CurrentObservation.HasValue)
            {
                var idObservation = aggregateCase.Header.FFPresenterSanitary.CurrentObservation.Value;
                ModelStorage.Put(Session.SessionID, aggregateCase.idfAggrCase, aggregateCase.idfAggrCase, idObservation.ToString(), aggregateCase.Header.FFPresenterSanitary);
            }
        }

        [HttpGet]
        public ActionResult VetAggregateActionPicker(string areaType, string periodType, string reportAreaType, string reportPeriodType)
        {
            ViewBag.ReportAreaType = reportAreaType;
            ViewBag.ReportPeriodType = reportPeriodType;

            var accessor = VetAggregateActionListItem.Accessor.Instance(null);
            IObject initObject = null;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                initObject = accessor.CreateNew(manager, null);
            }
            ViewBag.InitObject = initObject;
            FilterParams filter = SearchPanelHelper.GetDefaultFilter(accessor.SearchPanelMeta, initObject);
            ViewBag.Filter = filter;
            VetAggregateActionListItem.VetAggregateActionListItemGridModelList list = GetGridModelList(filter);
            ViewBag.GridItems = list;
            ModelStorage.Put(Session.SessionID, 0, AutoGridRoots.VetAggregateActionSelectList, "Grid", list);

            return View(accessor);         

        }

        [HttpPost]
        public ActionResult VetAggregateActionPicker(string formData)
        {
            FilterParams filter = SearchPanelHelper.SearchPanelParseValues(formData, VetAggregateActionListItem.Accessor.Instance(null).SearchPanelMeta);
            ViewBag.Filter = filter;
            ViewBag.InitObject = null;
            VetAggregateActionListItem.VetAggregateActionListItemGridModelList list = GetGridModelList(filter);
            ModelStorage.Put(Session.SessionID, 0, AutoGridRoots.VetAggregateActionSelectList, "Grid", list);
            int totalRows = list.Count;
            return Json(new { data = list, total = totalRows }, JsonRequestBehavior.AllowGet);
        }

        private static VetAggregateActionListItem.VetAggregateActionListItemGridModelList GetGridModelList(FilterParams filter)
        {
            List<VetAggregateActionListItem> items = GetVetAggregateActionList(filter);
            var list = new VetAggregateActionListItem.VetAggregateActionListItemGridModelList(AutoGridRoots.VetAggregateActionSelectList, items);
            return list;
        }

        private static List<VetAggregateActionListItem> GetVetAggregateActionList(FilterParams filter)
        {
            var accessor = VetAggregateActionListItem.Accessor.Instance(null);
            using (var dbmanager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                List<VetAggregateActionListItem> items = accessor.SelectListT(dbmanager, filter);
                return items;
            }
        }

        [HttpGet]
        public ActionResult VetAggregateActionReport(long id)
        {
            var hc = ModelStorage.Get(Session.SessionID, id, null) as AggregateCaseHeader;
            if (hc == null)
            {
                throw new BvModelException(@"Can't get Human Aggregate Case");
            }
            if (!hc.idfDiagnosticObservation.HasValue || !hc.idfProphylacticObservation.HasValue || !hc.idfSanitaryObservation.HasValue)
            {
                throw new BvModelException(@"Human Aggregate Case doesn't has valid observations");
            }
            byte[] report;
            using (var wrapper = new ReportClientWrapper())
            {
                var aggrParams = new AggregateActionsModel(ModelUserContext.CurrentLanguage, id,
                                                                hc.idfsDiagnosticObservationFormTemplate ?? 0,
                                                                hc.idfDiagnosticObservation.Value,
                                                                hc.idfsProphylacticObservationFormTemplate ?? 0,
                                                                hc.idfProphylacticObservation.Value,
                                                                hc.idfsSanitaryObservationFormTemplate ?? 0,
                                                                hc.idfSanitaryObservation.Value,
                                                                GetLabelsForVetAggregateActionTab(ModelUserContext.CurrentLanguage),
                                                                ModelUserContext.Instance.IsArchiveMode);
                report = wrapper.Client.ExportVetAggregateCaseActions( aggrParams);
            }
            const string fileName = "VetAggregateActionReport.pdf";
            Response.AppendHeader("content-disposition", "inline; filename=" + fileName);
            return File(report, "application/pdf", fileName);
        }

        private static Dictionary<string, string> GetLabelsForVetAggregateActionTab(string language)
        {
            var labels = new Dictionary<string, string>
                             {
                                 {"@diagnosticText" + language, Translator.GetMessageString("titleDiagnosticInvestigation")},
                                 {"@prophylacticText" + language, Translator.GetMessageString("tabTitleTreatmentProphylacticMeasures")},
                                 {"@sanitaryText" + language, Translator.GetMessageString("tabTitleVeterinarySanitaryMeasures")}
                             };
            return labels;
        }
    }
}
