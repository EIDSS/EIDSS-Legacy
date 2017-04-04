using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using InstanceManager.MsiLauncher;
using InstanceManager.Properties;
using InstanceManager.UI;
using Microsoft.Deployment.WindowsInstaller;
using Microsoft.Deployment.WindowsInstaller.Package;

namespace InstanceManager
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static int Main(string[] args)
    {
      try
      {
        CallFactories(args);
        Run();
        return 0;
      }
      catch (KeyNotFoundException exception)
      {
        MessageBox.Show(exception.Message, Resources.ExceptionBoxCaption);
        Console.Error.WriteLine(exception);
      }
      catch (InstanceManagerException exception)
      {
        MessageBox.Show(exception.Message, Resources.ExceptionBoxCaption);
        Console.Error.WriteLine(exception);
      }
      finally
      {
        ShutDown();
      }
      return 1;
    }

    private static void CallFactories(string[] args)
    {
      ArgumentsStorage.CreateStorage(args);

      var msi = FindAppropriateMsi();
      CreateInstanceManager(msi);
      CreateCommander(msi);
    }

    private static void ShutDown()
    {
      Commander.DestroyClassInstance();
    }

    private static void Run()
    {
      if (InstanceManager.ClassInstance.AnyInstalled)
      {
        using (var wizard = new SimpleFormsWizard())
        {
          wizard.Run();
        }
      }
      else
      {
        Commander.ClassInstance.Run(InstallFreeInstance.CommandId);
      }
    }



    private static string FindAppropriateMsi()
    {
      // ReSharper disable AssignNullToNotNullAttribute
      var executionDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
      var msis = Directory.EnumerateFiles(executionDirectory, "*.msi");
      // ReSharper restore AssignNullToNotNullAttribute

      return SearchPackage(msis.ToList());
    }

    private static string SearchPackage(IList<string> msis)
    {
      return msis.Count() == 1
        ? msis.First()
        : SearchPackageWithCorrectBitness(
                                          msis,
                                          Environment.Is64BitOperatingSystem ? Bitness.X64 : Bitness.X32);
    }

    private static string SearchPackageWithCorrectBitness(IEnumerable<string> msis, string bitness)
    {
      var appropriateMsis = msis.Where(msi => Bitness.Equals(bitness, GetPackageBitness(msi))).ToList();
      CheckSanity(appropriateMsis, bitness);
      return appropriateMsis[0];
    }

    private static string GetPackageBitness(string msi)
    {
      using (var package = new InstallPackage(msi, DatabaseOpenMode.ReadOnly))
      {
        return GetPackageBitness(package);
      }
    }

    private static string GetPackageBitness(Database package)
    {
      return package.SummaryInfo.Template.Split(new[] { ';' }, StringSplitOptions.None)[0];
    }

    private static void CheckSanity(ICollection<string> appropriateMsis, string bitness)
    {
      if (!appropriateMsis.Any())
      {
        throw new InstanceManagerException("Failed to found msi package with appropriate platform ({0})", bitness);
      }
      if (1 < appropriateMsis.Count)
      {
        throw new InstanceManagerException("Found several msi packages with appropriate platform ({0}): \"{1}\"",
                                           bitness,
                                           String.Join("\", \"", appropriateMsis));
      }
    }

    private static void CreateInstanceManager(string msi)
    {
      using (var package = new InstallPackage(msi, DatabaseOpenMode.ReadOnly))
      {
        const string DefaultInstance = "DEFAULT_INSTANCE";
        Instance.DefaultInstance = GetProperty(package, DefaultInstance);

        Instance.CurrentInnerVersion = GetInnerVersion(package);

        const string InstanceRegistrationProperty = "INSTANCE_REGISTRY";
        var instanceRegistrationKey = GetProperty(package, InstanceRegistrationProperty);

        const string InstancePool = "INSTANCE_POOL";
        var instancePool = GetProperty(package, InstancePool);

        InstanceManager.CreateManager(
                                      new RegistrationKey(instanceRegistrationKey, GetPackageBitness(package)),
                                      instancePool);
      }
    }

    private static string GetInnerVersion(InstallPackage package)
    {
      const string CurrentInnerVersion = "InnerVersion";
      try
      {
        return GetProperty(package, CurrentInnerVersion);
      }
      catch (InstanceManagerException)
      {
        return "0";
      }
    }

    private static string GetProperty(InstallPackage package, string property)
    {
      var propertyValue = package.Property[property];

      if (string.IsNullOrEmpty(propertyValue))
      {
        throw new InstanceManagerException("Msi package {0} doesn't contain mandatory property {1}", package, property);
      }

      return propertyValue;
    }

    private static void CreateCommander(string msi)
    {
      Commander.CreateCommander(msi);
      Commander.RegisterCommand(InstallFreeInstance.CommandId, new InstallFreeInstance());
      Commander.RegisterCommand(UpgradeInstalledInstance.CommandId, new UpgradeInstalledInstance());
      Commander.RegisterCommand(ManageInstalledInstance.CommandId, new ManageInstalledInstance());
    }
  }
}
