namespace CustomActions
{
  using Microsoft.Deployment.WindowsInstaller;
  using Utils;


  internal class DbAdminConnectionChecker : ComplexValidityChecker
  {
    protected const string MasterDatabase = "master";
    protected string m_adminPassword;
    protected string m_adminUser;
    protected string m_server;

    internal DbAdminConnectionChecker(Session session, ErrorManager manager, ILogger logger)
      : base(session, manager, logger)
    {
      ResetValidators();

      m_server = session[InstallerProperties.DbServer];
      m_adminUser = session[InstallerProperties.AdminDbUser];
      m_adminPassword = session[InstallerProperties.AdminDbPassword];
    }

    public override void Check()
    {
      m_session[InstallerProperties.DbAdminConnectionValid] = AreAdminFieldsNotEmpty() && AreAdminCredentialsCorrect()
        ? "1"
        : "0";

      m_session[InstallerProperties.ErrorConnectionText] = m_session.Format(m_manager.Errors);
    }

    private void ResetValidators()
    {
      m_session[InstallerProperties.DbAdminConnectionValid] = string.Empty;
    }

    private bool AreAdminFieldsNotEmpty()
    {
      if (!string.IsNullOrEmpty(m_adminUser) && !string.IsNullOrEmpty(m_adminPassword))
      {
        return true;
      }

      m_manager.Add(m_session[InstallerProperties.EmptyMandatoryFileds]);
      return false;
    }

    #region are admin credentials correct

    private bool AreAdminCredentialsCorrect()
    {
      return AdminCredentialsAreValid() && UserIsAdmin();
    }

    private bool AdminCredentialsAreValid()
    {
      if (Utils.DbChecker.TestConnection(m_server, MasterDatabase, m_adminUser, m_adminPassword))
      {
        return true;
      }

      m_manager.Add(m_session[InstallerProperties.BadAdminLogin]);
      return false;
    }

    private bool UserIsAdmin()
    {
      if (Utils.DbChecker.IsUserAdmin(m_server, m_adminUser, m_adminPassword))
      {
        return true;
      }

      m_manager.Add(m_session[InstallerProperties.NotAdmin]);
      return false;
    }

    #endregion are admin credentials correct
  }
}