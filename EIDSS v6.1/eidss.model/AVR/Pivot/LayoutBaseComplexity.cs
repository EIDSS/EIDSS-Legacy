using System;

namespace eidss.model.Avr.Pivot
{
    public class LayoutBaseComplexity
    {
        public virtual long CellCount
        {
            get { return 0; }
        }

        public virtual double Complexity
        {
            get { return 0; }
        }

        public long MemoryInMB
        {
            get { return GC.GetTotalMemory(false) / (1024 * 1024); }
        }

        public override string ToString()
        {
            return String.Format("CellCount={0}, Complexity={1}, Memory Usage={2}MB", CellCount, Complexity, MemoryInMB);
        }
    }
}