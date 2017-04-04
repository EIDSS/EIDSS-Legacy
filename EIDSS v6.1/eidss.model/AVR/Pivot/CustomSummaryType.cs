namespace eidss.model.Avr.Pivot
{
    public enum CustomSummaryType : long
    {
        Undefined = -1,
        Average = 10004001,
        Count = 10004002,
        DistinctCount = 10004020,
        Max = 10004003,
        Min = 10004004,
        Pop10000 = 10004006,
        Pop100000 = 10004012,
        PopGender100000 = 10004013,
        PopAgeGroupGender100000 = 10004014,
        PopAgeGroupGender10000 = 10004015,
        Sum = 10004005,
        StdDev = 10004008,
        Variance = 10004009,
    }
}