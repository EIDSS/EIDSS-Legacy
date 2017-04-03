using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bv.common.Core;

namespace eidss.webclient.Utils
{
    public static class Cultures
    {
        public static string[] Available
        {
            get { return Localizer.SupportedLanguages.Values.ToArray(); }
        }

        public static string GetLanguageAbbreviation(string culture)
        {
            return Localizer.SupportedLanguages.ContainsValue(culture)
                       ? Localizer.SupportedLanguages.First(c => c.Value == culture).Key
                       : "en";
        }

        public static string GetCulture(string language)
        {
            return Localizer.SupportedLanguages.ContainsKey(language)
                       ? Localizer.SupportedLanguages[language]
                       : (Localizer.SupportedLanguages.ContainsValue(language) ? language : "en");
        }

        public static bool StringIsCulture(string stringToTest)
        {
            foreach (string s in Available)
            {
                if (s.Equals(stringToTest, StringComparison.InvariantCultureIgnoreCase))
                    return true;
            }
            return false;
        }

        public static string GetSiteLanguage(HttpRequestBase request)
        {
            return System.Threading.Thread.CurrentThread.CurrentCulture.ToString();
        }
    }
}
