using System;
using eidss.model.Resources;

namespace eidss.model.Reports.AberrationAnalisys
{
    public class SyndromicAberrationModel : AberrationModel
    {
        public SyndromicAberrationModel
            (string language, DateTime startDate, DateTime endDate,
                long? regionId, long? rayonId, long? settlementId, string location,
                decimal threshold, int timeInterval, string timeIntervalText, int baseline, int lag, string[] dateFilter, string dateFilterText,
                long site, string siteText, long notifType, string notifTypeText, int? startAge, int? endAge, long? gender,
                string genderText, long? hospital, string hospitalText,
                bool useArchive)
            : base(
                language, startDate, endDate, regionId, rayonId, settlementId, location, threshold, timeInterval, timeIntervalText, baseline,
                lag, dateFilter, dateFilterText, useArchive)
        {
            Site = site;
            SiteText = siteText;
            NotifType = notifType;
            NotifTypeText = notifTypeText;
            StartAge = startAge;
            EndAge = endAge;
            Gender = gender;
            GenderText = genderText;
            Hospital = hospital;
            HospitalText = hospitalText;
        }

        public long Site { get; set; }

        public string SiteText { get; set; }

        public long NotifType { get; set; }

        public string NotifTypeText { get; set; }

        public int? StartAge { get; set; }

        public int? EndAge { get; set; }

        public string AgeText
        {
            get
            {
                if (StartAge == null)
                {
                    if (EndAge == null)
                    {
                        return string.Empty;
                    }
                    return "- " + EndAge + " " + EidssMessages.Get("years");
                }
                if (EndAge == null || EndAge == 0)
                {
                    return StartAge + " -";
                }
                return StartAge + " - " + EndAge + " " + EidssMessages.Get("years");
            }
        }

        public long? Gender { get; set; }

        public string GenderText { get; set; }

        public long? Hospital { get; set; }

        public string HospitalText { get; set; }
    }
}