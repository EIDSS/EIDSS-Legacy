using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using bv.common.Core;
using bv.model.BLToolkit;
using BLToolkit.Data;
using eidss.model.AVR.DataBase;
using eidss.model.AVR.ServiceData;
using eidss.model.AVR.SourceData;
using eidss.model.Helpers;
using eidss.model.Resources;
using eidss.model.Trace;
using eidss.model.WindowsService.Serialization;

namespace EIDSS.AVR.Service.WcfFacade
{
    public static class AvrDbHelper
    {
        public class LayoutDTO
        {
            public LayoutDTO(long layoutId)
            {
                LayoutId = layoutId;
            }

            public long LayoutId { get; set; }
            public long QueryId { get; set; }
            public string DefaultLayoutName { get; set; }
            public bool UseArchivedData { get; set; }
        }

        public const string TraceTitle = "AVR DB";
        private static readonly TraceHelper m_Trace = new TraceHelper(TraceHelper.AVRCategory);

        private const int DaysInAWeek = 7;
        private static readonly object m_DbSyncLock = new object();

        public static long? GetQueryCacheId
            (long queryId, string lang, bool isArchive, int refresheAfterDays = DaysInAWeek, bool allowSelectInvalidated = false)
        {
            return GetQueryCacheId(new QueryCacheKey(queryId, lang, isArchive), refresheAfterDays, allowSelectInvalidated);
        }

        public static long? GetQueryCacheId
            (QueryCacheKey queryCacheKey, int refresheAfterDays = DaysInAWeek, bool allowSelectInvalidated = false)
        {
            using (var avrTran = new AvrDbTransaction())
            {
                DbManagerProxy manager = avrTran.Manager;
                DbManager command = manager.SetSpCommand("spAsQueryCacheExist",
                    manager.Parameter("idfQuery", queryCacheKey.QueryId),
                    manager.Parameter("strLanguage", queryCacheKey.Lang),
                    manager.Parameter("blnUseArchivedData", queryCacheKey.IsArchive),
                    manager.Parameter("refreshedCacheOnUserCallAfterDays", refresheAfterDays),
                    manager.Parameter("allowSelectInvalidated", allowSelectInvalidated)
                    );
                object result;
                lock (m_DbSyncLock)
                {
                    result = command.ExecuteScalar();
                    avrTran.CommitTransaction();
                }

                return (result == null || result == DBNull.Value) ? null : (long?) result;
            }
        }

        public static DateTime? GetsQueryCacheUserRequestDate(long queryId)
        {
            using (var avrTran = new AvrDbTransaction())
            {
                DbManagerProxy manager = avrTran.Manager;
                DbManager command = manager.SetSpCommand("spAsQueryCacheUserRequestDate", manager.Parameter("idfQuery", queryId));
                object result;
                lock (m_DbSyncLock)
                {
                    result = command.ExecuteScalar();
                    avrTran.CommitTransaction();
                }
                return (result == null || result == DBNull.Value) ? null : (DateTime?) result;
            }
        }

