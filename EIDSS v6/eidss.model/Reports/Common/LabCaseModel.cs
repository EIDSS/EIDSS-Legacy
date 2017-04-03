using System;
using eidss.model.Core;

namespace eidss.model.Reports.Common
{
    [Serializable]
    public class LabCaseModel : BaseModel
    {
        public LabCaseModel()
        {
        }

        public LabCaseModel(string language, string caseId, bool useArchive)
            : base(language, useArchive)
        {
            CaseId = caseId;
        }

        [LocalizedDisplayName("strCaseID")]
        public string CaseId { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, case ID={1}", base.ToString(), CaseId);
        }
    }
}