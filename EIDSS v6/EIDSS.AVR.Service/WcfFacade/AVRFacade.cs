using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Threading;
using bv.common.Core;
using EIDSS.AVR.Service.Scheduler;
using eidss.avr.service.VirtualLayout;
using eidss.model.AVR.Db;
using eidss.model.AVR.ServiceData;
using eidss.model.Avr.View;
using eidss.model.Core.CultureInfo;
using eidss.model.Resources;
using eidss.model.Trace;
using eidss.model.WindowsService;
using eidss.model.WindowsService.Serialization;

namespace EIDSS.AVR.Service.WcfFacade
{
    public class AVRFacade : IAVRFacade
    {
        public const string TraceTitle = "WCF Service Call";
        private static readonly TraceHelper m_Trace = new TraceHelper(TraceHelper.AVRCategory);

        private static readonly object m_CacheSyncLock = new object();
        private static readonly object m_ChartSyncLock = new object();

        private static readonly List<QueryCacheKey> m_QueryCacheList = new List<QueryCacheKey>();
        private static readonly Dictionary<QueryCacheKey, bool> m_QueryCacheErrors = new Dictionary<QueryCacheKey, bool>();
        private static readonly Dictionary<QueryCacheKey, object> m_QueryCacheSyncLock = new Dictionary<QueryCacheKey, object>();

        private SchedulerConfigurationSection m_Configuration;
        private readonly ISchedulerConfigurationStrategy m_ConfigurationStrategy;

        public AVRFacade() : this(new SchedulerConfigurationStrategy())
        {
        }

        public AVRFacade(ISchedulerConfigurationStrategy configurationStrategy)
        {
            m_ConfigurationStrategy = configurationStrategy;
        }

        #region View cache

        public ChartExportDTO ExportChartToJpg(ChartTableDTO zippedData)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, zippedData);

