namespace CustomActions.UI
{
  using Microsoft.Deployment.WindowsInstaller;

  internal sealed class RepairOrRemoveMode : InstallMode
  {
    public RepairOrRemoveMode(Session session)
      : base(session)
    {
    }

    internal override bool IsReportsSvcConfigurationRequired()
    {
      return false;
    }

    internal override bool IsServiceConfigurationDlgRequired()
    {
      return false;
    }

    internal override bool IsPortSharingConfigurationRequired()
    {
      return false;
    }

    internal override bool IsWebConfigurationRequired()
    {
      return false;
    }

    internal override bool IsAvrConfigurationRequired()
    {
      return false;
    }

    internal override bool IsMobileConfigurationRequired()
    {
      return false;
    }

    internal override bool IsSmartphoneConfigurationRequired()
    {
      return false;
    }

    internal override bool IsOpenAPIConfigurationRequired()
    {
      return false;
    }

    internal override bool IsDbSettingsForAvrConfigurationRequired()
    {
      return false;
    }

    internal override bool IsGisMapsConfigurationRequired()
    {
      return false;
    }

    internal override bool IsAppPoolConfigurationRequired()
    {
      return false;
    }
  }
}