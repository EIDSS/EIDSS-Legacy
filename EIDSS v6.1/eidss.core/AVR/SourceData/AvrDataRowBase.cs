using System;

namespace eidss.model.AVR.SourceData
{
    public abstract class AvrDataRowBase
    {
        public static object DbNullValue = DBNull.Value;

        public abstract int Count { get; }

        public abstract object this[int index] { get;}

        public abstract AvrDataRowBase Clone();
    }
}