using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using bv.common;
using bv.common.Core;
using bv.common.db.Core;

namespace eidss.avr.db.DBService.DataTableCopier
{
    public class DataTableCopierMultiThread : IDataTableCopier
    {
        public const int MaxCopies = 1;
        private const int JoinTimeout = 20000;
        private const int WaitTimeout = 40000;

        private DataTable m_SourceTable;
        private bool m_Disposed;
        private readonly Queue<DataTable> m_Queue = new Queue<DataTable>();
        private readonly object m_SyncLock = new object();
        private volatile bool m_IsOutOfMemory;
        private readonly Thread m_Worker;
        private readonly AutoResetEvent m_Go = new AutoResetEvent(false);
        private readonly AutoResetEvent m_Ready = new AutoResetEvent(false);

        internal DataTableCopierMultiThread(DataTable sourceTable)
        {
            Utils.CheckNotNull(sourceTable, "sourceTable");
            m_SourceTable = sourceTable;
            m_Worker = new Thread(Work) {Name = "DataTableCopierThread", IsBackground = true};
        }

        public void Dispose()
        {
            try
            {
                m_SourceTable = null;
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

        public DataTable GetCopy()
        {
            ForceStart();

            //  return m_SourceTable.Copy();

            while (m_Ready.WaitOne(WaitTimeout))
            {
                DataTable copy = null;
                lock (m_SyncLock)
                {
                    if (m_Queue.Count > 0)
                    {
                        copy = m_Queue.Dequeue();
                    }
                }
                m_Go.Set();
                if (copy != null)
                {
                    return copy;
                }
            }

            throw new AvrException("Could not get datasource copy for layout");
        }

        public DataTable GetClone()
        {
            return m_SourceTable.Clone();
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
                        DataTable copy;
                        try
                        {
                            copy = m_SourceTable.Copy();
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
                                DbDisposeHelper.DisposeTable(ref copy, true);
                            }
                        }
                        m_Ready.Set();
                    }
                    else
                    {
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