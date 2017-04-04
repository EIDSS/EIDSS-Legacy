namespace CustomActions
{
  using System.Collections.Generic;
  using Microsoft.Deployment.WindowsInstaller;
  using UI;
  using Utils;


  public static class PortDetector
  {
    [CustomAction]
    public static ActionResult TestReportsServicePort(Session session)
    {
      session.Log("Begin TestReportsServicePort");

      var portDetectorHelper = GetPortDetectorHelper(session);
      session[Properties.ReportsServicePortValid] =
        InstallModeFactory.GetInstallMode(session).IsReportsSvcConfigurationRequired()
          ? portDetectorHelper.TestPort(Properties.ReportsServicePort)
          : "1";

      return ActionResult.Success;
    }

    [CustomAction]
    public static ActionResult TestWebSitePort(Session session)
    {
      session.Log("Begin TestWebSitePort");

      var portDetectorHelper = GetPortDetectorHelper(session);
      session[Properties.WebSitePortValid] = InstallModeFactory.GetInstallMode(session).IsWebConfigurationRequired()
        ? portDetectorHelper.TestPort(Properties.WebSitePort)
        : "1";

      return ActionResult.Success;
    }


    [CustomAction]
    public static ActionResult TestAvrPort(Session session)
    {
      session.Log("Begin TestAvrPort");

      var portDetectorHelper = GetPortDetectorHelper(session);
      session[Properties.AvrWebSitePortValid] = InstallModeFactory.GetInstallMode(session).IsAvrConfigurationRequired()
        ? portDetectorHelper.TestPort(Properties.AvrWebSitePort)
        : "1";

      return ActionResult.Success;
    }

    [CustomAction]
    public static ActionResult TestMobilePort(Session session)
    {
      session.Log("Begin TestMobilePort");

      var portDetectorHelper = GetPortDetectorHelper(session);
      session[Properties.MobileWebSitePortValid] =
        InstallModeFactory.GetInstallMode(session).IsMobileConfigurationRequired()
          ? portDetectorHelper.TestPort(Properties.MobileWebSitePort)
          : "1";

      return ActionResult.Success;
    }

    [CustomAction]
    public static ActionResult TestSmartphonePort(Session session)
    {
      session.Log("Begin TestSmartphonePort");

      var portDetectorHelper = GetPortDetectorHelper(session);
      session[Properties.SmartphoneWebSitePortValid] =
        InstallModeFactory.GetInstallMode(session).IsSmartphoneConfigurationRequired()
          ? portDetectorHelper.TestPort(Properties.SmartphoneWebSitePort)
          : "1";

      return ActionResult.Success;
    }

    [CustomAction]
    public static ActionResult TestOpenAPIPort(Session session)
    {
      session.Log("Begin TestOpenAPIPort");

      var portDetectorHelper = GetPortDetectorHelper(session);
      session[Properties.OpenApiWebSitePortValid] =
        InstallModeFactory.GetInstallMode(session).IsOpenAPIConfigurationRequired()
          ? portDetectorHelper.TestPort(Properties.OpenApiWebSitePort)
          : "1";

      return ActionResult.Success;
    }

    [CustomAction]
    public static ActionResult FindInstallerPorts(Session session)
    {
      session.Log("Begin FindInstallerPorts");

      return GetPortDetectorHelper(session).TryFindFreePorts();
    }

    private static PortDetectorHelper GetPortDetectorHelper(Session session)
    {
      return new PortDetectorHelper(session, FillInstallerPortNames(session));
    }

    private static bool SharePorts(Session session)
    {
      return !string.IsNullOrEmpty(session[Properties.SharePorts]);
    }

    private static IEnumerable<Port> FillInstallerPortNames(Session session)
    {
      Port.Session = session;

      if (SharePorts(session))
      {
        return new List<Port>
        {
          new Port(Properties.ReportsServicePort),
          new Port(new List<string>
          {
            Properties.WebSitePort,
            Properties.AvrWebSitePort,
            Properties.MobileWebSitePort,
            Properties.OpenApiWebSitePort,
            Properties.SmartphoneWebSitePort
          })
        };
      }

      return new List<Port>
      {
        new Port(Properties.ReportsServicePort),
        new Port(Properties.WebSitePort),
        new Port(Properties.AvrWebSitePort),
        new Port(Properties.MobileWebSitePort),
        new Port(Properties.OpenApiWebSitePort),
        new Port(Properties.SmartphoneWebSitePort)
      };
    }
  }
}