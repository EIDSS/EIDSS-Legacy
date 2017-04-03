using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web;
using System.Windows.Forms;

namespace bv.common.Core
{
    public class CustomCultureHelper
    {
        #region Properties
        static long m_CurrentCountry;
        public static long CurrentCountry
        {
            get
            {
                return m_CurrentCountry;
            }
            set
            {
                m_CurrentCountry = value;
                Register(m_CurrentCountry);
                InitSupportedLanguages();
            }
        }

            #region SupportedLanguages
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

        private static void AddLanguage(string langID, string cultureName)
        {
            if (!m_SupportedLanguages.ContainsKey(langID))
                m_SupportedLanguages.Add(langID, cultureName);
        }

        private static void InitSupportedLanguages()
        {
            m_SupportedLanguages = new Dictionary<string, string>();
            foreach (string key in Localizer.AllSupportedLanguages.Keys)
            {
                AddLanguage(key, GetCustomCultureName(key));
            }
        }
            #endregion

            #region CountryCodes
        static Dictionary<long, string> m_CountryCodes;
        public static Dictionary<long, string> CountryCodes
        {
            get
            {
                if (m_CountryCodes == null)
                {
                    InitSupportedCountries();
                }
                return m_CountryCodes;
            }
            set { m_CountryCodes = value; }
        }

        private static void InitSupportedCountries()
        {
            m_CountryCodes = new Dictionary<long, string>();
            AddCountry(170000000, "AZ");
            AddCountry(80000000, "HY");
            AddCountry(780000000, "KA");
            AddCountry(1240000000, "KZ");
            AddCountry(1050000000, "IQ");
            AddCountry(2260000000, "UA");
            AddCountry(2250000000, "TZ");
        }

        private static void AddCountry(long countryID, string countryCode)
        {
            if (!CountryCodes.ContainsKey(countryID))
                CountryCodes.Add(countryID, countryCode.ToUpperInvariant());
        }
            #endregion
            #region CountryNames
        static Dictionary<long, string> m_CountryNames;
        public static Dictionary<long, string> CountryNames
        {
            get
            {
                if (m_CountryNames == null)
                {
                    InitSupportedCountryNames();
                }
                return m_CountryNames;
            }
            set { m_CountryNames = value; }
        }

        private static void InitSupportedCountryNames()
        {
            m_CountryNames = new Dictionary<long, string>();
            AddCountryName(170000000, "Azerbaijan");
            AddCountryName(80000000, "Armenia");
            AddCountryName(780000000, "Georgia");
            AddCountryName(1240000000, "Kazakhstan");
            AddCountryName(1050000000, "Iraq");
            AddCountryName(2260000000, "Ukraine");
            AddCountryName(2250000000, "Tanzania");
        }

        private static void AddCountryName(long countryID, string countryName)
        {
            if (!CountryNames.ContainsKey(countryID))
                CountryNames.Add(countryID, countryName);
        }
        #endregion
            #region SupportedCustomCultures
        static List<Tuple<string, long>> m_SupportedCustomCultures;
        static object m_LockObject = new object();
        public static List<Tuple<string, long>> SupportedCustomCultures
        {
            get
            {
                lock (m_LockObject)
                {
                    if (m_SupportedCustomCultures == null)
                    {
                        InitSupportedCustomCultures();
                    }
                    return m_SupportedCustomCultures;
                }
            }
            set { lock (m_LockObject){m_SupportedCustomCultures = value;} }
        }

        private static void InitSupportedCustomCultures()
        {
            m_SupportedCustomCultures = new List<Tuple<string, long>>();
            AddCustomCulture("en", 170000000);
            AddCustomCulture("en", 80000000);
            AddCustomCulture("en", 780000000);
            AddCustomCulture("en", 1240000000);
            AddCustomCulture("ru", 1240000000);
            AddCustomCulture("en", 1050000000);
            AddCustomCulture("en", 2260000000);
            AddCustomCulture("en", 2250000000);
        }

