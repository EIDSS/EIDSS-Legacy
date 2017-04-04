using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using bv.common.Configuration;
using bv.common.Core;
using eidss.model.Trace;
using eidss.model.WindowsService;
using hmis2eidss.service.Import;
using hmis2eidss.service.Scheduler;

namespace hmis2eidss.service.Scheduler
{
    public class SchedulerRunner : IDisposable
    {

        private const string TraceTitle = "hmis2eidss";
        private readonly object m_SyncLock = new object();
        private static readonly TraceHelper m_Trace = new TraceHelper(TraceHelper.HMIS2EIDSSCategory);
        private readonly TimeSpan m_DisposeTimeout = new TimeSpan(0, 0, 5, 0);
        private readonly TimeSpan m_InfiniteTimeout = new TimeSpan(0, 0, 0, 0, -1);
        private readonly Stopwatch m_Watch;

        /*private IAVRFacade m_Facade;*/
        private SchedulerConfigurationSection m_Configuration;
        /*private IList<string> m_Languages;*/
        private readonly Timer m_Timer;
        private volatile bool m_Disposing;
        private readonly AutoResetEvent m_AutoEvent;
        private bool m_IsNotFirstRun;
        
        private readonly SchedulerConfigurationStrategy m_ConfigurationStrategy;

        public SchedulerRunner() : this(new SchedulerConfigurationStrategy())
        {
        }

        public SchedulerRunner(SchedulerConfigurationStrategy configurationStrategy)
        {
            Utils.CheckNotNull(configurationStrategy, "configurationStrategy");
            m_ConfigurationStrategy = configurationStrategy;

            m_AutoEvent = new AutoResetEvent(false);
            m_Watch = new Stopwatch();
            m_Timer = new Timer(TimerTick, null, Timeout.Infinite, Timeout.Infinite);
        }

        public SchedulerConfigurationSection Configuration
        {
            get { return m_Configuration ?? (m_Configuration = m_ConfigurationStrategy.GetConfigurationSection()); }
        }

        public void Start()
        {
            m_Timer.Change(0, Timeout.Infinite);
        }

        internal void TimerTick(object stateInfo)
        {
            lock (m_SyncLock)
            {
                try
                {
                    if (SetAutoEventIfDisposing() || !Configuration.SchedulerEnabled)
                    {
                        return;
                    }

                    var dateNow = DateTime.Now;
                    var delta = new TimeSpan(1, -dateNow.Hour, -dateNow.Minute, -dateNow.Second);
                    var timeout = /*DateTime.Today + Configuration.TimeOfSchedulerRuns > dateNow
                        ? DateTime.Today + Configuration.TimeOfSchedulerRuns - dateNow
                        :*/ Configuration.TimeOfSchedulerRuns + delta;

                    m_Timer.Change(timeout, m_InfiniteTimeout);
                    m_Trace.TraceInfo(TraceTitle, "Next start in {0} ({1})", dateNow + timeout, timeout);

                    RunJob();
                }
                catch (Exception ex)
                {
                    m_Trace.TraceError(ex);
                }
            }
        }
        
        private void RunJob()
        {
            if (m_IsNotFirstRun || Configuration.ImmediatelyRunScheduler)
            {
                Hmis2EidssImport.Import(m_Trace);
            }
            m_IsNotFirstRun = true;
        }

        private bool SetAutoEventIfDisposing()
        {
            if (m_Disposing)
            {
                m_AutoEvent.Set();
                return true;
            }
            return false;
        }

        private void TraceStartJob(IEnumerable<long> queryIdList, IEnumerable<string> languages)
        {
            string ids = queryIdList.Aggregate(string.Empty, (current, id) => current + id + ", ");
            string langs = languages.Aggregate(string.Empty, (current, lang) => current + lang + ", ");

            m_Trace.TraceInfo(TraceTitle, "Start refresh queries {0} for languages {1}", ids, langs);
        }

        private void TraceEndJob(IEnumerable<long> queryIdList, IEnumerable<string> languages)
        {
            string ids = queryIdList.Aggregate(string.Empty, (current, id) => current + id + ", ");
            string langs = languages.Aggregate(string.Empty, (current, lang) => current + lang + ", ");
            m_Trace.TraceInfo(TraceTitle, "End refresh queries {0} for languages {1}", ids, langs);
        }

        private void TraceStartRefreshQuery(long queryId, string language)
        {
            m_Trace.TraceInfo(TraceTitle, "Start refresh query {0} for language {1}", queryId, language);
            m_Watch.Start();
        }

        private void TraceEndRefreshQuery(long queryId, string language)
        {
            m_Watch.Stop();
            m_Trace.TraceInfo(TraceTitle, "End refresh query {0} for language {1}{2}Elapsed Milliseconds: {3:N0}",
                queryId, language, Environment.NewLine, m_Watch.ElapsedMilliseconds);
            m_Watch.Reset();
        }

        private void TraceWaiting()
        {
            m_Trace.Trace(TraceTitle, "Waiting for {0} seconds before executing next query...",
                Configuration.SecondsBetweenSchedulerTasks);
        }
        
        public void Dispose()
        {
            if (!m_Disposing)
            {
                m_Disposing = true;

                lock (m_SyncLock)
                {
                    m_Timer.Change(0, Timeout.Infinite);
                }

                m_AutoEvent.WaitOne(m_DisposeTimeout);
                m_Timer.Dispose();
            }
        }
    }
}