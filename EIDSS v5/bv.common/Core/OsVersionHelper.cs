using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace bv.common.Core
{
    public static class OsVersionHelper
    {

        public static string ReplaceProgramFileInPath(string path)
        {
            if ((path == null) || (path.Length == 0))
            {
                return path;
            }
#if !MONO
            if (Is64BitOperatingSystem() == true)
            {
                return (path.Replace("%ProgramFiles%", Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86)));
            }
#endif
            return (path.Replace("%ProgramFiles%", Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)));
        }

        /// <summary>
        /// Represents whether current OS is 64-bit. Returns result of 64but OS on all versions of windows that support .net
        /// </summary>
        /// <returns>Returns true, id OS is 64-bit, false if OS is 32-bit.</returns>
        public static bool Is64BitOperatingSystem()
        {
            if (IntPtr.Size == 8) //64bit will only run on 64bit
            {
                return true;
            }

            bool flag;
            return (DoesWin32MethodExist("kernel32.dll", "IsWow64Process") && IsWow64Process(GetCurrentProcess(), out flag)) && flag;
        }

        /// <summary>
        /// Checks if Win32 method exist in current OS.
        /// </summary>
        /// <param name="moduleName">Module name</param>
        /// <param name="methodName">Method name</param>
        /// <returns>Returns true, if method exists, otherwise - false.</returns>
        private static bool DoesWin32MethodExist(string moduleName, string methodName)
        {
            IntPtr moduleHandle = GetModuleHandle(moduleName);

            if (moduleHandle == IntPtr.Zero)
            {
                return false;
            }

            return GetProcAddress(moduleHandle, methodName) != IntPtr.Zero;
        }

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern IntPtr GetCurrentProcess();

        [System.Runtime.InteropServices.DllImport("kernel32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        private static extern IntPtr GetModuleHandle(string moduleName);

        [System.Runtime.InteropServices.DllImport("kernel32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetProcAddress(IntPtr module, [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPStr)]string procName);

        [System.Runtime.InteropServices.DllImport("kernel32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
        [return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
        private static extern bool IsWow64Process(IntPtr process, out bool wow64Process);

    } 

}