        private static void AddCustomCulture(string cultureCode, long countryID)
        {
            var item = new Tuple<string, long>(cultureCode.ToLowerInvariant(), countryID);
            if (!SupportedCustomCultures.Contains(item))
                SupportedCustomCultures.Add(item);
        }
            #endregion
        #endregion

        //- creates custom culture for country identified by EIDSS country ID
        public static void Register(string lang, long countryID)
        {
            if (!CountryCodes.ContainsKey(countryID))
                throw new Exception(string.Format("\'{0}\' - Unsupported country ID.", countryID));
            if (!SupportedCustomCultures.Contains(new Tuple<string, long>(lang.ToLowerInvariant(), countryID)))
                throw new Exception(string.Format("Unsupported pair culture name - country ID."));

            string cultureName = FormCustomCultureName(lang, countryID);
            if ((!IsCultureRegistered(cultureName)) && Localizer.AllSupportedLanguages.ContainsKey(lang))
            {
                string oldCultureName = Localizer.AllSupportedLanguages[lang];
                CultureAndRegionInfoBuilder cib = new CultureAndRegionInfoBuilder(cultureName, CultureAndRegionModifiers.None);

                // Populate the new CultureAndRegionInfoBuilder object with culture information.
                CultureInfo ci = new CultureInfo(oldCultureName);
                cib.LoadDataFromCultureInfo(ci);

                // Populate the new CultureAndRegionInfoBuilder object with region information.
                RegionInfo ri = new RegionInfo(oldCultureName);
                cib.LoadDataFromRegionInfo(ri);
                cib.CultureEnglishName = GetMenuLanguageName(lang, countryID);//"English (Georgia)";
                cib.CultureNativeName = GetMenuLanguageName(lang, countryID);
                cib.RegionNativeName = GetMenuLanguageName(lang, countryID);
                cib.RegionEnglishName = GetMenuLanguageName(lang, countryID);
                cib.Parent = ci;
                cib.Register();
            }
        }

        //- creates all custom cultures intended for country identified by EIDSS country ID. Currently we should create en culture for each country and ru culture for Kazakhstan. This can be updated later
        public static void Register(long countryID)
        {
            if (!CountryCodes.ContainsKey(countryID))
                throw new Exception(string.Format("\'{0}\' - Unsupported country ID.", countryID));

            foreach (Tuple<string, long> cult in SupportedCustomCultures.FindAll(t => t.Item2 == countryID))
            {
                Register(cult.Item1, countryID);
            }
        }

        //- creates all custom cultures intended for country identified by EIDSS country ID. Currently we should create en culture for each country and ru culture for Kazakhstan. This can be updated later
        public static void Register(string countryCode)
        {
            if(!CountryCodes.ContainsValue(countryCode.ToUpperInvariant()))
                throw new Exception(string.Format("\'{0}\' - Unsupported country code.", countryCode));

            foreach (long countryID in CountryCodes.Keys)
            {
                if (CountryCodes[countryID] == countryCode.ToUpperInvariant())
                {
                    Register(countryID);
                }
            }
        }

        //- creates custom cultures for all supported countries/cultures (list af all supported custom cultures shall be defined)
        public static void RegisterAll()
        {
            foreach (Tuple<string, long> cult in SupportedCustomCultures)
            {
                Register(cult.Item1, cult.Item2);
            }
        }

        //- deletes custom culture for country identified by EIDSS country ID
        public static void UnRegister(string cultureCode, long countryID)
        {
            if (!CountryCodes.ContainsKey(countryID))
                throw new Exception(string.Format("\'{0}\' - Unsupported country ID.", countryID));
            if (!SupportedCustomCultures.Contains(new Tuple<string, long>(cultureCode.ToLowerInvariant(), countryID)))
                throw new Exception(string.Format("Unsupported pair culture name - country ID."));

            // unregister only earlier registered cultures
            string cultureName = FormCustomCultureName(cultureCode, countryID);
            if(IsCultureRegistered(cultureName))
                CultureAndRegionInfoBuilder.Unregister(cultureName);
        }

