namespace CustomActions.Utils
{
  using System;
  using Microsoft.Deployment.WindowsInstaller;


  public abstract class ComplexValidityChecker
  {
    protected readonly ILogger m_logger;
    protected readonly ErrorManager m_manager;
    protected readonly Session m_session;

    public ComplexValidityChecker(Session session, ErrorManager manager, ILogger logger)
    {
      if (null == session)
      {
        throw new ArgumentNullException("session");
      }
      if (null == manager)
      {
        throw new ArgumentNullException("manager");
      }
      if (null == logger)
      {
        throw new ArgumentNullException("logger");
      }

      m_session = session;
      m_manager = manager;
      m_logger = logger;
    }

    public abstract void Check();
  }
}