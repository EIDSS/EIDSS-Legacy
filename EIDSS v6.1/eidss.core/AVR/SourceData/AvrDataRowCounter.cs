using System;
using System.Collections.Generic;

namespace eidss.model.AVR.SourceData
{
    public class AvrDataRowCounter
    {
        public AvrDataRowCounter()
        {
            DistinctTypes = new List<Type>();
        }

        public int StringCount { get; private set; }
        public int DateTimeCount { get; private set; }
        public int Int64Count { get; private set; }
        public int ObjectCount { get; private set; }
        public List<Type> DistinctTypes { get; private set; }

        public void AddType(Type type)
        {
            DistinctTypes.Add(type);
            if (type == typeof (String))
            {
                StringCount++;
            }
            else if (type == typeof (DateTime))
            {
                DateTimeCount++;
            }
            else if (type == typeof (Int64))
            {
                Int64Count++;
            }
            else
            {
                ObjectCount++;
            }
        }
    }
}