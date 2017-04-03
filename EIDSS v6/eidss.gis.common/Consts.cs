using System;

namespace eidss.gis.common
{
    /// <summary>
    /// Type codes in EIDSS DB
    /// </summary>
    public enum GisDbType: long
    {
        Unknown = 0,
        RftCountry = 19000001,
        RftRayon = 19000002,
        RftRegion = 19000003,
        RftSettlement = 19000004,
        RftSettlementType = 19000005,
        RftLanguage = 19000049
    }
}
