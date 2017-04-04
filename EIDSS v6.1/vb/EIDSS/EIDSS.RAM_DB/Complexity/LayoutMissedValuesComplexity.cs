using System;
using eidss.model.Avr.Pivot;

namespace eidss.avr.db.Complexity
{
    public class LayoutMissedValuesComplexity : LayoutBaseComplexity
    {
        private long m_CellCount;

        public override long CellCount
        {
            get { return m_CellCount; }
        }

        public void SetCelllCount(long cellCount)
        {
            m_CellCount = cellCount;
        }

        public override string ToString()
        {
            return String.Format("CellCount={0}", CellCount);
        }
    }
}