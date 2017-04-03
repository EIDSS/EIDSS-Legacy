using System;
using System.Data;
using System.Xml.Serialization;
using bv.common;

namespace Eidss.Web
{
    public class AddressInfo
    {
        [XmlIgnore]
        [FieldName("idfGeoLocation")]
        public long idfGeoLocation { get; set; }
        [FieldName("idfsCountry")]
        public BaseReferenceItem Country { get; set; }
        [FieldName("idfsRegion")]
        public BaseReferenceItem Region { get; set; }
        [FieldName("idfsRayon")]
        public BaseReferenceItem Rayon { get; set; }
        [FieldName("idfsSettlement")]
        public BaseReferenceItem Settlement { get; set; }
        [FieldName("strBuilding")]
        public string Building { get; set; }
        [FieldName("strHouse")]
        public string House { get; set; }
        [FieldName("strApartment")]
        public string Apartment { get; set; }
        [FieldName("strStreetName")]
        public string Street { get; set; }
        [FieldName("strPostCode")]
        public string ZipCode { get; set; }
        [FieldName("strHomePhone")]
        public string HomePhone { get; set; }
    }
}
