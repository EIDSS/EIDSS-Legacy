namespace InstanceManager
{
  using Microsoft.Win32;

  internal class RegistrationKey
  {
    internal string Key { get; private set; }
    internal RegistryView KeyBitness { get; private set; }

    internal RegistrationKey(string key, string bitness)
    {
      Key = key;

      switch (bitness)
      {
        case Bitness.X32:
          KeyBitness = RegistryView.Registry32;
          break;
        case Bitness.X64:
          KeyBitness = RegistryView.Registry64;
          break;
        default:
          throw new InstanceManagerException("Unknown platform ({0})", bitness);
      }
    }
  }
}