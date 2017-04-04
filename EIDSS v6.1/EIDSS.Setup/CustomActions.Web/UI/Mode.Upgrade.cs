namespace CustomActions.UI
{
  using Microsoft.Deployment.WindowsInstaller;


  internal sealed class UpgradeMode : InstallMode
  {
    public UpgradeMode(Session session)
      : base(session)
    {
    }

    internal override bool IsReportsSvcConfigurationRequired()
    {
      return m_session.EvaluateCondition("Not FEATURE.REPORTSSERVICE And ($EIDSS.Reports.Service.exe >= 3)");
    }

    internal override bool IsServiceConfigurationDlgRequired()
    {
      var webPreinstalled = m_session.EvaluateCondition("FEATURE.EIDSS.WEB");
      var webRequired = m_session.EvaluateCondition("$Web.AppPool >= 3");

      var avrPreinstalled = m_session.EvaluateCondition("FEATURE.AVR");
      var avrRequired = m_session.EvaluateCondition("$AVR.AppPool >= 3");

      var mobilePreinstalled = m_session.EvaluateCondition("FEATURE.EIDSS.MOBILE");
      var mobileRequired = m_session.EvaluateCondition("$MOBILE.AppPool >= 3");

      var openAPIPreinstalled = m_session.EvaluateCondition("FEATURE.OPENAPI");
      var openAPIRequired = m_session.EvaluateCondition("$OpenAPI.AppPool >= 3");

      var smartphonePreinstalled = m_session.EvaluateCondition("FEATURE.SMARTPHONE");
      var smartphoneRequired = m_session.EvaluateCondition("$Smartphone.AppPool >= 3");

      return (string.IsNullOrEmpty(m_session[Properties.ServiceAccountName])
              || string.IsNullOrEmpty(m_session[Properties.ServiceAccountPassword]))
             &&
             !(webPreinstalled || avrPreinstalled || mobilePreinstalled || openAPIPreinstalled || smartphonePreinstalled)
             && (webRequired || avrRequired || mobileRequired || openAPIRequired || smartphoneRequired);
    }

    internal override bool IsPortSharingConfigurationRequired()
    {
      return false;
    }

    internal override bool IsWebConfigurationRequired()
    {
      return m_session.EvaluateCondition("Not FEATURE.EIDSS.WEB And ($Web.AppPool >= 3)");
    }

    internal override bool IsAvrConfigurationRequired()
    {
      return m_session.EvaluateCondition("Not FEATURE.AVR And ($AVR.AppPool >= 3)");
    }

    internal override bool IsMobileConfigurationRequired()
    {
      return m_session.EvaluateCondition("Not FEATURE.EIDSS.MOBILE And ($MOBILE.AppPool >= 3)");
    }

    internal override bool IsSmartphoneConfigurationRequired()
    {
      return m_session.EvaluateCondition("Not FEATURE.SMARTPHONE And ($Smartphone.AppPool >= 3)");
    }

    internal override bool IsOpenAPIConfigurationRequired()
    {
      return m_session.EvaluateCondition("Not FEATURE.OPENAPI And ($OpenAPI.AppPool >= 3)");
    }

    internal override bool IsDbSettingsForAvrConfigurationRequired()
    {
      var avrNotInstalled = m_session.EvaluateCondition("Not FEATURE.AVR");
      var avrNotRequired = m_session.EvaluateCondition("$AVR.AppPool < 3");

      // In upgrade mode removing of previously installed features is just not installing them, so "no action"
      var avrIsBeingRemoved = m_session.EvaluateCondition("$AVR.AppPool = -1");

      return m_session.EvaluateCondition(Properties.RequireAvrUrl) && IsWebConfigurationRequired()
             && (avrNotInstalled && avrNotRequired || avrIsBeingRemoved);
    }

    internal override bool IsGisMapsConfigurationRequired()
    {
      var webNotInstalled = m_session.EvaluateCondition("Not FEATURE.EIDSS.WEB");
      var webRequired = m_session.EvaluateCondition("$Web.AppPool >= 3");

      var avrNotInstalled = m_session.EvaluateCondition("Not FEATURE.AVR");
      var avrRequired = m_session.EvaluateCondition("$AVR.AppPool >= 3");

      return webNotInstalled && avrNotInstalled && (webRequired || avrRequired);
    }

    internal override bool IsAppPoolConfigurationRequired()
    {
      var webPreinstalled = m_session.EvaluateCondition("FEATURE.EIDSS.WEB");
      var webRequired = m_session.EvaluateCondition("$Web.AppPool >= 3");

      var avrPreinstalled = m_session.EvaluateCondition("FEATURE.AVR");
      var avrRequired = m_session.EvaluateCondition("$AVR.AppPool >= 3");

      var mobilePreinstalled = m_session.EvaluateCondition("FEATURE.EIDSS.MOBILE");
      var mobileRequired = m_session.EvaluateCondition("$MOBILE.AppPool >= 3");

      return (string.IsNullOrEmpty(m_session[Properties.ServiceAccountName])
              || string.IsNullOrEmpty(m_session[Properties.ServiceAccountPassword]))
             &&
             !(webPreinstalled || avrPreinstalled || mobilePreinstalled)
             && (webRequired || avrRequired || mobileRequired);
    }
  }
}