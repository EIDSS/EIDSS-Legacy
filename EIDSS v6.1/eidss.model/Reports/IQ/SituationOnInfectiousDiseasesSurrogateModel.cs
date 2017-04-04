using System;
using eidss.model.Enums;
using eidss.model.Reports.Common;
using eidss.model.Resources;

namespace eidss.model.Reports.IQ
{
    [Serializable]
    public class SituationOnInfectiousDiseasesSurrogateModel : BaseIntervalModel
    {
        public const string DateFormat = "dd/MM/yyyy";

        public SituationOnInfectiousDiseasesSurrogateModel()
        {
            StartDate = new DateTime(2000, 01, 01);
            EndDate = new DateTime(2000, 01, 01);
            PeriodNumber = 1;
        }

        public SituationOnInfectiousDiseasesSurrogateModel
            (string language,
                int year, StatisticPeriodType periodType, int periodNumber,
                DateTime startDate, DateTime endDate,
                long? regionId, string regionName,
                bool useArchive)
            : base(language, startDate, endDate, useArchive)
        {
            Year = year;
            PeriodType = periodType;
            PeriodNumber = periodNumber;
            RegionId = regionId;
            RegionName = regionName;
        }

        public int Year { get; set; }

        public StatisticPeriodType PeriodType { get; set; }

        public int PeriodNumber { get; set; }

        public long? RegionId { get; set; }

        public string RegionName { get; set; }

        public string PeriodHeaderText
        {
            get
            {
                string periodName = "Unsuppored period type:" + PeriodType;
                switch (PeriodType)
                {
                    case StatisticPeriodType.Week:
                        periodName = EidssMessages.Get("WeekCapital", "Week");
                        break;
                    case StatisticPeriodType.Month:
                        periodName = EidssMessages.Get("MonthCapital", "Month");
                        break;
                }

                return String.Format("{0} ({1}) {2} - {3}",
                    periodName, PeriodNumber,
                    StartDate.ToString(DateFormat), EndDate.ToString(DateFormat));
            }
        }
    }
}