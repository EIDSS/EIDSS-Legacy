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
    public class VetCaseInfo
    {
        [XmlIgnore]
        [FieldName("idfCase")]
        public long Id { get; set; }
        [FieldName("strCaseID")]
        public string CaseID { get; set; }
        [FieldName("strFieldAccessionID")]
        public string FieldID  { get; set; }
        [FieldName("idfsCaseStatus")]
        public BaseReferenceItem CaseClassification  { get; set; }
        [FieldName("ReportedByPerson")]
        public string ReportedByPerson  { get; set; }
        [FieldName("datReportDate")]
        public DateTime? ReportedDate  { get; set; }
        [FieldName("strNationalName")]
        public string FarmName  { get; set; }
        [FieldName("strFarmCode")]
        public string FarmID  { get; set; }
        [FieldName("strFirstName")]
        public string FarmOwnerFirstName  { get; set; }
        [FieldName("strSecondName")]
        public string FarmOwnerSecondName  { get; set; }
        [FieldName("strLastName")]
        public string FarmOwnerLastName  { get; set; }
        [FieldName("FarmAddress")]
        public AddressInfo FarmAddress  { get; set; }
        [FieldName("intTotalAnimalQty")]
        public int? TotalAnimals  { get; set; }
        [FieldName("intSickAnimalQty")]
        public int? SickAnimals  { get; set; }
        [FieldName("intDeadAnimalQty")]
        public int? DeadAnimals  { get; set; }
        [FieldName("idfsTentativeDiagnosis")]
        public BaseReferenceItem Diagnosis1  { get; set; }
        [FieldName("idfsTentativeDiagnosis1")]
        public BaseReferenceItem Diagnosis2  { get; set; }
        [FieldName("idfsTentativeDiagnosis2")]
        public BaseReferenceItem Diagnosis3  { get; set; }
        [FieldName("idfsFinalDiagnosis")]
        public BaseReferenceItem FinalDiagnosis  { get; set; }

        public static VetCaseInfo GetById(string id)
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var vc = VetCase.Accessor.Instance(null).SelectByKey(manager, long.Parse(id));
                return new VetCaseInfo()
                {
                    Id = vc.idfCase,
                    CaseID = vc.strCaseID,
                    FieldID = vc.strFieldAccessionID,
                    CaseClassification = new BaseReferenceItem() { Id = vc.idfsCaseStatus, Name = vc.CaseStatus != null ? vc.CaseStatus.name : "" },
                    ReportedByPerson = vc.strPersonReportedBy,
                    ReportedDate = vc.datReportDate,
                    FarmName = vc.Farm.strNationalName,
                    FarmID = vc.Farm.strFarmCode,
                    FarmOwnerFirstName = vc.Farm.strOwnerFirstName,
                    FarmOwnerSecondName = vc.Farm.strOwnerMiddleName,
                    FarmOwnerLastName = vc.Farm.strOwnerLastName,
                    FarmAddress = new AddressInfo()
                    {
                        idfGeoLocation = vc.Farm.Address.idfGeoLocation,
                        Country = new BaseReferenceItem() { Id = vc.Farm.Address.idfsCountry, Name = vc.Farm.Address.Country != null ? vc.Farm.Address.Country.strCountryName : "" },
                        Region = new BaseReferenceItem() { Id = vc.Farm.Address.idfsRegion, Name = vc.Farm.Address.Region != null ? vc.Farm.Address.Region.strRegionName : "" },
                        Rayon = new BaseReferenceItem() { Id = vc.Farm.Address.idfsRayon, Name = vc.Farm.Address.Rayon != null ? vc.Farm.Address.Rayon.strRayonName : "" },
                        Settlement = new BaseReferenceItem() { Id = vc.Farm.Address.idfsSettlement, Name = vc.Farm.Address.Settlement != null ? vc.Farm.Address.Settlement.strSettlementName : "" },
                        Street = vc.Farm.Address.strStreetName,
                        ZipCode = vc.Farm.Address.strPostCode
                    },
                    TotalAnimals = vc.Farm.FarmTree[0].intTotalAnimalQty,
                    SickAnimals = vc.Farm.FarmTree[0].intSickAnimalQty,
                    DeadAnimals = vc.Farm.FarmTree[0].intDeadAnimalQty,
                    Diagnosis1 = new BaseReferenceItem() { Id = vc.idfsTentativeDiagnosis, Name = vc.TentativeDiagnosis != null ? vc.TentativeDiagnosis.name : "" },
                    Diagnosis2 = new BaseReferenceItem() { Id = vc.idfsTentativeDiagnosis1, Name = vc.TentativeDiagnosis1 != null ? vc.TentativeDiagnosis1.name : "" },
                    Diagnosis3 = new BaseReferenceItem() { Id = vc.idfsTentativeDiagnosis2, Name = vc.TentativeDiagnosis2 != null ? vc.TentativeDiagnosis2.name : "" },
                    FinalDiagnosis = new BaseReferenceItem() { Id = vc.idfsFinalDiagnosis, Name = vc.FinalDiagnosis != null ? vc.FinalDiagnosis.name : "" }
                };
            }
        }
    }
}
