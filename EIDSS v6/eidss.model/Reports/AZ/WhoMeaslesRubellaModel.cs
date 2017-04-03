using System;
using System.Linq;
using bv.common.Core;
using eidss.model.Core;
using eidss.model.Reports.Common;

namespace eidss.model.Reports.AZ
{
    [Serializable]
    public class WhoMeaslesRubellaModel : BaseDateModel
    {
        public const long RubellaId = 7720770000000;
        public const long MeaslesId = 7720040000000;

        public WhoMeaslesRubellaModel()
        {
            Init();
        }

        public WhoMeaslesRubellaModel
            (string language,
                int year, int? month,
                long? diagnosisId,
                bool useArchive)
            : base(language, year, month, useArchive)
        {
            DiagnosisId = diagnosisId;
            Init();
        }

        private void Init()
        {
            Diagnoses = new DiagnosisModel();
            var diagnList = FilterHelper.GetHumanDiagnosisList(Localizer.CurrentCultureLanguageID)
                        .Where(d => Utils.Str(d.Value) == RubellaId.ToString() || Utils.Str(d.Value) == MeaslesId.ToString())
                        .ToList();
            Diagnoses.SetDiagnoses(diagnList);
        }

        [LocalizedDisplayName("DiagnosisName")]
        public long? DiagnosisId { get; set; }

        public DiagnosisModel Diagnoses { get; set; }
        /*
        public List<SelectListItemSurrogate> DiagnosisList
        {
            get
            {
                return
                    FilterHelper.GetHumanDiagnosisList(Localizer.CurrentCultureLanguageID)
                        .Where(d => Utils.Str(d.Value) == RubellaId.ToString() || Utils.Str(d.Value) == MeaslesId.ToString())
                        .ToList();
            }
        }
        */
        public override string ToString()
        {
            return base.ToString() + "Diagnosis Id=" + DiagnosisId;
        }
    }
}