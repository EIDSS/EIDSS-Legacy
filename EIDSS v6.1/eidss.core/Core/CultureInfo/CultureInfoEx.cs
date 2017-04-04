using bv.common.Core;

namespace eidss.model.Core.CultureInfo
{
    public class CultureInfoEx
    {
        private readonly System.Globalization.CultureInfo m_CultureInfo;
        private readonly string m_ShortName;

        public CultureInfoEx(System.Globalization.CultureInfo cultureInfo, string shortName)
        {
            Utils.CheckNotNull(cultureInfo, "cultureInfo");
            Utils.CheckNotNullOrEmpty(shortName, "shortName");

            m_CultureInfo = cultureInfo;
            m_ShortName = shortName;
        }

        public System.Globalization.CultureInfo CultureInfo
        {
            get { return m_CultureInfo; }
        }

        public string ShortName
        {
            get { return m_ShortName; }
        }

        public string NativeName
        {
            get
            {
                string langId = Localizer.GetLanguageID(CultureInfo);
                return Localizer.GetMenuLanguageName(langId);
            }
        }

        public override string ToString()
        {
            return NativeName;
        }
    }
}