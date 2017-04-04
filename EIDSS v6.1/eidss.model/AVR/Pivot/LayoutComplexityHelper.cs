namespace eidss.model.Avr.Pivot
{
    public static class LayoutComplexityHelper
    {
        public static bool IsOk(this LayoutValidateResult result)
        {
            return result.Code == LayoutValidateCode.Ok;
        }
        public static bool IsUserDialogOk(this LayoutValidateResult result)
        {
            return result.Code == LayoutValidateCode.UserDialogOk;
        }
        public static bool IsCancel(this LayoutValidateResult result)
        {
            return result.Code == LayoutValidateCode.Cancel;
        }
        public static bool IsUserDialogCancel(this LayoutValidateResult result)
        {
            return result.Code == LayoutValidateCode.UserDialogCancel;
        }
        public static bool IsCancelOrUserDialogCancel(this LayoutValidateResult result)
        {
            return IsCancel(result) || IsUserDialogCancel(result);
        }
    }
}