using DevExpress.XtraPivotGrid;
using eidss.model.Avr.Pivot;

namespace eidss.avr.db.AvrEventArgs.DevExpressEventArgsWrappers
{
    public abstract class BasePivotGridCellBaseEventArgs
    {
        public delegate BasePivotGridCellBaseEventArgs GetCellInfoDelegate(int columnIndex, int rowIndex);

        public double DoubleValue
        {
            get { return ValueConverter.ConvertValueToDouble(Value); }
        }

        public abstract bool IsWeb { get; }

        public abstract object Value { get; }

        public abstract bool Selected { get; }

        public abstract bool Focused { get; }

        public abstract PivotGridFieldBase DataField { get; }

        public abstract PivotDrillDownDataSource CreateDrillDownDataSource();

        public abstract object GetFieldValue(PivotGridFieldBase idFieldBase);
    }
}