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
    public class VetAggregateActionController : BvController
    {
        public ActionResult Index()
        {
            return IndexInternal<VetAggregateActionListItem.Accessor, VetAggregateActionListItem, VetAggregateActionListItem.VetAggregateActionListItemGridModelList>
                (VetAggregateActionListItem.Accessor.Instance(null), AutoGridRoots.VetAggregateActionList, false);
        }

        public ActionResult IndexAjax([DataSourceRequest]DataSourceRequest request, FormCollection form)
        {
            return IndexInternalAjax<VetAggregateActionListItem.Accessor, VetAggregateActionListItem, VetAggregateActionListItem.VetAggregateActionListItemGridModelList>
                (form, VetAggregateActionListItem.Accessor.Instance(null), AutoGridRoots.VetAggregateActionList, request);
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
        public ActionResult VetAggregateActionPicker(string reportAreaType, string reportPeriodType)
        {
            ViewBag.ReportAreaType = reportAreaType;
            ViewBag.ReportPeriodType = reportPeriodType;

            return IndexInternal<VetAggregateActionListItem.Accessor, VetAggregateActionListItem, VetAggregateActionListItem.VetAggregateActionListItemGridModelList>
                (VetAggregateActionListItem.Accessor.Instance(null), AutoGridRoots.VetAggregateActionList, true);
        }

        [HttpPost]
        public ActionResult VetAggregateActionPicker(string formData)
        {
            return IndexInternal<VetAggregateActionListItem.Accessor, VetAggregateActionListItem, VetAggregateActionListItem.VetAggregateActionListItemGridModelList>
                (formData, VetAggregateActionListItem.Accessor.Instance(null), AutoGridRoots.VetAggregateActionList);
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
            return ReportResponse(report, "VetAggregateActionReport.pdf");
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


        [HttpGet]
        public ActionResult Summary()
        {
            ViewBag.HelpUrl = HelpPathConstants.m_VetAggregateActionSummaryPath;
            return DetailsInternal<VetAggregateActionSummary.Accessor, VetAggregateActionSummary>(null, VetAggregateActionSummary.Accessor.Instance(null),
                 null, null, null, null,
                 c => ModelStorage.Put(Session.SessionID, c.idfAggrCase, c.idfAggrCase, c.ObjectIdent + "AggregateCaseListItems", c.AggregateCaseListItems)
                 );
        }
    }
}
