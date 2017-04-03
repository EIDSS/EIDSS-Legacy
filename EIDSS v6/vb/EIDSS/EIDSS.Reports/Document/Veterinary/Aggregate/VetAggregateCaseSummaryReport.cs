using System.Collections.Generic;
using bv.model.BLToolkit;
using EIDSS.Reports.BaseControls.Aggregate;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Flexible;

namespace EIDSS.Reports.Document.Veterinary.Aggregate
{
    public sealed partial class VetAggregateCaseSummaryReport : BaseDocumentReport
    {
        private const int DeltaWidth = 8;

        public VetAggregateCaseSummaryReport()
        {
            InitializeComponent();
        }

        public override void SetParameters(DbManagerProxy manager, string lang, Dictionary<string, string> parameters)
        {
            base.SetParameters(manager, lang, parameters);

            string aggrXml = GetStringParameter(parameters, "@AggrXml");

            ((AdmUnitReport) xrSubreportAdmUnit.ReportSource).SetParameters(manager, lang, aggrXml);

            List<long> observations = AggregateHelper.GetObservationList(parameters, "@observationId");
            FlexFactory.CreateVetAggregateSummaryReport(FlexSubreport, observations, tableBaseHeader.Width - DeltaWidth);

            DataAdapter = null;
        }
    }
}