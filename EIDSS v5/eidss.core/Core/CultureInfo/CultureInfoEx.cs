using System.Collections.Generic;
using bv.common.Core;

namespace eidss.model.Core.CultureInfo
{
    public class CultureInfoEx
    {
        private static readonly Dictionary<string, string> m_ExistingLanguages = new Dictionary<string, string>();

        private readonly System.Globalization.CultureInfo m_CultureInfo;
        private readonly string m_ShortName;

        static CultureInfoEx()
        {
            m_ExistingLanguages.Add(Localizer.lngEn, "en-US");
            m_ExistingLanguages.Add(Localizer.lngRu, "ru-RU");
            m_ExistingLanguages.Add(Localizer.lngAzLat, "az-Latn-AZ");
            m_ExistingLanguages.Add(Localizer.lngUzLat, "uz-Latn-UZ");
            m_ExistingLanguages.Add(Localizer.lngUzCyr, "uz-Cyrl-UZ");
            m_ExistingLanguages.Add(Localizer.lngGe, "ka-GE");
            m_ExistingLanguages.Add(Localizer.lngUk, "uk-UA");
            m_ExistingLanguages.Add(Localizer.lngKz, "kk-KZ");
            m_ExistingLanguages.Add(Localizer.lngAr, "hy-AM");
            m_ExistingLanguages.Add(Localizer.lngIraq, "ar-IQ");
            m_ExistingLanguages.Add(Localizer.lngLaos, "lo-LA");
            m_ExistingLanguages.Add(Localizer.lngVietnam, "vi-VN");
        }

        public CultureInfoEx(System.Globalization.CultureInfo cultureInfo, string shortName)
        {
            Utils.CheckNotNull(cultureInfo, "cultureInfo");
            Utils.CheckNotNullOrEmpty(shortName, "shortName");

            m_CultureInfo = cultureInfo;
            m_ShortName = shortName;
        }

        public static IDictionary<string, string> ExistingLanguages
        {
            get { return m_ExistingLanguages; }
        }

        public System.Globalization.CultureInfo CultureInfo
        {
            get { return m_CultureInfo; }
        }

        public string ShortName
        {
            get { return m_ShortName; }
        }
        public string NativeName
        {
            get
            {
                string langId = Localizer.GetLanguageID(CultureInfo);
                return Localizer.GetMenuLanguageName(langId, null);
            }
        }

        public override string ToString()
        {
            return NativeName;
        }
    }
}