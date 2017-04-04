namespace CustomActions.Utils
{
  using System.Collections.Generic;
  using System.Globalization;
  using System.Net;
  using Microsoft.Deployment.WindowsInstaller;


  public class PortDetectorHelper
  {
    private readonly List<Port> m_installerPorts = new List<Port>();
    private readonly Session m_session;
    private int m_portLowerBound;
    private int m_portUpperBound;

    public PortDetectorHelper(Session session, IEnumerable<Port> ports)
    {
      m_session = session;
      AddPorts(ports);
      ParcePortBoundaries();
    }

    public string TestPort(string portProperty)
    {
      m_session[Properties.Port] = portProperty;

      int port;
      if (!int.TryParse(m_session[portProperty], out port))
      {
        m_session[Properties.BadPortText] = m_session.Format(m_session[Properties.UnsupportedPortValue]);
        return "0";
      }

      if (port <= IPEndPoint.MinPort || port > IPEndPoint.MaxPort)
      {
        m_session[Properties.BadPortText] = m_session.Format(m_session[Properties.PortIsOutOfBoundary]);
        return "0";
      }

      if (PortsAllowedToOccupy().Contains(port))
      {
        return "1";
      }

      if (new PortManager(GetOccupiedByInstaller(portProperty)).IsPortFree(port))
      {
        return "1";
      }
      m_session[Properties.BadPortText] = m_session.Format(m_session[Properties.PortIsOccupied]);
      return "0";
    }

    private ISet<int> PortsAllowedToOccupy()
    {
      var portsAllowedToOccupy = m_session[Properties.PortsAllowedToOccupy].Split(',');
      var allowedPorts = new HashSet<int>();
      foreach (var port in portsAllowedToOccupy)
      {
        int portValue;
        if (int.TryParse(port, out portValue))
        {
          allowedPorts.Add(portValue);
        }
      }
      return allowedPorts;
    }

    private void AddPorts(IEnumerable<Port> ports)
    {
      foreach (var port in ports)
      {
        m_installerPorts.Add(port);
      }
    }

    private void ParcePortBoundaries()
    {
      CheckRequiredProperties();

      if (!int.TryParse(m_session[Properties.PortLowerBound], out m_portLowerBound))
      {
        m_portLowerBound = IPEndPoint.MinPort;
      }

      if (!int.TryParse(m_session[Properties.PortUpperBound], out m_portUpperBound))
      {
        m_portUpperBound = IPEndPoint.MaxPort;
      }
    }

    private void CheckRequiredProperties()
    {
      if (string.IsNullOrEmpty(m_session[Properties.PortLowerBound]) ||
          string.IsNullOrEmpty(m_session[Properties.PortUpperBound]))
      {
        throw new InstallerException(string.Format(
          CultureInfo.InvariantCulture,
          "CheckRequiredProperties: Error. Mandatory properties '{0}' and '{1}' are not defined!",
          Properties.PortLowerBound,
          Properties.PortUpperBound));
      }
    }

    private IEnumerable<int> GetOccupiedByInstaller(string propertyToIgnore)
    {
      var list = new List<int>();
      foreach (var port in m_installerPorts)
      {
        if (!port.Contains(propertyToIgnore))
        {
          var portNumber = port.ValueAsInt;
          if (0 != portNumber)
          {
            list.Add(portNumber);
          }
        }
      }
      return list;
    }

    public ActionResult TryFindFreePorts()
    {
      try
      {
        FindFreePorts();
      }
      catch (InstallerException exception)
      {
        m_session.Log(exception.Message);
        return ActionResult.Failure;
      }

      return ActionResult.Success;
    }

    private void FindFreePorts()
    {
      var freePorts = GetFreePorts(m_installerPorts.Count);
      var emptyPorts = new List<Port>();
      foreach (var port in m_installerPorts)
      {
        if (!port.IsEmpty)
        {
          freePorts.Remove(port.Value);
        }
        else
        {
          emptyPorts.Add(port);
        }
      }

      for (var i = 0; i < emptyPorts.Count; ++i)
      {
        emptyPorts[i].Set(freePorts[i]);
      }
    }

    private List<string> GetFreePorts(int portAmmount)
    {
      if (portAmmount < 0)
      {
        return new List<string>(0);
      }

      var freePorts = new PortManager().GetFreePorts(portAmmount, m_portLowerBound, m_portUpperBound);
      if (portAmmount > freePorts.Count)
      {
        throw new InstallerException(string.Format(
          CultureInfo.InvariantCulture,
          "GetFreePorts: Error. Not enough free ports in range {0}:{1}!",
          m_portLowerBound,
          m_portUpperBound));
      }

      return freePorts.ConvertAll(x => x.ToString(CultureInfo.InvariantCulture));
    }
  }
}