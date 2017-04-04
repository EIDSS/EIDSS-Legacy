using System;
using eidss.model.Core;

namespace eidss.webclient.Models.Reports
{
    [Serializable]
    public class ComparativeIQModel : ComparativeModel
    {
        public ComparativeIQModel() 
        {
            CanWorkWithArchive = false;
        }
        [LocalizedDisplayName("strProvince1")]
        public string ProvinceCaption1 { get; set; }

        [LocalizedDisplayName("strProvince2")]
        public string ProvinceCaption2 { get; set; }

        [LocalizedDisplayName("strDistrict1")]
        public string DistrictCaption1 { get; set; }

        [LocalizedDisplayName("strDistrict2")]
        public string DistrictCaption2 { get; set; }
    }
}