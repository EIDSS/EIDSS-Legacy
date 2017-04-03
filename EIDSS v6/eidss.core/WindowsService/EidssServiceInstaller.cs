using System.Configuration.Install;
using System.ServiceProcess;

namespace eidss.model.WindowsService
{
    public abstract class EidssServiceInstaller : Installer
    {
        private ServiceConfig m_ServiceConfig;

        protected EidssServiceInstaller()
        {
            Initialize();
        }

        protected virtual ServiceConfig ServiceConfig
        {
            get { return m_ServiceConfig ?? (m_ServiceConfig = GetServiceConfig()); }
        }

        protected abstract ServiceConfig GetServiceConfig();

        private void Initialize()
        {
            var process = new ServiceProcessInstaller {Account = ServiceAccount.LocalSystem};

            var service = new ServiceInstaller
                {
                    ServiceName = ServiceConfig.ServiceName,
                    DisplayName = ServiceConfig.DisplayName,
                    Description = ServiceConfig.Description,
                    StartType = ServiceStartMode.Automatic
                };

            Installers.Add(process);
            Installers.Add(service);
            Committed += ReportServiceInstaller_Committed;
        }

        private void ReportServiceInstaller_Committed(object sender, InstallEventArgs e)
        {
            // Auto Start the Service Once Installation is Finished.
            var controller = new ServiceController(ServiceConfig.ServiceName);
            controller.Start();
        }

        
    }
}