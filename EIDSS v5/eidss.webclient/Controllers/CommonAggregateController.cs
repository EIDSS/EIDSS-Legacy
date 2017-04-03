using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Xml;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Reports;
using eidss.model.Reports.Common;
using eidss.model.Schema;
using eidss.webclient.Utils;

namespace eidss.webclient.Controllers
{
    [AuthorizeEIDSS]
    public class CommonAggregateController : Controller
    {
        public ActionResult AggregateSummaryHeader(AggregateCaseType caseType)
        {
            ViewBag.CaseType = caseType;
            FillLookupsViewBag();
            FillAggregateSummaryGridViewBag(caseType);
            Session["CaseType"] = caseType;
            Session["GridItems"] = ViewBag.GridModel;
            return PartialView();
        }

        #region FillViewBag

        private void FillLookupsViewBag()
        {
            using (DbManagerProxy dbmanager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                var accessor = (IObjectCreator)ObjectAccessor.AccessorInterface(typeof(HumanAggregateCaseListItem));
                var listItem = (HumanAggregateCaseListItem)accessor.CreateNew(dbmanager, null, null);
                ViewBag.AreaType = listItem.StatisticAreaTypeLookup;
                ViewBag.PeriodType = listItem.StatisticPeriodTypeLookup;
            }
        }

        private void FillAggregateSummaryGridViewBag(AggregateCaseType caseType)
        {
            string language = Cultures.GetSiteLanguage(Request);
            switch (caseType)
            {
                case AggregateCaseType.HumanAggregateCase:
                    FillHumanAggregateCaseGridViewBag(language);
                    break;
                case AggregateCaseType.VetAggregateCase:
                    FillVetAggregateCaseGridViewBag(language);
                    break;
                case AggregateCaseType.VetAggregateAction:
                    FillVetAggregateActionGridViewBag(language);
                    break;
            }
        }

        private void FillHumanAggregateCaseGridViewBag(string language)
        {
            ViewBag.GridModel = new List<HumanAggregateCaseListItem>();
            ViewBag.AggregateCasePickerPath = string.Format("/{0}/HumanAggregateCase/HumanAggregateCasePicker", language);
            ViewBag.AggregateCasePickerTitle = Translator.GetMessageString("titleHumanAggregateCasesList") + " (H15)";
            ViewBag.DetailAggregateCasePath = string.Format("/{0}/HumanAggregateCase/Details", language);
            ViewBag.AggregateCaseDetailTitle = "HumanAggregateCase";
        }

        private void FillVetAggregateCaseGridViewBag(string language)
        {
            ViewBag.GridModel = new List<VetAggregateCaseListItem>();
            ViewBag.AggregateCasePickerPath = string.Format("/{0}/VetAggregateCase/VetAggregateCasePicker", language);
            ViewBag.AggregateCasePickerTitle = Translator.GetMessageString("titleVetAggregateCasesList") + " (V09)";
            ViewBag.DetailAggregateCasePath = string.Format("/{0}/VetAggregateCase/Details", language);
            ViewBag.AggregateCaseDetailTitle = "VeterinaryAggregateCase";
        }

        private void FillVetAggregateActionGridViewBag(string language)
        {
            ViewBag.GridModel = new List<VetAggregateActionListItem>();
            ViewBag.AggregateCasePickerPath = string.Format("/{0}/VetAggregateAction/VetAggregateActionPicker", language);
            ViewBag.AggregateCasePickerTitle = Translator.GetMessageString("titleVetAggregateActionsList") + " (V13)";
            ViewBag.DetailAggregateCasePath = string.Format("/{0}/VetAggregateAction/Details", language);
            ViewBag.AggregateCaseDetailTitle = "VeterinaryAggregateAction";
        }

        #endregion
        
