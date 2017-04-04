namespace CustomActions
{
  using Microsoft.Deployment.WindowsInstaller;


  public static class CultureRegistrator
  {
    [CustomAction]
    public static ActionResult RegisterCustomCultures(Session session)
    {
      session.Log("Begin RegisterCustomLocale");

      Utils.CultureRegistrator.TryRegisterCustomCultures(session);

      return ActionResult.Success;
    }
  }
}
