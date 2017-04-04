namespace SetupExe.Modes
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.IO;
  using System.Reflection;


  internal class ExecuteInstanceManagerMode : ExecuteMode
  {
    private const string InstanceManagerFileName = "InstanceManager.exe";

    internal ExecuteInstanceManagerMode(IList<string> arguments, ResourceResolver resourceResolver, ILogger logger)
      : base(arguments, resourceResolver, logger)
    {
    }

    protected override string AskForUnpackPath()
    {
      throw new NotImplementedException();
    }

    protected override ProcessStartInfo GetExecutionProcessInfo()
    {
      var processInfo = new ProcessStartInfo
      {
        FileName = Path.Combine(m_unpackPath, InstanceManagerFileName),
        Arguments = BuildCommandLine(),
        WorkingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
      };
      return processInfo;
    }
  }
}