namespace CustomActions
{
  using System.IO;
  using Microsoft.Deployment.WindowsInstaller;


  public static class PathValidator
  {
    [CustomAction]
    public static ActionResult ValidatePath(Session session)
    {
      session.Log("Begin Validator.ValidatePath");

      session[Properties.DirValid] = "0";

      var pathProperty = session[Properties.PathToValidate];
      if (string.IsNullOrEmpty(pathProperty))
      {
        session.Log("Validator.ValidatePath: {0} must contain path property name!", Properties.PathToValidate);
        return ActionResult.Failure;
      }

      var path = session[pathProperty];
      if (string.IsNullOrEmpty(path))
      {
        session[Properties.InvalidDirText] = session.Format(session[Properties.DirIsEmpty]);
      }
      else if (!new DirectoryInfo(path).Exists)
      {
        session[Properties.InvalidDirText] = session.Format(session[Properties.DirDoesNotExist]);
      }
      else
      {
        session[Properties.DirValid] = "1";
      }

      return ActionResult.Success;
    }

  }
}
