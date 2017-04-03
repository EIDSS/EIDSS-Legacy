using System;
using eidss.model.Enums;
using eidss.model.Reports.Common;

namespace eidss.model.Reports.AberrationAnalisys
{
    public class VetAberrationModel : AberrationModel, IDisposable
    {
        public VetAberrationModel
            (string language, DateTime startDate, DateTime endDate,
                long? regionId, long? rayonId, long? settlementId, string location,
                decimal threshold, int timeInterval, string timeIntervalText, int baseline, int lag, string[] dateFilter, string dateFilterText,
                string[] checkedDiagnosis, long? caseType, string caseTypeText, long? reportType, string reportTypeText,
                string[] checkedCaseClassification,
                bool useArchive)
            : base(
                language, startDate, endDate, regionId, rayonId, settlementId, location, threshold, timeInterval, timeIntervalText, baseline,
                lag, dateFilter, dateFilterText, useArchive)
        {
            CaseTypeId = caseType;
            CaseTypeText = caseTypeText;
            ReportType = reportType;
            ReportTypeText = reportTypeText;
            int intHACode = caseType == (long)CaseTypeEnum.Livestock ? (int)HACode.Livestock : (int)HACode.Avian;
            multipleDiagnosis = new MultipleDiagnosisModel(checkedDiagnosis, intHACode);
            multipleCaseClassification = new MultipleCaseClassificationModel(checkedCaseClassification,
                intHACode, false, false);
        }

        public MultipleDiagnosisModel multipleDiagnosis { get; set; }

        public MultipleCaseClassificationModel multipleCaseClassification { get; set; }

        public long? CaseTypeId { get; set; }

        public string CaseTypeText { get; set; }

        public long? ReportType { get; set; }

        public string ReportTypeText { get; set; }

        public void Dispose()
        {
            multipleDiagnosis.Dispose();
            multipleCaseClassification.Dispose();
        }
    }
}