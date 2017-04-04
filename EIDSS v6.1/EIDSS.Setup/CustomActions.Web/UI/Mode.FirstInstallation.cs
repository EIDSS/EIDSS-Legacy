namespace CustomActions.UI
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using Microsoft.Deployment.WindowsInstaller;


  internal sealed class FirstInstallationMode : InstallMode
  {
    public FirstInstallationMode(Session session)
      : base(session)
    {
    }

    internal override bool IsReportsSvcConfigurationRequired()
    {
      return m_session.EvaluateCondition("$EIDSS.Reports.Service.exe >= 3");
    }

    internal override bool IsServiceConfigurationDlgRequired()
    {
      return IsWebConfigurationRequired() ||
             IsMobileConfigurationRequired() ||
             IsAvrConfigurationRequired() ||
             IsSmartphoneConfigurationRequired() ||
             IsOpenAPIConfigurationRequired();
    }

    internal override bool IsPortSharingConfigurationRequired()
    {
      var checkers = new List<Func<bool>>
      {
        IsWebConfigurationRequired,
        IsMobileConfigurationRequired,
        IsAvrConfigurationRequired,
        IsSmartphoneConfigurationRequired,
        IsOpenAPIConfigurationRequired
      };
      var webSiteCounter = checkers.Count(checker => checker());
      return 1 < webSiteCounter;
    }

    internal override bool IsWebConfigurationRequired()
    {
      return m_session.EvaluateCondition("$Web.AppPool >= 3");
    }

    internal override bool IsAvrConfigurationRequired()
    {
      return m_session.EvaluateCondition("$AVR.AppPool >= 3");
    }

    internal override bool IsMobileConfigurationRequired()
    {
      return m_session.EvaluateCondition("$MOBILE.AppPool >= 3");
    }

    internal override bool IsSmartphoneConfigurationRequired()
    {
      return m_session.EvaluateCondition("$Smartphone.AppPool >= 3");
    }

    internal override bool IsOpenAPIConfigurationRequired()
    {
      return m_session.EvaluateCondition("$OpenAPI.AppPool >= 3");
    }

    internal override bool IsDbSettingsForAvrConfigurationRequired()
    {
      var avrNotRequired = m_session.EvaluateCondition("$AVR.AppPool < 3");
      return m_session.EvaluateCondition(Properties.RequireAvrUrl) && IsWebConfigurationRequired() && avrNotRequired;
    }

    internal override bool IsGisMapsConfigurationRequired()
    {
      return IsWebConfigurationRequired() || IsAvrConfigurationRequired();
    }

    internal override bool IsAppPoolConfigurationRequired()
    {
      return IsWebConfigurationRequired()
          || IsMobileConfigurationRequired()
          || IsAvrConfigurationRequired();
    }
  }
}