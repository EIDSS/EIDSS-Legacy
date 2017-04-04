using System;
using System.Collections.Generic;
using System.Threading;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.common.Configuration;

namespace eidss.model.Core
{
    public static class LookupCacheListener
    {
        private static Timer m_Timer;
        private static long m_TimerInterval = 1000;

        public static void Listen()
        {
            if (m_Timer == null)
            {
                m_Timer = new Timer(TimerCallback, null, Timeout.Infinite, Timeout.Infinite);
            }
            m_Timer.Change(0, Timeout.Infinite);
        }
        public static void Stop()
        {
            if (m_Timer != null)
            {
                m_Timer.Change(Timeout.Infinite, Timeout.Infinite);
            }
        }
        public static void Cleanup()
        {
            GetModifiedLookupTables();
        }


        private static void TimerCallback(object state)
        {
            m_Timer.Change(Timeout.Infinite, Timeout.Infinite);
            try
            {
                var list = GetModifiedLookupTables();
                if (list != null)
                {
                    if (list.Count > 0)
                    {
                        foreach (var t in list)
                        {
                            LookupManager.ClearByTable(t);
                            LookupManager.ClearByTable("rft" + t);
                        }
                        LookupManager.ClearAndReloadOnIdle();
                    }
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                m_Timer.Change(m_TimerInterval, Timeout.Infinite);
            }
        }

        private static List<string> GetModifiedLookupTables()
        {
            if (!BaseSettings.SuppressGettingModifiedLookupTables)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    try
                    {
                        return manager.SetSpCommand("dbo.spLookupTables_GetModified", ModelUserContext.ClientID).ExecuteScalarList<string>();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            return null;
        }
    }
}