using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.Diagnostics;
using bv.common.Enums;
using bv.model.Model.Core;
using System.Security.AccessControl;
namespace bv.winclient.Core
{
    public class OneInstanceApp
    {

        public static bool Run(bool activateFirstInstance, ref bool showMessage)
        {
            if (!CheckAumMutex())
            {
                showMessage = false;
                return false;
            }
            showMessage = true;
            string mutexName = GetMutexName();
            if (mutexName == null)
                return false;
            if (IsMutexCreated(mutexName))
                return true;
            if (activateFirstInstance)
            {
                IntPtr mainWindowHandle = GetMainWindowHandle();
                if (mainWindowHandle.Equals(IntPtr.Zero) == false)
                {
                    if (WindowsAPI.IsIconic(mainWindowHandle))
                    {
                        WindowsAPI.ShowWindow(mainWindowHandle, WindowsAPI.SW_RESTORE);
                    }
                    else
                    {
                        WindowsAPI.SetForegroundWindow(mainWindowHandle);
                    }
                }
            }
            return false;
        }
        private static Mutex m_Mutex = null;
        public static bool IsMutexCreated(string mutexName)
        {
            if (mutexName == null)
                return false;
            Dbg.Debug("trying to create mutex:" + mutexName);
            try
            {
                Mutex mutex = Mutex.OpenExisting(mutexName, MutexRights.FullControl);
                if (mutex != null)
                    return false;
            }
            catch (WaitHandleCannotBeOpenedException)
            {
                //не найден, можно продолжать работу
            }
            catch (UnauthorizedAccessException)
            {
                return false;
            }
            bool newMutexCreated = false;
            try
            {
                m_Mutex = new Mutex(true, mutexName, out newMutexCreated);
            }
            catch (Exception ex)
            {
                ErrorForm.ShowError(StandardError.UnprocessedError, ex);
                Application.Exit();
            }

            if (newMutexCreated)
            {
                Dbg.Debug("new mutex is created:" + mutexName);
                return true;
            }
            Dbg.Debug("mutex with name " + mutexName + " exits already");
            return false;

        }
        public static void RegisterMainWindowHandle(Form frm)
        {
            return;

        }

        private static bool CheckAumMutex()
        {
            Mutex mutexUpdateNow;
            bool alone;
            const string mutexText = "aumupdatenow";
            Dbg.Debug("aum mutex checking...");
            try
            {
                mutexUpdateNow = Mutex.OpenExisting(mutexText, MutexRights.FullControl);
                alone = false;
            }
            catch (WaitHandleCannotBeOpenedException)
            {
                //не найден, можно продолжать работу
                alone = true;

            }
            catch (UnauthorizedAccessException)
            {
                alone = false;
            }

            Dbg.Debug("aum mutex alone={0}", alone);

            if (!alone)
            {
                Dbg.Debug("EIDSS now exit because aum (bvupdater) is running");

            }
            return alone;
        }
        private static string GetMutexName()
        {
            ProcessModule module = Process.GetCurrentProcess().MainModule;
            if (module == null)
                return null;
            string mutexName = GetProcessName();
            FileVersionInfo ver = module.FileVersionInfo;
            mutexName += ver.FileMajorPart.ToString();
            if (BaseSettings.OneInstanceMethod.ToLowerInvariant() == "client")
                mutexName += ModelUserContext.ClientID;
            else if (BaseSettings.OneInstanceMethod.ToLowerInvariant() == "user")
                mutexName += Environment.UserName;
            return mutexName;
        }

        private static string GetProcessName()
        {
            ProcessModule module = Process.GetCurrentProcess().MainModule;
            if (module == null)
                return null;
            string processName = module.ModuleName.ToLowerInvariant();
            return Path.GetFileNameWithoutExtension(processName);
        }
        private static IntPtr GetMainWindowHandle()
        {
            string processName = GetProcessName();
            if (processName == null)
                return IntPtr.Zero;
            processName = Path.GetFileNameWithoutExtension(processName);
            Process[] processes = Process.GetProcessesByName(processName);
            Dbg.Debug("retrieving window handle for process:" + processName);

            //Loop through the running processes in with the same name


            Process current = Process.GetCurrentProcess();

            foreach (Process p in processes)
            {
                //Ignore the current process
                if (p.MainModule != null && current.MainModule != null)
                    if (p.MainModule.FileName != current.MainModule.FileName)
                    {
                        Dbg.Debug("process " + processName + " is found");
                        return p.MainWindowHandle;
                    }
            }
            Dbg.Debug("process " + processName + " is not found");
            return IntPtr.Zero;
        } //RunningInstance

    }
}