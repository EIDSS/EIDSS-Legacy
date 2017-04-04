namespace CustomActions
{
  using Microsoft.Deployment.WindowsInstaller;
  using Utils;


  public class Cryptor
  {
    [CustomAction]
    public static ActionResult EncryptDbAccountDetails(Session session)
    {
      session.Log("Begin EncryptDbAccountDetails");

      var cryptor = new CryptorWrapper(session);
      cryptor.EncryptAccountDetails(InstallerProperties.DbUser, InstallerProperties.DbPassword);

      session[InstallerProperties.EncryptedDbUser] = cryptor.ResultUser;
      session[InstallerProperties.EncryptedDbPassword] = cryptor.ResultPassword;

      return ActionResult.Success;
    }

    [CustomAction]
    public static ActionResult EncryptArchiveDbAccountDetails(Session session)
    {
      session.Log("Begin EncryptArchiveDbAccountDetails");

      var cryptor = new CryptorWrapper(session);
      cryptor.EncryptAccountDetails(InstallerProperties.ArchUser, InstallerProperties.ArchPassword);

      session[InstallerProperties.EncryptedArchUser] = cryptor.ResultUser;
      session[InstallerProperties.EncryptedArchPassword] = cryptor.ResultPassword;

      return ActionResult.Success;
    }

    [CustomAction]
    public static ActionResult EncryptAvrDbAccountDetails(Session session)
    {
      session.Log("Begin EncryptAvrDbAccountDetails");

      var cryptor = new CryptorWrapper(session);
      cryptor.EncryptAccountDetails(InstallerProperties.AvrUser, InstallerProperties.AvrPassword);

      session[InstallerProperties.EncryptedAvrUser] = cryptor.ResultUser;
      session[InstallerProperties.EncryptedAvrPassword] = cryptor.ResultPassword;

      return ActionResult.Success;
    }

    [CustomAction]
    public static ActionResult DecryptAvrUser(Session session)
    {
      session.Log("Begin DecryptAvrUser");

      var cryptor = new CryptorWrapper(session);

      cryptor.DecryptAccountDetails(session, InstallerProperties.EncryptedAvrUser,
        InstallerProperties.EncryptedAvrPassword);

      if (!string.IsNullOrEmpty(cryptor.ResultUser))
      {
        session[InstallerProperties.AvrUser] = cryptor.ResultUser;
        session[InstallerProperties.AvrPassword] = cryptor.ResultPassword;
      }

      return ActionResult.Success;
    }

    [CustomAction]
    public static ActionResult DecryptAdminAvrUser(Session session)
    {
      session.Log("Begin DecryptAdminAvrUser");

      var cryptor = new CryptorWrapper(session);

      cryptor.DecryptAccountDetails(
        session,
        InstallerProperties.EncryptedAdminAvrUser,
        InstallerProperties.EncryptedAdminAvrPassword);

      if (!string.IsNullOrEmpty(cryptor.ResultUser))
      {
        session[InstallerProperties.AdminAvrUser] = cryptor.ResultUser;
        session[InstallerProperties.AdminAvrPassword] = cryptor.ResultPassword;
      }

      return ActionResult.Success;
    }

    [CustomAction]
    public static ActionResult DecryptAdminDbUser(Session session)
    {
      session.Log("Begin DecryptAdminDbUser");

      var cryptor = new CryptorWrapper(session);

      cryptor.DecryptAccountDetails(
        session,
        InstallerProperties.EncryptedAdminDbUser,
        InstallerProperties.EncryptedAdminDbPassword);

      if (!string.IsNullOrEmpty(cryptor.ResultUser))
      {
        session[InstallerProperties.AdminDbUser] = cryptor.ResultUser;
        session[InstallerProperties.AdminDbPassword] = cryptor.ResultPassword;
      }

      return ActionResult.Success;
    }
  }
}