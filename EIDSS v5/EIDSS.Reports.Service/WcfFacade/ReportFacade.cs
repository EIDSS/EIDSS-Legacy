using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Document.ActiveSurveillance;
using EIDSS.Reports.Document.Human.Aggregate;
using EIDSS.Reports.Document.Human.CaseInvestigation;
using EIDSS.Reports.Document.Human.EmergencyNotification;
using EIDSS.Reports.Document.Human.TZ;
using EIDSS.Reports.Document.Lim.Batch;
using EIDSS.Reports.Document.Lim.Case;
using EIDSS.Reports.Document.Lim.ContainerContent;
using EIDSS.Reports.Document.Lim.ContainerDetails;
using EIDSS.Reports.Document.Lim.TestResult;
using EIDSS.Reports.Document.Lim.Transfer;
using EIDSS.Reports.Document.Uni.AccessionIn;
using EIDSS.Reports.Document.Uni.Outbreak;
using EIDSS.Reports.Document.Veterinary.Aggregate;
using EIDSS.Reports.Document.Veterinary.AvianInvestigation;
using EIDSS.Reports.Document.Veterinary.LivestockInvestigation;
using EIDSS.Reports.Factory;
using EIDSS.Reports.Parameterized.ActiveSurveillance;
using EIDSS.Reports.Parameterized.Human.AJ.Reports;
using EIDSS.Reports.Parameterized.Human.DSummary;
using EIDSS.Reports.Parameterized.Human.DToChangedD;
using EIDSS.Reports.Parameterized.Human.GG.Report;
using EIDSS.Reports.Parameterized.Human.MMM;
using EIDSS.Reports.Parameterized.Uni.EventLog;
using EIDSS.Reports.Parameterized.Veterinary.KZ;
using EIDSS.Reports.Parameterized.Veterinary.SamplesCount;
using EIDSS.Reports.Parameterized.Veterinary.SamplesType;
using EIDSS.Reports.Parameterized.Veterinary.Situation;
using EIDSS.Reports.Parameterized.Veterinary.TestType;
using EIDSS.Reports.Service.Trace;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.db.Core;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.winclient.Core;
using eidss.model.Core;
using eidss.model.Core.CultureInfo;
using eidss.model.Enums;
using eidss.model.Reports;
using eidss.model.Reports.AZ;
using eidss.model.Reports.Common;
using eidss.model.Reports.GG;
using eidss.model.Reports.KZ;

namespace EIDSS.Reports.Service.WcfFacade
{
    public class ReportFacade : IReportFacade
    {
        public const string TraceTitle = "WCF Service Call";
        private static readonly TraceHelper m_Trace = new TraceHelper();

        private static readonly object m_SyncLock = new object();

        #region Export Common Human Reports

        public byte[] ExportHumAggregateCase(AggregateModel model)
        {
            ReportHelper.CreateReportDelegate cr;
            cr = (m, l) =>
                {
                    var report = new CaseAggregateReport();
                    Dictionary<string, string> ps = ReportHelper.CreateHumAggregateCaseParameters((AggregateReportParameters) model);
                    ReportHelper.AppendOrganizationIdToParameters(model, ps);
                    report.SetParameters(m, l, ps);
                    return report;
                };
            return ExportReportToBytesWrapper(cr, model);
        }

        public byte[] ExportHumAggregateCaseSummary(AggregateSummaryModel model)
        {
            ReportHelper.CreateReportDelegate cr;
            cr = (m, l) =>
                {
                    var report = new SummaryAggregateReport();
                    Dictionary<string, string> ps = ReportHelper.CreateAggrParameters(model.AggrXml);
                    ReportHelper.AppendOrganizationIdToParameters(model, ps);
                    ReportHelper.AddObservationListToParameters(model.ObservationList, ps, "@observationId");
                    report.SetParameters(m, l, ps);
                    return report;
                };
            return ExportReportToBytesWrapper(cr, model);
        }

