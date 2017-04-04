using System.Collections.Generic;
using DevExpress.XtraReports.UI;
using EIDSS.Reports.Flexible.Visitors;
using bv.winclient.Core;
using eidss.model.Model.Report;
using eidss.model.Schema;
using eidss.model.Enums;

namespace EIDSS.Reports.Flexible
{
    public class FlexFactory
    {
        #region Human

        public static void CreateHumanClinicalSignsReport(SubreportBase parentSubreport, long id, long diagnosis)
        {
            CreateFlexReport(parentSubreport, id, diagnosis, FFTypeEnum.HumanClinicalSigns);
        }

        public static void CreateHumanEpiObservationsReport(SubreportBase parentSubreport, long id, long diagnosis)
        {
            CreateFlexReport(parentSubreport, id, diagnosis, FFTypeEnum.HumanEpiInvestigations);
        }

        #endregion

        #region Lim

        public static void CreateLimBatchReport(SubreportBase parentSubreport, long id, long type)
        {
            CreateFlexReport(parentSubreport, id, type, FFTypeEnum.TestRun);
        }

        public static void CreateLimTestReport(SubreportBase parentSubreport, long id, long? type)
        {
            CreateFlexReport(parentSubreport, id, type, FFTypeEnum.TestDetails);
        }

        #endregion

        #region Vet

        public static void CreateControlMeasuresReport(SubreportBase parentSubreport, long id, long diagnosis)
        {
            CreateFlexReport(parentSubreport, id, diagnosis, FFTypeEnum.LivestockControlMeasures);
        }

        public static void CreateLivestockEpiReport(SubreportBase parentSubreport, long id, long diagnosis)
        {
            CreateFlexReport(parentSubreport, id, diagnosis, FFTypeEnum.LivestockFarmEPI);
        }

        public static void CreateAvianEpiReport(SubreportBase parentSubreport, long id, long diagnosis)
        {
            CreateFlexReport(parentSubreport, id, diagnosis, FFTypeEnum.AvianFarmEPI);
        }

        public static void CreateLivestockClinicalReport(SubreportBase parentSubreport, long id, long diagnosis)
        {
            CreateFlexReport(parentSubreport, id, diagnosis, FFTypeEnum.LivestockSpeciesCS);
        }

        public static void CreateAvianClinicalReport(SubreportBase parentSubreport, long id, long diagnosis)
        {
            CreateFlexReport(parentSubreport, id, diagnosis, FFTypeEnum.AvianSpeciesCS);
        }

        #endregion

        #region Human Aggregate

        public static void CreateHumanAggregateReport(SubreportBase parentSubreport, long idFormTemplate, long id, int? tableMaxSize)
        {
            var dictionary = new Dictionary<int, int> {{2, 2}, {3,2}, {4,2}};
            CreateFlexAggregateReport(parentSubreport, idFormTemplate, AggregateCaseSectionEnum.HumanCase, id,
                                      FFTypeEnum.HumanAggregateCase, tableMaxSize, dictionary);
        }

        public static void CreateHumanAggregateSummaryReport
            (SubreportBase parentSubreport, List<long> ids, int? tableMaxSize)
        {
            var dictionary = new Dictionary<int, int> { { 2, 2 }, { 3, 2 }, { 4, 2 } };
            CreateFlexAggregateSummaryReport(parentSubreport, ids, FFTypeEnum.HumanAggregateCase, tableMaxSize, dictionary);
        }

        #endregion

        #region Vet Aggregate

        public static void CreateVetAggregateReport(SubreportBase parentSubreport, long idFormTemplate, long id, int? tableMaxSize)
        {
            CreateFlexAggregateReport(parentSubreport,idFormTemplate, AggregateCaseSectionEnum.VetCase, id, FFTypeEnum.VetAggregateCase,
                                      tableMaxSize);
        }

        public static void CreateVetAggregateActionsReport
            (SubreportBase parentSubreport, long idFormTemplate, long id, int? tableMaxSize, string header)
        {
            CreateFlexAggregateReport(parentSubreport, idFormTemplate, AggregateCaseSectionEnum.DiagnosticAction, id,
                                      FFTypeEnum.VetEpizooticActionDiagnosisInv, tableMaxSize, header);
        }

        public static void CreateVetAggregateActionsProReport
            (SubreportBase parentSubreport, long idFormTemplate, long id, int? tableMaxSize, string header)
        {
            CreateFlexAggregateReport(parentSubreport, idFormTemplate, AggregateCaseSectionEnum.ProphylacticAction, id,
                                      FFTypeEnum.VetEpizooticActionTreatment, tableMaxSize, header);
        }

        public static void CreateVetAggregateActionsSanReport
            (SubreportBase parentSubreport, long idFormTemplate, long id, int? tableMaxSize, string header)
        {
            CreateFlexAggregateReport(parentSubreport, idFormTemplate, AggregateCaseSectionEnum.SanitaryAction, id,
                                      FFTypeEnum.VetEpizooticAction, tableMaxSize, header);
        }

        public static void CreateVetAggregateSummaryReport
            (SubreportBase parentSubreport, List<long> ids,
             int? tableMaxSize)
        {
            CreateFlexAggregateSummaryReport(parentSubreport, ids, FFTypeEnum.VetAggregateCase, tableMaxSize);
        }

        public static void CreateVetAggregateActionsSummaryReport
            (SubreportBase parentSubreport, List<long> ids,
             int? tableMaxSize, string header)
        {
            CreateFlexAggregateSummaryReport(parentSubreport, ids,
                                             FFTypeEnum.VetEpizooticActionDiagnosisInv, tableMaxSize, header);
        }

