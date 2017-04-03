using System;
using System.Runtime.Serialization;

namespace bv.common.Core
{
    public class AvrException : ApplicationException
    {
        public AvrException()
        {
        }

        public AvrException(string message) : base(message)
        {
        }

        public AvrException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AvrException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}