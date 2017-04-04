namespace SetupExe
{
  using System;
  using System.Collections.Generic;
  using System.Reflection;
  using Modes;


  internal static partial class ProgramEntryPoint
  {
    [STAThread]
    public static int Main(string[] args)
    {
      var logger = CreateLogger();
      try
      {
        return RunApplication(args, logger);
      }
      catch (ResourceResolverException exception)
      {
        logger.Log(exception.Message);
      }
      catch (ArgumentNullException exception)
      {
        logger.Log(exception.Message);
      }
      return (int) ErrorCode.LauncherError;

      //if (args != null && args.Length > 0) {
      //      ...
      //  } else {
      //var app = new App();
      //      app.Run();
      //  }
    }

    private static int RunApplication(IList<string> args, ILogger logger)
    {
      var resourceResolver = new ResourceResolver(logger);

      AppDomain.CurrentDomain.AssemblyResolve += resourceResolver.AssemblyResolve;

      using (var mode = DetectMode(args, resourceResolver, logger))
      {
        return (int) mode.Run();
      }
    }

    private static FileLogger CreateLogger()
    {
      return new FileLogger(Assembly.GetExecutingAssembly().Location + ".log");
    }

    private static IMode DetectMode(IList<string> args, ResourceResolver resourceResolver, ILogger logger)
    {
      if (args.Count == 1)
      {
        if (args[0].Equals("/help", StringComparison.OrdinalIgnoreCase))
        {
          return new ShowUsageMode();
        }

        if (args[0].StartsWith("/extract:", StringComparison.OrdinalIgnoreCase))
        {
          return new UnpackMode(args[0].TrimStart("/extract:".ToCharArray()).Trim('"'), resourceResolver);
        }
      }

      return GetExecuteMode(args, resourceResolver, logger);
    }
  }
}