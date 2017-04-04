using System.Collections.Generic;
using eidss.model.Schema;

namespace eidss.model.Helpers
{
    public class LocationPersonalDataHelper
    {
        private readonly List<CountryLookup> m_Countries;
        private readonly List<RegionLookup> m_Regions;
        private readonly List<RayonLookup> m_Rayons;
        private readonly List<SettlementLookup> m_Settlements;
        public LocationPersonalDataHelper
            (List<CountryLookup> countries, List<RegionLookup> regions, List<RayonLookup> rayons,
             List<SettlementLookup> settlements)
        {
            m_Countries = countries;
            m_Regions = regions;
            m_Rayons = rayons;
            m_Settlements = settlements;
        }
        private CountryLookup m_CurrentCountry;
        public string GetCountryName(long? idfsCountry)
        {
            if (m_CurrentCountry != null && m_CurrentCountry.idfsCountry == idfsCountry)
                return m_CurrentCountry.strCountryName;
            if (idfsCountry == null)
            {
                m_CurrentCountry = null;
                return string.Empty;
            }
            m_CurrentCountry = m_Countries.Find(c => c.idfsCountry == idfsCountry);
            return (m_CurrentCountry == null) ? string.Empty : m_CurrentCountry.strCountryName;
        }
        private RegionLookup m_CurrentRegion;
        public string GetRegionName(long? idfsRegion)
        {
            if (m_CurrentRegion != null && m_CurrentRegion.idfsRegion == idfsRegion)
                return m_CurrentRegion.strRegionName;
            if (idfsRegion == null)
            {
                m_CurrentRegion = null;
                return string.Empty;
            }
            m_CurrentRegion = m_Regions.Find(c => c.idfsRegion == idfsRegion);
            return (m_CurrentRegion == null) ? string.Empty : m_CurrentRegion.strRegionName;
        }
        private RayonLookup m_CurrentRayon;
        public string GetRayonName(long? idfsRayon)
        {
            if (m_CurrentRayon != null && m_CurrentRayon.idfsRayon == idfsRayon)
                return m_CurrentRayon.strRayonName;
            if (idfsRayon == null)
            {
                m_CurrentRayon = null;
                return string.Empty;
            }
            m_CurrentRayon = m_Rayons.Find(c => c.idfsRayon == idfsRayon);
            return (m_CurrentRayon == null) ? string.Empty : m_CurrentRayon.strRayonName;
        }
        private SettlementLookup m_CurrentSettlement;
        public string GetSettlementName(long? idfsSettlement)
        {
            if (m_CurrentSettlement != null && m_CurrentSettlement.idfsSettlement == idfsSettlement)
                return m_CurrentSettlement.strSettlementName;
            if (idfsSettlement == null)
            {
                m_CurrentSettlement = null;
                return string.Empty;
            }
            m_CurrentSettlement = m_Settlements.Find(c => c.idfsSettlement == idfsSettlement);
            return (m_CurrentSettlement == null) ? string.Empty : m_CurrentSettlement.strSettlementName;
        }
    }
}
