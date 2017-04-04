using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Web.Mvc;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Reports;
using eidss.model.Reports.ARM;
using eidss.model.Reports.AZ;
using eidss.model.Reports.Common;
using eidss.model.Reports.GG;
using eidss.model.Reports.IQ;
using eidss.model.Reports.KZ;
using eidss.model.Reports.TH;
using eidss.model.Resources;
using eidss.model.Schema;
using eidss.web.common.Utils;
using eidss.webclient.Models.Reports;
using eidss.webclient.Utils;
using EIDSS.Reports.Parameterized.Human.GG.Report;

namespace eidss.webclient.Controllers
{
    [AuthorizeEIDSS]
    public class ReportController : Controller
    {
        #region Paper Forms

        private string GetFullPathForPaperForm(string reportName)
        {
            string ret = String.Format("/Content/PaperForms/{0}/{1}", ModelUserContext.CurrentLanguage, reportName);
            if (Server != null && !System.IO.File.Exists(Server.MapPath(ret)))
            {
                ret = String.Format("/Content/PaperForms/{0}/{1}", "en", reportName);
            }
            return ret;
        }

        public FileResult AvianDiseaseOutbreaksForm()
        {
            const string reportName = "Investigation Form For Avian Disease Outbreaks.pdf";
            var result = new FilePathResult(GetFullPathForPaperForm(reportName), MediaTypeNames.Application.Octet)
            {
                FileDownloadName = reportName
            };
            return result;
        }

        public FileResult LivestockDiseaseOutbreaksForm()
        {
            const string reportName = "Investigation Form For Livestock Disease Outbreaks.pdf";
            var result = new FilePathResult(GetFullPathForPaperForm(reportName), MediaTypeNames.Application.Octet)
            {
                FileDownloadName = reportName
            };
            return result;
        }

        public FileResult GeneralCaseInvestigationForm()
        {
            string reportName = EidssSiteContext.Instance.IsIraqCustomization && ModelUserContext.CurrentLanguage == Localizer.lngEn
                ? "General Case Investigation Form IQ.pdf"
                : "General Case Investigation Form.pdf";
            var result = new FilePathResult(GetFullPathForPaperForm(reportName), MediaTypeNames.Application.Octet)
            {
                FileDownloadName = reportName
            };
            return result;
        }

        #endregion

        #region Print Barcodes

        public ActionResult PrintBarcodes()
        {
            ViewBag.GetReportActionName = "ShowPrintBarcodes";
            ViewBag.Title = EidssMenu.Instance.GetString("MenuUniversalBarcodes");

            return View("Common/PrintBarcodes", new PrintBarcodesModel());
        }

