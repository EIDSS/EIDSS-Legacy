using bv.model.Model.Core;
using eidss.model.Resources;

namespace eidss.model.Avr.Pivot
{
    public abstract class LayoutBaseValidator
    {
        public bool IgnoreValidationWarnings { get; set; }

        public abstract LayoutValidateResult Validate(LayoutBaseComplexity complexity);

        protected static string GetTooMuchMemoryLayoutMessage()
        {
            return EidssMessages.Get("msgCancelALotOfMemoryLayout", null, ModelUserContext.CurrentLanguage);
        }
        protected static string GetTooBigLayoutMessage()
        {
            return EidssMessages.Get("msgCancelTooBigLayout", null, ModelUserContext.CurrentLanguage);
        }
        protected static string GetTooComplexLayoutMessage()
        {
            return EidssMessages.Get("msgTooComplexLayout", null, ModelUserContext.CurrentLanguage);
        }

    }
}