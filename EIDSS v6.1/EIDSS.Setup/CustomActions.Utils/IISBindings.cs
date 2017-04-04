namespace CustomActions.Utils
{
  using System;
  using System.Collections.Generic;
  using System.Collections.ObjectModel;
  using Microsoft.Web.Administration;


  internal sealed class IISBindings
  {
    private static readonly IISBindings s_instance = new IISBindings();
    private readonly List<int> m_occupiedPorts = new List<int>();

    // Explicit static constructor to tell C# compiler
    // not to mark type as beforefieldinit
    static IISBindings()
    {
    }

    private IISBindings()
    {
      if (InternetInformationServicesDetection.Instance.IsInstalled(InternetInformationServicesVersion.IIS7))
      {
        FindIISBindings();
      }
    }

    internal static IISBindings Instance
    {
      get
      {
        return s_instance;
      }
    }

    internal ReadOnlyCollection<int> OccupiedPorts
    {
      get { return m_occupiedPorts.AsReadOnly(); }
    }

    private void FindIISBindings()
    {
      using (var sm = new ServerManager())
      {
        foreach (var site in sm.Sites)
        {
          ParceBindings(site);
        }
      }
    }

    private void ParceBindings(ConfigurationElement site)
    {
      foreach (var binding in site.GetCollection("bindings"))
      {
        var protocol = (string)binding["protocol"];

        if (protocol.StartsWith("http", StringComparison.OrdinalIgnoreCase) ||
            protocol.StartsWith("https", StringComparison.OrdinalIgnoreCase))
        {
          var parts = ((string)binding["bindingInformation"]).Split(':');
          if (parts.Length == 3)
          {
            //Get the port in use HERE !!!
            int port;
            if (int.TryParse(parts[1], out port))
            {
              m_occupiedPorts.Add(port);
            }
          }
        }
      }
    }
  }
}