                using (new CultureInfoTransaction(new CultureInfo(CultureInfoEx.ExistingLanguages[zippedData.Lang])))
                {
                    VirtualChart virtualChart = null;
                    try
                    {
                        lock (m_ChartSyncLock)
                        {
                            virtualChart = new VirtualChart();
                        }
                        ChartExportDTO result = virtualChart.ExportChartToJpg(zippedData, m_ChartSyncLock);
                        return result;
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
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, zippedData);
                string format = EidssMessages.Get("msgCouldNotExportChart",
                    "Could not get Export chart from View. ViewID={0}, Lang={1}");
                string msg = string.Format(format, zippedData.ViewId, zippedData.Lang);
                throw new AvrDataException(msg, ex);
            }
        }

        public ViewDTO GetCachedView(string sessionId, long layoutId, string lang)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, sessionId, layoutId, lang);

                AvrPivotViewModel model;

                using (new CultureInfoTransaction(new CultureInfo(CultureInfoEx.ExistingLanguages[lang])))
                {
                    using (var virtualPivot = new VirtualPivot())
                    {
                        model = virtualPivot.CreateAvrPivotViewModel(layoutId, lang);
                    }
                }

                string viewXml = AvrViewSerializer.Serialize(model.ViewHeader);
                byte[] viewZippedBytes = BinaryCompressor.ZipString(viewXml);

                BaseTableDTO serializedDTO = BinarySerializer.SerializeFromTable(model.ViewData);
                BaseTableDTO zippedDTO = BinaryCompressor.Zip(serializedDTO);

                var result = new ViewDTO(zippedDTO, viewZippedBytes);

                return result;
            }
            catch (OutOfMemoryException ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, sessionId, layoutId, lang);
                throw new AvrDataException(EidssMessages.Get("ErrAVROutOfMemory"), ex);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, sessionId, layoutId, lang);
                string format = EidssMessages.Get("msgCouldNotGetViewData",
                    "Could not get View Data from Layout. LayoutID={0}, Lang={1}, SessionId={2}");
                string msg = string.Format(format, layoutId, lang, sessionId);
                throw new AvrDataException(msg, ex);
            }
        }

        #endregion

        #region query cache

        public QueryTableHeaderDTO GetConcreteCachedQueryTableHeader(long queryCacheId, long queryId, string lang, bool isArchive)
        {
            QueryTableHeaderDTO header = AvrDbHelper.GetTableHeader(queryCacheId, false, isArchive);
            return header.PacketCount > 0
                ? header
                : GetInternalCachedQueryTableHeader(queryId, false, lang, isArchive);
        }

        public QueryTableHeaderDTO GetCachedQueryTableHeader(long queryId, string lang, bool isArchive)
        {
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
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, queryId, lang, isArchive);
                var cacheKey = new QueryCacheKey(queryId, lang, isArchive);

                long? id = AvrDbHelper.GetTableId(cacheKey, RefreshedCacheOnUserCallAfterDays);

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
                                    id = AvrDbHelper.GetTableId(cacheKey, RefreshedCacheOnUserCallAfterDays);
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
                                id = AvrDbHelper.GetTableId(cacheKey, RefreshedCacheOnUserCallAfterDays, true);
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

                QueryTableHeaderDTO header = AvrDbHelper.GetTableHeader(id.Value, isSchedulerCall, isArchive);
                return header;
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, queryId, lang);
                string format = EidssMessages.Get("msgCouldNotGetQueryCacheHeader",
                    "Could not get header of query cashe table. Query ID={0}, Language={1}");
                throw new AvrDataException(string.Format(format, queryId, lang), ex);
            }
        }

        public QueryTablePacketDTO GetCachedQueryTablePacket(long queryCasheId, int packetNumber)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, queryCasheId, packetNumber);
                QueryTablePacketDTO packet = AvrDbHelper.GetTablePacket(queryCasheId, packetNumber);
                return packet;
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, queryCasheId, packetNumber);
                string format = EidssMessages.Get("msgCouldNotGetQueryCachePacket",
                    "Could not get packet of query cashe table. QueryCasheID={0}, Packet No={1}");
                string msg = string.Format(format, queryCasheId, packetNumber);
                throw new AvrDataException(msg, ex);
            }
        }

        public void InvalidateQueryCacheForLanguage(long queryId, string lang)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, queryId, lang);

                AvrDbHelper.InvalidateQueryCache(queryId, lang);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, queryId, lang);
                string format = EidssMessages.Get("msgCouldNotInvalidateQueryCache",
                    "Could not make query cashe table out of date. Query ID={0}, Language={1}");
                throw new AvrDataException(string.Format(format, queryId, lang), ex);
            }
        }

        public void InvalidateQueryCache(long queryId)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, queryId);

                AvrDbHelper.InvalidateQueryCache(queryId);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, queryId);

                string format = EidssMessages.Get("msgCouldNotInvalidateQueryCacheAllLang",
                    "Could not make query cashe table out of date. Query ID={0}, All Languages");
                throw new AvrDataException(string.Format(format, queryId), ex);
            }
        }

        public void DeleteQueryCacheForLanguage(long queryId, string lang, bool leaveLastRecord)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle, queryId, lang);

                int numberDeleted = AvrDbHelper.DeleteQueryCache(queryId, lang, leaveLastRecord);
                if (numberDeleted != 0)
                {
                    string msg = string.Format("Deleted '{0}' old cache records for Query '{1}' for language '{2}'",
                        numberDeleted, queryId, lang);
                    m_Trace.Trace(TraceTitle, msg);
                }
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle, queryId, lang);
                string format = EidssMessages.Get("msgCouldNotDeleteQueryCache",
                    "Could not delete query cashe. Query ID={0}, Language={1}");
                throw new AvrDataException(string.Format(format, queryId, lang), ex);
            }
        }

        public DateTime GetQueryRefreshDateTime(long queryId, string lang)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle);

                return AvrDbHelper.GetQueryRefreshDateTime(queryId, lang);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle);
                string format = EidssMessages.Get("msgCouldNotGetQueryCache",
                    "Could not get query cashe refresh date and time for Query ID={0}");
                throw new AvrDataException(string.Format(format, queryId), ex);
            }
        }

        public DateTime? GetsQueryCacheUserRequestDate(long queryId)
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle);

                return AvrDbHelper.GetsQueryCacheUserRequestDate(queryId);
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle);
                string format = EidssMessages.Get("msgCouldNotGetQueryCacheUserRequestDate",
                    "Could not get date when user requestet query cashe for Query ID={0}");
                throw new AvrDataException(string.Format(format, queryId), ex);
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

        #endregion

        #region Common

        public Version GetServiceVersion()
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle);

                Assembly asm = Assembly.GetExecutingAssembly();
                return asm.GetName().Version;
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle);
                string message = EidssMessages.Get("msgAvrServiceVersionError", "Could not get service version due to internal error.");
                throw new AvrDataException(message, ex);
            }
        }

        public DatabaseNames GetDatabaseName()
        {
            try
            {
                m_Trace.TraceMethodCall(Utils.GetCurrentMethodName(), TraceTitle);

                return AvrDbHelper.GetDatabaseNames();
            }
            catch (AvrDataException ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle);
                throw;
            }
            catch (Exception ex)
            {
                m_Trace.TraceMethodException(ex, Utils.GetCurrentMethodName(), TraceTitle);
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

        #endregion
    }
}