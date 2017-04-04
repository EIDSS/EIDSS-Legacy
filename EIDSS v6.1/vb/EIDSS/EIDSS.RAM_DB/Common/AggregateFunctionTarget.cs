using System;

namespace eidss.avr.db.Common
{
    [Flags]
    public enum AggregateFunctionTarget
    {
        Pivot = 1,
        View = 2,
        Basic = 4,

    }
}