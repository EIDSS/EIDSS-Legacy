using System;
using System.Collections.Generic;

namespace eidss.model.Reports.Common
{
    [Serializable]
    public class AggregateActionsModel : BaseIdModel
    {
        public AggregateActionsModel
            (string language, long id, long diagnosticFormTemplate, long diagnosticObservation, long prophylacticFormTemplate,
             long prophylacticObservation, long sanitaryFormTemplate, long sanitaryObservation, IDictionary<string, string> labels,
             bool useArchive)
            : base(language, id, useArchive)
        {
            DiagnosticFormTemplate = diagnosticFormTemplate;
            DiagnosticObservation = diagnosticObservation;
            ProphylacticFormTemplate = prophylacticFormTemplate;
            ProphylacticObservation = prophylacticObservation;
            SanitaryFormTemplate = sanitaryFormTemplate;
            SanitaryObservation = sanitaryObservation;
            Labels = labels;
        }

        public long DiagnosticFormTemplate { get; set; }
        public long DiagnosticObservation { get; set; }
        public long ProphylacticFormTemplate { get; set; }
        public long ProphylacticObservation { get; set; }
        public long SanitaryFormTemplate { get; set; }
        public long SanitaryObservation { get; set; }
        public IDictionary<string, string> Labels { get; set; }

        public static explicit operator AggregateActionsParameters(AggregateActionsModel model)
        {
            return new AggregateActionsParameters(model.Id,
                                                  model.DiagnosticFormTemplate, model.DiagnosticObservation,
                                                  model.ProphylacticFormTemplate, model.ProphylacticObservation,
                                                  model.SanitaryFormTemplate, model.SanitaryObservation,
                                                  model.Labels);
        }
    }
}