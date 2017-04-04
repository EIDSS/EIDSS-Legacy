using System.Collections.Generic;
using bv.model.BLToolkit;
using eidss.model.Reports;
using EIDSS.Reports.BaseControls.Aggregate;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Factory;
using EIDSS.Reports.Flexible;

namespace EIDSS.Reports.Document.Human.Aggregate
{
    [NullableAdapters]
    public sealed partial class SummaryAggregateReport : BaseDocumentReport
    {
        public SummaryAggregateReport()
        {
            InitializeComponent();
        }

        public override void SetParameters
            (string lang, Dictionary<string, string> parameters, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            base.SetParameters(lang, parameters, manager, archiveManager);

            string aggrXml = GetStringParameter(parameters, "@AggrXml");

            ((AdmUnitReport) xrSubreportAdmUnit.ReportSource).SetParameters(lang, aggrXml, manager, archiveManager);

            List<long> observations = AggregateHelper.GetObservationList(parameters, "@observationId");
            FlexFactory.CreateHumanAggregateSummaryReport(FlexSubreport, observations, tableBaseHeader.Width);

            ReportRtlHelper.SetRTL(this);
            ReportRebinder.RebindDateAndFontForReport();
        }
    }
}