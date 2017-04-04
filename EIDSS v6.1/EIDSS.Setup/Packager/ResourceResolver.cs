namespace SetupExe
{
  using System;
  using System.Globalization;
  using System.IO;
  using System.Linq;
  using System.Reflection;
  using Ionic.Zip;


  internal sealed class ResourceResolver
  {
    private readonly ILogger m_logger;

    internal ResourceResolver(ILogger logger)
    {
      if (null == logger)
      {
        throw new ArgumentNullException("logger");
      }

      m_logger = logger;
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
      "Microsoft.Globalization",
      "CA1303:Do not pass literals as localized parameters",
      MessageId = "SetupExe.ILogger.Log(System.String)")]
    internal Assembly AssemblyResolve(object sender, ResolveEventArgs args)
    {
      var resourceMask = new AssemblyName(args.Name).Name + ".dll";
      m_logger.Log(string.Format(
        CultureInfo.InvariantCulture,
        "Resolving assembly '{0}'",
        resourceMask));
      using (var stream = GetResourceStream(resourceMask))
      {
        var assbebmlyBytes = new byte[stream.Length];
        stream.Read(assbebmlyBytes, 0, assbebmlyBytes.Length);
        return Assembly.Load(assbebmlyBytes);
      }
    }

    private static Stream GetResourceStream(string resourceMask)
    {
      var execAsm = Assembly.GetExecutingAssembly();
      var resourceName = execAsm.GetManifestResourceNames()
        .FirstOrDefault(s => s.EndsWith(resourceMask, StringComparison.OrdinalIgnoreCase));
      if (!string.IsNullOrEmpty(resourceName))
      {
        return execAsm.GetManifestResourceStream(resourceName);
      }
      throw new ResourceResolverException(resourceMask);
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
      "Microsoft.Globalization",
      "CA1303:Do not pass literals as localized parameters",
      MessageId = "SetupExe.ILogger.Log(System.String)")]
    internal void UnpackResources(string path)
    {
      m_logger.Log("Resolving zipped resources");

      const string ZipMask = ".zip";
      using (var stream = GetResourceStream(ZipMask))
      {
        Unpack(stream, path);
      }
    }

    private static void Unpack(Stream stream, string path)
    {
      using (var zipFile = ZipFile.Read(stream))
      {
        TryUnpack(zipFile, path);
      }
    }

    private static void TryUnpack(ZipFile archive, string path)
    {
      try
      {
        archive.ExtractAll(path);
      }
      catch (Exception ex)
      {
        throw new ResourceResolverException(ex.Message, ex);
      }
    }
  }
}