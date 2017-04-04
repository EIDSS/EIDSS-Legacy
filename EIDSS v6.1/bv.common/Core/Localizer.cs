using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using bv.common.Configuration;
using bv.common.Resources;

namespace bv.common.Core
{
    public class Localizer
    {
        public static string lngEn {get { return Core.SupportedLanguages.lngEn; }}
        public static string lngRu { get { return Core.SupportedLanguages.lngRu; } }
        public static string lngGe { get { return Core.SupportedLanguages.lngGe; } }
        public static string lngKz { get { return Core.SupportedLanguages.lngKz; } }
        public static string lngUzCyr { get { return Core.SupportedLanguages.lngUzCyr; } }
        public static string lngUzLat { get { return Core.SupportedLanguages.lngUzLat; } }
        public static string lngAzLat { get { return Core.SupportedLanguages.lngAzLat; } }
        public static string lngAr { get { return Core.SupportedLanguages.lngAr; } }
        public static string lngUk { get { return Core.SupportedLanguages.lngUk; } }
        public static string lngIraq { get { return Core.SupportedLanguages.lngIraq; } }
        public static string lngVietnam { get { return Core.SupportedLanguages.lngVietnam; } }
        public static string lngLaos { get { return Core.SupportedLanguages.lngLaos; } }
        public static string lngThai { get { return Core.SupportedLanguages.lngThai; } }

        public static BaseStringsStorage MenuMessages { get; set; }

        //public static string Language { get; set; }


        public static Dictionary<string, string> SupportedLanguages
        {
            get { return Core.SupportedLanguages.Installed; }
            //set { m_SupportedLanguages = value; }
        }


        public static Dictionary<string, string> AllSupportedLanguages
        {
            get { return Core.SupportedLanguages.All; }
            //set { m_AllSupportedLanguages = value; }
        }

        public static string CurrentCultureLanguageID
        {
            get { return GetLanguageID(Thread.CurrentThread.CurrentCulture); }
        }

        public static int YearShift
        {
            get { return CurrentCultureLanguageID == lngThai ? 543 : 0; }
        }

        private static void AddLanguage(Dictionary<string, string> dict, string langID, string cultureName)
        {
            if (!dict.ContainsKey(langID))
            {
                dict.Add(langID, cultureName);
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
                case Core.SupportedLanguages.lngEn:
                    return MenuMessages.GetString("MenuEnglish", "&English", displayLangID).Replace("&", "");
                case Core.SupportedLanguages.lngRu:
                    return MenuMessages.GetString("MenuRussian", "&Russian", displayLangID).Replace("&", "");
                case Core.SupportedLanguages.lngGe:
                    return MenuMessages.GetString("MenuGeorgian", "&Georgian", displayLangID).Replace("&", "");
                case Core.SupportedLanguages.lngKz:
                    return MenuMessages.GetString("MenuKazakh", "&Kazakh", displayLangID).Replace("&", "");
                case Core.SupportedLanguages.lngUzCyr:
                    return MenuMessages.GetString("MenuUzbekCyr", "Uzbeck (&Cyr)", displayLangID).Replace("&", "");
                case Core.SupportedLanguages.lngUzLat:
                    return MenuMessages.GetString("MenuUzbekLat", "Uzbek (&Lat)", displayLangID).Replace("&", "");
                case Core.SupportedLanguages.lngAzLat:
                    return MenuMessages.GetString("MenuAzeriLat", "Azeri (&Lat)", displayLangID).Replace("&", "");
                case Core.SupportedLanguages.lngAr:
                    return MenuMessages.GetString("MenuArmenian", "Armenian", displayLangID).Replace("&", "");
                case Core.SupportedLanguages.lngUk:
                    return MenuMessages.GetString("MenuUkrainian", "Ukrainian", displayLangID).Replace("&", "");
                case Core.SupportedLanguages.lngIraq:
                    return MenuMessages.GetString("MenuIraq", "Arabic (Iraq)", displayLangID).Replace("&", "");
                case Core.SupportedLanguages.lngLaos:
                    return MenuMessages.GetString("MenuLaos", "Laos", displayLangID).Replace("&", "");
                case Core.SupportedLanguages.lngVietnam:
                    return MenuMessages.GetString("MenuVietnam", "Vietnam", displayLangID).Replace("&", "");
                case Core.SupportedLanguages.lngThai:
                    return MenuMessages.GetString("MenuThai", "Thai", displayLangID).Replace("&", "");
            }
            return MenuMessages.GetString("MenuEnglish", "&English", displayLangID).Replace("&", "");
        }

