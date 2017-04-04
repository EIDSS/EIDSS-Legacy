using System;
using bv.common.Core;
using eidss.avr.db.CacheReceiver;
using eidss.avr.db.Common;
using eidss.model.AVR.SourceData;

namespace eidss.avr.db.DBService.DataTableCopier
{
    public class AvrDataTableCopier : IDisposable
    {
        private readonly object m_SyncLock = new object();

        private CachedQueryResult m_SourceQueryResult;
        private AvrDataTable m_ClonedTable;
        private bool m_Disposed;

        public AvrDataTableCopier() : this(new CachedQueryResult(-1, new AvrDataTable()))
        {
        }

        public AvrDataTableCopier(CachedQueryResult sourceQueryResult)
        {
            Utils.CheckNotNull(sourceQueryResult, "sourceQueryResult");
            m_SourceQueryResult = sourceQueryResult;
            if (m_SourceQueryResult.HasTable)
            {
                m_ClonedTable = m_SourceQueryResult.QueryTable.Clone();
            }
        }

        public AvrDataTable GetCopy(string filter)
        {
            lock (m_SyncLock)
            {
                if (m_Disposed)
                {
                    throw new ObjectDisposedException("DataTableCopier");
                }
                long queryId = m_SourceQueryResult.QueryId;
                AvrDataTable result;

                if (m_SourceQueryResult.HasTable)
                {
                    if (m_SourceQueryResult.HasZippedSource)
                    {
                        result = m_SourceQueryResult.QueryTable;
                        m_SourceQueryResult =
                            new CachedQueryResult(queryId, m_SourceQueryResult.QueryHeader, m_SourceQueryResult.QueryPackets);
                    }
                    else
                    {
                        result = m_SourceQueryResult.QueryTable.Copy();
                    }
                }
                else
                {
                    if (m_SourceQueryResult.HasZippedSource)
                    {
                        var converter = new AvrCacheConverter();
                        CachedQueryResult copyResult
                            = converter.GetCachedQueryTable(queryId, m_SourceQueryResult.QueryHeader,
                                m_SourceQueryResult.QueryPackets, filter);
                        
                        result = copyResult.QueryTable;

                        result.TableName = QueryProcessor.GetQueryName(queryId);
                        QueryProcessor.SetCopyPropertyForColumnsIfNeeded(result);
                        QueryProcessor.TranslateTableFields(result, queryId);
                        QueryProcessor.SetNullForForbiddenTableFields(result, queryId);
                        QueryProcessor.RemoveNotExistingColumns(result, queryId, false);
                    }
                    else
                    {
                        result = new AvrDataTable();
                    }
                }
                return result;
            }
        }

        public AvrDataTable GetClone()
        {
            lock (m_SyncLock)
            {
                if (m_Disposed)
                {
                    throw new ObjectDisposedException("DataTableCopier");
                }

                if (m_ClonedTable != null)
                {
                    return m_ClonedTable.Clone();
                }
                return new AvrDataTable();
            }
        }

        public void Dispose()
        {
            lock (m_SyncLock)
            {
                m_SourceQueryResult = null;
                m_ClonedTable = null;
                m_Disposed = true;
            }
        }
    }
}