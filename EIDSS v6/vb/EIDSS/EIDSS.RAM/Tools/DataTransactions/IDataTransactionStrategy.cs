using DevExpress.XtraPivotGrid.Data;

namespace eidss.avr.Tools.DataTransactions
{
    public interface IDataTransactionStrategy
    {
        DataTransaction BeginTransaction(PivotGridData data);
    }
}