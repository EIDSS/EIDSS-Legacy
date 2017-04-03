using System;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using Eidss.Web;
using bv.model.BLToolkit;
using eidss.model.Core;
using eidss.model.Schema;


namespace EIDSS.Web
{
    public class SampleInfo
    {
        [XmlIgnore]
        [FieldName("idfContainer")]
        public long Id { get; set; }
        [FieldName("strBarcode")]
        public string SampleID { get; set; }
        [FieldName("strFieldBarcode")]
        public string FieldID { get; set; }
        [FieldName("idfsSpecimenType")]
        public BaseReferenceItem Type { get; set; }
        [FieldName("datFieldCollectionDate")]
        public DateTime? CollectionDate { get; set; }
        [FieldName("CaseID")]
        public string CaseID { get; set; }
        [FieldName("ParentBarcode")]
        public string ParentSampleID { get; set; }
        [FieldName("datAccession")]
        public DateTime? AccessionDate { get; set; }
        [FieldName("AnimalName")]
        public string AnimalID { get; set; }

        public static SampleInfo[] GetAll(SampleInfo filter)
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                return LabSampleListItem.Accessor.Instance(null)
                    .SelectListT(manager, FilterAutoBuilder.BuildFilter(filter))
                    .Select(
                        c => new SampleInfo()
                        {
                            Id = c.idfContainer,
                            SampleID = c.strBarcode,
                            FieldID  = c.strFieldBarcode,
                            Type = new BaseReferenceItem() { Id = c.idfsSpecimenType, Name = c.SampleType != null ? c.SampleType.name : "" },
                            CollectionDate = c.datFieldCollectionDate,
                            CaseID = c.CaseID,
        //[FieldName("ParentBarcode")]
        //ParentSampleID = c.str
                            AccessionDate = c.datAccession,
                            AnimalID = c.AnimalName
                        }
                    ).ToArray();
            }
        }
    }
}
