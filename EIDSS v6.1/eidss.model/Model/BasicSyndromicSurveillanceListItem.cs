
using eidss.model.Resources;

namespace eidss.model.Schema
{
    public partial class BasicSyndromicSurveillanceListItem
    {
        public static void Init()
        {
            m_MaskMonthsOnly = EidssMessages.Get("bssMaskMonthsOnly");
            m_MaskYearsOnly = EidssMessages.Get("bssMaskYearsOnly");
            m_MaskYearsAndMonths = EidssMessages.Get("bssMaskYearsAndMonths");
        }

        private static string m_MaskYearsOnly;
        private static string MaskYearsOnly
        {
            get
            {
                if (m_MaskYearsOnly == null)
                    Init();
                return m_MaskYearsOnly;
            }
        }

        private static string m_MaskMonthsOnly;
        private static string MaskMonthsOnly
        {
            get
            {
                if (m_MaskMonthsOnly == null)
                    Init();
                return m_MaskMonthsOnly;
            }
        }
        private static string m_MaskYearsAndMonths;
        private static string MaskYearsAndMonths
        {
            get
            {
                if (m_MaskYearsAndMonths == null)
                    Init();
                return m_MaskYearsAndMonths;
            }
        }
        public string FormatAge()
        {
            if (intAgeYear != null && intAgeYear > 0 && intAgeMonth != null && intAgeMonth > 0)
                return string.Format(MaskYearsAndMonths, intAgeYear, intAgeMonth);
            if (intAgeYear != null && intAgeYear > 0)
                return string.Format(MaskYearsOnly, intAgeYear);
            if (intAgeMonth != null && intAgeMonth > 0)
                return string.Format(MaskMonthsOnly, intAgeMonth);
            return "";
        }
    }
}
