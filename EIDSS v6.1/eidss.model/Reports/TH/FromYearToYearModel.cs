using System;
using bv.common.Core;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.model.Reports.Common;
using eidss.model.Resources;

namespace eidss.model.Reports.TH
{
    [Serializable]
    public class FromYearToYearModel : BaseModel
    {
        public int GregorianToThai(int year)
        {
            if (Language == Localizer.lngThai)
                return ThaiCalendarHelper.GregorianYearToThai(year);
            return year;
        }

        public int ThaiToGrigorean(int year)
        {
            if (Language == Localizer.lngThai)
                return ThaiCalendarHelper.ThaiYearToGregorian(year);
            return year;
        }

        public int MinYearFrom { get; set; }
        public int MaxYearFrom { get; set; }
        public int MinYearTo { get; set; }
        public int MaxYearTo { get; set; }
        public void SetYearsIntervalFrom(int minYear = 0, int maxYear = 0, int defaultYear = 0)
        {
            if (minYear > 0) MinYearFrom = minYear;
            if (maxYear > 0) MaxYearFrom = maxYear;
            if (defaultYear > 0) StartYear = defaultYear;
        }

        public void SetYearsIntervalTo(int minYear = 0, int maxYear = 0, int defaultYear = 0)
        {
            if (minYear > 0) MinYearTo = minYear;
            if (maxYear > 0) MaxYearTo = maxYear;
            if (defaultYear > 0) EndYear = defaultYear;
        }

        public bool YearsCaptionsSpecial { get; set; }

        public FromYearToYearModel()
        {
            Language = ModelUserContext.CurrentLanguage;
            EndYear = GregorianToThai(DateTime.Now.Year);
            StartYear = EndYear - 1;
            MinYearFrom = MinYearTo = GregorianToThai(2000);
            MaxYearFrom = StartYear;
            MaxYearTo = EndYear;
        }

        public string GetYearFromCaption()
        {
            return EidssFields.Get("strFromYear");
        }

        public string GetYearToCaption()
        {
            return EidssFields.Get("strToYear");
        }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public override string ToString()
        {
            return base.ToString() + string.Format(" StartYear={0}, EndYear={1}", StartYear, EndYear);
        }
    }
}
