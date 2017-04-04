using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace bv.common.Core
{
    public class SupportedLanguages
    {
        public const string lngEn = "en";
        public const string lngRu = "ru";
        public const string lngGe = "ka";
        public const string lngKz = "kk";
        public const string lngUzCyr = "uz-C";
        public const string lngUzLat = "uz-L";
        public const string lngAzLat = "az-L";
        public const string lngAr = "hy";
        public const string lngUk = "uk";
        public const string lngIraq = "ar";
        public const string lngVietnam = "vi";
        public const string lngLaos = "lo";
        public const string lngThai = "th";
        private static void AddLanguage(Dictionary<string, string> dict, string langID, string cultureName)
        {
            if (!dict.ContainsKey(langID))
            {
                dict.Add(langID, cultureName);
            }
        }

        private static Dictionary<string, string> m_SupportedLanguages;

        public static Dictionary<string, string> Installed
        {
            get
            {
                if (m_SupportedLanguages == null)
                {
                    InitSupportedLanguages();
                }
                return m_SupportedLanguages;
            }
            set { m_SupportedLanguages = value; }
        }
        private static Dictionary<string, string> m_AllSupportedLanguages;
        public static Dictionary<string, string> All
        {
            get
            {
                if (m_AllSupportedLanguages == null)
                {
                    InitSupportedLanguages();
                }
                return m_AllSupportedLanguages;
            }
            set { m_AllSupportedLanguages = value; }
        }

        private static void InitSupportedLanguages()
        {
            m_AllSupportedLanguages = new Dictionary<string, string>();
            AddLanguage(All, lngEn, "en-US");
            AddLanguage(All, lngRu, "ru-RU");
            AddLanguage(All, lngAzLat, "az-Latn-AZ");
            AddLanguage(All, lngUzLat, "uz-Latn-UZ");
            AddLanguage(All, lngUzCyr, "uz-Cyrl-UZ");
            AddLanguage(All, lngGe, "ka-GE");
            AddLanguage(All, lngUk, "uk-UA");
            AddLanguage(All, lngKz, "kk-KZ");
            AddLanguage(All, lngAr, "hy-AM");
            AddLanguage(All, lngIraq, "ar-IQ");
            AddLanguage(All, lngLaos, "lo-LA");
            AddLanguage(All, lngVietnam, "vi-VN");
            AddLanguage(All, lngThai, "th-TH");

            m_SupportedLanguages = new Dictionary<string, string>();

            if (HttpContext.Current == null && InputLanguage.InstalledInputLanguages.Count > 0)
            {
                foreach (InputLanguage language in InputLanguage.InstalledInputLanguages)
                {
                    switch (language.Culture.Name)
                    {
                        case "en-US":
                            AddLanguage(Installed, lngEn, language.Culture.Name);
                            break;
                        case "ru-RU":
                            AddLanguage(Installed, lngRu, language.Culture.Name);
                            break;
                        case "az-Latn-AZ":
                            AddLanguage(Installed, lngAzLat, language.Culture.Name);
                            break;
                        case "uz-Latn-UZ":
                            AddLanguage(Installed, lngUzLat, language.Culture.Name);
                            break;
                        case "uz-Cyrl-UZ":
                            AddLanguage(Installed, lngUzCyr, language.Culture.Name);
                            break;
                        case "ka-GE":
                            AddLanguage(Installed, lngGe, language.Culture.Name);
                            break;
                        case "uk-UA":
                            AddLanguage(Installed, lngUk, language.Culture.Name);
                            break;
                        case "kk-KZ":
                            AddLanguage(Installed, lngKz, language.Culture.Name);
                            break;
                        case "hy-AM":
                            AddLanguage(Installed, lngAr, language.Culture.Name);
                            break;
                        case "lo-LA":
                            AddLanguage(Installed, lngLaos, language.Culture.Name);
                            break;
                        case "vi-VN":
                            AddLanguage(Installed, lngVietnam, language.Culture.Name);
                            break;
                        case "ar-IQ":
                            AddLanguage(Installed, lngIraq, language.Culture.Name);
                            break;
                        case "th-TH":
                            AddLanguage(Installed, lngThai, language.Culture.Name);
                            break;
                    }
                }
            }
            else
            {
                AddLanguage(Installed, lngEn, "en-US");
                AddLanguage(Installed, lngRu, "ru-RU");
                AddLanguage(Installed, lngAzLat, "az-Latn-AZ");
                AddLanguage(Installed, lngUzLat, "uz-Latn-UZ");
                AddLanguage(Installed, lngUzCyr, "uz-Cyrl-UZ");
                AddLanguage(Installed, lngGe, "ka-GE");
                AddLanguage(Installed, lngUk, "uk-UA");
                AddLanguage(Installed, lngKz, "kk-KZ");
                AddLanguage(Installed, lngAr, "hy-AM");
                AddLanguage(Installed, lngIraq, "ar-IQ");
                AddLanguage(Installed, lngLaos, "lo-LA");
                AddLanguage(Installed, lngVietnam, "vi-VN");
                AddLanguage(Installed, lngThai, "th-TH");
            }
        }

        public static string GetDefaultLanguageName(string langID)
        {
            switch (langID)
            {
                case lngEn:
                    return "English";
                case lngRu:
                    return "Russian";
                case lngGe:
                    return "Georgian";
                case lngKz:
                    return "Kazakh";
                case lngUzCyr:
                    return "Uzbek";
                case lngUzLat:
                    return "Uzbek";
                case lngAzLat:
                    return "Azeri";
                case lngAr:
                    return "Armenian";
                case lngUk:
                    return "Ukrainian";
                case lngIraq:
                    return "Arabic";
                case lngLaos:
                    return "Laos";
                case lngVietnam:
                    return "Vietnam";
                case lngThai:
                    return "Thai";
            }
            return "English";
        }
    }
}
