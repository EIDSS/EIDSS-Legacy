namespace CustomActions
{
  using Microsoft.Deployment.WindowsInstaller;
  using Utils;

  public static class Cryptor
  {
    [CustomAction]
    public static ActionResult EncryptDbAccountDetails(Session session)
    {
      session.Log("Begin EncryptDbAccountDetails");

      var cryptor = new CryptorWrapper(session);
      cryptor.EncryptAccountDetails(Properties.DbUser, Properties.DbPassword);

      session[Properties.EncryptedDbUser] = cryptor.ResultUser;
      session[Properties.EncryptedDbPassword] = cryptor.ResultPassword;

      return ActionResult.Success;
    }

    [CustomAction]
    public static ActionResult EncryptArchiveDbAccountDetails(Session session)
    {
      session.Log("Begin EncryptArchiveDbAccountDetails");

      var cryptor = new CryptorWrapper(session);
      cryptor.EncryptAccountDetails(Properties.ArchUser, Properties.ArchPassword);

      session[Properties.EncryptedArchUser] = cryptor.ResultUser;
      session[Properties.EncryptedArchPassword] = cryptor.ResultPassword;

      return ActionResult.Success;
    }

    [CustomAction]
    public static ActionResult EncryptServiceAccountDetails(Session session)
    {
      session.Log("Begin EncryptServiceAccountDetails");

      var cryptor = new CryptorWrapper(session);
      cryptor.EncryptAccountDetails(Properties.ServiceAccountName, Properties.ServiceAccountPassword, Properties.ServiceAccountDomain);

      session[Properties.EncryptedServiceAccountName] = cryptor.ResultUser;
      session[Properties.EncryptedServiceAccountPassword] = cryptor.ResultPassword;

      return ActionResult.Success;
    }

    [CustomAction]
    public static ActionResult DecryptServiceAccountDetails(Session session)
    {
      session.Log("Begin DecryptServiceAccountDetails");

      var cryptor = new CryptorWrapper(session);
      cryptor.DecryptAccountDetails(session, Properties.EncryptedServiceAccountName, Properties.EncryptedServiceAccountPassword);

      session[Properties.ServiceAccountName] = CryptorWrapper.GetUser(cryptor.ResultUser);
      session[Properties.ServiceAccountDomain] = CryptorWrapper.GetDomain(cryptor.ResultUser);
      session[Properties.ServiceAccountPassword] = cryptor.ResultPassword;

      return ActionResult.Success;
    }

    [CustomAction]
    public static ActionResult EncryptDbAccountForAvrDetails(Session session)
    {
      session.Log("Begin EncryptDbAccountForAvrDetails");

      var cryptor = new CryptorWrapper(session);
      cryptor.EncryptAccountDetails(Properties.DbUserForAvr, Properties.DbPasswordForAvr);

      session[Properties.EncryptedDbUserForAvr] = cryptor.ResultUser;
      session[Properties.EncryptedDbPasswordForAvr] = cryptor.ResultPassword;

      return ActionResult.Success;
    }
  }
}