        public ActionResult ShowPrintBarcodes(PrintBarcodesModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                model.InitContextProperties();
                byte[] report = wrapper.Client.ExportNewBarcodes(model.BarcodeType, model.Quantity);
                resultParameters = new ReportResultParameters(report, "PrintBarcodes",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        #endregion

        #region Common Human Reports

        public ActionResult HumDiagnosisToChangedDiagnosis()
        {
            ViewBag.GetReportActionName = "ShowHumDiagnosisToChangedDiagnosis";
            ViewBag.Title = EidssMenu.Instance.GetString("ReportsHumDiagnosisToChangedDiagnosis");
            ViewBag.ArrayForRename = new List<string> { "InitialDiagnoses.CheckedItems", "FinalDiagnoses.CheckedItems" };

            var address = new AddressModel(FilterHelper.GetDefaultRegion(), FilterHelper.GetDefaultRayon()) { IsSettlementVisible = true };
            return View("Common/DToChangedD",
                new DToChangedDModel
                {
                    Address = address,
                    FinalDiagnoses = { AddSelectAllItem = true },
                    InitialDiagnoses = { AddSelectAllItem = true }
                });
        }

        public ActionResult ShowHumDiagnosisToChangedDiagnosis(DToChangedDModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                DToChangedDSurrogateModel surrogateModel;
                using (model.CreateCurrentCultureInfoTransaction())
                {
                    model.InitContextProperties();
                    model.Address.ResetAddressLookup();
                    SetCheckedItems(model.InitialDiagnosesList, model.InitialDiagnoses);
                    SetCheckedItems(model.FinalDiagnosesList, model.FinalDiagnoses);
                    surrogateModel = (DToChangedDSurrogateModel)model;
                }
                byte[] report = wrapper.Client.ExportHumDiagnosisToChangedDiagnosis(surrogateModel);
                resultParameters = new ReportResultParameters(report, "Concordance_of_Initial_and_Final_Diagnosis",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        public ActionResult HumMonthlyMorbidityAndMortality()
        {
            ViewBag.GetReportActionName = "ShowHumMonthlyMorbidityAndMortality";
            ViewBag.Title = EidssMenu.Instance.GetString("ReportsHumMonthlyMorbidityAndMortality");
            var model = new BaseThaiDateModel
            {
                CanWorkWithArchive = false,
                Language = ModelUserContext.CurrentLanguage
            };
            if (model.Language == Localizer.lngThai)
            {
                model.Year = ThaiCalendarHelper.GregorianYearToThai(model.Year);
            }

            return View("Common/BaseDate", model);
        }

        public ActionResult ShowHumMonthlyMorbidityAndMortality(BaseDateModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                model.InitContextProperties();
                if (model.Language == Localizer.lngThai)
                {
                    model.Year = ThaiCalendarHelper.ThaiYearToGregorian(model.Year);
                }

                byte[] report = wrapper.Client.ExportHumMonthlyMorbidityAndMortality(model);
                resultParameters = new ReportResultParameters(report, "Human_Monthly_Morbidity_And_Mortality",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        #endregion

        #region AZ Human Reports

        public JsonResult GetRayons(AddressModel model)
        {
            object jsonData = (model.RegionId.HasValue && model.RegionId.Value > 0)
                ? new SelectList(model.GetRayons(), "Value", "Text")
                : (object)string.Empty;

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTransportCHERayons(TransportCHEModel model)
        {
            object jsonData = (model.RegionId.HasValue && model.RegionId.Value > 0)
                ? new SelectList(model.GetRayons(), "Value", "Text")
                : (object)string.Empty;

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetWeeks(int year)
        {
            var model = new WeeksModel();
            object jsonData = (year > 0)
                ? new SelectList(model.GetWeeksList(year), "Value", "Text")
                : (object)string.Empty;

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetRayonsList(AddressMultiselectModel model)
        {
            object jsonData = !bv.common.Core.Utils.IsEmpty(model.RegionsSelected)
                ? new SelectList(model.GetRayons(model.RegionsSelected), "Value", "Text")
                : (object)string.Empty;

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSettlements(AddressModel model)
        {
            object jsonData = (model.RayonId.HasValue && model.RayonId.Value > 0)
                ? new SelectList(model.GetSettlements(), "Value", "Text")
                : (object)string.Empty;

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult HumFormN1A3()
        {
            return HumFormN1(true);
        }

        public ActionResult HumFormN1A4()
        {
            return HumFormN1(false);
        }

        public ActionResult HumFormN1(bool isA3Format)
        {
            ViewBag.GetReportActionName = "ShowHumFormN1";
            ViewBag.Title = EidssMenu.Instance.GetString("HumFormN1");
            var model = new FormNo1Model(FilterHelper.GetDefaultRegion(), FilterHelper.GetDefaultRayon())
            {
                PageSize = isA3Format
                    ? FilterHelper.PageSizeA3
                    : FilterHelper.PageSizeA4
            };
            return View("AZ/FormNo1", model);
        }

        public ActionResult ShowHumFormN1A3(FormNo1Model model)
        {
            return ShowHumFormN1(model);
        }

        public ActionResult ShowHumFormN1A4(FormNo1Model model)
        {
            return ShowHumFormN1(model);
        }

        public ActionResult ShowHumFormN1(FormNo1Model model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                FormNo1SurrogateModel surrogateModel;
                using (model.CreateCurrentCultureInfoTransaction())
                {
                    model.InitContextProperties();
                    model.Address.ResetAddressLookup();
                    surrogateModel = (FormNo1SurrogateModel)model;
                }
                byte[] report = wrapper.Client.ExportHumFormN1(surrogateModel);
                resultParameters = new ReportResultParameters(report, "Human_Form_No_1",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        public ActionResult HumDataQualityIndicators()
        {
            ViewBag.GetReportActionName = "ShowDataQualityIndicators";
            ViewBag.Title = EidssMenu.Instance.GetString("HumDataQualityIndicators");
            return View("AZ/DataQualityIndicators",
                new DataQualityIndicatorsModel
                {
                    CanWorkWithArchive = false,
                    ShowRayonFilter = true,
                    StartMonth = DateTime.Today.Month,
                    EndMonth = DateTime.Today.Month
                });
        }

        public ActionResult ShowDataQualityIndicators(DataQualityIndicatorsModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                DataQualityIndicatorsSurrogateModel surrogateModel;
                using (model.CreateCurrentCultureInfoTransaction())
                {
                    model.InitContextProperties();
                    SetDiagnosisCheckedItems(model);
                    surrogateModel = (DataQualityIndicatorsSurrogateModel)model;
                }

                byte[] report = wrapper.Client.ExportHumDataQualityIndicators(surrogateModel);
                resultParameters = new ReportResultParameters(report, "Human_Data_Quality_Indicators",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        public ActionResult HumDataQualityIndicatorsRayons()
        {
            ViewBag.GetReportActionName = "ShowDataQualityIndicatorsRayons";
            ViewBag.Title = EidssMenu.Instance.GetString("HumDataQualityIndicatorsRayons");
            return View("AZ/DataQualityIndicators",
                new DataQualityIndicatorsModel
                {
                    CanWorkWithArchive = false,
                    StartMonth = DateTime.Today.Month,
                    EndMonth = DateTime.Today.Month
                });
        }

        public ActionResult ShowDataQualityIndicatorsRayons(DataQualityIndicatorsModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                DataQualityIndicatorsSurrogateModel surrogateModel;
                using (model.CreateCurrentCultureInfoTransaction())
                {
                    model.InitContextProperties();
                    SetDiagnosisCheckedItems(model);
                    surrogateModel = (DataQualityIndicatorsSurrogateModel)model;
                }

                byte[] report = wrapper.Client.ExportHumDataQualityIndicatorsRayons(surrogateModel);
                resultParameters = new ReportResultParameters(report, "Human_Data_Quality_Indicators",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        private static void SetDiagnosisCheckedItems(DataQualityIndicatorsModel model)
        {
            if (!bv.common.Core.Utils.IsEmpty(model.MultipleDiagnosisFilter_CheckedItems))
            {
                model.MultipleDiagnosisFilter.CheckedItems =
                    model.MultipleDiagnosisFilter_CheckedItems.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            }
        }

        public ActionResult HumSummaryByRayonDiagnosisAgeGroups()
        {
            ViewBag.GetReportActionName = "ShowHumSummaryByRayonDiagnosisAgeGroups";
            ViewBag.Title = EidssMenu.Instance.GetString("HumSummaryByRayonDiagnosisAgeGroups");
            ViewBag.MaxCheckedCount = SummaryByRayonDiagnosisModel.HumMaxDiagnosisCount;
            return View("AZ/SummaryByRayonDiagnosis", new SummaryByRayonDiagnosisModel(null) { CanWorkWithArchive = false });
        }

        public ActionResult ShowHumSummaryByRayonDiagnosisAgeGroups(SummaryByRayonDiagnosisModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                model.InitContextProperties();
                if (!bv.common.Core.Utils.IsEmpty(model.MultipleDiagnosisFilter_CheckedItems))
                {
                    model.MultipleDiagnosisFilter.CheckedItems =
                        model.MultipleDiagnosisFilter_CheckedItems.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                }
                byte[] report = wrapper.Client.ExportHumSummaryByRayonDiagnosisAgeGroups(model);
                resultParameters = new ReportResultParameters(report, "Human_Summary_By_Rayon_Diagnosis_Age_Groups",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        public ActionResult HumComparativeAZReport()
        {
            ViewBag.GetReportActionName = "ShowHumComparativeAZReport";
            ViewBag.Title = EidssMenu.Instance.GetString("HumComparativeReport");
            var address = new AddressModel(FilterHelper.GetDefaultRegion(), FilterHelper.GetDefaultRayon());
            return View("AZ/Comparative", new ComparativeModel { Address1 = address });
        }

        public ActionResult ShowHumComparativeAZReport(ComparativeModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                ComparativeSurrogateModel surrogateModel;
                using (model.CreateCurrentCultureInfoTransaction())
                {
                    model.InitContextProperties();
                    model.Address1.ResetAddressLookup();
                    model.Address2.ResetAddressLookup();
                    surrogateModel = (ComparativeSurrogateModel)model;
                }

                byte[] report = wrapper.Client.ExportHumComparativeAZReport(surrogateModel);
                resultParameters = new ReportResultParameters(report, "Human_Comparative_Report",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        public ActionResult HumExternalComparativeReport()
        {
            ViewBag.GetReportActionName = "ShowHumExternalComparativeReport";
            ViewBag.Title = EidssMenu.Instance.GetString("HumExternalComparativeReport");
            var address = new TransportCHEModel(FilterHelper.GetDefaultRegion(true), FilterHelper.GetDefaultRayon(true));
            return View("AZ/ExternalComparative", new ExternalComparativeModel(address));
        }

        public ActionResult ShowHumExternalComparativeReport(ExternalComparativeModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                ExternalComparativeSurrogateModel surrogateModel;
                using (model.CreateCurrentCultureInfoTransaction())
                {
                    model.InitContextProperties();
                    model.Address.ResetAddressLookup();
                    surrogateModel = (ExternalComparativeSurrogateModel)model;
                }
                byte[] report = wrapper.Client.ExportHumExternalComparativeReport(surrogateModel);
                resultParameters = new ReportResultParameters(report, "Human_External_Comparative_Report",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        public ActionResult HumMainIndicatorsOfAFPSurveillance()
        {
            ViewBag.GetReportActionName = "ShowHumMainIndicatorsOfAFPSurveillance";
            ViewBag.Title = EidssMenu.Instance.GetString("HumMainIndicatorsOfAFPSurveillance");
            return View("AZ/AFPSurveillance", new AFPModel());
        }

        public ActionResult ShowHumMainIndicatorsOfAFPSurveillance(AFPModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                model.InitContextProperties();
                byte[] report = wrapper.Client.ExportHumMainIndicatorsOfAFPSurveillance(model);
                resultParameters = new ReportResultParameters(report, "Human_Main_Indicators_Of_AFP_Surveillance",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        public ActionResult HumAdditionalIndicatorsOfAFPSurveillance()
        {
            ViewBag.GetReportActionName = "ShowHumAdditionalIndicatorsOfAFPSurveillance";
            ViewBag.Title = EidssMenu.Instance.GetString("HumAdditionalIndicatorsOfAFPSurveillance");
            return View("AZ/AFPSurveillance", new AFPModel());
        }

        public ActionResult ShowHumAdditionalIndicatorsOfAFPSurveillance(AFPModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                model.InitContextProperties();
                byte[] report = wrapper.Client.ExportHumAdditionalIndicatorsOfAFPSurveillance(model);
                resultParameters = new ReportResultParameters(report, "Human_Additional_Indicators_Of_AFP_Surveillance",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        public JsonResult GetReportingPeriodList(AFPModel model)
        {
            List<SelectListItem> list = model.PeriodList.ConvertToSelectListItem().ToList();
            object jsonData = (list.Count > 0)
                ? new SelectList(list, "Value", "Text")
                : (object)string.Empty;
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetQuartersList(BaseYearQuarterModel model)
        {
            List<SelectListItem> list = model.GetQuarters().ConvertToSelectListItem().ToList();
            object jsonData = (list.Count > 0)
                ? new SelectList(list, "Value", "Text")
                : (object)string.Empty;
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetMonthList(VersionedDateModel model)
        {
            List<SelectListItem> list = model.SelectedMonthList.ConvertToSelectListItem().ToList();
            object jsonData = (list.Count > 0)
                ? new SelectList(list, "Value", "Text")
                : (object)string.Empty;
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult HumWhoMeaslesRubellaReport()
        {
            ViewBag.GetReportActionName = "ShowHumWhoMeaslesRubellaReport";
            ViewBag.Title = EidssMenu.Instance.GetString("HumWhoMeaslesRubellaReport");
            //return View("Common/BaseDate", new WhoMeaslesRubellaModel());
            return View("AZ/HumWhoMeaslesRubellaReport", new WhoMeaslesRubellaModel());
        }

        public ActionResult ShowHumWhoMeaslesRubellaReport(WhoMeaslesRubellaModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                model.InitContextProperties();
                byte[] report = wrapper.Client.ExportHumWhoMeaslesRubellaReport(model);
                resultParameters = new ReportResultParameters(report, "Human_Measles_Rubella_Report",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        public ActionResult HumComparativeReportOfTwoYears()
        {
            ViewBag.GetReportActionName = "ShowHumComparativeReportOfTwoYears";
            ViewBag.Title = EidssMenu.Instance.GetString("HumComparativeReportOfTwoYears");
            var address = new TransportCHEModel(FilterHelper.GetDefaultRegion(true), FilterHelper.GetDefaultRayon(true));
            var model = new ComparativeTwoYearsModel
            {
                Address = address,
                YearModel = { YearsCaptionsSpecial = true }
            };
            int thisYear = DateTime.Now.Year;
            int lastYear = thisYear - 1;
            model.YearModel.SetYearsIntervalFrom(2000, lastYear, lastYear);
            model.YearModel.SetYearsIntervalTo(2001, thisYear, thisYear);
            return View("AZ/ComparativeTwoYears", model);
        }
        private static void SetCounterCheckedItems(ComparativeTwoYearsModel model)
        {
            if (!bv.common.Core.Utils.IsEmpty(model.MultipleCounterFilter_CheckedItems))
            {
                model.Counter.CheckedItems =
                    model.MultipleCounterFilter_CheckedItems.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            }
        }

        public ActionResult ShowHumComparativeReportOfTwoYears(ComparativeTwoYearsModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                ComparativeTwoYearsSurrogateModel surrogateModel;
                using (model.CreateCurrentCultureInfoTransaction())
                {
                    model.InitContextProperties();
                    SetCounterCheckedItems(model);
                    surrogateModel = (ComparativeTwoYearsSurrogateModel)model;
                }
                if (surrogateModel.DiagnosisId.HasValue && surrogateModel.DiagnosisId.Value == 0)
                {
                    surrogateModel.DiagnosisId = null;
                }
                var report = wrapper.Client.ExportHumComparativeReportOfTwoYears(surrogateModel);
                resultParameters = new ReportResultParameters(report, "Human_Comparative_Report_of_Two_years",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        /// <summary>
        ///     Custom validation operations
        /// </summary>
        public JsonResult Validate(FormCollection collection)
        {
            var isSuccessValue = true;
            var messageText = string.Empty;

            var reportName = collection["ReportName"];
            if (reportName == "BorderRayons")
            {
                var dl = collection["BorderRayonsModelDiagOrGroup"];
                var cnt = dl.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                if (cnt.Length > 12)
                {
                    messageText = EidssMessages.Get("msgTooManyDiagnosis12");
                    isSuccessValue = false;
                }
            }
            if (reportName == "DataQuality")
            {
                //TODO add validation for data quality indicators report diagnoses/groups
            }
            else if (reportName == "Tuberculosis")
            {
                var dl = collection["MultipleYearsFilterCheckedItems"];
                var cnt = dl.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                if (cnt.Length > TuberculosisSurrogateModel.MaxYearsCount)
                {
                    messageText = string.Format(EidssMessages.Get("msgTooManyYears"), TuberculosisSurrogateModel.MaxYearsCount);
                }
            }

            return new JsonResult
            {
                Data = new
                {
                    isSuccess = isSuccessValue,
                    message = messageText
                },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public ActionResult HumBorderRayonsComparativeReport()
        {
            ViewBag.GetReportActionName = "ShowHumBorderRayonsComparativeReport";
            ViewBag.Title = EidssMenu.Instance.GetString("HumBorderRayonsComparativeReport");
            var address = new AddressModel(FilterHelper.GetDefaultRegion(), FilterHelper.GetDefaultRayon()) { IsRequired = true };
            var model = new BorderRayonsModel { Address = address };
            model.LoadDiagnosesList();
            ObjectStorage.Put(ModelUserContext.ClientID, (long)model.Key, (long)model.Key, null, model);
            return View("AZ/BorderRayonsComparative", model);
        }

        public ActionResult SelectDiagOrGroup(long id, string keyname, string valuename)
        {
            //TODO We could create an interface IDiagOrGroup instead BorderRayonsModel 
            return ObjectStorage.Using<BorderRayonsModel, ActionResult>(o =>
            {
                return Json(o.DiagOrGroupLookup.Where(c => c.idfsDiagnosisOrDiagnosisGroup != 0).Select(c => new
                {
                    Value = c.GetValue(keyname),
                    Text = c.GetValue(valuename),
                    IsChecked = o.DiagOrGroupSelected != null && o.DiagOrGroupSelected.Contains(c.idfsDiagnosisOrDiagnosisGroup),
                    group =
                        c.blnGroup.HasValue && c.blnGroup.Value
                            ? ""
                            : (c.idfsDiagnosisGroup.HasValue && c.idfsDiagnosisGroup.Value != 0 ? c.idfsDiagnosisGroup.Value.ToString() : ""),
                    classname =
                        c.blnGroup.HasValue && c.blnGroup.Value
                            ? "clsGroup"
                            : (c.idfsDiagnosisGroup.HasValue && c.idfsDiagnosisGroup.Value > 0 ? "clsItemInGroup" : "clsItemAsGroup")
                }), JsonRequestBehavior.AllowGet);
            }, ModelUserContext.ClientID, id, null);
        }

        private static void SetCounterCheckedItems(BorderRayonsModel model)
        {
            if (!bv.common.Core.Utils.IsEmpty(model.MultipleCounterFilter_CheckedItems))
            {
                model.Counter.CheckedItems =
                    model.MultipleCounterFilter_CheckedItems.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            }
        }

        public ActionResult ShowHumBorderRayonsComparativeReport(BorderRayonsModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                BorderRayonsSurrogateModel surrogateModel;

                using (model.CreateCurrentCultureInfoTransaction())
                {
                    model.InitContextProperties();
                    model.Address.ResetAddressLookup();
                    SetCheckedItems(model.BorderRayonsModelDiagOrGroup, model.MultipleDiagnosisFilter);
                    SetCounterCheckedItems(model);
                    surrogateModel = (BorderRayonsSurrogateModel)model;
                }
                byte[] report = wrapper.Client.ExportHumBorderRayonsComparativeReport(surrogateModel);
                resultParameters = new ReportResultParameters(report, "Human_Border_Rayons_Comparative",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        public ActionResult HumTuberculosisCasesTested()
        {
            ViewBag.GetReportActionName = "ShowHumTuberculosisCasesTested";
            ViewBag.Title = EidssMenu.Instance.GetString("HumTuberculosisCasesTested");

            var currentYear = DateTime.Now.Year;
            var model = new TuberculosisModel
            {
                MultipleYears = new MultipleYearsModel(currentYear) { CheckedItems = new[] { currentYear.ToString() }, IsRequired = true },
                StartMonth = DateTime.Now.Month,
                EndMonth = DateTime.Now.Month,
            };
            ViewBag.checkedIds = string.Join(",", model.MultipleYears.CheckedItems);
            return View("AZ/TuberculosisCasesTested", model);
        }

        public ActionResult ShowHumTuberculosisCasesTested(TuberculosisModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                TuberculosisSurrogateModel surrogateModel;
                using (model.CreateCurrentCultureInfoTransaction())
                {
                    model.InitContextProperties();
                    surrogateModel = (TuberculosisSurrogateModel)model;
                }
                if (surrogateModel.DiagnosisId.HasValue && surrogateModel.DiagnosisId.Value == 0)
                {
                    surrogateModel.DiagnosisId = null;
                }
                var report = wrapper.Client.ExportHumTuberculosisCasesTested(surrogateModel);
                resultParameters = new ReportResultParameters(report, "Human_Tuberculosis_Cases_Tested",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }
            return PrepareReportResult(resultParameters);
        }

        #endregion

        #region AZ Zoonotic Reports
        public ActionResult SimplifiedComparativeAZ()
        {
            return ZoonoticComparativeAZ();
        }

        public ActionResult ZoonoticComparativeAZ()
        {
            ViewBag.GetReportActionName = "ShowZoonoticComparativeAZ";
            ViewBag.Title = EidssMenu.Instance.GetString("ZoonoticComparativeAZ");

            var address = new AddressModel(FilterHelper.GetDefaultRegion(), FilterHelper.GetDefaultRayon());
            var model = new ZoonoticModel { Address = address };
            return View("AZ/ZoonoticComparativeAZ", model);
        }


        public ActionResult ShowZoonoticComparativeAZ(ZoonoticModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                ZoonoticSurrogateModel surrogateModel;
                using (model.CreateCurrentCultureInfoTransaction())
                {
                    model.InitContextProperties();
                    surrogateModel = (ZoonoticSurrogateModel)model;
                }
                if (surrogateModel.DiagnosisId.HasValue && surrogateModel.DiagnosisId.Value == 0)
                {
                    surrogateModel.DiagnosisId = null;
                }
                var report = wrapper.Client.ExportZoonoticComparativeAZ(surrogateModel);
                resultParameters = new ReportResultParameters(report, "Human_Zoonotic_Comparative_Report",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }
            return PrepareReportResult(resultParameters);
        }
        public ActionResult SelectZoonoticDiagnosisOrDiagnosisGroup()
        {
            var list = FilterHelper.GetZoonoticDiagnosisOrGroupList(Localizer.CurrentCultureLanguageID, true);
            return Json(list.Select(c => new
            {
                c.Value,
                c.Text,
                c.ClassName
            }), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region AZ Vet Reports

        public ActionResult VeterinaryCasesReportAZ()
        {
            ViewBag.GetReportActionName = "ShowVeterinaryCasesReportAZ";
            ViewBag.Title = EidssMenu.Instance.GetString("VeterinaryCasesReport");
            var address = new TransportCHEModel(FilterHelper.GetDefaultRegion(), FilterHelper.GetDefaultRayon(), false);
            var model = new VetCasesModel
            {
                Address = address,
                StartYear = DateTime.Now.Year,
                StartMonth = DateTime.Now.Month,
                EndYear = DateTime.Now.Year,
                EndMonth = DateTime.Now.Month,
            };
            return View("AZ/VetCase", model);
        }

        public ActionResult ShowVeterinaryCasesReportAZ(VetCasesModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                VetCasesSurrogateModel surrogateModel;

                using (model.CreateCurrentCultureInfoTransaction())
                {
                    model.InitContextProperties();
                    model.Address.ResetAddressLookup();
                    surrogateModel = (VetCasesSurrogateModel)model;
                }

                byte[] report = wrapper.Client.ExportVeterinaryCasesReport(surrogateModel);
                resultParameters = new ReportResultParameters(report, "Veterinary_Cases_Report",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        public ActionResult VeterinaryLaboratoriesAZ()
        {
            ViewBag.GetReportActionName = "ShowVeterinaryLaboratoriesAZ";
            ViewBag.Title = EidssMenu.Instance.GetString("VeterinaryLaboratoriesAZ");
            var address = new AddressModel(FilterHelper.GetDefaultRegion(), FilterHelper.GetDefaultRayon());
            var model = new VetLabModel
            {
                Address = address,
                Year = DateTime.Now.Year,
            };
            return View("AZ/VetLab", model);
        }

        public ActionResult ShowVeterinaryLaboratoriesAZ(VetLabModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                VetLabSurrogateModel surrogateModel;
                using (model.CreateCurrentCultureInfoTransaction())
                {
                    model.InitContextProperties();
                    model.Address.ResetAddressLookup();
                    surrogateModel = (VetLabSurrogateModel)model;
                }
                byte[] report = wrapper.Client.ExportVeterinaryLaboratoriesAZReport(surrogateModel);
                resultParameters = new ReportResultParameters(report, "Veterinary_Laboratories_Report",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        public ActionResult VeterinaryFormVet(string reportBaseId)
        {
            ViewBag.GetReportActionName = string.Format("Show{0}", reportBaseId);
            ViewBag.Title = EidssMenu.Instance.GetString(reportBaseId);
            var address = new TransportCHEModel(FilterHelper.GetDefaultRegion(), FilterHelper.GetDefaultRayon(), false);
            var model = new VetCasesModel
            {
                Address = address,
                StartYear = DateTime.Now.Year,
                StartMonth = DateTime.Now.Month,
                EndYear = DateTime.Now.Year,
                EndMonth = DateTime.Now.Month,
            };
            return View("AZ/VetCase", model);
        }

        public ActionResult VeterinaryFormVet1()
        {
            return VeterinaryFormVet("VeterinaryFormVet1");
        }

        public ActionResult VeterinaryFormVet1A()
        {
            return VeterinaryFormVet("VeterinaryFormVet1A");
        }

        public ActionResult ShowVeterinaryFormVet1(VetCasesModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                model.InitContextProperties();
                byte[] report = wrapper.Client.ExportVeterinaryFormVet1((VetCasesSurrogateModel)model);
                resultParameters = new ReportResultParameters(report, "VeterinaryFormVet1",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        public ActionResult ShowVeterinaryFormVet1A(VetCasesModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                model.InitContextProperties();
                byte[] report = wrapper.Client.ExportVeterinaryFormVet1A((VetCasesSurrogateModel)model);
                resultParameters = new ReportResultParameters(report, "VeterinaryFormVet1A",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        public ActionResult VeterinarySummaryAZ()
        {
            ViewBag.GetReportActionName = "ShowVeterinarySummaryAZ";
            ViewBag.Title = EidssMenu.Instance.GetString("VeterinarySummaryAZ");
            ViewBag.MaxCheckedCount = VetSummaryModel.VetMaxSpeciesTypeCount;
            return View("AZ/VetSummary", new VetSummaryModel { CanWorkWithArchive = true });
        }

        public ActionResult ShowVeterinarySummaryAZ(VetSummaryModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                using (model.CreateCurrentCultureInfoTransaction())
                {
                    model.InitContextProperties();
                    SetSpeciesTypeCheckedItems(model);
                }

                byte[] report = wrapper.Client.ExportVeterinarySummaryAZ(model);
                resultParameters = new ReportResultParameters(report, "Veterinary_Summary_Report",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        private static void SetSpeciesTypeCheckedItems(VetSummaryModel model)
        {
            if (!bv.common.Core.Utils.IsEmpty(model.SpeciesType_CheckedItems))
            {
                model.CheckedItems =
                    model.SpeciesType_CheckedItems.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            }
        }

        public JsonResult VetSummarySetSurveillanceType(VetSummaryModel model, string type)
        {
            if (type == "passive")
                model.SurveillanceType = VetSummarySurveillanceType.PassiveSurveillanceIndex;
            else if (type == "action")
                model.SurveillanceType = VetSummarySurveillanceType.AggregateActionsIndex;
            else
                model.SurveillanceType = VetSummarySurveillanceType.ActiveSurveillanceIndex;

            return new JsonResult
            {
                Data = new
                {
                    diagnosisList = model.DiagnosisList,
                },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };

        }
        public JsonResult GetVetSummarySpecies(VetSummaryModel model)
        {
            HACode accessory = HACode.None;
            using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                var d = DiagnosisLookup.Accessor.Instance(null).SelectLookupList(manager)
                    .FirstOrDefault(c => c.idfsDiagnosis == model.DiagnosisId);

                if (d != null)
                {
                    accessory = (HACode)(d.intHACode??0);
                }
            }

            return new JsonResult
            {
                Data = new
                {
                    data = FilterHelper.GetSpeciesTypes(accessory),
                },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };

        }

        #endregion

        #region AZ Lab Reports

        public ActionResult LabTestingResultsAZ()
        {
            ViewBag.GetReportActionName = "ShowLabTestingResultsAZ";
            ViewBag.Title = EidssMenu.Instance.GetString("LabTestingResultsAZ");
            return View("AZ/LabTestingResults", new LabTestingTesultsModel());
        }

        public ActionResult ShowLabTestingResultsAZ(LabTestingTesultsModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                model.InitContextProperties();
                byte[] report = wrapper.Client.ExportLabTestingResultsAZ(model);
                resultParameters = new ReportResultParameters(report, "LabTestResultAZ",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }
        public JsonResult SearchLabSample(LabTestingTesultsModel model)
        {
            var list = model.DepartmentsList;
            object jsonData = string.Empty;
            string msg = null;
            if (list != null && list.Count > 0)
            {
                if (list[0].Value == "-2")
                    msg = "msgReportAzSampleNotFound";
                else if (list[0].Value == "-1")
                    msg = "msgReportAzDepartmentsNotFound";
                else
                    jsonData = new SelectList(list, "Value", "Text");
            }
            return new JsonResult
            {
                Data = new
                {
                    data = jsonData,
                    message = msg
                },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };

        }

        public ActionResult AssignmentLabDiagnosticAZ()
        {
            ViewBag.GetReportActionName = "ShowAssignmentLabDiagnosticAZ";
            ViewBag.Title = EidssMenu.Instance.GetString("AssignmentLabDiagnosticAZ");
            return View("AZ/AssignmentLabDiagnostic", new AssignmentLabDiagnosticModel());
        }

        public ActionResult ShowAssignmentLabDiagnosticAZ(AssignmentLabDiagnosticModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                model.InitContextProperties();
                byte[] report = wrapper.Client.ExportAssignmentLabDiagnosticAZ(model);
                resultParameters = new ReportResultParameters(report, "AssignmentLabDiagnosticAZ",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        public JsonResult ValidateAssignmentLabDiagnostic(AssignmentLabDiagnosticModel model)
        {
            var list = model.SentToList;
            object jsonData = string.Empty;
            string msg =null;
            if (list != null && list.Count > 0)
            {
                if (list[0].Value == "-1")
                    msg = "msgReportAzSamplesNotFound";
                else if (list[0].Value == "-2")
                    msg = "msgReportAzCaseNotFound";
                else
                    jsonData = new SelectList(list, "Value", "Text");
            }
            return new JsonResult
            {
                Data = new
                {
                    data = jsonData,
                    message = msg
                },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };

        }

        #endregion

        #region TH Reports

        public JsonResult GetDistricts(ThaiDistrictModel model)
        {
            object jsonData = (model.ProvinceId.HasValue && model.ProvinceId.Value > 0)
                ? new SelectList(model.GetDistricts(), "Value", "Text")
                : (object)string.Empty;

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult HumComparativeReportOfSeveralYearsTH()
        {
            ViewBag.GetReportActionName = "ShowHumComparativeReportOfSeveralYearsTH";
            ViewBag.Title = EidssMenu.Instance.GetString("HumComparativeReportOfSeveralYearsTH");
            var model = new ComparativeSeveralYearsTHModel();
            return View("TH/ComparativeReportOfSeveralYears", model);
        }

        private static void SetCheckedItems(string checkedValues, BaseMultipleModel model)
        {
            if (!bv.common.Core.Utils.IsEmpty(checkedValues))
            {
                model.CheckedItems =
                    checkedValues.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            }
        }

        public ActionResult ShowHumComparativeReportOfSeveralYearsTH(ComparativeSeveralYearsTHModel model)
        {
            ReportResultParameters resultParameters;
            model.YearModel.Language = model.Language;
            model.District.Language = model.Language;
            using (var wrapper = new ReportClientWrapper())
            {
                ComparativeSeveralYearsTHSurrogateModel surrogateModel;
                using (model.CreateCurrentCultureInfoTransaction())
                {
                    model.InitContextProperties();
                    model.YearModel.InitContextProperties();

                    var provinceId = model.District.ProvinceId;
                    var districtId = model.District.DistrictId;
                    model.District.InitContextProperties();
                    model.District.InitProvinceDistrict();
                    model.District.ProvinceId = provinceId;
                    model.District.DistrictId = districtId;

                    SetCheckedItems(model.MultipleDiagnosisFilter_CheckedItems, model.MultipleDiagnosisFilter);
                    surrogateModel = (ComparativeSeveralYearsTHSurrogateModel)model;
                }
                byte[] report = wrapper.Client.ExportHumComparativeReportOfSeveralYearsTH(surrogateModel);
                resultParameters = new ReportResultParameters(report, "Comparative_Report_Of_Several_Years",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        public ActionResult HumReportedCasesDeathsByProvinceMonthTH()
        {
            ViewBag.GetReportActionName = "ShowHumReportedCasesDeathsByProvinceMonthTH";
            ViewBag.Title = EidssMenu.Instance.GetString("HumReportedCasesDeathsByProvinceMonthTH");

            var model = new NumberOfCasesDeathsMonthTHModel { Diagnoses = { AddSelectAllItem = true } };

            return View("TH/ReportedCasesDeathsByProvinceMonth", model);
        }

        public ActionResult ShowHumReportedCasesDeathsByProvinceMonthTH(NumberOfCasesDeathsMonthTHModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                using (model.CreateCurrentCultureInfoTransaction())
                {
                    model.InitContextProperties();
                    SetCheckedItems(model.Diagnoses_CheckedItems, model.Diagnoses);
                    SetCheckedItems(model.ZoneFilter_CheckedItems, model.Zones);
                    SetCheckedItems(model.RegionFilter_CheckedItems, model.Regions);
                    SetCheckedItems(model.ProvinceFilter_CheckedItems, model.Provinces);
                    if (model.Language == Localizer.lngThai)
                    {
                        model.Year = ThaiCalendarHelper.ThaiYearToGregorian(model.Year);
                    }
                }
                byte[] report = wrapper.Client.ExportHumNumberOfCasesDeathsMonthTH(model);
                resultParameters = new ReportResultParameters(report, "Reported_cases_and_deaths_by_Province_and_by_Month",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        public ActionResult HumNumberOfCasesDeathsMorbidityMortalityTH()
        {
            ViewBag.GetReportActionName = "ShowHumNumberOfCasesDeathsMorbidityMortalityTH";
            ViewBag.Title = EidssMenu.Instance.GetString("HumNumberOfCasesDeathsMorbidityMortalityTH");

            var model = new NumberOfCasesDeathsMorbidityMortalityTHWebModel
            {
                Language = ModelUserContext.CurrentLanguage,
                StartDate = new DateTime(DateTime.Today.Year, 1, 1),
                Diagnoses = { AddSelectAllItem = true }
            };

            if (model.Language == Localizer.lngThai)
            {
                model.StartDate = ThaiCalendarHelper.ThaiDateToGriogorian(model.StartDate);
                model.EndDate = ThaiCalendarHelper.ThaiDateToGriogorian(model.EndDate);
            }
            return View("TH/NumberOfCasesDeathsMorbidityMortality", model);
        }

        public ActionResult ShowHumNumberOfCasesDeathsMorbidityMortalityTH(NumberOfCasesDeathsMorbidityMortalityTHWebModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                var currentLanguage = ModelUserContext.CurrentLanguage;
                //we shall convert dates to gregorian before switching thread culture to report culture
                if (model.Language == Localizer.lngThai && currentLanguage != Localizer.lngThai)
                {
                    model.StartDate = ThaiCalendarHelper.ThaiDateToGriogorian(model.StartDate);
                    model.EndDate = ThaiCalendarHelper.ThaiDateToGriogorian(model.EndDate);
                }
                else if (model.Language != Localizer.lngThai && currentLanguage == Localizer.lngThai)
                {
                    model.StartDate = ThaiCalendarHelper.GregorianDateToThai(model.StartDate);
                    model.EndDate = ThaiCalendarHelper.GregorianDateToThai(model.EndDate);
                }
                NumberOfCasesDeathsMorbidityMortalityTHModel surrogateModel;
                using (model.CreateCurrentCultureInfoTransaction())
                {
                    model.InitContextProperties();
                    SetCheckedItems(model.Diagnoses_CheckedItems, model.Diagnoses);
                    SetCheckedItems(model.ZoneFilter_CheckedItems, model.Zones);
                    SetCheckedItems(model.RegionFilter_CheckedItems, model.Regions);
                    SetCheckedItems(model.ProvinceFilter_CheckedItems, model.Provinces);
                    surrogateModel = model.ConvertToBaseModel();
                }
                byte[] report = wrapper.Client.ExportHumNumberOfCasesDeathsMorbidityMortalityTH(surrogateModel);
                resultParameters = new ReportResultParameters(report,
                    "Number_of_cases_deaths_morbidity_rate_mortality_rate_case_fatality_rate",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        #endregion

        #region ARM Reports

        public ActionResult HumFormN85()
        {
            ViewBag.GetReportActionName = "ShowHumFormN85";
            ViewBag.Title = EidssMenu.Instance.GetString("HumFormN85");
            var model = new FormN85Model(FilterHelper.GetDefaultRegion(), FilterHelper.GetDefaultRayon());
            return View("ARM/FormN85", model);
        }

        public ActionResult ShowHumFormN85(FormN85Model model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                FormN85SurrogateModel surrogateModel;
                using (model.CreateCurrentCultureInfoTransaction())
                {
                    model.InitContextProperties();
                    model.Address.ResetAddressLookup();
                    model.UserName = EidssUserContext.User.FullName;
                    surrogateModel = (FormN85SurrogateModel)model;
                }
                byte[] report = wrapper.Client.ExportHumFormN85ARM(surrogateModel);
                resultParameters = new ReportResultParameters(report, "Human_Form_No_85",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        #endregion

        #region IQ Human Reports

        public ActionResult HumComparativeIQReport()
        {
            ViewBag.GetReportActionName = "ShowHumComparativeIQReport";
            ViewBag.Title = EidssMenu.Instance.GetString("HumComparativeIQReport");
            var address = new AddressModel(FilterHelper.GetDefaultRegion(), FilterHelper.GetDefaultRayon());
            return View("IQ/Comparative", new ComparativeIQModel { Address1 = address });
        }

        public ActionResult ShowHumComparativeIQReport(ComparativeIQModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                ComparativeSurrogateModel surrogateModel;
                using (model.CreateCurrentCultureInfoTransaction())
                {
                    model.InitContextProperties();
                    model.Address1.ResetAddressLookup();
                    model.Address2.ResetAddressLookup();
                    surrogateModel = (ComparativeSurrogateModel)model;
                }

                byte[] report = wrapper.Client.ExportHumComparativeIQReport(surrogateModel);
                resultParameters = new ReportResultParameters(report, "Human_Comparative_Report",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }
            return PrepareReportResult(resultParameters);
        }

        public ActionResult WeeklySituationDiseasesByDistricts()
        {
            ViewBag.GetReportActionName = "ShowWeeklySituationDiseasesByDistricts";
            ViewBag.Title = EidssMenu.Instance.GetString("WeeklySituationDiseasesByDistricts");

            var model = new SituationOnInfectiousDiseasesModel
            {
                PeriodType = StatisticPeriodType.Week,
                PeriodNumber = DatePeriodHelper.GetWeekOfYear(DateTime.Now),
                Year = DateTime.Now.Year
            };
            return View("IQ/WeeklySituationDiseasesByAgeGroupAndSex", model);
        }

        public ActionResult ShowWeeklySituationDiseasesByDistricts(SituationOnInfectiousDiseasesModel model)
        {
            ReportResultParameters resultParameters;
            model.PeriodType = StatisticPeriodType.Week;
            using (var wrapper = new ReportClientWrapper())
            {
                byte[] report = wrapper.Client.ExportWeeklySituationDiseasesByDistricts((SituationOnInfectiousDiseasesSurrogateModel)model);
                resultParameters = new ReportResultParameters(report, "Human_Weekly_Situation_Diseases_By_Districts",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }
            return PrepareReportResult(resultParameters);
        }

        public ActionResult MonthlySituationDiseasesByDistricts()
        {
            ViewBag.GetReportActionName = "ShowMonthlySituationDiseasesByDistricts";
            ViewBag.Title = EidssMenu.Instance.GetString("MonthlySituationDiseasesByDistricts");

            var model = new SituationOnInfectiousDiseasesModel
            {
                PeriodType = StatisticPeriodType.Month,
                PeriodNumber = DateTime.Now.Month,
                Year = DateTime.Now.Year
            };
            return View("IQ/MonthSituationDiseasesByAgeGroupAndSex", model);
        }

        public ActionResult ShowMonthlySituationDiseasesByDistricts(SituationOnInfectiousDiseasesModel model)
        {
            model.PeriodType = StatisticPeriodType.Month;
            model.Year = model.MonthsFilter.Year;
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                byte[] report = wrapper.Client.ExportMonthlySituationDiseasesByDistricts((SituationOnInfectiousDiseasesSurrogateModel)model);
                resultParameters = new ReportResultParameters(report, "Human_Monthly_Situation_Diseases_By_Districts",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }
            return PrepareReportResult(resultParameters);
        }

        public ActionResult WeeklySituationDiseasesByAgeGroupAndSex()
        {
            ViewBag.GetReportActionName = "ShowWeeklySituationDiseasesByAgeGroupAndSex";
            ViewBag.Title = EidssMenu.Instance.GetString("WeeklySituationDiseasesByAgeGroupAndSex");

            var model = new SituationOnInfectiousDiseasesModel
            {
                PeriodType = StatisticPeriodType.Week,
                Year = DateTime.Now.Year,
                PeriodNumber = DatePeriodHelper.GetWeekOfYear(DateTime.Now)
            };
            return View("IQ/WeeklySituationDiseasesByAgeGroupAndSex", model);
        }

        public ActionResult ShowWeeklySituationDiseasesByAgeGroupAndSex(SituationOnInfectiousDiseasesModel model)
        {
            model.PeriodType = StatisticPeriodType.Week;
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                byte[] report =
                    wrapper.Client.ExportWeeklySituationDiseasesByAgeGroupAndSex((SituationOnInfectiousDiseasesSurrogateModel)model);
                resultParameters = new ReportResultParameters(report, "Human_Weekly_Situation_Diseases_By_Age_Group_And_Sex",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }
            return PrepareReportResult(resultParameters);
        }

        public ActionResult MonthlySituationDiseasesByAgeGroupAndSex()
        {
            ViewBag.GetReportActionName = "ShowMonthlySituationDiseasesByAgeGroupAndSex";
            ViewBag.Title = EidssMenu.Instance.GetString("MonthlySituationDiseasesByAgeGroupAndSex");
            var model = new SituationOnInfectiousDiseasesModel
            {
                PeriodType = StatisticPeriodType.Month,
                Year = DateTime.Now.Year,
                PeriodNumber = DateTime.Now.Month
            };
            return View("IQ/MonthSituationDiseasesByAgeGroupAndSex", model);
        }

        public ActionResult ShowMonthlySituationDiseasesByAgeGroupAndSex(SituationOnInfectiousDiseasesModel model)
        {
            ReportResultParameters resultParameters;
            model.PeriodType = StatisticPeriodType.Month;
            model.Year = model.MonthsFilter.Year;
            using (var wrapper = new ReportClientWrapper())
            {
                byte[] report =
                    wrapper.Client.ExportMonthlySituationDiseasesByAgeGroupAndSex((SituationOnInfectiousDiseasesSurrogateModel)model);
                resultParameters = new ReportResultParameters(report, "Human_Monthly_Situation_Diseases_By_Age_Group_And_Sex",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }
            return PrepareReportResult(resultParameters);
        }

        #endregion

        #region GG Human Reports

        public ActionResult Hum60BJournal()
        {
            ViewBag.GetReportActionName = "ShowHum60BJournal";
            ViewBag.Title = EidssMenu.Instance.GetString("ReportsJournal60BReportCard");
            return View("GG/Hum60BJournal", new Hum60BJournalModel());
        }

        public ActionResult ShowHum60BJournal(Hum60BJournalModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                model.InitContextProperties();
                byte[] report = wrapper.Client.ExportHum60BJournal(model);
                resultParameters = new ReportResultParameters(report, "Human_60B_Journal",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        public ActionResult HumMonthInfectiousDiseaseV5()
        {
            ViewBag.GetReportActionName = "ShowHumMonthInfectiousDiseaseV5";
            ViewBag.Title = EidssMenu.Instance.GetString("ReportsHumInfectiousDiseaseMonthV5");
            var model = new MonthInfectiousDiseaseModel { Version = ReportVersion.Version5 };
            return View("GG/MonthInfectiousDiseaseV5AndV6", model);
        }

        public ActionResult ShowHumMonthInfectiousDiseaseV5(MonthInfectiousDiseaseModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                model.InitContextProperties();
                byte[] report = wrapper.Client.ExportHumMonthInfectiousDiseaseV5(model);
                resultParameters = new ReportResultParameters(report, "Human_Month_Infectious_Disease_V5",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        public ActionResult HumMonthInfectiousDiseaseV6()
        {
            ViewBag.GetReportActionName = "ShowHumMonthInfectiousDiseaseV6";
            ViewBag.Title = EidssMenu.Instance.GetString("ReportsHumInfectiousDiseaseMonthV6");
            var model = new MonthInfectiousDiseaseModel
            {
                Version = ReportVersion.Version6,
                RayonFilter =
                {
                    RegionRayonComplexId = String.Format("{0}__{1}", FilterHelper.GetDefaultRegion(), FilterHelper.GetDefaultRayon()),
                    IsCurrentRayonSelected = true
                }
            };
            return View("GG/MonthInfectiousDiseaseV5AndV6", model);
        }

        public ActionResult ShowHumMonthInfectiousDiseaseV6(MonthInfectiousDiseaseModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                model.InitContextProperties();
                byte[] report = wrapper.Client.ExportHumMonthInfectiousDiseaseV6(model);
                resultParameters = new ReportResultParameters(report, "Human_Month_Infectious_Disease_V6",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        public ActionResult HumMonthInfectiousDiseaseV61()
        {
            ViewBag.GetReportActionName = "ShowHumMonthInfectiousDiseaseV61";
            ViewBag.Title = EidssMenu.Instance.GetString("ReportsHumInfectiousDiseaseMonthV61");
            var model = new MonthInfectiousDiseaseModel
            {
                RayonFilter =
                {
                    RegionRayonComplexId = String.Format("{0}__{1}", FilterHelper.GetDefaultRegion(), FilterHelper.GetDefaultRayon()),
                    IsCurrentRayonSelected = true
                }
            };
            return View("GG/MonthInfectiousDiseaseV5AndV6", model);
        }

        public ActionResult ShowHumMonthInfectiousDiseaseV61(MonthInfectiousDiseaseModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                model.InitContextProperties();
                byte[] report = wrapper.Client.ExportHumMonthInfectiousDiseaseV61(model);
                resultParameters = new ReportResultParameters(report, "Human_Month_Infectious_Disease_V61",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        public ActionResult HumIntermediateMonthInfectiousDiseaseV5()
        {
            ViewBag.GetReportActionName = "ShowHumIntermediateMonthInfectiousDiseaseV5";
            ViewBag.Title = EidssMenu.Instance.GetString("HumInfectiousDiseaseIntermediateMonthV5");
            var address = new AddressModel(FilterHelper.GetDefaultRegion(), FilterHelper.GetDefaultRayon());
            var processor = new InfectiousDiseasesProcessor(ReportVersion.Version5);
            return View("GG/IntermediateInfectiousDisease", new IntermediateInfectiousDiseaseModel
            {
                Address = address,
                UseEmptyInititalStartDate = true,
                UseEmptyInititalEndDate = true,
                ValidationMessage = "msgInfectiousDiseasesCorrectDate",
                MinStartDate = processor.MinDate,
                MinEndDate = processor.MinDate,
                MaxStartDate = processor.MaxDate,
                MaxEndDate = processor.MaxDate
            });
        }

        public ActionResult ShowHumIntermediateMonthInfectiousDiseaseV5(IntermediateInfectiousDiseaseModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                IntermediateInfectiousDiseaseSurrogateModel surrogateModel;
                using (model.CreateCurrentCultureInfoTransaction())
                {
                    model.InitContextProperties();
                    model.Address.ResetAddressLookup();
                    surrogateModel = (IntermediateInfectiousDiseaseSurrogateModel)model;
                }

                byte[] report = wrapper.Client.ExportHumIntermediateMonthInfectiousDiseaseV5(surrogateModel);
                resultParameters = new ReportResultParameters(report, "Human_Intermediate_Month_Infectious_Disease_V5",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }
            return PrepareReportResult(resultParameters);
        }

        public ActionResult HumIntermediateMonthInfectiousDiseaseV6()
        {
            ViewBag.GetReportActionName = "ShowHumIntermediateMonthInfectiousDiseaseV6";
            ViewBag.Title = EidssMenu.Instance.GetString("HumInfectiousDiseaseIntermediateMonthV6");
            var address = new AddressModel(FilterHelper.GetDefaultRegion(), FilterHelper.GetDefaultRayon());
            var processor = new InfectiousDiseasesProcessor(ReportVersion.Version6);
            return View("GG/IntermediateInfectiousDisease", new IntermediateInfectiousDiseaseModel
            {
                Address = address,
                UseEmptyInititalStartDate = true,
                UseEmptyInititalEndDate = true,
                ValidationMessage = "msgInfectiousDiseasesCorrectDate",
                MinStartDate = processor.MinDate,
                MinEndDate = processor.MinDate,
                MaxStartDate = processor.MaxDate,
                MaxEndDate = processor.MaxDate
            });
        }

        public ActionResult ShowHumIntermediateMonthInfectiousDiseaseV6(IntermediateInfectiousDiseaseModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                IntermediateInfectiousDiseaseSurrogateModel surrogateModel;
                using (model.CreateCurrentCultureInfoTransaction())
                {
                    model.InitContextProperties();
                    model.Address.ResetAddressLookup();
                    surrogateModel = (IntermediateInfectiousDiseaseSurrogateModel)model;
                }

                byte[] report = wrapper.Client.ExportHumIntermediateMonthInfectiousDiseaseV6(
                    surrogateModel);
                resultParameters = new ReportResultParameters(report, "Human_Intermediate_Month_Infectious_Disease_V6",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }
            return PrepareReportResult(resultParameters);
        }

        public ActionResult HumIntermediateMonthInfectiousDiseaseV61()
        {
            ViewBag.GetReportActionName = "ShowHumIntermediateMonthInfectiousDiseaseV61";
            ViewBag.Title = EidssMenu.Instance.GetString("HumInfectiousDiseaseIntermediateMonthV61");
            var address = new AddressModel(FilterHelper.GetDefaultRegion(), FilterHelper.GetDefaultRayon());
            var processor = new InfectiousDiseasesProcessor(ReportVersion.Version61);
            return View("GG/IntermediateInfectiousDisease", new IntermediateInfectiousDiseaseModel
            {
                Address = address,
                UseEmptyInititalStartDate = true,
                UseEmptyInititalEndDate = true,
                ValidationMessage = "msgInfectiousDiseasesCorrectDate",
                MinStartDate = processor.MinDate,
                MinEndDate = processor.MinDate,
                MaxStartDate = processor.MaxDate,
                MaxEndDate = processor.MaxDate
            });
        }

        public ActionResult ShowHumIntermediateMonthInfectiousDiseaseV61(IntermediateInfectiousDiseaseModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                IntermediateInfectiousDiseaseSurrogateModel surrogateModel;
                using (model.CreateCurrentCultureInfoTransaction())
                {
                    model.InitContextProperties();
                    model.Address.ResetAddressLookup();
                    surrogateModel = (IntermediateInfectiousDiseaseSurrogateModel)model;
                }

                byte[] report = wrapper.Client.ExportHumIntermediateMonthInfectiousDiseaseV61(
                    surrogateModel);
                resultParameters = new ReportResultParameters(report, "Human_Intermediate_Month_Infectious_Disease_V61",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }
            return PrepareReportResult(resultParameters);
        }
        public ActionResult HumAnnualInfectiousDisease()
        {
            ViewBag.GetReportActionName = "ShowHumAnnualInfectiousDisease";
            ViewBag.Title = EidssMenu.Instance.GetString("ReportsHumInfectiousDiseaseYear");
            return View("GG/AnnualInfectiousDisease", new AnnualInfectiousDiseaseModel());
        }

        public ActionResult ShowHumAnnualInfectiousDisease(AnnualInfectiousDiseaseModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                model.InitContextProperties();
                byte[] report = wrapper.Client.ExportHumAnnualInfectiousDisease(model);
                resultParameters = new ReportResultParameters(report, "Human_Annual_Infectious_Disease",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        public ActionResult HumIntermediateAnnualInfectiousDisease()
        {
            ViewBag.GetReportActionName = "ShowHumIntermediateAnnualInfectiousDisease";
            ViewBag.Title = EidssMenu.Instance.GetString("HumInfectiousDiseaseIntermediateYear");
            var address = new AddressModel(FilterHelper.GetDefaultRegion(), FilterHelper.GetDefaultRayon());
            return View("GG/IntermediateInfectiousDisease", new IntermediateInfectiousDiseaseModel
            {
                Address = address,
                UseEmptyInititalStartDate = true,
                UseEmptyInititalEndDate = true,
                MinStartDate = new DateTime(2005, 1, 1),
                MaxStartDate = new DateTime(2012, 12, 31),
                MinEndDate = new DateTime(2005, 1, 1),
                MaxEndDate = new DateTime(2012, 12, 31),
                ValidationMessage = "msgInfectiousDiseasesCorrectDate"

            });
        }

        public ActionResult ShowHumIntermediateAnnualInfectiousDisease(IntermediateInfectiousDiseaseModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                IntermediateInfectiousDiseaseSurrogateModel surrogateModel;
                using (model.CreateCurrentCultureInfoTransaction())
                {
                    model.InitContextProperties();
                    model.Address.ResetAddressLookup();
                    surrogateModel = (IntermediateInfectiousDiseaseSurrogateModel)model;
                }

                model.InitContextProperties();
                byte[] report = wrapper.Client.ExportHumIntermediateAnnualInfectiousDisease(surrogateModel);
                resultParameters = new ReportResultParameters(report, "Human_Intermediate_Annual_Infectious_Disease",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }
            return PrepareReportResult(resultParameters);
        }

        public ActionResult HumMonthInfectiousDiseaseV4()
        {
            ViewBag.GetReportActionName = "ShowHumMonthInfectiousDiseaseV4";
            ViewBag.Title = EidssMenu.Instance.GetString("ReportsHumInfectiousDiseaseMonthV4");
            var model = new MonthInfectiousDiseaseModel { Version = ReportVersion.Version4 };
            return View("GG/MonthInfectiousDiseaseV4", model);
        }

        public ActionResult ShowHumMonthInfectiousDiseaseV4(MonthInfectiousDiseaseModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                model.InitContextProperties();
                byte[] report = wrapper.Client.ExportHumMonthInfectiousDiseaseV4(model);
                resultParameters = new ReportResultParameters(report, "Human_Month_Infectious_Disease_V4",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        public ActionResult HumIntermediateMonthInfectiousDiseaseV4()
        {
            ViewBag.GetReportActionName = "ShowHumIntermediateMonthInfectiousDiseaseV4";
            ViewBag.Title = EidssMenu.Instance.GetString("HumInfectiousDiseaseIntermediateMonthV4");
            var address = new AddressModel(FilterHelper.GetDefaultRegion(), FilterHelper.GetDefaultRayon());
            var processor = new InfectiousDiseasesProcessor(ReportVersion.Version4);
            return View("GG/IntermediateInfectiousDisease", new IntermediateInfectiousDiseaseModel
            {
                Address = address,
                UseEmptyInititalStartDate = true,
                UseEmptyInititalEndDate = true,
                ValidationMessage = "msgInfectiousDiseasesCorrectDate",
                MinStartDate = processor.MinDate,
                MinEndDate = processor.MinDate,
                MaxStartDate = processor.MaxDate,
                MaxEndDate = processor.MaxDate
            });
        }

        public ActionResult ShowHumIntermediateMonthInfectiousDiseaseV4(IntermediateInfectiousDiseaseModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                IntermediateInfectiousDiseaseSurrogateModel surrogateModel;
                using (model.CreateCurrentCultureInfoTransaction())
                {
                    model.InitContextProperties();
                    model.Address.ResetAddressLookup();
                    surrogateModel = (IntermediateInfectiousDiseaseSurrogateModel)model;
                }

                byte[] report = wrapper.Client.ExportHumIntermediateMonthInfectiousDiseaseV4(surrogateModel);
                resultParameters = new ReportResultParameters(report, "Human_Intermediate_Month_Infectious_Disease_V4",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }
            return PrepareReportResult(resultParameters);
        }

        #endregion

        #region GG Lab Reports

        public ActionResult HumSerologyResearchCard()
        {
            ViewBag.GetReportActionName = "ShowHumSerologyResearchCard";
            ViewBag.Title = EidssMenu.Instance.GetString("ReportsHumSerologyResearchCard");
            return View("GG/HumanLabSample", new HumanLabSampleModel());
        }

        public ActionResult ShowHumSerologyResearchCard(HumanLabSampleModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                model.InitContextProperties();
                model.InitContextProperties();
                byte[] report = wrapper.Client.ExportHumSerologyResearchCard(model);
                resultParameters = new ReportResultParameters(report, "Human_Lab_Serology_Research_Card",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        public ActionResult HumMicrobiologyResearchCard()
        {
            ViewBag.GetReportActionName = "ShowHumMicrobiologyResearchCard";
            ViewBag.Title = EidssMenu.Instance.GetString("ReportsHumMicrobiologyResearchCard");
            return View("GG/HumanLabSample", new HumanLabSampleModel());
        }

        public ActionResult ShowHumMicrobiologyResearchCard(HumanLabSampleModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                model.InitContextProperties();
                byte[] report = wrapper.Client.ExportHumMicrobiologyResearchCard(model);
                resultParameters = new ReportResultParameters(report, "Human_Lab_Microbiology_Research_Card",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        public ActionResult HumAntibioticResistanceCard()
        {
            ViewBag.GetReportActionName = "ShowHumAntibioticResistanceCard";
            ViewBag.Title = EidssMenu.Instance.GetString("HumAntibioticResistanceCard");
            return View("GG/HumanLabSample", new HumanLabSampleModel());
        }

        public ActionResult ShowHumAntibioticResistanceCard(HumanLabSampleModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                model.InitContextProperties();
                byte[] report = wrapper.Client.ExportHumAntibioticResistanceCard(model);
                resultParameters = new ReportResultParameters(report, "Human_Lab_Antibiotic_Resistanc_Card_NCDC",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        public ActionResult HumAntibioticResistanceCardLma()
        {
            ViewBag.GetReportActionName = "ShowHumAntibioticResistanceCardLma";
            ViewBag.Title = EidssMenu.Instance.GetString("HumAntibioticResistanceCardLma");
            return View("GG/VetLabSample", new VetLabSampleModel());
        }

        public ActionResult ShowHumAntibioticResistanceCardLma(VetLabSampleModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                model.InitContextProperties();
                byte[] report = wrapper.Client.ExportHumAntibioticResistanceCardLma(model);
                resultParameters = new ReportResultParameters(report, "Human_Lab_Antibiotic_Resistanc_Card_LMA",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        #endregion

        #region Common Vet Reports

        public ActionResult VetYearlySituation()
        {
            ViewBag.GetReportActionName = "ShowVetYearlySituation";
            ViewBag.Title = EidssMenu.Instance.GetString("ReportsVetYearlySituation");
            return View("Common/BaseYear", new BaseYearModel { CanWorkWithArchive = false });
        }

        public ActionResult ShowVetYearlySituation(BaseYearModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                model.InitContextProperties();
                byte[] report = wrapper.Client.ExportVetYearlySituation(model);
                resultParameters = new ReportResultParameters(report, "Veterinary_Yearly_Situation",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        public ActionResult VetSamplesCount()
        {
            ViewBag.GetReportActionName = "ShowVetSamplesCount";
            ViewBag.Title = EidssMenu.Instance.GetString("ReportsVetSamplesCount");
            return View("Common/BaseYear", new BaseYearModel { CanWorkWithArchive = false });
        }

        public ActionResult ShowVetSamplesCount(BaseYearModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                model.InitContextProperties();
                byte[] report = wrapper.Client.ExportVetSamplesCount(model);
                resultParameters = new ReportResultParameters(report, "Veterinary_Samples_Count",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        public ActionResult VetSamplesBySampleType()
        {
            ViewBag.GetReportActionName = "ShowVetSamplesBySampleType";
            ViewBag.Title = EidssMenu.Instance.GetString("ReportsVetSamplesReportBySampleType");
            return View("Common/BaseYear", new BaseYearModel { CanWorkWithArchive = false });
        }

        public ActionResult ShowVetSamplesBySampleType(BaseYearModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                model.InitContextProperties();
                byte[] report = wrapper.Client.ExportVetSamplesBySampleType(model);
                resultParameters = new ReportResultParameters(report, "Veterinary_Samples_Count_By_SampleType",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        public ActionResult VetSamplesBySampleTypesWithinRegions()
        {
            ViewBag.GetReportActionName = "ShowVetSamplesBySampleTypesWithinRegions";
            ViewBag.Title = EidssMenu.Instance.GetString("ReportsVetSamplesReportBySampleTypesWithinRegions");
            return View("Common/BaseYear", new BaseYearModel { CanWorkWithArchive = false });
        }

        public ActionResult ShowVetSamplesBySampleTypesWithinRegions(BaseYearModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                model.InitContextProperties();
                byte[] report = wrapper.Client.ExportVetSamplesBySampleTypesWithinRegions(model);
                resultParameters = new ReportResultParameters(report, "Veterinary_Samples_Count_By_SampleType_Within_Regions",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        public ActionResult VetActiveSurveillance()
        {
            ViewBag.GetReportActionName = "ShowVetActiveSurveillance";
            ViewBag.Title = EidssMenu.Instance.GetString("ReportsActiveSurveillance");
            return View("Common/BaseYear", new BaseYearModel { CanWorkWithArchive = false });
        }

        public ActionResult ShowVetActiveSurveillance(BaseYearModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                model.InitContextProperties();
                byte[] report = wrapper.Client.ExportVetActiveSurveillance(model);
                resultParameters = new ReportResultParameters(report, "Veterinary_Active_Surveillance_Report",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        #endregion

        #region KZ Vet Reports

        public ActionResult VetCountryPlannedDiagnosticTests()
        {
            ViewBag.GetReportActionName = "ShowVetCountryPlannedDiagnosticTests";
            ViewBag.Title = EidssMenu.Instance.GetString("VetCountryPlannedDiagnosticTestsReport");
            return View("KZ/DiagnosticInvestigationCountry", new DiagnosticInvestigationModel());
        }

        public ActionResult ShowVetCountryPlannedDiagnosticTests(DiagnosticInvestigationModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                model.InitContextProperties();
                byte[] report = wrapper.Client.ExportVetCountryPlannedDiagnosticTests(model);

                resultParameters = new ReportResultParameters(report, "Veterinary_Country_Planned_Diagnostic_Tests_Report",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        public ActionResult VetOblastPlannedDiagnosticTests()
        {
            ViewBag.GetReportActionName = "ShowVetOblastPlannedDiagnosticTests";
            ViewBag.Title = EidssMenu.Instance.GetString("VetRegionPlannedDiagnosticTestsReport");
            return View("KZ/DiagnosticInvestigationOblast", new DiagnosticInvestigationModel());
        }

        public ActionResult ShowVetOblastPlannedDiagnosticTests(DiagnosticInvestigationModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                model.InitContextProperties();
                byte[] report = wrapper.Client.ExportVetOblastPlannedDiagnosticTests(model);

                resultParameters = new ReportResultParameters(report, "Veterinary_Oblast_Planned_Diagnostic_Tests_Report",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        public ActionResult VetCountryPreventiveMeasures()
        {
            ViewBag.GetReportActionName = "ShowVetCountryPreventiveMeasures";
            ViewBag.Title = EidssMenu.Instance.GetString("VetCountryPreventiveMeasuresReport");
            return View("KZ/ProphylacticCountry", new ProphylacticModel());
        }

        public ActionResult ShowVetCountryPreventiveMeasures(ProphylacticModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                model.InitContextProperties();
                byte[] report = wrapper.Client.ExportVetCountryPreventiveMeasures(model);

                resultParameters = new ReportResultParameters(report, "Veterinary_Country_Preventive_Measures_Report",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        public ActionResult VetOblastPreventiveMeasures()
        {
            ViewBag.GetReportActionName = "ShowVetOblastPreventiveMeasures";
            ViewBag.Title = EidssMenu.Instance.GetString("VetRegionPreventiveMeasuresReport");
            return View("KZ/ProphylacticOblast", new ProphylacticModel());
        }

        public ActionResult ShowVetOblastPreventiveMeasures(ProphylacticModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                model.InitContextProperties();
                byte[] report = wrapper.Client.ExportVetOblastPreventiveMeasures(model);

                resultParameters = new ReportResultParameters(report, "Veterinary_Oblast_Preventive_Measures_Report",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        public ActionResult VetCountrySanitaryMeasures()
        {
            ViewBag.GetReportActionName = "ShowVetCountrySanitaryMeasures";
            ViewBag.Title = EidssMenu.Instance.GetString("VetCountryProphilacticMeasuresReport");
            return View("KZ/SanitaryCountry", new SanitaryModel());
        }

        public ActionResult ShowVetCountrySanitaryMeasures(SanitaryModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                model.InitContextProperties();
                byte[] report = wrapper.Client.ExportVetCountrySanitaryMeasures(model);
                resultParameters = new ReportResultParameters(report, "Veterinary_Country_Sanitary_Measures_Report",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        public ActionResult VetOblastSanitaryMeasures()
        {
            ViewBag.GetReportActionName = "ShowVetOblastSanitaryMeasures";
            ViewBag.Title = EidssMenu.Instance.GetString("VetRegionProphilacticMeasuresReport");
            return View("KZ/SanitaryOblast", new SanitaryModel());
        }

        public ActionResult ShowVetOblastSanitaryMeasures(SanitaryModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                model.InitContextProperties();
                byte[] report = wrapper.Client.ExportVetOblastSanitaryMeasures(model);
                resultParameters = new ReportResultParameters(report, "Veterinary_Oblast_Sanitary_Measures_Report",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        #endregion

        #region KZ Human Reports

        public ActionResult HumInfectiousParasiticKZ()
        {
            ViewBag.GetReportActionName = "ShowHumInfectiousParasiticKZ";
            ViewBag.Title = EidssMenu.Instance.GetString("HumInfectiousParasiticKZ");
            var model = new InfectiousParasiticKZModel(FilterHelper.GetDefaultRegion(), FilterHelper.GetDefaultRayon());
            return View("KZ/HumInfectiousParasiticKZ", model);
        }

        public ActionResult ShowHumInfectiousParasiticKZ(InfectiousParasiticKZModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                model.InitContextProperties();
                byte[] report = wrapper.Client.ExportInfectiousParasiticKZReport((InfectiousParasiticKZSurrogateModel)model);
                resultParameters = new ReportResultParameters(report, "Human_Form_No_2",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        #endregion

        #region GG Vet Reports

        //VetLaboratoryResearchResult // VetLaboratoryResearchResult

        public ActionResult VetLaboratoryResearchResult()
        {
            ViewBag.GetReportActionName = "ShowVetLaboratoryResearchResult";
            ViewBag.Title = EidssMenu.Instance.GetString("VetLaboratoryResearchResult");
            return View("GG/VetLaboratoryResearchResult", new VetLaboratoryResearchResultModel());
        }

        public ActionResult ShowVetLaboratoryResearchResult(VetLaboratoryResearchResultModel model)
        {
            SelectListItemSurrogate csr =
                model.ConditionSampleReceivedList.FirstOrDefault(c => c.Value == model.cbConditionSampleReceived.ToString());
            if (csr != null && csr.Text.Length > 0)
            {
                model.ConditionSampleReceived = csr.Text;
            }

            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                byte[] report = wrapper.Client.ExportVetLaboratoryResearchResult(model);
                resultParameters = new ReportResultParameters(report, "Vet_Laboratory_Research_Result",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }
            return PrepareReportResult(resultParameters);
        }

        public ActionResult VetRabiesBulletinEurope()
        {
            ViewBag.GetReportActionName = "ShowVetRabiesBulletinEurope";
            ViewBag.Title = EidssMenu.Instance.GetString("ReportsVetRabiesBulletinEurope");
            return View("GG/VetRabiesBulletinEurope", new RBEModel());
        }

        public ActionResult ShowVetRabiesBulletinEurope(RBEModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                model.InitContextProperties();
                if (!bv.common.Core.Utils.IsEmpty(model.QuarterList))
                {
                    string[] quartersValues = model.QuarterList.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    if (quartersValues.Length > 0)
                    {
                        List<int> q = quartersValues.Select(s => Convert.ToInt32(s)).ToList();
                        model.Quarters = new QuartersModel(q.Contains(1), q.Contains(2), q.Contains(3), q.Contains(4));
                    }
                }

                if (!bv.common.Core.Utils.IsEmpty(model.RegionList))
                {
                    model.Regions = model.RegionList.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                }

                if (!bv.common.Core.Utils.IsEmpty(model.RayonList))
                {
                    model.Rayons = model.RayonList.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                }

                byte[] report = wrapper.Client.ExportVetRabiesBulletinEurope((RBESurrogateModel)model);
                resultParameters = new ReportResultParameters(report, "Vet_Rabies_Bulletin_Europe_Report",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        #endregion

        #region Common Administrative Reports

        public ActionResult AdmEventLog()
        {
            ViewBag.GetReportActionName = "ShowAdmEventLog";
            ViewBag.Title = EidssMenu.Instance.GetString("ReportsAdmEventLog");
            return View("Common/BaseInterval", new BaseIntervalModel { CanWorkWithArchive = false });
        }

        public ActionResult ShowAdmEventLog(BaseIntervalModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                model.InitContextProperties();
                byte[] report = wrapper.Client.ExportAdmEventLog(model);
                resultParameters = new ReportResultParameters(report, "Administrative_Event_Log",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        #endregion

        #region Helper Methods

        private ActionResult PrepareReportResult(ReportResultParameters parameters)
        {
            string extension = parameters.FileExtension.ToLowerInvariant();
            string fullFileName = string.Format("{0}.{1}", parameters.FileName, extension);
            // this check because if call from  unit test HttpContext is null
            if (HttpContext != null)
            {
                HttpContext.Response.AddHeader("Content-Disposition",
                    string.Format("{0}; filename={1}", parameters.IsOpenInNewWindow ? "inline" : "attachment", fullFileName));
                Response.AppendHeader("Content-Type", "application/" + extension);
                Response.BinaryWrite(parameters.FileContents);
            }
            return new ContentResult();
        }

        public ActionResult LanguageChanged(string lang)
        {
            return new JsonResult { Data = String.Empty, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }


        #endregion
    }
}