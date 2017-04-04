namespace SetupExe.Modes
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Globalization;
  using System.IO;
  using System.Linq;
  using System.Reflection;


  internal class ExecuteMsiExecMode : ExecuteMode
  {
    private const string MsiExec = "msiexec.exe";

    internal ExecuteMsiExecMode(IList<string> arguments, ResourceResolver resourceResolver, ILogger logger)
      : base(arguments, resourceResolver, logger)
    {
    }

    private string MsiInstallSwitch
    {
      get { return string.Format(CultureInfo.InvariantCulture, "/i \"{0}\" ", GetMsiToRun()); }
    }

    protected override string AskForUnpackPath()
    {
      throw new NotImplementedException();
    }

    protected override ProcessStartInfo GetExecutionProcessInfo()
    {
      var processInfo = new ProcessStartInfo
      {
        FileName = MsiExec,
        Arguments = BuildCommandLine(),
        WorkingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
      };
      return processInfo;
    }

    private string GetMsiToRun()
    {
      var msis = Directory.EnumerateFiles(m_unpackPath, "*.msi");
      return msis.FirstOrDefault();
    }

    protected override string BuildCommandLine()
    {
      return MsiInstallSwitch + base.BuildCommandLine();
    }
  }
}