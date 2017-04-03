using System;
using bv.model.Model.Core;

namespace bv.model.Model.Validators
{
    public class PredicateValidator : BaseFieldValidator
    {

        public PredicateValidator(string msgId, string fldName, string prpName, string fldLabel, object[] pars, bool shouldAsk)
            : base(msgId, fldName, prpName, fldLabel, pars, shouldAsk)
        {
        }

        public virtual void Validate<T>(T t, Func<T, bool> predicate)
            where T : IObject
        {
            if (!predicate(t))
                throw new ValidationModelException(m_MsgId, m_FldName, m_PrpName, m_Pars, GetType(), m_ShouldAsk, t);
        }
        public virtual void Validate<T, C>(T t, C c, Func<T, C, bool> predicate)
            where T : IObject
        {
            if (!predicate(t, c))
                throw new ValidationModelException(m_MsgId, m_FldName, m_PrpName, m_Pars, GetType(), m_ShouldAsk, t);
        }

        public virtual void Validate<T>(T t, Func<T, bool> predicate, Func<T, string> msgFunc)
            where T : IObject
        {
            if (!predicate(t))
                throw new ValidationModelException(msgFunc(t), m_FldName, m_PrpName, m_Pars, GetType(), m_ShouldAsk, t);
        }
        public virtual void Validate<T, C>(T t, C c, Func<T, C, bool> predicate, Func<T, C, string> msgFunc)
            where T : IObject
        {
            if (!predicate(t, c))
                throw new ValidationModelException(msgFunc(t, c), m_FldName, m_PrpName, m_Pars, GetType(), m_ShouldAsk, t);
        }

        public static bool CompareDates(DateTime? d1, DateTime? d2)
        {
            return (d1 == null || d2 == null || d1.Value.Date <= d2.Value.Date);
        }
    }
}
