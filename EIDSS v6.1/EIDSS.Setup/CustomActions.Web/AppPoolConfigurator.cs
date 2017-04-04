namespace CustomActions
{
  using System;
  using System.Collections.Generic;
  using System.Globalization;
  using Microsoft.Deployment.WindowsInstaller;
  using Utils;


  public static class AppPoolConfigurator
  {
    private const string IisAppPoolTable = "IIsAppPool";
    private const string AppPoolColumn = "AppPool";
    private const string IdleTimeoutColumn = "IdleTimeout";


    [CustomAction]
    public static ActionResult GetAppPoolIdleTimeoutInSeconds(Session session)
    {
      session.Log("Begin GetAppPoolIdleTimeoutInSeconds");

      var timeOutInMinutesValue = session[Properties.AppPoolIdleTimeoutInMinutes];
      int timeOutInMinutes;
      if (!int.TryParse(timeOutInMinutesValue, out timeOutInMinutes))
      {
        session.Log("Value of [{0}] is {1}. It's not a number!", Properties.AppPoolIdleTimeoutInMinutes,
          timeOutInMinutesValue);
        return ActionResult.Failure;
      }

      session[Properties.AppPoolIdleTimeoutInSeconds] = (timeOutInMinutes * 60).ToString(CultureInfo.InvariantCulture);

      return ActionResult.Success;
    }

    [CustomAction]
    public static ActionResult SetAppPoolIdleTimeout(Session session)
    {
      session.Log("Begin SetAppPoolIdleTimeout");

      var appPool = session[Properties.AppPool];
      var timeOutValue = session[Properties.AppPoolIdleTimeout];
      int timeOut;
      if (!int.TryParse(timeOutValue, out timeOut))
      {
        session.Log("Value of [{0}] is {1}. It's not a number!", Properties.AppPoolIdleTimeout, timeOutValue);
        return ActionResult.Failure;
      }

      var msiDatabaseWrapper = new MsiDatabaseWrapper(session);
      msiDatabaseWrapper.ReplaceRecord(
        IisAppPoolTable,
        new MsiDatabaseWrapper.Field(AppPoolColumn, appPool),
        new MsiDatabaseWrapper.Field(IdleTimeoutColumn, timeOut));

      return ActionResult.Success;
    }
  }
}
