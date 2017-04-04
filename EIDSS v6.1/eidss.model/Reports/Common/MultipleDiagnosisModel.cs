using System;
using System.Collections.Generic;
using bv.common.Core;
using eidss.model.Enums;

namespace eidss.model.Reports.Common
{
    [Serializable]
    public class MultipleDiagnosisModel : BaseMultipleModel
    {
        public MultipleDiagnosisModel() : this(new string[0], (int) HACode.Human)
        {
        }

        public MultipleDiagnosisModel(string[] checkedDiagnosis) : this(checkedDiagnosis, (int) HACode.Human)
        {
        }

        public MultipleDiagnosisModel(string[] checkedDiagnosis, int hacode)
        {
            CheckedItems = checkedDiagnosis ?? new string[0];
            HascCode = hacode;
            UsingType = DiagnosisUsingTypeEnum.StandardCase;
        }

        public int HascCode { get; set; }

        public bool IsRequired { get; set; }

        public bool AddSelectAllItem { get; set; }

        public DiagnosisUsingTypeEnum? UsingType { get; set; }

        public override List<SelectListItemSurrogate> LoadItemList()
        {
            return FilterHelper.GetDiagnosisList(Localizer.CurrentCultureLanguageID, HascCode, UsingType, false, AddSelectAllItem);
        }
    }
}