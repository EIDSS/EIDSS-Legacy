namespace CustomActions.Utils
{
  using System.Collections.Generic;
  using System.Net.NetworkInformation;


  public class PortManager
  {
    private readonly List<int> m_occupiedPorts = new List<int>();

    public PortManager()
    {
      m_occupiedPorts.AddRange(IISBindings.Instance.OccupiedPorts);
      FindTcpOccupiedPorts();
    }

    public PortManager(IEnumerable<int> occupiedByInstaller)
      : this()
    {
      AddCustomRange(occupiedByInstaller);
    }

    private void AddCustomRange(IEnumerable<int> range)
    {
      if (null != range)
      {
        m_occupiedPorts.AddRange(range);
      }
    }

    public int GetFreePort(int portLowerBound, int portUpperBound)
    {
      var freePort = portLowerBound;
      do
      {
        if (!m_occupiedPorts.Contains(freePort))
        {
          return freePort;
        }
        ++freePort;
      } while (freePort <= portUpperBound);
      return 0;
    }

    public List<int> GetFreePorts(int portAmount, int portLowerBound, int portUpperBound)
    {
      var freePorts = new List<int>(portAmount);
      for (var port = portLowerBound; port < portUpperBound && freePorts.Count < portAmount; ++port)
      {
        if (!m_occupiedPorts.Contains(port))
        {
          freePorts.Add(port);
        }
      }

      return freePorts;
    }

    public bool IsPortFree(int port)
    {
      return !m_occupiedPorts.Contains(port);
    }

    private void FindTcpOccupiedPorts()
    {
      var ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
      foreach (var tcpi in ipGlobalProperties.GetActiveTcpConnections())
      {
        m_occupiedPorts.Add(tcpi.LocalEndPoint.Port);
      }

      foreach (var listener in ipGlobalProperties.GetActiveTcpListeners())
      {
        m_occupiedPorts.Add(listener.Port);
      }
    }
  }
}