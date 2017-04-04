
using System.Diagnostics;

namespace InstanceManager.MsiLauncher
{
  internal interface ICommand
  {
    Process Run(string msi, params object[] args);
  }
}