using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eidss.model.Enums
{
    public enum CustomMandatoryField : long
    {
        HumanCase_DiagnosisDate = 1,
        HumanCase_Patient_FirstName = 2,
        HumanCase_Patient_DateOfBirth = 3,
        HumanCase_Patient_Age = 4,
        HumanCase_Patient_AgeType = 5,
        HumanCase_Patient_Gender = 6,
        HumanCase_Patient_CurrentResidence_Settlement = 7,
        HumanCase_DateOfSymptomsOnSet = 8,
        HumanCase_Patient_RegistrationAddress_Region = 9,
        HumanCase_Patient_RegistrationAddress_Rayon = 10,
        HumanCase_Patient_RegistrationAddress_Settlement = 11,
        HumanCase_PointGeoLocation = 12,
        HumanCase_ExposureDate = 13,
        HumanCase_InitialCaseStatus = 14,
        VetCase_CaseClassification = 15,
        VetCase_Farm_Address_Settlement = 16,
        VetCase_TentativeDiagnosis = 17,
        VetCase_Tentative1Diagnosis = 18,
        VetCase_Tentative2Diagnosis = 19,
        VetCase_FinalDiagnosis = 20,
        ASCampaign_StartDate = 21,
        ASCampaign_EndDate = 22,
        ASSession_StartDate = 23,
        ASSession_EndDate = 24,
        ASSession_Rayon = 25,
        HumanCase_FinalCaseStatus = 26,
        HumanCase_CompletionPaperFormDate = 27,
        HumanCase_SentByPerson = 28,
        HumanCase_SentByOffice = 29,
        VetCase_TentativeDiagnosisDate = 30,
        VetCase_TentativeDiagnosis1Date = 31,
        VetCase_TentativeDiagnosis2Date = 32,
        VetCase_FinalDiagnosisDate = 33,
        VetCase_Farm_FarmOwnerLastName = 34,
        VetCase_Farm_FarmName = 35,
        VetCase_ReportedByOffice = 36,
        VetCase_PersonReportedBy = 37,
        VetCase_Farm_FarmOwnerFirstName = 38,
    }
}
