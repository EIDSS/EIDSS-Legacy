using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bv.model.Model.Core;
using System.Reflection;
using bv.model.Model.Validators;
using eidss.model.Enums;
using eidss.model.Core;

namespace eidss.model.Schema
{
    public class CustomMandatoryFieldValidator : BaseFieldValidator
    {

        public CustomMandatoryFieldValidator(string fldName, string prpName, string fldLabel, bool shouldAsk)
            : base("ErrMandatoryFieldRequired", fldName, prpName, fldLabel, null, shouldAsk)
        {
        }


        private bool FieldNeedsValidation(CustomMandatoryField field)
        {
            return EidssSiteContext.Instance.CustomMandatoryFields.Contains(field);
        }


        public void Validate<T, F>(T t, F f, CustomMandatoryField field)
            where F : class
        {
            if (FieldNeedsValidation(field))
            {
                if (f == null)
                    throw new ValidationModelException(m_MsgId, m_FldName, m_PrpName, m_Pars, typeof(RequiredValidator), false);

                var s = f as string;
                if (s != null)
                {
                    if (s.Length == 0)
                        throw new ValidationModelException(m_MsgId, m_FldName, m_PrpName, m_Pars, typeof(RequiredValidator), false);
                }
            }
        }

        public void Validate<T, F>(T t, Nullable<F> f, CustomMandatoryField field)
            where F : struct
        {
            if (FieldNeedsValidation(field))
            {
                if (f == null)
                    throw new ValidationModelException(m_MsgId, m_FldName, m_PrpName, m_Pars, typeof(RequiredValidator), false);

                if (!f.HasValue)
                    throw new ValidationModelException(m_MsgId, m_FldName, m_PrpName, m_Pars, typeof(RequiredValidator), false);
            }
        }

        public void Validate<T>(T t, Nullable<DateTime> f, CustomMandatoryField field)
        {
            if (FieldNeedsValidation(field))
            {
                if (f == null)
                    throw new ValidationModelException(m_MsgId, m_FldName, m_PrpName, m_Pars, typeof(RequiredValidator), false);

                if (!f.HasValue)
                    throw new ValidationModelException(m_MsgId, m_FldName, m_PrpName, m_Pars, typeof(RequiredValidator), false);

                if (f.Value == DateTime.MinValue)
                    throw new ValidationModelException(m_MsgId, m_FldName, m_PrpName, m_Pars, typeof(RequiredValidator), false);
            }
        }

        public void Validate<T>(T t, DateTime f, CustomMandatoryField field)
        {
            if (FieldNeedsValidation(field))
            {
                if (f == DateTime.MinValue)
                    throw new ValidationModelException(m_MsgId, m_FldName, m_PrpName, m_Pars, typeof(RequiredValidator), false);
            }
        }

        public void Validate<T>( T t, Int64 f, CustomMandatoryField field)
        {
            if (FieldNeedsValidation(field))
            {
                if (f == 0)
                    throw new ValidationModelException(m_MsgId, m_FldName, m_PrpName, m_Pars, typeof(RequiredValidator), false);
            }
        }

        public void Validate<T>( T t, Int32 f, CustomMandatoryField field)
        {
            if (FieldNeedsValidation(field))
            {
                if (f == 0)
                    throw new ValidationModelException(m_MsgId, m_FldName, m_PrpName, m_Pars, typeof(RequiredValidator), false);
            }
        }

        public void Validate<T>( T t, Int16 f, CustomMandatoryField field)
        {
            if (FieldNeedsValidation(field))
            {
                if (f == 0)
                    throw new ValidationModelException(m_MsgId, m_FldName, m_PrpName, m_Pars, typeof(RequiredValidator), false);
            }
        }


        //public void Validate<T,F>(T t, F f, CustomMandatoryField field)
        //    where T : class
        //    where F : class
        //{
        //    if (t == null)
        //        throw new ValidationModelException(m_MsgId, m_FldName, m_PrpName, m_Pars, typeof(RequiredValidator));

        //    Type customMandatoryFieldAttribute = typeof(CustomMandatoryFieldAttribute);

        //    foreach (PropertyInfo property in t.GetType().GetProperties().Where(p => p.GetCustomAttributes(customMandatoryFieldAttribute, false).Length > 0))
        //    {
        //        var attr = (CustomMandatoryFieldAttribute)property.GetCustomAttributes(customMandatoryFieldAttribute, false)[0];
        //        if (EidssSiteContext.Instance.CustomMandatoryFields.Count(i => attr.Match(i)) > 0)
        //        {
        //            var val = property.GetValue(t, null);
        //            if (val == null)
        //            {
        //                throw new ValidationModelException(m_MsgId, property.Name, property.Name, m_Pars, typeof(RequiredValidator));
        //            }
        //        }


        //    }

        //}
    }
}
