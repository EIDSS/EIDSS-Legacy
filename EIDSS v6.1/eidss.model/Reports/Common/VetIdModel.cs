using System;

namespace eidss.model.Reports.Common
{
    [Serializable]
    public class VetIdModel : BaseIdModel
    {
        public VetIdModel(string language, long id, long diagnosisId, bool includeMap, bool useArchive) : base(language, id, useArchive)
        {
            DiagnosisId = diagnosisId;
            IncludeMap = includeMap;
        }

        public long DiagnosisId { get; set; }
        public bool IncludeMap { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, DiagnosisId={1} IncludeMap={2}", base.ToString(), DiagnosisId, IncludeMap);
        }
    }
}