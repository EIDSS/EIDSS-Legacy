using System;
using System.ComponentModel;

namespace eidss.model.AVR.SourceData
{
    public delegate object AvrMethodDelegate(AvrDataRowBase avrDataRow);
    public class AvrMethodDescriptor : PropertyDescriptor
    {
        protected AvrMethodDelegate m_Method;
        protected Type m_MethodReturnType;

        public AvrMethodDescriptor(string name, AvrMethodDelegate method, Type methodReturnType)
            : base(name, null)
        {
            m_Method = method;
            m_MethodReturnType = methodReturnType;
        }

        public AvrMethodDelegate Method
        {
            get { return m_Method; }
        }

        public Type MethodReturnType
        {
            get { return m_MethodReturnType; }
        }

        public override Type ComponentType
        {
            get { return typeof(AvrDataRowBase); }
        }

        public override Type PropertyType
        {
            get { return m_MethodReturnType; }
        }

        public override bool IsReadOnly
        {
            get { return true; }
        }

        public override bool CanResetValue(object component)
        {
            return false;
        }


        public override object GetValue(object component)
        {
            var p = (AvrDataRowBase)component;
            return m_Method(p);
        }

        public override void ResetValue(object component)
        {
        }

       
        public override void SetValue(object component, object value)
        {
        }

        public override bool ShouldSerializeValue(object component)
        {
            return false;
        }
    }
}