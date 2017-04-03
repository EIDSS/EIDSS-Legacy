using System;

namespace EIDSS.Reports.Service.WcfFacade
{
    public class ReportDataException : ApplicationException
    {
        public ReportDataException()
        {
        }

        public ReportDataException(string message) : base(message)
        {
        }

        public ReportDataException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}