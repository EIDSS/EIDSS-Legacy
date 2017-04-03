using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using bv.common.Configuration;
using bv.common.Resources;

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

        private static Dictionary<string, string> m_SupportedLanguages;

        public static Dictionary<string, string> SupportedLanguages
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

        public static Dictionary<string, string> AllSupportedLanguages
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

        public static string CurrentCultureLanguageID
        {
            get { return GetLanguageID(Thread.CurrentThread.CurrentCulture); }
        }

        private static void AddLanguage(Dictionary<string, string> dict, string langID, string cultureName)
        {
            if (!dict.ContainsKey(langID))
            {
                dict.Add(langID, cultureName);
            }
        }

        private static void InitSupportedLanguages()
        {
            m_AllSupportedLanguages = new Dictionary<string, string>();
            AddLanguage(AllSupportedLanguages, lngEn, "en-US");
            AddLanguage(AllSupportedLanguages, lngRu, "ru-RU");
            AddLanguage(AllSupportedLanguages, lngAzLat, "az-Latn-AZ");
            AddLanguage(AllSupportedLanguages, lngUzLat, "uz-Latn-UZ");
            AddLanguage(AllSupportedLanguages, lngUzCyr, "uz-Cyrl-UZ");
            AddLanguage(AllSupportedLanguages, lngGe, "ka-GE");
            AddLanguage(AllSupportedLanguages, lngUk, "uk-UA");
            AddLanguage(AllSupportedLanguages, lngKz, "kk-KZ");
            AddLanguage(AllSupportedLanguages, lngAr, "hy-AM");
            AddLanguage(AllSupportedLanguages, lngIraq, "ar-IQ");
            AddLanguage(AllSupportedLanguages, lngLaos, "lo-LA");
            AddLanguage(AllSupportedLanguages, lngVietnam, "vi-VN");

            m_SupportedLanguages = new Dictionary<string, string>();

            if (HttpContext.Current == null && InputLanguage.InstalledInputLanguages.Count > 0)
            {
                foreach (InputLanguage language in InputLanguage.InstalledInputLanguages)
                {
                    switch (language.Culture.Name)
                    {
                        case "en-US":
                            AddLanguage(SupportedLanguages, lngEn, language.Culture.Name);
                            break;
                        case "ru-RU":
                            AddLanguage(SupportedLanguages, lngRu, language.Culture.Name);
                            break;
                        case "az-Latn-AZ":
                            AddLanguage(SupportedLanguages, lngAzLat, language.Culture.Name);
                            break;
                        case "uz-Latn-UZ":
                            AddLanguage(SupportedLanguages, lngUzLat, language.Culture.Name);
                            break;
                        case "uz-Cyrl-UZ":
                            AddLanguage(SupportedLanguages, lngUzCyr, language.Culture.Name);
                            break;
                        case "ka-GE":
                            AddLanguage(SupportedLanguages, lngGe, language.Culture.Name);
                            break;
                        case "uk-UA":
                            AddLanguage(SupportedLanguages, lngUk, language.Culture.Name);
                            break;
                        case "kk-KZ":
                            AddLanguage(SupportedLanguages, lngKz, language.Culture.Name);
                            break;
                        case "hy-AM":
                            AddLanguage(SupportedLanguages, lngAr, language.Culture.Name);
                            break;
                        case "lo-LA":
                            AddLanguage(SupportedLanguages, lngLaos, language.Culture.Name);
                            break;
                        case "vi-VN":
                            AddLanguage(SupportedLanguages, lngVietnam, language.Culture.Name);
                            break;
                        case "ar-IQ":
                            AddLanguage(SupportedLanguages, lngIraq, language.Culture.Name);
                            break;
                    }
                }
            }
            else
            {
                AddLanguage(SupportedLanguages, lngEn, "en-US");
                AddLanguage(SupportedLanguages, lngRu, "ru-RU");
                AddLanguage(SupportedLanguages, lngAzLat, "az-Latn-AZ");
                AddLanguage(SupportedLanguages, lngUzLat, "uz-Latn-UZ");
                AddLanguage(SupportedLanguages, lngUzCyr, "uz-Cyrl-UZ");
                AddLanguage(SupportedLanguages, lngGe, "ka-GE");
                AddLanguage(SupportedLanguages, lngUk, "uk-UA");
                AddLanguage(SupportedLanguages, lngKz, "kk-KZ");
                AddLanguage(SupportedLanguages, lngAr, "hy-AM");
                AddLanguage(SupportedLanguages, lngIraq, "ar-IQ");
                AddLanguage(SupportedLanguages, lngLaos, "lo-LA");
                AddLanguage(SupportedLanguages, lngVietnam, "vi-VN");
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///     Converts passed <b>CultureInfo</b> object to the application language identifier
        /// </summary>
        /// <param name="culture">
        ///     <b>CultureInfo</b> object
        /// </param>
        /// <returns>
        ///     Returns application language identifier related with passed <i>culture</i>.
        /// </returns>
        /// <remarks>
        ///     Use this method to retrieve application language identifier for the specific <b>CultureInfo</b>.
        ///     Application language identifier is used to set/get current application language and
        ///     perform related application translation to this language.
        /// </remarks>
        /// <history>
        ///     [Mike]	30.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static string GetLanguageID(CultureInfo culture)
        {
            switch (culture.TwoLetterISOLanguageName)
            {
                case "uz":
                    if (culture.Name.IndexOf("Cyrl", StringComparison.Ordinal) > 0)
                    {
                        return lngUzCyr;
                    }
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
        ///     Gets the translated human readable language name related with specific application language identifier
        /// </summary>
        /// <param name="langID">
        ///     application language identifier for which the human readable language name should be retrieved
        /// </param>
        /// <param name="displayLangID">
        ///     application language identifier of language to which the language name should be translated
        /// </param>
        /// <remarks>
        ///     <b>Note:</b> only English, Russian, Georgian, Kazakh, Uzbek Cyrillic and Uzbek Latin languages are supported by the
        ///     system
        /// </remarks>
        /// <history>
        ///     [Mike]	30.03.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static string GetLanguageName(string langID, string displayLangID = null)
        {
            if (MenuMessages == null)
            {
                MenuMessages = BvMessages.Instance;
            }
            switch (langID)
            {
                case lngEn:
                    return MenuMessages.GetString("MenuEnglish", "&English", displayLangID).Replace("&", "");
                case lngRu:
                    return MenuMessages.GetString("MenuRussian", "&Russian", displayLangID).Replace("&", "");
                case lngGe:
                    return MenuMessages.GetString("MenuGeorgian", "&Georgian", displayLangID).Replace("&", "");
                case lngKz:
                    return MenuMessages.GetString("MenuKazakh", "&Kazakh", displayLangID).Replace("&", "");
                case lngUzCyr:
                    return MenuMessages.GetString("MenuUzbekCyr", "Uzbeck (&Cyr)", displayLangID).Replace("&", "");
                case lngUzLat:
                    return MenuMessages.GetString("MenuUzbekLat", "Uzbek (&Lat)", displayLangID).Replace("&", "");
                case lngAzLat:
                    return MenuMessages.GetString("MenuAzeriLat", "Azeri (&Lat)", displayLangID).Replace("&", "");
                case lngAr:
                    return MenuMessages.GetString("MenuArmenian", "Armenian", displayLangID).Replace("&", "");
                case lngUk:
                    return MenuMessages.GetString("MenuUkrainian", "Ukrainian", displayLangID).Replace("&", "");
                case lngIraq:
                    return MenuMessages.GetString("MenuIraq", "Arabic (Iraq)", displayLangID).Replace("&", "");
                case lngLaos:
                    return MenuMessages.GetString("MenuLaos", "Laos", displayLangID).Replace("&", "");
                case lngVietnam:
                    return MenuMessages.GetString("MenuVietnam", "Vietnam", displayLangID).Replace("&", "");
            }
            return MenuMessages.GetString("MenuEnglish", "&English", displayLangID).Replace("&", "");
        }

        public static string GetMenuLanguageName(string langID, string displayLangID = null)
        {
            if (MenuMessages == null)
            {
                MenuMessages = BvMessages.Instance;
            }
            switch (langID)
            {
                case lngEn:
                    return MenuMessages.GetString("MenuEnglish", "&English", displayLangID).Replace("&", "") + " (" +
                           MenuMessages.GetString("MenuEnglish", "&English", lngEn).Replace("&", "") + ")";
                case lngRu:
                    return MenuMessages.GetString("MenuRussian", "&Russian", displayLangID).Replace("&", "") + " (" +
                           MenuMessages.GetString("MenuRussian", "&Russian", lngRu).Replace("&", "") + ")";
                case lngGe:
                    return MenuMessages.GetString("MenuGeorgian", "&Georgian", displayLangID).Replace("&", "") + " (" +
                           MenuMessages.GetString("MenuGeorgian", "&Georgian", lngGe).Replace("&", "") + ")";
                case lngKz:
                    return MenuMessages.GetString("MenuKazakh", "&Kazakh", displayLangID).Replace("&", "") + " (" +
                           MenuMessages.GetString("MenuKazakh", "&Kazakh", lngKz).Replace("&", "") + ")";
                case lngUzCyr:
                    return MenuMessages.GetString("MenuUzbekCyr", "Uzbeck (&Cyr)", displayLangID).Replace("&", "") + " (" +
                           MenuMessages.GetString("MenuUzbekCyr", "Uzbeck (&Cyr)", lngUzCyr).Replace("&", "") + ")";
                case lngUzLat:
                    return MenuMessages.GetString("MenuUzbekLat", "Uzbek (&Lat)", displayLangID).Replace("&", "") + " (" +
                           MenuMessages.GetString("MenuUzbekLat", "Uzbek (&Lat)", lngUzLat).Replace("&", "") + ")";
                case lngAzLat:
                    return MenuMessages.GetString("MenuAzeriLat", "Azeri (&Lat)", displayLangID).Replace("&", "") + " (" +
                           MenuMessages.GetString("MenuAzeriLat", "Azeri (&Lat)", lngAzLat).Replace("&", "") + ")";
                case lngAr:
                    return MenuMessages.GetString("MenuArmenian", "Armenian", displayLangID).Replace("&", "") + " (" +
                           MenuMessages.GetString("MenuArmenian", "Armenian", lngAr).Replace("&", "") + ")";
                case lngUk:
                    return MenuMessages.GetString("MenuUkrainian", "Ukrainian", displayLangID).Replace("&", "") + " (" +
                           MenuMessages.GetString("MenuUkrainian", "Ukrainian", lngUk).Replace("&", "") + ")";
                case lngIraq:
                    return MenuMessages.GetString("MenuIraq", "Arabic (Iraq)", displayLangID).Replace("&", "") + " (" +
                           MenuMessages.GetString("MenuIraq", "Arabic (Iraq)", lngIraq).Replace("&", "") + ")";
                case lngLaos:
                    return MenuMessages.GetString("MenuLaos", "Laos", displayLangID).Replace("&", "") + " (" +
                           MenuMessages.GetString("MenuLaos", "Laos", lngLaos).Replace("&", "") + ")";
                case lngVietnam:
                    return MenuMessages.GetString("MenuVietnam", "Vietnam", displayLangID).Replace("&", "") + " (" +
                           MenuMessages.GetString("MenuVietnam", "Vietnam", lngVietnam).Replace("&", "") + ")";
            }
            return MenuMessages.GetString("MenuEnglish", "&English", displayLangID).Replace("&", "") + " (" +
                   MenuMessages.GetString("MenuEnglish", "&English", lngEn).Replace("&", "") + ")";
        }

        public static string DefaultLanguage
        {
            get { return Config.GetSetting("DefaultLanguage", "en"); }
        }

        public static string DefaultLanguageLocale
        {
            get { return CustomCultureHelper.SupportedLanguages[DefaultLanguage]; }
        }

        public static bool ReverseFromToLabelsPosition
        {
            get { return CultureInfo.CurrentCulture.Name.ToLowerInvariant() == "ka-ge"; }
        }
    }
}