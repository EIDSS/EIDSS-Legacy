using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using bv.common.Configuration;

namespace bv.common.Core
{
    public class MemoryManager
    {
        [DllImport("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize", CharSet = CharSet.Auto)]
        public static extern int SetProcessWorkingSetSize(IntPtr process, int minimumWorkingSetSize, int maximumWorkingSetSize);

        private static bool m_Enabled = true;
        private static readonly object m_SyncObj = new object();

        public static void Flush(bool forceFlush = true)
        {
            if (!forceFlush && !BaseSettings.ForceMemoryFlush)
                return;
            lock (m_SyncObj)
            {
                if (!m_Enabled)
                {
                    Thread.MemoryBarrier();
                    return;
                }
                Thread.MemoryBarrier();
            }
            try
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                    SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
            }
            catch (Exception)
            {

                //Some users won't have permission to adjust their working set.                
                lock (m_SyncObj)
                {
                    Thread.MemoryBarrier();
                    m_Enabled = false;

                }
            }

        }

    }
}
