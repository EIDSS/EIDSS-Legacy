using System;
using System.Collections.Generic;

namespace eidss.model.Reports.Common
{
    [Serializable]
    public class AggregateActionsSummaryModel : BaseModel
    {
        public AggregateActionsSummaryModel
            (string language, string aggrXml, IEnumerable<long> diagnosticObservation, IEnumerable<long> prophylacticObservation,
             IEnumerable<long> sanitaryObservation, IDictionary<string, string> labels, bool useArchive)
            : base(language, useArchive)
        {
            AggrXml = aggrXml;
            DiagnosticObservation = diagnosticObservation;
            ProphylacticObservation = prophylacticObservation;
            SanitaryObservation = sanitaryObservation;
            Labels = labels;
        }

        public string AggrXml { get; set; }
        public IEnumerable<long> DiagnosticObservation { get; set; }
        public IEnumerable<long> ProphylacticObservation { get; set; }
        public IEnumerable<long> SanitaryObservation { get; set; }
        public IDictionary<string, string> Labels { get; set; }

        public static explicit operator AggregateActionsSummaryParameters(AggregateActionsSummaryModel model)
        {
            return new AggregateActionsSummaryParameters(model.AggrXml,
                                                         model.DiagnosticObservation,
                                                         model.ProphylacticObservation,
                                                         model.SanitaryObservation,
                                                         model.Labels);
        }
    }
}