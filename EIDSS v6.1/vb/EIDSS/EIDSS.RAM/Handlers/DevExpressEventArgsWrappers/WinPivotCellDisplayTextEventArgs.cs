using bv.common.Core;
using DevExpress.XtraPivotGrid;
using eidss.avr.db.AvrEventArgs.DevExpressEventArgsWrappers;

namespace eidss.avr.Handlers.DevExpressEventArgsWrappers
{
    public class WinPivotCellDisplayTextEventArgs : BasePivotCellDisplayTextEventArgs
    {
        private readonly PivotCellDisplayTextEventArgs m_WinEventArgs;

        public WinPivotCellDisplayTextEventArgs(PivotCellDisplayTextEventArgs winEventArgs)
        {
            Utils.CheckNotNull(winEventArgs, "winEventArgs");
            m_WinEventArgs = winEventArgs;
        }

        public override bool IsWeb
        {
            get { return false; }
        }

        public override object Value
        {
            get { return m_WinEventArgs.Value; }
        }

        public override PivotGroupInterval GroupInterval
        {
            get
            {
                return m_WinEventArgs.DataField != null
                    ? m_WinEventArgs.DataField.GroupInterval
                    : PivotGroupInterval.DateMonth;
            }
        }

        public override bool IsDataFieldNull
        {
            get { return m_WinEventArgs.DataField == null; }
        }

        public override int ColumnIndex
        {
            get { return m_WinEventArgs.ColumnIndex; }
        }

        public override int RowIndex
        {
            get { return m_WinEventArgs.RowIndex; }
        }

        public override string DisplayText
        {
            get { return m_WinEventArgs.DisplayText; }
            set { m_WinEventArgs.DisplayText = value; }
        }

        public override bool HasDrillDownDataSource
        {
            get
            {
                PivotDrillDownDataSource dataSource = m_WinEventArgs.CreateDrillDownDataSource();
                return dataSource.RowCount > 0;
            }
        }

        public override object GetCellValue(int columnIndex, int rowIndex)
        {
            return m_WinEventArgs.GetCellValue(columnIndex, rowIndex);
        }
    }
}