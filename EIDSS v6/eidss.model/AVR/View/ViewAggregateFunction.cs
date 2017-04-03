using System;

namespace eidss.model.Avr.View
{
    [Serializable]
    public enum ViewAggregateFunction : long
    {
        Undefined = -1,
        CumulativePercent = 10004016,
        PercentOfColumn = 10004007,
        PercentOfRow = 10004010,
        Proportion = 10004011,
        MaxOfRow = 10004017,
        MinOfRow = 10004018,
        Ratio = 10004019,

    }
}