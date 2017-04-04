using System.Collections.Generic;
using bv.model.BLToolkit;
using eidss.model.Reports;
using EIDSS.Reports.BaseControls.Aggregate;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Factory;
using EIDSS.Reports.Flexible;

namespace EIDSS.Reports.Document.Veterinary.Aggregate
{
    [NullableAdapters]
    public sealed partial class VetAggregateActionsSummaryReport : BaseDocumentReport
    {
        public VetAggregateActionsSummaryReport()
        {
            InitializeComponent();
        }

        public override void SetParameters(string lang, Dictionary<string, string> parameters, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            base.SetParameters(lang, parameters, manager, archiveManager);

            string aggrXml = GetStringParameter(parameters, "@AggrXml");
            ((AdmUnitReport)xrSubreportAdmUnit.ReportSource).SetParameters(lang, aggrXml, manager, archiveManager);

            const int deltaWidth = 8;
            List<long> diagnosticObservations = AggregateHelper.GetObservationList(parameters, "@diagnosticObservation");
            string diagnosticText = GetStringParameter(parameters, "@diagnosticText" + lang);
            FlexFactory.CreateVetAggregateActionsSummaryReport(FlexSubreport, diagnosticObservations, tableBaseHeader.Width - deltaWidth,
                diagnosticText);

            List<long> sanitaryObservations = AggregateHelper.GetObservationList(parameters, "@sanitaryObservation");
            string sanitaryText = GetStringParameter(parameters, "@sanitaryText" + lang);
            FlexFactory.CreateVetAggregateActionsSummarySanReport(FlexSubreportSan, sanitaryObservations, tableBaseHeader.Width - deltaWidth,
                sanitaryText);

            List<long> prophylacticObservations = AggregateHelper.GetObservationList(parameters, "@prophylacticObservation");
            string prophylacticText = GetStringParameter(parameters, "@prophylacticText" + lang);
            FlexFactory.CreateVetAggregateActionsSummaryProReport(FlexSubreportPro, prophylacticObservations,
                tableBaseHeader.Width - deltaWidth, prophylacticText);

            ReportRtlHelper.SetRTL(this);
            ReportRebinder.RebindDateAndFontForReport();
        }
    }
}