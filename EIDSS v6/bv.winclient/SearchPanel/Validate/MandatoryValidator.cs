using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using bv.winclient.Layout;
using DevExpress.XtraEditors;

namespace bv.winclient.SearchPanel.Validate
{
    public class MandatoryValidator : BaseValidator
    {
        public MandatoryValidator(Control target)
            : base(target)
        {

        }

        public override void Validate()
        {
            IsValid = !string.IsNullOrWhiteSpace(Target.Text);
            //if (string.IsNullOrWhiteSpace(Target.Text))
            //{
            //    if (Target is BaseEdit)
            //        LayoutCorrector.SetStyleController(Target as BaseEdit, LayoutCorrector.MandatoryStyleController);

            //    //Target.BackColor = Color.White;
            //    //IsValid = false;
            //}
            //else
            //{
            //    LayoutCorrector.SetStyleController(Target as BaseEdit, LayoutCorrector.EditorStyleController);
            //    //Target.BackColor = Color.White;
            //    //IsValid = true;
            //}
        }

    }

}