        public byte[] ExportHumCaseInvestigation(HumIdModel model)
        {
            ReportHelper.CreateReportDelegate cr;
            cr = (m, l) =>
                {
                    var report = new CaseInvestigationReport();
                    Dictionary<string, string> ps = ReportHelper.CreateHumCaseInvestigationParameters(model.Id, model.EpiId, model.CsId,
                                                                                                      model.DiagnosisId);
                    ReportHelper.AppendOrganizationIdToParameters(model, ps);
                    report.SetParameters(m, l, ps);
                    return report;
                };
            return ExportReportToBytesWrapper(cr, model);
        }

        public byte[] ExportHumUrgentyNotification(BaseIdModel model)
        {
            ReportHelper.CreateReportDelegate cr;
            cr = (m, l) =>
                {
                    BaseDocumentReport report = (EidssSiteContext.Instance.CountryID == 2250000000)
                                                    ? (BaseDocumentReport)
                                                      new TanzaniaCaseInvestigation()
                                                    : new EmergencyNotificationReport();

                    Dictionary<string, string> ps = ReportHelper.CreateParameters(model.Id);
                    ReportHelper.AppendOrganizationIdToParameters(model, ps);
                    report.SetParameters(m, l, ps);
                    return report;
                };
            return ExportReportToBytesWrapper(cr, model);
        }

        public byte[] ExportHumDiagnosisToChangedDiagnosis(BaseIntervalModel model)
        {
            ReportHelper.CreateReportDelegate cr = (m, l) =>
                {
                    var report = new DToChangedDReport();
                    report.SetParameters(m, model);
                    return report;
                };
            return ExportReportToBytesWrapper(cr, model);
        }

        public byte[] ExportHumMonthlyMorbidityAndMortality(BaseDateModel model)
        {
            ReportHelper.CreateReportDelegate cr = (m, l) =>
                {
                    var report = new MMMReport();
                    report.SetParameters(m, model);
                    return report;
                };

            return ExportReportToBytesWrapper(cr, model);
        }

        public byte[] ExportHumSummaryOfInfectiousDiseases(BaseIntervalModel model)
        {
            ReportHelper.CreateReportDelegate cr = (m, l) =>
                {
                    var report = new DSummaryReport();
                    report.SetParameters(m, model);
                    return report;
                };
            return ExportReportToBytesWrapper(cr, model);
        }

        #endregion

        #region Human GG reports

        public byte[] ExportHumSerologyResearchCard(LabSampleModel model)
        {
            ReportHelper.CreateReportDelegate cr = (m, l) =>
                {
                    var report = new SerologyResearchCardReport();
                    report.SetParameters(m, model);
                    return report;
                };
            return ExportReportToBytesWrapper(cr, model);
        }

        public byte[] ExportHumMicrobiologyResearchCard(LabSampleModel model)
        {
            ReportHelper.CreateReportDelegate cr = (m, l) =>
                {
                    var report = new MicrobiologyResearchCardReport();
                    report.SetParameters(m, model);
                    return report;
                };
            return ExportReportToBytesWrapper(cr, model);
        }

        public byte[] ExportHumAntibioticResistanceCard(LabSampleModel model)
        {
            ReportHelper.CreateReportDelegate cr = (m, l) =>
                {
                    var report = new AntibioticResistanceCardReport();
                    report.SetParameters(m, model);
                    return report;
                };
            return ExportReportToBytesWrapper(cr, model);
        }

        public byte[] ExportHum60BJournal(Hum60BJournalModel model)
        {
            ReportHelper.CreateReportDelegate cr = (m, l) =>
                {
                    var report = new Journal60BReport();
                    report.SetParameters(m, model);
                    return report;
                };
            return ExportReportToBytesWrapper(cr, model);
        }

        public byte[] ExportHumMonthInfectiousDisease(MonthInfectiousDiseaseModel model)
        {
            ReportHelper.CreateReportDelegate cr = (m, l) =>
                {
                    var report = new InfectiousDiseasesMonth {ShowGlobalHeader = false};
                    report.SetParameters(m, model);
                    return report;
                };
            return ExportReportToBytesWrapper(cr, model);
        }

