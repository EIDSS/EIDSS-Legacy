namespace CustomActions.UI
{
  using Microsoft.Deployment.WindowsInstaller;


  internal abstract class InstallMode
  {
    protected readonly Session m_session;

    internal InstallMode(Session session)
    {
      m_session = session;
    }

    internal abstract bool IsReportsSvcConfigurationRequired();

    internal abstract bool IsServiceConfigurationDlgRequired();

    internal abstract bool IsPortSharingConfigurationRequired();

    internal abstract bool IsWebConfigurationRequired();

    internal abstract bool IsAvrConfigurationRequired();

    internal abstract bool IsMobileConfigurationRequired();

    internal abstract bool IsSmartphoneConfigurationRequired();

    internal abstract bool IsOpenAPIConfigurationRequired();

    internal abstract bool IsDbSettingsForAvrConfigurationRequired();

    internal abstract bool IsGisMapsConfigurationRequired();

    internal abstract bool IsAppPoolConfigurationRequired();
  }
}