using System;
using EIDSS.RAM_DB.Views;

namespace EIDSS.RAM_DB.Common.EventHandlers
{
    public class CopyLayoutEventArgs : EventArgs
    {
        private readonly IRamPivotGridView m_PivotGrid;

        public CopyLayoutEventArgs(IRamPivotGridView pivotGrid, string disabledCriteria)
        {
            m_PivotGrid = pivotGrid;
            DisabledCriteria = disabledCriteria;
        }

        public IRamPivotGridView PivotGrid
        {
            get { return m_PivotGrid; }
        }

        public string DisabledCriteria { get; set; }
    }
}