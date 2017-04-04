using System;
using System.Runtime.Serialization;

namespace eidss.model.WindowsService.Serialization
{
    public class CustomSerializationException : ApplicationException
    {
        public CustomSerializationException()
        {
        }

        public CustomSerializationException(string message) : base(message)
        {
        }

        public CustomSerializationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CustomSerializationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}