        public static void CreateVetAggregateActionsSummaryProReport
            (SubreportBase parentSubreport, List<long> ids,
             int? tableMaxSize, string header)
        {
            CreateFlexAggregateSummaryReport(parentSubreport, ids,
                                             FFTypeEnum.VetEpizooticActionTreatment, tableMaxSize, header);
        }

        public static void CreateVetAggregateActionsSummarySanReport
            (SubreportBase parentSubreport, List<long> ids,
             int? tableMaxSize, string header)
        {
            CreateFlexAggregateSummaryReport(parentSubreport, ids,
                                             FFTypeEnum.VetEpizooticAction, tableMaxSize, header);
        }

        #endregion

        private static void CreateFlexAggregateSummaryReport
            (SubreportBase parentSubreport,List<long> ids, FFTypeEnum formType, int? tableMaxSize, Dictionary<int, int> levelFont = null)
        {
            CreateFlexAggregateSummaryReport(parentSubreport, ids, formType, tableMaxSize, string.Empty, levelFont);
        }

        private static void CreateFlexAggregateSummaryReport
            (SubreportBase parentSubreport, List<long> ids, FFTypeEnum formType,
             int? tableMaxSize, string header, Dictionary<int, int> levelFont = null)
        {
            var templateHelper = new TemplateHelper();
            templateHelper.LoadSummary(ids, formType);
            var flexNodeReport = templateHelper.GetFlexNodeFromTemplate(false);
            /*
            var templateHelper = new TemplateHelper();
            templateHelper.LoadSummary(ids, formType);
            FlexNode flexNode = templateHelper.GetFlexNodeFromTemplateSummary();
            */
            flexNodeReport.ProcessAsTable = true;
            parentSubreport.ReportSource = CreateFlexReport(flexNodeReport, header, tableMaxSize, levelFont);
        }

        private static void CreateFlexAggregateReport
            (SubreportBase parentSubreport, long idFormTemplate, AggregateCaseSectionEnum presetStub,
             long id, FFTypeEnum formType, int? tableMaxSize, Dictionary<int, int> levelFont = null)
        {
            CreateFlexAggregateReport(parentSubreport, idFormTemplate, presetStub, id, formType, tableMaxSize, string.Empty, levelFont);
        }

        private static void CreateFlexAggregateReport
            (SubreportBase parentSubreport, long idFormTemplate, AggregateCaseSectionEnum matrixId,
             long id, FFTypeEnum formType, int? tableMaxSize, string reportHeader, Dictionary<int, int> levelFont = null)
        {
            var templateHelper = new TemplateHelper();
            templateHelper.LoadTemplate(new List<long> { id }, idFormTemplate);
            templateHelper.LoadAggregateTemplate(matrixId, id);
            var flexNodeReport = templateHelper.GetFlexNodeFromTemplate(false);
            flexNodeReport.ProcessAsTable = true;
            parentSubreport.ReportSource = CreateFlexReport(flexNodeReport, reportHeader, tableMaxSize, levelFont);
        }

        private static void CreateFlexReport(SubreportBase parentSubreport, long id, long? determinant,FFTypeEnum formType)
        {
            /*
            var ffModel = new FFPresenterModel((long)formType);
            ffModel.SetProperties(EidssSiteContext.Instance.CountryID, determinant, formType, id, 0);
            var flexNode = ffModel.CreateFlexNodeForTemplate();
            */
            var templateHelper = new TemplateHelper();
            templateHelper.LoadTemplate(new List<long> {id}, determinant, formType);
            var flexNode = templateHelper.GetFlexNodeFromTemplate(true);
            parentSubreport.ReportSource = CreateFlexReport(flexNode, string.Empty, null);
        }

        public static FlexReport CreateFlexReport
            (FlexNodeReport root, string tableHeader, int? tableMaxSize, Dictionary<int, int> levelFont = null)
        {
            root.AcceptForward(new AuditVisitor());
            root.AcceptForward(new ShouldProcessAsTableVisitor());

            var levelVisitor = new LevelVisitor();
            root.AcceptForward(levelVisitor);
            var auditWidthVisitor = new AuditWidthVisitor();
            for (int i = levelVisitor.MaxLevel; i > 0; i--)
            {
                auditWidthVisitor.LevelToVisit = i;
                root.AcceptBackword(auditWidthVisitor);
            }
            if (!string.IsNullOrEmpty(auditWidthVisitor.ErrorMessage))
            {
                MessageForm.Show(auditWidthVisitor.ErrorMessage, "Flexible Form Error");
            }
            var reportVisitor = new ReportVisitor {LevelFont = levelFont};
            root.AcceptForward(reportVisitor);

            var tableVisitor = new TableVisitor {TableMaxWidth = tableMaxSize, TableHeader = tableHeader};
            root.AcceptForward(tableVisitor);

            var report = (FlexReport) root.AssignedControl;
            EndInitChildren(report);
            // note[ivan]: no need to set header for whole report, just set it for main table
            report.Text = string.Empty;

            return report;
        }

        private static void EndInitChildren(XRControl parent)
        {
            foreach (XRControl child in parent.Controls)
            {
                EndInitChildren(child);
            }
            if (parent is XRSubreport)
            {
                EndInitChildren(((XRSubreport) (parent)).ReportSource);
            }
            var flexTable = parent as FlexTable;
            if (flexTable != null)
            {
                (flexTable).EndInit();
            }
        }
    }
}