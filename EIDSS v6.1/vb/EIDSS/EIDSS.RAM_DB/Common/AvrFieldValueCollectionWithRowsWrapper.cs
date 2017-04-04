using System.Collections.Generic;
using eidss.model.AVR.SourceData;

namespace eidss.avr.db.Common
{
    public class AvrFieldValueCollectionWithRowsWrapper
    {
        public AvrFieldValueCollectionWithRowsWrapper(AvrFieldValueCollection collection, IList<AvrDataRowBase> rows, IList<int> rowIndexes)
        {
            Collection = collection;
            RowList = rows;
            RowIndexesList = rowIndexes;
        }

        public AvrFieldValueCollection Collection { get; private set; }
        public IList<AvrDataRowBase> RowList { get; private set; }
        public IList<int> RowIndexesList { get; private set; }
    }
}