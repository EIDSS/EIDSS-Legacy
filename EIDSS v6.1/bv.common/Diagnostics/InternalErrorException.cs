using System;
using System.Runtime.Serialization;


namespace bv.common.Diagnostics
{
    [Serializable()]
    public class InternalErrorException : ApplicationException
    {
        protected InternalErrorException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
        public InternalErrorException(string message)
            : base(message)
        {
        }
    }
}
