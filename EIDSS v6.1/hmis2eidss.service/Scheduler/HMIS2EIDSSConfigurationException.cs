using System;

namespace hmis2eidss.service.Scheduler
{
    public class HMIS2EIDSSConfigurationException : ApplicationException
    {
        public HMIS2EIDSSConfigurationException()
        {
        }

        public HMIS2EIDSSConfigurationException(string message) : base(message)
        {
        }

        public HMIS2EIDSSConfigurationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}