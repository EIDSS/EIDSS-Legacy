using System;

namespace eidss.model.Reports.Common
{
    [Serializable]
    public class AggregateModel : BaseIdModel
    {
        public AggregateModel(string language, long id, long formTemplateId, long observationId, bool useArchive)
            : base(language, id, useArchive)
        {
            FormTemplateId = formTemplateId;
            ObservationId = observationId;
        }

        public long FormTemplateId { get; set; }
        public long ObservationId { get; set; }

        public static explicit operator AggregateReportParameters(AggregateModel model)
        {
            return new AggregateReportParameters(model.Id, model.FormTemplateId, model.ObservationId);
        }
    }
}