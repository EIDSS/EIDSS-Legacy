using System;

namespace eidss.model.Avr.Pivot
{
    public class AvrCacheCancelException : ApplicationException
    {
        private readonly LayoutValidateResult m_ValidatorResult;

        public AvrCacheCancelException(LayoutValidateResult validatorResult)
        {
            m_ValidatorResult = validatorResult;
        }

        public LayoutValidateResult ValidatorResult
        {
            get { return m_ValidatorResult; }
        }
    }
}