using System.ComponentModel;
using System.Configuration;
using bv.common.Configuration;
using bv.common.Core;
using eidss.model.WindowsService;

namespace EIDSS.Reports.Service.WindowsService
{
    [RunInstaller(true)]
    public class ReportServiceInstaller : EidssServiceInstaller
    {
        protected override ServiceConfig GetServiceConfig()
        {
            Configuration conf = ConfigurationManager.OpenExeConfiguration(Utils.GetExecutingPath() + "\\EIDSS.Reports.Service.exe");

            string url = Config.GetFromSettingOrConfiguration(conf, @"ReportServiceHostURL", @"http://localhost:8097/");
            string defautDescr = string.Format(
                @"Service provides reports generation for Electronic Integrated Disease Surveillance System. Reports are accessible calling WCF service with endpoint '{0}'",
                url);

            var result = new ServiceConfig
                {
                    ServiceName = Config.GetFromSettingOrConfiguration(conf, @"ServiceSystemName", @"EIDSSReportsService_v6"),
                    DisplayName =
                        Config.GetFromSettingOrConfiguration(conf, @"ServiceDisplayName", @"EIDSS Reports Service version 6"),
                    Description = Config.GetFromSettingOrConfiguration(conf, @"ServiceDescription", defautDescr)
                };
            return result;
        }
    }
}