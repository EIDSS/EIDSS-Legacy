using System;

namespace eidss.model.Reports.AberrationAnalisys
{
    public class ILISyndromicAberrationModel : AberrationModel
    {
        public ILISyndromicAberrationModel
            (string language, DateTime startDate, DateTime endDate,
                long? regionId, long? rayonId, string location,
                decimal threshold, int timeInterval, string timeIntervalText, int baseline, int lag, string[] dateFilter, string dateFilterText,
                int ageGroup, string ageGroupText,
                long? hospital, string hospitalText,
                bool useArchive)
            : base(
                language, startDate, endDate, regionId, rayonId, null, location, threshold, timeInterval, timeIntervalText, baseline,
                lag, dateFilter, dateFilterText, useArchive)
        {
            AgeGroup = ageGroup;
            AgeGroupText = ageGroupText;
            Hospital = hospital;
            HospitalText = hospitalText;
        }

        public int AgeGroup { get; set; }

        public string AgeGroupText { get; set; }

        public long? Hospital { get; set; }

        public string HospitalText { get; set; }
    }
}