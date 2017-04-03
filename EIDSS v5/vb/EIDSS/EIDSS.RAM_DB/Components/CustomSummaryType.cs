namespace EIDSS.RAM_DB.Components
{
    public enum CustomSummaryType : long
    {
        Average = 10004001,
        Count = 10004002,
        Custom = -1,
        Max = 10004003,
        Min = 10004004,
        Sum = 10004005,
        Pop10000 = 10004006,
        PercentOfColumn = 10004007,
        StdDev = 10004008,
        Variance = 10004009,
        PercentOfRow = 10004010,
        Proportion = 10004011,
        Pop100000 = 10004012,
        PopGender100000 = 10004013,
        PopAgeGroupGender100000 = 10004014,
        PopAgeGroupGender10000 = 10004015,
    }
}