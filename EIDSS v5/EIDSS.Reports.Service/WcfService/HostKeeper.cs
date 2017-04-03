using System;
using System.Configuration;
using System.ServiceModel;
using EIDSS.Reports.Service.Trace;
using EIDSS.Reports.Service.WcfFacade;
using bv.common.Configuration;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.model.Model.Validators;
using eidss.model.Core;
using eidss.model.Core.Security;
using eidss.model.Resources;

namespace EIDSS.Reports.Service.WcfService
{
    public class HostKeeper : IDisposable
    {
        private ServiceHost m_Host;
        private readonly TraceHelper m_Trace = new TraceHelper();
        private const string TraceTitle = @"WCF Service Host";

        public HostKeeper()
        {
            try
            {
                InitEidssLibs();

                DataBaseChecker.CheckDbConnection();

                InitServiceHost();
            }
            catch (Exception ex)
            {
                m_Trace.TraceCritical(ex);
                throw;
            }
        }

        private void InitEidssLibs()
        {
            DbManagerFactory.SetSqlFactory(new ConnectionCredentials().ConnectionString);
            EidssUserContext.Init();

            ClassLoader.Init("bv_common.dll", null);
            ClassLoader.Init("bvwin_common.dll", null);
            ClassLoader.Init("bv.common.dll", null);
            ClassLoader.Init("bv.winclient.dll", null);
            ClassLoader.Init("eidss*.dll", null);
            Localizer.MenuMessages = EidssMenu.Instance;
            BaseFieldValidator.FieldCaptions = EidssFields.Instance;
            EIDSS_LookupCacheHelper.Init();
            m_Trace.Trace(TraceTitle, "EIDSS dlls initialized.");
        }

       

        private void InitServiceHost()
        {

            string url = Config.GetSetting("ReportServiceHostURL", "http://localhost:8098/");
            if (string.IsNullOrEmpty(url))
            {
                throw new ApplicationException(@"""ReportServiceHostURL"" parameter not congigured in AppSettings section.");
            }

            m_Host = new ServiceHost(typeof (ReportFacade), new Uri(url));

            m_Trace.TraceInfo(TraceTitle, string.Format(@"Service Host Configured at URL {0}", url));
        }

        public TraceHelper Trace
        {
            get { return m_Trace; }
        }

        public void Open()
        {
            m_Host.Open();
            m_Trace.TraceInfo(TraceTitle, @"Service Host Opened");
        }

        public void Close()
        {
            if (m_Host == null)
            {
                throw new ApplicationException(@"Service host already closed.");
            }

            m_Host.Close();
            m_Host = null;

            m_Trace.TraceInfo(TraceTitle, @"Service Host Closed");
        }

        public void Dispose()
        {
            if ((m_Host != null) && (m_Host.State == CommunicationState.Opened))
            {
                Close();
            }
        }
    }
}