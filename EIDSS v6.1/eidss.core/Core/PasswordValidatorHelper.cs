using eidss.model.Core.Security;
using eidss.model.Resources;

namespace eidss.model.Core
{
    public class PasswordValidatorHelper
    {
        public static string GetPaswordError(string password, string confirmPassword, EidssSecurityManager security = null)
        {
            if (security == null)
                security = new EidssSecurityManager();
            if (confirmPassword != password)
            {
                return EidssMessages.Get("msgConfirmPasswordError");
            }
            int minimumLength = security.GetIntPolicyValue("intPasswordMinimalLength", 5);
            if (password.Length < minimumLength)
            {
                return string.Format(EidssMessages.Get("msgPasswordTooShort"), minimumLength);
            }

            if (!security.ValidatePassword(password))
            {
                return SecurityMessages.GetLoginErrorMessage(8);
            }
            return null;
        }
        public static string ChangePassword(string organization, string login, string oldPassword, string newPassword, string confirmPassword)
        {
            var security = new EidssSecurityManager();
            var err = GetPaswordError(newPassword, confirmPassword, security);
            if (err != null)
                return err;
            var errCode = security.ChangePassword(organization, login, oldPassword, newPassword);
            if (errCode != 0)
                return SecurityMessages.GetLoginErrorMessage(errCode);
            return null;
        }

    }
}
