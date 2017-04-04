using bv.common.Core;
using DevExpress.XtraGrid.Views.Base;
using eidss.avr.db.AvrEventArgs.DevExpressEventArgsWrappers;

namespace eidss.avr.Handlers.DevExpressEventArgsWrappers
{
    class WinGridCellDisplayTextEventArgs : BaseGridViewCellDisplayTextEventArgs
    {
        private readonly CustomColumnDisplayTextEventArgs m_WinEventArgs;

        public WinGridCellDisplayTextEventArgs(CustomColumnDisplayTextEventArgs winEventArgs)
        {
            Utils.CheckNotNull(winEventArgs, "winEventArgs");
            m_WinEventArgs = winEventArgs;
        }

        public override object Value
        {
            get { return m_WinEventArgs.Value; }
        }

        public override string DisplayText
        {
            get { return m_WinEventArgs.DisplayText; }
            set { m_WinEventArgs.DisplayText = value; }
        }
    }
}
