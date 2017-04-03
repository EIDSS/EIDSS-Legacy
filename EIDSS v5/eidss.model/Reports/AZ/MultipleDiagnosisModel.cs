using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using eidss.model.Core;
using eidss.model.Reports.Common;

namespace eidss.model.Reports.AZ
{
    [Serializable]
    public class MultipleDiagnosisModel
    {
        public MultipleDiagnosisModel()
        {
            CheckedDiagnosis = new string[0];
        }

        public MultipleDiagnosisModel(string[] checkedDiagnosis)
        {
            CheckedDiagnosis = checkedDiagnosis;
        }

        [LocalizedDisplayName("DiagnosisName")]
        public string[] CheckedDiagnosis { get; set; }

        public List<SelectListItemSurrogate> DiagnosisList
        {
            get { return FilterHelper.GetHumanDiagnosisList(Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName); }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            foreach (string diagnos in CheckedDiagnosis)
            {
                result.AppendFormat("{0},", diagnos);
            }
            return result.ToString();
        }
    }
}