using System;
using bv.common.Core;
using DevExpress.XtraPivotGrid.Data;

namespace EIDSS.RAM.Components.DataTransactions
{
    public class DataTransaction : IDisposable
    {
        private readonly PivotGridData m_Data;
        private readonly DataTransactionStrategy.EndTransactionHandler m_EndTransactionHandler;

        public DataTransaction()
        {
        }

        public DataTransaction(DataTransactionStrategy.EndTransactionHandler endTransactionHandler, PivotGridData data)
        {
            Utils.CheckNotNull(data, "data");
            m_Data = data;
            m_EndTransactionHandler = endTransactionHandler;

            m_Data.BeginUpdate();
        }

        public bool HasData
        {
            get { return m_Data != null; }
        }

        public void Dispose()
        {
            if (m_Data != null)
            {
                m_Data.EndUpdate();
            }
            if (m_EndTransactionHandler != null)
            {
                m_EndTransactionHandler();
            }
        }
    }
}