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
    public class HumanAggregateCaseController : BvController
    {
        public ActionResult Index()
        {
            return IndexInternal<HumanAggregateCaseListItem.Accessor, HumanAggregateCaseListItem, HumanAggregateCaseListItem.HumanAggregateCaseListItemGridModelList>
                (HumanAggregateCaseListItem.Accessor.Instance(null), AutoGridRoots.HumanAggregateCaseList, false);
        }

        [CompressFilter]
        public ActionResult IndexAjax([DataSourceRequest]DataSourceRequest request, FormCollection form)
        {
            return IndexInternalAjax<HumanAggregateCaseListItem.Accessor, HumanAggregateCaseListItem, HumanAggregateCaseListItem.HumanAggregateCaseListItemGridModelList>
                (form, HumanAggregateCaseListItem.Accessor.Instance(null), AutoGridRoots.HumanAggregateCaseList, request);
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
        [CompressFilter]
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
            //var hc = ModelStorage.Get(ModelUserContext.ClientID, key, null) as AggregateCaseHeader;
            ObjectStorage.Using<AggregateCaseHeader, bool>(hc =>
                {
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
                    return false;
                }, ModelUserContext.ClientID, key, null);
        }

        void hc_ValidationDetails(object sender, ValidationEventArgs args)
        {
            ViewData["ErrorMessage"] = Translator.GetErrorMessage(args);
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
            ObjectStorage.Put(ModelUserContext.ClientID, aggregateCase.idfAggrCase - 1, aggregateCase.idfAggrCase - 1, null, aggregateCase);
            ObjectStorage.Put(ModelUserContext.ClientID, aggregateCase.idfAggrCase, aggregateCase.idfAggrCase, null, aggregateCase.Header);
            if (aggregateCase.Header.FFPresenterCase.CurrentObservation.HasValue)
            {
                var idObservation = aggregateCase.Header.FFPresenterCase.CurrentObservation.Value;
                ObjectStorage.Put(ModelUserContext.ClientID, aggregateCase.idfAggrCase, aggregateCase.idfAggrCase, idObservation.ToString(), aggregateCase.Header.FFPresenterCase);
            }
        }

        [HttpGet]
        public ActionResult HumanAggregateCasePicker(string reportAreaType, string reportPeriodType)
        {
            ViewBag.ReportAreaType = reportAreaType;
            ViewBag.ReportPeriodType = reportPeriodType;

            return IndexInternal<HumanAggregateCaseListItem.Accessor, HumanAggregateCaseListItem, HumanAggregateCaseListItem.HumanAggregateCaseListItemGridModelList>
                (HumanAggregateCaseListItem.Accessor.Instance(null), AutoGridRoots.AsSessionList, true);
        }

        [HttpPost]
        public ActionResult HumanAggregateCasePicker(string formData)
        {
            return IndexInternal<HumanAggregateCaseListItem.Accessor, HumanAggregateCaseListItem, HumanAggregateCaseListItem.HumanAggregateCaseListItemGridModelList>
                (formData, HumanAggregateCaseListItem.Accessor.Instance(null), AutoGridRoots.AsSessionList);
        }

        [HttpGet]
        public ActionResult HumanAggregateCaseReport(long id)
        {
            //var hc = ModelStorage.Get(ModelUserContext.ClientID, id, null) as AggregateCaseHeader;
            return ObjectStorage.Using<AggregateCaseHeader, ActionResult>(hc =>
                {
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
                        report = wrapper.Client.ExportHumAggregateCase(model);
                    }
                    return ReportResponse(report, "HumanAggregateCaseReport.pdf");
                }, ModelUserContext.ClientID, id, null);
        }

        [HttpGet]
        public ActionResult Summary()
        {
            ViewBag.HelpUrl = HelpPathConstants.m_HumanAggregateCaseSummaryPath;
            return DetailsInternal<HumanAggregateCaseSummary.Accessor, HumanAggregateCaseSummary>(null, HumanAggregateCaseSummary.Accessor.Instance(null),
                 null, null, null, null, 
                 c => ObjectStorage.Put(ModelUserContext.ClientID, c.idfAggrCase, c.idfAggrCase, c.ObjectIdent + "AggregateCaseListItems", c.AggregateCaseListItems)
                 );
        }

    }
}
