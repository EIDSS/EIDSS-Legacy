using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bv.model.Model.Core;

namespace bv.model.Model.Validators
{
    /*
    public class ReferenceDuplicateValueValidator: PredicateValidator
    {
        public ReferenceDuplicateValueValidator(string fldName, string prpName, string fldLabel, bool shouldAsk)
            : base("mbDuplicateFoundSimple", fldName, prpName, fldLabel, null, shouldAsk)
        {
        }
        public override void Validate<T>(T t, Func<T, bool> predicate)
        {
            if (!predicate(t))
            {
                throw new ValidationModelException(m_MsgId, m_FldName, m_PrpName, m_Pars, GetType(), m_ShouldAsk);
            }
        }
        public override void Validate<T, C>(T t, C c, Func<T, C, bool> predicate)
        {
            if (!predicate(t, c))
            {
                throw new ValidationModelException(m_MsgId, m_FldName, m_PrpName, m_Pars, GetType(), m_ShouldAsk);
            }
        }

    }
    */
}
