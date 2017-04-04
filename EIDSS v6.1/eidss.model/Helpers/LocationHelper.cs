using System.Linq;
using eidss.model.Schema;

namespace eidss.model.Helpers
{
    public static class LocationHelper
    {
        public static void CopyLocation(GeoLocation locationFrom, GeoLocation locationTo)
        {
            locationTo.GeoLocationType =
                locationFrom.GeoLocationType != null
                ? locationTo.GeoLocationTypeLookup.FirstOrDefault(c => c.idfsBaseReference == locationFrom.GeoLocationType.idfsBaseReference)
                : locationTo.GeoLocationType;

            locationTo.Country =
                locationFrom.Country != null
                ? locationTo.CountryLookup.FirstOrDefault(c => c.idfsCountry == locationFrom.Country.idfsCountry)
                : locationTo.Country;

            locationTo.strDescription = locationFrom.strDescription;
            locationTo.blnGeoLocationShared = locationFrom.blnGeoLocationShared;
            locationTo.Region = locationFrom.idfsRegion.HasValue
                                      ? locationTo.RegionLookup.SingleOrDefault(
                                          c => c.idfsRegion == locationFrom.idfsRegion.Value)
                                      : locationTo.Region;
            locationTo.Rayon = locationFrom.idfsRayon.HasValue
                                     ? locationTo.RayonLookup.SingleOrDefault(c => c.idfsRayon == locationFrom.idfsRayon.Value)
                                     : locationTo.Rayon;
            locationTo.Settlement = locationFrom.idfsSettlement.HasValue
                                          ? locationTo.SettlementLookup.SingleOrDefault(
                                              c => c.idfsSettlement == locationFrom.idfsSettlement.Value)
                                          : locationTo.Settlement;
            locationTo.dblLatitude = locationFrom.dblLatitude;
            locationTo.dblLongitude = locationFrom.dblLongitude;
            locationTo.dblDistance = locationFrom.dblDistance;
            locationTo.dblAlignment = locationFrom.dblAlignment;
            locationTo.dblAccuracy = locationFrom.dblAccuracy;
            locationTo.GroundType = locationFrom.GroundType;
            locationTo.blnForeignAddress = locationFrom.blnForeignAddress;
            locationTo.strForeignAddress = locationFrom.strForeignAddress;
        }

    }
}
