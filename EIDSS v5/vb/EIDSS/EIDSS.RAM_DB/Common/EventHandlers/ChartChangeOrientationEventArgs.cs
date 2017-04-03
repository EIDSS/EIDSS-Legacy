using System;

namespace EIDSS.RAM_DB.Common.EventHandlers
{
    public delegate void ChangeOrientationEventHandler(ChartChangeOrientationEventArgs e);

    public class ChartChangeOrientationEventArgs : EventArgs
    {
        private readonly bool m_Vertical;

        public ChartChangeOrientationEventArgs(bool m_Vertical)
        {
            this.m_Vertical = m_Vertical;
        }

        public bool Vertical
        {
            get { return m_Vertical; }
        }
    }
}