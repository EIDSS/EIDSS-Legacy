using bv.common.Core;
using DevExpress.Data.PivotGrid;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraPivotGrid.Data;
using eidss.avr.db.AvrEventArgs.DevExpressEventArgsWrappers;
using eidss.avr.db.Common;
using eidss.model.Avr.Pivot;

namespace eidss.avr.Handlers.DevExpressEventArgsWrappers
{
    public class WinPivotGridCustomSummaryEventArgs : BasePivotGridCustomSummaryEventArgs
    {
        private readonly PivotGridCustomSummaryEventArgsBase<PivotGridField> m_WinEventArgs;

        public WinPivotGridCustomSummaryEventArgs
            (PivotGridCustomSummaryEventArgsBase<PivotGridField> winEventArgs)
        {
            Utils.CheckNotNull(winEventArgs, "winEventArgs");
            m_WinEventArgs = winEventArgs;
        }

        public override bool IsWeb
        {
            get { return false; }
        }

        public override object CustomValue
        {
            get { return m_WinEventArgs.CustomValue; }
            set { m_WinEventArgs.CustomValue = value; }
        }

        public override PivotGridFieldBase DataField
        {
            get { return m_WinEventArgs.DataField; }
        }

        public override PivotGridFieldBase ColumnField
        {
            get { return m_WinEventArgs.ColumnField; }
        }

        public override object ColumnFieldValue
        {
            get { return m_WinEventArgs.ColumnFieldValue; }
        }

        public override PivotGridFieldBase RowField
        {
            get { return m_WinEventArgs.RowField; }
        }

        public override object RowFieldValue
        {
            get { return m_WinEventArgs.RowFieldValue; }
        }

        public override PivotSummaryValue SummaryValue
        {
            get { return m_WinEventArgs.SummaryValue; }
        }

        public override bool IsDataFieldNumeric
        {
            get { return ((IAvrPivotGridField) DataField).IsNumeric; }
        }

        public override CustomSummaryType AggregateFunction
        {
            get { return (CustomSummaryType)((IAvrPivotGridField)DataField).AggregateFunctionId; }
        }

        public override CustomSummaryType BasicCountFunctions
        {
            get { return (CustomSummaryType)((IAvrPivotGridField)DataField).BasicCountFunctionId; }
        }

        public override PivotDrillDownDataSource CreateDrillDownDataSource()
        {
            return m_WinEventArgs.CreateDrillDownDataSource();
        }
    }
}