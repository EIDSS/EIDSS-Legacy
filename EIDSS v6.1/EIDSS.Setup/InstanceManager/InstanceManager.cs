namespace InstanceManager
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics.CodeAnalysis;
  using System.Linq;
  using Microsoft.Win32;


  internal sealed class InstanceManager
  {
    private readonly Instances m_upgradableInstances = new Instances();
    private readonly Instances m_maintainableInstances = new Instances();
    private readonly List<string> m_instancePool = new List<string>();
    private Instance m_freeInstance;

    internal static InstanceManager ClassInstance;

    // Explicit static constructor to tell C# compiler not to mark type as beforefieldinit
    [SuppressMessage(
                     "Microsoft.Performance",
                     "CA1810:InitializeReferenceTypeStaticFieldsInline",
                     Justification = "Explicit static constructor to tell C# compiler not to mark type as beforefieldinit")]
    static InstanceManager()
    {
    }

    internal static InstanceManager CreateManager(RegistrationKey instanceRegistryKey, string instancePool)
    {
      return ClassInstance ?? (ClassInstance = new InstanceManager(instanceRegistryKey, instancePool));
    }

    internal Instance FreeInstance
    {
      get
      {
        if (null == m_freeInstance)
        {
          m_freeInstance = Instance.EmptyInstance();
          foreach (var instance in m_instancePool.Where(instance => !m_upgradableInstances.Contains(instance) && !m_maintainableInstances.Contains(instance)))
          {
            m_freeInstance = Instance.MakeInstance(instance, true);
            return m_freeInstance;
          }
        }
        return m_freeInstance;
      }
    }

    internal bool AnyUpgradable
    {
      get { return m_upgradableInstances.Any(); }
    }

    internal bool AnyMaintainable
    {
      get { return m_maintainableInstances.Any(); }
    }

    internal bool AnyInstalled
    {
      get { return AnyUpgradable || AnyMaintainable; }
    }


    internal bool AnyFree
    {
      get { return FreeInstance.IsFree; }
    }

    internal int UpgradableCount
    {
      get
      {
        return m_upgradableInstances.Count();
      }
    }

    internal int MaintainableCount
    {
      get
      {
        return m_maintainableInstances.Count();
      }
    }

    internal Instances Upgradable
    {
      get { return m_upgradableInstances; }
    }

    internal Instances Maintainable
    {
      get { return m_maintainableInstances; }
    }

    private InstanceManager(RegistrationKey instanceRegistryKey, string instancePool)
    {
      ReadInstancesFromRegistry(instanceRegistryKey);
      ExtractInstancePool(instancePool);
    }

    private void ReadInstancesFromRegistry(RegistrationKey instancesRegistryKey)
    {
      using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, instancesRegistryKey.KeyBitness))
      using (var instancesKey = hklm.OpenSubKey(instancesRegistryKey.Key))
      {
        if (null != instancesKey && 0 != instancesKey.ValueCount)
        {
          ReadInstancesFromRegistryKey(instancesKey);
        }
      }
    }

    private void ReadInstancesFromRegistryKey(RegistryKey instancesKey)
    {
      foreach (var instance in instancesKey.GetValueNames())
      {
        ReadInstance(instancesKey, instance);
      }
      m_upgradableInstances.Sort();
      m_maintainableInstances.Sort();
    }

    private void ReadInstance(RegistryKey instancesKey, string instance)
    {
      var newInstance = Instance.MakeInstance(instance, instancesKey.GetValue(instance) as string);
      if (!newInstance.IsInstalled)
      {
        return;
      }
      if (newInstance.IsUpgradable)
      {
        m_upgradableInstances.Add(newInstance);
      }
      else
      {
        m_maintainableInstances.Add(newInstance);
      }
    }

    private void ExtractInstancePool(string instancePool)
    {
      m_instancePool.AddRange(instancePool.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries));
    }
  }
}
