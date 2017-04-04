namespace InstanceManager
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using Microsoft.Deployment.WindowsInstaller;
  using Microsoft.Deployment.WindowsInstaller.Package;


  internal sealed class Instance : IComparable<Instance>
  {
    internal static string DefaultInstance;
    internal static string CurrentInnerVersion;

    internal string Name { get; private set; }
    internal string ProductName { get; private set; }
    internal string ProductCode { get; private set; }
    internal bool IsFree { get; private set; }
    internal bool IsDefault { get; private set; }
    internal bool IsUpgradable { get; private set; }
    internal bool IsInstalled { get; private set; }

    internal static Instance EmptyInstance()
    {
      return new Instance(string.Empty, string.Empty, false);
    }

    internal static Instance MakeInstance(string name, string productCode)
    {
      return new Instance(name, productCode, false);
    }

    internal static Instance MakeInstance(string name, bool isFree)
    {
      return new Instance(name, string.Empty, isFree);
    }

    private Instance(string name, string productCode, bool isFree)
    {
      CheckStatic();

      Name = name;
      ProductCode = productCode;

      var installedProduct = GetInstalledProduct(productCode);
      IsInstalled = null != installedProduct;

      ProductName = ExtractProductName(installedProduct);
      IsFree = isFree;
      IsDefault = IsInstanceDefault(Name);
      IsUpgradable = IsInstanceUpgradableToCurrentVersion(ExtractInnerVersion(installedProduct));
    }

    private static ProductInstallation GetInstalledProduct(string productCode)
    {
      return !string.IsNullOrEmpty(productCode)
        ? ProductInstallation.GetProducts(productCode, null, UserContexts.Machine).FirstOrDefault()
        : null;
    }

    private static void CheckStatic()
    {
      if (string.IsNullOrEmpty(DefaultInstance))
      {
        throw new InstanceManagerException("Mandatory static member \"DefaultInstance\" is uninitialized!");
      }
      if (string.IsNullOrEmpty(CurrentInnerVersion))
      {
        throw new InstanceManagerException("Mandatory static member \"CurrentInnerVersion\" is uninitialized!");
      }
    }

    private static string ExtractProductName(ProductInstallation installedProduct)
    {
      return null == installedProduct ? string.Empty : installedProduct.ProductName;
    }

    private static string ExtractInnerVersion(ProductInstallation installedProduct)
    {
      if (null == installedProduct)
      {
        return string.Empty;
      }

      var localPackage = installedProduct.LocalPackage;
      if (string.IsNullOrEmpty(localPackage))
      {
        return string.Empty;
      }

      string innerVersion;
      using (var msiBase = new InstallPackage(localPackage, DatabaseOpenMode.ReadOnly))
      {
        innerVersion = msiBase.Property["InnerVersion"];
      }

      return string.IsNullOrEmpty(innerVersion) ? string.Empty : innerVersion;
    }

    private static bool IsInstanceDefault(string name)
    {
      return name.Equals(DefaultInstance, StringComparison.OrdinalIgnoreCase);
    }

    private static bool IsInstanceUpgradableToCurrentVersion(string version)
    {
      return !version.Equals(CurrentInnerVersion, StringComparison.OrdinalIgnoreCase);
    }

    public int CompareTo(Instance other)
    {
      return String.CompareOrdinal(Name, null == other ? string.Empty : other.Name);
    }
  }

  internal class Instances : List<Instance>
  {
    internal bool Contains(string instanceToSearch)
    {
      return this.Any(instance => instance.Name.Equals(instanceToSearch, StringComparison.OrdinalIgnoreCase));
    }
  }
}