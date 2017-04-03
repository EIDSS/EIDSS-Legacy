using System;

namespace eidss.model.Reports.Common
{
    [Serializable]
    public class VetIdModel : BaseIdModel
    {
        public VetIdModel(string language, long id, long diagnosisId, bool useArchive) : base(language, id, useArchive)
        {
            DiagnosisId = diagnosisId;
        }

        public long DiagnosisId { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, DiagnosisId={1}", base.ToString(), DiagnosisId);
        }
    }
}