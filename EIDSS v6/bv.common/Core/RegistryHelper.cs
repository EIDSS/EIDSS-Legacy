using System;
using bv.common.Diagnostics;
using Microsoft.Win32;

namespace bv.common.Core
{
    public class RegistryHelper
    {
        private static RegistryView GetRegistryView()
        {
            if (OsVersionHelper.Is64BitOperatingSystem())
                return RegistryView.Registry64;
            return RegistryView.Registry32;
        }

        private static string GetSectionName(string section)
        {
            if (OsVersionHelper.Is64BitOperatingSystem())
                return section + "\\Wow6432Node";
            return section;
        }

        public static string Read(string section, string keyName, string valueName)
        {
            string rekKeyName = GetSectionName(section) + "\\" + keyName;
            RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, GetRegistryView()).OpenSubKey(rekKeyName);
            if (key == null)
            {
                Dbg.Debug("registry key <{0}> is not found", keyName);
                return "";
            }

            object val = key.GetValue(valueName);
            key.Close();
            if (val == null)
            {
                Dbg.Debug("value for registry key <{0}> is not defined", keyName);
                return "";
            }
            return val.ToString();

        }

        public static void DeleteValue(string section, string keyName, string valueName, string value)
        {
            try
            {
                string fullKeyName = GetSectionName(section) + "\\" + keyName;
                RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, GetRegistryView()).OpenSubKey(fullKeyName,true);
                if (key != null)
                {
                    key.DeleteValue(valueName);
                    key.Close();
                }
                else
                {
                    Dbg.Debug("can\'t open key {0} in registry", fullKeyName);
                }
            }
            catch (Exception ex)
            {
                Dbg.Debug("can\'t delete registry value {0}:{1}, error - {2}", valueName, value, ex);
            }
        }
        public static void DeleteSubkey(string section, string keyName)
        {
            try
            {
                string fullKeyName = GetSectionName(section) + "\\" + keyName;
                RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, GetRegistryView()).OpenSubKey(GetSectionName(section), true);
                if (key != null)
                {
                    RegistryKey subKey = key.OpenSubKey(keyName, true);
                    if (subKey != null)
                    {
                        key.DeleteSubKey(keyName);
                        key.Close();
                    }
                    else
                    {
                        Dbg.Debug("can\'t open key {0} in registry", fullKeyName);
                    }
                }
            }
            catch (Exception ex)
            {
                Dbg.Debug("can\'t delete registry key {0}:{1}, error - {2}", keyName, ex);
            }
        }
        public static void Write(string section, string keyName, string valueName, string value)
        {
            try
            {
                string fullKeyName = GetSectionName(section) + "\\" + keyName;
                RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, GetRegistryView()).OpenSubKey(fullKeyName,true) ??
                                  RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, GetRegistryView()).CreateSubKey(fullKeyName, RegistryKeyPermissionCheck.ReadWriteSubTree);
                if (key != null)
                {
                    key.SetValue(valueName, value);
                    key.Close();
                }
                else
                {
                    Dbg.Debug("can\'t create key {0} in registry", fullKeyName);
                }
            }
            catch (Exception ex)
            {
                Dbg.Debug("can\'t write to registry {0}:{1}, error - {2}", valueName, value, ex);
            }
        }

        private const string EidssRegistryKey = "EIDSS 6.0";

        public static void WriteEidssValue(string valueName, string value)
        {
            Write("SOFTWARE", EidssRegistryKey, valueName, value);
        }
        public static string ReadEidssValue(string valueName)
        {
            return Read("SOFTWARE", EidssRegistryKey, valueName);
        }
    }
}
