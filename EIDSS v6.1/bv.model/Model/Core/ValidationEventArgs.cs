using System;

namespace bv.model.Model.Core
{
    public class ValidationEventArgs : EventArgs
    {
        private readonly string m_MsgId;
        public string MessageId { get { return m_MsgId;  } }
        private readonly string m_FldName;
        public string FieldName { get { return m_FldName; } }
        private readonly string m_PrpName;
        public string PropertyName { get { return m_PrpName; } }
        private readonly object[] m_Pars;
        public object[] Pars { get { return m_Pars; } }
        public bool Continue { get; set; }
        private readonly Type m_Type;
        public Type Type { get { return m_Type; } }
        private readonly IObject m_Obj;
        public IObject Obj { get { return m_Obj; } }
        public ValidationEventType ValidationType { get; private set; }
        public bool ShouldAsk { get { return ValidationType == ValidationEventType.Question; } }

        public ValidationEventArgs(string msgId, string fldName, string prpName, object[] pars, Type type, IObject obj, ValidationEventType validationType)
            : base()
        {
            Continue = false;
            m_MsgId = msgId;
            m_FldName = fldName;
            m_PrpName = prpName;
            m_Pars = pars;
            m_Type = type;
            m_Obj = obj;
            ValidationType = validationType;
        }
    }
}
