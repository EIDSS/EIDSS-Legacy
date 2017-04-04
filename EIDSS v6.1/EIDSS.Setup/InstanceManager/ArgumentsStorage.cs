using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace InstanceManager
{
  internal sealed class ArgumentsStorage
  {
    internal static ArgumentsStorage Instance;
    private readonly ICollection<string> m_args = new List<string>(0);

    // Explicit static constructor to tell C# compiler not to mark type as beforefieldinit
    [SuppressMessage(
                     "Microsoft.Performance",
                     "CA1810:InitializeReferenceTypeStaticFieldsInline",
                     Justification = "Explicit static constructor to tell C# compiler not to mark type as beforefieldinit")]
    static ArgumentsStorage()
    {
    }

    private ArgumentsStorage(IEnumerable<string> args)
    {
      foreach (var arg in args)
      {
        m_args.Add(ArgumentRequiresQuotes(arg) ? "\"" + arg + "\"" : arg);
      }
    }

    private static bool ArgumentRequiresQuotes(string argument)
    {
      return argument.Contains(" ") | argument.Contains("\t");
    }

    internal static ArgumentsStorage CreateStorage(string[] args)
    {
      return Instance ?? (Instance = new ArgumentsStorage(args));
    }

    //internal ICollection<string> Arguments
    //{
    //  get { return m_args; }
    //}

    internal string ArgumentsLine
    {
      get { return string.Join(" ", m_args); }
    }
  }
}
