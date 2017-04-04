using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using bv.common.Core;

namespace eidss.model.Core.CultureInfo
{
    public class BaseLanguageProcessor
    {
        private readonly List<CultureInfoEx> m_LanguageItems = new List<CultureInfoEx>();
        private CultureInfoEx m_CurrentCulture;

        public CultureInfoEx CurrentCulture
        {
            get
            {
                if (m_CurrentCulture == null)
                {
                    throw new ApplicationException("CurrentCulture is not initialized in report keeper");
                }
                return m_CurrentCulture;
            }
            set { m_CurrentCulture = value; }
        }

        public IList<CultureInfoEx> LanguageItems
        {
            get { return m_LanguageItems.AsReadOnly(); }
        }

        public void InitLanguages()
        {
            // Note: [Inan] workaround to support design mode for component or call from unit test
            FillSupportedLanguages();

            FillLanguageItems();

            FindCurrentLanguage();
        }

        protected virtual bool NeedToFillSupportedLanguages
        {
            get
            {
                bool isInTest = Utils.IsCalledFromUnitTest();
                return isInTest;
            }
        }

        private void FillSupportedLanguages()
        {
            if (NeedToFillSupportedLanguages)
            {
                //CustomCultureHelper.SupportedLanguages
                foreach (KeyValuePair<string, string> pair in Localizer.AllSupportedLanguages)
                {
                    if (!Localizer.SupportedLanguages.ContainsKey(pair.Key))
                    {
                        Localizer.SupportedLanguages.Add(pair.Key, pair.Value);
                    }
                    if (!CustomCultureHelper.SupportedLanguages.ContainsKey(pair.Key))
                    {
                        CustomCultureHelper.SupportedLanguages.Add(pair.Key, CustomCultureHelper.GetCustomCultureName(pair.Key));
                    }
                }
            }
        }

        private void FillLanguageItems()
        {
            m_LanguageItems.Clear();
            foreach (string language in Localizer.SupportedLanguages.Keys)
            {
                var cultureInfo = new System.Globalization.CultureInfo(CustomCultureHelper.SupportedLanguages[language]);
                var item = new CultureInfoEx(cultureInfo, language);
                m_LanguageItems.Add(item);
            }
        }

        private void FindCurrentLanguage()
        {
            m_CurrentCulture = m_LanguageItems.Find(IsCultureCurrent);
            if (m_CurrentCulture == null)
            {
                var sbError = new StringBuilder();
                sbError.AppendFormat("Current culture {0} is absent in SupportedLanguages", Thread.CurrentThread.CurrentCulture);
                sbError.AppendLine();
                sbError.AppendFormat("Supported languages count: {0}", CustomCultureHelper.SupportedLanguages.Count);
                sbError.AppendFormat("IsCalledFromUnitTest: {0}", Utils.IsCalledFromUnitTest());
                sbError.AppendLine("Supported languages are: ");
                sbError.AppendLine();
                foreach (string entry in CustomCultureHelper.SupportedLanguages.Keys)
                {
                    sbError.AppendFormat("{0} - {1}", entry, CustomCultureHelper.SupportedLanguages[entry]);
                    sbError.AppendLine();
                }
                throw new ApplicationException(sbError.ToString());
            }
        }

        private static bool IsCultureCurrent(CultureInfoEx tmp)
        {
            return tmp.CultureInfo.ToString().ToLowerInvariant() ==
                   Thread.CurrentThread.CurrentCulture.ToString().ToLowerInvariant();
        }
    }
}