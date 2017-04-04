namespace CustomActions
{
  using Microsoft.Deployment.WindowsInstaller;
  using UI;

  public static class UINavigator
  {
    [CustomAction]
    public static ActionResult RebuildDialogChain(Session session)
    {
      session.Log("Begin RebuildDialogChain");

      InstallModeFactory.GetDialogsChain(session).BuildChain();

      return ActionResult.Success;
    }
  }
}