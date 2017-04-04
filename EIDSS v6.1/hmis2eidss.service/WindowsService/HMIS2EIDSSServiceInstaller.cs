using System.ComponentModel;
using System.Configuration;
using bv.common.Configuration;
using bv.common.Core;
using eidss.model.WindowsService;

namespace hmis2eidss.service.WindowsService
{
    [RunInstaller(true)]
    public class HMIS2EIDSSServiceInstaller : EidssServiceInstaller
    {
        protected override ServiceConfig GetServiceConfig()
        {
            Configuration conf = ConfigurationManager.OpenExeConfiguration(Utils.GetExecutingPath() + "\\hmis2eidss.service.exe");

            var result = new ServiceConfig
                {
                    ServiceName = Config.GetFromSettingOrConfiguration(conf, @"HMIS2EIDSSServiceSystemName", @"HMIS2EIDSSService_v6"),
                    DisplayName =
                        Config.GetFromSettingOrConfiguration(conf, @"HMIS2EIDSSServiceDisplayName", @"HMIS To EIDSS Service version 6"),
                    Description = Config.GetFromSettingOrConfiguration(conf, @"HMIS2EIDSSServiceDescription", @"Service for transmission data from HMIS To EIDSS version 6")
                };
            return result;
        }
    }
}