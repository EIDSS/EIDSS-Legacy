namespace SetupExe
{
  using System;
  using System.IO;
  using System.Security;
  using System.Text;


  internal sealed class FileLogger : ILogger
  {
    private readonly string m_path;

    internal FileLogger(string path)
    {
      if (string.IsNullOrEmpty(path))
      {
        throw new ArgumentNullException("path");
      }

      m_path = Path.GetDirectoryName(Path.GetFullPath(path));
      TryPrepareLogFile();
    }

    #region ILogger Members

    public void Log(string message)
    {
      try
      {
        PureLog(message);
      }
      catch (IOException)
      {
      }
      catch (UnauthorizedAccessException)
      {
      }
      catch (SecurityException)
      {
      }
    }

    #endregion

    private void TryPrepareLogFile()
    {
      try
      {
        PrepareLogFile();
      }
      catch (IOException)
      {
      }
      catch (UnauthorizedAccessException)
      {
      }
      catch (SecurityException)
      {
      }
      catch (NotSupportedException)
      {
      }
    }

    private void PrepareLogFile()
    {
      if (File.Exists(m_path))
      {
        File.Delete(m_path);
      }
      Directory.CreateDirectory(m_path);
    }

    private void PureLog(string message)
    {
      if (!string.IsNullOrEmpty(m_path))
      {
        File.AppendAllText(m_path, message + Environment.NewLine, Encoding.UTF8);
      }
    }
  }
}