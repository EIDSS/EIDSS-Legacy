using System;

namespace eidss.model.Reports.AZ
{
    [Serializable]
    public class DataQualityIndicatorsModel : AFPModel
    {
        public DataQualityIndicatorsModel()
        {
            MultipleDiagnosisFilter = new MultipleDiagnosisModel();
        }

        public DataQualityIndicatorsModel(string language, int year, string[] checkedDiagnosis, int period, int periodType, bool useArchive)
            : base(language, year, period, periodType, useArchive)
        {
            MultipleDiagnosisFilter = new MultipleDiagnosisModel(checkedDiagnosis);
        }

        public MultipleDiagnosisModel MultipleDiagnosisFilter { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, Diagnosis={1}", base.ToString(), MultipleDiagnosisFilter);
        }
    }
}