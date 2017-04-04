using System;
using System.Collections.Generic;
using System.Linq;
using bv.common.Core;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Reports.Common;

namespace eidss.model.Reports.AZ
{
    [Serializable]
    public class VetSummaryModel : BaseIntervalModel
    {
        private MultipleSpeciesTypeModel m_SpeciesType;
        public const int VetMaxSpeciesTypeCount = 3;
//        private MultipleDiagnosisModel m_MultipleDiagnosisFilter;

        public VetSummaryModel()
        {
            MinStartDate = new DateTime(2000, 1, 1);
            MaxStartDate = DateTime.Today;
            StartDate = DateTime.Today.AddMonths(-1);
            MinEndDate = new DateTime(2000, 1, 1);
            MaxEndDate = DateTime.Today;
            EndDate = DateTime.Today;
            SurveillanceType = VetSummarySurveillanceType.ActiveSurveillanceIndex;
            DiagnosisModel = new DiagnosisModel();
            DiagnosisModel.SetDiagnoses(DiagnosisList);
            SpeciesType = new MultipleSpeciesTypeModel();
        }

        public VetSummaryModel
            (string lang, DateTime startDate, DateTime endDate,
                VetSummarySurveillanceType surveillanceType, string surveillanceTypeName,
                long diagnosisId, string diagnosisName,
                long actionMethodId, string actionMethodName,
                string[] speciesTypeCheckedItems,
                bool useArchive)
            : base(lang, startDate, endDate, useArchive)
        {
            SurveillanceType = surveillanceType;
            SurveillanceTypeName = surveillanceTypeName;
            DiagnosisId = diagnosisId;
            DiagnosisName = diagnosisName;
            ActionMethodId = actionMethodId;
            ActionMethodName = actionMethodName;
            SpeciesType = new MultipleSpeciesTypeModel(speciesTypeCheckedItems ?? new string[0]);
        }

        public VetSummarySurveillanceType SurveillanceType { get; set; }
        public string SurveillanceTypeName { get; set; }

        public DiagnosisModel DiagnosisModel { get; set; }

        [LocalizedDisplayName("DiagnosisName")]
        public long? DiagnosisId { get; set; }

        public string DiagnosisName { get; set; }

        public List<SelectListItemSurrogate> DiagnosisList
        {
            get
            {
                switch (SurveillanceType)
                {
                    case VetSummarySurveillanceType.ActiveSurveillanceIndex:
                        return FilterHelper.GetDiagnosisList(Localizer.CurrentCultureLanguageID, (int) HACode.Livestock,
                            DiagnosisUsingTypeEnum.StandardCase);
                    case VetSummarySurveillanceType.PassiveSurveillanceIndex:
                        return FilterHelper.GetDiagnosisList(Localizer.CurrentCultureLanguageID, (int) (HACode.Livestock | HACode.Avian),
                            DiagnosisUsingTypeEnum.StandardCase);
                    case VetSummarySurveillanceType.AggregateActionsIndex:
                        return FilterHelper.GetDiagnosisList(Localizer.CurrentCultureLanguageID, (int) (HACode.Livestock | HACode.Avian),
                            DiagnosisUsingTypeEnum.AggregatedCase);
                    default:
                        return new List<SelectListItemSurrogate>();
                }
            }
        }

        public long? ActionMethodId { get; set; }

        public string ActionMethodName { get; set; }

        public string[] CheckedItems
        {
            get { return SpeciesType.CheckedItems; }
            set { SpeciesType.CheckedItems = value; }
        }

        public MultipleSpeciesTypeModel SpeciesType
        {
            get { return m_SpeciesType ?? (m_SpeciesType = new MultipleSpeciesTypeModel()); }
            set { m_SpeciesType = value; }
        }

        public string SpeciesType_CheckedItems { get; set; }

        public List<string> TakeLimitedCheckedItems
        {
            get { return CheckedItems.ToList().Take(VetMaxSpeciesTypeCount).ToList(); }
        }

        public bool IsTooManyCheckedItems()
        {
            return CheckedItems.Length <= VetMaxSpeciesTypeCount;
        }
    }
}