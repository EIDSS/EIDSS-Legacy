namespace SetupExe.Modes
{
  using System;


  internal sealed class ShowUsageMode : IMode
  {
    #region IMode Members

    public ErrorCode Run()
    {
      ShowUsage();
      return ErrorCode.LauncherError;
    }

    public void Dispose()
    {
    }

    #endregion

    private static void ShowUsage()
    {
      Console.WriteLine(
        "Usage:" +
        "\r\n\textract:path - extracts content to specified path" +
        "\r\n\thelp - this help");

      //todo ui showUsage
    }
  }
}