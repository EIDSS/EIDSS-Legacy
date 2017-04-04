using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace InstanceManager.MsiLauncher
{
  internal sealed class Commander
  {
    private readonly Dictionary<string, ICommand> m_commands = new Dictionary<string, ICommand>();
    private readonly string m_msi;

    internal static Commander ClassInstance;
    private Process m_process;

    // Explicit static constructor to tell C# compiler not to mark type as beforefieldinit
    [SuppressMessage(
                     "Microsoft.Performance",
                     "CA1810:InitializeReferenceTypeStaticFieldsInline",
                     Justification = "Explicit static constructor to tell C# compiler not to mark type as beforefieldinit")]
    static Commander()
    {
    }

    internal static Commander CreateCommander(string msi)
    {
      return ClassInstance ?? (ClassInstance = new Commander(msi));
    }

    internal static void DestroyClassInstance()
    {
      if (null != ClassInstance)
      {
        ClassInstance.ShutDown();
      }
    }

    private void ShutDown()
    {
      if (null != m_process)
      {
        m_process.WaitForExit();
      }
    }

    private Commander(string msi)
    {
      m_msi = msi;
    }

    internal void Run(string commandName, params object[] args)
    {
      m_process = GetCommand(commandName).Run(m_msi, args);
    }

    internal static void RegisterCommand(string commandName, ICommand command)
    {
      ClassInstance.m_commands.Add(commandName, command);
    }

    private ICommand GetCommand(string commandName)
    {
      return m_commands[commandName];
    }
  }
}