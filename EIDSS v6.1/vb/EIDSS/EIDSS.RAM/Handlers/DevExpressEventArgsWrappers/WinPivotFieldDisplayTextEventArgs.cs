using bv.common.Core;
using DevExpress.XtraPivotGrid;
using eidss.avr.db.AvrEventArgs.DevExpressEventArgsWrappers;

namespace eidss.avr.Handlers.DevExpressEventArgsWrappers
{
    public class WinPivotFieldDisplayTextEventArgs : BasePivotFieldDisplayTextEventArgs
    {
        private readonly PivotFieldDisplayTextEventArgs m_WinEventArgs;

        public WinPivotFieldDisplayTextEventArgs(PivotFieldDisplayTextEventArgs winEventArgs)
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

        public override bool IsPopulatingFilterDropdown
        {
            get { return m_WinEventArgs.IsPopulatingFilterDropdown; }
        }

        public override bool IsColumn
        {
            get { return m_WinEventArgs.IsColumn; }
        }

        public override PivotGridFieldBase DataField
        {
            get { return m_WinEventArgs.DataField; }
        }

        public override PivotGridValueType ValueType
        {
            get { return m_WinEventArgs.ValueType; }
        }

        public override string DisplayText
        {
            get { return m_WinEventArgs.DisplayText; }
            set { m_WinEventArgs.DisplayText = value; }
        }
    }
} ;