        public byte[] ExportHumMonthInfectiousDiseaseNew(MonthInfectiousDiseaseModel model)
        {
            ReportHelper.CreateReportDelegate cr;
            cr = (m, l) =>
                {
                    var report = new InfectiousDiseasesMonthNew {ShowGlobalHeader = false};
                    report.SetParameters(m, model);
                    return report;
                };
            return ExportReportToBytesWrapper(cr, model);
        }

        public byte[] ExportHumIntermediateMonthInfectiousDisease(IntermediateInfectiousDiseaseSurrogateModel model)
        {
            ReportHelper.CreateReportDelegate cr;
            cr = (m, l) =>
                {
                    var report = new InfectiousDiseasesMonth {ShowGlobalHeader = true};
                    report.SetParameters(m, model);
                    return report;
                };
            return ExportReportToBytesWrapper(cr, model);
        }

        public byte[] ExportHumIntermediateMonthInfectiousDiseaseNew(IntermediateInfectiousDiseaseSurrogateModel model)
        {
            ReportHelper.CreateReportDelegate cr;
            cr = (m, l) =>
                {
                    var report = new InfectiousDiseasesMonthNew {ShowGlobalHeader = true};
                    report.SetParameters(m, model);
                    return report;
                };
            return ExportReportToBytesWrapper(cr, model);
        }

        public byte[] ExportHumAnnualInfectiousDisease(AnnualInfectiousDiseaseModel model)
        {
            ReportHelper.CreateReportDelegate cr;
            cr = (m, l) =>
                {
                    var report = new InfectiousDiseasesYear {ShowGlobalHeader = false};
                    report.SetParameters(m, model);
                    return report;
                };
            return ExportReportToBytesWrapper(cr, model);
        }

        public byte[] ExportHumIntermediateAnnualInfectiousDisease(IntermediateInfectiousDiseaseSurrogateModel model)
        {
            ReportHelper.CreateReportDelegate cr;
            cr = (m, l) =>
                {
                    var report = new InfectiousDiseasesYear {ShowGlobalHeader = false};
                    report.SetParameters(m, model);
                    return report;
                };
            return ExportReportToBytesWrapper(cr, model);
        }

        #endregion

        #region Human AZ reports

        public byte[] ExportHumFormN1(FormNo1SurrogateModel model)
        {
            ReportHelper.CreateReportDelegate cr;
            cr = (m, l) =>
                {
                    var report = new FormN1Report(model.IsA3Format);
                    report.SetParameters(m, model);
                    return report;
                };

            return ExportReportToBytesWrapper(cr, model);
        }

        public byte[] ExportHumDataQualityIndicators(DataQualityIndicatorsModel model)
        {
            ReportHelper.CreateReportDelegate cr;
            cr = (m, l) =>
                {
                    var report = new DataQualityIndicatorsReport();
                    report.SetParameters(m, model);
                    return report;
                };
            return ExportReportToBytesWrapper(cr, model);
        }

        public byte[] ExportHumDataQualityIndicatorsRayons(DataQualityIndicatorsModel model)
        {
            ReportHelper.CreateReportDelegate cr;
            cr = (m, l) =>
                {
                    var report = new DataQualityIndicatorsRayonsReport();
                    report.SetParameters(m, model);
                    return report;
                };
            return ExportReportToBytesWrapper(cr, model);
        }

        public byte[] ExportHumSummaryByRayonDiagnosisAgeGroups(SummaryByRayonDiagnosisAgeGroupsModel model)
        {
            ReportHelper.CreateReportDelegate cr;
            cr = (m, l) =>
                {
                    var report = new SummaryReport();
                    report.SetParameters(m, model);
                    return report;
                };
            return ExportReportToBytesWrapper(cr, model);
        }

