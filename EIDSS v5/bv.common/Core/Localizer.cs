using System.Collections.Generic;
using bv.common.Configuration;
using bv.common.Resources;
#if !MONO
using System.Web;
using System.Windows.Forms;
#endif

namespace bv.common.Core
{
    public class Localizer
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

        public static BaseStringsStorage MenuMessages { get; set; }

        //public static string Language { get; set; }

        private static Dictionary<string,string> m_SupportedLanguages;
        public static Dictionary<string,string> SupportedLanguages
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

        private static void AddLanguage(string langID, string cultureName)
        {
            if (!m_SupportedLanguages.ContainsKey(langID))
                m_SupportedLanguages.Add(langID, cultureName);
        }
        private static void InitSupportedLanguages()
        {
            m_SupportedLanguages = new Dictionary<string, string>();
            #if !MONO
            if (HttpContext.Current == null && InputLanguage.InstalledInputLanguages.Count >0)
            {
                foreach (InputLanguage language in InputLanguage.InstalledInputLanguages)
                {
                    switch (language.Culture.Name)
                    {
                        case "en-US":
                            AddLanguage(lngEn, language.Culture.Name);
                            break;
                        case "ru-RU":
                            AddLanguage(lngRu, language.Culture.Name);
                            break;
                        case "az-Latn-AZ":
                            AddLanguage(lngAzLat, language.Culture.Name);
                            break;
                        case "uz-Latn-UZ":
                            AddLanguage(lngUzLat, language.Culture.Name);
                            break;
                        case "uz-Cyrl-UZ":
                            AddLanguage(lngUzCyr, language.Culture.Name);
                            break;
                        case "ka-GE":
                            AddLanguage(lngGe, language.Culture.Name);
                            break;
                        case "uk-UA":
                            AddLanguage(lngUk, language.Culture.Name);
                            break;
                        case "kk-KZ":
                            AddLanguage(lngKz, language.Culture.Name);
                            break;
                        case "hy-AM":
                            AddLanguage(lngAr, language.Culture.Name);
                            break;
                        case "lo-LA":
                            AddLanguage(lngLaos, language.Culture.Name);
                            break;
                        case "vi-VN":
                            AddLanguage(lngVietnam, language.Culture.Name);
                            break;
                    }
                }
            }
            else
            {
            #endif
                AddLanguage(lngEn, "en-US");
                AddLanguage(lngRu, "ru-RU");
                AddLanguage(lngAzLat, "az-Latn-AZ");
                AddLanguage(lngUzLat, "uz-Latn-UZ");
                AddLanguage(lngUzCyr, "uz-Cyrl-UZ");
                AddLanguage(lngGe, "ka-GE");
                AddLanguage(lngUk, "uk-UA");
                AddLanguage(lngKz, "kk-KZ");
                AddLanguage(lngAr, "hy-AM");
                AddLanguage(lngIraq, "ar-IQ");
                AddLanguage(lngLaos, "lo-LA");
                AddLanguage(lngVietnam, "vi-VN");
#if !MONO
            }
            #endif
        }
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Converts passed <b>CultureInfo</b> object to the application language identifier
        /// </summary>
        /// <param name="culture">
        /// <b>CultureInfo</b> object
        /// </param>
        /// <returns>
        /// Returns application language identifier related with passed <i>culture</i>.
        /// </returns>
        /// <remarks>
        /// Use this method to retrieve application language identifier for the specific <b>CultureInfo</b>.
        /// Application language identifier is used to set/get current application language and
        /// perform related application translation to this language.
        /// </remarks>
        /// <history>
        /// 	[Mike]	30.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static string GetLanguageID(System.Globalization.CultureInfo culture)
        {
            switch (culture.TwoLetterISOLanguageName)
            {
                case "uz":
                    if (culture.Name.IndexOf("Cyrl", System.StringComparison.Ordinal) > 0)
                        return lngUzCyr;
                    return lngUzLat;
                case "az":
                    return lngAzLat;
                case "ar":
                    return lngIraq;
                default:
                    return culture.TwoLetterISOLanguageName;
            }
        }
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets the translated human readable language name related with specific application language identifier
        /// </summary>
        /// <param name="LangID">
        /// application language identifier for which the human readable language name should be retrieved
        /// </param>
        /// <param name="DisplayLangID">
        /// application language identifier of language to which the language name should be translated
        /// </param>
        /// <remarks>
        /// <b>Note:</b> only English, Russian, Georgian, Kazakh, Uzbek Cyrillic and Uzbek Latin languages are supported by the system
        /// </remarks>
        /// <history>
        /// 	[Mike]	30.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static string GetLanguageName(string LangID, string DisplayLangID = null)
        {
            if (MenuMessages == null)
                MenuMessages = BvMessages.Instance;
            switch (LangID)
            {
                case lngEn:
                    return MenuMessages.GetString("MenuEnglish", "&English", DisplayLangID).Replace("&", "");
                case lngRu:
                    return MenuMessages.GetString("MenuRussian", "&Russian", DisplayLangID).Replace("&", "");
                case lngGe:
                    return MenuMessages.GetString("MenuGeorgian", "&Georgian", DisplayLangID).Replace("&", "");
                case lngKz:
                    return MenuMessages.GetString("MenuKazakh", "&Kazakh", DisplayLangID).Replace("&", "");
                case lngUzCyr:
                    return MenuMessages.GetString("MenuUzbekCyr", "Uzbeck (&Cyr)", DisplayLangID).Replace("&", "");
                case lngUzLat:
                    return MenuMessages.GetString("MenuUzbekLat", "Uzbek (&Lat)", DisplayLangID).Replace("&", "");
                case lngAzLat:
                    return MenuMessages.GetString("MenuAzeriLat", "Azeri (&Lat)", DisplayLangID).Replace("&", "");
                case lngAr:
                    return MenuMessages.GetString("MenuArmenian", "Armenian", DisplayLangID).Replace("&", "");
                case lngUk:
                    return MenuMessages.GetString("MenuUkrainian", "Ukrainian", DisplayLangID).Replace("&", "");
                case lngIraq:
                    return MenuMessages.GetString("MenuIraq", "Arabic (Iraq)", DisplayLangID).Replace("&", "");
                case lngLaos:
                    return MenuMessages.GetString("MenuLaos", "Laos", DisplayLangID).Replace("&", "");
                case lngVietnam:
                    return MenuMessages.GetString("MenuVietnam", "Vietnam", DisplayLangID).Replace("&", "");
            }
            return MenuMessages.GetString("MenuEnglish", "&English", DisplayLangID).Replace("&", "");
        }


