using System.ComponentModel;
using DevExpress.Data.PivotGrid;
using DevExpress.XtraPivotGrid;

namespace eidss.avr.db.AvrEventArgs.DevExpressEventArgsWrappers
{
    public abstract class BasePivotGridCustomSummaryEventArgs
    {
        public abstract bool IsWeb { get; }

        public abstract object CustomValue { get; set; }

        [Description("Gets the data field against which the summary is calculated.")]
        public abstract PivotGridFieldBase DataField { get; }

        [Description("Gets the column field which corresponds to the current cell.")]
        public abstract PivotGridFieldBase ColumnField { get; }

        [Description("Gets the row field which corresponds to the current cell.")]
        public abstract PivotGridFieldBase RowField { get; }

        public abstract PivotSummaryValue SummaryValue { get; }

        public abstract bool IsDataFieldNumeric { get; }

        public abstract PivotDrillDownDataSource CreateDrillDownDataSource();
    }
}