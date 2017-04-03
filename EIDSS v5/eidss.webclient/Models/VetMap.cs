using System.Configuration;
using System.Globalization;
using bv.common.Configuration;

namespace eidss.webclient.Models
{
    public class VetMap
    {
        public double m_VetLon { get; set; }
        public double m_VetLat { get; set; }
        public string m_VelMapLocalUrl;
        public string m_VelMapLocalUrlLabel;
        public VetMap()
        {
            string l_conf_url = Config.GetSetting("MapLocalUrl");
            m_VelMapLocalUrl = l_conf_url + "/base";
            m_VelMapLocalUrlLabel = l_conf_url + "/" + CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToString();
        }
    }
}