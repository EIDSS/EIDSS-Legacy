using System;
using System.Collections.Generic;
using System.Threading;
using bv.common;
using bv.common.Core;
using eidss.avr.db.CacheReceiver;
using eidss.avr.db.Common;
using eidss.model.AVR.SourceData;

namespace eidss.avr.db.DBService.DataTableCopier
{
    public class AvrDataTableCopierMultiThread :IDisposable
    {
        public const int MaxCopies = 1;
        private const int JoinTimeout = 20000;
        private const int WaitTimeout = 60000;
        private bool m_Continued;

        private readonly object m_SyncLock = new object();
        private readonly AutoResetEvent m_Go = new AutoResetEvent(false);
        private readonly AutoResetEvent m_Ready = new AutoResetEvent(false);
        private readonly Thread m_Worker;

        private CachedQueryResult m_SourceQueryResult;
        private readonly AvrDataTable m_ClonedTable;
        private readonly Queue<AvrDataTable> m_Queue = new Queue<AvrDataTable>();
        private bool m_Disposed;
        private volatile bool m_IsOutOfMemory;

        internal AvrDataTableCopierMultiThread(CachedQueryResult sourceQueryResult)
        {
            Utils.CheckNotNull(sourceQueryResult, "sourceQueryResult");
            m_SourceQueryResult = sourceQueryResult;

            lock (m_SyncLock)
            {
                if (m_SourceQueryResult.HasTable)
                {
                    m_ClonedTable = m_SourceQueryResult.QueryTable.Clone();
                    if (m_SourceQueryResult.HasZippedSource)
                    {
                        m_Queue.Enqueue(m_SourceQueryResult.QueryTable);
                        m_SourceQueryResult = new CachedQueryResult(m_SourceQueryResult.QueryId,
                            m_SourceQueryResult.QueryHeader, m_SourceQueryResult.QueryPackets);
                    }
                }
            }

            m_Worker = new Thread(Work) {Name = "DataTableCopierThread", IsBackground = true};
        }

        public void Dispose()
        {
            try
            {
                m_SourceQueryResult = null;
                m_Disposed = true;

                if (!m_Worker.IsAlive)
                {
                    return;
                }
                m_Go.Set();
                if (!m_Worker.Join(JoinTimeout))
                {
                    m_Worker.Abort();
                }
                m_Go.Close();
                m_Ready.Close();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
            }
        }

        public bool IsOutOfMemory
        {
            get { return m_IsOutOfMemory; }
        }

        public int QueueCount
        {
            get
            {
                lock (m_SyncLock)
                {
                    return m_Queue.Count;
                }
            }
        }

        public void ForceStart()
        {
            if (m_Disposed)
            {
                throw new ObjectDisposedException("DataTableCopier");
            }
            if ((m_Worker.ThreadState & ThreadState.Unstarted) != 0)
            {
                m_Worker.Start();
            }
        }

        public AvrDataTable GetClone()
        {
            ForceStart();

            lock (m_SyncLock)
            {
                if (m_ClonedTable != null)
                {
                    return m_ClonedTable.Clone();
                }
                return new AvrDataTable();
            }
        }

        public AvrDataTable GetCopy()
        {
            ForceStart();

            lock (m_SyncLock)
            {
                if (m_Queue.Count == 0 && !m_Continued)
                {
                    m_Go.Set();
                    m_Continued = true;
                }
            }

            while (m_Ready.WaitOne(WaitTimeout))
            {
                AvrDataTable copy = null;
                lock (m_SyncLock)
                {
                    if (m_Queue.Count > 0)
                    {
                        copy = m_Queue.Dequeue();
                    }
                }
                //  m_Go.Set();
                if (copy != null)
                {
                    return copy;
                }
            }

            throw new AvrException("Could not get datasource copy for layout");
        }

        public void Continue()
        {
            lock (m_SyncLock)
            {
                if (!m_Continued)
                {
                    m_Go.Set();
                    m_Continued = true;
                }
            }
        }

        private void Work()
        {
            try
            {
                while (true)
                {
                    if (m_Disposed)
                    {
                        return;
                    }

                    if (QueueCount < MaxCopies)
                    {
                        //DataTable.Copy() operation is too long, so we cannot put it into lock
                        AvrDataTable copy;
                        try
                        {
                            long queryId = m_SourceQueryResult.QueryId;
                            if (m_SourceQueryResult.HasTable)
                            {
                                copy = m_SourceQueryResult.QueryTable.Copy();
                            }
                            else
                            {
                                if (m_SourceQueryResult.HasZippedSource)
                                {
                                    var converter = new AvrCacheConverter();
                                    CachedQueryResult copyResult = 
                                        converter.GetCachedQueryTable(queryId,m_SourceQueryResult.QueryHeader, m_SourceQueryResult.QueryPackets, string.Empty);
                                    copy = copyResult.QueryTable;

                                    copy.TableName = QueryProcessor.GetQueryName(queryId);
                                    QueryProcessor.SetCopyPropertyForColumnsIfNeeded(copy);
                                    QueryProcessor.TranslateTableFields(copy, queryId);
                                    QueryProcessor.SetNullForForbiddenTableFields(copy, queryId);
                                    QueryProcessor.RemoveNotExistingColumns(copy, queryId, false);
                                }
                                else
                                {
                                    copy = new AvrDataTable();
                                }
                            }

                            m_IsOutOfMemory = false;
                        }
                        catch (OutOfMemoryException)
                        {
                            copy = GetClone();
                            m_IsOutOfMemory = true;
                        }

                        lock (m_SyncLock)
                        {
                            //need to check again
                            if (QueueCount < MaxCopies)
                            {
                                m_Queue.Enqueue(copy);
                            }
                            else
                            {
                                copy.Clear();
                                //DbDisposeHelper.DisposeTable(ref copy, true);
                            }
                        }
                        m_Ready.Set();
                    }
                    else
                    {
                        lock (m_SyncLock)
                        {
                            m_Continued = false;
                        }
                        m_Ready.Set();
                        m_Go.WaitOne();
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
            }
        }
    }
}