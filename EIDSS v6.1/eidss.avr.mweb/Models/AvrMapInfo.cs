using System.Configuration;
using System.Globalization;
using bv.common.Core;
using eidss.gis;
using eidss.gis.common;
using eidss.gis.Tools;

namespace eidss.avr.mweb.Models
{
    public class AvrMapInfo
    {
        public string m_InfoResult;
        public string[] m_InfoRegion;
        public string[] m_InfoRayon;
        public string m_InfoSettlement;
        public AvrMapInfo(double pLon, double pLat)
        {
            //MtInfo mtInfo = new MtInfo();
            //var connectionCredentials = new bv.common.Configuration.ConnectionCredentials();
            //mtInfo.ConnectionString = connectionCredentials.ConnectionString;
            //mtInfo.LoadTranslations();
            //m_InfoRegion = new string[4];
            //m_InfoRayon = new string[4];
            //m_InfoResult = mtInfo.GetWebPointInfo(pLon, pLat, m_InfoRegion, m_InfoRayon, ref m_InfoSettlement);





            var connectionCredentials = new bv.common.Configuration.ConnectionCredentials();
            var lng = Localizer.CurrentCultureLanguageID;
            m_InfoRegion = new string[4];
            m_InfoRayon = new string[4];

            // Old version: uses map control and requires devex. Causes an error.

            //MtInfo mtInfo = new MtInfo();
            //mtInfo.ConnectionString = connectionCredentials.ConnectionString;
            //mtInfo.LoadTranslations();
            //m_InfoResult = mtInfo.GetWebPointInfo(pLon, pLat, m_InfoRegion, m_InfoRayon, ref m_InfoSettlement);

            m_InfoResult = CoordinatesUtils.GetWebPointInfo1(connectionCredentials.ConnectionString, lng, pLon, pLat,
                m_InfoRegion, m_InfoRayon, ref m_InfoSettlement);
        }
    }
}