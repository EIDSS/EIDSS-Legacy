using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using bv.common.Core;
using bv.model.BLToolkit;
using eidss.model.Helpers;
using eidss.model.Schema;
using eidss.model.Trace;
using eidss.model.WindowsService;
using EIDSS.AVR.Service.WcfFacade;
using StructureMap;

namespace EIDSS.AVR.Service.Scheduler
{
    public class SchedulerRunner : IDisposable
    {
        private readonly string m_TraceTitle;
        private readonly object m_SyncLock = new object();
        private static readonly TraceHelper m_Trace = new TraceHelper(TraceHelper.AVRCategory);
        private readonly TimeSpan m_DisposeTimeout = new TimeSpan(0, 0, 5, 0);
        private readonly TimeSpan m_InfiniteTimeout = new TimeSpan(0, 0, 0, 0, -1);
        private readonly Stopwatch m_Watch;

        private IAVRFacade m_Facade;
        private SchedulerConfigurationSection m_Configuration;
        private IList<string> m_Languages;
        private readonly Timer m_QueryRefreshTimer;
        private readonly Timer m_LookupCasheRefreshTimer;
        private volatile bool m_Disposing;
        private readonly AutoResetEvent m_AutoEvent;
        private bool m_IsNotFirstRun;

        private readonly ISchedulerConfigurationStrategy m_ConfigurationStrategy;
        private readonly IContainer m_Container;

       
        public SchedulerRunner(IContainer container)
        {
            Utils.CheckNotNull(container, "container");
            m_Container = container;

            m_ConfigurationStrategy = container.GetInstance<ISchedulerConfigurationStrategy>();

            m_TraceTitle = string.Format("[{0}] Refresh AVR Queries", m_ConfigurationStrategy.GetServiceDisplayName());

            m_AutoEvent = new AutoResetEvent(false);
            m_Watch = new Stopwatch();
            m_QueryRefreshTimer = new Timer(QueryRefreshTimerTick, null, Timeout.Infinite, Timeout.Infinite);
            m_LookupCasheRefreshTimer = new Timer(LookupCasheRefreshTimerTick, null, Timeout.Infinite, Timeout.Infinite);
        }

        public SchedulerConfigurationSection Configuration
        {
            get { return m_Configuration ?? (m_Configuration = m_ConfigurationStrategy.GetConfigurationSection()); }
        }

        public IAVRFacade Facade
        {
            get { return m_Facade ?? (m_Facade = m_ConfigurationStrategy.GetAVRFacade(m_Container)); }
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
            get { return ArchiveSqlHelper.IsCredentialsCorrect(); }
        }

        public void Start()
        {
            m_QueryRefreshTimer.Change(0, Timeout.Infinite);
            m_LookupCasheRefreshTimer.Change(0, 1000);
        }

        internal void LookupCasheRefreshTimerTick(object stateInfo)
        {
            try
            {
                LookupManager.AddObject("Query", null, AvrQueryLookup.Accessor.Instance(null).GetType(), "_SelectListInternal");
                LookupManager.AddObject("LayoutFolder", null, AvrFolderLookup.Accessor.Instance(null).GetType(), "_SelectListInternal");
                LookupManager.AddObject("Layout", null, AvrLayoutLookup.Accessor.Instance(null).GetType(), "_SelectListInternal");
                LookupManager.ClearAndReloadOnIdle();
            }
            catch (Exception ex)
            {
                m_Trace.TraceError(ex);
            }
        }

        internal void QueryRefreshTimerTick(object stateInfo)
        {
            lock (m_SyncLock)
            {
                try
                {
                    if (SetAutoEventIfDisposing() || !Configuration.SchedulerEnabled)
                    {
                        return;
                    }

                    int days = Configuration.DaysBetweenSchedulerRuns;
                    if (days < 1)
                    {
                        days = 1;
                    }
                    DateTime dateNow = DateTime.Now;
                    var delta = new TimeSpan(days, -dateNow.Hour, -dateNow.Minute, -dateNow.Second);

                    m_QueryRefreshTimer.Change(Configuration.TimeOfSchedulerRuns + delta, m_InfiniteTimeout);

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
                        DateTime? userRequestDate = Facade.GetsQueryCacheUserRequestDate(queryId);
                        DateTime dateSplitter = DateTime.Now.AddDays(-Configuration.DontRefreshCacheNotUsedByUserAfterDays);
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

        private void TraceStartJob(ICollection<long> queryIdList, IEnumerable<string> languages)
        {
            TraceStartEndJob(queryIdList, languages, true);
        }

        private void TraceEndJob(ICollection<long> queryIdList, IEnumerable<string> languages)
        {
            TraceStartEndJob(queryIdList, languages, false);
        }

        private void TraceStartEndJob(ICollection<long> queryIdList, IEnumerable<string> languages, bool isStart)
        {
            string ids = queryIdList.Aggregate(string.Empty, (current, id) => current + id + ", ");
            string names = queryIdList.Aggregate(string.Empty, (current, id) => current + AvrDbHelper.GetQueryNameForLog(id) + ", ");
            string langs = languages.Aggregate(string.Empty, (current, lang) => current + lang + ", ");

            string msg = isStart
                ? "Start refresh queries with ids '{0}'{3} and with names '{1}'{3} for languages '{2}'"
                : "End refresh queries with ids '{0}'{3} and with names '{1}'{3} for languages '{2}'";
            m_Trace.TraceInfo(m_TraceTitle, msg, ids, names, langs, Environment.NewLine);
        }

        private void TraceStartRefreshQuery(long queryId, string language)
        {
            m_Trace.TraceInfo(m_TraceTitle, "Start refresh query query '{0}' with id='{1}' for language {2}",
                AvrDbHelper.GetQueryNameForLog(queryId), queryId, language);
            m_Watch.Start();
        }

        private void TraceEndRefreshQuery(long queryId, string language)
        {
            m_Watch.Stop();
            m_Trace.TraceInfo(m_TraceTitle, "End refresh query '{0}' with id='{1}' for language {2}{3}Elapsed Milliseconds: {4:N0}",
                AvrDbHelper.GetQueryNameForLog(queryId), queryId,
                language, Environment.NewLine, m_Watch.ElapsedMilliseconds);
            m_Watch.Reset();
        }

        private void TraceQueryNoRequestedByUser(long queryId)
        {
            m_Trace.TraceInfo(m_TraceTitle,
                "Skipped refresh of query '{0}' with id='{1}' because it never have been requested by user. ",
                AvrDbHelper.GetQueryNameForLog(queryId), queryId);
        }

        private void TraceWaiting()
        {
            m_Trace.Trace(m_TraceTitle, "Waiting for {0} seconds before executing next query...",
                Configuration.SecondsBetweenSchedulerTasks);
        }

        public void Dispose()
        {
            if (!m_Disposing)
            {
                m_Disposing = true;

                lock (m_SyncLock)
                {
                    m_QueryRefreshTimer.Change(0, Timeout.Infinite);
                    m_LookupCasheRefreshTimer.Change(0, Timeout.Infinite);
                }

                m_AutoEvent.WaitOne(m_DisposeTimeout);
                m_QueryRefreshTimer.Dispose();
                m_LookupCasheRefreshTimer.Dispose();
            }
        }
    }
}