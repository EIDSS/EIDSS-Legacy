//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Threading;
//using bv.common;
//using bv.common.db.Core;
//
//namespace EIDSS.RAM_DB.Common
//{
//    public class DataTableCleaner : IDisposable
//    {
//        private const int JoinTimeout = 20000;
//        private readonly object m_SyncLock = new object();
//        private readonly Queue<DataTable> m_Queue = new Queue<DataTable>();
//        private readonly Thread m_Worker;
//        private readonly AutoResetEvent m_WaitHandle = new AutoResetEvent(false);
//        
//        public DataTableCleaner()
//        {
//            m_Worker = new Thread(Work) {Name = "DataTableCleanerThread", IsBackground = true};
//            m_Worker.Start();
//        }
//
//
//        public int QueueCount
//        {
//            get
//            {
//                lock (m_SyncLock)
//                {
//                    return m_Queue.Count;
//                }
//            }
//        }
//
//        public void Enqueue(DataTable table)
//        {
//            lock (m_SyncLock)
//            {
//                m_Queue.Enqueue(table);
//            }
//            m_WaitHandle.Set();
//        }
//
//        public void Dispose()
//        {
//            try
//            {
//                if (!m_Worker.IsAlive)
//                {
//                    return;
//                }
//
//                Enqueue(null);
//
//                if (!m_Worker.Join(JoinTimeout))
//                {
//                    m_Worker.Abort();
//                }
//                m_WaitHandle.Close();
//            }
//            catch (Exception ex)
//            {
//                Trace.WriteLine(ex);
//            }
//        }
//
//        private void Work()
//        {
//            try
//            {
//                while (true)
//                {
//                    DataTable table = null;
//                    lock (m_SyncLock)
//                    {
//                        if (QueueCount > 0)
//                        {
//                            table = m_Queue.Dequeue();
//                            // end work when receive null
//                            if (table == null)
//                            {
//                                return;
//                            }
//                        }
//                    }
//
//                    if (table == null)
//                    {
//                        m_WaitHandle.WaitOne();
//                    }
//                    else
//                    {
//                        lock (table)
//                        {
//                            DbDisposeHelper.DisposeTable(ref table, true);
//                        }
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                Trace.WriteLine(ex);
//            }
//        }
//    }
//}