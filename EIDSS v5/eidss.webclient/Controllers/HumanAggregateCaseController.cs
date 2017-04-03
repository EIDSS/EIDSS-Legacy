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
    public class HumanAggregateCaseController : Controller
    {
        public ActionResult Index()
        {
            var accessor = HumanAggregateCaseListItem.Accessor.Instance(null);
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
            FilterParams filter = SearchPanelHelper.SearchPanelParseValues(form, HumanAggregateCaseListItem.Accessor.Instance(null).SearchPanelMeta);
            ViewBag.Filter = filter;
            ViewBag.InitObject = null;
            HumanAggregateCaseListItem.HumanAggregateCaseListItemGridModelList list = GetGridModelList(filter);
            ModelStorage.Put(Session.SessionID, AutoGridRoots.HumanAggregateCaseList, AutoGridRoots.HumanAggregateCaseList, "Grid", list);
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

            HumanAggregateCase aggregateCase = GetAggregateCaseById(id.Value);
            FillSessionValues(aggregateCase);
            return View(aggregateCase);
        }

        [HttpPost]
        public ActionResult Details(FormCollection form)
        {
            PostAggregateCase(form);
            var key = long.Parse(form["idfAggrCase"]);
            var hcr = ModelStorage.Get(Session.SessionID, key - 1, null) as HumanAggregateCase;
            ViewData["SaveAndExitClick"] = form["SaveAndExitClick"];
            ViewBag.ShowHumanAggregateCaseReportClick = form["ShowHumanAggregateCaseReportClick"];
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
            ViewBag.HelpUrl = HelpPathConstants.m_HumanAggregateCaseSummaryPath;
            return View();
        }

        [HttpGet]
        public ActionResult HumanAggregateCaseEditor(long idfAggrCase)
        {
            HumanAggregateCase aggregateCase = GetAggregateCaseById(idfAggrCase);
            FillSessionValues(aggregateCase);
            return View(aggregateCase);
        }

        private static HumanAggregateCase GetAggregateCaseById(long idfAggrCase)
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var acc = HumanAggregateCase.Accessor.Instance(null);
                var aggregateCase = idfAggrCase.Equals(0) ? acc.CreateNewT(manager, null) : acc.SelectByKey(manager, idfAggrCase); //TODO extender helper для проверки
                return aggregateCase;
            }
        }

        private void FillSessionValues(HumanAggregateCase aggregateCase)
        {
            ModelStorage.Put(Session.SessionID, aggregateCase.idfAggrCase - 1, aggregateCase.idfAggrCase - 1, null, aggregateCase);
            ModelStorage.Put(Session.SessionID, aggregateCase.idfAggrCase, aggregateCase.idfAggrCase, null, aggregateCase.Header);
            if (aggregateCase.Header.FFPresenterCase.CurrentObservation.HasValue)
            {
                var idObservation = aggregateCase.Header.FFPresenterCase.CurrentObservation.Value;
                ModelStorage.Put(Session.SessionID, aggregateCase.idfAggrCase, aggregateCase.idfAggrCase, idObservation.ToString(), aggregateCase.Header.FFPresenterCase);
            }
        }

        [HttpGet]
        public ActionResult HumanAggregateCasePicker(string areaType, string periodType, string reportAreaType, string reportPeriodType)
        {
            ViewBag.ReportAreaType = reportAreaType;
            ViewBag.ReportPeriodType = reportPeriodType;

            var accessor = HumanAggregateCaseListItem.Accessor.Instance(null);
            IObject initObject = null;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                initObject = accessor.CreateNew(manager, null);
            }
            ViewBag.InitObject = initObject;
            FilterParams filter = SearchPanelHelper.GetDefaultFilter(accessor.SearchPanelMeta, initObject);
            ViewBag.Filter = filter;
            HumanAggregateCaseListItem.HumanAggregateCaseListItemGridModelList list = GetGridModelList(filter);
            ViewBag.GridItems = list;
            ModelStorage.Put(Session.SessionID, 0, AutoGridRoots.HumanAggregateCaseSelectList, "Grid", list);

            return View(accessor);         

        }

        [HttpPost]
        public ActionResult HumanAggregateCasePicker(string formData)
        {
            FilterParams filter = SearchPanelHelper.SearchPanelParseValues(formData, HumanAggregateCaseListItem.Accessor.Instance(null).SearchPanelMeta);
            ViewBag.Filter = filter;
            ViewBag.InitObject = null;
            HumanAggregateCaseListItem.HumanAggregateCaseListItemGridModelList list = GetGridModelList(filter);
            ModelStorage.Put(Session.SessionID, 0, AutoGridRoots.HumanAggregateCaseSelectList, "Grid", list);
            int totalRows = list.Count;
            return Json(new { data = list, total = totalRows }, JsonRequestBehavior.AllowGet);
        }

        private static HumanAggregateCaseListItem.HumanAggregateCaseListItemGridModelList GetGridModelList(FilterParams filter)
        {
            List<HumanAggregateCaseListItem> items = GetHumanAggregateCaseList(filter);
            var list = new HumanAggregateCaseListItem.HumanAggregateCaseListItemGridModelList(AutoGridRoots.HumanAggregateCaseSelectList, items);
            return list;
        }

        private static List<HumanAggregateCaseListItem> GetHumanAggregateCaseList(FilterParams filter)
        {
            var accessor = HumanAggregateCaseListItem.Accessor.Instance(null);
            using (var dbmanager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                List<HumanAggregateCaseListItem> items = accessor.SelectListT(dbmanager, filter);
                return items;
            }
        }

        [HttpGet]
        public ActionResult HumanAggregateCaseReport(long id)
        {
            var hc = ModelStorage.Get(Session.SessionID, id, null) as AggregateCaseHeader;
             if (hc == null)
            {
                throw new BvModelException(@"Can't get Human Aggregate Case");
            }
            if (!hc.idfCaseObservation.HasValue)
            {
                throw new BvModelException(@"Human Aggregate Case doesn't has observation");
            }
            byte[] report;
            using (var wrapper = new ReportClientWrapper())
            {
                var model = new AggregateModel(ModelUserContext.CurrentLanguage, id, hc.idfsCaseObservationFormTemplate ?? 0, hc.idfCaseObservation.Value, ModelUserContext.Instance.IsArchiveMode);
                report = wrapper.Client.ExportHumAggregateCase(model);
            }
            const string fileName = "HumanAggregateCaseReport.pdf";
            Response.AppendHeader("content-disposition", "inline; filename=" + fileName);
            return File(report, "application/pdf", fileName);
        }
    }
}
