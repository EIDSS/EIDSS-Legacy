using System;

namespace eidss.model.Reports
{
    [Serializable]
    public class AggregateReportParameters
    {
        public AggregateReportParameters(long caseId, long formTemplateId, long observationId)
        {
            CaseId = caseId;
            FormTemplateId = formTemplateId;
            ObservationId = observationId;
        }

        public long CaseId { get; private set; }
        public long FormTemplateId { get; private set; }
        public long ObservationId { get; private set; }

        public override string ToString()
        {
            return string.Format("CaseId={0}, FormTemplateId={1}, ObservationId={2}", CaseId, FormTemplateId, ObservationId);
        }
    }
}