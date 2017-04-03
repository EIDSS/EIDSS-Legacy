using System;
using eidss.model.Reports.Common;

namespace eidss.model.Reports.AZ
{
    [Serializable]
    public class SummaryByRayonDiagnosisAgeGroupsModel : BaseIntervalModel
    {
        public SummaryByRayonDiagnosisAgeGroupsModel()
        {
            MultipleDiagnosisFilter = new MultipleDiagnosisModel();
        }

        public SummaryByRayonDiagnosisAgeGroupsModel(string lang, DateTime startDate, DateTime endDate, bool useArchive)
            : base(lang, startDate, endDate, useArchive)
        {
            MultipleDiagnosisFilter = new MultipleDiagnosisModel();
        }

        public MultipleDiagnosisModel MultipleDiagnosisFilter { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, Diagnosis={1}", base.ToString(),  MultipleDiagnosisFilter);
        }
    }
}