using System;
using System.Collections.Generic;
using System.Threading;
using bv.model.BLToolkit;
using bv.model.Model.Core;

namespace eidss.model.Core
{
    public static class FiltrationManager
    {
        private static bool m_bFiltration;
        private static readonly Queue<long> m_DataAuditEvents = new Queue<long>();
        private static readonly AutoResetEvent m_Event = new AutoResetEvent(false);
        private static readonly AutoResetEvent m_CloseEvent = new AutoResetEvent(false);

        private static void DoFiltration()
        {
            if (!m_bFiltration)
            {
                m_bFiltration = true;
                ThreadPool.QueueUserWorkItem(c =>
                    {
                        var waitHandles = new WaitHandle[] {m_CloseEvent, m_Event};
                        while (WaitHandle.WaitAny(waitHandles) != 0)
                        {
                            long id = 0;
                            lock (m_DataAuditEvents)
                            {
                                if (m_DataAuditEvents.Count > 0)
                                    id = m_DataAuditEvents.Dequeue();
                            }

                            if (id != 0)
                            {
                                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                                {
                                    try
                                    {
                                        manager.SetSpCommand("dbo.spFiltered_CheckEvent", id).ExecuteNonQuery();
                                    }
                                    catch (Exception)
                                    {
                                        // TODO add error handling here
                                    }
                                }
                            }

                            lock (m_DataAuditEvents)
                            {
                                if (m_DataAuditEvents.Count > 0)
                                    m_Event.Set();
                                else
                                    m_CloseEvent.Set();
                            }
                        }

                        m_bFiltration = false;
                        return;
                    }, null);
            }
        }

        public static void AddAuditEvent(long id)
        {
            lock (m_DataAuditEvents)
            {
                m_DataAuditEvents.Enqueue(id);
                m_Event.Set();
                DoFiltration();
            }
        }
    }
}