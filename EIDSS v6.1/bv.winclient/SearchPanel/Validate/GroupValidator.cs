using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bv.winclient.SearchPanel.Validate
{
    public class GroupValidator
    {
        List<BaseValidator> list = new List<BaseValidator>();

        public void Add(BaseValidator validator)
        {
            if (!list.Contains(validator))
                list.Add(validator);
        }
        public bool Validate()
        {
            var isValid = true;
            foreach (var validator in list)
            {
                validator.Validate();
                if (validator.IsValid == false)
                    isValid = false;
            }
            return isValid;
        }
    }

}
