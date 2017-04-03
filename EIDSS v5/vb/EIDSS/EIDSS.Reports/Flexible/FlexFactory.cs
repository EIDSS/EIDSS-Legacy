using System.Collections.Generic;
using DevExpress.XtraReports.UI;
using EIDSS.FlexibleForms.Helpers;
using EIDSS.FlexibleForms.Helpers.ReportHelper.Tree;
using EIDSS.Reports.Flexible.Visitors;
using bv.winclient.Core;

namespace EIDSS.Reports.Flexible
{
    public class FlexFactory
    {
        #region Human

        public static void CreateHumanClinicalSignsReport(SubreportBase parentSubreport, long id, long diagnosis)
        {
            CreateFlexReport(parentSubreport, id, diagnosis, FFType.HumanClinicalSigns);
        }

        public static void CreateHumanEpiObservationsReport(SubreportBase parentSubreport, long id, long diagnosis)
        {
            CreateFlexReport(parentSubreport, id, diagnosis, FFType.HumanEpiInvestigations);
        }

        #endregion

        #region Lim

        public static void CreateLimBatchReport(SubreportBase parentSubreport, long id, long type)
        {
            CreateFlexReport(parentSubreport, id, type, FFType.TestRun);
        }

        public static void CreateLimTestReport(SubreportBase parentSubreport, long id, long? type)
        {
            CreateFlexReport(parentSubreport, id, type, FFType.TestDetails);
        }

        #endregion

        #region Vet

        public static void CreateControlMeasuresReport(SubreportBase parentSubreport, long id, long diagnosis)
        {
            CreateFlexReport(parentSubreport, id, diagnosis, FFType.LivestockControlMeasures);
        }

        public static void CreateLivestockEpiReport(SubreportBase parentSubreport, long id, long diagnosis)
        {
            CreateFlexReport(parentSubreport, id, diagnosis, FFType.LivestockFarmEPI);
        }

        public static void CreateAvianEpiReport(SubreportBase parentSubreport, long id, long diagnosis)
        {
            CreateFlexReport(parentSubreport, id, diagnosis, FFType.AvianFarmEPI);
        }

        public static void CreateLivestockClinicalReport(SubreportBase parentSubreport, long id, long diagnosis)
        {
            CreateFlexReport(parentSubreport, id, diagnosis, FFType.LivestockSpeciesCS);
        }

        public static void CreateAvianClinicalReport(SubreportBase parentSubreport, long id, long diagnosis)
        {
            CreateFlexReport(parentSubreport, id, diagnosis, FFType.AvianSpeciesCS);
        }

        #endregion

        #region Human Aggregate

        public static void CreateHumanAggregateReport(SubreportBase parentSubreport, long idFormTemplate, long id, int? tableMaxSize)
        {
            var dictionary = new Dictionary<int, int> {{3, 3}};
            CreateFlexAggregateReport(parentSubreport, idFormTemplate, AggregateCaseSection.HumanCase, id,
                                      FFType.HumanAggregateCase, tableMaxSize, dictionary);
        }

        public static void CreateHumanAggregateSummaryReport
            (SubreportBase parentSubreport, List<long> ids, int? tableMaxSize)
        {
            var dictionary = new Dictionary<int, int> {{3, 3}};
            CreateFlexAggregateSummaryReport(parentSubreport, ids, FFType.HumanAggregateCase, tableMaxSize, dictionary);
        }

        #endregion

        #region Vet Aggregate

        public static void CreateVetAggregateReport(SubreportBase parentSubreport, long idFormTemplate, long id, int? tableMaxSize)
        {
            CreateFlexAggregateReport(parentSubreport,idFormTemplate, AggregateCaseSection.VetCase, id, FFType.VetAggregateCase,
                                      tableMaxSize);
        }

        public static void CreateVetAggregateActionsReport
            (SubreportBase parentSubreport, long idFormTemplate, long id, int? tableMaxSize, string header)
        {
            CreateFlexAggregateReport(parentSubreport,idFormTemplate, AggregateCaseSection.DiagnosticAction, id,
                                      FFType.VetEpizooticActionDiagnosisInv, tableMaxSize, header);
        }

        public static void CreateVetAggregateActionsProReport
            (SubreportBase parentSubreport, long idFormTemplate, long id, int? tableMaxSize, string header)
        {
            CreateFlexAggregateReport(parentSubreport, idFormTemplate, AggregateCaseSection.ProphylacticAction, id,
                                      FFType.VetEpizooticActionTreatment, tableMaxSize, header);
        }

