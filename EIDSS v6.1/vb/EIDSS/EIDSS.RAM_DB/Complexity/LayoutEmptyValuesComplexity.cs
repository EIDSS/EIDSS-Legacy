using System;
using eidss.model.Avr.Pivot;

namespace eidss.avr.db.Complexity
{
    public class LayoutEmptyValuesComplexity : LayoutBaseComplexity
    {
        public LayoutEmptyValuesComplexity(int caseCount, int rowFieldCount, int colFieldCount, int dataFieldCount) : this()
        {
            CaseCount = caseCount;

            RowFieldCount = rowFieldCount;
            ColFieldCount = colFieldCount;
            DataFieldCount = dataFieldCount;
        }

        public LayoutEmptyValuesComplexity()
        {
        }

        public int RowCount { get; set; }
        public int ColCount { get; set; }

        public int CaseCount { get; private set; }

        public int RowFieldCount { get; private set; }
        public int ColFieldCount { get; private set; }
        public int DataFieldCount { get; private set; }

        public override long CellCount
        {
            get
            {
                long count = ColCount * RowCount * DataFieldCount +
                             RowCount * RowFieldCount +
                             ColCount * ColFieldCount;
                return count;
            }
        }

        public override double Complexity
        {
            get
            {
                // it received by experimental way while measuring report rendering time
                var complexity = 1e-6 * CaseCount *
                                 ((ColFieldCount + RowFieldCount) * ((double) CellCount / 7500 + Math.Log(CellCount+1) / 10 + 6) + 14);
                return complexity;
            }
        }

        public override string ToString()
        {
            return String.Format("{0}, Rows:{1}, Cols:{2}, Row fields: {3}, Col fields:{4}",
                base.ToString(), RowCount, ColCount, RowFieldCount, ColFieldCount);
        }
    }
}