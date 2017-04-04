using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bv.common.Configuration;
using bv.common.Core;

namespace eidss.smartphone.web.Utils
{
    public static class Cultures
    {
        public static string[] Available
        {
            get { return CustomCultureHelper.SupportedLanguages.Values.ToArray(); }
        }

        public static string GetLanguageAbbreviation(string culture)
        {
            return CustomCultureHelper.SupportedLanguages.ContainsValue(culture)
                       ? CustomCultureHelper.SupportedLanguages.First(c => c.Value == culture).Key
                       : "en";
        }

        public static string GetCulture(string language)
        {
            return CustomCultureHelper.SupportedLanguages.ContainsKey(language)
                       ? CustomCultureHelper.SupportedLanguages[language]
                       : (CustomCultureHelper.SupportedLanguages.ContainsValue(language) ? language : "en");
        }
        public static string GetCultureStandard(string language)
        {
            var ret = GetCulture(language);
            if (ret.EndsWith("-Eidss"))
            {
                ret = ret.Substring(0, 2);
            }
            return ret;
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

        public static bool IsRtl
        {
            get
            {
                return Localizer.IsRtl;
            }
        }
    }
}