        public static string GetMenuLanguageName(string langID, string displayLangID = null)
        {
            if (MenuMessages == null)
                MenuMessages = BvMessages.Instance;
            switch (langID)
            {
                case lngEn:
                    return MenuMessages.GetString("MenuEnglish", "&English", displayLangID).Replace("&", "") + " (" + MenuMessages.GetString("MenuEnglish", "&English", lngEn).Replace("&", "") + ")";
                case lngRu:
                    return MenuMessages.GetString("MenuRussian", "&Russian", displayLangID).Replace("&", "") + " (" + MenuMessages.GetString("MenuRussian", "&Russian", lngRu).Replace("&", "") + ")";
                case lngGe:
                    return MenuMessages.GetString("MenuGeorgian", "&Georgian", displayLangID).Replace("&", "") + " (" + MenuMessages.GetString("MenuGeorgian", "&Georgian", lngGe).Replace("&", "") + ")";
                case lngKz:
                    return MenuMessages.GetString("MenuKazakh", "&Kazakh", displayLangID).Replace("&", "") + " (" + MenuMessages.GetString("MenuKazakh", "&Kazakh", lngKz).Replace("&", "") + ")";
                case lngUzCyr:
                    return MenuMessages.GetString("MenuUzbekCyr", "Uzbeck (&Cyr)", displayLangID).Replace("&", "") + " (" + MenuMessages.GetString("MenuUzbekCyr", "Uzbeck (&Cyr)", lngUzCyr).Replace("&", "") + ")";
                case lngUzLat:
                    return MenuMessages.GetString("MenuUzbekLat", "Uzbek (&Lat)", displayLangID).Replace("&", "") + " (" + MenuMessages.GetString("MenuUzbekLat", "Uzbek (&Lat)", lngUzLat).Replace("&", "") + ")";
                case lngAzLat:
                    return MenuMessages.GetString("MenuAzeriLat", "Azeri (&Lat)", displayLangID).Replace("&", "") + " (" + MenuMessages.GetString("MenuAzeriLat", "Azeri (&Lat)", lngAzLat).Replace("&", "") + ")";
                case lngAr:
                    return MenuMessages.GetString("MenuArmenian", "Armenian", displayLangID).Replace("&", "") + " (" + MenuMessages.GetString("MenuArmenian", "Armenian", lngAr).Replace("&", "") + ")";
                case lngUk:
                    return MenuMessages.GetString("MenuUkrainian", "Ukrainian", displayLangID).Replace("&", "") + " (" + MenuMessages.GetString("MenuUkrainian", "Ukrainian", lngUk).Replace("&", "") + ")";
                case lngIraq:
                    return MenuMessages.GetString("MenuIraq", "Arabic (Iraq)", displayLangID).Replace("&", "") + " (" + MenuMessages.GetString("MenuIraq", "Arabic (Iraq)", lngIraq).Replace("&", "") + ")";
                case lngLaos:
                    return MenuMessages.GetString("MenuLaos", "Laos", displayLangID).Replace("&", "")+ " (" + MenuMessages.GetString("MenuLaos", "Laos", lngLaos).Replace("&", "") + ")";;
                case lngVietnam:
                    return MenuMessages.GetString("MenuVietnam", "Vietnam", displayLangID).Replace("&", "")+ " (" + MenuMessages.GetString("MenuVietnam", "Vietnam", lngVietnam).Replace("&", "") + ")";;
            }
            return MenuMessages.GetString("MenuEnglish", "&English", displayLangID).Replace("&", "") + " (" + MenuMessages.GetString("MenuEnglish", "&English", lngEn).Replace("&", "") + ")";

        }

        public static string DefaultLanguage
        {
            get
            {
                return Config.GetSetting("DefaultLanguage", "en");
            }
        }
        public static string DefaultLanguageLocale
        {
            get
            {
                return SupportedLanguages[DefaultLanguage];
            }
        }
    }
}
