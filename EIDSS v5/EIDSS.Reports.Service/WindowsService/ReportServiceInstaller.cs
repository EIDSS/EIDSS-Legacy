using System.ComponentModel;
using System.Configuration;
using System.Configuration.Install;
using System.ServiceProcess;
using bv.common.Configuration;
using bv.common.Core;

namespace EIDSS.Reports.Service.WindowsService
{
    [RunInstaller(true)]
    public class ReportServiceInstaller : Installer
    {
        private readonly string m_ServiceName;

        public ReportServiceInstaller()
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(Utils.GetExecutingPath() + "\\EIDSS.Reports.Service.exe");

            string url = GetConfigValue(configuration, @"ReportServiceHostURL", @"http://localhost:8098/");

            m_ServiceName = GetConfigValue(configuration, @"ServiceSystemName", @"EIDSSReportsService_v5");

            string displayName = GetConfigValue(configuration, @"ServiceDisplayName", @"EIDSS Reports Service version 5");

            string defautDescr = string.Format(@"Service provides reports generation for Electronic Integrated Disease Surveillance System. Reports are accessible calling WCF service with endpoint '{0}'",url);
            string description = GetConfigValue(configuration, @"ServiceDescription", defautDescr);

            var process = new ServiceProcessInstaller {Account = ServiceAccount.LocalSystem};

            var service = new ServiceInstaller
                              {
                                  ServiceName = m_ServiceName,
                                  DisplayName = displayName,
                                  Description = description,
                                  StartType = ServiceStartMode.Automatic
                              };

            Installers.Add(process);
            Installers.Add(service);
            Committed += ReportServiceInstaller_Committed;
        }

        private void ReportServiceInstaller_Committed(object sender, InstallEventArgs e)
        {
            // Auto Start the Service Once Installation is Finished.
            var controller = new ServiceController(m_ServiceName);
            controller.Start();
        }

        private static string GetConfigValue(Configuration configuration, string key, string defaultValue)
        {
            string result = defaultValue;
            string generalValue = Config.GetSetting(key);
            if (!Utils.IsEmpty(generalValue))
            {
                result = generalValue;
            }
            else
            {
                KeyValueConfigurationElement hostElement = configuration.AppSettings.Settings[key];
                if (hostElement != null && !Utils.IsEmpty(hostElement.Value))
                {
                    result = hostElement.Value;
                }
            }
            return result;
        }
    }
}
