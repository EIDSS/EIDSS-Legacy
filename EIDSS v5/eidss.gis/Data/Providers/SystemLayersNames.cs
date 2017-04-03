using System.Linq;
using eidss.gis.common;

namespace eidss.gis.Data.Providers
{

    /// <summary>
    /// System tables name consts
    /// </summary>
    public struct SystemLayerNames
    {
        public const string Countries = "gisWKBCountry";
        public const string Regions = "gisWKBRegion";
        public const string Rayons = "gisWKBRayon";
        public const string Settlements = "gisWKBSettlement";

        private static string[] m_AllSystemLayerNames = {Countries, Regions, Rayons, Settlements};
        
        public static bool IsSystemLayerName(string tableName)
        {
            return m_AllSystemLayerNames.Contains(tableName);
        }

        /// <summary>
        /// Return GIS type (long) in EIDSS DB 
        /// </summary>
        /// <param name="tableName">Table Name</param>
        /// <returns></returns>
        public static GisDbType ToGisDbType(string tableName)
        {
            switch(tableName)
            {
                case Countries:
                    return GisDbType.RftCountry;
                case Regions:
                    return GisDbType.RftRegion;
                case Rayons:
                    return GisDbType.RftRayon;
                case Settlements:
                    return GisDbType.RftSettlement;
                default:
                    return GisDbType.Unknown;
            }
        }
    }


}