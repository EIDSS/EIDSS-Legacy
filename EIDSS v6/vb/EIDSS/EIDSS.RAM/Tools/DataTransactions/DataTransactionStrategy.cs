using bv.common.Core;
using DevExpress.XtraPivotGrid.Data;

namespace eidss.avr.Tools.DataTransactions
{
    public class DataTransactionStrategy : IDataTransactionStrategy
    {
        private PivotGridData m_Data;
        private DataTransaction m_CurrentTransaction;

        public delegate void EndTransactionHandler();

        public DataTransaction BeginTransaction(PivotGridData data)
        {
            if (m_CurrentTransaction == null)
            {
                Utils.CheckNotNull(data, "data");
                m_Data = data;
                m_CurrentTransaction = new DataTransaction(delegate { m_CurrentTransaction = null; }, m_Data);
                return m_CurrentTransaction;
            }
            return new DataTransaction();
        }
    }
}