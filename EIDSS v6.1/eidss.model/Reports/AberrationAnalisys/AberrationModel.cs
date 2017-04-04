using System;
using eidss.model.Reports.Common;

namespace eidss.model.Reports.AberrationAnalisys
{
    public class AberrationModel : BaseIntervalLocationModel
    {
        public AberrationModel
            (string language, DateTime startDate, DateTime endDate,
                long? regionId, long? rayonId, long? settlementId, string location,
                decimal threshold, int timeInterval, string timeIntervalText, int baseline, int lag, string[] dateFilter,
                string dateFilterText,
                bool useArchive)
            : base(language, startDate, endDate, regionId, rayonId, settlementId, location, useArchive)
        {
            SetDateFilter(dateFilter);
            DateFilterText = dateFilterText;
            TimeIntervalId = timeInterval;
            TimeIntervalText = timeIntervalText;
            AnalysisMethod = "CUSUM";
            Threshold = threshold;
            Baseline = baseline;
            Lag = lag;
        }

        public bool[] DateFilter { get; set; }

        private void SetDateFilter(string[] value)
        {
            DateFilter = new[] {false, false, false, false, false};
            for (int i = 0; i < value.Length; i++)
            {
                DateFilter[int.Parse(value[i]) - 1] = true;
            }
        }

        public string DateFilterText { get; set; }

        public int TimeIntervalId { get; set; }

        public string TimeIntervalText { get; set; }

        public string AnalysisMethod { get; set; }

        public decimal Threshold { get; set; }

        public int Baseline { get; set; }

        public int Lag { get; set; }
    }
}