using System.ComponentModel;
using System.Configuration;
using bv.common.Configuration;
using bv.common.Core;
using eidss.model.WindowsService;

namespace EIDSS.AVR.Service.WindowsService
{
    [RunInstaller(true)]
    public class AVRServiceInstaller : EidssServiceInstaller
    {
        protected override ServiceConfig GetServiceConfig()
        {
            Configuration conf = ConfigurationManager.OpenExeConfiguration(Utils.GetExecutingPath() + "\\EIDSS.AVR.Service.exe");

            string url = Config.GetFromSettingOrConfiguration(conf, @"AVRServiceHostURL", @"http://localhost:8071/");
            string defautDescr = string.Format(
                @"Service provides reports generation for Electronic Integrated Disease Surveillance System. Reports are accessible calling WCF service with endpoint '{0}'",
                url);

            var result = new ServiceConfig
                {
                    ServiceName = Config.GetFromSettingOrConfiguration(conf, @"AVRServiceSystemName", @"EIDSSAVRService_v6"),
                    DisplayName =
                        Config.GetFromSettingOrConfiguration(conf, @"SAVRerviceDisplayName", @"EIDSS AVR Service version 6"),
                    Description = Config.GetFromSettingOrConfiguration(conf, @"AVRServiceDescription", defautDescr)
                };
            return result;
        }
    }
}