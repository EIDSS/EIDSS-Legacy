namespace eidss.model.Avr.Pivot
{
    public static class CustomSummaryTypeHelper
    {
        public static bool IsMinMax(this CustomSummaryType type)
        {
            bool isMinMax = (type == CustomSummaryType.Min) ||
                             (type == CustomSummaryType.Max);
            return isMinMax;
        }
        public static bool IsAdmUnit(this CustomSummaryType type)
        {
            bool isAdmUnit = (type == CustomSummaryType.Pop10000) ||
                             (type == CustomSummaryType.Pop100000);
            return isAdmUnit;
        }

        public static bool IsGender(this CustomSummaryType type)
        {
            bool isGender = (type == CustomSummaryType.PopAgeGroupGender10000) ||
                            (type == CustomSummaryType.PopAgeGroupGender100000) ||
                            (type == CustomSummaryType.PopGender100000);
            return isGender;
        }

        public static bool IsAdmUnitOrGender(this CustomSummaryType type)
        {
            return type.IsAdmUnit() || type.IsGender();
        }

        public static bool IsBasicCounterNeeded(this CustomSummaryType type)
        {
            return type != CustomSummaryType.Min &&
                   type != CustomSummaryType.Max &&
                   type != CustomSummaryType.Count &&
                   type != CustomSummaryType.DistinctCount;
        }

        public static bool IsFillEmptyValuesNeeded(this CustomSummaryType type)
        {
            return type != CustomSummaryType.Min &&
                   type != CustomSummaryType.Max &&
                   type != CustomSummaryType.Count &&
                   type != CustomSummaryType.DistinctCount &&
                   type != CustomSummaryType.Sum;
        }
    }
}