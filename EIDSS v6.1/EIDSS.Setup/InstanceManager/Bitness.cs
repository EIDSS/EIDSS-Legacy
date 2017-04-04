namespace InstanceManager
{
  using System;

  internal static class Bitness
  {
    internal static bool Equals(string bitness1, string bitness2)
    {
      if (string.IsNullOrEmpty(bitness1))
      {
        bitness1 = X32;
      }
      if (string.IsNullOrEmpty(bitness2))
      {
        bitness2 = X32;
      }

      return bitness1.Equals(bitness2, StringComparison.OrdinalIgnoreCase);
    }

    internal const string X32 = "Intel";
    internal const string X64 = "x64";
  }
}