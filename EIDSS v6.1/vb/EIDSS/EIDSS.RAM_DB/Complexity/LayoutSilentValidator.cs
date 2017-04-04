using bv.common.Configuration;
using eidss.model.Avr.Pivot;

namespace eidss.avr.db.Complexity
{
    public class LayoutSilentValidator : LayoutBaseValidator
    {
        public override LayoutValidateResult Validate(LayoutBaseComplexity complexity)
        {
            if (BaseSettings.ShowBigLayoutWarning)
            {
                if (complexity.MemoryInMB > BaseSettings.AvrErrorMemoryLimit)
                {
                    return new LayoutValidateResult(LayoutValidateCode.Cancel, GetTooMuchMemoryLayoutMessage());
                }
                if (complexity.CellCount > BaseSettings.AvrErrorCellCountLimit)
                {
                    return new LayoutValidateResult(LayoutValidateCode.Cancel, GetTooBigLayoutMessage());
                }
                if (complexity.Complexity > BaseSettings.AvrErrorLayoutComplexity)
                {
                    return new LayoutValidateResult(LayoutValidateCode.Cancel, GetTooComplexLayoutMessage());
                }

                if (!IgnoreValidationWarnings)
                {
                    if (complexity.MemoryInMB > BaseSettings.AvrWarningMemoryLimit)
                    {
                        return new LayoutValidateResult(LayoutValidateCode.Cancel, GetTooMuchMemoryLayoutMessage());
                    }
                    if (complexity.CellCount > BaseSettings.AvrWarningCellCountLimit)
                    {
                        return new LayoutValidateResult(LayoutValidateCode.Cancel, GetTooBigLayoutMessage());
                    }
                    if (complexity.Complexity > BaseSettings.AvrWarningLayoutComplexity)
                    {
                        return new LayoutValidateResult(LayoutValidateCode.Cancel, GetTooComplexLayoutMessage());
                    }
                }
            }
            return new LayoutValidateResult();
        }
    }
}