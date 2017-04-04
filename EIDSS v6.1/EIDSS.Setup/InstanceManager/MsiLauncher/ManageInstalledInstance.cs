using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace InstanceManager.MsiLauncher
{
  internal sealed class ManageInstalledInstance : ICommand
  {
    public Process Run(string msi, params object[] args)
    {
      if (!args.Any() || !(args[0] is Instance))
      {
        throw new InstanceManagerException("Expected argument of type Instance!");
      }

      var instanceToManage = args[0] as Instance;
      var transformInstanceArguments = !instanceToManage.IsDefault
                                         ? string.Format(CultureInfo.InstalledUICulture, "/n {0}", instanceToManage.ProductCode)
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
      get { return "ManageInstalledInstance"; }
    }
  }
}