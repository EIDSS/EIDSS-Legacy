using System;
using System.Runtime.Serialization;

namespace eidss.model.AVR.Db
{
    [Serializable]
    public class AvrDbException : ApplicationException

    {
        public AvrDbException()
        {
        }

        public AvrDbException(string message) : base(message)
        {
        }

        public AvrDbException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AvrDbException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}