using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Web.Mvc;
using bv.model.Model.Core;
using eidss.model.Reports;
using eidss.model.Reports.AZ;
using eidss.model.Reports.Common;
using eidss.model.Reports.GG;
using eidss.model.Reports.KZ;
using eidss.model.Resources;
using eidss.webclient.Models.Reports;
using eidss.webclient.Utils;

namespace eidss.webclient.Controllers
{
    [AuthorizeEIDSS]
    public class ReportController : Controller
    {
        #region Paper Forms

        private string GetFullPathForPaperForm(string reportName)
        {
            var ret = String.Format("/Content/PaperForms/{0}/{1}", ModelUserContext.CurrentLanguage, reportName);
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
            const string reportName = "General Case Investigation Form.pdf";
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
            ViewBag.ArrayForRename = new List<string> {"InitialDiagnoses.CheckedItems", "FinalDiagnoses.CheckedItems"};

            var address = new AddressModel(FilterHelper.GetDefaultRegion(), FilterHelper.GetDefaultRayon()) {IsSettlementVisible = true};
            return View("Common/DToChangedD", new DToChangedDModel {Address = address});
        }

        public ActionResult ShowHumDiagnosisToChangedDiagnosis(DToChangedDModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                model.InitContextProperties();
                if (!bv.common.Core.Utils.IsEmpty(model.InitialDiagnosesList))
                {
                    model.InitialDiagnoses.CheckedItems = model.InitialDiagnosesList.Split(new[] {","},
                        StringSplitOptions.RemoveEmptyEntries);
                }

                if (!bv.common.Core.Utils.IsEmpty(model.FinalDiagnosesList))
                {
                    model.FinalDiagnoses.CheckedItems = model.FinalDiagnosesList.Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries);
                }
                //модель может содержать выбранные диагнозы, перечисленные через запятую, собранные в один элемент массива
                //CorrectDiagnoses(model.InitialDiagnoses);
                //CorrectDiagnoses(model.FinalDiagnoses);

                byte[] report = wrapper.Client.ExportHumDiagnosisToChangedDiagnosis((DToChangedDSurrogateModel) model);
                resultParameters = new ReportResultParameters(report, "Concordance_of_Initial_and_Final_Diagnosis",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        private void CorrectDiagnoses(MultipleDiagnosisModel dm)
        {
            if (dm.CheckedItems.Length == 1)
            {
                string item0 = dm.CheckedItems[0];
                if (item0.Contains(","))
                {
                    dm.CheckedItems = item0.Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries);
                }
            }
        }

        public ActionResult HumMonthlyMorbidityAndMortality()
        {
            ViewBag.GetReportActionName = "ShowHumMonthlyMorbidityAndMortality";
            ViewBag.Title = EidssMenu.Instance.GetString("ReportsHumMonthlyMorbidityAndMortality");
            return View("Common/BaseDate", new BaseDateModel {CanWorkWithArchive = false});
        }

