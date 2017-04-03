using System;
using System.Collections.Generic;
using bv.common.Core;
using eidss.model.Core;
using eidss.model.Enums;

namespace eidss.model.Reports.Common
{
    [Serializable]
    public class DiagnosisModel : IDisposable
    {
        [LocalizedDisplayName("DiagnosisName")]
        public long? DiagnosisId { get; set; }

        public void Dispose()
        {
            if (ItemsList != null) ItemsList.Clear();
        }

        public List<SelectListItemSurrogate> ItemsList { get; private set; }

        public void SetDiagnoses(List<SelectListItemSurrogate> diagnosisList)
        {
            ItemsList = diagnosisList;
        }

        public void LoadDiagnoses(int hascCode, List<long> filter = null, DiagnosisUsingTypeEnum? usingType = DiagnosisUsingTypeEnum.StandardCase)
        {
            var list = FilterHelper.GetDiagnosisList(Localizer.CurrentCultureLanguageID, hascCode, usingType);
            if (filter != null)
            {
                for (var i = list.Count - 1; i >= 0; i++)
                {
                    if (!filter.Contains(Convert.ToInt64(list[i].Value))) list.RemoveAt(i);
                }
            }
            ItemsList = list;
        }
    }
}
