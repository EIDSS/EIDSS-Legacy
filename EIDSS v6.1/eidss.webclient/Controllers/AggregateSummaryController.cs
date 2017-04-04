using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Xml;
using BLToolkit.EditableObjects;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Reports;
using eidss.model.Reports.Common;
using eidss.model.Schema;
using eidss.web.common.Controllers;
using eidss.web.common.Utils;
using eidss.webclient.Utils;

namespace eidss.webclient.Controllers
{
    [AuthorizeEIDSS]
    public class AggregateSummaryController : BvController
    {
        //[HttpPost] bug 12240
        public ActionResult AddSelectedAggregateCaseItems(string selectedItems, string reportAreaType, string reportPeriodType, long idfAggrCase)
        {
            var selectedIds = selectedItems.Split(',').Select(c => Int64.Parse(c)).ToList();
            var selection = GetSelectedItems(selectedIds, idfAggrCase);
            var data = new CompareModel();
            string strMessage;
            bool res = ValidateSelectedItems(selection.ToList(), reportAreaType, reportPeriodType, idfAggrCase, out strMessage);
            if (res)
            {
                //var aggrSum = ModelStorage.Get(ModelUserContext.ClientID, idfAggrCase, null);
                ObjectStorage.Using<IObject, bool>(aggrSum =>
                    {
                        if (aggrSum is HumanAggregateCaseSummary)
                            (aggrSum as HumanAggregateCaseSummary).AggregateCaseListItems.AddRange(selection.Where(c => !(aggrSum as HumanAggregateCaseSummary).AggregateCaseListItems.Any(i => i.idfAggrCase == (long)c.Key && !i.IsMarkedToDelete)).ToList());
                        else if (aggrSum is VetAggregateCaseSummary)
                            (aggrSum as VetAggregateCaseSummary).AggregateCaseListItems.AddRange(selection.Where(c => !(aggrSum as VetAggregateCaseSummary).AggregateCaseListItems.Any(i => i.idfAggrCase == (long)c.Key && !i.IsMarkedToDelete)).ToList());
                        else if (aggrSum is VetAggregateActionSummary)
                            (aggrSum as VetAggregateActionSummary).AggregateCaseListItems.AddRange(selection.Where(c => !(aggrSum as VetAggregateActionSummary).AggregateCaseListItems.Any(i => i.idfAggrCase == (long)c.Key && !i.IsMarkedToDelete)).ToList());
                        return false;
                    }, ModelUserContext.ClientID, idfAggrCase, null);
            }
            else
            {
                data.Add("ErrorMessage", "ErrorMessage", "ErrorMessage", strMessage, false, false, false);
            }
            return new JsonResult { Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        public ActionResult RemoveAllAggregateCaseItems(long idfAggrCase)
        {
            //var aggrSum = ModelStorage.Get(ModelUserContext.ClientID, idfAggrCase, null);
            return ObjectStorage.Using<IObject, ActionResult>(aggrSum =>
                {
                    if (aggrSum is HumanAggregateCaseSummary)
                        (aggrSum as HumanAggregateCaseSummary).AggregateCaseListItems.RemoveAll(c => true);
                    else if (aggrSum is VetAggregateCaseSummary)
                        (aggrSum as VetAggregateCaseSummary).AggregateCaseListItems.RemoveAll(c => true);
                    else if (aggrSum is VetAggregateActionSummary)
                        (aggrSum as VetAggregateActionSummary).AggregateCaseListItems.RemoveAll(c => true);

                    var data = new CompareModel();
                    return new JsonResult { Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }, ModelUserContext.ClientID, idfAggrCase, null);
        }


        private bool ValidateSelectedItems(IList<IObject> selection, string reportAreaType, string reportPeriodType, long idfAggrCase, out string errorMessage)
        {
            Dictionary<string, object> parameters = GetValidationParameters(reportAreaType, reportPeriodType, idfAggrCase);
            bool isItemsValid = AggregateHelper.ValidateSelection(selection, parameters, out errorMessage);
            return isItemsValid;
        }
        private Dictionary<string, object> GetValidationParameters(string reportAreaType, string reportPeriodType, long idfAggrCase)
        {
            var parameters = new Dictionary<string, object>();
            IObject firstRow = GetGridFirstRow(idfAggrCase);
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
        private IObject GetGridFirstRow(long idfAggrCase)
        {
            //var aggrSum = ModelStorage.Get(ModelUserContext.ClientID, idfAggrCase, null);
            return ObjectStorage.Using<IObject, IObject>(aggrSum =>
                {
                    if (aggrSum is HumanAggregateCaseSummary && (aggrSum as HumanAggregateCaseSummary).AggregateCaseListItems.Count > 0)
                        return (aggrSum as HumanAggregateCaseSummary).AggregateCaseListItems[0];
                    if (aggrSum is VetAggregateCaseSummary && (aggrSum as VetAggregateCaseSummary).AggregateCaseListItems.Count > 0)
                        return (aggrSum as VetAggregateCaseSummary).AggregateCaseListItems[0];
                    if (aggrSum is VetAggregateActionSummary && (aggrSum as VetAggregateActionSummary).AggregateCaseListItems.Count > 0)
                        return (aggrSum as VetAggregateActionSummary).AggregateCaseListItems[0];

                    return null;
                }, ModelUserContext.ClientID, idfAggrCase, null);
        }


        private IList<IObject> GetSelectedItems(List<long> selectedIds, long idfAggrCase)
        {
            //var aggrSum = ModelStorage.Get(ModelUserContext.ClientID, idfAggrCase, null);
            return ObjectStorage.Using<IObject, IList<IObject>>(aggrSum =>
                {
                    using (var manager = DbManagerFactory.Factory.Create(model.Core.EidssUserContext.Instance))
                    {
                        if (aggrSum is HumanAggregateCaseSummary)
                            return HumanAggregateCaseListItem.Accessor.Instance(null).SelectListT(manager).Where(x => selectedIds.Contains(x.idfAggrCase)).Cast<IObject>().ToList();
                        if (aggrSum is VetAggregateCaseSummary)
                            return VetAggregateCaseListItem.Accessor.Instance(null).SelectListT(manager).Where(x => selectedIds.Contains(x.idfAggrCase)).Cast<IObject>().ToList();
                        if (aggrSum is VetAggregateActionSummary)
                            return VetAggregateActionListItem.Accessor.Instance(null).SelectListT(manager).Where(x => selectedIds.Contains(x.idfAggrCase)).Cast<IObject>().ToList();
                    }
                    return new List<IObject>();
                }, ModelUserContext.ClientID, idfAggrCase, null);
        }




        [HttpGet]
        [CompressFilter]
        public ActionResult SummaryFlexibleForm(long idfAggrCase)
        {
            var ffData = GetFlexibleFormDataForJsonResult(idfAggrCase);
            return Json(new { data = ffData }, JsonRequestBehavior.AllowGet);
        }

        #region Get Flexible Form data for JsonResult

        private object GetFlexibleFormDataForJsonResult(long idfAggrCase)
        {
            //var aggrSum = ModelStorage.Get(ModelUserContext.ClientID, idfAggrCase, null);
            return ObjectStorage.Using<IObject, object>(aggrSum =>
                {
                    var ffData = new object();
                    if (aggrSum is HumanAggregateCaseSummary)
                        ffData = GetAggregateCaseFlexibleFormData(FFTypeEnum.HumanAggregateCase, idfAggrCase);
                    else if (aggrSum is VetAggregateCaseSummary)
                        ffData = GetAggregateCaseFlexibleFormData(FFTypeEnum.VetAggregateCase, idfAggrCase);
                    else if (aggrSum is VetAggregateActionSummary)
                        ffData = GetVetAggregateActionFlexibleFormData(idfAggrCase);
                    return ffData;
                }, ModelUserContext.ClientID, idfAggrCase, null);
        }

        private object GetAggregateCaseFlexibleFormData(FFTypeEnum aggregateCaseType, long idfAggrCase)
        {
            var divData = GetFlexibleFormSummaryData(aggregateCaseType, "idfCaseObservation", "divFfSummary", idfAggrCase);
            var resultData = new object[1] { divData };
            return resultData;
        }

        private object GetVetAggregateActionFlexibleFormData(long idfAggrCase)
        {
            var divDiagnosticData = GetFlexibleFormSummaryData(FFTypeEnum.VetEpizooticActionDiagnosisInv, "idfDiagnosticObservation", "divDiagnosticFfSummary", idfAggrCase);
            var divProphylacticData = GetFlexibleFormSummaryData(FFTypeEnum.VetEpizooticActionTreatment, "idfProphylacticObservation", "divProphilacticFfSummary", idfAggrCase);
            var divSanitaryData = GetFlexibleFormSummaryData(FFTypeEnum.VetEpizooticAction, "idfSanitaryObservation", "divSanitaryFfSummary", idfAggrCase);
            var vetAggregateActionResultData = new object[3] { divDiagnosticData, divProphylacticData, divSanitaryData };
            return vetAggregateActionResultData;
        }

        private object GetFlexibleFormSummaryData(FFTypeEnum ffType, string observationFieldName, string divName, long idfAggrCase)
        {
            var ffModel = new FFPresenterModel((long)ffType);
            ffModel.PrepareSummary(GetObservarionsList(observationFieldName, idfAggrCase));
            ObjectStorage.Put(ModelUserContext.ClientID, idfAggrCase, idfAggrCase + 1, (idfAggrCase + 2).ToString(), ffModel);
            string aggregateCaseDivContent = "";
            //var aggrSum = ModelStorage.Get(ModelUserContext.ClientID, idfAggrCase, null);
            return ObjectStorage.Using<IObject, object>(aggrSum =>
                {
                    if (aggrSum is HumanAggregateCaseSummary)
                        aggregateCaseDivContent = this.RenderPartialView("HumanAggregateCaseFlexibleForm", aggrSum as HumanAggregateCaseSummary);
                    else if (aggrSum is VetAggregateCaseSummary)
                        aggregateCaseDivContent = this.RenderPartialView("VetAggregateCaseFlexibleForm", aggrSum as VetAggregateCaseSummary);
                    else if (aggrSum is VetAggregateActionSummary)
                        aggregateCaseDivContent = this.RenderPartialView("VetAggregateActionFlexibleForm", aggrSum as VetAggregateActionSummary);

                    var ffSummaryData = new { divId = divName, divContent = aggregateCaseDivContent };
                    return ffSummaryData;
                }, ModelUserContext.ClientID, idfAggrCase, null);
        }

        private List<long> GetObservarionsList(string observationFieldName, long idfAggrCase)
        {
            //var aggrSum = ModelStorage.Get(ModelUserContext.ClientID, idfAggrCase, null);
            return ObjectStorage.Using<IObject, List<long>>(aggrSum =>
                {
                    var observations = new List<long>();
                    if (aggrSum is HumanAggregateCaseSummary && (aggrSum as HumanAggregateCaseSummary).AggregateCaseListItems.Count > 0)
                        observations = (aggrSum as HumanAggregateCaseSummary).AggregateCaseListItems.Where(i => !i.IsMarkedToDelete).Select(item => (long)item.GetValue(observationFieldName)).ToList();
                    if (aggrSum is VetAggregateCaseSummary && (aggrSum as VetAggregateCaseSummary).AggregateCaseListItems.Count > 0)
                        observations = (aggrSum as VetAggregateCaseSummary).AggregateCaseListItems.Where(i => !i.IsMarkedToDelete).Select(item => (long)item.GetValue(observationFieldName)).ToList();
                    if (aggrSum is VetAggregateActionSummary && (aggrSum as VetAggregateActionSummary).AggregateCaseListItems.Count > 0)
                        observations = (aggrSum as VetAggregateActionSummary).AggregateCaseListItems.Where(i => !i.IsMarkedToDelete).Select(item => (long)item.GetValue(observationFieldName)).ToList();

                    return observations;
                }, ModelUserContext.ClientID, idfAggrCase, null);
        }

        #endregion


        [HttpGet]
        public ActionResult AggregateReport(string reportAreaType, string reportPeriodType, long idfAggrCase)
        {
            byte[] report = GetPdfReport(reportAreaType, reportPeriodType, idfAggrCase);
            return ReportResponse(report, "AggregateReport.pdf");
        }

        private static StatisticAreaType ConvertStringToStatisticAreaType(string value)
        {
            StatisticAreaType result = (bv.common.Core.Utils.IsEmpty(value)) ? StatisticAreaType.None : (StatisticAreaType)Int64.Parse(value);
            return result;
        }

        private static StatisticPeriodType ConvertStringToStatisticPeriodType(string value)
        {
            StatisticPeriodType result = (bv.common.Core.Utils.IsEmpty(value)) ? StatisticPeriodType.None : (StatisticPeriodType)Int64.Parse(value);
            return result;
        }

        private int GetGridRowsCount(long idfAggrCase)
        {
            //var aggrSum = ModelStorage.Get(ModelUserContext.ClientID, idfAggrCase, null);
            return ObjectStorage.Using<IObject, int>(aggrSum =>
                {
                    if (aggrSum is HumanAggregateCaseSummary)
                        return (aggrSum as HumanAggregateCaseSummary).AggregateCaseListItems.Count(c => !c.IsMarkedToDelete);
                    if (aggrSum is VetAggregateCaseSummary)
                        return (aggrSum as VetAggregateCaseSummary).AggregateCaseListItems.Count(c => !c.IsMarkedToDelete);
                    if (aggrSum is VetAggregateActionSummary)
                        return (aggrSum as VetAggregateActionSummary).AggregateCaseListItems.Count(c => !c.IsMarkedToDelete);
                    return 0;
                }, ModelUserContext.ClientID, idfAggrCase, null);
        }

        private List<IObject> GetGridRows(long idfAggrCase)
        {
            //var aggrSum = ModelStorage.Get(ModelUserContext.ClientID, idfAggrCase, null);
            return ObjectStorage.Using<IObject, List<IObject>>(aggrSum =>
                {
                    if (aggrSum is HumanAggregateCaseSummary)
                        return (aggrSum as HumanAggregateCaseSummary).AggregateCaseListItems.Where(c => !c.IsMarkedToDelete).Cast<IObject>().ToList();
                    if (aggrSum is VetAggregateCaseSummary)
                        return (aggrSum as VetAggregateCaseSummary).AggregateCaseListItems.Where(c => !c.IsMarkedToDelete).Cast<IObject>().ToList();
                    if (aggrSum is VetAggregateActionSummary)
                        return (aggrSum as VetAggregateActionSummary).AggregateCaseListItems.Where(c => !c.IsMarkedToDelete).Cast<IObject>().ToList();
                    return new List<IObject>();
                }, ModelUserContext.ClientID, idfAggrCase, null);
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

        private string GetCurrentParametersXML(StatisticAreaType reportAreaType, StatisticPeriodType reportPeriodType, long idfAggrCase)
        {
            //int gridRowsCount = GetGridRowsCount(idfAggrCase);
            //if (gridRowsCount > 0)
            //{
                XmlNode adminNode = null;
                XmlNode timeIntervalNode = null;
                XmlDocument xmlDocument = InitXml(reportAreaType.ToString(), reportPeriodType.ToString(), ref adminNode, ref timeIntervalNode);
                IEnumerable<IObject> areas = GetGridRows(idfAggrCase).Distinct(new AreaComparer(reportAreaType));
                foreach (IObject area in areas)
                {
                    AddAdminUnitNode(xmlDocument, adminNode, GetAdminUnit(area, reportAreaType));
                }
                IEnumerable<IObject> periods = GetGridRows(idfAggrCase).Distinct(new PeriodComparer());
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
            //}

            //return null;
        }

        private byte[] GetPdfReport(string reportAreaType, string reportPeriodType, long idfAggrCase)
        {
            StatisticAreaType areaType = ConvertStringToStatisticAreaType(reportAreaType);
            StatisticPeriodType periodType = ConvertStringToStatisticPeriodType(reportPeriodType);
            string parametersXml = GetCurrentParametersXML(areaType, periodType, idfAggrCase);


            //var aggrSum = ModelStorage.Get(ModelUserContext.ClientID, idfAggrCase, null);
            return ObjectStorage.Using<IObject, byte[]>(aggrSum =>
                {
                    byte[] report = null;
                    if (aggrSum is HumanAggregateCaseSummary)
                    {
                        List<long> humanObservations = GetObservarionsList("idfCaseObservation", idfAggrCase);
                        if (humanObservations.Count > 0)
                        {
                            using (var wrapper = new ReportClientWrapper())
                            {
                                var model = new AggregateSummaryModel(ModelUserContext.CurrentLanguage, parametersXml,
                                    humanObservations,
                                    ModelUserContext.Instance.IsArchiveMode);
                                report = wrapper.Client.ExportHumAggregateCaseSummary(model);
                            }
                        }
                    }
                    else if (aggrSum is VetAggregateCaseSummary)
                    {
                        List<long> observations = GetObservarionsList("idfCaseObservation", idfAggrCase);
                        if (observations.Count > 0)
                        {
                            using (var wrapper = new ReportClientWrapper())
                            {
                                var model = new AggregateSummaryModel(ModelUserContext.CurrentLanguage, parametersXml,
                                    observations, ModelUserContext.Instance.IsArchiveMode);
                                report = wrapper.Client.ExportVetAggregateCaseSummary(model);
                            }
                        }
                    }
                    else if (aggrSum is VetAggregateActionSummary)
                    {
                        report = GetVetAggregateActionReport(ModelUserContext.CurrentLanguage, parametersXml, idfAggrCase);
                    }

                    return report;
                }, ModelUserContext.ClientID, idfAggrCase, null);
        }

        private byte[] GetVetAggregateActionReport(string language, string parametersXml, long idfAggrCase)
        {
            List<long> diagnosticObservations = GetObservarionsList("idfDiagnosticObservation", idfAggrCase);
            List<long> prophylacticObservations = GetObservarionsList("idfProphylacticObservation", idfAggrCase);
            List<long> sanitaryObservations = GetObservarionsList("idfSanitaryObservation", idfAggrCase);
            Dictionary<string, string> labels = GetLabelsForVetAggregateActionTab(language);
            byte[] report = null;
            if (diagnosticObservations.Count > 0 && prophylacticObservations.Count > 0 && sanitaryObservations.Count > 0)
            {
                using (var wrapper = new ReportClientWrapper())
                {
                    var aggrParams = new AggregateActionsSummaryModel(ModelUserContext.CurrentLanguage,
                        parametersXml,
                        diagnosticObservations,
                        prophylacticObservations,
                        sanitaryObservations,
                        labels,
                        ModelUserContext.Instance.IsArchiveMode);
                    report = wrapper.Client.ExportVetAggregateCaseActionsSummary(aggrParams);
                }
            }
            return report;
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
