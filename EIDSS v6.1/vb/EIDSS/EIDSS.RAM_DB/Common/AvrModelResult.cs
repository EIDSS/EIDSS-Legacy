using System;

namespace eidss.avr.db.Common
{
    public abstract class AvrModelResult<T>
    {
        protected AvrModelResult(T model)
        {
            Model = model;
            IsOk = true;
        }

        protected AvrModelResult(string errorMessage, Exception innerException = null)
        {
            ErrorMessage = errorMessage;
            InnerException = innerException;
            IsOk = false;
        }

        public T Model { get; protected set; }
        public bool IsOk { get; protected set; }
        public string ErrorMessage { get; protected set; }
        public Exception InnerException { get; protected set; }
    }
}