namespace SetupExe
{
  using System.Collections.Generic;
  using Modes;


  internal static partial class ProgramEntryPoint
  {
    private static IMode GetExecuteMode(
      IList<string> arguments,
      ResourceResolver resourceResolver,
      ILogger logger)
    {
      return new ExecuteMsiExecMode(arguments, resourceResolver, logger);
    }
  }
}