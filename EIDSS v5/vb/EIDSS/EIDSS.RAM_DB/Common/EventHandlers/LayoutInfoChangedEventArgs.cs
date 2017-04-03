using System.Data;

namespace EIDSS.RAM_DB.Common.EventHandlers
{
    public class LayoutInfoChangedEventArgs : LayoutEventArgs
    {
        private readonly DataRowState m_LayoutState = DataRowState.Unchanged;

        public LayoutInfoChangedEventArgs(long layoutId, DataRowState layoutState)
            : base(layoutId)
        {
            m_LayoutState = layoutState;
        }

        public DataRowState LayoutState
        {
            get { return m_LayoutState; }
        }
    }
}