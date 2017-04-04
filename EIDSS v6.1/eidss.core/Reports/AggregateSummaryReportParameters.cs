using System;
using System.Collections.Generic;

namespace eidss.model.Reports
{
    [Serializable]
    public class AggregateSummaryReportParameters
    {
        public AggregateSummaryReportParameters(string aggrXml, IEnumerable<long> observationList)
        {
            AggrXml = aggrXml;
            ObservationList = observationList;
        }

        public string AggrXml { get; private set; }
        public IEnumerable<long> ObservationList { get; private set; }
    }
}