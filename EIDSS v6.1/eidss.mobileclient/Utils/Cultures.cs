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
            return CustomCultureHelper.SupportedLanguages.ContainsValue(culture)
                       ? CustomCultureHelper.SupportedLanguages.First(c => c.Value == culture).Key
                       : "en";
        }

        public static string GetCulture(string language)
        {
            return Localizer.SupportedLanguages.ContainsKey(language)
                       ? Localizer.SupportedLanguages[language]
                       : (Localizer.SupportedLanguages.ContainsValue(language) ? language : "en");
        }
    }
}
