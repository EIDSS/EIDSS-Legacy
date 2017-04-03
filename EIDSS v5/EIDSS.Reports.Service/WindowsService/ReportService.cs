using System;
using System.ServiceProcess;
using EIDSS.Reports.Service.WcfService;

namespace EIDSS.Reports.Service.WindowsService
{
    internal class ReportService : ServiceBase
    {
        private HostKeeper m_HostKeeper;
        private const string TraceTitle = "Windows Service";

        protected override void OnStart(string[] args)
        {
            try
            {
             //   throw new ApplicationException("xxx");
                base.OnStart(args);
                m_HostKeeper = new HostKeeper();
                m_HostKeeper.Open();

                m_HostKeeper.Trace.TraceInfo(TraceTitle, "Reports Service Started.");
            }
            catch (Exception ex)
            {
                m_HostKeeper.Trace.TraceCritical(ex);
                throw;
            }
        }

        protected override void OnStop()
        {
            try
            {
                m_HostKeeper.Close();
                m_HostKeeper.Trace.TraceInfo(TraceTitle, "Reports Service Stopped.");
            }
            catch (Exception ex)
            {
                m_HostKeeper.Trace.TraceCritical(ex);
                throw;
            }
        }
    }
}