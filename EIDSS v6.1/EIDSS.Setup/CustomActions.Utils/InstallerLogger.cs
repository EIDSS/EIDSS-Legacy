namespace CustomActions.Utils
{
  using System;
  using Microsoft.Deployment.WindowsInstaller;


  public sealed class InstallerLogger : ILogger
  {
    private readonly Session m_session;

    public InstallerLogger(Session session)
    {
      if (session == null)
      {
        throw new ArgumentNullException("session");
      }

      m_session = session;
    }

    #region ILogger Members

    public void Log(string message)
    {
      m_session.Log(message);
    }

    #endregion
  }
}