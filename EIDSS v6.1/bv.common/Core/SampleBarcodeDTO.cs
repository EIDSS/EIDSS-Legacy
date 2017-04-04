using System;

namespace bv.common.Core
{
    public class SampleBarcodeDTO
    {
        public string OwnerId { get; set; }
        public string Barcode { get; set; }
        public string SpeciesCode { get; set; }
        public string SpecimenCode { get; set; }
        public DateTime CollectionDate { get; set; }
    }
}