        public byte[] ExportHumComparativeAZReport(ComparativeSurrogateModel model)
        {
            ReportHelper.CreateReportDelegate cr;
            cr = (m, l) =>
                {
                    var report = new ComparativeAZReport();
                    report.SetParameters(m, model);
                    return report;
                };
            return ExportReportToBytesWrapper(cr, model);
        }

        public byte[] ExportHumExternalComparativeReport(ExternalComparativeSurrogateModel model)
        {
            ReportHelper.CreateReportDelegate cr;
            cr = (m, l) =>
                {
                    var report = new ExternalComparativeReport();
                    report.SetParameters(m, model);
                    return report;
                };
            return ExportReportToBytesWrapper(cr, model);
        }

        public byte[] ExportHumMainIndicatorsOfAFPSurveillance
            (AFPModel model)
        {
            ReportHelper.CreateReportDelegate cr;
            cr = (m, l) =>
                {
                    var report = new MainAFPIndicatorsReport();
                    report.SetParameters(m, model);
                    return report;
                };
            return ExportReportToBytesWrapper(cr, model);
        }

        public byte[] ExportHumAdditionalIndicatorsOfAFPSurveillance
            (AFPModel model)
        {
            ReportHelper.CreateReportDelegate cr;
            cr = (m, l) =>
                {
                    var report = new AdditionalAFPIndicatorsReport();
                    report.SetParameters(m, model);
                    return report;
                };
            return ExportReportToBytesWrapper(cr, model);
        }

        public byte[] ExportHumWhoMeaslesRubellaReport(BaseDateModel model)
        {
            ReportHelper.CreateReportDelegate cr;
            cr = (m, l) =>
                {
                    var report = new WhoMeaslesRubellaReport();
                    report.SetParameters(m, model);
                    return report;
                };
            return ExportReportToBytesWrapper(cr, model);
        }

        public byte[] ExportHumComparativeReportOfTwoYears(ComparativeTwoYearsSurrogateModel model)
        {
            ReportHelper.CreateReportDelegate cr;
            cr = (m, l) =>
            {
                var report = new ComparativeTwoYearsAZReport();
                report.SetParameters(m, model);
                return report;
            };
            return ExportReportToBytesWrapper(cr, model);
        }

        #endregion

        #region Veterinary AZ reports

        public byte[] ExportVeterinaryCasesReport(VetCasesSurrogateModel model)
        {
            ReportHelper.CreateReportDelegate cr;
            cr = (m, l) =>
                {
                    var report = new VetCaseReport();
                    report.SetParameters(m, model);
                    return report;
                };
            return ExportReportToBytesWrapper(cr, model);
        }

        public byte[] ExportVeterinaryLaboratoriesAZReport(VetLabSurrogateModel model)
        {
            ReportHelper.CreateReportDelegate cr;
            cr = (m, l) =>
            {
                var report = new VetLabReport();
                report.SetParameters(m, model);
                return report;
            };
            return ExportReportToBytesWrapper(cr, model);
        }

        #endregion

        #region Veterinary reports

        public byte[] ExportVetAggregateCase(AggregateModel model)
        {
            ReportHelper.CreateReportDelegate cr;
            cr = (m, l) =>
                {
                    Dictionary<string, string> ps = ReportHelper.CreateVetAggregateCaseParameters((AggregateReportParameters) model);
                    ReportHelper.AppendOrganizationIdToParameters(model, ps);
                    var report = new VetAggregateReport();
                    report.SetParameters(m, l, ps);
                    return report;
                };
            return ExportReportToBytesWrapper(cr, model);
        }

        public byte[] ExportVetAggregateCaseSummary(AggregateSummaryModel model)
        {
            ReportHelper.CreateReportDelegate cr;
            cr = (m, l) =>
                {
                    Dictionary<string, string> ps = ReportHelper.CreateAggrParameters(model.AggrXml);
                    ReportHelper.AddObservationListToParameters(model.ObservationList, ps, "@observationId");
                    ReportHelper.AppendOrganizationIdToParameters(model, ps);
                    var report = new VetAggregateCaseSummaryReport();
                    report.SetParameters(m, l, ps);
                    return report;
                };
            return ExportReportToBytesWrapper(cr, model);
        }

