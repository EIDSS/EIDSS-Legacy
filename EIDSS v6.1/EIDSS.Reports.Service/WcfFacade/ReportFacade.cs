using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.db.Core;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.model.Model.Validators;
using bv.winclient.Core;
using eidss.model.Core;
using eidss.model.Core.CultureInfo;
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
using eidss.model.Trace;
using EIDSS.Reports.Barcode;
using EIDSS.Reports.BaseControls;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Document.ActiveSurveillance;
using EIDSS.Reports.Document.Human.Aggregate;
using EIDSS.Reports.Document.Human.CaseInvestigation;
using EIDSS.Reports.Document.Human.EmergencyNotification;
using EIDSS.Reports.Document.Human.TZ;
using EIDSS.Reports.Document.Lim.Batch;
using EIDSS.Reports.Document.Lim.Case;
using EIDSS.Reports.Document.Lim.ContainerDetails;
using EIDSS.Reports.Document.Lim.SampleDestruction;
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
using EIDSS.Reports.Parameterized.Human.ARM.Report;
using EIDSS.Reports.Parameterized.Human.DToChangedD;
using EIDSS.Reports.Parameterized.Human.GG.Report;
using EIDSS.Reports.Parameterized.Human.IQ.Reports;
using EIDSS.Reports.Parameterized.Human.KZ;
using EIDSS.Reports.Parameterized.Human.MMM;
using EIDSS.Reports.Parameterized.Human.TH.Reports;
using EIDSS.Reports.Parameterized.Uni.EventLog;
using EIDSS.Reports.Parameterized.Veterinary.KZ;
using EIDSS.Reports.Parameterized.Veterinary.SamplesCount;
using EIDSS.Reports.Parameterized.Veterinary.SamplesType;
using EIDSS.Reports.Parameterized.Veterinary.Situation;
using EIDSS.Reports.Parameterized.Veterinary.TestType;
using SampleReport = EIDSS.Reports.Document.Lim.ContainerContent.ContainerContentReport;

namespace EIDSS.Reports.Service.WcfFacade
{
    public class ReportFacade : IReportFacade
    {
        public const string TraceTitle = "WCF Service Call";
        private static readonly TraceHelper m_Trace = new TraceHelper(TraceHelper.ReportsCategory);

        private static readonly object m_SyncLock = new object();
        private static volatile bool m_Initialized;

        #region Export Common Human Reports

