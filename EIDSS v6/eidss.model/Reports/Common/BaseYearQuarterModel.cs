using System;
using System.Collections.Generic;
using System.Linq;
using eidss.model.Core;

namespace eidss.model.Reports.Common
{
    [Serializable]
    public class BaseYearQuarterModel : BaseYearModel
    {
        public const int MinYear = 2000;
        private QuartersModel m_Quarters;

        public BaseYearQuarterModel()
        {
            Year = DateTime.Now.Year;
            m_Quarters = new QuartersModel();
        }

        public BaseYearQuarterModel
            (string language, int year, bool firstQuarter, bool secondQuarter, bool thirdQuarter, bool fourthQuarter, bool useArchive)
            : base(language, year, useArchive)
        {
            m_Quarters = new QuartersModel(firstQuarter, secondQuarter, thirdQuarter, fourthQuarter);
        }

        public BaseYearQuarterModel(string language, int year, QuartersModel quarters, bool useArchive)
            : base(language, year, useArchive)
        {
            m_Quarters = quarters;
        }

         [LocalizedDisplayName("QuarterForAggr")]
        public QuartersModel Quarters
        {
            get { return m_Quarters; }
            set { m_Quarters = value; }
        }

        public string QuarterName
        {
            get { return m_Quarters.QuarterName; }
        }

        public DateTime StartDate1
        {
            get { return m_Quarters.GetStartDate1(Year); }
        }

        public DateTime EndDate1
        {
            get { return m_Quarters.GetEndDate1(Year); }
        }

        public DateTime? StartDate2
        {
            get { return m_Quarters.GetStartDate2(Year); }
        }

        public DateTime? EndDate2
        {
            get { return m_Quarters.GetEndDate2(Year); }
        }

        public string QuarterLongName
        {
            get
            {
                string name = GetQuarterLongName(StartDate1, EndDate1);
                if (StartDate2.HasValue && EndDate2.HasValue)
                {
                    name +=",                          " + GetQuarterLongName(StartDate2.Value, EndDate2.Value);
                }
                return name;
            }
        }

        public List<SelectListItemSurrogate> QuarterListItems
        {
            get
            {
                var collection = new List<SelectListItemSurrogate>();
                int index = 0;
                foreach (string quarter in QuartersModel.QuarterNumbers)
                {
                    collection.Add(new SelectListItemSurrogate
                    {
                        Text = quarter,
                        Value = index.ToString()
                    });
                    index++;
                }

                return collection;
            }
        }

        private static string GetQuarterLongName(DateTime startDate, DateTime endDate)
        {
            return string.Format("{0:dd.MM.yyyy} - {1:dd.MM.yyyy}", startDate, endDate);
        }

        public List<SelectListItemSurrogate> GetQuarters()
        {
            List<string> qf = QuartersModel.QuartersFormat;
            return qf.Select((t, i) =>
                new SelectListItemSurrogate
                {
                    Selected = false,
                    Value = (i + 1).ToString(), //1-4
                    Text = String.Format(t, Year)
                }).ToList();
        }


        public override string ToString()
        {
            return base.ToString() + string.Format("  Quarter={0}", m_Quarters.QuarterName);
        }

       
    }
}