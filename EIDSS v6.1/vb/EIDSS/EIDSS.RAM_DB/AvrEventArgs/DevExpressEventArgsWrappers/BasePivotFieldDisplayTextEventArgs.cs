using DevExpress.XtraPivotGrid;

namespace eidss.avr.db.AvrEventArgs.DevExpressEventArgsWrappers
{
    public abstract class BasePivotFieldDisplayTextEventArgs
    {
        public abstract bool IsWeb { get; }

        public abstract object Value { get; }

        public abstract bool IsPopulatingFilterDropdown { get; }

        public abstract bool IsColumn { get; }

        public abstract PivotGridFieldBase DataField { get; }

        public abstract PivotGridValueType ValueType { get; }

        public abstract string DisplayText { get; set; }
    }
} ;