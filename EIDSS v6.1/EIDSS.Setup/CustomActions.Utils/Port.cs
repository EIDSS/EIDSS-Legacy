namespace CustomActions.Utils
{
  using System.Collections.Generic;
  using System.Linq;
  using Microsoft.Deployment.WindowsInstaller;


  public class Port
  {
    private readonly List<string> m_portNames;
    private bool m_isEmpty = true;
    public static Session Session;

    public Port(string portName)
    {
      m_portNames = new List<string> { portName };
    }

    public Port(List<string> portNames)
    {
      m_portNames = portNames;
    }

    public bool IsEmpty
    {
      get
      {
        if (!string.IsNullOrEmpty(Session[m_portNames[0]]))
        {
          m_isEmpty = false;
        }
        return m_isEmpty;
      }
    }

    public string Value
    {
      get { return m_portNames.Any() ? Session[m_portNames[0]] : "0"; }
    }

    public int ValueAsInt
    {
      get
      {
        int portNumber;
        int.TryParse(Value, out portNumber);
        return portNumber;
      }
    }

    public void Set(string value)
    {
      m_isEmpty = false;
      foreach (var portName in m_portNames)
      {
        Session[portName] = value;
      }
    }

    public bool Contains(string portName)
    {
      return m_portNames.Contains(portName);
    }

    public override string ToString()
    {
      return string.Join(", ", m_portNames);
    }
  }
}