using System;
using System.Collections.Generic;
using System.Configuration;
using EIDSS.AVR.Service.WcfFacade;
using eidss.model.Core;
using eidss.model.Trace;
using eidss.model.WindowsService;
using StructureMap;

namespace EIDSS.AVR.Service.Scheduler
{
    public class SchedulerConfigurationStrategy : ISchedulerConfigurationStrategy
    {
        private static readonly TraceHelper m_Trace = new TraceHelper(TraceHelper.AVRCategory);

        public IAVRFacade GetAVRFacade(IContainer container)
        {
            try
            {
                return new AVRFacade(container);
            }
            catch (Exception ex)
            {
                m_Trace.TraceError(ex, "Couldn't initialize AVR Facade.");
                throw;
            }
        }

        public SchedulerConfigurationSection GetConfigurationSection()
        {
            try
            {
                var section = (SchedulerConfigurationSection) ConfigurationManager.GetSection("schedulerConfiguration");
                if (section == null)
                {
                    throw new AVRConfigurationException("Couldn't find schedulerConfiguration section");
                }
                return section;
            }
            catch (Exception ex)
            {
                m_Trace.TraceError(ex, "Couldn't load schedulerConfiguration section from config");
                throw;
            }
        }

        public IList<string> GetLanguages()
        {
            try
            {
                return LanguageDbLoader.GetLanguages();
            }
            catch (Exception ex)
            {
                m_Trace.TraceError(ex, "Couldn't load supported languages from database.");
                throw;
            }
        }

        public string GetServiceDisplayName()
        {
            try
            {
                return ConfigurationManager.AppSettings.Get("AVRServiceDisplayName");
            }
            catch (Exception ex)
            {
                m_Trace.TraceError(ex, "Couldn't load AVRServiceDisplayName from config.");
                throw;
            }
        }
    }
}