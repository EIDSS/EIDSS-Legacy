using bv.model.Model.Core;

namespace eidss.model.Schema
{
    public partial class LoginInfo
    {
        protected static void CheckPasswords(LoginInfo obj)
        {
            //using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            //{
                //if (!Accessor.Instance(m_CS).ValidateCanDeleteWithoutException(manager, obj))
                //{
                //    throw new ValidationModelException("msgCantDeleteRecord", "_on_delete", "_on_delete", null, null);
                //}

                var wasError = false;

                if (obj.strPasswordDecrypted != null)
                {
                    if (obj.strPasswordDecrypted != obj.strConfirmPassword) wasError = true;
                }
                else if ((obj.binPassword == null) || (obj.binPassword.Length == 0))
                {
                    wasError = true;
                }
               
                if (wasError)
                {
                    throw new ValidationModelException("LoginInfo_Incorrect_Password", "_on_delete", "_on_delete", null, null, false);
                }
            //}
        } 
    }
}
