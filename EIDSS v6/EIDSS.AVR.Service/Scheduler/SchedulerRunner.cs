using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using bv.common.Configuration;
using bv.common.Core;
using eidss.model.Trace;
using eidss.model.WindowsService;

namespace EIDSS.AVR.Service.Scheduler
{
    public class SchedulerRunner : IDisposable
    {
        private const string TraceTitle = "Refresh AVR Queries";
        private readonly object m_SyncLock = new object();
        private static readonly TraceHelper m_Trace = new TraceHelper(TraceHelper.AVRCategory);
        private readonly TimeSpan m_DisposeTimeout = new TimeSpan(0, 0, 5, 0);
        private readonly TimeSpan m_InfiniteTimeout = new TimeSpan(0, 0, 0, 0, -1);
        private readonly Stopwatch m_Watch;

        private IAVRFacade m_Facade;
        private SchedulerConfigurationSection m_Configuration;
        private IList<string> m_Languages;
        private readonly Timer m_Timer;
        private volatile bool m_Disposing;
        private readonly AutoResetEvent m_AutoEvent;
        private bool m_IsNotFirstRun;

        private readonly ISchedulerConfigurationStrategy m_ConfigurationStrategy;

        public SchedulerRunner() : this(new SchedulerConfigurationStrategy())
        {
        }

        public SchedulerRunner(ISchedulerConfigurationStrategy configurationStrategy)
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

        public IAVRFacade Facade
        {
            get { return m_Facade ?? (m_Facade = m_ConfigurationStrategy.GetAVRFacade()); }
        }

        public IList<string> Languages
        {
            get { return m_Languages ?? (m_Languages = m_ConfigurationStrategy.GetLanguages()); }
        }

        public static TraceHelper Trace
        {
            get { return m_Trace; }
        }

        public static bool UseArchiveData
        {
            get
            {
                var credentials = new ConnectionCredentials(null, "Archive");
                return credentials.IsCorrect;
            }
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

                    var days = Configuration.DaysBetweenSchedulerRuns;
                    if (days < 1) days = 1;
                    DateTime dateNow = DateTime.Now;
                    var delta = new TimeSpan(days, -dateNow.Hour, -dateNow.Minute, -dateNow.Second);

                    m_Timer.Change(Configuration.TimeOfSchedulerRuns + delta, m_InfiniteTimeout);

                    RunAllQueriesRefreshJob();
                }
                catch (Exception ex)
                {
                    m_Trace.TraceError(ex);
                }
            }
        }

        private void RunAllQueriesRefreshJob()
        {
            if (m_IsNotFirstRun || Configuration.ImmediatelyRunScheduler)
            {
                List<long> queryIdList = Facade.GetQueryIdList();

                TraceStartJob(queryIdList, Languages);

                foreach (long queryId in queryIdList)
                {
                    try
                    {
                        var userRequestDate = Facade.GetsQueryCacheUserRequestDate(queryId);
                        var dateSplitter = DateTime.Now.AddDays(-Configuration.DontRefreshCacheNotUsedByUserAfterDays);
                        if (userRequestDate.HasValue && userRequestDate.Value > dateSplitter)
                        {
                            foreach (string language in Languages)
                            {
                                TraceStartRefreshQuery(queryId, language);
                                Facade.RefreshCachedQueryTableByScheduler(queryId, language, UseArchiveData);
                                Facade.DeleteQueryCacheForLanguage(queryId, language, true);
                                TraceEndRefreshQuery(queryId, language);

                                if (SetAutoEventIfDisposing())
                                {
                                    return;
                                }

                                TraceWaiting();
                                for (int i = 0; i < Configuration.SecondsBetweenSchedulerTasks; i++)
                                {
                                    Thread.Sleep(1000);
                                    if (SetAutoEventIfDisposing())
                                    {
                                        return;
                                    }
                                }
                            }
                        }
                        else
                        {
                            TraceQueryNoRequestedByUser(queryId);
                            foreach (string language in Languages)
                            {
                                if (SetAutoEventIfDisposing())
                                {
                                    return;
                                }
                                Facade.InvalidateQueryCacheForLanguage(queryId, language);
                                Facade.DeleteQueryCacheForLanguage(queryId, language, false);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        m_Trace.TraceError(ex);
                    }
                }
                TraceEndJob(queryIdList, Languages);
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
      
        private void TraceQueryNoRequestedByUser(long queryId)
        {
         
            m_Trace.TraceInfo(TraceTitle, "Skipped refresh of query {0} because it never have been requested by user. ",queryId);
         
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