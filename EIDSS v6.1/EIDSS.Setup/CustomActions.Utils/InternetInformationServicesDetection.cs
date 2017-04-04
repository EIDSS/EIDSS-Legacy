namespace CustomActions.Utils
{
  using System;
  using Microsoft.Win32;


  internal enum InternetInformationServicesVersion
  {
    IIS4 = 4,
    IIS5 = 5,
    IIS6 = 6,
    IIS7 = 7,
  }

  internal sealed class InternetInformationServicesDetection
  {
    private static readonly Lazy<InternetInformationServicesDetection> s_lazy =
      new Lazy<InternetInformationServicesDetection>(() => new InternetInformationServicesDetection());

    public static InternetInformationServicesDetection Instance { get { return s_lazy.Value; } }


    private const string IISRegKeyName = @"Software\Microsoft\InetStp\";
    private const string IISRegKeyValue = "MajorVersion";
    private const int IISAbsentMark = -1;
    private readonly int m_iisMajorVersion;

    private InternetInformationServicesDetection()
    {
      using (var hklm = Registry.LocalMachine)
      using (var iisKey = hklm.OpenSubKey(IISRegKeyName))
      {
        if (null != iisKey)
        {
          m_iisMajorVersion = (int)iisKey.GetValue(IISRegKeyValue, IISAbsentMark);
        }
      }
    }

    internal bool IsInstalled(InternetInformationServicesVersion iisVersion)
    {
      return (int)iisVersion == m_iisMajorVersion;
    }
  }
}