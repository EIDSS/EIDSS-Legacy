using bv.common.Core;
using DevExpress.Data.PivotGrid;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraPivotGrid.Data;
using eidss.avr.db.AvrEventArgs.DevExpressEventArgsWrappers;
using eidss.avr.db.Common;
using eidss.avr.PivotComponents;

namespace eidss.avr.Handlers.DevExpressEventArgsWrappers
{
    public class WinPivotGridCustomSummaryEventArgs : BasePivotGridCustomSummaryEventArgs
    {
        private readonly PivotGridCustomSummaryEventArgsBase<PivotGridField> m_WinEventArgs;

        public WinPivotGridCustomSummaryEventArgs(PivotGridCustomSummaryEventArgsBase<PivotGridField> winEventArgs)
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

        public override PivotGridFieldBase RowField
        {
            get { return m_WinEventArgs.RowField; }
        }

        public override PivotSummaryValue SummaryValue
        {
            get { return m_WinEventArgs.SummaryValue; }
        }

        public override bool IsDataFieldNumeric
        {
            get { return ((IAvrPivotGridField)DataField).IsNumeric; }
        }

        public override PivotDrillDownDataSource CreateDrillDownDataSource()
        {
            return m_WinEventArgs.CreateDrillDownDataSource();
        }
    }
}