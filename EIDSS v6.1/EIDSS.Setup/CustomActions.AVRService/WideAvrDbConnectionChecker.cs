namespace CustomActions
{
  using Microsoft.Deployment.WindowsInstaller;
  using Utils;


  internal sealed class WideAvrDbConnectionChecker : DbAdminConnectionChecker
  {
    private readonly string m_password;
    private readonly string m_user;

    internal WideAvrDbConnectionChecker(Session session, ErrorManager manager, ILogger logger)
      : base(session, manager, logger)
    {
      ResetValidators();

      m_server = session[InstallerProperties.AvrDbServer];
      m_adminUser = session[InstallerProperties.AdminAvrUser];
      m_adminPassword = session[InstallerProperties.AdminAvrPassword];
      m_user = session[InstallerProperties.AvrUser];
      m_password = session[InstallerProperties.AvrPassword];
    }

    public override void Check()
    {
      var areAdminFieldsNotEmpty = AreAdminFieldsNotEmpty();
      var areAvrUserFieldsNotEmpty = AreAvrUserFieldsNotEmpty();

      m_session[InstallerProperties.AvrWideDbConnectionValid] =
        areAdminFieldsNotEmpty && AreAdminCredentialsCorrect()
        && areAvrUserFieldsNotEmpty && AreAvrUserCredentialsCorrectOrNotExist()
          ? "1"
          : "0";

      m_session[InstallerProperties.ErrorConnectionText] = m_session.Format(m_manager.Errors);
    }

    private void ResetValidators()
    {
      m_session[InstallerProperties.AvrWideDbConnectionValid] = string.Empty;
      m_session[InstallerProperties.AvrDbAdminConnectionValid] = string.Empty;
      m_session[InstallerProperties.AvrDbConnectionValid] = string.Empty;
    }

    #region are manadatory fields empty ?

    private bool AreAdminFieldsNotEmpty()
    {
      if (!string.IsNullOrEmpty(m_adminUser) && !string.IsNullOrEmpty(m_adminPassword))
      {
        return true;
      }

      m_session[InstallerProperties.AvrDbAdminConnectionValid] = "0";
      m_manager.Add(m_session[InstallerProperties.EmptyMandatoryFileds]);
      return false;
    }

    private bool AreAvrUserFieldsNotEmpty()
    {
      if (!string.IsNullOrEmpty(m_user) && !string.IsNullOrEmpty(m_password))
      {
        return true;
      }

      m_session[InstallerProperties.AvrDbConnectionValid] = "0";
      m_manager.Add(m_session[InstallerProperties.EmptyMandatoryFileds]);
      return false;
    }

    #endregion are manadatory fields empty ?

    #region are admin credentials correct

    private bool AreAdminCredentialsCorrect()
    {
      if (!AdminCredentialsAreValid() || !UserIsAdmin())
      {
        m_session[InstallerProperties.AvrDbAdminConnectionValid] = "0";
        return false;
      }

      m_session[InstallerProperties.AvrDbAdminConnectionValid] = "1";
      return true;
    }

    private bool AdminCredentialsAreValid()
    {
      if (Utils.DbChecker.TestConnection(m_server, MasterDatabase, m_adminUser, m_adminPassword))
      {
        return true;
      }

      m_manager.Add(m_session[InstallerProperties.BadAvrAdminLogin]);
      return false;
    }

    private bool UserIsAdmin()
    {
      if (Utils.DbChecker.IsUserAdmin(m_server, m_adminUser, m_adminPassword))
      {
        return true;
      }

      m_manager.Add(m_session[InstallerProperties.NotAvrAdmin]);
      return false;
    }

    #endregion are admin credentials correct

    #region are avr user credentials correct or not exist

    private bool AreAvrUserCredentialsCorrectOrNotExist()
    {
      if (!UserExists() || UserValid())
      {
        m_session[InstallerProperties.AvrDbConnectionValid] = "1";
        return true;
      }

      m_session[InstallerProperties.AvrDbConnectionValid] = "0";
      m_manager.Add(m_session[InstallerProperties.BadAvrUserLogin]);
      return false;
    }

    private bool UserValid()
    {
      return Utils.DbChecker.TestConnection(m_server, MasterDatabase, m_user, m_password);
    }

    private bool UserExists()
    {
      return Utils.DbChecker.DoesUserExist(m_server, m_adminUser, m_adminPassword, m_user);
    }

    #endregion are avr user credentials correct or not exist
  }
}