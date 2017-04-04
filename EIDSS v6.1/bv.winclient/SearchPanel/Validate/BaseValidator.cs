using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace bv.winclient.SearchPanel.Validate
{
    public class BaseValidator : IValidator
    {
        public Control Target { get; set; }
        public bool IsValid { get; set; }
        public string ErrorText { get; set; }

        public BaseValidator(Control target)
        {
            Target = target;
            Target.TextChanged += Validate;
        }
        public void Validate(object sender, EventArgs e)
        {
            Validate();
        }
        public virtual void Validate()
        {
        }
    }
}
