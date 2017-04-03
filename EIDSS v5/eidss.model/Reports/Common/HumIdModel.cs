using System;
using eidss.model.Core;

namespace eidss.model.Reports.Common
{
    [Serializable]
    public class HumIdModel : BaseIdModel
    {
        public HumIdModel(string language, long id, long epiId, long csId, long diagnosisId, bool useArchive)
            : base(language, id, useArchive)
        {
            EpiId = epiId;
            CsId = csId;
            DiagnosisId = diagnosisId;
        }

        public long EpiId { get; set; }
        public long CsId { get; set; }
        public long DiagnosisId { get; set; }

        public override string ToString()
        {
            return  string.Format("{0} Epi Id={1}, SC Id={2}", base.ToString(), EpiId, CsId);
        }
    }
}