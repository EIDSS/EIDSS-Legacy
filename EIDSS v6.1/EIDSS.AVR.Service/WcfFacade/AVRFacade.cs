using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Threading;
using bv.common.Configuration;
using bv.common.Core;
using eidss.avr.LayoutForm;
using eidss.avr.service.VirtualLayout;
using eidss.avr.service.WcfFacade;
using eidss.model.Avr.View;
using eidss.model.AVR.DataBase;
using eidss.model.AVR.ServiceData;
using eidss.model.Core.CultureInfo;
using eidss.model.Resources;
using eidss.model.Trace;
using eidss.model.WindowsService;
using eidss.model.WindowsService.Serialization;
using EIDSS.AVR.Service.Scheduler;
using StructureMap;

namespace EIDSS.AVR.Service.WcfFacade
{
    public class AVRFacade : IAVRFacade
    {
        public readonly string m_TraceTitle;
        private static readonly TraceHelper m_Trace = new TraceHelper(TraceHelper.AVRCategory);

        private static readonly SemaphoreSlim m_ViewSemaphore;

        private static readonly object m_CacheSyncLock = new object();
        private static readonly object m_ChartSyncLock = new object();

        private static readonly List<QueryCacheKey> m_QueryCacheList = new List<QueryCacheKey>();
        private static readonly Dictionary<QueryCacheKey, bool> m_QueryCacheErrors = new Dictionary<QueryCacheKey, bool>();
        private static readonly Dictionary<QueryCacheKey, object> m_QueryCacheSyncLock = new Dictionary<QueryCacheKey, object>();

        private SchedulerConfigurationSection m_Configuration;
        private readonly ISchedulerConfigurationStrategy m_ConfigurationStrategy;
        private readonly IContainer m_Container;

        static AVRFacade()
        {
            var max = Config.GetIntSetting("MaxViewSimultaneouslyRequests", 1);
            m_ViewSemaphore = new SemaphoreSlim(max, max);
        }

        // todo [ivan] implement default container 
        private static Container StructureMapContainerInit()
        {
            Container c = new Container();
            c.Configure(r =>
            {
                r.For<ISchedulerConfigurationStrategy>().Use<SchedulerConfigurationStrategy>();
                r.For<ITraceStrategy>().Use<TraceHelper>();
            });
            return c;
        }

        public AVRFacade()
            : this(StructureMapContainerInit())
        {
        }

        public AVRFacade(IContainer container)
        {
            m_Container = container;
            m_ConfigurationStrategy = m_Container.GetInstance<ISchedulerConfigurationStrategy>();

            m_TraceTitle = String.Format("[{0}] WCF Service Call", m_ConfigurationStrategy.GetServiceDisplayName());
        }

        #region View cache

