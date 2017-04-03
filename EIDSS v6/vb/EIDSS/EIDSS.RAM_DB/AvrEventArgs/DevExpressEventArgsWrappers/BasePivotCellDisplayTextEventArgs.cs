using DevExpress.XtraPivotGrid;
using eidss.avr.db.Common;

namespace eidss.avr.db.AvrEventArgs.DevExpressEventArgsWrappers
{
    public abstract class BasePivotCellDisplayTextEventArgs
    {
        public abstract bool IsWeb { get; }
        public abstract object Value { get; }
        public abstract PivotGroupInterval GroupInterval { get;  }
        public abstract bool IsDataFieldNull { get; }
        public abstract int ColumnIndex { get; }
        public abstract int RowIndex { get; }
        public abstract string DisplayText { get; set; }

        public abstract object GetCellValue(int columnIndex, int rowIndex);
    }
} ;