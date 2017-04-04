using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eidss.model.Enums
{
    public enum SourceOfCaseSessionDate
    {
        //Human case dates
        HcDateOfSymptomsOnset = 1,
        HcDatePatientFirstSoughtCare = 2,
        HcDiagnosisDate = 3,
        HcNotificationDate = 4,
        HcDateEntered = 5,
        //Vet case dates
        VcStartOfSigns = 6,
        VcInitialReportDate = 7,
        VcAssignedDate = 8,
        VcInvestigationDate = 9,
        VcTentativeDiagnosis1Date = 10,
        VcTentativeDiagnosis2Date = 11,
        VcTentativeDiagnosis3Date = 12,
        VcFinalDiagnosisDate = 13,
        VcDateEntered = 14,
        //Vs session dates
        VssStartDate = 15
    }
}
