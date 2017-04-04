using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace InstanceManager
{
  [System.Diagnostics.CodeAnalysis.SuppressMessage(
                                                   "Microsoft.Naming",
                                                   "CA1702:CompoundWordsShouldBeCasedCorrectly",
                                                   MessageId = "InstanceManager", Justification = "InstanceManager is unreadable"),
  Serializable]
  public class InstanceManagerException : Exception
  {
    public InstanceManagerException()
    {
    }

    public InstanceManagerException(string message)
      : base(message)
    {
    }

    public InstanceManagerException(string message, params object[] args)
      : this(string.Format(CultureInfo.InvariantCulture, message, args))
    {
    }

    public InstanceManagerException(string message, Exception innerException)
      : base(message, innerException)
    {
    }

    protected InstanceManagerException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }
  }
}