using System;
using System.Collections.Generic;
using bv.common.Core;
using eidss.model.Enums;

namespace eidss.model.Reports.Common
{
    [Serializable]
    public class MultipleCaseClassificationModel : BaseMultipleModel
    {
        private readonly int m_HACode;
        private readonly bool m_IsInitial;
        private readonly bool m_IsFinal;

        public MultipleCaseClassificationModel()
        {
            CheckedItems = new string[0];
            m_HACode = (int) HACode.Human;
            m_IsInitial = false;
            m_IsFinal = false;
        }

        public MultipleCaseClassificationModel(string[] checkedItems, int haCode, bool isInitial, bool isFinal)
        {
            CheckedItems = checkedItems ?? new string[0];
            m_HACode = haCode;
            m_IsInitial = isInitial;
            m_IsFinal = isFinal;
        }

        public override List<SelectListItemSurrogate> LoadItemList()
        {
            List<SelectListItemSurrogate> itemsList
                = FilterHelper.GetCaseClassificationsList(Localizer.CurrentCultureLanguageID, m_HACode, m_IsInitial, m_IsFinal, false);
            itemsList.Add(new SelectListItemSurrogate {Text = "<no classification>", Value = "0"});
            return itemsList;
        }
    }
}