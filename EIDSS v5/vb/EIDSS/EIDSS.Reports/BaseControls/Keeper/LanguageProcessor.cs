using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.Threading;
using bv.common.Core;
using bv.winclient.Core;
using eidss.model.Core.CultureInfo;

namespace EIDSS.Reports.BaseControls.Keeper
{
    public sealed class LanguageProcessor
    {
        private readonly Component m_ParentComponent;
        private readonly List<CultureInfoEx> m_LanguageItems = new List<CultureInfoEx>();
        private CultureInfoEx m_CurrentCulture;

        public LanguageProcessor(Component parentComponent)
        {
            Utils.CheckNotNull(parentComponent, "parentComponent");
            m_ParentComponent = parentComponent;
        }

        public CultureInfoEx CurrentCulture
        {
            get
            {
                if (m_CurrentCulture == null)
                    throw new ApplicationException("CurrentCulture is not initialized in report keeper");
                return m_CurrentCulture;
            }
            internal set { m_CurrentCulture = value; }
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

        private void FillSupportedLanguages()
        {
            bool isInDesign = (WinUtils.IsComponentInDesignMode(m_ParentComponent));
            bool isInTest = Utils.IsCalledFromUnitTest();
            if (isInTest || isInDesign)
            {
                foreach (KeyValuePair<string, string> pair in CultureInfoEx.ExistingLanguages)
                {
                    if (!Localizer.SupportedLanguages.ContainsKey(pair.Key))
                    {
                        Localizer.SupportedLanguages.Add(pair.Key, pair.Value);
                    }
                }
            }
        }

        private void FillLanguageItems()
        {
            m_LanguageItems.Clear();
            foreach (string language in Localizer.SupportedLanguages.Keys)
            {
                var item = new CultureInfoEx(new CultureInfo(Localizer.SupportedLanguages[language]),language);
                m_LanguageItems.Add(item);
            }
        }

        private void FindCurrentLanguage()
        {
            m_CurrentCulture = m_LanguageItems.Find(IsCultureCurrent);
            if (m_CurrentCulture == null)
            {
                var sbError = new StringBuilder();
                sbError.AppendFormat("Current culture {0} is absent in SupportedLanguages",Thread.CurrentThread.CurrentCulture);
                sbError.AppendLine();
                sbError.AppendFormat("Supported languages count: {0}", Localizer.SupportedLanguages.Count);
                sbError.AppendFormat("IsCalledFromUnitTest: {0}", Utils.IsCalledFromUnitTest());
                sbError.AppendLine("Supported languages are: ");
                sbError.AppendLine();
                foreach (string entry in Localizer.SupportedLanguages.Keys)
                {
                    sbError.AppendFormat("{0} - {1}", entry, Localizer.SupportedLanguages[entry]);
                    sbError.AppendLine();
                }
                throw new ApplicationException(sbError.ToString());
            }
        }

        private static bool IsCultureCurrent(CultureInfoEx tmp)
        {
            return tmp.CultureInfo.ToString().ToLower() ==
                   Thread.CurrentThread.CurrentCulture.ToString().ToLower();
        }
    }
}