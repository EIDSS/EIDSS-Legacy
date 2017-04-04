using System.Collections.Generic;
using StructureMap;

namespace eidss.model.WindowsService
{
    public interface ISchedulerConfigurationStrategy
    {
        IAVRFacade GetAVRFacade(IContainer container);
        SchedulerConfigurationSection GetConfigurationSection();
        IList<string> GetLanguages();
        string GetServiceDisplayName();

    }
}