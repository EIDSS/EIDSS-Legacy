using System;
using eidss.avr.db.Interfaces;

namespace eidss.avr.db.AvrEventArgs.AvrEventArgs
{
    public class CopyLayoutEventArgs : EventArgs
    {
        private readonly IAvrPivotGridView m_PivotGrid;

        public CopyLayoutEventArgs(IAvrPivotGridView pivotGrid, string disabledCriteria)
        {
            m_PivotGrid = pivotGrid;
            DisabledCriteria = disabledCriteria;
        }

        public IAvrPivotGridView PivotGrid
        {
            get { return m_PivotGrid; }
        }

        public string DisabledCriteria { get; set; }
    }
}