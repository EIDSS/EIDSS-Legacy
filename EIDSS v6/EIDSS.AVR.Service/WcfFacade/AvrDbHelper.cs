using System;
using System.Collections.Generic;
using System.Data;
using BLToolkit.Data;
using bv.common.Configuration;
using bv.common.Core;
using bv.model.BLToolkit;
using eidss.model.AVR.Db;
using eidss.model.AVR.ServiceData;
using eidss.model.Resources;
using eidss.model.WindowsService.Serialization;

namespace EIDSS.AVR.Service.WcfFacade
{
    public static class AvrDbHelper
    {
        private static readonly object m_DbSyncLock = new object();

        public static long? GetTableId
            (long queryId, string lang, bool isArchive, int refresheAfterDays = 7, bool allowSelectInvalidated = false)
        {
            return GetTableId(new QueryCacheKey(queryId, lang, isArchive), refresheAfterDays, allowSelectInvalidated);
        }

        public static long? GetTableId(QueryCacheKey queryCacheKey, int refresheAfterDays = 7, bool allowSelectInvalidated = false)
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

        public static QueryTableHeaderDTO GetTableHeader(long queryCacheId, bool isSchedulerCall, bool isArchive)
        {
            using (var avrTran = new AvrDbTransaction())
            {
                DbManagerProxy manager = avrTran.Manager;
                DbManager command = manager.SetSpCommand("spAsQueryCacheGetHeader",
                    manager.Parameter("idfQueryCache", queryCacheId),
                    manager.Parameter("blnSchedulerCall", isSchedulerCall),
                    manager.Parameter("blnUseArchivedData", isArchive));

                var headerPacket = new QueryTablePacketDTO {IsArchive = isArchive};
                int packetCount = 0;
                lock (m_DbSyncLock)
                {
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            packetCount = (int) reader["intPacketCount"];
                            headerPacket.RowCount = (int) reader["intQueryColumnCount"];
                            headerPacket.BinaryBody = (byte[]) reader["blbQuerySchema"];
                        }
                    }

                    avrTran.CommitTransaction();
                }
                return new QueryTableHeaderDTO(headerPacket, queryCacheId, packetCount);
            }
        }

        public static QueryTablePacketDTO GetTablePacket(long queryCacheId, int packetNumber)
        {
            using (var avrTran = new AvrDbTransaction())
            {
                DbManager command = avrTran.Manager.SetSpCommand("spAsQueryCacheGetPacket",
                    avrTran.Manager.Parameter("idfQueryCache", queryCacheId),
                    avrTran.Manager.Parameter("intQueryCachePacketNumber", packetNumber));

                var result = new QueryTablePacketDTO();
                using (IDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result.RowCount = (int) reader["intTableRowCount"];
                        result.BinaryBody = (byte[]) reader["blbQueryCachePacket"];
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
                        manager.Parameter("blbQuerySchema", zippedTable.Header.BinaryBody),
                        manager.Parameter("blnUseArchivedData", zippedTable.UseArchivedData)
                        );

                    var queryCasheId = (long) headerCommand.ExecuteScalar();
                    for (int i = 0; i < zippedTable.BodyPackets.Count; i++)
                    {
                        DbManager command = manager.SetSpCommand("spAsQueryCachePostPacket",
                            manager.Parameter("idfQueryCache", queryCasheId),
                            manager.Parameter("intQueryCachePacketNumber", i),
                            manager.Parameter("intPacketRowCount", zippedTable.BodyPackets[i].RowCount),
                            manager.Parameter("blbQueryCachePacket", zippedTable.BodyPackets[i].BinaryBody),
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

        public static QueryTableModel GetQueryResult(long queryId, string lang, bool isArchive)
        {
            string queryString;
            QueryTableModel zippedTable;

            using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
            {
                queryString = QueryHelper.GetQueryText(manager, queryId, false);

                QueryTableModel serializedTable = QueryHelper.GetInnerQueryResult(manager, queryString, lang,
                    c => BinarySerializer.SerializeFromCommand(c, queryId, lang, false));
                zippedTable = BinaryCompressor.Zip(serializedTable);
            }

            if (isArchive)
            {
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
                var credentials = new ConnectionCredentials(null, "Archive");
                if (credentials.IsCorrect)
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
            return GetIdList("spAsQuerySelectLookup", "idflQuery");
        }

        public static List<long> GetLayoutIdList()
        {
            return GetIdList("spAsLayoutSelectLookup", "idflLayout");
        }

        private static List<long> GetIdList(string spLookupName, string idColumnName)
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
            {
                DbManager command = manager.SetSpCommand(spLookupName, manager.Parameter("LangID", Localizer.lngEn));
                using (IDataReader reader = command.ExecuteReader())
                {
                    var result = new List<long>();
                    while (reader.Read())
                    {
                        result.Add((long) reader[idColumnName]);
                    }
                    return result;
                }
            }
        }
    }
}