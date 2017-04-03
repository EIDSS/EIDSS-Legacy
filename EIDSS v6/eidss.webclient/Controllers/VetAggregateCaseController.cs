using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.model.Reports;
using eidss.model.Reports.Common;
using eidss.model.Schema;
using eidss.web.common.Controllers;
using eidss.web.common.Utils;
using eidss.webclient.Utils;

namespace eidss.webclient.Controllers
{
   [AuthorizeEIDSS]
    public class VetAggregateCaseController : BvController
    {
        public ActionResult Index()
        {
            return IndexInternal<VetAggregateCaseListItem.Accessor, VetAggregateCaseListItem, VetAggregateCaseListItem.VetAggregateCaseListItemGridModelList>
                (VetAggregateCaseListItem.Accessor.Instance(null), AutoGridRoots.VetAggregateCaseList, false);
        }

        public ActionResult IndexAjax([DataSourceRequest]DataSourceRequest request, FormCollection form)
        {
            return IndexInternalAjax<VetAggregateCaseListItem.Accessor, VetAggregateCaseListItem, VetAggregateCaseListItem.VetAggregateCaseListItemGridModelList>
                (form, VetAggregateCaseListItem.Accessor.Instance(null), AutoGridRoots.VetAggregateCaseList, request);
        }

        [HttpGet]
        public ActionResult Details(long? id) //TODO возможно стоит сделать просто long, когда будет обязательно вызываться с id (для нового id=0)
        {
            if (!id.HasValue)
            {
                id = 0; //новый случай //TODO вынести id нового в константу
            }

            VetAggregateCase aggregateCase = GetAggregateCaseById(id.Value);
            FillSessionValues(aggregateCase);
            return View(aggregateCase);
        }

        [HttpPost]
        public ActionResult Details(FormCollection form)
        {
            return DetailsInternalAjax<AggregateCaseHeader.Accessor, AggregateCaseHeader>(form, AggregateCaseHeader.Accessor.Instance(null), null, null, null, null);
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
        }

        void hc_ValidationDetails(object sender, ValidationEventArgs args)
        {
            ViewData["ErrorMessage"] = Translator.GetErrorMessage(args);
        }

        public ActionResult CaseSummary()
        {
            ViewBag.HelpUrl = HelpPathConstants.m_VetAggregateCaseSummaryPath;
            return View();
        }

        [HttpGet]
        public ActionResult VetAggregateCaseEditor(long idfAggrCase)
        {
            VetAggregateCase aggregateCase = GetAggregateCaseById(idfAggrCase);
            FillSessionValues(aggregateCase);
            return View(aggregateCase);
        }

        private static VetAggregateCase GetAggregateCaseById(long idfAggrCase)
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var acc = VetAggregateCase.Accessor.Instance(null);
                var aggregateCase = idfAggrCase.Equals(0) ? acc.CreateNewT(manager, null) : acc.SelectByKey(manager, idfAggrCase); //TODO extender helper для проверки
                return aggregateCase;
            }
        }

        private void FillSessionValues(VetAggregateCase aggregateCase)
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
        public ActionResult VetAggregateCasePicker(string reportAreaType, string reportPeriodType)
        {
            ViewBag.ReportAreaType = reportAreaType;
            ViewBag.ReportPeriodType = reportPeriodType;

            return IndexInternal<VetAggregateCaseListItem.Accessor, VetAggregateCaseListItem, VetAggregateCaseListItem.VetAggregateCaseListItemGridModelList>
                (VetAggregateCaseListItem.Accessor.Instance(null), AutoGridRoots.VetAggregateCaseList, true);
        }

        [HttpPost]
        public ActionResult VetAggregateCasePicker(string formData)
        {
            return IndexInternal<VetAggregateCaseListItem.Accessor, VetAggregateCaseListItem, VetAggregateCaseListItem.VetAggregateCaseListItemGridModelList>
                (formData, VetAggregateCaseListItem.Accessor.Instance(null), AutoGridRoots.VetAggregateCaseList);
        }

       [HttpGet]
        public ActionResult VetAggregateCaseReport(long id)
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
                var model = new AggregateModel(ModelUserContext.CurrentLanguage, id, hc.idfsCaseObservationFormTemplate ?? 0,
                    hc.idfCaseObservation.Value, ModelUserContext.Instance.IsArchiveMode);
                report = wrapper.Client.ExportVetAggregateCase(model);
            }
            return ReportResponse(report, "VetAggregateCaseReport.pdf");
        }

       [HttpGet]
       public ActionResult Summary()
       {
           ViewBag.HelpUrl = HelpPathConstants.m_VetAggregateCaseSummaryPath;
           return DetailsInternal<VetAggregateCaseSummary.Accessor, VetAggregateCaseSummary>(null, VetAggregateCaseSummary.Accessor.Instance(null),
                null, null, null, null,
                c => ModelStorage.Put(Session.SessionID, c.idfAggrCase, c.idfAggrCase, c.ObjectIdent + "AggregateCaseListItems", c.AggregateCaseListItems)
                );
       }

    }
}
