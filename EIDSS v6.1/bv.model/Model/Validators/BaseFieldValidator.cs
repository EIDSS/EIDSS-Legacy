using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bv.common.Core;
using bv.common.Resources;
using bv.model.Model.Core;
namespace bv.model.Model.Validators
{
    public class BaseFieldValidator : IFieldValidator
    {
        protected readonly string m_MsgId;
        protected readonly string m_FldName;
        protected readonly string m_PrpName;
        protected readonly string m_FldLabel;
        protected readonly object[] m_Pars;
        protected readonly ValidationEventType m_ValidationType;
        public static BaseStringsStorage FieldCaptions { get; set; }
        public BaseFieldValidator(string fldName)
        {
            m_FldName = fldName;
        }
        public BaseFieldValidator(string msgId, string fldName, string prpName, string fldLabel, object[] pars, ValidationEventType validationType)
        {
            if (!string.IsNullOrEmpty(msgId))
                m_MsgId = msgId;
            m_FldName = fldName;
            m_PrpName = prpName;
            m_FldLabel = string.IsNullOrEmpty(fldLabel) ? fldName : fldLabel;
            if (pars == null || pars.Length == 0)
                m_Pars = FieldCaptions != null ? new string[] { FieldCaptions.GetString(m_FldLabel) } : new string[] { m_FldLabel };
            else
            {
                m_Pars = pars;
            }
            m_ValidationType = validationType;
        }
    }
}
