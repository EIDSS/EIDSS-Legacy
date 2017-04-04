using System;
using System.Collections.Generic;
using System.Linq;
using eidss.model.Enums;
using eidss.model.Reports.Common;

namespace eidss.model.Reports.AZ
{
    [Serializable]
    public class SummaryByRayonDiagnosisModel : BaseIntervalModel
    {
        public const int HumMaxDiagnosisCount = 5;

        public SummaryByRayonDiagnosisModel()
        {
            MultipleDiagnosisFilter = new MultipleDiagnosisModel
            {
                IsRequired = true,
                UsingType = DiagnosisUsingTypeEnum.StandardCase,
                HascCode = (int) HACode.Human
            };
        }

        public SummaryByRayonDiagnosisModel(DiagnosisUsingTypeEnum? usingType = DiagnosisUsingTypeEnum.StandardCase)
        {
            MultipleDiagnosisFilter = new MultipleDiagnosisModel
            {
                IsRequired = true,
                UsingType = usingType,
                HascCode = (int) HACode.Human
            };
        }

        public SummaryByRayonDiagnosisModel
            (string lang, DateTime startDate, DateTime endDate, bool useArchive,
                DiagnosisUsingTypeEnum? usingType = DiagnosisUsingTypeEnum.StandardCase)
            : base(lang, startDate, endDate, useArchive)
        {
            MultipleDiagnosisFilter = new MultipleDiagnosisModel
            {
                IsRequired = true,
                UsingType = usingType,
                HascCode = (int) HACode.Human
            };
        }

        public MultipleDiagnosisModel MultipleDiagnosisFilter { get; set; }

        public string MultipleDiagnosisFilter_CheckedItems { get; set; }

        public List<string> TakeLimitedCheckedItems
        {
            get { return MultipleDiagnosisFilter.CheckedItems.ToList().Take(HumMaxDiagnosisCount).ToList(); }
        }

        public bool IsTooManyCheckedItems()
        {
            return MultipleDiagnosisFilter.CheckedItems.Length <= HumMaxDiagnosisCount;
        }

        public override string ToString()
        {
            return string.Format("{0}, Diagnosis={1}", base.ToString(), MultipleDiagnosisFilter);
        }
    }
}