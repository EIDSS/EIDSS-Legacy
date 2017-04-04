using System.ComponentModel;
using DevExpress.Data.PivotGrid;
using DevExpress.XtraPivotGrid;
using eidss.model.Avr.Pivot;

namespace eidss.avr.db.AvrEventArgs.DevExpressEventArgsWrappers
{
    public abstract class BasePivotGridCustomSummaryEventArgs
    {
        public abstract bool IsWeb { get; }

        [Description("Gets or sets a custom summary value.")]
        public abstract object CustomValue { get; set; }

        [Description("Gets the data field against which the summary is calculated.")]
        public abstract PivotGridFieldBase DataField { get; }

        [Description("Gets the column field which corresponds to the current cell.")]
        public abstract PivotGridFieldBase ColumnField { get; }

        [Description("Gets the value of the column field that corresponds to the current cell.")]
        public abstract object ColumnFieldValue { get; }

        [Description("Gets the row field which corresponds to the current cell.")]
        public abstract PivotGridFieldBase RowField { get; }

        [Description("Gets the value of the row field that corresponds to the current cell.")]
        public abstract object RowFieldValue { get; }

        [Description("Gets an object that contains the values of the predefined summaries which are calculated for the current cell.")]
        public abstract PivotSummaryValue SummaryValue { get; }

        [Description("Returns a list of the records that are associated with the cell currently being processed.")]
        public abstract PivotDrillDownDataSource CreateDrillDownDataSource();

        public abstract bool IsDataFieldNumeric { get; }

        public abstract CustomSummaryType AggregateFunction { get; }

        public abstract CustomSummaryType BasicCountFunctions { get; }
    }
}