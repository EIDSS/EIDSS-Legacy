using System;
using bv.common.Configuration;
using bv.model.BLToolkit;
using eidss.model.Trace;
using eidss.model.WcfService;
using hmis2eidss.service.Scheduler;

namespace hmis2eidss.service.WindowsService
{
    public sealed class HMIS2EIDSSHostKeeper : ServiceHostKeeper
    {
        private SchedulerRunner m_Scheduler;

        protected override string TraceCategory
        {
            get { return TraceHelper.HMIS2EIDSSCategory; }
        }

        protected override void InitServiceHost()
        {
            //base.InitServiceHost();

            m_Scheduler = new SchedulerRunner();
            Trace.TraceInfo(TraceTitle, string.Format(@"HMIS2EIDSS Scheduler started with configuration: {0}{1} ",
                Environment.NewLine, m_Scheduler.Configuration));
            /*
            try
            {
                DatabaseNames names = m_Scheduler.Facade.GetDatabaseName();
                Trace.TraceInfo(TraceTitle, string.Format(@"AVR Service use 
                    EIDSS Database '{0}'
                    EIDSS Archive Database '{1}'
                    AVR Database '{2}'",
                    names.EidssActualDbName, names.EidssArchiveDbName, names.AvrDbName));
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex);
            }
            */
        }

        protected override void OpenExtender()
        {
            m_Scheduler.Start();
            Trace.TraceInfo(TraceTitle, @"Scheduler started.");
        }

        protected override void CloseExtender()
        {
            if (m_Scheduler == null)
            {
                throw new ApplicationException(@"Scheduler already stopped.");
            }

            m_Scheduler.Dispose();
            m_Scheduler = null;

            Trace.TraceInfo(TraceTitle, @"Scheduler stopped.");
        }

        protected override Type ServiceType
        {
            get { throw new NotImplementedException(); }
        }

        protected override string DefaultServiceHostURL
        {
            get { throw new NotImplementedException(); }
        }

        protected override string ServiceHostURLConfigName
        {
            get { throw new NotImplementedException(); }
        }
    }
}