namespace SetupExe.Modes
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Globalization;
  using System.IO;
  using System.Linq;
  using System.Reflection;
  using System.Text;


  internal abstract class ExecuteMode : IMode
  {
    protected readonly IList<string> m_arguments;
    private readonly string m_logPath;
    protected readonly ILogger m_logger;
    protected readonly ResourceResolver m_resourceResolver;
    protected string m_unpackPath;

    internal ExecuteMode(IList<string> arguments, ResourceResolver resourceResolver, ILogger logger)
    {
      if (null == arguments)
      {
        throw new ArgumentNullException("arguments");
      }
      if (null == logger)
      {
        throw new ArgumentNullException("logger");
      }
      if (null == resourceResolver)
      {
        throw new ArgumentNullException("resourceResolver");
      }
      m_resourceResolver = resourceResolver;
      m_logger = logger;

      m_logPath = GetLogFile(arguments);
      m_arguments = FilterOutLogSwitch(arguments);
    }

    private string LogSwitch
    {
      get { return string.Format(CultureInfo.InvariantCulture, " /l*v \"{0}\" ", m_logPath); }
    }

    private static string DefaultLogFile
    {
      get
      {
        return Path.Combine(
          Path.GetTempPath(),
          "Setup." + Path.GetFileName(Assembly.GetExecutingAssembly().Location) + ".log");
      }
    }

    #region IMode Members

    public ErrorCode Run()
    {
      m_unpackPath = GetUnpackPath();
      m_resourceResolver.UnpackResources(m_unpackPath);
      return Execute();
    }

    public void Dispose()
    {
      try
      {
        DeleteFolder(m_unpackPath);
      }
      catch (IOException exception)
      {
        m_logger.Log(exception.Message);
      }
      catch (UnauthorizedAccessException exception)
      {
        m_logger.Log(exception.Message);
      }
    }

    #endregion

    private static string GetLogFile(IList<string> arguments)
    {
      for (var index = 0; index < arguments.Count; ++index)
      {
        if (!arguments[index].StartsWith("/l", StringComparison.OrdinalIgnoreCase) || index + 1 >= arguments.Count)
        {
          continue;
        }

        return arguments[index + 1];
      }

      return DefaultLogFile;
    }

    private IList<string> FilterOutLogSwitch(IList<string> arguments)
    {
      var logIndex = arguments.IndexOf(m_logPath);
      if (-1 == logIndex)
      {
        return arguments;
      }

      var newArguments = new List<string>(arguments.Count - 2);
      newArguments.AddRange(arguments);
      newArguments.RemoveAt(logIndex);
      newArguments.RemoveAt(logIndex - 1);
      return newArguments;
    }

    private string GetUnpackPath()
    {
      var unpackPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
      try
      {
        CreateExtractionFolder(unpackPath);
        return unpackPath;
      }
      catch (IOException exception)
      {
        m_logger.Log(exception.Message);
      }
      catch (UnauthorizedAccessException exception)
      {
        m_logger.Log(exception.Message);
      }
      return AskForUnpackPath();
    }

    protected abstract string AskForUnpackPath();

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
      "Microsoft.Globalization",
      "CA1303:Do not pass literals as localized parameters",
      MessageId = "SetupExe.ILogger.Log(System.String)")]
    private ErrorCode Execute()
    {
      var startInfo = GetExecutionProcessInfo();
      m_logger.Log(string.Format(
        CultureInfo.InvariantCulture,
        "Running command: {0} {1}",
        startInfo.FileName,
        startInfo.Arguments));

      using (var exeProcess = Process.Start(startInfo))
      {
        exeProcess.WaitForExit();

        if (0 == exeProcess.ExitCode)
        {
          return ErrorCode.Success;
        }

        m_logger.Log(string.Format(
          CultureInfo.InvariantCulture,
          "{0} {1} finished with code {2}",
          startInfo.FileName,
          startInfo.Arguments,
          exeProcess.ExitCode));
        return ErrorCode.ApplicationError;
      }
    }

    protected abstract ProcessStartInfo GetExecutionProcessInfo();

    protected virtual string BuildCommandLine()
    {
      var commandLineBuilder = new StringBuilder();
      foreach (var argument in m_arguments)
      {
        commandLineBuilder.Append(WrapProperty(argument));
        commandLineBuilder.Append(" ");
      }
      return commandLineBuilder + LogSwitch;
    }

    private static string WrapProperty(string argument)
    {
      var splitted = argument.Split(new[] { '=' }, 2);
      if (splitted.Length == 2 && splitted.Last().Contains(" "))
      {
        return splitted.First() + "=\"\"" + splitted.Last() + "\"\" ";
      }

      return argument;
    }

    private static void CreateExtractionFolder(string folder)
    {
      DeleteFolder(folder);
      Directory.CreateDirectory(folder);
    }

    private static void DeleteFolder(string folder)
    {
      if (!string.IsNullOrEmpty(folder) && Directory.Exists(folder))
      {
        Directory.Delete(folder, true);
      }
    }
  }
}