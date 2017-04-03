using System;
using System.Collections.Generic;

namespace eidss.model.Reports.Common
{
    [Serializable]
    public class AggregateSummaryModel : BaseModel
    {
        public string AggrXml { get; set; }
        public List<long> ObservationList { get; set; }

        public AggregateSummaryModel(string language, string aggrXml, List<long> observationList, bool useArchive)
            : base(language, useArchive)
        {
            AggrXml = aggrXml;
            ObservationList = observationList;
        }

        public static explicit operator AggregateSummaryReportParameters(AggregateSummaryModel model)
        {
            return new AggregateSummaryReportParameters(model.AggrXml, model.ObservationList);
        }
    }
}