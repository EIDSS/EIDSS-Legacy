using System;
using System.Collections.Generic;
using System.Configuration;
using eidss.avr.db.DBService;
using EIDSS.AVR.Service.WcfFacade;
using eidss.model.Core;
using eidss.model.Trace;
using eidss.model.WindowsService;

namespace EIDSS.AVR.Service.Scheduler
{
    public class SchedulerConfigurationStrategy : ISchedulerConfigurationStrategy
    {
        private static readonly TraceHelper m_Trace = new TraceHelper(TraceHelper.AVRCategory);

        public IAVRFacade GetAVRFacade()
        {
            try
            {
                return new AVRFacade();
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
    }
}