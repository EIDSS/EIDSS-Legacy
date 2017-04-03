using System;
using System.ServiceModel;
using System.Text;
using System.Web.Mvc;
using System.Xml;
using bv.common.Configuration;
using eidss.webclient.ReportService;

namespace eidss.webclient.Utils
{
    public class ReportClientWrapper : IDisposable
    {
        private readonly ReportFacadeClient m_Client;

        public ReportClientWrapper()
        {
            var address = new EndpointAddress(Config.GetSetting("ReportServiceHostURL", "http://localhost:8097/"));
            m_Client = bv.common.Core.Utils.IsCalledFromUnitTest()
                           ? new ReportFacadeClient(CreateTestBinding(), address)
                           : new ReportFacadeClient("BasicHttpBinding_IReportFacade", address);

            
        }

        public ReportFacadeClient Client
        {
            get { return m_Client; }
        }

        public void Dispose()
        {
            m_Client.Close();
        }

        private BasicHttpBinding CreateTestBinding()
        {
            var binding = new BasicHttpBinding
                              {
                                  Name = "BasicHttpBinding_IReportFacade",
                                  CloseTimeout = new TimeSpan(0, 3, 0),
                                  OpenTimeout = new TimeSpan(0, 3, 0),
                                  ReceiveTimeout = new TimeSpan(0, 10, 0),
                                  SendTimeout = new TimeSpan(0, 3, 0),
                                  MaxBufferSize = 2147483647,
                                  MaxBufferPoolSize = 2147483647,
                                  MaxReceivedMessageSize = 2147483647,
                                  TextEncoding = Encoding.UTF8,
                                  TransferMode = TransferMode.Buffered,
                                  UseDefaultWebProxy = true,
                                  ReaderQuotas = new XmlDictionaryReaderQuotas
                                                     {
                                                         MaxDepth = 32,
                                                         MaxStringContentLength = 2147483647,
                                                         MaxArrayLength = 2147483647,
                                                         MaxBytesPerRead = 2147483647,
                                                         MaxNameTableCharCount = 2147483647,
                                                     },
                              };
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
            return binding;
        }
    }
}
