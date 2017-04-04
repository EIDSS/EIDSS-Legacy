namespace CustomActions
{
  using Microsoft.Deployment.WindowsInstaller;
  using Utils;


  public static class DbChecker
  {
    private const string MasterDatabase = "master";

    [CustomAction]
    public static ActionResult TestDbConnection(Session session)
    {
      session.Log("Begin TestDbConnection");

      session[InstallerProperties.DbConnectionValid] = Utils.DbChecker.TestConnection(
        session,
        InstallerProperties.DbServer,
        InstallerProperties.SqlDatabase,
        InstallerProperties.DbUser,
        InstallerProperties.DbPassword)
        ? "1"
        : "0";

      return ActionResult.Success;
    }

    [CustomAction]
    public static ActionResult TestArchiveDbConnection(Session session)
    {
      session.Log("Begin TestArchiveDbConnection");

      session[InstallerProperties.ArchDbConnectionValid] = Utils.DbChecker.TestConnection(
        session,
        InstallerProperties.ArchDbServer,
        InstallerProperties.ArchDatabase,
        InstallerProperties.ArchUser,
        InstallerProperties.ArchPassword)
        ? "1"
        : "0";

      return ActionResult.Success;
    }

    [CustomAction]
    public static ActionResult TestAvrDbConnection(Session session)
    {
      session.Log("Begin TestAvrDbConnection");

      session[InstallerProperties.AvrDbConnectionValid] = Utils.DbChecker.TestConnection(
        session,
        InstallerProperties.AvrDbServer,
        InstallerProperties.AvrDatabase,
        InstallerProperties.AvrUser,
        InstallerProperties.AvrPassword)
        ? "1"
        : "0";

      return ActionResult.Success;
    }

    [CustomAction]
    public static ActionResult TestDbAdminConnection(Session session)
    {
      session.Log("Begin TestDbAdminConnection");

      var validityChecker = new DbAdminConnectionChecker(session, new ErrorManager(), new InstallerLogger(session));
      validityChecker.Check();

      return ActionResult.Success;
    }

    [CustomAction]
    public static ActionResult TestWideAvrDbConnection(Session session)
    {
      session.Log("Begin TestWideAvrDbConnection");

      var validityChecker = new WideAvrDbConnectionChecker(session, new ErrorManager(), new InstallerLogger(session));
      validityChecker.Check();

      return ActionResult.Success;
    }
  }
}