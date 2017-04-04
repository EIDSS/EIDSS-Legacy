using System;
using System.ServiceModel;
using bv.common.Configuration;
using eidss.model.Trace;

namespace eidss.model.WcfService
{
    public abstract class ServiceHostKeeper : IDisposable
    {
        private bool m_IsInitialized;
        private ServiceHost m_Host;
        private bool m_HostExists;
        private TraceHelper m_Trace;
        protected const string TraceTitle = @"WCF Service Host";

        protected abstract Type ServiceType { get; }
        protected abstract string DefaultServiceHostURL { get; }
        protected abstract string ServiceHostURLConfigName { get; }
        protected abstract string TraceCategory { get; }

        protected TraceHelper Trace
        {
            get { return m_Trace ?? (m_Trace = new TraceHelper(TraceCategory)); }
        }

        public string CurrentServiceHostURL { get;protected set; }

        public void Open()
        {
            Initialize();

            if (m_HostExists)
            {
                m_Host.Open();
            }

            Trace.TraceInfo(TraceTitle, @"Service Host Opened");

            OpenExtender();
        }

        public void Close()
        {
            if (m_HostExists && m_Host == null)
            {
                throw new ApplicationException(@"Service host already closed.");
            }

            if (m_HostExists)
            {
                m_Host.Close();
            }

            m_Host = null;

            Trace.TraceInfo(TraceTitle, @"Service Host Closed");

            CloseExtender();
        }

        public void Dispose()
        {
            if ((m_Host != null) && (m_Host.State == CommunicationState.Opened))
            {
                Close();
            }
        }

        private void Initialize()
        {
            if (!m_IsInitialized)
            {
                try
                {
                    InitEidssCore();
                    Trace.Trace(TraceTitle, "EIDSS core initialized.");

                    DataBaseChecker.CheckDbConnection();

                    InitServiceHost();
                }
                catch (Exception ex)
                {
                    Trace.TraceCritical(ex);
                    throw;
                }
                m_IsInitialized = true;
            }
        }

        protected virtual void OpenExtender()
        {
        }

        protected virtual void CloseExtender()
        {
        }

        protected virtual void InitEidssCore()
        {
            EidssServiceInitializer.InitEidssCore();
        }

        protected virtual void  CalculateServiceURL()
        {
            string url = Config.GetSetting(ServiceHostURLConfigName, DefaultServiceHostURL);
            if (string.IsNullOrEmpty(url))
            {
                string message = string.Format(@"'{0}' parameter not congigured in AppSettings section.", ServiceHostURLConfigName);
                throw new ApplicationException(message);
            }
            CurrentServiceHostURL = url;
        }

        protected virtual void InitServiceHost()
        {
            CalculateServiceURL();
            
            m_Host = new ServiceHost(ServiceType, new Uri(CurrentServiceHostURL));
            m_HostExists = true;

            Trace.TraceInfo(TraceTitle, string.Format(@"Service Host Configured at URL {0}", CurrentServiceHostURL));
        }
    }
}