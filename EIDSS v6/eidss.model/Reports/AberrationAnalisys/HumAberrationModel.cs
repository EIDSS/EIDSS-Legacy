using System;
using eidss.model.Enums;
using eidss.model.Reports.Common;
using eidss.model.Resources;

namespace eidss.model.Reports.AberrationAnalisys
{
    public class HumAberrationModel : AberrationModel
    {
        public HumAberrationModel
            (string language, DateTime startDate, DateTime endDate,
                long? regionId, long? rayonId, long? settlementId, string location,
                decimal threshold, int timeInterval, string timeIntervalText, int baseline, int lag, string[] dateFilter, string dateFilterText,
                string[] checkedDiagnosis, int? startAge, int? endAge, long? gender, string genderText, string[] checkedCaseClassification,
                bool useArchive)
            : base(
                language, startDate, endDate, regionId, rayonId, settlementId, location, threshold, timeInterval, timeIntervalText, baseline,
                lag, dateFilter, dateFilterText, useArchive)
        {
            StartAge = startAge;
            EndAge = endAge;
            Gender = gender;
            GenderText = genderText;
            MultipleDiagnosis = new MultipleDiagnosisModel(checkedDiagnosis, (int) HACode.Human);
            MultipleCaseClassification = new MultipleCaseClassificationModel(checkedCaseClassification, (int) HACode.Human, false, true);
        }

        public MultipleDiagnosisModel MultipleDiagnosis { get; set; }

        public MultipleCaseClassificationModel MultipleCaseClassification { get; set; }

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
    }
}