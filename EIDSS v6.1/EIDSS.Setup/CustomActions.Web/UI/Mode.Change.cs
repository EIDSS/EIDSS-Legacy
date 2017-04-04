namespace CustomActions.UI
{
  using Microsoft.Deployment.WindowsInstaller;


  internal sealed class ChangeMode : InstallMode
  {
    public ChangeMode(Session session)
      : base(session)
    {
    }

    internal override bool IsReportsSvcConfigurationRequired()
    {
      return m_session.EvaluateCondition("(?EIDSS.Reports.Service.exe = 2) And ($EIDSS.Reports.Service.exe >= 3)");
    }

    internal override bool IsServiceConfigurationDlgRequired()
    {
      var webNotInstalled = m_session.EvaluateCondition("?Web.AppPool = 2");
      var webRequired = m_session.EvaluateCondition("$Web.AppPool >= 3");

      var avrNotInstalled = m_session.EvaluateCondition("?AVR.AppPool = 2");
      var avrRequired = m_session.EvaluateCondition("$AVR.AppPool >= 3");

      var mobileNotInstalled = m_session.EvaluateCondition("?MOBILE.AppPool = 2");
      var mobileRequired = m_session.EvaluateCondition("$MOBILE.AppPool >= 3");

      var openAPINotInstalled = m_session.EvaluateCondition("?OpenAPI.AppPool = 2");
      var openAPIRequired = m_session.EvaluateCondition("$OpenAPI.AppPool >= 3");

      var smartphoneNotInstalled = m_session.EvaluateCondition("?Smartphone.AppPool = 2");
      var smartphoneRequired = m_session.EvaluateCondition("$Smartphone.AppPool >= 3");

      return (string.IsNullOrEmpty(m_session[Properties.ServiceAccountName])
              || string.IsNullOrEmpty(m_session[Properties.ServiceAccountPassword]))
             && webNotInstalled && avrNotInstalled && mobileNotInstalled && openAPINotInstalled &&
             smartphoneNotInstalled
             && (webRequired || avrRequired || mobileRequired || openAPIRequired || smartphoneRequired);
    }

    internal override bool IsPortSharingConfigurationRequired()
    {
      return false;
    }

    internal override bool IsWebConfigurationRequired()
    {
      return m_session.EvaluateCondition("(?Web.AppPool = 2) And ($Web.AppPool >= 3)");
    }

    internal override bool IsAvrConfigurationRequired()
    {
      return m_session.EvaluateCondition("(?AVR.AppPool = 2) And ($AVR.AppPool >= 3)");
    }

    internal override bool IsMobileConfigurationRequired()
    {
      return m_session.EvaluateCondition("(?MOBILE.AppPool = 2) And ($MOBILE.AppPool >= 3)");
    }

    internal override bool IsSmartphoneConfigurationRequired()
    {
      return m_session.EvaluateCondition("(?Smartphone.AppPool = 2) And ($Smartphone.AppPool >= 3)");
    }

    internal override bool IsOpenAPIConfigurationRequired()
    {
      return m_session.EvaluateCondition("(?OpenAPI.AppPool = 2) And ($OpenAPI.AppPool >= 3)");
    }

    internal override bool IsDbSettingsForAvrConfigurationRequired()
    {
      var avrNotInstalled = m_session.EvaluateCondition("?AVR.AppPool = 2");
      var avrNotRequired = m_session.EvaluateCondition("$AVR.AppPool < 3");
      var avrIsBeingRemoved = m_session.EvaluateCondition("$AVR.AppPool = 2");

      return m_session.EvaluateCondition(Properties.RequireAvrUrl) && IsWebConfigurationRequired()
             && (avrNotInstalled && avrNotRequired || avrIsBeingRemoved);
    }

    internal override bool IsGisMapsConfigurationRequired()
    {
      var webNotInstalled = m_session.EvaluateCondition("?Web.AppPool = 2");
      var webRequired = m_session.EvaluateCondition("$Web.AppPool >= 3");

      var avrNotInstalled = m_session.EvaluateCondition("?AVR.AppPool = 2");
      var avrRequired = m_session.EvaluateCondition("$AVR.AppPool >= 3");

      return webNotInstalled && avrNotInstalled && (webRequired || avrRequired);
    }

    internal override bool IsAppPoolConfigurationRequired()
    {
      var webNotInstalled = m_session.EvaluateCondition("?Web.AppPool = 2");
      var webRequired = m_session.EvaluateCondition("$Web.AppPool >= 3");

      var avrNotInstalled = m_session.EvaluateCondition("?AVR.AppPool = 2");
      var avrRequired = m_session.EvaluateCondition("$AVR.AppPool >= 3");

      var mobileNotInstalled = m_session.EvaluateCondition("?MOBILE.AppPool = 2");
      var mobileRequired = m_session.EvaluateCondition("$MOBILE.AppPool >= 3");

      return (string.IsNullOrEmpty(m_session[Properties.ServiceAccountName])
              || string.IsNullOrEmpty(m_session[Properties.ServiceAccountPassword]))
             && webNotInstalled && avrNotInstalled && mobileNotInstalled
             && (webRequired || avrRequired || mobileRequired);
    }
  }
}