        public byte[] ExportVetAggregateCaseActions(AggregateActionsModel model)
        {
            ReportHelper.CreateReportDelegate cr;
            cr = (m, l) =>
                {
                    Dictionary<string, string> ps = ReportHelper.CreateVetAggregateCaseActionsParameters((AggregateActionsParameters) model);
                    ReportHelper.AppendOrganizationIdToParameters(model, ps);
                    var report = new VetAggregateActionsReport();
                    report.SetParameters(m, l, ps);
                    return report;
                };
            return ExportReportToBytesWrapper(cr, model);
        }

        public byte[] ExportVetAggregateCaseActionsSummary(AggregateActionsSummaryModel model)
        {
            ReportHelper.CreateReportDelegate cr;
            cr = (m, l) =>
                {
                    Dictionary<string, string> ps =
                        ReportHelper.CreateVetAggregateCaseActionsSummaryPs((AggregateActionsSummaryParameters) model);
                    ReportHelper.AppendOrganizationIdToParameters(model, ps);
                    var report = new VetAggregateActionsSummaryReport();
                    report.SetParameters(m, l, ps);
                    return report;
                };
            return ExportReportToBytesWrapper(cr, model);
        }

        public byte[] ExportVetAvianInvestigation(VetIdModel model)
        {
            ReportHelper.CreateReportDelegate cr;
            cr = (m, l) =>
                {
                    Dictionary<string, string> ps = ReportHelper.CreateParameters(model.Id);
                    ReportHelper.AppendOrganizationIdToParameters(model, ps);
                    ps.Add("@DiagnosisID", model.DiagnosisId.ToString(CultureInfo.InvariantCulture));
                    var report = new AvianInvestigationReport();
                    report.SetParameters(m, l, ps);
                    return report;
                };
            return ExportReportToBytesWrapper(cr, model);
        }

        public byte[] ExportVetLivestockInvestigation(VetIdModel model)
        {
            ReportHelper.CreateReportDelegate cr;
            cr = (m, l) =>
                {
                    Dictionary<string, string> ps = ReportHelper.CreateParameters(model.Id);
                    ReportHelper.AppendOrganizationIdToParameters(model, ps);
                    ps.Add("@DiagnosisID", model.DiagnosisId.ToString(CultureInfo.InvariantCulture));
                    var report = new LivestockInvestigationReport();
                    report.SetParameters(m, l, ps);
                    return report;
                };
            return ExportReportToBytesWrapper(cr, model);
        }

        public byte[] ExportVetActiveSurveillanceSampleCollected(BaseIdModel model)
        {
            ReportHelper.CreateReportDelegate cr = (m, l) =>
                {
                    Dictionary<string, string> ps = ReportHelper.CreateParameters(model.Id);
                    ReportHelper.AppendOrganizationIdToParameters(model, ps);
                    var report = new SessionReport();
                    report.SetParameters(m, l, ps);
                    return report;
                };
            return ExportReportToBytesWrapper(cr, model);
        }

        public byte[] ExportVetSamplesCount(BaseYearModel model)
        {
            ReportHelper.CreateReportDelegate cr = (m, l) =>
                {
                    var report = new VetSamplesCountReport();
                    report.SetParameters(m, model);
                    return report;
                };
            return ExportReportToBytesWrapper(cr, model);
        }

        public byte[] ExportVetSamplesBySampleType(BaseYearModel model)
        {
            ReportHelper.CreateReportDelegate cr = (m, l) =>
                {
                    var report = new VetSamplesTypeReport();
                    report.SetParameters(m, model);
                    return report;
                };
            return ExportReportToBytesWrapper(cr, model);
        }

        public byte[] ExportVetSamplesBySampleTypesWithinRegions(BaseYearModel model)
        {
            ReportHelper.CreateReportDelegate cr = (m, l) =>
                {
                    var report = new VetTestTypeReport();
                    report.SetParameters(m, model);
                    return report;
                };
            return ExportReportToBytesWrapper(cr, model);
        }

