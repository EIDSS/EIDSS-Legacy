using System;
using System.Configuration;

namespace eidss.model.WindowsService
{
    public class SchedulerConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("schedulerEnabled", IsRequired = false, DefaultValue = true)]
        public bool SchedulerEnabled
        {
            get { return (bool) this["schedulerEnabled"]; }
            set { this["schedulerEnabled"] = value; }
        }

        [ConfigurationProperty("immediatelyRunSchedulerWhenServiceStarts", IsRequired = false, DefaultValue = false)]
        public bool ImmediatelyRunScheduler
        {
            get { return (bool) this["immediatelyRunSchedulerWhenServiceStarts"]; }
            set { this["immediatelyRunSchedulerWhenServiceStarts"] = value; }
        }

        [ConfigurationProperty("daysBetweenSchedulerRuns", IsRequired = false, DefaultValue = 1)]
        public int DaysBetweenSchedulerRuns
        {
            get { return (int) this["daysBetweenSchedulerRuns"]; }
            set { this["daysBetweenSchedulerRuns"] = value; }
        }

        [ConfigurationProperty("timeOfSchedulerRuns", IsRequired = true)]
        public TimeSpan TimeOfSchedulerRuns
        {
            get { return (TimeSpan) this["timeOfSchedulerRuns"]; }
            set { this["timeOfSchedulerRuns"] = value; }
        }

        [ConfigurationProperty("secondsBetweenSchedulerTasks", IsRequired = false, DefaultValue = 10 * 60)]
        public int SecondsBetweenSchedulerTasks
        {
            get { return (int) this["secondsBetweenSchedulerTasks"]; }
            set { this["secondsBetweenSchedulerTasks"] = value; }
        }

        [ConfigurationProperty("refreshedCacheOnUserCallAfterDays", IsRequired = false, DefaultValue = 7)]
        public int RefreshedCacheOnUserCallAfterDays
        {
            get { return (int) this["refreshedCacheOnUserCallAfterDays"]; }
            set { this["refreshedCacheOnUserCallAfterDays"] = value; }
        }

        [ConfigurationProperty("dontRefreshCacheNotUsedByUserAfterDays", IsRequired = false, DefaultValue = 30)]
        public int DontRefreshCacheNotUsedByUserAfterDays
        {
            get { return (int) this["dontRefreshCacheNotUsedByUserAfterDays"]; }
            set { this["dontRefreshCacheNotUsedByUserAfterDays"] = value; }
        }

        public override string ToString()
        {
            return string.Format(
                @"schedulerEnabled={0}, 
                        timeOfSchedulerRuns={1}, 
                        immediatelyRunSchedulerWhenServiceStarts={2}, 
                        secondsBetweenSchedulerTasks={3} sec",
                SchedulerEnabled, TimeOfSchedulerRuns, ImmediatelyRunScheduler, SecondsBetweenSchedulerTasks);
        }
    }
}