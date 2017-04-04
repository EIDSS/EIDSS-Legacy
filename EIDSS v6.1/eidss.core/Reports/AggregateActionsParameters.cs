using System;
using System.Collections.Generic;

namespace eidss.model.Reports
{
    [Serializable]
    public class AggregateActionsParameters
    {
        public AggregateActionsParameters
            (long caseId,
             long diagnosticFormTemplate, long diagnosticObservation,
             long prophylacticFormTemplate, long prophylacticObservation,
             long sanitaryFormTemplate, long sanitaryObservation,
             IDictionary<string, string> labels)
        {
            CaseId = caseId;
            DiagnosticFormTemplate = diagnosticFormTemplate;
            DiagnosticObservation = diagnosticObservation;
            ProphylacticFormTemplate = prophylacticFormTemplate;
            ProphylacticObservation = prophylacticObservation;
            SanitaryFormTemplate = sanitaryFormTemplate;
            SanitaryObservation = sanitaryObservation;
            Labels = labels;
        }

        public long CaseId { get; private set; }
        public long DiagnosticFormTemplate { get; private set; }
        public long DiagnosticObservation { get; private set; }
        public long ProphylacticFormTemplate { get; private set; }
        public long ProphylacticObservation { get; private set; }
        public long SanitaryFormTemplate { get; private set; }
        public long SanitaryObservation { get; private set; }
        public IDictionary<string, string> Labels { get; private set; }
    }
}