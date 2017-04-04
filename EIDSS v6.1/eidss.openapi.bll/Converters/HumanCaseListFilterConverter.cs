using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using BLToolkit.EditableObjects;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.openapi.bll.Exceptions;
using eidss.openapi.contract;

namespace eidss.openapi.bll.Converters
{
    internal class HumanCaseListFilterConverter :
        AbstractFieldConverter<eidss.openapi.contract.HumanCaseListFilter, eidss.model.Schema.HumanCaseListItem>
    {
        private static HumanCaseListFilterConverter _instance = new HumanCaseListFilterConverter();
        private HumanCaseListFilterConverter() { }
        public static HumanCaseListFilterConverter Instance { get { return _instance; } }


        public static List<MappingItem> _filedMatcher = new List<MappingItem>()
            {
                new MappingItem(c => c.RecordID, c => c.idfCase, OperationType.Equal),
                new MappingItem(c => c.Diagnosis, c => c.idfsDiagnosis, OperationType.Equal),
                new MappingItem(c => c.FinalDiagnosis, c => c.idfsFinalDiagnosis, OperationType.Equal),
                new MappingItem(c => c.FinalCaseClassification, c => c.idfsCaseStatus, OperationType.Equal),
                new MappingItem(c => c.CaseStatus, c => c.idfsCaseProgressStatus, OperationType.Equal),
                new MappingItem(c => c.NotificationSentByFacility, "idfSentByOffice", OperationType.Equal),
                new MappingItem(c => c.NotificationReceivedByFacility, "idfReceivedByOffice", OperationType.Equal),
                new MappingItem(c => c.NotificationSentByOfficer, "idfSentByPerson", OperationType.Equal),
                new MappingItem(c => c.NotificationReceivedByOfficer, "idfReceivedByPerson", OperationType.Equal),
                new MappingItem(c => c.AgeType, c => c.idfsHumanAgeType, OperationType.Equal),
                new MappingItem(c => c.Sex, c => c.idfsHumanGender, OperationType.Equal),
                new MappingItem(c => c.NationalityCitizenship, c => c.idfsNationality, OperationType.Equal),
                new MappingItem(c => c.Outcome, "idfsOutcome", OperationType.Equal),
                new MappingItem(c => c.Hospitalization, c => c.idfsHospitalizationStatus, OperationType.Equal),
                new MappingItem(c => c.CurrentResidenceCountry, c => c.idfsCountry, OperationType.Equal),
                new MappingItem(c => c.CurrentResidenceRegion, c => c.idfsRegion, OperationType.Equal),
                new MappingItem(c => c.CurrentResidenceRayon, c => c.idfsRayon, OperationType.Equal),
                new MappingItem(c => c.CurrentResidenceSettlement, c => c.idfsSettlement, OperationType.Equal),
                new MappingItem(c => c.AgeFrom, c => c.intPatientAge, OperationType.MoreOrEqualThan),
                new MappingItem(c => c.AgeTo, c => c.intPatientAge, OperationType.LessOrEqualThan),

                new MappingItem(c => c.CaseID, c => c.strCaseID, OperationType.Like),
                new MappingItem(c => c.LocalID, c => c.strLocalIdentifier, OperationType.Like),
                new MappingItem(c => c.PatientLastName, c => c.strLastName, OperationType.Like),
                new MappingItem(c => c.PatientFirstName, c => c.strFirstName, OperationType.Like),
                new MappingItem(c => c.PatientMiddleName, c => c.strSecondName, OperationType.Like),
                new MappingItem(c => c.PatientPhoneNumber, "strHomePhone", OperationType.Like),
                new MappingItem(c => c.EmployerName, "strEmployerName", OperationType.Like),
                new MappingItem(c => c.AdditionalInformationComments, "strNote", OperationType.Like),
                new MappingItem(c => c.PlaceOfHospitalization, "strHospitalizationPlace", OperationType.Like),

                new MappingItem(c => c.DateEnteredFrom, c => c.datEnteredDate, OperationType.MoreOrEqualThan),
                new MappingItem(c => c.DateEnteredTo, c => c.datEnteredDate, OperationType.LessOrEqualThan),
                new MappingItem(c => c.DateOfBirthFrom, c => c.datDateofBirth, OperationType.MoreOrEqualThan),
                new MappingItem(c => c.DateOfBirthTo, c => c.datDateofBirth, OperationType.LessOrEqualThan),
                new MappingItem(c => c.DiagnosisDateFrom, "datTentativeDiagnosisDate", OperationType.MoreOrEqualThan),
                new MappingItem(c => c.DiagnosisDateTo, "datTentativeDiagnosisDate", OperationType.LessOrEqualThan),
                new MappingItem(c => c.DateOfFinalDiagnosisFrom, "datFinalDiagnosisDate", OperationType.MoreOrEqualThan),
                new MappingItem(c => c.DateOfFinalDiagnosisTo, "datFinalDiagnosisDate", OperationType.LessOrEqualThan),
                new MappingItem(c => c.DateOfCompletionOfPaperFormFrom, c => c.datCompletionPaperFormDate, OperationType.MoreOrEqualThan),
                new MappingItem(c => c.DateOfCompletionOfPaperFormTo, c => c.datCompletionPaperFormDate, OperationType.LessOrEqualThan),
                new MappingItem(c => c.DateOfSymptomOnsetForm, "datOnSetDate", OperationType.MoreOrEqualThan),
                new MappingItem(c => c.DateOfSymptomOnsetTo, "datOnSetDate", OperationType.LessOrEqualThan),
                new MappingItem(c => c.NotificationDateForm, "datNotificationDate", OperationType.MoreOrEqualThan),
                new MappingItem(c => c.NotificationDateTo, "datNotificationDate", OperationType.LessOrEqualThan),
            };

        public override List<MappingItem> MappingList
        {
            get { return _filedMatcher; }
        }
    }
}