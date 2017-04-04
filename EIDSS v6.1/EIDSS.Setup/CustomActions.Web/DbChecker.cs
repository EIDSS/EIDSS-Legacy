namespace CustomActions
{
  using Microsoft.Deployment.WindowsInstaller;


  public static class DbChecker
  {
    [CustomAction]
    public static ActionResult TestDbConnection(Session session)
    {
      session.Log("Begin DbChecker.TestDbConnection");

      session[Properties.DbConnectionValid] = Utils.DbChecker.TestConnection(
        session,
        Properties.DbServer,
        Properties.SqlDatabase,
        Properties.DbUser,
        Properties.DbPassword) ? "1" : "0";
      //session[Properties.DbConnectionValid] = "1" != session[Properties.DbConnectionValid] ? "1" : "0";

      return ActionResult.Success;
    }

    [CustomAction]
    public static ActionResult TestArchiveDbConnection(Session session)
    {
      session.Log("Begin DbChecker.TestArchiveDbConnection");

      session[Properties.ArchDbConnectionValid] = Utils.DbChecker.TestConnection(
        session,
        Properties.ArchDbServer,
        Properties.ArchDatabase,
        Properties.ArchUser,
        Properties.ArchPassword) ? "1" : "0";
      //session[Properties.ArchDbConnectionValid] = "1" != session[Properties.ArchDbConnectionValid] ? "1" : "0";

      return ActionResult.Success;
    }

    [CustomAction]
    public static ActionResult TestDbConnectionForAvr(Session session)
    {
      session.Log("Begin DbChecker.TestDbConnectionForAvr");

      session[Properties.DbConnectionValidForAvr] = Utils.DbChecker.TestConnection(
        session,
        Properties.DbServerForAvr,
        Properties.SqlDatabaseForAvr,
        Properties.DbUserForAvr,
        Properties.DbPasswordForAvr) ? "1" : "0";
      //session[Properties.ArchDbConnectionValid] = "1" != session[Properties.ArchDbConnectionValid] ? "1" : "0";

      return ActionResult.Success;
    }
  }
}
