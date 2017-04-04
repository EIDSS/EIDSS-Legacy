namespace eidss.model.Avr.Pivot
{
    public class LayoutValidateResult
    {
        public LayoutValidateResult()
        {
            Code = LayoutValidateCode.Ok;
        }

        public LayoutValidateResult(LayoutValidateCode code)
        {
            Code = code;
        }

        public LayoutValidateResult(LayoutValidateCode code, string errorMessage)
        {
            Code = code;
            ErrorMessage = errorMessage;
        }

        public LayoutValidateCode Code { get; private set; }
        public string ErrorMessage { get; private set; }
    }
}