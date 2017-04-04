using eidss.model.customization.Core;
using eidss.model.Core;

namespace eidss.model.customization.Thailand
{
    internal class ThailandCustomization : BaseCustomization
    {
        public override VisibilityFeatures VisibilityFeatures
        {
            get
            {
                return new VisibilityFeatures
                {
                    IsPersonIDBeforeName = false,
                    IsHumanCaseSampleMainTestVisible = true,
                    IsHerdEpiControlMeasuresVisible = true,
                    IsLastNameBeforeFirstName = false,
                    IsOnlyHouseUseInAddress = true,
                };
            }
        }

        public override string BuildFullName(string last, string first, string middle)
        {
            last = string.IsNullOrWhiteSpace(last) ? "" : last.Trim();
            first = string.IsNullOrWhiteSpace(first) ? "" : first.Trim();
            middle = string.IsNullOrWhiteSpace(middle) ? "" : middle.Trim();
            return (first + " " + last + " " + middle).Trim();
        }
    }
}