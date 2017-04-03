using System;
using bv.common.Configuration;
using eidss.mobileclient.MobileReportService;

namespace eidss.mobileclient.Utils
{
    public class ReportClientWrapper : IDisposable
    {
        private readonly ReportFacadeClient m_Client;

        public ReportClientWrapper()
        {
            string address = Config.GetSetting("ReportServiceHostURL", "http://localhost:8097/");
            m_Client = new ReportFacadeClient("BasicHttpBinding_IReportFacade", address);
        }

        public ReportFacadeClient Client
        {
            get { return m_Client; }
        }

        public void Dispose()
        {
            m_Client.Close();
        }
    }
}
