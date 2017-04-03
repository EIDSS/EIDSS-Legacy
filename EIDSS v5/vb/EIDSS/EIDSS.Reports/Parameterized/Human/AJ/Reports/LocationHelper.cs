using System.Linq;
using bv.common.Core;
using eidss.model.Resources;

namespace EIDSS.Reports.Parameterized.Human.AJ.Reports
{
    public static class LocationHelper
    {
        private const long OtherRayonsId = 1344340000000;

        private static readonly long[] m_CityList = new[]
            {
                1344470000000,
                1344650000000,
                1344830000000,
                1344890000000,
                1344920000000
            };

        public static string GetLocation
            (string language, string countryName, long? regionId, string regionName, long? rayonId, string rayonName)
        {
            string location;
            if (regionId.HasValue)
            {
                if (rayonId.HasValue)
                {
                    location = regionId.Value == OtherRayonsId
                                   ? rayonName
                                   : string.Format("{0}, {1}", regionName, rayonName);
                    if (language == Localizer.lngRu && !m_CityList.Contains(rayonId.Value))
                    {
                        location += EidssMessages.Get("report_rayon_suffix");
                    }
                }
                else
                {
                    location = regionName;
                }
            }
            else
            {
                location = countryName;
            }
            return location;
        }
    }
}