        public ActionResult ShowHumMonthlyMorbidityAndMortality(BaseDateModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                model.InitContextProperties();
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
                : (object) string.Empty;

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTransportCHERayons(TransportCHEModel model)
        {
            object jsonData = (model.RegionId.HasValue && model.RegionId.Value > 0)
                ? new SelectList(model.GetRayons(), "Value", "Text")
                : (object) string.Empty;

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetRayonsList(AddressMultiselectModel model)
        {
            object jsonData = !bv.common.Core.Utils.IsEmpty(model.RegionsSelected)
                ? new SelectList(model.GetRayons(model.RegionsSelected), "Value", "Text")
                : (object) string.Empty;

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSettlements(AddressModel model)
        {
            object jsonData = (model.RayonId.HasValue && model.RayonId.Value > 0)
                ? new SelectList(model.GetSettlements(), "Value", "Text")
                : (object) string.Empty;

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
                model.InitContextProperties();
                byte[] report = wrapper.Client.ExportHumFormN1((FormNo1SurrogateModel) model);
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
                new DataQualityIndicatorsModel {CanWorkWithArchive = false, ShowRayonFilter = true, EndMonth = DateTime.Today.Month});
        }

        public ActionResult ShowDataQualityIndicators(DataQualityIndicatorsModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                model.InitContextProperties();
                byte[] report = wrapper.Client.ExportHumDataQualityIndicators((DataQualityIndicatorsSurrogateModel) model);
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
                new DataQualityIndicatorsModel {CanWorkWithArchive = false, EndMonth = DateTime.Today.Month});
        }

        public ActionResult ShowDataQualityIndicatorsRayons(DataQualityIndicatorsModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                model.InitContextProperties();
                if (!bv.common.Core.Utils.IsEmpty(model.MultipleDiagnosisFilter_CheckedItems))
                {
                    model.MultipleDiagnosisFilter.CheckedItems = model.MultipleDiagnosisFilter_CheckedItems.Split(new[] {","},
                        StringSplitOptions.RemoveEmptyEntries);
                }
                byte[] report = wrapper.Client.ExportHumDataQualityIndicatorsRayons((DataQualityIndicatorsSurrogateModel) model);
                resultParameters = new ReportResultParameters(report, "Human_Data_Quality_Indicators",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        public ActionResult HumSummaryByRayonDiagnosisAgeGroups()
        {
            ViewBag.GetReportActionName = "ShowHumSummaryByRayonDiagnosisAgeGroups";
            ViewBag.Title = EidssMenu.Instance.GetString("HumSummaryByRayonDiagnosisAgeGroups");
            ViewBag.MaxCheckedCount = SummaryByRayonDiagnosisModel.HumMaxDiagnosisCount;
            return View("AZ/SummaryByRayonDiagnosis", new SummaryByRayonDiagnosisModel(null) {CanWorkWithArchive = false});
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
                        model.MultipleDiagnosisFilter_CheckedItems.Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries);
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
            return View("AZ/Comparative", new ComparativeModel {Address1 = address});
        }

        public ActionResult ShowHumComparativeAZReport(ComparativeModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                model.InitContextProperties();
                byte[] report = wrapper.Client.ExportHumComparativeAZReport((ComparativeSurrogateModel) model);
                resultParameters = new ReportResultParameters(report, "Human_Comparative_Report",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        public ActionResult HumExternalComparativeReport()
        {
            ViewBag.GetReportActionName = "ShowHumExternalComparativeReport";
            ViewBag.Title = EidssMenu.Instance.GetString("HumExternalComparativeReport");
            var address = new AddressModel(FilterHelper.GetDefaultRegion(), FilterHelper.GetDefaultRayon());
            return View("AZ/ExternalComparative", new ExternalComparativeModel(address));
        }

        public ActionResult ShowHumExternalComparativeReport(ExternalComparativeModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                model.InitContextProperties();
                byte[] report = wrapper.Client.ExportHumExternalComparativeReport((ExternalComparativeSurrogateModel) model);
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
                : (object) string.Empty;
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetQuartersList(BaseYearQuarterModel model)
        {
            List<SelectListItem> list = model.GetQuarters().ConvertToSelectListItem().ToList();
            object jsonData = (list.Count > 0)
                ? new SelectList(list, "Value", "Text")
                : (object) string.Empty;
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
                var report = wrapper.Client.ExportHumWhoMeaslesRubellaReport(model);
                resultParameters = new ReportResultParameters(report, "Human_Measles_Rubella_Report",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        public ActionResult HumComparativeReportOfTwoYears()
        {
            ViewBag.GetReportActionName = "ShowHumComparativeReportOfTwoYears";
            ViewBag.Title = EidssMenu.Instance.GetString("HumComparativeReportOfTwoYears");
            var address = new AddressModel(FilterHelper.GetDefaultRegion(), FilterHelper.GetDefaultRayon());
            return View("AZ/ComparativeTwoYears", new ComparativeTwoYearsModel {Address = address});
        }

        public ActionResult ShowHumComparativeReportOfTwoYears(ComparativeTwoYearsModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                model.InitContextProperties();
                byte[] report = wrapper.Client.ExportHumComparativeReportOfTwoYears((ComparativeTwoYearsSurrogateModel) model);
                resultParameters = new ReportResultParameters(report, "Human_Comparative_Report_of_Two_years",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        #endregion

        #region AZ Vet Reports

        public ActionResult VeterinaryCasesReportAZ()
        {
            ViewBag.GetReportActionName = "ShowVeterinaryCasesReportAZ";
            ViewBag.Title = EidssMenu.Instance.GetString("VeterinaryCasesReport");
            var address = new AddressModel(FilterHelper.GetDefaultRegion(), FilterHelper.GetDefaultRayon());
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
                model.InitContextProperties();
                byte[] report = wrapper.Client.ExportVeterinaryCasesReport((VetCasesSurrogateModel) model);
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
                model.InitContextProperties();
                byte[] report = wrapper.Client.ExportVeterinaryLaboratoriesAZReport((VetLabSurrogateModel) model);
                resultParameters = new ReportResultParameters(report, "Veterinary_Laboratories_Report",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        public ActionResult VeterinaryFormVet(string reportBaseId)
        {
            ViewBag.GetReportActionName = string.Format("Show{0}", reportBaseId);
            ViewBag.Title = EidssMenu.Instance.GetString(reportBaseId);
            var address = new AddressModel(FilterHelper.GetDefaultRegion(), FilterHelper.GetDefaultRayon());
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
                byte[] report = wrapper.Client.ExportVeterinaryFormVet1((VetCasesSurrogateModel) model);
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
                byte[] report = wrapper.Client.ExportVeterinaryFormVet1A((VetCasesSurrogateModel) model);
                resultParameters = new ReportResultParameters(report, "VeterinaryFormVet1A",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        public ActionResult VeterinarySummaryAZ()
        {
            ViewBag.GetReportActionName = "ShowVeterinarySummaryAZ";
            ViewBag.Title = EidssMenu.Instance.GetString("VeterinarySummaryAZ");
            ViewBag.MaxCheckedCount = SummaryByRayonDiagnosisModel.VetMaxDiagnosisCount;
            return View("AZ/SummaryByRayonDiagnosis", new SummaryByRayonDiagnosisModel {CanWorkWithArchive = false, IsVet = true});
        }

        public ActionResult ShowVeterinarySummaryAZ(SummaryByRayonDiagnosisModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                model.InitContextProperties();
                model.IsVet = true;
                if (!bv.common.Core.Utils.IsEmpty(model.MultipleDiagnosisFilter_CheckedItems))
                {
                    model.MultipleDiagnosisFilter.CheckedItems =
                        model.MultipleDiagnosisFilter_CheckedItems.Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries);
                    //TODO отрезать избыточные диагнозы
                }
                
                var report = wrapper.Client.ExportVeterinarySummaryAZ(model);
                resultParameters = new ReportResultParameters(report, "Veterinary_Summary_Report",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        #endregion

        #region AZ Lab Reports

        public ActionResult LabTestingResultsAZ()
        {
            ViewBag.GetReportActionName = "ShowLabTestingResultsAZ";
            ViewBag.Title = EidssMenu.Instance.GetString("LabTestingResultsAZ");
            return View("AZ/LabTestingResults", new VetLabSampleModel());
        }

        public ActionResult ShowLabTestingResultsAZ(VetLabSampleModel model)
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

        public ActionResult AssignmentLabDiagnosticAZ()
        {
            ViewBag.GetReportActionName = "ShowAssignmentLabDiagnosticAZ";
            ViewBag.Title = EidssMenu.Instance.GetString("AssignmentLabDiagnosticAZ");
            return View("AZ/AssignmentLabDiagnostic", new LabCaseModel());
        }

        public ActionResult ShowAssignmentLabDiagnosticAZ(LabCaseModel model)
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

        #endregion

        #region IQ Human Reports

        /*
        public ActionResult HumComparativeIQReport()
        {
            ViewBag.GetReportActionName = "ShowHumComparativeIQReport";
            ViewBag.Title = EidssMenu.Instance.GetString("HumComparativeIQReport");
            var address = new AddressModel(FilterHelper.GetDefaultRegion(), FilterHelper.GetDefaultRayon());
            return View("IQ/Comparative", new ComparativeIQModel { Address1 = address });
        }

        public FileContentResult ShowHumComparativeIQReport(ComparativeIQModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                byte[] report = wrapper.Client.ExportHumComparativeIQReport((ComparativeSurrogateModel)model);
                resultParameters = new ReportResultParameters(report, "Human_Comparative_Report",
                                                              model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }
        */

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

        public ActionResult HumMonthInfectiousDiseaseNew()
        {
            ViewBag.GetReportActionName = "ShowHumMonthInfectiousDiseaseNew";
            ViewBag.Title = EidssMenu.Instance.GetString("ReportsHumInfectiousDiseaseMonthNew");
            var model = new MonthInfectiousDiseaseModel {IsMonthMandatory = true};
            return View("GG/MonthInfectiousDiseaseNew", model);
        }

        public ActionResult ShowHumMonthInfectiousDiseaseNew(MonthInfectiousDiseaseModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                model.InitContextProperties();
                byte[] report = wrapper.Client.ExportHumMonthInfectiousDiseaseNew(model);
                resultParameters = new ReportResultParameters(report, "Human_Month_Infectious_Disease_New_Revision",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        public ActionResult HumIntermediateMonthInfectiousDiseaseNew()
        {
            ViewBag.GetReportActionName = "ShowHumIntermediateMonthInfectiousDiseaseNew";
            ViewBag.Title = EidssMenu.Instance.GetString("HumInfectiousDiseaseIntermediateMonthNew");
            var address = new AddressModel(FilterHelper.GetDefaultRegion(), FilterHelper.GetDefaultRayon());
            return View("GG/IntermediateInfectiousDisease", new IntermediateInfectiousDiseaseModel {Address = address});
        }

        public ActionResult ShowHumIntermediateMonthInfectiousDiseaseNew(IntermediateInfectiousDiseaseModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                model.InitContextProperties();
                byte[] report = wrapper.Client.ExportHumIntermediateMonthInfectiousDiseaseNew(
                    (IntermediateInfectiousDiseaseSurrogateModel) model);
                resultParameters = new ReportResultParameters(report, "Human_Intermediate_Month_Infectious_Disease_New_Revision",
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
            return View("GG/IntermediateInfectiousDisease", new IntermediateInfectiousDiseaseModel {Address = address});
        }

        public ActionResult ShowHumIntermediateAnnualInfectiousDisease(IntermediateInfectiousDiseaseModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                model.InitContextProperties();
                byte[] report = wrapper.Client.ExportHumIntermediateAnnualInfectiousDisease(
                    (IntermediateInfectiousDiseaseSurrogateModel) model);
                resultParameters = new ReportResultParameters(report, "Human_Intermediate_Annual_Infectious_Disease",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }
            return PrepareReportResult(resultParameters);
        }

        public ActionResult HumMonthInfectiousDisease()
        {
            ViewBag.GetReportActionName = "ShowHumMonthInfectiousDisease";
            ViewBag.Title = EidssMenu.Instance.GetString("ReportsHumInfectiousDiseaseMonth");
            var model = new MonthInfectiousDiseaseModel {IsMonthMandatory = true};
            return View("GG/MonthInfectiousDisease", model);
        }

        public ActionResult ShowHumMonthInfectiousDisease(MonthInfectiousDiseaseModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                model.InitContextProperties();
                byte[] report = wrapper.Client.ExportHumMonthInfectiousDisease(model);
                resultParameters = new ReportResultParameters(report, "Human_Month_Infectious_Disease_Old_Revision",
                    model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        public ActionResult HumIntermediateMonthInfectiousDisease()
        {
            ViewBag.GetReportActionName = "ShowHumIntermediateMonthInfectiousDisease";
            ViewBag.Title = EidssMenu.Instance.GetString("HumInfectiousDiseaseIntermediateMonth");
            var address = new AddressModel(FilterHelper.GetDefaultRegion(), FilterHelper.GetDefaultRayon());
            return View("GG/IntermediateInfectiousDisease", new IntermediateInfectiousDiseaseModel {Address = address});
        }

        public ActionResult ShowHumIntermediateMonthInfectiousDisease(IntermediateInfectiousDiseaseModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                byte[] report = wrapper.Client.ExportHumIntermediateMonthInfectiousDisease(
                    (IntermediateInfectiousDiseaseSurrogateModel) model);
                resultParameters = new ReportResultParameters(report, "Human_Intermediate_Month_Infectious_Disease_Old_Revision",
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
            return View("Common/BaseYear", new BaseYearModel {CanWorkWithArchive = false});
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
            return View("Common/BaseYear", new BaseYearModel {CanWorkWithArchive = false});
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
            return View("Common/BaseYear", new BaseYearModel {CanWorkWithArchive = false});
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
            return View("Common/BaseYear", new BaseYearModel {CanWorkWithArchive = false});
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
            return View("Common/BaseYear", new BaseYearModel {CanWorkWithArchive = false});
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
                var report = wrapper.Client.ExportInfectiousParasiticKZReport((InfectiousParasiticKZSurrogateModel)model);
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
                    string[] quartersValues = model.QuarterList.Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries);
                    if (quartersValues.Length > 0)
                    {
                        List<int> q = quartersValues.Select(s => Convert.ToInt32(s)).ToList();
                        model.Quarters = new QuartersModel(q.Contains(1), q.Contains(2), q.Contains(3), q.Contains(4));
                    }
                }

                if (!bv.common.Core.Utils.IsEmpty(model.RegionList))
                {
                    model.Regions = model.RegionList.Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries);
                }

                if (!bv.common.Core.Utils.IsEmpty(model.RayonList))
                {
                    model.Rayons = model.RayonList.Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries);
                }

                byte[] report = wrapper.Client.ExportVetRabiesBulletinEurope((RBESurrogateModel) model);
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
            return View("Common/BaseInterval", new BaseIntervalModel {CanWorkWithArchive = false});
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
            var extension = parameters.FileExtension.ToLowerInvariant();
            var fullFileName = string.Format("{0}.{1}", parameters.FileName, extension);
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

        #endregion
    }
}