        public static QueryTableHeaderDTO GetQueryCacheHeader(long queryCacheId, bool isSchedulerCall, bool isArchive)
        {
            using (var avrTran = new AvrDbTransaction())
            {
                DbManagerProxy manager = avrTran.Manager;
                DbManager command = manager.SetSpCommand("spAsQueryCacheGetHeader",
                    manager.Parameter("idfQueryCache", queryCacheId),
                    manager.Parameter("blnSchedulerCall", isSchedulerCall),
                    manager.Parameter("blnUseArchivedData", isArchive));

                QueryTablePacketDTO headerPacket = new QueryTablePacketDTO {IsArchive = isArchive};
                int packetCount = 0;
                lock (m_DbSyncLock)
                {
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            packetCount = (int) reader["intPacketCount"];
                            headerPacket.RowCount = (int) reader["intQueryColumnCount"];
                            var binaryBody = (byte[]) reader["blbQuerySchema"];
                            headerPacket.BinaryBody = new ChunkByteArray(binaryBody);
                        }
                    }

                    avrTran.CommitTransaction();
                }
                return new QueryTableHeaderDTO(headerPacket, queryCacheId, packetCount);
            }
        }

        public static QueryTablePacketDTO GetQueryCachePacket(long queryCasheId, int packetNumber)
        {
            using (var avrTran = new AvrDbTransaction())
            {
                DbManager command = avrTran.Manager.SetSpCommand("spAsQueryCacheGetPacket",
                    avrTran.Manager.Parameter("idfQueryCache", queryCasheId),
                    avrTran.Manager.Parameter("intQueryCachePacketNumber", packetNumber));

                var result = new QueryTablePacketDTO();
                using (IDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result.RowCount = (int) reader["intTableRowCount"];
                        result.BinaryBody = new ChunkByteArray((byte[]) reader["blbQueryCachePacket"]);
                        result.IsArchive = (bool) reader["blnArchivedData"];
                    }
                }
                avrTran.CommitTransaction();
                return result;
            }
        }

        public static long SaveQueryCache(QueryTableModel zippedTable)
        {
            using (var avrTran = new AvrDbTransaction())
            {
                long id = SaveQueryCacheWithoutTransaction(zippedTable);
                avrTran.CommitTransaction();
                return id;
            }
        }

        public static long SaveQueryCacheWithoutTransaction(QueryTableModel zippedTable)
        {
            lock (m_DbSyncLock)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory[DatabaseType.Avr].Create())
                {
                    DbManager headerCommand = manager.SetSpCommand("spAsQueryCachePostHeader",
                        manager.Parameter("idfQuery", zippedTable.QueryId),
                        manager.Parameter("strLanguage", zippedTable.Language),
                        manager.Parameter("intQueryColumnCount", zippedTable.Header.RowCount),
                        manager.Parameter("blbQuerySchema", zippedTable.Header.BinaryBody.ToArray()),
                        manager.Parameter("blnUseArchivedData", zippedTable.UseArchivedData)
                        );

                    var queryCasheId = (long) headerCommand.ExecuteScalar();
                    for (int i = 0; i < zippedTable.BodyPackets.Count; i++)
                    {
                        DbManager command = manager.SetSpCommand("spAsQueryCachePostPacket",
                            manager.Parameter("idfQueryCache", queryCasheId),
                            manager.Parameter("intQueryCachePacketNumber", i),
                            manager.Parameter("intPacketRowCount", zippedTable.BodyPackets[i].RowCount),
                            manager.Parameter("blbQueryCachePacket", zippedTable.BodyPackets[i].BinaryBody.ToArray()),
                            manager.Parameter("blnArchivedData", zippedTable.BodyPackets[i].IsArchive)
                            );

                        command.ExecuteNonQuery();
                    }

                    return queryCasheId;
                }
            }
        }

        public static void InvalidateQueryCache(long queryId, string lang = null)
        {
            using (var avrTran = new AvrDbTransaction())
            {
                DbManagerProxy manager = avrTran.Manager;

                DbManager command = string.IsNullOrEmpty(lang)
                    ? manager.SetSpCommand("spAsQueryCacheInvalidate",
                        manager.Parameter("idfQuery", queryId))
                    : manager.SetSpCommand("spAsQueryCacheInvalidate",
                        manager.Parameter("idfQuery", queryId),
                        manager.Parameter("strLanguage", lang));

                lock (m_DbSyncLock)
                {
                    command.ExecuteNonQuery();
                    avrTran.CommitTransaction();
                }
            }
        }

        public static int DeleteQueryCache(long queryId, string lang, bool leaveLastRecord)
        {
            using (var avrTran = new AvrDbTransaction())
            {
                DbManagerProxy manager = avrTran.Manager;
                DbManager command = manager.SetSpCommand("spAsQueryCacheDelete",
                    manager.Parameter("idfQuery", queryId),
                    manager.Parameter("strLanguage", lang),
                    manager.Parameter("blnLeaveLastRecord", leaveLastRecord)
                    );

                lock (m_DbSyncLock)
                {
                    object result = command.ExecuteScalar();
                    int numberDeleted = 0;
                    if (result is int)
                    {
                        numberDeleted = (int) result;
                    }
                    avrTran.CommitTransaction();
                    return numberDeleted;
                }
            }
        }

        public static DateTime GetQueryRefreshDateTime(long queryId, string lang)
        {
            DateTime date = DateTime.Now;
            using (var avrTran = new AvrDbTransaction())
            {
                DbManagerProxy manager = avrTran.Manager;
                DbManager command = manager.SetSpCommand("spAsQueryCacheGetRefreshDateTime",
                    manager.Parameter("idfQuery", queryId),
                    manager.Parameter("strLanguage", lang));
                lock (m_DbSyncLock)
                {
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            date = (DateTime) reader["datQueryRefresh"];
                        }
                    }
                    avrTran.CommitTransaction();
                }
            }
            return date;
        }

        public static long SaveViewCache(long queryCacheId, long layoutId, ViewDTO zippedTable)
        {
            using (var avrTran = new AvrDbTransaction())
            {
                long id = SaveViewCacheWithoutTransaction(queryCacheId, layoutId, zippedTable);
                avrTran.CommitTransaction();
                return id;
            }
        }

        public static long SaveViewCacheWithoutTransaction(long queryCacheId, long layoutId, ViewDTO zippedTable)
        {
            lock (m_DbSyncLock)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory[DatabaseType.Avr].Create())
                {
                    DbManager headerCommand = manager.SetSpCommand("spAsViewCachePostHeader",
                        manager.Parameter("idfQueryCache", queryCacheId),
                        manager.Parameter("idfLayout", layoutId),
                        manager.Parameter("blbViewSchema", zippedTable.Header.BinaryBody.ToArray()),
                        manager.Parameter("blbViewHeader", zippedTable.BinaryViewHeader),
                        manager.Parameter("intViewColumnCount", zippedTable.Header.RowCount)
                        );

                    var viewCasheId = (long) headerCommand.ExecuteScalar();
                    for (int i = 0; i < zippedTable.BodyPackets.Count; i++)
                    {
                        DbManager command = manager.SetSpCommand("spAsViewCachePostPacket",
                            manager.Parameter("idfViewCache", viewCasheId),
                            manager.Parameter("intViewCachePacketNumber", i),
                            manager.Parameter("intPacketRowCount", zippedTable.BodyPackets[i].RowCount),
                            manager.Parameter("blbViewCachePacket", zippedTable.BodyPackets[i].BinaryBody.ToArray())
                            );

                        command.ExecuteNonQuery();
                    }

                    return viewCasheId;
                }
            }
        }

        public static void InvalidateViewCache(long layoutId)
        {
            using (var avrTran = new AvrDbTransaction())
            {
                DbManagerProxy manager = avrTran.Manager;

                DbManager command = manager.SetSpCommand("spAsViewCacheInvalidate",
                    manager.Parameter("idfLayout", layoutId));

                lock (m_DbSyncLock)
                {
                    command.ExecuteNonQuery();
                    avrTran.CommitTransaction();
                }
            }
        }

        public static long? GetViewCacheId
            (long queryCacheId, long layoutId, int refresheAfterDays = DaysInAWeek, bool allowSelectInvalidated = false)
        {
            using (var avrTran = new AvrDbTransaction())
            {
                DbManagerProxy manager = avrTran.Manager;
                DbManager command = manager.SetSpCommand("spAsViewCacheExist",
                    manager.Parameter("idfQueryCache", queryCacheId),
                    manager.Parameter("idfLayout", layoutId),
                    manager.Parameter("refreshedCacheOnUserCallAfterDays", refresheAfterDays),
                    manager.Parameter("allowSelectInvalidated", allowSelectInvalidated)
                    );
                object result;
                lock (m_DbSyncLock)
                {
                    result = command.ExecuteScalar();
                    avrTran.CommitTransaction();
                }

                return (result == null || result == DBNull.Value) ? null : (long?) result;
            }
        }

        public static ViewDTO GetViewCache(long viewCacheId, bool isSchedulerCall)
        {
            ViewDTO view;
            using (var avrTran = new AvrDbTransaction())
            {
                DbManagerProxy manager = avrTran.Manager;
                DbManager headerCmd = manager.SetSpCommand("spAsViewCacheGetHeader",
                    manager.Parameter("idfViewCache", viewCacheId),
                    manager.Parameter("blnSchedulerCall", isSchedulerCall));

                lock (m_DbSyncLock)
                {
                    int packetCount;
                    using (IDataReader reader = headerCmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            return null;
                        }

                        BaseTableDTO viewTableDTO = new BaseTableDTO
                        {
                            Header =
                            {
                                RowCount = (int) reader["intViewColumnCount"],
                                BinaryBody = new ChunkByteArray((byte[]) reader["blbViewSchema"])
                            }
                        };

                        var binaryHeader = (byte[]) reader["blbViewHeader"];
                        view = new ViewDTO(viewTableDTO, binaryHeader);

                        packetCount = (int) reader["intPacketCount"];
                    }
                    for (int packetNumber = 0; packetNumber < packetCount; packetNumber++)
                    {
                        DbManager packetCmd = manager.SetSpCommand("spAsViewCacheGetPacket",
                            manager.Parameter("idfViewCache", viewCacheId),
                            manager.Parameter("intViewCachePacketNumber", packetNumber));

                        var packetDTO = new BaseTablePacketDTO();
                        using (IDataReader packetReader = packetCmd.ExecuteReader())
                        {
                            if (!packetReader.Read())
                            {
                                return null;
                            }

                            packetDTO.RowCount = (int) packetReader["intTableRowCount"];
                            packetDTO.BinaryBody = new ChunkByteArray((byte[]) packetReader["blbViewCachePacket"]);
                        }
                        view.BodyPackets.Add(packetDTO);
                    }

                    avrTran.CommitTransaction();
                }
            }
            return view;
        }

        public static QueryTableModel GetQueryResult(long queryId, string lang, bool isArchive)
        {
            string queryString;
            QueryTableModel zippedTable;

            var watch = new Stopwatch();
            watch.Start();
            m_Trace.Trace(TraceTitle, "Executing actual query '{0}' for lang '{1}'", queryId, lang);
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
            {
                queryString = QueryHelper.GetQueryText(manager, queryId, false);

                QueryTableModel serializedTable = QueryHelper.GetInnerQueryResult(manager, queryString, lang,
                    c => BinarySerializer.SerializeFromCommand(c, queryId, lang, false));
                zippedTable = BinaryCompressor.Zip(serializedTable);
            }

            if (isArchive)
            {
                m_Trace.Trace(TraceTitle, "Executing archive query '{0}' for lang '{1}'", queryId, lang);
                using (DbManagerProxy archiveManager = DbManagerFactory.Factory[DatabaseType.Archive].Create())
                {
                    using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
                    {
                        QueryHelper.DropAndCreateArchiveQuery(manager, archiveManager, queryId);
                    }
                    QueryTableModel serializedArchiveTable = QueryHelper.GetInnerQueryResult(archiveManager, queryString, lang,
                        c => BinarySerializer.SerializeFromCommand(c, queryId, lang, true));
                    QueryTableModel zippedArchiveTable = BinaryCompressor.Zip(serializedArchiveTable);

                    zippedTable.UseArchivedData = true;
                    foreach (QueryTablePacketDTO packet in zippedArchiveTable.BodyPackets)
                    {
                        packet.IsArchive = true;
                        zippedTable.BodyPackets.Add(packet);
                    }
                }
            }
            m_Trace.Trace(TraceTitle, "Executing query '{0}' for lang '{1}' finished, duration={2},", queryId, lang, watch.Elapsed);
            return zippedTable;
        }

        public static DatabaseNames GetDatabaseNames()
        {
            string eidssActualDbName;
            string eidssArchiveDbName = null;
            string avrDbName;
            try
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
                {
                    eidssActualDbName = GetDatabaseName(manager);
                }
            }
            catch (Exception ex)
            {
                string message = EidssMessages.Get("msgAvrServiceActualDbError", "AVR Service could not connect to Actual EIDSS Database");
                throw new AvrDataException(message, ex);
            }
            try
            {
                if (ArchiveSqlHelper.IsCredentialsCorrect())
                {
                    using (DbManagerProxy archiveManager = DbManagerFactory.Factory[DatabaseType.Archive].Create())
                    {
                        eidssArchiveDbName = GetDatabaseName(archiveManager);
                    }
                }
            }
            catch (Exception ex)
            {
                string message = EidssMessages.Get("msgAvrServiceArchiveDbError", "AVR Service could not connect to Archive EIDSS Database");
                throw new AvrDataException(message, ex);
            }

            try
            {
                using (DbManagerProxy avrManager = DbManagerFactory.Factory[DatabaseType.Avr].Create())
                {
                    avrDbName = GetDatabaseName(avrManager);
                }
            }
            catch (Exception ex)
            {
                string message = EidssMessages.Get("msgAvrServiceDbError", "AVR Service could not connect to AVR Service Database");
                throw new AvrDataException(message, ex);
            }

            return new DatabaseNames(eidssActualDbName, eidssArchiveDbName, avrDbName);
        }

        private static string GetDatabaseName(DbManagerProxy manager)
        {
            return manager != null && manager.Connection != null
                ? manager.Connection.Database
                : string.Empty;
        }

        public static List<long> GetQueryIdList()
        {
            List<long> result = GetValueList<long>("spAsQuerySelectLookup", "idflQuery");
            return result;
        }

        public static List<long> GetLayoutIdList()
        {
            List<long> result = GetValueList<long>("spAsLayoutSelectLookup", "idflLayout");
            return result;
        }

        private static List<T> GetValueList<T>(string spLookupName, string idColumnName)
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
            {
                DbManager command = manager.SetSpCommand(spLookupName, manager.Parameter("LangID", Localizer.lngEn));
                using (IDataReader reader = command.ExecuteReader())
                {
                    var result = new List<T>();
                    while (reader.Read())
                    {
                        var item = (T) reader[idColumnName];
                        result.Add(item);
                    }
                    return result;
                }
            }
        }

        public static string GetLayoutNameForLog(long id)
        {
            return GetValue("spAsLayoutSelectLookup", "LayoutID", id, "strDefaultLayoutName");
        }

        public static string GetQueryNameForLog(long id)
        {
            return GetValue("spAsQuerySelectLookup", "QueryID", id, "DefQueryName");
        }

        private static string GetValue(string spLookupName, string idName, long idValue, string valueColumnName)
        {
            try
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
                {
                    DbManager command = manager.SetSpCommand(spLookupName,
                        manager.Parameter("LangID", Localizer.lngEn),
                        manager.Parameter(idName, idValue));
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        return reader.Read()
                            ? Utils.Str(reader[valueColumnName])
                            : string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public static LayoutDTO GetLayoutDTO(long layoutId)
        {
            LayoutDTO dto = new LayoutDTO(layoutId);
            try
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
                {
                    DbManager command = manager.SetSpCommand("spAsLayoutSelectLookup",
                        manager.Parameter("LangID", Localizer.lngEn),
                        manager.Parameter("LayoutID", layoutId));
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            dto.DefaultLayoutName = reader["strDefaultLayoutName"].ToString();
                            dto.QueryId = (long) reader["idflQuery"];
                            dto.UseArchivedData = (bool) reader["blnUseArchivedData"];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                dto.DefaultLayoutName = ex.ToString();
            }
            return dto;
        }
    }
}