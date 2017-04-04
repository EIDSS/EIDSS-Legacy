using System;
using System.Collections.Generic;

namespace eidss.model.Reports.Common
{
    [Serializable]
    public class MultipleCounterModel : BaseMultipleModel
    {
        public MultipleCounterModel() : this(new string[0])
        {
        }

        public MultipleCounterModel(string[] checkedItems)
        {
            CheckedItems = checkedItems ?? new string[0];
        }
        public bool IsRequired { get; set; }

        public override List<SelectListItemSurrogate> LoadItemList()
        {
            return FilterHelper.GetWebCounterList(1);
        }
    }
}