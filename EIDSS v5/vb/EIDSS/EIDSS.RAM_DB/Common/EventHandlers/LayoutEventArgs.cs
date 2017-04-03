using System;

namespace EIDSS.RAM_DB.Common.EventHandlers
{
    public class LayoutEventArgs : EventArgs
    {
        private readonly long m_LayoutId;

        public LayoutEventArgs(long layoutId)
        {
            m_LayoutId = layoutId;
        }

        public long LayoutId
        {
            get { return m_LayoutId; }
        }
    }
}