namespace InstanceManager.MsiLauncher
{
  using System.Diagnostics;
  using System.Globalization;

  internal sealed class InstallFreeInstance : ICommand
  {
    public Process Run(string msi, params object[] args)
    {
      var freeInstance = InstanceManager.ClassInstance.FreeInstance;

      var transformInstanceArguments =
        !freeInstance.IsDefault
          ? string.Format(CultureInfo.InstalledUICulture, "TRANSFORMS=:{0} MSINEWINSTANCE=1", freeInstance.Name)
          : string.Empty;

      var arguments = string.Format(
                                    CultureInfo.InvariantCulture,
                                    "/i \"{0}\" {1} {2}",
                                    msi,
                                    transformInstanceArguments,
                                    ArgumentsStorage.Instance.ArgumentsLine);

      return Process.Start("msiexec.exe", arguments);
    }


    public static string CommandId
    {
      get { return "InstallFreeInstance"; }
    }
  }
}