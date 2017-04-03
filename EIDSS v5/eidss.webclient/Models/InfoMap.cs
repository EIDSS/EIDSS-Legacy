using System.Configuration;
using System.Globalization;
using eidss.gis;
using eidss.gis.common;
using eidss.gis.Tools;

namespace eidss.webclient.Models
{
    public class InfoMap
    {
        public string m_InfoResult;
        public string[] m_InfoRegion;
        public string[] m_InfoRayon;
        public string m_InfoSettlement;
        public InfoMap(double pLon, double pLat)
        {
            MtInfo mtInfo = new MtInfo();
            mtInfo.ConnectionString = ConfigurationManager.AppSettings["EidssConnectionString"];
            mtInfo.LoadTranslations();
            m_InfoRegion = new string[4];
            m_InfoRayon = new string[4];
            m_InfoResult = mtInfo.GetWebPointInfo(pLon, pLat, m_InfoRegion, m_InfoRayon, ref m_InfoSettlement);
        }
    }
}