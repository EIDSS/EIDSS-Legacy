using System;
using System.Linq;
using System.Data;
using System.Xml.Serialization;
using bv.common;
using System.Collections.Generic;
using bv.model.BLToolkit;
using eidss.model.Core;
using eidss.model.Schema;

namespace Eidss.Web
{
    public class HumanCaseListInfo
    {
        [FieldName("idfCase")]
        public long Id { get; set; }
        [FieldName("strCaseID")]
        public string CaseID { get; set; }
        [FieldName("strLocalIdentifier")]
        public string LocalID { get; set; }
        [FieldName("datEnteredDate")]
        public DateTime? EnteredDate { get; set; }
        [FieldName("idfsDiagnosis")]
        public BaseReferenceItem Diagnosis { get; set; }
        [FieldName("idfsInitialCaseStatus")]
        public BaseReferenceItem CaseClassification { get; set; }
        [FieldName("idfsCaseProgressStatus")]
        public BaseReferenceItem CaseStatus { get; set; }
        [FieldName("datDateofBirth")]
        public DateTime? DateOfBirth { get; set; }
        [FieldName("GeoLocationName")]
        public string Location { get; set; }
        [FieldName("intPatientAge")]
        public int? PatientAge { get; set; }
        [FieldName("idfsHumanAgeType")]
        public BaseReferenceItem PatientAgeType { get; set; }

        public static HumanCaseListInfo[] GetAll()
        {
            return GetAll(new HumanCaseListInfo());
        }

        public static HumanCaseListInfo[] GetAll(HumanCaseListInfo filter)
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                return HumanCaseListItem.Accessor.Instance(null)
                    .SelectListT(manager, FilterAutoBuilder.BuildFilter(filter))
                    .Select(
                        c => new HumanCaseListInfo()
                        {
                            Id = c.idfCase,
                            CaseID = c.strCaseID,
                            LocalID = c.strLocalIdentifier,
                            Diagnosis = new BaseReferenceItem() { Id = c.idfsDiagnosis, Name = c.DiagnosisName },
                            CaseClassification = new BaseReferenceItem() { Id = c.idfsInitialCaseStatus, Name = c.CaseClassification != null ? c.CaseClassification.name : "" },
                            CaseStatus = new BaseReferenceItem() { Id = c.idfsCaseStatus, Name = c.CaseStatusName },
                            EnteredDate = c.datEnteredDate,
                            DateOfBirth = c.datDateofBirth,
                            Location = c.GeoLocationName,
                            PatientAge = c.intPatientAge,
                            PatientAgeType = new BaseReferenceItem() { Id = c.idfsHumanAgeType, Name = c.HumanAgeType != null ? c.HumanAgeType.name : "" }
                        }).ToArray();
            }
        }
        
    }
}

