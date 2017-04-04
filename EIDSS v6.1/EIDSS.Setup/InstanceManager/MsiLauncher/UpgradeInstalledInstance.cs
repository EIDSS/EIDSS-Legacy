namespace InstanceManager.MsiLauncher
{
  using System.Diagnostics;
  using System.Globalization;
  using System.Linq;

  internal sealed class UpgradeInstalledInstance : ICommand
  {
    public Process Run(string msi, params object[] args)
    {
      if (!args.Any() || !(args[0] is Instance))
      {
        throw new InstanceManagerException("Expected argument of type Instance!");
      }

      var instanceToManage = args[0] as Instance;
      var transformInstanceArguments =
        !instanceToManage.IsDefault
          ? string.Format(CultureInfo.InstalledUICulture, "TRANSFORMS=:{0} MSINEWINSTANCE=1", instanceToManage.Name)
          : string.Empty;

      var arguments = string.Format(
                                    CultureInfo.InvariantCulture,
                                    "/i \"{0}\" {1} {2}",
                                    msi,
                                    transformInstanceArguments,
                                    ArgumentsStorage.Instance.ArgumentsLine);

      return Process.Start("msiexec.exe", arguments);
    }

    internal static string CommandId
    {
      get { return "UpgradeInstalledInstance"; }
    }
  }
}