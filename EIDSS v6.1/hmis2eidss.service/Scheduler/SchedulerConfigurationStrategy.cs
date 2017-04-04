using System;
using System.Collections.Generic;
using System.Configuration;
using eidss.model.Trace;
using eidss.model.WindowsService;

namespace hmis2eidss.service.Scheduler
{
    public class SchedulerConfigurationStrategy //: ISchedulerConfigurationStrategy
    {
        private static readonly TraceHelper m_Trace = new TraceHelper(TraceHelper.HMIS2EIDSSCategory);

        /*public IAVRFacade GetAVRFacade()
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
        }*/

        public SchedulerConfigurationSection GetConfigurationSection()
        {
            try
            {
                // todo: [ivan] reload config
                var section = (SchedulerConfigurationSection) ConfigurationManager.GetSection("schedulerConfiguration");
                if (section == null)
                {
                    throw new HMIS2EIDSSConfigurationException("Couldn't find schedulerConfiguration section");
                }
                return section;
            }
            catch (Exception ex)
            {
                m_Trace.TraceError(ex, "Couldn't load schedulerConfiguration section from config");
                throw;
            }
        }

        /*public IList<string> GetLanguages()
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
        }*/
    }
}