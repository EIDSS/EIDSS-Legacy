namespace SetupExe
{
  using System;
  using System.Globalization;
  using System.Runtime.Serialization;


  [System.Diagnostics.CodeAnalysis.SuppressMessage(
    "Microsoft.Design",
    "CA1064:ExceptionsShouldBePublic")]
  [Serializable]
  internal sealed class ResourceResolverException : Exception
  {
    internal ResourceResolverException()
    {
    }

    internal ResourceResolverException(string resourceMask)
      : base(string.Format(
        CultureInfo.InvariantCulture,
        "Resources '*{0}' were not found",
        resourceMask))
    {
    }

    internal ResourceResolverException(string message, Exception innerException)
      : base(message, innerException)
    {
    }

    private ResourceResolverException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }
  }
}