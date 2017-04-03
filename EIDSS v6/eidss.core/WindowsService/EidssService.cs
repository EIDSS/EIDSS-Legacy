using System;
using System.ServiceProcess;
using eidss.model.Trace;
using eidss.model.WcfService;

namespace eidss.model.WindowsService
{
    public class EidssService : ServiceBase
    {
        private ServiceHostKeeper m_HostKeeper;
        private readonly Func<ServiceHostKeeper> m_HostKeeperCreator;
        private const string TraceTitle = "EIDSS Windows Service";
        private readonly TraceHelper m_Trace;

        public EidssService(Func<ServiceHostKeeper> hostKeeperCreator, string traceCategory)
        {
            m_HostKeeperCreator = hostKeeperCreator;
            m_Trace = new TraceHelper(traceCategory);
        }

        public void RunInConsole()
        {
            try
            {
                using (ServiceHostKeeper hostKeeper = m_HostKeeperCreator())
                {
                    //throw new ApplicationException("xxx");
                    hostKeeper.Open();
                    m_Trace.TraceInfo(TraceTitle, @"Press Enter to stop Service.");
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                m_Trace.TraceError(ex);
                Console.ReadLine();
            }
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                base.OnStart(args);
                m_HostKeeper = m_HostKeeperCreator();
                m_HostKeeper.Open();

                m_Trace.TraceInfo(TraceTitle, "Reports Service Started.");
            }
            catch (Exception ex)
            {
                m_Trace.TraceCritical(ex);
                throw;
            }
        }

        protected override void OnStop()
        {
            try
            {
                m_HostKeeper.Close();
                m_Trace.TraceInfo(TraceTitle, "Reports Service Stopped.");
            }
            catch (Exception ex)
            {
                m_Trace.TraceCritical(ex);
                throw;
            }
        }
    }
}