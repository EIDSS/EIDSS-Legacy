using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using bv.common;
using bv.common.Core;
using bv.common.db.Core;

namespace EIDSS.RAM_DB.Common
{
    public class DataTableCopier : IDisposable
    {
        public const int MaxCopies = 1;
        private const int JoinTimeout = 20000;
        private const int WaitTimeout = 30000;
        
        private DataTable m_SourceTable;
        private bool m_Disposed;
        private readonly Queue<DataTable> m_Queue = new Queue<DataTable>();
        private readonly object m_SyncLock = new object();
        private readonly Thread m_Worker;
        private readonly AutoResetEvent m_Go = new AutoResetEvent(false);
        private readonly AutoResetEvent m_Ready = new AutoResetEvent(false);

        public DataTableCopier(DataTable sourceTable)
        {
            Utils.CheckNotNull(sourceTable, "sourceTable");
            m_SourceTable = sourceTable;
            m_Worker = new Thread(Work) { Name = "DataTableCopierThread", IsBackground = true };
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
            //return m_SourceTable.Copy();
            ForceStart();

            if (m_Ready.WaitOne(WaitTimeout))
            {
                DataTable copy;
                lock (m_SyncLock)
                {
                    copy = m_Queue.Dequeue();
                }
                m_Go.Set();
                return copy;
            }
            
            throw new RamException("Could not get datasource copy for layout");
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
                        DataTable copy = m_SourceTable.Copy();
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