        public byte[] ExportVetYearlySituation(BaseYearModel model)
        {
            ReportHelper.CreateReportDelegate cr = (m, l) =>
                {
                    var report = new VetSituationReport();
                    report.SetParameters(m, model);
                    return report;
                };
            return ExportReportToBytesWrapper(cr, model);
        }

        public byte[] ExportVetActiveSurveillance(BaseYearModel model)
        {
            ReportHelper.CreateReportDelegate cr = (m, l) =>
                {
                    var report = new ActiveSurveillanceReport();
                    report.SetParameters(m, model);
                    return report;
                };
            return ExportReportToBytesWrapper(cr, model);
        }

        #endregion

        #region KZ Veterinary reports

        public byte[] ExportVetCountryPreventiveMeasures(ProphylacticModel model)
        {
            ReportHelper.CreateReportDelegate cr = (m, l) =>
                {
                    var report = new VetCountryPreventiveMeasures();
                    report.SetParameters(m, model);
                    return report;
                };
            return ExportReportToBytesWrapper(cr, model);
        }

        public byte[] ExportVetCountrySanitaryMeasures(SanitaryModel model)
        {
            ReportHelper.CreateReportDelegate cr = (m, l) =>
                {
                    var report = new VetCountryProphilacticMeasures();
                    report.SetParameters(m, model);
                    return report;
                };
            return ExportReportToBytesWrapper(cr, model);
        }

        public byte[] ExportVetCountryPlannedDiagnosticTests
            (DiagnosticInvestigationModel model)
        {
            ReportHelper.CreateReportDelegate cr = (m, l) =>
                {
                    var report = new VetCountryPlannedDiagnostic();
                    report.SetParameters(m, model);
                    return report;
                };
            return ExportReportToBytesWrapper(cr, model);
        }

        public byte[] ExportVetOblastPreventiveMeasures(ProphylacticModel model)
        {
            ReportHelper.CreateReportDelegate cr = (m, l) =>
                {
                    var report = new VetRegionPreventiveMeasures();
                    report.SetParameters(m, model);
                    return report;
                };
            return ExportReportToBytesWrapper(cr, model);
        }

        public byte[] ExportVetOblastSanitaryMeasures(SanitaryModel model)
        {
            ReportHelper.CreateReportDelegate cr = (m, l) =>
                {
                    var report = new VetRegionProphilacticMeasures();
                    report.SetParameters(m, model);
                    return report;
                };
            return ExportReportToBytesWrapper(cr, model);
        }

        public byte[] ExportVetOblastPlannedDiagnosticTests(DiagnosticInvestigationModel model)
        {
            ReportHelper.CreateReportDelegate cr = (m, l) =>
                {
                    var report = new VetRegionPlannedDiagnostic();
                    report.SetParameters(m, model);
                    return report;
                };
            return ExportReportToBytesWrapper(cr, model);
        }

        #endregion

        #region Lab module reports

        public byte[] ExportLimTestResult(LimTestResultModel model)
        {
            ReportHelper.CreateReportDelegate cr;
            cr = (m, l) =>
                {
                    Dictionary<string, string> ps = ReportHelper.CreateLimTestResultParameters(model.Id, model.CsId, model.TypeId);
                    ReportHelper.AppendOrganizationIdToParameters(model, ps);
                    var report = new TestResultReport();
                    report.SetParameters(m, l, ps);
                    return report;
                };
            return ExportReportToBytesWrapper(cr, model);
        }

        public byte[] ExportLimSampleTransfer(BaseIdModel model)
        {
            ReportHelper.CreateReportDelegate cr;
            cr = (m, l) =>
                {
                    Dictionary<string, string> ps = ReportHelper.CreateParameters(model.Id);
                    ReportHelper.AppendOrganizationIdToParameters(model, ps);

                    var report = new TransferReport();
                    report.SetParameters(m, l, ps);
                    return report;
                };
            return ExportReportToBytesWrapper(cr, model);
        }