        public static void CreateVetAggregateActionsSanReport
            (SubreportBase parentSubreport, long idFormTemplate, long id, int? tableMaxSize, string header)
        {
            CreateFlexAggregateReport(parentSubreport, idFormTemplate, AggregateCaseSection.SanitaryAction, id,
                                      FFType.VetEpizooticAction, tableMaxSize, header);
        }

        public static void CreateVetAggregateSummaryReport
            (SubreportBase parentSubreport, List<long> ids,
             int? tableMaxSize)
        {
            CreateFlexAggregateSummaryReport(parentSubreport, ids, FFType.VetAggregateCase, tableMaxSize);
        }

        public static void CreateVetAggregateActionsSummaryReport
            (SubreportBase parentSubreport, List<long> ids,
             int? tableMaxSize, string header)
        {
            CreateFlexAggregateSummaryReport(parentSubreport, ids,
                                             FFType.VetEpizooticActionDiagnosisInv, tableMaxSize, header);
        }

        public static void CreateVetAggregateActionsSummaryProReport
            (SubreportBase parentSubreport, List<long> ids,
             int? tableMaxSize, string header)
        {
            CreateFlexAggregateSummaryReport(parentSubreport, ids,
                                             FFType.VetEpizooticActionTreatment, tableMaxSize, header);
        }

        public static void CreateVetAggregateActionsSummarySanReport
            (SubreportBase parentSubreport, List<long> ids,
             int? tableMaxSize, string header)
        {
            CreateFlexAggregateSummaryReport(parentSubreport, ids,
                                             FFType.VetEpizooticAction, tableMaxSize, header);
        }

        #endregion

        private static void CreateFlexAggregateSummaryReport
            (SubreportBase parentSubreport,
             List<long> ids, FFType formType, int? tableMaxSize, Dictionary<int, int> levelFont = null)
        {
            CreateFlexAggregateSummaryReport(parentSubreport, ids, formType, tableMaxSize, string.Empty, levelFont);
        }

        private static void CreateFlexAggregateSummaryReport
            (SubreportBase parentSubreport, List<long> ids, FFType formType,
             int? tableMaxSize, string header, Dictionary<int, int> levelFont = null)
        {
            var templateHelper = new TemplateHelper();
            templateHelper.LoadSummary(ids, formType);
            FlexNode flexNode = templateHelper.GetFlexNodeFromTemplateSummary();
            flexNode.ProcessAsTable = true;
            parentSubreport.ReportSource = CreateFlexReport(flexNode, header, tableMaxSize, levelFont);
        }

        private static void CreateFlexAggregateReport
            (SubreportBase parentSubreport, long idFormTemplate, AggregateCaseSection presetStub,
             long id, FFType formType, int? tableMaxSize, Dictionary<int, int> levelFont = null)
        {
            CreateFlexAggregateReport(parentSubreport, idFormTemplate, presetStub, id, formType, tableMaxSize, string.Empty, levelFont);
        }

        private static void CreateFlexAggregateReport
            (SubreportBase parentSubreport, long idFormTemplate, AggregateCaseSection presetStub,
             long id, FFType formType, int? tableMaxSize, string reportHeader, Dictionary<int, int> levelFont = null)
        {
            var templateHelper = new TemplateHelper();
            //templateHelper.LoadAggregateTemplate(presetStub, id, formType);
            templateHelper.LoadAggregateTemplate(idFormTemplate, presetStub, id, formType);

            FlexNode flexNode = templateHelper.GetFlexNodeFromTemplate(id);
            flexNode.ProcessAsTable = true;
            parentSubreport.ReportSource = CreateFlexReport(flexNode, reportHeader, tableMaxSize, levelFont);
        }

        private static void CreateFlexReport(SubreportBase parentSubreport, long id, long? determinant,FFType formType)
        {
            var templateHelper = new TemplateHelper();
            templateHelper.LoadTemplate(new List<long> {id}, determinant, formType);
            FlexNode flexNode = templateHelper.GetFlexNodeFromTemplate(id);
            parentSubreport.ReportSource = CreateFlexReport(flexNode, string.Empty, null);
        }

        public static FlexReport CreateFlexReport
            (FlexNode root, string tableHeader, int? tableMaxSize, Dictionary<int, int> levelFont = null)
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