        public ChartExportDTO ExportChartToJpg(ChartTableDTO zippedData)
        {
            try
            {
                string layoutName = AvrDbHelper.GetLayoutNameForLog(zippedData.ViewId);
                Stopwatch watch = TraceMethodCall(layoutName, zippedData);
                EidssAvrServiceInitializer.CheckAndInitEidssCore();

                ChartExportDTO result;
                using (new CultureInfoTransaction(new CultureInfo(CustomCultureHelper.SupportedLanguages[zippedData.Lang])))
                {
                    VirtualChart virtualChart = null;
                    try
                    {
                        lock (m_ChartSyncLock)
                        {
                            virtualChart = new VirtualChart(m_Container);
                        }
                        result = virtualChart.ExportChartToJpg(zippedData, m_ChartSyncLock);
                    }
                    finally
                    {
                        if (virtualChart != null)
                        {
                            lock (m_ChartSyncLock)
                            {
                                virtualChart.Dispose();
                            }
                        }
                    }
                }
                TraceMethodCallFinished(watch, layoutName, zippedData);
                return result;
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), m_TraceTitle, zippedData);
                string format = EidssMessages.Get("msgCouldNotExportChart",
                    "Could not get Export chart from View. ViewID={0}, Lang={1}");
                string msg = String.Format(format, zippedData.ViewId, zippedData.Lang);
                throw new AvrDataException(msg, ex);
            }
        }

        public ViewDTO GetCachedView(string sessionId, long layoutId, string lang)
        {
            try
            {
                m_ViewSemaphore.Wait();

                var layout = AvrDbHelper.GetLayoutDTO(layoutId);
                Stopwatch watch = TraceMethodCall(sessionId, layoutId, layout.DefaultLayoutName, lang);
                EidssAvrServiceInitializer.CheckAndInitEidssCore();

                ViewDTO view = null;
                var cacheKey = new QueryCacheKey(layout.QueryId, lang, layout.UseArchivedData);
                long? queryCacheId = AvrDbHelper.GetQueryCacheId(cacheKey, RefreshedCacheOnUserCallAfterDays);
                if (queryCacheId.HasValue)
                {
                    var viewCacheId = AvrDbHelper.GetViewCacheId(queryCacheId.Value, layoutId, RefreshedCacheOnUserCallAfterDays);
                    if (viewCacheId.HasValue)
                    {
                        view = AvrDbHelper.GetViewCache(viewCacheId.Value, false);
                    }
                }

                if (view == null)
                {
                    AvrPivotViewModel model = VirtualPivot.CreateAvrPivotViewModel(layoutId, lang, m_Container);

                    string xmlViewHeader = AvrViewSerializer.Serialize(model.ViewHeader);
                    byte[] zippedViewHeader = BinaryCompressor.ZipString(xmlViewHeader);

                    BaseTableDTO serializedDTO = BinarySerializer.SerializeFromTable(model.ViewData);
                    BaseTableDTO zippedDTO = BinaryCompressor.Zip(serializedDTO);

                    view = new ViewDTO(zippedDTO, zippedViewHeader);

                    queryCacheId = AvrDbHelper.GetQueryCacheId(cacheKey, RefreshedCacheOnUserCallAfterDays);
                    if (queryCacheId.HasValue)
                    {
                        AvrDbHelper.SaveViewCache(queryCacheId.Value, layoutId, view);
                    }
                }
                TraceMethodCallFinished(watch, sessionId, layoutId, layout.DefaultLayoutName, lang);
                return view;
            }
            catch (OutOfMemoryException ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), m_TraceTitle, sessionId, layoutId, lang);
                throw new AvrDataException(EidssMessages.Get("ErrAVROutOfMemory"), ex);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), m_TraceTitle, sessionId, layoutId, lang);
                string format = EidssMessages.Get("msgCouldNotGetViewData",
                    "Could not get View Data from Layout. LayoutID={0}, Lang={1}, SessionId={2}");
                string msg = String.Format(format, layoutId, lang, sessionId);
                throw new AvrDataException(msg, ex);
            }
            finally
            {
                m_ViewSemaphore.Release();
            }
        }


        public void InvalidateViewCache(long layoutId)
        {
            try
            {
                TraceMethodCall(layoutId, AvrDbHelper.GetLayoutNameForLog(layoutId));

                AvrDbHelper.InvalidateViewCache(layoutId);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), m_TraceTitle, layoutId);

                string format = EidssMessages.Get("msgCouldNotInvalidateViewCacheAllLang",
                    "Could not make view cashe out of date. View ID={0}, All Languages");
                throw new AvrDataException(String.Format(format, layoutId), ex);
            }
        }
        #endregion

        #region query cache

        public QueryTableHeaderDTO GetConcreteCachedQueryTableHeader(long queryCacheId, long queryId, string lang, bool isArchive)
        {
            QueryTableHeaderDTO header = AvrDbHelper.GetQueryCacheHeader(queryCacheId, false, isArchive);
            return header.PacketCount > 0
                ? header
                : GetInternalCachedQueryTableHeader(queryId, false, lang, isArchive);
        }

        public QueryTableHeaderDTO GetCachedQueryTableHeader(long queryId, string lang, bool isArchive)
        {
            if (queryId < 0)
            {
                return new QueryTableHeaderDTO();
            }
            return GetInternalCachedQueryTableHeader(queryId, false, lang, isArchive);
        }

        public void RefreshCachedQueryTableByScheduler(long queryId, string lang, bool isArchive)
        {
            InvalidateQueryCacheForLanguage(queryId, lang);
            GetInternalCachedQueryTableHeader(queryId, true, lang, isArchive);
        }

        private QueryTableHeaderDTO GetInternalCachedQueryTableHeader(long queryId, bool isSchedulerCall, string lang, bool isArchive)
        {
            try
            {
                string queryName = AvrDbHelper.GetQueryNameForLog(queryId);
                Stopwatch watch = TraceMethodCall(queryId, queryName, lang, isArchive);

                EidssAvrServiceInitializer.CheckAndInitEidssCore();

                var cacheKey = new QueryCacheKey(queryId, lang, isArchive);

                long? id = AvrDbHelper.GetQueryCacheId(cacheKey, RefreshedCacheOnUserCallAfterDays);

                if (!id.HasValue)
                {
                    bool needExecute;
                    lock (m_CacheSyncLock)
                    {
                        needExecute = !m_QueryCacheList.Contains(cacheKey);
                        if (needExecute)
                        {
                            m_QueryCacheList.Add(cacheKey);
                            if (!m_QueryCacheSyncLock.ContainsKey(cacheKey))
                            {
                                m_QueryCacheSyncLock.Add(cacheKey, new object());
                            }
                            if (!m_QueryCacheErrors.ContainsKey(cacheKey))
                            {
                                m_QueryCacheErrors.Add(cacheKey, false);
                            }
                        }
                    }
                    lock (m_QueryCacheSyncLock[cacheKey])
                    {
                        try
                        {
                            if (needExecute)
                            {
                                try
                                {
                                    id = AvrDbHelper.GetQueryCacheId(cacheKey, RefreshedCacheOnUserCallAfterDays);
                                    if (!id.HasValue)
                                    {
                                        QueryTableModel tableModel = AvrDbHelper.GetQueryResult(queryId, lang, isArchive);
                                        id = AvrDbHelper.SaveQueryCache(tableModel);
                                    }
                                }
                                finally
                                {
                                    lock (m_CacheSyncLock)
                                    {
                                        m_QueryCacheErrors[cacheKey] = !id.HasValue;
                                        m_QueryCacheList.Remove(cacheKey);
                                    }
                                }
                            }
                            else
                            {
                                while (true)
                                {
                                    lock (m_CacheSyncLock)
                                    {
                                        if (!m_QueryCacheList.Contains(cacheKey))
                                        {
                                            break;
                                        }
                                    }

                                    Monitor.Wait(m_QueryCacheSyncLock[cacheKey]);
                                }
                                lock (m_CacheSyncLock)
                                {
                                    if (m_QueryCacheErrors[cacheKey])
                                    {
                                        string message = EidssMessages.Get("msgCouldNotGetQueryCacheHeaderGeneral",
                                            "Could not get header of query cashe table. For detail see previous exception logged");
                                        throw new AvrDataException(message);
                                    }
                                }
                                id = AvrDbHelper.GetQueryCacheId(cacheKey, RefreshedCacheOnUserCallAfterDays, true);
                            }
                        }
                        finally
                        {
                            Monitor.PulseAll(m_QueryCacheSyncLock[cacheKey]);
                        }
                    }
                }
                if (!id.HasValue)
                {
                    string msg = EidssMessages.Get("msgCouldNotGetQueryCacheId", "Could not get query cashe ID. See log for more details.");
                    throw new AvrDataException(msg);
                }

                QueryTableHeaderDTO header = AvrDbHelper.GetQueryCacheHeader(id.Value, isSchedulerCall, isArchive);
                TraceMethodCallFinished(watch, queryId, queryName, lang, isArchive);
                return header;
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), m_TraceTitle, queryId, lang);
                string format = EidssMessages.Get("msgCouldNotGetQueryCacheHeader",
                    "Could not get header of query cashe table. Query ID={0}, Language={1}");
                throw new AvrDataException(String.Format(format, queryId, lang), ex);
            }
        }

        public QueryTablePacketDTO GetCachedQueryTablePacket(long queryCasheId, int packetNumber, int totalPacketCount)
        {
            try
            {
                if (queryCasheId < 0)
                {
                    return new QueryTablePacketDTO();
                }

                TraceMethodCall(queryCasheId, packetNumber);
                QueryTablePacketDTO packet = AvrDbHelper.GetQueryCachePacket(queryCasheId, packetNumber);

                m_Trace.Trace(m_TraceTitle, "Packet {0} of {1} for Query Cashe {2} received", packetNumber + 1, totalPacketCount,
                    queryCasheId);

                return packet;
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), m_TraceTitle, queryCasheId, packetNumber);
                string format = EidssMessages.Get("msgCouldNotGetQueryCachePacket",
                    "Could not get packet of query cashe table. QueryCasheID={0}, Packet No={1}");
                string msg = String.Format(format, queryCasheId, packetNumber + 1);
                throw new AvrDataException(msg, ex);
            }
        }

        public void InvalidateQueryCacheForLanguage(long queryId, string lang)
        {
            try
            {
                TraceMethodCall(queryId, AvrDbHelper.GetQueryNameForLog(queryId), lang);

                AvrDbHelper.InvalidateQueryCache(queryId, lang);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), m_TraceTitle, queryId, lang);
                string format = EidssMessages.Get("msgCouldNotInvalidateQueryCache",
                    "Could not make query cashe table out of date. Query ID={0}, Language={1}");
                throw new AvrDataException(String.Format(format, queryId, lang), ex);
            }
        }

        public void InvalidateQueryCache(long queryId)
        {
            try
            {
                TraceMethodCall(queryId, AvrDbHelper.GetQueryNameForLog(queryId));

                AvrDbHelper.InvalidateQueryCache(queryId);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), m_TraceTitle, queryId);

                string format = EidssMessages.Get("msgCouldNotInvalidateQueryCacheAllLang",
                    "Could not make query cashe table out of date. Query ID={0}, All Languages");
                throw new AvrDataException(String.Format(format, queryId), ex);
            }
        }

        public void DeleteQueryCacheForLanguage(long queryId, string lang, bool leaveLastRecord)
        {
            try
            {
                TraceMethodCall(queryId, AvrDbHelper.GetQueryNameForLog(queryId), lang);

                int numberDeleted = AvrDbHelper.DeleteQueryCache(queryId, lang, leaveLastRecord);
                if (numberDeleted != 0)
                {
                    string msg = String.Format("Deleted '{0}' old cache records for Query '{1}' for language '{2}'",
                        numberDeleted, queryId, lang);
                    m_Trace.Trace(m_TraceTitle, msg);
                }
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), m_TraceTitle, queryId, lang);
                string format = EidssMessages.Get("msgCouldNotDeleteQueryCache",
                    "Could not delete query cashe. Query ID={0}, Language={1}");
                throw new AvrDataException(String.Format(format, queryId, lang), ex);
            }
        }

        public bool DoesCachedQueryExists(long queryId, string lang, bool isArchive)
        {
            try
            {
                TraceMethodCall(queryId, AvrDbHelper.GetQueryNameForLog(queryId), lang);
                var cacheKey = new QueryCacheKey(queryId, lang, isArchive);
                long? id = AvrDbHelper.GetQueryCacheId(cacheKey, RefreshedCacheOnUserCallAfterDays);
                return id.HasValue;
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), m_TraceTitle);
                string format = EidssMessages.Get("msgCouldNotGetQueryCacheExistance",
                    "Could not define does query cache exists for Query ID={0}.");
                throw new AvrDataException(String.Format(format, queryId), ex);
            }
        }

        public DateTime GetQueryRefreshDateTime(long queryId, string lang)
        {
            try
            {
                if (queryId < 0)
                {
                    return DateTime.Now;
                }
                TraceMethodCall(queryId, AvrDbHelper.GetQueryNameForLog(queryId), lang);

                return AvrDbHelper.GetQueryRefreshDateTime(queryId, lang);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), m_TraceTitle);
                string format = EidssMessages.Get("msgCouldNotGetQueryCache",
                    "Could not get query cashe refresh date and time for Query ID={0}");
                throw new AvrDataException(String.Format(format, queryId), ex);
            }
        }

        public DateTime? GetsQueryCacheUserRequestDate(long queryId)
        {
            try
            {
                TraceMethodCall(queryId, AvrDbHelper.GetQueryNameForLog(queryId));

                return AvrDbHelper.GetsQueryCacheUserRequestDate(queryId);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), m_TraceTitle);
                string format = EidssMessages.Get("msgCouldNotGetQueryCacheUserRequestDate",
                    "Could not get date when user requestet query cashe for Query ID={0}");
                throw new AvrDataException(String.Format(format, queryId), ex);
            }
        }

        public List<long> GetQueryIdList()
        {
            return AvrDbHelper.GetQueryIdList();
        }

        public List<long> GetLayoutIdList()
        {
            return AvrDbHelper.GetLayoutIdList();
        }

        public long CopyLayout(long layoutId, string lang)
        {
            try
            {
                TraceMethodCall(layoutId, AvrDbHelper.GetLayoutNameForLog(layoutId), lang);
                EidssAvrServiceInitializer.CheckAndInitEidssCore();
                return VirtualLayoutCopier.CreateLayoutCopyInAvrService(layoutId, lang, m_Container);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), m_TraceTitle);
                string format = EidssMessages.Get("msgCouldNotCreateLayoutCopy", "Could not create layout copy. Layout ID={0}, Language={1}");
                throw new AvrDataException(String.Format(format, layoutId, lang), ex);
            }
        }

        #endregion

        #region Common

        public Version GetServiceVersion()
        {
            try
            {
                TraceMethodCall();

                Assembly asm = Assembly.GetExecutingAssembly();
                return asm.GetName().Version;
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), m_TraceTitle);
                string message = EidssMessages.Get("msgAvrServiceVersionError", "Could not get service version due to internal error.");
                throw new AvrDataException(message, ex);
            }
        }

        public DatabaseNames GetDatabaseName()
        {
            try
            {
                TraceMethodCall();

                return AvrDbHelper.GetDatabaseNames();
            }
            catch (AvrDataException ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), m_TraceTitle);
                throw;
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), m_TraceTitle);
                string message = EidssMessages.Get("msgAvrServiceDbNameError", "Could not get service Database names due to internal error.");
                throw new AvrDataException(message, ex);
            }
        }

        #endregion

        #region Helper methods

        private SchedulerConfigurationSection Configuration
        {
            get { return m_Configuration ?? (m_Configuration = m_ConfigurationStrategy.GetConfigurationSection()); }
        }

        internal int RefreshedCacheOnUserCallAfterDays
        {
            get { return Configuration.RefreshedCacheOnUserCallAfterDays; }
        }

        private Stopwatch TraceMethodCall(params object[] values)
        {
            m_Trace.TraceMethodCall(Utils.GetPreviousMethodName(), m_TraceTitle, values);
            var watch = new Stopwatch();
            watch.Start();
            return watch;
        }

        private void TraceMethodCallFinished(Stopwatch watch, params object[] values)
        {
            string methodName = String.Format("Finish call (duration={0}) of {1}", watch.Elapsed, Utils.GetPreviousMethodName());
            m_Trace.TraceMethodCall(methodName, m_TraceTitle, values);
        }

        #endregion
    }
}