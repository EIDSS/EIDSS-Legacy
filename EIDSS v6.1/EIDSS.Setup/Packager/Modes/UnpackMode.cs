namespace SetupExe.Modes
{
  using System;


  internal sealed class UnpackMode : IMode
  {
    private readonly ResourceResolver m_resourceResolver;
    private readonly string m_unpackPath;

    internal UnpackMode(string unpackPath, ResourceResolver resourceResolver)
    {
      if (string.IsNullOrEmpty(unpackPath))
      {
        throw new ArgumentNullException("unpackPath");
      }
      if (null == resourceResolver)
      {
        throw new ArgumentNullException("resourceResolver");
      }
      m_unpackPath = unpackPath;
      m_resourceResolver = resourceResolver;
    }

    #region IMode Members

    public ErrorCode Run()
    {
      m_resourceResolver.UnpackResources(m_unpackPath);
      return ErrorCode.Success;
    }

    #endregion

    public void Dispose()
    {
    }
  }
}