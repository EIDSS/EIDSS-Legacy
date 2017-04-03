using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bv.common.Core;

namespace eidss.mobileclient.Utils
{
    public static class Cultures
    {
        public static string[] Available
        {
            get { return Localizer.SupportedLanguages.Values.ToArray(); }
        }
        /*= new string[] { "en", "ru", "en-US", "ru-RU", "ka-GE", "uk-UA", "az-Latn-AZ", "kk-KZ" };*/

        public static bool StringIsCulture(string stringToTest)
        {
            return Available.Any(s => s.Equals(stringToTest, StringComparison.InvariantCultureIgnoreCase));
        }

        public static string GetSiteLanguage(HttpRequestBase request)
        {
            return System.Threading.Thread.CurrentThread.CurrentCulture.ToString();
        }

        public static string GetLanguageAbbreviation(string culture)
        {
            switch (culture)
            {
                case "ru":
                case "ru-RU":
                    return "ru";
                case "ka-GE":
                    return "ka";
                case "kk-KZ":
                    return "kk";
                case "az-Latn-AZ":
                    return "az-L";
                case "uk-UA":
                    return "uk";
                case "uz-Cyrl-UZ":
                    return "uz-C";
                case "uz-Latn-UZ":
                    return "uz-L";
                case "hy-AM":
                    return "hy";
                case "ar-IQ":
                    return "ar";
                default:
                    return "en";
            }
        }

        public static string GetCulture(string language)
        {
            return Localizer.SupportedLanguages.ContainsKey(language)
                       ? Localizer.SupportedLanguages[language]
                       : (Localizer.SupportedLanguages.ContainsValue(language) ? language : "en");
            /*
            switch (language)
            {
                case "ru":
                case "ru-RU":
                    return "ru-RU";
                case "ka":
                case "ka-GE":
                    return "ka-GE";
                case "kk":
                case "kk-KZ":
                    return "kk-KZ";
                case "az-L":
                case "az-Latn-Az":
                    return "az-Latn-Az";
                case "uk":
                case "uk-UA":
                    return "uk-UA";
                case "uz-C":
                case "uz-Cyrl-UZ":
                    return "uz-Cyrl-UZ";
                case "uz-L":
                case "uz-Latn-UZ":
                    return "uz-Latn-UZ";
                case "hy":
                case "hy-AM":
                    return "hy-AM";
                case "ar":
                case "ar-IQ":
                    return "ar-IQ";
                default:
                    return "en-US";
            }
            */
        }
    }
}
