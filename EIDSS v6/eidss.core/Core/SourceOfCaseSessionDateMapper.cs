using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eidss.model.Enums;
using eidss.model.Resources;

namespace eidss.model.Core
{
    public class SourceOfCaseSessionDateMapper
    {
        public static string Map(SourceOfCaseSessionDate sourceDate)
        {
            string resId = null;
            switch (sourceDate)
            {
                case SourceOfCaseSessionDate.HcDateOfSymptomsOnset:
                    resId = "datOnSetDate";
                    break;
                case SourceOfCaseSessionDate.HcDatePatientFirstSoughtCare:
                    resId = "datFirstSoughtCareDate";
                    break;
                case SourceOfCaseSessionDate.HcDiagnosisDate:
                    resId = "datDiagnosisDate";
                    break;
                case SourceOfCaseSessionDate.HcNotificationDate:
                    resId = "datNotificationDate";
                    break;
                case SourceOfCaseSessionDate.HcDateEntered:
                    resId = "datEnteredDate";
                    break;
                case SourceOfCaseSessionDate.VcStartOfSigns:
                    resId = "datStartOfSignsDate";
                    break;
                case SourceOfCaseSessionDate.VcInitialReportDate:
                    resId = "datInitialReportDate";
                    break;
                case SourceOfCaseSessionDate.VcAssignedDate:
                    resId = "datAssignedDate";
                    break;
                case SourceOfCaseSessionDate.VcInvestigationDate:
                    resId = "datInvestigationDate";
                    break;
                case SourceOfCaseSessionDate.VcTentativeDiagnosis1Date:
                    resId = "datTentativeDiagnosisDateLbl";
                    break;
                case SourceOfCaseSessionDate.VcTentativeDiagnosis2Date:
                    resId = "datTentativeDiagnosis1DateLbl";
                    break;
                case SourceOfCaseSessionDate.VcTentativeDiagnosis3Date:
                    resId = "datTentativeDiagnosis2DateLbl";
                    break;
                case SourceOfCaseSessionDate.VcFinalDiagnosisDate:
                    resId = "datFinalDiagnosisDate";
                    break;
                case SourceOfCaseSessionDate.VcDateEntered:
                    resId = "datEnteredDate";
                    break;
                case SourceOfCaseSessionDate.VssStartDate:
                    resId = "datStartDate";
                    break;
            }

            return resId == null ? "" : EidssFields.Instance.GetString(resId);
        }
    }
}
