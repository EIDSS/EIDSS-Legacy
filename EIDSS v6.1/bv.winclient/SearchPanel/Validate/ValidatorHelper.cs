using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace bv.winclient.SearchPanel.Validate
{
    public class ValidatorHelper
    {
        public static Control CreatMandatoryValidator(Control target, string text, GroupValidator groupValidator = null)
        {
            var baseValidator = new MandatoryValidator(target);

            if (groupValidator != null)
                groupValidator.Add(baseValidator);
            return new LabelControl();
        }
    }
}
