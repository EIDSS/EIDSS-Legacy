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
        public const int VetMaxDiagnosisCount = 3;

        private bool m_IsVet;

        public SummaryByRayonDiagnosisModel()
        {
            MultipleDiagnosisFilter = new MultipleDiagnosisModel {IsRequired = true, UsingType = DiagnosisUsingTypeEnum.StandardCase};
        }

        public SummaryByRayonDiagnosisModel(DiagnosisUsingTypeEnum? usingType = DiagnosisUsingTypeEnum.StandardCase)
        {
            MultipleDiagnosisFilter = new MultipleDiagnosisModel {IsRequired = true, UsingType = usingType};
        }

        public SummaryByRayonDiagnosisModel
            (string lang, DateTime startDate, DateTime endDate, bool isVet, bool useArchive,
                DiagnosisUsingTypeEnum? usingType = DiagnosisUsingTypeEnum.StandardCase)
            : base(lang, startDate, endDate, useArchive)
        {
            MultipleDiagnosisFilter = new MultipleDiagnosisModel {IsRequired = true, UsingType = usingType};
            IsVet = isVet;
        }

        public bool IsVet
        {
            get { return m_IsVet; }
            set
            {
                MultipleDiagnosisFilter.HascCode = value ? (int) HACode.Livestock : (int) HACode.Human;
                m_IsVet = value;
            }
        }

        public int MaxDiagnosisCount
        {
            get { return IsVet ? VetMaxDiagnosisCount : HumMaxDiagnosisCount; }
        }

        public MultipleDiagnosisModel MultipleDiagnosisFilter { get; set; }

        public string MultipleDiagnosisFilter_CheckedItems { get; set; }

        public List<string> TakeLimitedCheckedItems
        {
            get { return MultipleDiagnosisFilter.CheckedItems.ToList().Take(MaxDiagnosisCount).ToList(); }
        }

        public bool IsTooManyCheckedItems()
        {
            return MultipleDiagnosisFilter.CheckedItems.Length <= MaxDiagnosisCount;
        }

        public override string ToString()
        {
            return string.Format("{0}, Diagnosis={1}", base.ToString(), MultipleDiagnosisFilter);
        }
    }
}