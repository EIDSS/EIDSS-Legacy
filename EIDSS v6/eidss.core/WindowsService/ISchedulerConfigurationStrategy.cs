using System.Collections.Generic;

namespace eidss.model.WindowsService
{
    public interface ISchedulerConfigurationStrategy
    {
        IAVRFacade GetAVRFacade();
        SchedulerConfigurationSection GetConfigurationSection();
        IList<string> GetLanguages();
    }
}