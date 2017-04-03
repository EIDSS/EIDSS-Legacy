using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
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
    public class ReportController : Controller
    {
        #region Common Human Reports

        public ActionResult HumDiagnosisToChangedDiagnosis()
        {
            ViewBag.GetReportActionName = "ShowHumDiagnosisToChangedDiagnosis";
            ViewBag.Title = EidssMenu.Instance.GetString("ReportsHumDiagnosisToChangedDiagnosis");
            return View("Common/BaseInterval", new BaseIntervalModel { CanWorkWithArchive = false });
        }

        public FileContentResult ShowHumDiagnosisToChangedDiagnosis(BaseIntervalModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                byte[] report = wrapper.Client.ExportHumDiagnosisToChangedDiagnosis(model);
                resultParameters = new ReportResultParameters(report, "Human_Diagnosis_To_Changed_Diagnosis",
                                                              model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        public ActionResult HumMonthlyMorbidityAndMortality()
        {
            ViewBag.GetReportActionName = "ShowHumMonthlyMorbidityAndMortality";
            ViewBag.Title = EidssMenu.Instance.GetString("ReportsHumMonthlyMorbidityAndMortality");
            return View("Common/BaseDate", new BaseDateModel { CanWorkWithArchive = false });
        }

        public FileContentResult ShowHumMonthlyMorbidityAndMortality(BaseDateModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
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

        public FileContentResult ShowHumFormN1A3(FormNo1Model model)
        {
            return ShowHumFormN1(model);
        }
        public FileContentResult ShowHumFormN1A4(FormNo1Model model)
        {
            return ShowHumFormN1(model);
        }

        public FileContentResult ShowHumFormN1(FormNo1Model model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
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
            return View("AZ/DataQualityIndicators", new DataQualityIndicatorsModel { CanWorkWithArchive = false });
        }

        public FileContentResult ShowDataQualityIndicators(DataQualityIndicatorsModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                byte[] report = wrapper.Client.ExportHumDataQualityIndicators(model);
                resultParameters = new ReportResultParameters(report, "Human_Data_Quality_Indicators",
                                                              model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        public ActionResult HumDataQualityIndicatorsRayons()
        {
            ViewBag.GetReportActionName = "ShowDataQualityIndicatorsRayons";
            ViewBag.Title = EidssMenu.Instance.GetString("HumDataQualityIndicatorsRayons");
            return View("AZ/DataQualityIndicators", new DataQualityIndicatorsModel { CanWorkWithArchive = false });
        }

        public FileContentResult ShowDataQualityIndicatorsRayons(DataQualityIndicatorsModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                byte[] report = wrapper.Client.ExportHumDataQualityIndicatorsRayons(model);
                resultParameters = new ReportResultParameters(report, "Human_Data_Quality_Indicators",
                                                              model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        public ActionResult HumSummaryByRayonDiagnosisAgeGroups()
        {
            ViewBag.GetReportActionName = "ShowHumSummaryByRayonDiagnosisAgeGroups";
            ViewBag.Title = EidssMenu.Instance.GetString("HumSummaryByRayonDiagnosisAgeGroups");
            return View("AZ/SummaryByRayonDiagnosisAgeGroups", new SummaryByRayonDiagnosisAgeGroupsModel { CanWorkWithArchive = false });
        }

        public FileContentResult ShowHumSummaryByRayonDiagnosisAgeGroups(SummaryByRayonDiagnosisAgeGroupsModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
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

        public FileContentResult ShowHumComparativeAZReport(ComparativeModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
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

        public FileContentResult ShowHumExternalComparativeReport(ExternalComparativeModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
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

        public FileContentResult ShowHumMainIndicatorsOfAFPSurveillance(AFPModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
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

        public FileContentResult ShowHumAdditionalIndicatorsOfAFPSurveillance(AFPModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
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

        public ActionResult HumWhoMeaslesRubellaReport()
        {
            ViewBag.GetReportActionName = "ShowHumWhoMeaslesRubellaReport";
            ViewBag.Title = EidssMenu.Instance.GetString("HumWhoMeaslesRubellaReport");
            return View("Common/BaseDate", new BaseDateModel());
        }

        public FileContentResult ShowHumWhoMeaslesRubellaReport(BaseDateModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
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
            var address = new AddressModel(FilterHelper.GetDefaultRegion(), FilterHelper.GetDefaultRayon());
            return View("AZ/ComparativeTwoYears", new ComparativeTwoYearsModel { Address = address });
        }

        public FileContentResult ShowHumComparativeReportOfTwoYears(ComparativeTwoYearsModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                byte[] report = wrapper.Client.ExportHumComparativeReportOfTwoYears((ComparativeTwoYearsSurrogateModel)model);
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

        public FileContentResult ShowVeterinaryCasesReportAZ(VetCasesModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
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

        public FileContentResult ShowVeterinaryLaboratoriesAZ(VetLabModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                byte[] report = wrapper.Client.ExportVeterinaryLaboratoriesAZReport((VetLabSurrogateModel)model);
                resultParameters = new ReportResultParameters(report, "Veterinary_Laboratories_Report",
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

        public FileContentResult ShowHum60BJournal(Hum60BJournalModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
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
            return View("GG/MonthInfectiousDiseaseNew", new MonthInfectiousDiseaseModel());
        }

        public FileContentResult ShowHumMonthInfectiousDiseaseNew(MonthInfectiousDiseaseModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
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

        public FileContentResult ShowHumIntermediateMonthInfectiousDiseaseNew(IntermediateInfectiousDiseaseModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                byte[] report = wrapper.Client.ExportHumIntermediateMonthInfectiousDiseaseNew(
                    (IntermediateInfectiousDiseaseSurrogateModel)
                    model);
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

        public FileContentResult ShowHumAnnualInfectiousDisease(AnnualInfectiousDiseaseModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
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

        public FileContentResult ShowHumIntermediateAnnualInfectiousDisease(IntermediateInfectiousDiseaseModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                byte[] report = wrapper.Client.ExportHumIntermediateAnnualInfectiousDisease(
                    (IntermediateInfectiousDiseaseSurrogateModel)
                    model);
                resultParameters = new ReportResultParameters(report, "Human_Intermediate_Annual_Infectious_Disease",
                                                              model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }
            return PrepareReportResult(resultParameters);
        }

        public ActionResult HumMonthInfectiousDisease()
        {
            ViewBag.GetReportActionName = "ShowHumMonthInfectiousDisease";
            ViewBag.Title = EidssMenu.Instance.GetString("ReportsHumInfectiousDiseaseMonth");
            return View("GG/MonthInfectiousDisease", new MonthInfectiousDiseaseModel());
        }

        public FileContentResult ShowHumMonthInfectiousDisease(MonthInfectiousDiseaseModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
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

        public FileContentResult ShowHumIntermediateMonthInfectiousDisease(IntermediateInfectiousDiseaseModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                byte[] report = wrapper.Client.ExportHumIntermediateMonthInfectiousDiseaseNew(
                    (IntermediateInfectiousDiseaseSurrogateModel)
                    model);
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
            return View("GG/LabSample", new LabSampleModel());
        }

        public FileContentResult ShowHumSerologyResearchCard(LabSampleModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
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
            return View("GG/LabSample", new LabSampleModel());
        }

        public FileContentResult ShowHumMicrobiologyResearchCard(LabSampleModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
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
            return View("GG/LabSample", new LabSampleModel());
        }

        public FileContentResult ShowHumAntibioticResistanceCard(LabSampleModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                byte[] report = wrapper.Client.ExportHumAntibioticResistanceCard(model);
                resultParameters = new ReportResultParameters(report, "Human_Lab_Antibiotic_Resistanc_Card",
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

        public FileContentResult ShowVetYearlySituation(BaseYearModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
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

        public FileContentResult ShowVetSamplesCount(BaseYearModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
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

        public FileContentResult ShowVetSamplesBySampleType(BaseYearModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
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

        public FileContentResult ShowVetSamplesBySampleTypesWithinRegions(BaseYearModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
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

        public FileContentResult ShowVetActiveSurveillance(BaseYearModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
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

        public FileContentResult ShowVetCountryPlannedDiagnosticTests(DiagnosticInvestigationModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
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

        public FileContentResult ShowVetOblastPlannedDiagnosticTests(DiagnosticInvestigationModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
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

        public FileContentResult ShowVetCountryPreventiveMeasures(ProphylacticModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
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

        public FileContentResult ShowVetOblastPreventiveMeasures(ProphylacticModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
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

        public FileContentResult ShowVetCountrySanitaryMeasures(SanitaryModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
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

        public FileContentResult ShowVetOblastSanitaryMeasures(SanitaryModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                byte[] report = wrapper.Client.ExportVetOblastSanitaryMeasures(model);
                resultParameters = new ReportResultParameters(report, "Veterinary_Oblast_Sanitary_Measures_Report",
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
            return View("Common/BaseInterval", new BaseIntervalModel{CanWorkWithArchive = false});
        }

        public FileContentResult ShowAdmEventLog(BaseIntervalModel model)
        {
            ReportResultParameters resultParameters;
            using (var wrapper = new ReportClientWrapper())
            {
                byte[] report = wrapper.Client.ExportAdmEventLog(model);
                resultParameters = new ReportResultParameters(report, "Administrative_Event_Log",
                                                              model.ExportFormatEnum.ToString(), model.IsOpenInNewWindow);
            }

            return PrepareReportResult(resultParameters);
        }

        #endregion

        #region Helper Methods

        private FileContentResult PrepareReportResult(ReportResultParameters parameters)
        {
            string extension = parameters.FileExtension.ToLowerInvariant();
            string fullFileName = string.Format("{0}.{1}", parameters.FileName, extension);
            if (parameters.IsOpenInNewWindow)
            {
                HttpContext.Response.ClearHeaders();
                HttpContext.Response.AddHeader("Content-Disposition", string.Format("inline; filename={0}", fullFileName));
            }
            string contentType = "application/" + extension;
            return File(parameters.FileContents, contentType, fullFileName);
        }

        #endregion
    }
}