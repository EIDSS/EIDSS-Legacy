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
    public class VetCaseListInfo
    {
        [XmlIgnore]
        [FieldName("idfCase")]
        public long Id { get; set; }
        [FieldName("strCaseID")]
        public string CaseID { get; set; }
        [FieldName("idfsCaseStatus")]
        public BaseReferenceItem CaseClassification  { get; set; }
        [FieldName("datReportDate")]
        public DateTime? ReportedDate  { get; set; }
        [FieldName("strNationalName")]
        public string FarmName  { get; set; }
        [FieldName("strFarmCode")]
        public string FarmID  { get; set; }
        [FieldName("FarmAddress")]
        public AddressInfo FarmAddress  { get; set; }
        [FieldName("intTotalAnimalQty")]
        public int? TotalAnimals  { get; set; }
        [FieldName("intSickAnimalQty")]
        public int? SickAnimals  { get; set; }
        [FieldName("intDeadAnimalQty")]
        public int? DeadAnimals  { get; set; }
        [FieldName("idfsDiagnosis")]
        public BaseReferenceItem Diagnosis  { get; set; }

        public static VetCaseListInfo[] GetAll(VetCaseListInfo filter)
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                return VetCaseListItem.Accessor.Instance(null)
                    .SelectListT(manager, FilterAutoBuilder.BuildFilter(filter))
                    .Select(
                        c => new VetCaseListInfo()
                        {
                            Id = c.idfCase,
                            CaseID = c.strCaseID,
                            CaseClassification = new BaseReferenceItem() { Id = c.idfsCaseClassification, Name = c.CaseClassification != null ? c.CaseClassification.name : "" },
                            ReportedDate = c.datReportDate,
                            FarmName = c.strNationalName,
                            FarmID = c.strFarmCode,
                            FarmAddress = new AddressInfo()
                            {
                                idfGeoLocation = c.idfAddress.Value,
                                Country = new BaseReferenceItem() { Id = c.idfsCountry, Name = c.Country != null ? c.Country.strCountryName : "" },
                                Region = new BaseReferenceItem() { Id = c.idfsRegion, Name = c.Region != null ? c.Region.strRegionName : "" },
                                Rayon = new BaseReferenceItem() { Id = c.idfsRayon, Name = c.Rayon != null ? c.Rayon.strRayonName : "" },
                                Settlement = new BaseReferenceItem() { Id = c.idfsSettlement, Name = c.Settlement != null ? c.Settlement.strSettlementName : "" }
                            },
                            TotalAnimals = c.intTotalAnimalQty,
                            SickAnimals = c.intSickAnimalQty,
                            DeadAnimals = c.intDeadAnimalQty,
                            Diagnosis = new BaseReferenceItem() { Id = c.idfsDiagnosis, Name = c.Diagnosis != null ? c.Diagnosis.name : "" }
                        }).ToArray();
            }
        }
    }
}
