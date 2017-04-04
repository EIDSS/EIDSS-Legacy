namespace CustomActions
{
  using System;
  using System.Globalization;
  using AVRService;
  using Microsoft.Deployment.WindowsInstaller;

  public static class ServiceDetector
  {
    [CustomAction]
    public static ActionResult PingAVRService(Session session)
    {
      session.Log("Begin PingService");

      var address = session[Properties.AVRServiceHostUrl];
      if (!UrlIsBad(address))
      {
        AVRFacadeClient avrFacade = null;
        try
        {
          avrFacade = new AVRFacadeClient("BasicHttpBinding_IAVRFacade", address);
          CompareVersions(
            GetServiceVersion(session, avrFacade),
            session[Properties.MajorVersion], session[Properties.MinorVersion], session[Properties.Build]);
        }
        catch (UriFormatException ex)
        {
          session.Log(ex.Message);
          s_pingResult = PingServiceResult.BadUrl;
        }
        catch (Exception ex)
        {
          session.Log(ex.Message);
          return ActionResult.Failure;
        }
        finally
        {
          if (avrFacade != null)
          {
            avrFacade.Close();
          }
        }
      }

      return ParseError(session, s_pingResult);
    }


    private static PingServiceResult s_pingResult = PingServiceResult.Success;

    private static ActionResult ParseError(Session session, PingServiceResult result)
    {
      switch (result)
      {
        case PingServiceResult.UrlIsEmpty:
          SetPingFailed(session, Properties.ServiceHostUrlIsEmpty);
          break;
        case PingServiceResult.BadUrl:
          SetPingFailed(session, Properties.BadUrl);
          break;
        case PingServiceResult.PingUnsuccessful:
          SetPingFailed(session, Properties.ServicePingFailed);
          break;
        case PingServiceResult.VersionMismatch:
          SetPingFailed(session, Properties.VersionMismatch);
          break;
        case PingServiceResult.Success:
          SetPingSucceeded(session);
          break;
        default:
          return ActionResult.Failure;
      }
      return ActionResult.Success;
    }

    private static void CompareVersions
      (Version serviceVersion, string installerMajorVersion, string installerMinorVersion, string installerBuild)
    {
      if (!BadVersion.IsVersionBad(serviceVersion)
        && !VersionsAreEqual(serviceVersion, installerMajorVersion, installerMinorVersion, installerBuild))
      {
        s_pingResult = PingServiceResult.VersionMismatch;
      }
    }

    private static Version GetServiceVersion(Session session, IAVRFacade avrFacade)
    {
      try
      {
        return avrFacade.GetServiceVersion();
      }
      catch (UriFormatException ex)
      {
        session.Log(ex.Message);
        s_pingResult = PingServiceResult.BadUrl;
      }
      catch (Exception ex)
      {
        session.Log(ex.Message);
        s_pingResult = PingServiceResult.PingUnsuccessful;
      }
      return BadVersion.GetBadVersion;
    }

    private static void SetPingFailed(Session session, string pingResultProperty)
    {
      if (string.IsNullOrEmpty(pingResultProperty))
      {
        throw new ArgumentNullException(pingResultProperty);
      }

      session[Properties.BadServicePingText] = session.Format(session[pingResultProperty]);
      session[Properties.AVRServiceHostUrlValid] = "0";
    }

    private static void SetPingSucceeded(Session session)
    {
      session[Properties.BadServicePingText] = string.Empty;
      session[Properties.AVRServiceHostUrlValid] = "1";
    }

    private static bool VersionsAreEqual(Version version1, string major2, string minor2, string build2)
    {
      return VersionsAreEqual(
        version1, new Version(
          Convert.ToInt32(major2, CultureInfo.InvariantCulture),
          Convert.ToInt32(minor2, CultureInfo.InvariantCulture),
          Convert.ToInt32(build2, CultureInfo.InvariantCulture)
          ));
    }

    private static bool VersionsAreEqual(Version version1, Version version2)
    {
      return version1.Major == version2.Major && version1.Minor == version2.Minor && version1.Build == version2.Build;
    }

    private static bool UrlIsBad(string address)
    {
      return IsUriEmpty(address) || IsUriBadFormatted(address);
    }

    private static bool IsUriEmpty(string address)
    {
      if (!string.IsNullOrEmpty(address))
      {
        return false;
      }
      s_pingResult = PingServiceResult.UrlIsEmpty;
      return true;
    }

    private static bool IsUriBadFormatted(string address)
    {
      if (Uri.IsWellFormedUriString(address, UriKind.RelativeOrAbsolute))
      {
        return false;
      }
      s_pingResult = PingServiceResult.BadUrl;
      return true;
    }
  }

  internal enum PingServiceResult
  {
    FatalError = 0,
    UrlIsEmpty,
    BadUrl,
    PingUnsuccessful,
    VersionMismatch,
    Success
  }

  internal static class BadVersion
  {
    private static readonly Lazy<Version> s_lazy = new Lazy<Version>(() => new Version(0, 0, 0, 0));

    internal static Version GetBadVersion { get { return s_lazy.Value; } }

    internal static bool IsVersionBad(Version version)
    {
      return version == GetBadVersion;
    }
  }
}