        public static string GetMenuLanguageName(string langID, string displayLangID = null)
        {
            return string.Format("{0} ({1})", GetLanguageName(langID, displayLangID), GetLanguageName(langID, lngEn));
            //if (MenuMessages == null)
            //{
            //    MenuMessages = BvMessages.Instance;
            //}
            //switch (langID)
            //{
            //    case lngEn:
            //        return MenuMessages.GetString("MenuEnglish", "&English", displayLangID).Replace("&", "") + " (" +
            //               MenuMessages.GetString("MenuEnglish", "&English", lngEn).Replace("&", "") + ")";
            //    case lngRu:
            //        return MenuMessages.GetString("MenuRussian", "&Russian", displayLangID).Replace("&", "") + " (" +
            //               MenuMessages.GetString("MenuRussian", "&Russian", lngRu).Replace("&", "") + ")";
            //    case lngGe:
            //        return MenuMessages.GetString("MenuGeorgian", "&Georgian", displayLangID).Replace("&", "") + " (" +
            //               MenuMessages.GetString("MenuGeorgian", "&Georgian", lngGe).Replace("&", "") + ")";
            //    case lngKz:
            //        return MenuMessages.GetString("MenuKazakh", "&Kazakh", displayLangID).Replace("&", "") + " (" +
            //               MenuMessages.GetString("MenuKazakh", "&Kazakh", lngKz).Replace("&", "") + ")";
            //    case lngUzCyr:
            //        return MenuMessages.GetString("MenuUzbekCyr", "Uzbeck (&Cyr)", displayLangID).Replace("&", "") + " (" +
            //               MenuMessages.GetString("MenuUzbekCyr", "Uzbeck (&Cyr)", lngUzCyr).Replace("&", "") + ")";
            //    case lngUzLat:
            //        return MenuMessages.GetString("MenuUzbekLat", "Uzbek (&Lat)", displayLangID).Replace("&", "") + " (" +
            //               MenuMessages.GetString("MenuUzbekLat", "Uzbek (&Lat)", lngUzLat).Replace("&", "") + ")";
            //    case lngAzLat:
            //        return MenuMessages.GetString("MenuAzeriLat", "Azeri (&Lat)", displayLangID).Replace("&", "") + " (" +
            //               MenuMessages.GetString("MenuAzeriLat", "Azeri (&Lat)", lngAzLat).Replace("&", "") + ")";
            //    case lngAr:
            //        return MenuMessages.GetString("MenuArmenian", "Armenian", displayLangID).Replace("&", "") + " (" +
            //               MenuMessages.GetString("MenuArmenian", "Armenian", lngAr).Replace("&", "") + ")";
            //    case lngUk:
            //        return MenuMessages.GetString("MenuUkrainian", "Ukrainian", displayLangID).Replace("&", "") + " (" +
            //               MenuMessages.GetString("MenuUkrainian", "Ukrainian", lngUk).Replace("&", "") + ")";
            //    case lngIraq:
            //        return MenuMessages.GetString("MenuIraq", "Arabic (Iraq)", displayLangID).Replace("&", "") + " (" +
            //               MenuMessages.GetString("MenuIraq", "Arabic (Iraq)", lngIraq).Replace("&", "") + ")";
            //    case lngLaos:
            //        return MenuMessages.GetString("MenuLaos", "Laos", displayLangID).Replace("&", "") + " (" +
            //               MenuMessages.GetString("MenuLaos", "Laos", lngLaos).Replace("&", "") + ")";
            //    case lngVietnam:
            //        return MenuMessages.GetString("MenuVietnam", "Vietnam", displayLangID).Replace("&", "") + " (" +
            //               MenuMessages.GetString("MenuVietnam", "Vietnam", lngVietnam).Replace("&", "") + ")";
            //    case lngThai:
            //        return MenuMessages.GetString("MenuThai", "Thai", displayLangID).Replace("&", "") + " (" +
            //               MenuMessages.GetString("MenuThai", "Thai", lngUk).Replace("&", "") + ")";
            //}
            //return MenuMessages.GetString("MenuEnglish", "&English", displayLangID).Replace("&", "") + " (" +
            //       MenuMessages.GetString("MenuEnglish", "&English", lngEn).Replace("&", "") + ")";
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

        public static bool IsRtl
        {
            get { return BaseSettings.ForceRightToLeft || (Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft && !BaseSettings.ForceLeftToRight); }
        }
    }
}