        public byte[] ExportLimTest(LimTestModel model)
        {
            ReportHelper.CreateReportDelegate cr;
            cr = (m, l) =>
                {
                    Dictionary<string, string> ps = ReportHelper.CreateParameters(model.Id);
                    ReportHelper.AppendOrganizationIdToParameters(model, ps);

                    var report = new TestReport();
                    ps.Add("@IsHuman", model.IsHuman.ToString(CultureInfo.InvariantCulture));
                    report.SetParameters(m, l, ps);
                    return report;
                };
            return ExportReportToBytesWrapper(cr, model);
        }

        public byte[] ExportLimBatchTest(LimBatchTestModel model)
        {
            ReportHelper.CreateReportDelegate cr;
            cr = (m, l) =>
                {
                    Dictionary<string, string> ps = ReportHelper.CreateParameters(model.Id);
                    ReportHelper.AppendOrganizationIdToParameters(model, ps);
                    ps.Add("@TypeID", model.TypeId.ToString(CultureInfo.InvariantCulture));
                    var report = new BatchTestReport();
                    report.SetParameters(m, l, ps);
                    return report;
                };
            return ExportReportToBytesWrapper(cr, model);
        }

        public byte[] ExportLimContainerDetails(BaseIdModel model)
        {
            ReportHelper.CreateReportDelegate cr;
            cr = (m, l) =>
                {
                    Dictionary<string, string> ps = ReportHelper.CreateParameters(model.Id);
                    ReportHelper.AppendOrganizationIdToParameters(model, ps);
                    var report = new ContainerDetailsReport();
                    report.SetParameters(m, l, ps);
                    return report;
                };
            return ExportReportToBytesWrapper(cr, model);
        }

        public byte[] ExportLimContainerContent(LimContainerContentModel model)
        {
            ReportHelper.CreateReportDelegate cr;
            cr = (m, l) =>
                {
                    Dictionary<string, string> ps =
                        ReportHelper.CreateLimContainerContentParameters(model.ContainerId, model.FreezerId);
                    ReportHelper.AppendOrganizationIdToParameters(model, ps);
                    var report = new ContainerContentReport();
                    report.SetParameters(m, l, ps);
                    return report;
                };
            return ExportReportToBytesWrapper(cr, model);
        }

        public byte[] ExportLimAccessionIn(BaseIdModel model)
        {
            ReportHelper.CreateReportDelegate cr;
            cr = (m, l) =>
                {
                    Dictionary<string, string> ps = ReportHelper.CreateParameters(model.Id);
                    ReportHelper.AppendOrganizationIdToParameters(model, ps);

                    var report = new AccessionInReport();
                    report.SetParameters(m, l, ps);
                    return report;
                };
            return ExportReportToBytesWrapper(cr, model);
        }

        #endregion

        #region  Outbreak reports

        public byte[] ExportOutbreak(BaseIdModel model)
        {
            ReportHelper.CreateReportDelegate cr;
            cr = (m, l) =>
                {
                    Dictionary<string, string> ps = ReportHelper.CreateParameters(model.Id);
                    ReportHelper.AppendOrganizationIdToParameters(model, ps);
                    var report = new OutbreakReport();
                    report.SetParameters(m, l, ps);
                    return report;
                };
            return ExportReportToBytesWrapper(cr, model);
        }

        #endregion

        #region Administrative reports

        public byte[] ExportAdmEventLog(BaseIntervalModel model)
        {
            ReportHelper.CreateReportDelegate cr = (m, l) =>
                {
                    var report = new EventLogReport();
                    report.SetParameters(m, model);
                    return report;
                };
            return ExportReportToBytesWrapper(cr, model);
        }

        #endregion

        #region Vector Surveillance reports

