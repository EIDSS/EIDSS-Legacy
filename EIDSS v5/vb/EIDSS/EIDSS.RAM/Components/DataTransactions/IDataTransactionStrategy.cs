using DevExpress.XtraPivotGrid.Data;

namespace EIDSS.RAM.Components.DataTransactions
{
    public interface IDataTransactionStrategy
    {
        DataTransaction BeginTransaction(PivotGridData data);
    }
}