using System;

namespace EIDSS.AVR.Service.Scheduler
{
    public class AVRConfigurationException : ApplicationException
    {
        public AVRConfigurationException()
        {
        }

        public AVRConfigurationException(string message) : base(message)
        {
        }

        public AVRConfigurationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}