        public byte[] ExportHumAggregateCase(AggregateModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);
                ReportHelper.CreateReportDelegate cr;
                cr = (l, m, am) =>
                {
                    var report = new CaseAggregateReport();
                    Dictionary<string, string> ps = ReportHelper.CreateHumAggregateCaseParameters((AggregateReportParameters) model);
                    ReportHelper.AppendOrganizationIdToParameters(model, ps);
                    report.SetParameters(l, ps, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportHumAggregateCaseSummary(AggregateSummaryModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);
                ReportHelper.CreateReportDelegate cr;
                cr = (l, m, am) =>
                {
                    var report = new SummaryAggregateReport();
                    Dictionary<string, string> ps = ReportHelper.CreateAggrParameters(model.AggrXml);
                    ReportHelper.AppendOrganizationIdToParameters(model, ps);
                    ReportHelper.AddObservationListToParameters(model.ObservationList, ps, "@observationId");
                    report.SetParameters(l, ps, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportHumCaseInvestigation(HumIdModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr;
                cr = (l, m, am) =>
                {
                    var report = new CaseInvestigationReport();
                    Dictionary<string, string> ps = ReportHelper.CreateHumCaseInvestigationParameters(model.Id, model.EpiId, model.CsId,
                        model.DiagnosisId);
                    ReportHelper.AppendOrganizationIdToParameters(model, ps);
                    report.SetParameters(l, ps, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportHumUrgentyNotification(BaseIdModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr;
                cr = (l, m, am) =>
                {
                    BaseDocumentReport report = new EmergencyNotificationReport();

                    Dictionary<string, string> ps = ReportHelper.CreateParameters(model.Id);
                    ReportHelper.AppendOrganizationIdToParameters(model, ps);
                    report.SetParameters(l, ps, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportHumUrgentyNotificationDTRA(BaseIdModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr;
                cr = (l, m, am) =>
                {
                    BaseDocumentReport report = new EmergencyNotificationDTRAReport();

                    Dictionary<string, string> ps = ReportHelper.CreateParameters(model.Id);
                    ReportHelper.AppendOrganizationIdToParameters(model, ps);
                    report.SetParameters(l, ps, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportHumUrgentyNotificationTanzania(BaseIdModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr;
                cr = (l, m, am) =>
                {
                    BaseDocumentReport report = new TanzaniaCaseInvestigation();

                    Dictionary<string, string> ps = ReportHelper.CreateParameters(model.Id);
                    ReportHelper.AppendOrganizationIdToParameters(model, ps);
                    report.SetParameters(l, ps, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportHumDiagnosisToChangedDiagnosis(DToChangedDSurrogateModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr = (l, m, am) =>
                {
                    var report = new DToChangedDReport();
                    report.SetParameters(model, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportHumMonthlyMorbidityAndMortality(BaseDateModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr = (l, m, am) =>
                {
                    var report = new MMMReport();
                    report.SetParameters(model, m, am);
                    return report;
                };

                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        #endregion

        #region Human GG reports

        public byte[] ExportHumSerologyResearchCard(HumanLabSampleModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr = (l, m, am) =>
                {
                    var report = new SerologyResearchCardReport();
                    report.SetParameters(model, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportHumMicrobiologyResearchCard(HumanLabSampleModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr = (l, m, am) =>
                {
                    var report = new MicrobiologyResearchCardReport();
                    report.SetParameters(model, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportHumAntibioticResistanceCard(HumanLabSampleModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr = (l, m, am) =>
                {
                    var report = new AntibioticResistanceCardReport();
                    report.SetParameters(model, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportHumAntibioticResistanceCardLma(VetLabSampleModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr = (l, m, am) =>
                {
                    var report = new AntibioticResistanceCardReport();
                    report.SetParameters(model, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportHum60BJournal(Hum60BJournalModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr = (l, m, am) =>
                {
                    var report = new Journal60BReport();
                    report.SetParameters(model, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportHumMonthInfectiousDiseaseV4(MonthInfectiousDiseaseModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr = (l, m, am) =>
                {
                    var report = new InfectiousDiseasesMonthV4 {ShowGlobalHeader = false};
                    report.SetParameters(model, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportHumMonthInfectiousDiseaseV5(MonthInfectiousDiseaseModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr;
                cr = (l, m, am) =>
                {
                    var report = new InfectiousDiseasesMonthV5 {ShowGlobalHeader = false};
                    report.SetParameters(model, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportHumMonthInfectiousDiseaseV6(MonthInfectiousDiseaseModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr;
                cr = (l, m, am) =>
                {
                    var report = new InfectiousDiseasesMonthV6 {ShowGlobalHeader = false};
                    report.SetParameters(model, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportHumMonthInfectiousDiseaseV61(MonthInfectiousDiseaseModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr;
                cr = (l, m, am) =>
                {
                    var report = new InfectiousDiseasesMonthV6 { ShowGlobalHeader = false };
                    report.SetParameters(model, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportHumIntermediateMonthInfectiousDiseaseV4(IntermediateInfectiousDiseaseSurrogateModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr;
                cr = (l, m, am) =>
                {
                    var report = new InfectiousDiseasesMonthV4 {ShowGlobalHeader = true};
                    report.SetParameters(model, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportHumIntermediateMonthInfectiousDiseaseV5(IntermediateInfectiousDiseaseSurrogateModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr;
                cr = (l, m, am) =>
                {
                    var report = new InfectiousDiseasesMonthV5 {ShowGlobalHeader = true};
                    report.SetParameters(model, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportHumIntermediateMonthInfectiousDiseaseV6(IntermediateInfectiousDiseaseSurrogateModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr;
                cr = (l, m, am) =>
                {
                    var report = new InfectiousDiseasesMonthV6 {ShowGlobalHeader = true};
                    report.SetParameters(model, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }
        public byte[] ExportHumIntermediateMonthInfectiousDiseaseV61(IntermediateInfectiousDiseaseSurrogateModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr;
                cr = (l, m, am) =>
                {
                    var report = new InfectiousDiseasesMonthV61 { ShowGlobalHeader = true };
                    report.SetParameters(model, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportHumAnnualInfectiousDisease(AnnualInfectiousDiseaseModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr;
                cr = (l, m, am) =>
                {
                    var report = new InfectiousDiseasesYear {ShowGlobalHeader = false};
                    report.SetParameters(model, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportHumIntermediateAnnualInfectiousDisease(IntermediateInfectiousDiseaseSurrogateModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr;
                cr = (l, m, am) =>
                {
                    var report = new InfectiousDiseasesYear {ShowGlobalHeader = true};
                    report.SetParameters(model, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        #endregion

        #region Vet GG reports

        public byte[] ExportVetRabiesBulletinEurope(RBESurrogateModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr;
                cr = (l, m, am) =>
                {
                    var report = new RBEReport();
                    report.SetParameters(model, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportVetLaboratoryResearchResult(VetLaboratoryResearchResultModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr;
                cr = (l, m, am) =>
                {
                    var report = new LaboratoryResearchReport();
                    report.SetParameters(model, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        #endregion

        #region Human AZ reports

        public byte[] ExportHumFormN1(FormNo1SurrogateModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr;
                cr = (l, m, am) =>
                {
                    var report = new FormN1Report();
                    report.SetParameters(model, m, am);

                    return report;
                };

                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportHumDataQualityIndicators(DataQualityIndicatorsSurrogateModel surrogateModel)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, surrogateModel);

                ReportHelper.CreateReportDelegate cr;
                cr = (l, m, am) =>
                {
                    var report = new DataQualityIndicatorsReport();
                    report.SetParameters(surrogateModel, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, surrogateModel);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, surrogateModel);
                throw;
            }
        }

        public byte[] ExportHumDataQualityIndicatorsRayons(DataQualityIndicatorsSurrogateModel surrogateModel)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, surrogateModel);

                ReportHelper.CreateReportDelegate cr;
                cr = (l, m, am) =>
                {
                    var report = new DataQualityIndicatorsRayonsReport();
                    report.SetParameters(surrogateModel, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, surrogateModel);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, surrogateModel);
                throw;
            }
        }

        public byte[] ExportHumSummaryByRayonDiagnosisAgeGroups(SummaryByRayonDiagnosisModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);
                ReportHelper.CreateReportDelegate cr;
                cr = (l, m, am) =>
                {
                    var report = new HumSummaryReport();
                    report.SetParameters(model, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportHumComparativeAZReport(ComparativeSurrogateModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr;
                cr = (l, m, am) =>
                {
                    var report = new ComparativeAZReport();
                    report.SetParameters(model, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportHumExternalComparativeReport(ExternalComparativeSurrogateModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr;
                cr = (l, m, am) =>
                {
                    var report = new ExternalComparativeReport();
                    report.SetParameters(model, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportHumMainIndicatorsOfAFPSurveillance
            (AFPModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr;
                cr = (l, m, am) =>
                {
                    var report = new MainAFPIndicatorsReport();
                    report.SetParameters(model, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportHumAdditionalIndicatorsOfAFPSurveillance
            (AFPModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr;
                cr = (l, m, am) =>
                {
                    var report = new AdditionalAFPIndicatorsReport();
                    report.SetParameters(model, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportHumWhoMeaslesRubellaReport(WhoMeaslesRubellaModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr;
                cr = (l, m, am) =>
                {
                    var report = new WhoMeaslesRubellaReport();
                    report.SetParameters(model, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportHumComparativeReportOfTwoYears(ComparativeTwoYearsSurrogateModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);
                ReportHelper.CreateReportDelegate cr;
                cr = (l, m, am) =>
                {
                    var report = new ComparativeTwoYearsAZReport();
                    report.SetParameters(model, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportHumBorderRayonsComparativeReport(BorderRayonsSurrogateModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr;
                cr = (l, m, am) =>
                {
                    var report = new BorderRayonsComparativeAZReport();
                    report.SetParameters(model, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportHumTuberculosisCasesTested(TuberculosisSurrogateModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr;
                cr = (l, m, am) =>
                {
                    var report = new TuberculosisCasesTestedReport();
                    report.SetParameters(model, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportLabTestingResultsAZ(LabTestingTesultsModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr = (l, m, am) =>
                {
                    var report = new LabTestingTesultsReportNew();
                    report.SetParameters(model, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportAssignmentLabDiagnosticAZ(AssignmentLabDiagnosticModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr = (l, m, am) =>
                {
                    var report = new AssignmentLabDiagnosticReportNew();
                    report.SetParameters(model, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        #endregion

        #region Zoonotic AZ reports

        public byte[] ExportZoonoticComparativeAZ(ZoonoticSurrogateModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr;
                cr = (l, m, am) =>
                {
                    var report = new ZoonoticAZReport();
                    report.SetParameters(model, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        #endregion

        #region Human IQ reports

        public byte[] ExportHumComparativeIQReport(ComparativeSurrogateModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr;
                cr = (l, m, am) =>
                {
                    var report = new ComparativeIQReport();
                    report.SetParameters(model, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportWeeklySituationDiseasesByAgeGroupAndSex(SituationOnInfectiousDiseasesSurrogateModel model)
        {
            return ExportSituationDiseasesByAgeGroupAndSex(model);
        }

        public byte[] ExportMonthlySituationDiseasesByAgeGroupAndSex(SituationOnInfectiousDiseasesSurrogateModel model)
        {
            return ExportSituationDiseasesByAgeGroupAndSex(model);
        }

        private byte[] ExportSituationDiseasesByAgeGroupAndSex(SituationOnInfectiousDiseasesSurrogateModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr;
                cr = (l, m, am) =>
                {
                    var report = new DiseasesByAgeGroupAndSexReport();
                    report.SetParameters(model, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportWeeklySituationDiseasesByDistricts(SituationOnInfectiousDiseasesSurrogateModel model)
        {
            return ExportSituationDiseasesByDistricts(model);
        }

        public byte[] ExportMonthlySituationDiseasesByDistricts(SituationOnInfectiousDiseasesSurrogateModel model)
        {
            return ExportSituationDiseasesByDistricts(model);
        }

        private byte[] ExportSituationDiseasesByDistricts(SituationOnInfectiousDiseasesSurrogateModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr;
                cr = (l, m, am) =>
                {
                    var report = new DiseasesByDistrictsReport();
                    report.SetParameters(model, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        #endregion

        #region Veterinary AZ reports

        public byte[] ExportVeterinaryCasesReport(VetCasesSurrogateModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr;
                cr = (l, m, am) =>
                {
                    var report = new VetCaseReport();
                    report.SetParameters(model, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportVeterinaryLaboratoriesAZReport(VetLabSurrogateModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr;
                cr = (l, m, am) =>
                {
                    var report = new VetLabReport();
                    report.SetParameters(model, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportVeterinaryFormVet1(VetCasesSurrogateModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr;
                cr = (l, m, am) =>
                {
                    var report = new FormVet1();
                    report.SetParameters(model, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportVeterinaryFormVet1A(VetCasesSurrogateModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr;
                cr = (l, m, am) =>
                {
                    var report = new FormVet1A();
                    report.SetParameters(model, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportVeterinarySummaryAZ(VetSummaryModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);
                ReportHelper.CreateReportDelegate cr;
                cr = (l, m, am) =>
                {
                    var report = new VetSummaryReport();
                    report.SetParameters(model, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        #endregion

        #region TH reports

        public byte[] ExportHumComparativeReportOfSeveralYearsTH(ComparativeSeveralYearsTHSurrogateModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);
                ReportHelper.CreateReportDelegate cr;
                cr = (l, m, am) =>
                {
                    var report = new ComparativeSeveralYearsTHReport();
                    report.SetParameters(model, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportHumNumberOfCasesDeathsMorbidityMortalityTH(NumberOfCasesDeathsMorbidityMortalityTHModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);
                ReportHelper.CreateReportDelegate cr;
                cr = (l, m, am) =>
                {
                    var report = new NumberOfCasesDeathsMorbidityMortalityTHReport();
                    report.SetParameters(model, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportHumNumberOfCasesDeathsMonthTH(NumberOfCasesDeathsMonthTHModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);
                ReportHelper.CreateReportDelegate cr;
                cr = (l, m, am) =>
                {
                    var report = new NumberOfCasesDeathsMonthTHReport();
                    report.SetParameters(model, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        #endregion

        #region ARM reports

        public byte[] ExportHumFormN85ARM(FormN85SurrogateModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);
                ReportHelper.CreateReportDelegate cr;
                cr = (l, m, am) =>
                {
                    var report = new FormN85JointReport();
                    report.SetParameters(model, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        #endregion

        #region Veterinary reports

        public byte[] ExportVetAggregateCase(AggregateModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr;
                cr = (l, m, am) =>
                {
                    Dictionary<string, string> ps = ReportHelper.CreateVetAggregateCaseParameters((AggregateReportParameters) model);
                    ReportHelper.AppendOrganizationIdToParameters(model, ps);
                    var report = new VetAggregateReport();
                    report.SetParameters(l, ps, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportVetAggregateCaseSummary(AggregateSummaryModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr;
                cr = (l, m, am) =>
                {
                    Dictionary<string, string> ps = ReportHelper.CreateAggrParameters(model.AggrXml);
                    ReportHelper.AddObservationListToParameters(model.ObservationList, ps, "@observationId");
                    ReportHelper.AppendOrganizationIdToParameters(model, ps);
                    var report = new VetAggregateCaseSummaryReport();
                    report.SetParameters(l, ps, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportVetAggregateCaseActions(AggregateActionsModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);
                ReportHelper.CreateReportDelegate cr;
                cr = (l, m, am) =>
                {
                    Dictionary<string, string> ps = ReportHelper.CreateVetAggregateCaseActionsParameters((AggregateActionsParameters) model);
                    ReportHelper.AppendOrganizationIdToParameters(model, ps);
                    var report = new VetAggregateActionsReport();
                    report.SetParameters(l, ps, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportVetAggregateCaseActionsSummary(AggregateActionsSummaryModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr;
                cr = (l, m, am) =>
                {
                    Dictionary<string, string> ps =
                        ReportHelper.CreateVetAggregateCaseActionsSummaryPs((AggregateActionsSummaryParameters) model);
                    ReportHelper.AppendOrganizationIdToParameters(model, ps);
                    var report = new VetAggregateActionsSummaryReport();
                    report.SetParameters(l, ps, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportVetAvianInvestigation(VetIdModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr;
                cr = (l, m, am) =>
                {
                    Dictionary<string, string> ps = ReportHelper.CreateParameters(model.Id);
                    ReportHelper.AppendOrganizationIdToParameters(model, ps);
                    ps.Add("@DiagnosisID", model.DiagnosisId.ToString(CultureInfo.InvariantCulture));
                    ps.Add("@IncludeMap", model.IncludeMap ? "1" : "0");
                    var report = new AvianInvestigationReport();
                    report.SetParameters(l, ps, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportVetLivestockInvestigation(VetIdModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr;
                cr = (l, m, am) =>
                {
                    Dictionary<string, string> ps = ReportHelper.CreateParameters(model.Id);
                    ReportHelper.AppendOrganizationIdToParameters(model, ps);
                    ps.Add("@DiagnosisID", model.DiagnosisId.ToString(CultureInfo.InvariantCulture));
                    ps.Add("@IncludeMap", model.IncludeMap?"1":"0");
                    var report = new LivestockInvestigationReport();
                    report.SetParameters(l, ps, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportVetActiveSurveillanceSampleCollected(BaseIdModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr = (l, m, am) =>
                {
                    Dictionary<string, string> ps = ReportHelper.CreateParameters(model.Id);
                    ReportHelper.AppendOrganizationIdToParameters(model, ps);
                    var report = new SessionReport();
                    report.SetParameters(l, ps, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportVetSamplesCount(BaseYearModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr = (l, m, am) =>
                {
                    var report = new VetSamplesCountReport();
                    report.SetParameters(model, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportVetSamplesBySampleType(BaseYearModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);
                ReportHelper.CreateReportDelegate cr = (l, m, am) =>
                {
                    var report = new VetSamplesTypeReport();
                    report.SetParameters(model, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportVetSamplesBySampleTypesWithinRegions(BaseYearModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);
                ReportHelper.CreateReportDelegate cr = (l, m, am) =>
                {
                    var report = new VetTestTypeReport();
                    report.SetParameters(model, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportVetYearlySituation(BaseYearModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);
                ReportHelper.CreateReportDelegate cr = (l, m, am) =>
                {
                    var report = new VetSituationReport();
                    report.SetParameters(model, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportVetActiveSurveillance(BaseYearModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr = (l, m, am) =>
                {
                    var report = new ActiveSurveillanceReport();
                    report.SetParameters(model, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        #endregion

        #region KZ Human reports

        public byte[] ExportInfectiousParasiticKZReport(InfectiousParasiticKZSurrogateModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr = (l, m, am) =>
                {
                    var report = new InfectiousParasiticKZReport();
                    report.SetParameters(model, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        #endregion

        #region KZ Veterinary reports

        public byte[] ExportVetCountryPreventiveMeasures(ProphylacticModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr = (l, m, am) =>
                {
                    var report = new VetCountryPreventiveMeasures();
                    report.SetParameters(model, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportVetCountrySanitaryMeasures(SanitaryModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr = (l, m, am) =>
                {
                    var report = new VetCountryProphilacticMeasures();
                    report.SetParameters(model, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportVetCountryPlannedDiagnosticTests
            (DiagnosticInvestigationModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr = (l, m, am) =>
                {
                    var report = new VetCountryPlannedDiagnostic();
                    report.SetParameters(model, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportVetOblastPreventiveMeasures(ProphylacticModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr = (l, m, am) =>
                {
                    var report = new VetRegionPreventiveMeasures();
                    report.SetParameters(model, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportVetOblastSanitaryMeasures(SanitaryModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr = (l, m, am) =>
                {
                    var report = new VetRegionProphilacticMeasures();
                    report.SetParameters(model, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportVetOblastPlannedDiagnosticTests(DiagnosticInvestigationModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr = (l, m, am) =>
                {
                    var report = new VetRegionPlannedDiagnostic();
                    report.SetParameters(model, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        #endregion

        #region Lab module reports

        public byte[] ExportLimTestResult(LimTestResultModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr;
                cr = (l, m, am) =>
                {
                    Dictionary<string, string> ps = ReportHelper.CreateLimTestResultParameters(model.Id, model.CsId, model.TypeId);
                    ReportHelper.AppendOrganizationIdToParameters(model, ps);
                    var report = new TestResultReport();
                    report.SetParameters(l, ps, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportLimSampleTransfer(BaseIdModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr;
                cr = (l, m, am) =>
                {
                    Dictionary<string, string> ps = ReportHelper.CreateParameters(model.Id);
                    ReportHelper.AppendOrganizationIdToParameters(model, ps);

                    var report = new TransferReport();
                    report.SetParameters(l, ps, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportLimTest(LimTestModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr;
                cr = (l, m, am) =>
                {
                    Dictionary<string, string> ps = ReportHelper.CreateParameters(model.Id);
                    ReportHelper.AppendOrganizationIdToParameters(model, ps);

                    var report = new TestReport();
                    ps.Add("@IsHuman", model.IsHuman.ToString(CultureInfo.InvariantCulture));
                    report.SetParameters(l, ps, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportLimBatchTest(LimBatchTestModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr;
                cr = (l, m, am) =>
                {
                    Dictionary<string, string> ps = ReportHelper.CreateParameters(model.Id);
                    ReportHelper.AppendOrganizationIdToParameters(model, ps);
                    ps.Add("@TypeID", model.TypeId.ToString(CultureInfo.InvariantCulture));
                    var report = new BatchTestReport();
                    report.SetParameters(l, ps, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportLimSample(BaseIdModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);
                ReportHelper.CreateReportDelegate cr;
                cr = (l, m, am) =>
                {
                    Dictionary<string, string> ps = ReportHelper.CreateParameters(model.Id);
                    ReportHelper.AppendOrganizationIdToParameters(model, ps);
                    var report = new LimSampleReport();
                    report.SetParameters(l, ps, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportLimContainerContent(LimContainerContentModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);
                ReportHelper.CreateReportDelegate cr;
                cr = (l, m, am) =>
                {
                    Dictionary<string, string> ps =
                        ReportHelper.CreateLimSampleParameters(model.ContainerId, model.FreezerId);
                    ReportHelper.AppendOrganizationIdToParameters(model, ps);
                    var report = new SampleReport();
                    report.SetParameters(l, ps, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportLimAccessionIn(BaseIdModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr;
                cr = (l, m, am) =>
                {
                    Dictionary<string, string> ps = ReportHelper.CreateParameters(model.Id);
                    ReportHelper.AppendOrganizationIdToParameters(model, ps);

                    var report = new AccessionInReport();
                    report.SetParameters(l, ps, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        public byte[] ExportLimSampleDestruction(IdListModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr = (l, m, am) =>
                {
                    var report = new SampleDestructionReport();

                    Dictionary<string, string> ps = ReportHelper.ConvertSampeIdsToParameters(model.IdList);
                    ReportHelper.AppendOrganizationIdToParameters(model, ps);
                    report.SetParameters(l, ps, m, am);

                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        #endregion

        #region  Outbreak reports

        public byte[] ExportOutbreak(BaseIdModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr;
                cr = (l, m, am) =>
                {
                    Dictionary<string, string> ps = ReportHelper.CreateParameters(model.Id);
                    ReportHelper.AppendOrganizationIdToParameters(model, ps);
                    var report = new OutbreakReport();
                    report.SetParameters(l, ps, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        #endregion

        #region Administrative reports

        public byte[] ExportAdmEventLog(BaseIntervalModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr = (l, m, am) =>
                {
                    var report = new EventLogReport();
                    report.SetParameters(model, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        #endregion

        #region Vector Surveillance reports

        public byte[] ExportVectorSurveillanceSessionSummary(BaseIdModel model)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, model);

                ReportHelper.CreateReportDelegate cr = (l, m, am) =>
                {
                    Dictionary<string, string> ps = ReportHelper.CreateParameters(model.Id);
                    ReportHelper.AppendOrganizationIdToParameters(model, ps);
                    var report = new Document.VectorSurveillance.SessionReport();
                    report.SetParameters(l, ps, m, am);
                    return report;
                };
                return ExportReportToBytesWrapper(cr, model);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, model);
                throw;
            }
        }

        #endregion

        public Version GetServiceVersion()
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            return asm.GetName().Version;
        }

        #region Barcode reports

        public byte[] ExportNewBarcodes(long barcodeType, int quantity)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, barcodeType, quantity);

                return ExportBarcodes(barcodeType, new List<long>(), quantity);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, barcodeType, quantity);
                throw;
            }
        }

        public byte[] ExportExistingBarcodes(long barcodeType, IList<long> idList)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, barcodeType, idList);

                return ExportBarcodes(barcodeType, idList, 1);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, barcodeType, idList);
                throw;
            }
        }

        public byte[] ExportSampleBarcodes(IList<SampleBarcodeDTO> samples)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, samples);
                InitEidssCoreIfNeeded();

                using (SampleBarcodeReport report = BarcodeReportGenerator.GenerateSampleBarcodeReport())
                {
                    report.InitPrinterSettings();
                    report.GetBarcodeBySampleData(samples);

                    byte[] bytes = report.ExportToBytes(ReportExportType.Pdf);
                    return bytes;
                }
            }

            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, samples);
                throw;
            }
        }

        private static byte[] ExportBarcodes(long barcodeType, IList<long> idList, int quantity)
        {
            try
            {
                InitEidssCoreIfNeeded();

                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    using (BaseBarcodeReport report = BarcodeReportGenerator.GenerateBarcodeReport(barcodeType))
                    {
                        report.InitPrinterSettings();
                        if (idList != null && idList.Count > 0)
                        {
                            report.GetBarcodeById(manager, barcodeType, idList);
                        }
                        else
                        {
                            report.GetNewBarcode(manager, barcodeType, quantity);
                        }

                        byte[] bytes = report.ExportToBytes(ReportExportType.Pdf);
                        return bytes;
                    }
                }
            }
            catch (Exception ex)
            {
                WrapSqlException(ex);
                throw;
            }
        }

        #endregion

        #region Helper Methods

        private byte[] ExportReportToBytesWrapper(ReportHelper.CreateReportDelegate cr, BaseModel model)
        {
            try
            {
                return ExportReportToBytes(model, cr);
            }
            catch (Exception ex)
            {
                m_Initialized = false;
                WrapSqlException(ex);
                throw;
            }
        }

        private static byte[] ExportReportToBytes(BaseModel model, ReportHelper.CreateReportDelegate createReport)
        {
            Utils.CheckNotNull(createReport, "createReport");

            Utils.CheckNotNullOrEmpty(model.Language, "parameters.Language");

            string lang = model.Language; //.ToLowerInvariant();
            byte[] bytes;

            InitEidssCoreIfNeeded();

            if (!CustomCultureHelper.SupportedLanguages.ContainsKey(lang))
            {
                throw new ArgumentException(String.Format("Language {0} is not supported", lang));
            }

            EidssUserContext.User.SetForbiddenPersonalDataGroups(model.ForbiddenGroups ?? new List<PersonalDataGroup>());
            using (new CultureInfoTransaction(new CultureInfo(CustomCultureHelper.SupportedLanguages[lang])))
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    DbManagerProxy archiveManager = null;
                    BaseReport report = null;
                    try
                    {
                        if (model.Mode != ReportArchiveMode.ActualOnly)
                        {
                            archiveManager = DbManagerFactory.Factory[DatabaseType.Archive].Create();
                        }
                        switch (model.Mode)
                        {
                            case ReportArchiveMode.ActualOnly:
                                report = createReport(model.Language, manager, manager);
                                break;
                            case ReportArchiveMode.ArchiveOnly:
                                report = createReport(model.Language, archiveManager, archiveManager);
                                break;
                            default:
                                report = createReport(model.Language, manager, archiveManager);
                                break;
                        }
                        report.SetAdaptersNull();
                        if (report.ChildReport != null)
                        {
                            report.ChildReport.SetAdaptersNull();
                            report.CreateDocument();
                            report.ChildReport.CreateDocument();
                            report.Pages.AddRange(report.ChildReport.Pages);
                            report.PrintingSystem.ContinuousPageNumbering = true;
                        }

                        bytes = report.ExportToBytes(model.ExportFormatEnum);
                    }
                    finally
                    {
                        if (report != null)
                        {
                            report.Dispose();
                        }
                        if (archiveManager != null)
                        {
                            archiveManager.Dispose();
                        }
                    }
                }
            }
            return bytes;
        }

        private static void InitEidssCoreIfNeeded()
        {
            lock (m_SyncLock)
            {
                if (!m_Initialized)
                {
                    Config.ReloadSettings();

                    ConnectionManager.DefaultInstance.SetCredentials();
                    DbManagerFactory.SetSqlFactory(new ConnectionCredentials().ConnectionString);

                    DbManagerFactory.SetSqlFactory(new ConnectionCredentials(null, "Archive").ConnectionString, DatabaseType.Archive);

                    EidssUserContext.Init();
                    Localizer.MenuMessages = EidssMenu.Instance;
                    BaseFieldValidator.FieldCaptions = EidssFields.Instance;
                    EIDSS_LookupCacheHelper.Init();
                    CustomCultureHelper.CurrentCountry = EidssSiteContext.Instance.CountryID;
                    m_Initialized = true;
                }
            }
        }

        private static void WrapSqlException(Exception ex)
        {
            string description = SqlExceptionHandler.GetExceptionDescription(ex);
            if (!String.IsNullOrEmpty(description))
            {
                throw new ReportDataException(description, ex);
            }
        }

        #endregion
    }
}