        public byte[] ExportVectorSurveillanceSessionSummary(BaseIdModel model)
        {
            ReportHelper.CreateReportDelegate cr = (m, l) =>
            {
                Dictionary<string, string> ps = ReportHelper.CreateParameters(model.Id);
                ReportHelper.AppendOrganizationIdToParameters(model, ps);
                var report = new Document.VectorSurveillance.SessionReport();
                report.SetParameters(m, l, ps);
                return report;
            };
            return ExportReportToBytesWrapper(cr, model);
        }

        #endregion

        public Version GetServiceVersion()
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            return asm.GetName().Version;
        }

        #region Helper Methods

        private byte[] ExportReportToBytesWrapper(ReportHelper.CreateReportDelegate cr, BaseModel model)
        {
            TraceMethodCall(Utils.GetPreviousMethodName(), model);
            try
            {
                return ExportReportToBytes(model, cr);
            }
            catch (Exception ex)
            {
                TraceMethodException(ex, Utils.GetPreviousMethodName(), model);
                WrapSqlException(ex);
                throw;
            }
        }

        private static byte[] ExportReportToBytes(BaseModel model, ReportHelper.CreateReportDelegate createReport)
        {
            Utils.CheckNotNull(createReport, "createReport");

            Utils.CheckNotNullOrEmpty(model.Language, "parameters.Language");

            string lang = model.Language; //.ToLower();
            if (!CultureInfoEx.ExistingLanguages.ContainsKey(lang))
            {
                throw new ArgumentException(String.Format("Language {0} is not supported", lang));
            }

            byte[] bytes;

            lock (m_SyncLock)
            {
                EidssUserContext.User.SetForbiddenPersonalDataGroups(model.ForbiddenGroups ?? new List<PersonalDataGroup>());
                using (new CultureInfoTransaction(new CultureInfo(CultureInfoEx.ExistingLanguages[lang])))
                {
                    Config.ReloadSettings();
                    ConnectionCredentials credentials;
                    if (model.UseArchive)
                    {
                        credentials = new ConnectionCredentials(null, "Archive");
                        ConnectionManager.DefaultInstance.SetCredentials(null, null, null, null, null, "Archive");
                    }
                    else
                    {
                        credentials = new ConnectionCredentials();
                        ConnectionManager.DefaultInstance.SetCredentials();
                    }

                    DbManagerFactory.SetSqlFactory(credentials.ConnectionString);
                    using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    {
                        using (BaseReport report = createReport(manager, model.Language))
                        {
                            if (report.ChildReport != null)
                            {
                                report.CreateDocument();
                                report.ChildReport.CreateDocument();
                                report.Pages.AddRange(report.ChildReport.Pages);
                                report.PrintingSystem.ContinuousPageNumbering = true;
                            }

                            bytes = report.ExportToBytes(model.ExportFormatEnum);
                        }
                    }
                }
            }
            return bytes;
        }

        public static void TraceMethodCall(string methodName, params object[] value)
        {
            string parameters = BuildParams(value);
            string message = String.Format("{0}({1})", methodName, parameters);
            m_Trace.Trace(new Dictionary<string, object>(), TraceTitle, message);
        }

        public static void TraceMethodException(Exception ex, string methodName, params object[] value)
        {
            string parameters = BuildParams(value);
            string title = String.Format("{0} - Error while executing method {1}({2})",
                                         TraceTitle, methodName, parameters);
            m_Trace.TraceError(ex, new Dictionary<string, object>(), title);
        }

        public static void WrapSqlException(Exception ex)
        {
            string description = SqlExceptionHandler.GetExceptionDescription(ex);
            if (!String.IsNullOrEmpty(description))
            {
                throw new ReportDataException(description, ex);
            }
        }

        private static string BuildParams(IEnumerable<object> value)
        {
            var paramsBuilder = new StringBuilder();
            if (value != null)
            {
                foreach (object parameter in value)
                {
                    object printableParam = (parameter is IEnumerable<object>)
                                                ? BuildParams((IEnumerable<object>) parameter)
                                                : parameter ?? "NULL";
                    paramsBuilder.AppendFormat("{0}, ", printableParam);
                }
            }
            return paramsBuilder.ToString();
        }

        #endregion
    }
}