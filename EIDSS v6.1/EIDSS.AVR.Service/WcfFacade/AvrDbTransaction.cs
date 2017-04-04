using System;
using bv.model.BLToolkit;

namespace EIDSS.AVR.Service.WcfFacade
{
    public class AvrDbTransaction : IDisposable
    {
        private readonly DbManagerProxy m_Manager;
        private bool m_NeedCommit;

        public AvrDbTransaction()
        {
            m_Manager = DbManagerFactory.Factory[DatabaseType.Avr].Create();
            m_NeedCommit = !m_Manager.IsTransactionStarted;
            if (m_NeedCommit)
            {
                m_Manager.BeginTransaction();
            }
        }

        public DbManagerProxy Manager
        {
            get { return m_Manager; }
        }

        public bool NeedCommit
        {
            get { return m_NeedCommit; }
        }

        public void CommitTransaction()
        {
            if (m_NeedCommit)
            {
                m_Manager.CommitTransaction();
                m_NeedCommit = false;
            }
        }

        public void RollbackTransaction()
        {
            if (m_NeedCommit)
            {
                m_Manager.RollbackTransaction();
                m_NeedCommit = false;
            }
        }

        public void Dispose()
        {
            if (m_NeedCommit)
            {
                m_Manager.RollbackTransaction();
            }
            m_Manager.Dispose();
        }
    }
}