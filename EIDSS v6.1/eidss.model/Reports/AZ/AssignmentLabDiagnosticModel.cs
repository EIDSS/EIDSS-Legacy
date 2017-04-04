using System;
using System.Collections.Generic;
using bv.common.Core;
using eidss.model.Core;
using eidss.model.Reports.Common;

namespace eidss.model.Reports.AZ
{
    [Serializable]
    public class AssignmentLabDiagnosticModel : BaseModel
    {
        public AssignmentLabDiagnosticModel()
        {
        }

        public AssignmentLabDiagnosticModel(string language, string caseId, long? sentToId, bool useArchive)
            : base(language,  useArchive)
        {
            SentTo = sentToId;
            CaseId = caseId;
        }

        [LocalizedDisplayName("strCaseID")]
        public string CaseId { get; set; }

        [LocalizedDisplayName("strSentTo")]
        public long? SentTo { get; set; }
        public List<SelectListItemSurrogate> SentToList
        {
            get
            {
                if (!string.IsNullOrEmpty(CaseId))
                    return FilterHelper.GetAssignmentLabDiagnosticAZSendToLookup(CaseId, Localizer.CurrentCultureLanguageID);
                return new List<SelectListItemSurrogate>();
            }
        }

        public override string ToString()
        {
            return string.Format("{0}, sent to ID={1}, case ID={2}", base.ToString(), SentTo, CaseId);
        }
    }
}