        public ActionResult AreaType_OnChange(string previousValue, string newValue)
        {
            bool isValidAdminLevel = IsValidAdminLevel(previousValue, newValue);
            var result = new { cansel = !isValidAdminLevel };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        
        private bool IsValidAdminLevel(string previousValue, string newValue)
        {
            if (bv.common.Core.Utils.IsEmpty(newValue))
            {
                return false;
            }
            int gridRowsCount = GetGridRowsCount();
            if (gridRowsCount <= 0)
            {
                return true;
            }
            var newAdminLevel = (StatisticAreaType)Int64.Parse(newValue);
            StatisticAreaType previousAdminLevel = ConvertStringToStatisticAreaType(previousValue);
            return AggregateHelper.ValidateAreaType(newAdminLevel, previousAdminLevel);
        }

        private static StatisticAreaType ConvertStringToStatisticAreaType(string value)
        {
            StatisticAreaType result = (bv.common.Core.Utils.IsEmpty(value)) ? StatisticAreaType.None : (StatisticAreaType)Int64.Parse(value);
            return result;
        }
        
        public ActionResult PeriodType_OnChange(string previousValue, string newValue)
        {
            bool isValidAdminLevel = IsValidTimeInterval(previousValue, newValue);
            var result = new { cansel = !isValidAdminLevel };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        private bool IsValidTimeInterval(string previousValue, string newValue)
        {
            if (bv.common.Core.Utils.IsEmpty(newValue))
            {
                return false;
            }
            int gridRowsCount = GetGridRowsCount();
            if (gridRowsCount <= 0)
            {
                return true;
            }
            var newTimeInterval = (StatisticPeriodType)Int64.Parse(newValue);
            StatisticPeriodType previousTimeInterval = ConvertStringToStatisticPeriodType(previousValue);
            return AggregateHelper.ValidatePeriodType(newTimeInterval, previousTimeInterval);
        }

        private static StatisticPeriodType ConvertStringToStatisticPeriodType(string value)
        {
            StatisticPeriodType result = (bv.common.Core.Utils.IsEmpty(value)) ? StatisticPeriodType.None : (StatisticPeriodType)Int64.Parse(value);
            return result;
        }

        private int GetGridRowsCount()
        {
            var gridItems = (IEnumerable<IObject>) Session["GridItems"];
            return gridItems.Count();
        }
        
        /// <summary>
        /// Button "Select" have been clicked in AggregateCasePicker
        /// </summary>
        /// <param name="selectedItems"></param>
        /// <param name="reportAreaType"></param>
        /// <param name="reportPeriodType"></param>
        /// <returns></returns>
        public ActionResult AddSelectedAggregateCaseItems(string selectedItems, string reportAreaType, string reportPeriodType)
        {
            List<string> selectedIds = selectedItems.Split(';').ToList();
            IList<IObject> selection = GetSelectedItems(selectedIds);
            JsonResult result = AddSelectedItemsInGridData(selection, reportAreaType, reportPeriodType);
            return result;
        }

        private IList<IObject> GetSelectedItems(List<string> selectedIds)
        {
            var caseType = (AggregateCaseType)Session["CaseType"];
            IList<IObject> selection = new List<IObject>();
            using (var manager = DbManagerFactory.Factory.Create(model.Core.EidssUserContext.Instance))
            {
                switch (caseType)
                {
                    case AggregateCaseType.HumanAggregateCase:
                        IList<IObject> humanAggregateCases = HumanAggregateCaseListItem.Accessor.Instance(null).SelectList(manager);
                        selection = humanAggregateCases.Where(x => selectedIds.Contains(x.Key.ToString())).ToList();
                        break;
                    case AggregateCaseType.VetAggregateCase:
                        IList<IObject> vetAggregateCases = VetAggregateCaseListItem.Accessor.Instance(null).SelectList(manager);
                        selection = vetAggregateCases.Where(x => selectedIds.Contains(x.Key.ToString())).ToList();
                        break;
                    case AggregateCaseType.VetAggregateAction:
                        IList<IObject> vetAggregateActions = VetAggregateActionListItem.Accessor.Instance(null).SelectList(manager);
                        selection = vetAggregateActions.Where(x => selectedIds.Contains(x.Key.ToString())).ToList();
                        break;
                }
            }
            return selection;
        }
        
        private JsonResult AddSelectedItemsInGridData(IList<IObject> selection, string reportAreaType, string reportPeriodType)
        {
            string errorMessage;
            bool isItemsValid = ValidateSelectedItems(selection, reportAreaType, reportPeriodType, out errorMessage);
            if (!isItemsValid)
            {
                return Json(new { isValid = isItemsValid, error = errorMessage }, JsonRequestBehavior.AllowGet);
            }

            var gridData = GetAggregateCaseGridDataAfterMerge(selection);
            return Json(gridData, JsonRequestBehavior.AllowGet);
        }
        
        /// <summary>
        /// Aggregate Case have been changed in AggregateCaseEditor
        /// </summary>
        /// <param name="selectedItem"></param>
        /// <param name="reportAreaType"></param>
        /// <param name="reportPeriodType"></param>
        /// <returns></returns>
        public ActionResult UpdateSelectedAggregateCaseItem(string selectedItem, string reportAreaType, string reportPeriodType)
        {
            var selectedIds = new List<string>{ selectedItem };
            IList<IObject> selection = GetSelectedItems(selectedIds);
            JsonResult result = UpdateSelectedItemInGridData(selection[0], reportAreaType, reportPeriodType);
            return result;
        }

        private JsonResult UpdateSelectedItemInGridData(IObject selectedItem, string reportAreaType, string reportPeriodType)
        {
            Int64 itemId = Int64.Parse(selectedItem.Key.ToString());
            RemoveAggregateItemFromGridData(itemId);

            string errorMessage;
            var selection = new List<IObject> { selectedItem };
            bool isItemsValid = ValidateSelectedItems(selection, reportAreaType, reportPeriodType, out errorMessage);
            if (!isItemsValid)
            {
                object resultData = GetGridDataFromSessionForJsonResult();
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }

            var gridData = GetAggregateCaseGridDataAfterMerge(selection);
            return Json(gridData, JsonRequestBehavior.AllowGet);
        }

        #region Selection validation

        private bool ValidateSelectedItems(IList<IObject> selection, string reportAreaType, string reportPeriodType, out string errorMessage)
        {
            Dictionary<string, object> parameters = GetValidationParameters(reportAreaType, reportPeriodType);
            bool isItemsValid = AggregateHelper.ValidateSelection(selection, parameters, out errorMessage);
            return isItemsValid;
        }

        private Dictionary<string, object> GetValidationParameters(string reportAreaType, string reportPeriodType)
        {
            var parameters = new Dictionary<string, object>();
            IObject firstRow = GetGridFirstRow();
            if (firstRow != null)
            {
                Int64 areaType = Int64.Parse(firstRow.GetValue("idfsAreaType").ToString());
                Int64 periodType = Int64.Parse(firstRow.GetValue("idfsPeriodType").ToString());
                parameters.Add("AreaType", areaType);
                parameters.Add("PeriodType", periodType);
            }
            parameters.Add("ReportAreaType", Int64.Parse(reportAreaType));
            parameters.Add("ReportPeriodType", Int64.Parse(reportPeriodType));
            return parameters;
        }

        private IObject GetGridFirstRow()
        {
            List<IObject> gridItems = ((IEnumerable<IObject>)Session["GridItems"]).ToList();
            IObject firstRow = gridItems.Count > 0 ? gridItems[0] : null;
            return firstRow;
        }

        #endregion

        #region Merge selection and grid data
        
        private object GetAggregateCaseGridDataAfterMerge(IList<IObject> selection)
        {
            var gridData = new object();

            var caseType = (AggregateCaseType)Session["CaseType"];
            switch (caseType)
            {
                case AggregateCaseType.HumanAggregateCase:
                    gridData = GetHumanAggregateCaseGridDataAfterMerge(selection);
                    break;
                case AggregateCaseType.VetAggregateCase:
                    gridData = GetVetAggregateCaseGridDataAfterMerge(selection);
                    break;
                case AggregateCaseType.VetAggregateAction:
                    gridData = VetAggregateActionGridDataAfterMerge(selection);
                    break;
            }

            return gridData;
        }

        private object GetHumanAggregateCaseGridDataAfterMerge(IList<IObject> selection)
        {
            List<HumanAggregateCaseListItem> humanCaseList = Merge<HumanAggregateCaseListItem>(selection);
            var gridData = new HumanAggregateCaseListItem.HumanAggregateCaseListItemGridModelList(
                AutoGridRoots.HumanAggregateCaseSummaryHeaderList, humanCaseList);
            var result = new { isValid = true, data = gridData, total = gridData.Count };
            return result;
        }

        private object GetVetAggregateCaseGridDataAfterMerge(IList<IObject> selection)
        {
            List<VetAggregateCaseListItem> vetCaseList = Merge<VetAggregateCaseListItem>(selection);
            var gridData = new VetAggregateCaseListItem.VetAggregateCaseListItemGridModelList(
                AutoGridRoots.VetAggregateCaseSummaryHeaderList, vetCaseList);
            var result = new { isValid = true, data = gridData, total = gridData.Count };
            return result;
        }

        private object VetAggregateActionGridDataAfterMerge(IList<IObject> selection)
        {
            List<VetAggregateActionListItem> vetAggregateList = Merge<VetAggregateActionListItem>(selection);
            var gridData = new VetAggregateActionListItem.VetAggregateActionListItemGridModelList(
                AutoGridRoots.VetAggregateActionSummaryHeaderList, vetAggregateList);
            var result = new { isValid = true, data = gridData, total = gridData.Count };
            return result;
        }

        private List<T> Merge<T>(IList<IObject> selection) where T : class, IObject
        {
            var items = new List<T>();
            var currentCases = (IList<T>)Session["GridItems"];
            if (currentCases != null && currentCases.Count > 0)
            {
                var selectedCases = selection.Cast<T>().ToList();
                var union = selectedCases.Union(currentCases, new ObjectComparer());
                items = union.Cast<T>().ToList();
            }
            else
            {
                items = selection.Cast<T>().ToList();
            }
            Session["GridItems"] = items;
            return items;
        }

        #endregion

        public ActionResult RemoveAggregateCaseItem(string selectedId)
        {
            Int64 itemId = Int64.Parse(selectedId);
            RemoveAggregateItemFromGridData(itemId);
            object gridData = GetGridDataFromSessionForJsonResult();
            return Json(gridData, JsonRequestBehavior.AllowGet);
        }

        #region Remove item from grid data

        private void RemoveAggregateItemFromGridData(Int64 removeItemId)
        {
            var caseType = (AggregateCaseType)Session["CaseType"];
            switch (caseType)
            {
                case AggregateCaseType.HumanAggregateCase:
                    RemoveHumanAggregateCaseFromGridData(removeItemId);
                    break;
                case AggregateCaseType.VetAggregateCase:
                    RemoveVetAggregateCaseFromGridData(removeItemId);
                    break;
                case AggregateCaseType.VetAggregateAction:
                    RemoveVetAggregateActionFromGridData(removeItemId);
                    break;
            }
        }

        private void RemoveHumanAggregateCaseFromGridData(Int64 removeItemId)
        {
            var humanCaseList = (IList<HumanAggregateCaseListItem>)Session["GridItems"];
            HumanAggregateCaseListItem humanAggregateCaseItem =
                humanCaseList.Where(x => x.idfAggrCase == removeItemId).FirstOrDefault();
            humanCaseList.Remove(humanAggregateCaseItem);
            Session["GridItems"] = humanCaseList;
        }

        private void RemoveVetAggregateCaseFromGridData(Int64 removeItemId)
        {
            var vetCaseList = (IList<VetAggregateCaseListItem>)Session["GridItems"];
            VetAggregateCaseListItem vetAggregateCaseItem =
                vetCaseList.Where(x => x.idfAggrCase == removeItemId).FirstOrDefault();
            vetCaseList.Remove(vetAggregateCaseItem);
            Session["GridItems"] = vetCaseList;
        }

        private void RemoveVetAggregateActionFromGridData(Int64 removeItemId)
        {
            var vetAggregateActionList = (IList<VetAggregateActionListItem>)Session["GridItems"];
            VetAggregateActionListItem vetAggregateActionItem =
                vetAggregateActionList.Where(x => x.idfAggrCase == removeItemId).FirstOrDefault();
            vetAggregateActionList.Remove(vetAggregateActionItem);
            Session["GridItems"] = vetAggregateActionList;
        }

        #endregion

        public ActionResult RemoveAllAggregateCaseItems()
        {
            RemoveAllItemsFromGridData();
            object gridData = GetGridDataFromSessionForJsonResult();
            return Json(gridData, JsonRequestBehavior.AllowGet);
        }

        private void RemoveAllItemsFromGridData()
        {
            var caseType = (AggregateCaseType)Session["CaseType"];
            switch (caseType)
            {
                case AggregateCaseType.HumanAggregateCase:
                    var humanCaseList = (IList<HumanAggregateCaseListItem>)Session["GridItems"];
                    humanCaseList.Clear();
                    Session["GridItems"] = humanCaseList;
                    break;
                case AggregateCaseType.VetAggregateCase:
                    var vetCaseList = (IList<VetAggregateCaseListItem>)Session["GridItems"];
                    vetCaseList.Clear();
                    Session["GridItems"] = vetCaseList;
                    break;
                case AggregateCaseType.VetAggregateAction:
                    var vetAggregateActionList = (IList<VetAggregateActionListItem>)Session["GridItems"];
                    vetAggregateActionList.Clear();
                    Session["GridItems"] = vetAggregateActionList;
                    break;
            }
        }

        #region Get grid data from session for JsonResult

        private object GetGridDataFromSessionForJsonResult()
        {
            var gridData = new object();

            var caseType = (AggregateCaseType)Session["CaseType"];
            switch (caseType)
            {
                case AggregateCaseType.HumanAggregateCase:
                    gridData = GetJsonHumanAggregateCaseGridDataFromSession();
                    break;
                case AggregateCaseType.VetAggregateCase:
                    gridData = GetVetAggregateCaseGridDataFromSession();
                    break;
                case AggregateCaseType.VetAggregateAction:
                    gridData = GetVetAggregateActionGridDataFromSession();
                    break;
            }

            return gridData;
        }

        private object GetJsonHumanAggregateCaseGridDataFromSession()
        {
            var humanCaseList = (IList<HumanAggregateCaseListItem>)Session["GridItems"];
            var gridData = new HumanAggregateCaseListItem.HumanAggregateCaseListItemGridModelList(
                    AutoGridRoots.HumanAggregateCaseSummaryHeaderList, humanCaseList);
            var result = new { data = gridData, total = gridData.Count };
            return result;
        }

        private object GetVetAggregateCaseGridDataFromSession()
        {
            var vetCaseList = (IList<VetAggregateCaseListItem>)Session["GridItems"];
            var gridData = new VetAggregateCaseListItem.VetAggregateCaseListItemGridModelList(
                   AutoGridRoots.VetAggregateCaseSummaryHeaderList, vetCaseList);
            var result = new { data = gridData, total = gridData.Count };
            return result;
        }

        private object GetVetAggregateActionGridDataFromSession()
        {
            var vetAggregateList = (IList<VetAggregateActionListItem>)Session["GridItems"];
            var gridData = new VetAggregateActionListItem.VetAggregateActionListItemGridModelList(
                    AutoGridRoots.VetAggregateActionSummaryHeaderList, vetAggregateList);
            var result = new { data = gridData, total = gridData.Count };
            return result;
        }

        #endregion

        [HttpGet]
        public ActionResult SummaryFlexibleForm()
        {
            //int gridRowsCount = GetGridRowsCount();
            //if(gridRowsCount == 0)
            //{
            //    return Json(new { data = "" }, JsonRequestBehavior.AllowGet);
            //}

            var ffData = GetFlexibleFormDataForJsonResult();
            return Json(new { data = ffData }, JsonRequestBehavior.AllowGet);
        }

        #region Get Flexible Form data for JsonResult

        private object GetFlexibleFormDataForJsonResult()
        {
            var ffData = new object();

            var caseType = (AggregateCaseType)Session["CaseType"];
            switch (caseType)
            {
                case AggregateCaseType.HumanAggregateCase:
                    ffData = GetAggregateCaseFlexibleFormData(FFTypeEnum.HumanAggregateCase);
                    break;
                case AggregateCaseType.VetAggregateCase:
                    ffData = GetAggregateCaseFlexibleFormData(FFTypeEnum.VetAggregateCase);
                    break;
                case AggregateCaseType.VetAggregateAction:
                    ffData = GetVetAggregateActionFlexibleFormData();
                    break;
            }

            return ffData;
        }

        private object GetAggregateCaseFlexibleFormData(FFTypeEnum aggregateCaseType)
        {
            var divData = GetFlexibleFormSummaryData(aggregateCaseType, "idfCaseObservation", "divFfSummary");
            var resultData = new object[1] { divData };
            return resultData;
        }
        
        private object GetVetAggregateActionFlexibleFormData()
        {
            var divDiagnosticData = GetFlexibleFormSummaryData(FFTypeEnum.VetEpizooticActionDiagnosisInv, "idfDiagnosticObservation", "divDiagnosticFfSummary"); 
            var divProphylacticData = GetFlexibleFormSummaryData(FFTypeEnum.VetEpizooticActionTreatment, "idfProphylacticObservation", "divProphilacticFfSummary");
            var divSanitaryData = GetFlexibleFormSummaryData(FFTypeEnum.VetEpizooticAction, "idfSanitaryObservation", "divSanitaryFfSummary");
            var vetAggregateActionResultData = new object[3] { divDiagnosticData, divProphylacticData, divSanitaryData };
            return vetAggregateActionResultData;
        }

        private object GetFlexibleFormSummaryData(FFTypeEnum ffType, string observationFieldName, string divName)
        {
            var ffModel = new FFPresenterModel((long)ffType);
            ffModel.PrepareSummary(GetObservarionsList(observationFieldName));
            ModelStorage.Put(Session.SessionID, 0, 0, "0", ffModel);
            string aggregateCaseDivContent = this.RenderPartialView("SummaryFFHolder", ffModel);
            var ffSummaryData = new { divId = divName, divContent = aggregateCaseDivContent };
            return ffSummaryData;
        }

        #endregion

        [HttpGet]
        public ActionResult AggregateReport(string reportAreaType, string reportPeriodType)
        {
            byte[] report = GetPdfReport(reportAreaType, reportPeriodType);
            const string fileName = "AggregateReport.pdf";
            Response.AppendHeader("content-disposition", "inline; filename=" + fileName);
            return File(report, "application/pdf", fileName);
        }

        private byte[] GetPdfReport(string reportAreaType, string reportPeriodType)
        {
            StatisticAreaType areaType = ConvertStringToStatisticAreaType(reportAreaType);
            StatisticPeriodType periodType = ConvertStringToStatisticPeriodType(reportPeriodType);
            string parametersXml = GetCurrentParametersXML(areaType, periodType);

            byte[] report = null;

            var caseType = (AggregateCaseType) Session["CaseType"];
            switch (caseType)
            {
                case AggregateCaseType.HumanAggregateCase:
                    List<long> humanObservations = GetObservarionsList("idfCaseObservation");
                     using (var wrapper = new ReportClientWrapper())
                     {
                         var model = new AggregateSummaryModel(ModelUserContext.CurrentLanguage, parametersXml, humanObservations, ModelUserContext.Instance.IsArchiveMode);
                         report = wrapper.Client.ExportHumAggregateCaseSummary( model);
                     }
                    break;
                case AggregateCaseType.VetAggregateCase:
                    List<long> observations = GetObservarionsList("idfCaseObservation");

                     using (var wrapper = new ReportClientWrapper())
                     {
                         var model = new AggregateSummaryModel(ModelUserContext.CurrentLanguage, parametersXml, observations, ModelUserContext.Instance.IsArchiveMode);
                         report = wrapper.Client.ExportVetAggregateCaseSummary( model);
                     }
                    break;
                case AggregateCaseType.VetAggregateAction:
                    report = GetVetAggregateActionReport(ModelUserContext.CurrentLanguage, parametersXml);
                    break;
            }

            return report;
        }

        private byte[] GetVetAggregateActionReport(string language, string parametersXml)
        {
            List<long> diagnosticObservations = GetObservarionsList("idfDiagnosticObservation");
            List<long> prophylacticObservations = GetObservarionsList("idfProphylacticObservation");
            List<long> sanitaryObservations = GetObservarionsList("idfSanitaryObservation");
            Dictionary<string, string> labels = GetLabelsForVetAggregateActionTab(language);
            byte[] report;
            using (var wrapper = new ReportClientWrapper())
            {
                var aggrParams = new AggregateActionsSummaryModel(ModelUserContext.CurrentLanguage,
                                                                  parametersXml,
                                                                  diagnosticObservations,
                                                                  prophylacticObservations,
                                                                  sanitaryObservations,
                                                                  labels,
                                                                  ModelUserContext.Instance.IsArchiveMode);
                report = wrapper.Client.ExportVetAggregateCaseActionsSummary( aggrParams);
            }
            return report;
        }

        private List<long> GetObservarionsList(string observationFieldName)
        {
            var gridItems = (IEnumerable<IObject>) Session["GridItems"];
            List<long> observations = gridItems.Select(item => (long) item.GetValue(observationFieldName)).ToList();
            return observations.Count > 0 ? observations : new List<long>();
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

        #region Parameters XML support

        private string GetCurrentParametersXML(StatisticAreaType reportAreaType, StatisticPeriodType reportPeriodType)
        {
            int gridRowsCount = GetGridRowsCount();
            if (gridRowsCount > 0)
            {
                XmlNode adminNode = null;
                XmlNode timeIntervalNode = null;
                XmlDocument xmlDocument = InitXml(reportAreaType.ToString(), reportPeriodType.ToString(), ref adminNode, ref timeIntervalNode);
                IEnumerable<IObject> areas = ((IEnumerable<IObject>)Session["GridItems"]).Distinct<IObject>(new AreaComparer(reportAreaType));
                foreach (IObject area in areas)
                {
                    AddAdminUnitNode(xmlDocument, adminNode, GetAdminUnit(area, reportAreaType));
                }
                IEnumerable<IObject> periods = ((IEnumerable<IObject>)Session["GridItems"]).Distinct<IObject>(new PeriodComparer());
                foreach (IObject period in periods)
                {
                    AddTimeIntervalUnitNode(xmlDocument, timeIntervalNode, Convert.ToDateTime(period.GetValue("datStartDate")), Convert.ToDateTime(period.GetValue("datFinishDate")));
                }
                var sb = new StringBuilder();
                var sw = new StringWriter(sb);
                var xmlW = new XmlTextWriter(sw);
                xmlDocument.WriteTo(xmlW);
                xmlW.Close();
                sw.Close();
                string aggrXml = sb.ToString();
                return aggrXml;
            }

            return null;
        }

        private static string GetAdminUnit(IObject bo, StatisticAreaType reportAreaType)
        {
            switch (reportAreaType)
            {
                case StatisticAreaType.Country:
                    return bv.common.Core.Utils.Str(bo.GetValue("idfsCountry") ?? 0);
                case StatisticAreaType.Rayon:
                    return bv.common.Core.Utils.Str(bo.GetValue("idfsRayon") ?? 0);
                case StatisticAreaType.Region:
                    return bv.common.Core.Utils.Str(bo.GetValue("idfsRegion") ?? 0);
                case StatisticAreaType.Settlement:
                    return bv.common.Core.Utils.Str(bo.GetValue("idfsSettlement") ?? 0);
                default:
                    return "0";
            }

        }

        private static XmlDocument InitXml(string areaType, string periodType, ref XmlNode adminNode, ref XmlNode timeIntervalNode)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml("<?xml version=\"1.0\" encoding =\"UTF-16\"?><ROOT/>");

            XmlNode root = xmlDocument.DocumentElement;

            adminNode = xmlDocument.CreateNode(XmlNodeType.Element, "AdminLevel", root.NamespaceURI);
            XmlAttribute attrAreaType = xmlDocument.CreateAttribute("AreaType");
            attrAreaType.Value = bv.common.Core.Utils.Str(areaType);
            adminNode.Attributes.Append(attrAreaType);
            root.AppendChild(adminNode);

            timeIntervalNode = xmlDocument.CreateNode(XmlNodeType.Element, "TimeInterval", root.NamespaceURI);
            XmlAttribute attrPeriodType = xmlDocument.CreateAttribute("PeriodType");
            attrPeriodType.Value = bv.common.Core.Utils.Str(periodType);
            timeIntervalNode.Attributes.Append(attrPeriodType);
            root.AppendChild(timeIntervalNode);
            return xmlDocument;
        }

        private static void AddAdminUnitNode(XmlDocument xmlDocument, XmlNode adminNode, string adminUnitID)
        {
            XmlNode adminUnitNode = xmlDocument.CreateNode(XmlNodeType.Element, "AdminUnit", adminNode.NamespaceURI);
            XmlAttribute attrAUID = xmlDocument.CreateAttribute("AdminUnitID");
            attrAUID.Value = bv.common.Core.Utils.Str(adminUnitID);
            adminUnitNode.Attributes.Append(attrAUID);
            adminNode.AppendChild(adminUnitNode);
        }

        private static void AddTimeIntervalUnitNode(XmlDocument xmlDocument, XmlNode timeIntervalNode, DateTime startDate, DateTime finishDate)
        {
            XmlNode timeIntervalUnitNode = xmlDocument.CreateNode(XmlNodeType.Element, "TimeIntervalUnit", timeIntervalNode.NamespaceURI);

            XmlAttribute attrSD = xmlDocument.CreateAttribute("StartDate");
            attrSD.Value = startDate.ToString("yyyy-MM-dd");
            timeIntervalUnitNode.Attributes.Append(attrSD);

            XmlAttribute attrFD = xmlDocument.CreateAttribute("FinishDate");
            attrFD.Value = finishDate.ToString("yyyy-MM-dd");
            timeIntervalUnitNode.Attributes.Append(attrFD);

            timeIntervalNode.AppendChild(timeIntervalUnitNode);
        }

        #endregion
    }
}
