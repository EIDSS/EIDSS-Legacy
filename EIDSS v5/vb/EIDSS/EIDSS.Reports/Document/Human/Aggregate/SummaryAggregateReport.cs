using System.Collections.Generic;
using bv.model.BLToolkit;
using EIDSS.Reports.BaseControls;
using EIDSS.Reports.BaseControls.Aggregate;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Flexible;

namespace EIDSS.Reports.Document.Human.Aggregate
{
    public sealed partial class SummaryAggregateReport : BaseDocumentReport
    {
        public SummaryAggregateReport()
        {
            InitializeComponent();
        }

        public override void SetParameters(DbManagerProxy manager, string lang, Dictionary<string, string> parameters)
        {
            base.SetParameters(manager, lang, parameters);

            string aggrXml = GetStringParameter(parameters, "@AggrXml");

            admUnitReport1.SetParameters(manager, lang, aggrXml);
            timeUnitReport1.SetParameters(manager, lang, aggrXml);

            List<long> observations = AggregateHelper.GetObservationList(parameters, "@observationId");
            FlexFactory.CreateHumanAggregateSummaryReport(FlexSubreport, observations, tableBaseHeader.Width);
        }
    }
}