using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bv.common.Resources;
using bv.model.Model.Core;

namespace bv.model.Model.Validators
{
    //This vlaidator shall be applied only to string values validation
    public class DuplicateValueValidator : PredicateValidator
    {
        public DuplicateValueValidator(string fldName, string prpName, string fldLabel, bool shouldAsk)
            : base("mbDuplicateFound", fldName, prpName, fldLabel, FieldCaptions != null ? new string[] { FieldCaptions.GetString(fldName), "" } : new string[] { fldName, "" }, shouldAsk)
        {
        }
        public override void Validate<T>(T t, Func<T, bool> predicate)
        {
            if (!predicate(t))
            {
                object value = (t as IObject).GetValue(m_FldName);
                m_Pars[1] = value;
                throw new ValidationModelException(m_MsgId, m_FldName, m_PrpName, m_Pars, GetType(), m_ShouldAsk);
            }
        }
        public override void Validate<T, C>(T t, C c, Func<T, C, bool> predicate)
        {
            if (!predicate(t, c))
            {
                m_Pars[1] = (c as IObject).GetValue(m_FldName).ToString ();
                throw new ValidationModelException(m_MsgId, m_FldName, m_PrpName, m_Pars, GetType(), m_ShouldAsk);
            }
        }

    }
}
