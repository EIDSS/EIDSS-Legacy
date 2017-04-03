using System;
using System.Collections.Generic;
using eidss.model.Core;
using eidss.model.Reports.Common;

namespace eidss.model.Reports.GG
{
    [Serializable]
    public class VetLaboratoryResearchResultModel : BaseModel
    {
        public VetLaboratoryResearchResultModel()
        {
            
        }

        public VetLaboratoryResearchResultModel
            (string language, string caseId, string sessionId, string registrationNumber, string conditionSampleReceived,
                string resultRecipient, bool useArchive) :
                    base(language, useArchive)
        {
            CaseId = caseId;
            SessionId = sessionId;
            RegistrationNumber = registrationNumber;
            ConditionSampleReceived = conditionSampleReceived;
            ResultRecipient = resultRecipient;
        }

        [LocalizedDisplayName("strCaseID")]
        public string CaseId { get; set; }

        [LocalizedDisplayName("strSessionID")]
        public string SessionId { get; set; }

        [LocalizedDisplayName("RegistrationNumber")]
        public string RegistrationNumber { get; set; }

        [LocalizedDisplayName("ConditionSampleReceived")]
        public string ConditionSampleReceived { get; set; }

        [LocalizedDisplayName("ResultRecipient")]
        public string ResultRecipient { get; set; }

        public int cbConditionSampleReceived { get; set; }
        public int cbReportSource { get; set; }
        
        [LocalizedDisplayName("ReportSource")]
        public int idReportSource { get; set; }
        
        public List<SelectListItemSurrogate> ReportSourcesList
        {
            get
            {
                return FilterHelper.GetWebReportSourceList(-1, true);
            }
        }

        public List<SelectListItemSurrogate> ConditionSampleReceivedList
        {
            get { return FilterHelper.GetWebReportConditionList(-1); }
        }
    }
}