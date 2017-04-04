using System.Collections.Generic;
using eidss.model.AVR.SourceData;

namespace eidss.avr.db.Common
{
    public class AvrColumnRowIntersectionPair
    {
        private static readonly AvrColumnRowIntersectionPair m_NullObject;

        static AvrColumnRowIntersectionPair()
        {
            var nullCollection = new AvrFieldValueCollectionWithRowsWrapper(new AvrFieldValueCollection(), new AvrDataRowBase[0], new int[0]);
            m_NullObject = new AvrColumnRowIntersectionPair(new List<AvrFieldValueCollectionWithRowsWrapper>(), nullCollection);
        }

        public AvrColumnRowIntersectionPair
            (List<AvrFieldValueCollectionWithRowsWrapper> colValues, AvrFieldValueCollectionWithRowsWrapper rowValues)
        {
            ColValues = colValues;
            RowValues = rowValues;
        }

        public static AvrColumnRowIntersectionPair NullObject
        {
            get { return m_NullObject; }
        }

        public List<AvrFieldValueCollectionWithRowsWrapper> ColValues { get; private set; }
        public AvrFieldValueCollectionWithRowsWrapper RowValues { get; private set; }
    }
}