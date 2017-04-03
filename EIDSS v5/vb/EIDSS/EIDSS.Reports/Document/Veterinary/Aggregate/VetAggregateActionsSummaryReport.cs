using System.Collections.Generic;
using bv.model.BLToolkit;
using EIDSS.Reports.BaseControls.Aggregate;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Flexible;

namespace EIDSS.Reports.Document.Veterinary.Aggregate
{
    public sealed partial class VetAggregateActionsSummaryReport : BaseDocumentReport
    {
        public VetAggregateActionsSummaryReport()
        {
            InitializeComponent();
        }

        public override void SetParameters(DbManagerProxy manager, string lang, Dictionary<string, string> parameters)
        {
            base.SetParameters(manager, lang, parameters);

            string aggrXml = GetStringParameter(parameters, "@AggrXml");
            admUnitReport1.SetParameters(manager, lang, aggrXml);
            timeUnitReport1.SetParameters(manager, lang, aggrXml);

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
        }
    }
}