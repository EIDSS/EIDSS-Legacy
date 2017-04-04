using System;
using System.Collections.Generic;
using eidss.model.Resources;

namespace eidss.model.Reports.Common
{
    [Serializable]
    public class MultipleYearsModel : BaseMultipleModel
    {
        public bool IsRequired { get; set; }
        public int UpperYear { get; private set; }
        public string MultipleYearsFilterCheckedItems { get; set; }

        public MultipleYearsModel(int upperYear = 0)
        {
            IsRequired = false;
            UpperYear = upperYear;
        }

        public override List<SelectListItemSurrogate> LoadItemList()
        {
            var result = new List<SelectListItemSurrogate>
            {
                new SelectListItemSurrogate
                {
                    Text = EidssFields.Get("SelectAll"),
                    Value = "-1",
                    Selected = false
                }
            };

            for (var i = UpperYear; i >= 2000; i--)
            {
                var istr = i.ToString();
                result.Add(new SelectListItemSurrogate
                {
                    Text = i.ToString(),
                    Value = i.ToString(),
                    Selected = Array.IndexOf(CheckedItems, istr) >= 0
                });
            }
            return result;
        }
    }
}