using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bv.common.Core;
using bv.common.Resources;
using bv.model.Model.Core;

namespace bv.model.Model.Validators
{

    public class RequiredValidator : BaseFieldValidator
    {

        public RequiredValidator(string fldName, string prpName, string fldLabel, bool shouldAsk)
            : base("ErrMandatoryFieldRequired", fldName, prpName, fldLabel, null, shouldAsk)
        {
        }

        public void Validate<T, F>(Func<T, bool> predicate, T t, F f)
            where F : class
        {
            if (predicate(t))
            {
                if (f == null)
                    throw new ValidationModelException(m_MsgId, m_FldName, m_PrpName, m_Pars, typeof(RequiredValidator), m_ShouldAsk);

                var s = f as string;
                if (s != null)
                {
                    if (s.Trim().Length == 0)
                        throw new ValidationModelException(m_MsgId, m_FldName, m_PrpName, m_Pars, typeof(RequiredValidator), m_ShouldAsk);
                }
            }
        }

        public void Validate<T, F>(Func<T, bool> predicate, T t, Nullable<F> f)
            where F : struct
        {
            if (predicate(t))
            {
                if (f == null)
                    throw new ValidationModelException(m_MsgId, m_FldName, m_PrpName, m_Pars, typeof(RequiredValidator), m_ShouldAsk);

                if (!f.HasValue)
                    throw new ValidationModelException(m_MsgId, m_FldName, m_PrpName, m_Pars, typeof(RequiredValidator), m_ShouldAsk);
            }
        }

        public void Validate<T>(Func<T, bool> predicate, T t, Nullable<DateTime> f)
        {
            if (predicate(t))
            {
                if (f == null)
                    throw new ValidationModelException(m_MsgId, m_FldName, m_PrpName, m_Pars, typeof(RequiredValidator), m_ShouldAsk);

                if (!f.HasValue)
                    throw new ValidationModelException(m_MsgId, m_FldName, m_PrpName, m_Pars, typeof(RequiredValidator), m_ShouldAsk);

                if (f.Value == DateTime.MinValue)
                    throw new ValidationModelException(m_MsgId, m_FldName, m_PrpName, m_Pars, typeof(RequiredValidator), m_ShouldAsk);
            }
        }

        public void Validate<T>(Func<T, bool> predicate, T t, DateTime f)
        {
            if (predicate(t))
            {
                if (f == DateTime.MinValue)
                    throw new ValidationModelException(m_MsgId, m_FldName, m_PrpName, m_Pars, typeof(RequiredValidator), m_ShouldAsk);
            }
        }

        public void Validate<T>(Func<T, bool> predicate, T t, Int64? f)
        {
            if (predicate(t))
            {
                if (f == null || f.Value == 0)
                    throw new ValidationModelException(m_MsgId, m_FldName, m_PrpName, m_Pars, typeof(RequiredValidator), m_ShouldAsk);
            }
        }

        public void Validate<T>(Func<T, bool> predicate, T t, Int64 f)
        {
            if (predicate(t))
            {
                if (f == 0)
                    throw new ValidationModelException(m_MsgId, m_FldName, m_PrpName, m_Pars, typeof(RequiredValidator), m_ShouldAsk);
            }
        }

        public void Validate<T>(Func<T, bool> predicate, T t, Int32 f)
        {
            if (predicate(t))
            {
                if (f == 0)
                    throw new ValidationModelException(m_MsgId, m_FldName, m_PrpName, m_Pars, typeof(RequiredValidator), m_ShouldAsk);
            }
        }

        public void Validate<T>(Func<T, bool> predicate, T t, Int16 f)
        {
            if (predicate(t))
            {
                if (f == 0)
                    throw new ValidationModelException(m_MsgId, m_FldName, m_PrpName, m_Pars, typeof(RequiredValidator), m_ShouldAsk);
            }
        }


    }


}
