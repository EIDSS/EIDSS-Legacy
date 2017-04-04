namespace CustomActions
{
  using System.Collections.Generic;
  using Microsoft.Deployment.WindowsInstaller;
  using Utils;


  public class PortDetector
  {
    [CustomAction]
    public static ActionResult TestAvrServicePort(Session session)
    {
      session.Log("Begin TestAvrServicePort");

      Port.Session = session;
      var portDetectorHelper = new PortDetectorHelper(
        session,
        new List<Port>
        {
          new Port(InstallerProperties.AvrServicePort)
        });
      session[InstallerProperties.AvrServicePortValid] = portDetectorHelper.TestPort(InstallerProperties.AvrServicePort);

      return ActionResult.Success;
    }

    [CustomAction]
    public static ActionResult FindInstallerPorts(Session session)
    {
      session.Log("Begin FindInstallerPorts");

      Port.Session = session;
      return new PortDetectorHelper(
        session,
        new List<Port>
        {
          new Port(InstallerProperties.AvrServicePort)
        }).TryFindFreePorts();
    }
  }
}