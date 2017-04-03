using System;

namespace EIDSS.RAM_DB.Common.EventHandlers
{
    

    public class PivotSelectionEventArgs : EventArgs
    {
        private readonly bool m_ChartEnabled;
        private readonly bool m_MapEnabled;

        public PivotSelectionEventArgs(bool chartEnabled, bool mapEnabled)
        {
            m_ChartEnabled = chartEnabled;
            m_MapEnabled = mapEnabled;
        }

        public bool ChartEnabled
        {
            get { return m_ChartEnabled; }
        }

        public bool MapEnabled
        {
            get { return m_MapEnabled; }
        }
    }
}