        //- deletes all custom cultures intended for country identified by EIDSS country ID
        public static void UnRegister(long countryID)
        {
            if (!CountryCodes.ContainsKey(countryID))
                throw new Exception(string.Format("\'{0}\' - Unsupported country ID.", countryID));

            UnRegister(Localizer.lngEn, countryID);
            UnRegister(Localizer.lngRu, countryID);
        }

        //- deletes all custom cultures intended for country identified by EIDSS country ID
        public static void UnRegister(string countryCode)
        {
            if(!CountryCodes.ContainsValue(countryCode.ToUpperInvariant()))
                throw new Exception(string.Format("\'{0}\' - Unsupported country code.", countryCode));

            foreach (long countryID in CountryCodes.Keys)
            {
                if (CountryCodes[countryID] == countryCode.ToUpperInvariant())
                {
                    UnRegister(countryID);
                }
            }
        }

        //- deletes all our custom cultures
        public static void UnRegisterAll()
        {
            foreach (Tuple<string, long> cult in SupportedCustomCultures)
            {
                UnRegister(cult.Item1, cult.Item2);
            }
        }

        //- returns custom culture name for specified parametrs
        public static string FormCustomCultureName(string cultureCode, long countryID)
        {
            bool found = false;
            foreach (var culture in SupportedCustomCultures)
            {
                if (culture.Item1 == cultureCode && culture.Item2 == countryID)
                    found = true;
            }
            if (!found)
                return "";
            return GetCountryNameByID(countryID) == null ? "" : string.Format("{0}-{1}-Eidss", cultureCode.ToLowerInvariant(), GetCountryNameByID(countryID));
        }

        public static bool IsCultureRegistered(string cultureName)
        {
            bool bFound = false;
            foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.UserCustomCulture))
            {
                if (cultureName == ci.Name)
                    bFound = true;
            }
            return bFound;
        }

        //- returns custom culture name for specified parametrs using the rules above if custom culture is registered for these parameters and cultureName in other case.
        public static string GetCustomCultureName(string cultureCode, long countryID)
        {
            string cultureName = FormCustomCultureName(cultureCode, countryID);
            if (IsCultureRegistered(cultureName))
                return cultureName;
            else
                return Localizer.AllSupportedLanguages[cultureCode];
        }

        public static string GetCustomCultureName(string cultureCode)
        {
            return GetCustomCultureName(cultureCode, CurrentCountry);
        }

        //- returns country abbreviation defined by countryID, null for incorrect (unsupported) countryID
        public static string GetCountryNameByID(long countryID)
        {
            if (CountryCodes.ContainsKey(countryID))
                return CountryCodes[countryID];
            else
                return null;
        }

        //- returns country ID defined by countryName, 0 for incorrect countryName. countryName shall be case insensetive.
        public static long GetCountryIDByName(string countryName)
        {
            //country ID by country abbrevation
            foreach(long countryID in CountryCodes.Keys)
            {
                if (CountryCodes[countryID] == countryName.ToUpperInvariant())
                    return countryID;
            }
            //country ID by country name
            foreach (long countryID in CountryNames.Keys)
            {
                if (CountryNames[countryID].ToUpperInvariant() == countryName.ToUpperInvariant())
                    return countryID;
            }
            return 0L;
        }

        private static string GetMenuLanguageName(string cultureCode, long countryID)
        {
            var item = new Tuple<string, long>(cultureCode.ToLowerInvariant(), countryID);
            //if (SupportedCustomCultures.Contains(item))
                return string.Format("{0} ({1})", Localizer.GetLanguageName(cultureCode), CountryNames[countryID]);
            //else
            //    return Localizer.GetMenuLanguageName(cultureCode);
        }

        /*public static string GetMenuLanguageName(string cultureCode)
        {
            return GetMenuLanguageName(cultureCode, CurrentCountry);
        }*/
    }
}
