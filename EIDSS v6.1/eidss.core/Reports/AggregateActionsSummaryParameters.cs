using System;
using System.Collections.Generic;

namespace eidss.model.Reports
{
    [Serializable]
    public class AggregateActionsSummaryParameters
    {
        public AggregateActionsSummaryParameters(string aggrXml, IEnumerable<long> diagnosticObservation, IEnumerable<long> prophylacticObservation, IEnumerable<long> sanitaryObservation, IDictionary<string, string> labels)
        {
            AggrXml = aggrXml;
            DiagnosticObservation = diagnosticObservation;
            ProphylacticObservation = prophylacticObservation;
            SanitaryObservation = sanitaryObservation;
            Labels = labels;
        }

        public string AggrXml { get; private set; }
        public IEnumerable<long> DiagnosticObservation { get; private set; }
        public IEnumerable<long> ProphylacticObservation { get; private set; }
        public IEnumerable<long> SanitaryObservation { get; private set; }
        public IDictionary<string, string> Labels { get; private set; }
    }
}