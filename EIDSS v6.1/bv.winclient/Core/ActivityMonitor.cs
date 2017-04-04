using System;
using System.Runtime.InteropServices;


namespace bv.winclient.Core
{

    public class ActivityMonitor : IDisposable
    {
        #region interop stuff
        public delegate int HookProc(int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern bool UnhookWindowsHookEx(int idHook);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int CallNextHookEx(int idHook, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern int GetKeyState(int vKey);

        private const byte VK_LCONTROL = 0xA2;
        private const byte VK_L = 76;

        public enum HookType
        {
            WH_JOURNALRECORD = 0,
            WH_JOURNALPLAYBACK = 1,
            WH_KEYBOARD = 2,
            WH_GETMESSAGE = 3,
            WH_CALLWNDPROC = 4,
            WH_CBT = 5,
            WH_SYSMSGFILTER = 6,
            WH_MOUSE = 7,
            WH_HARDWARE = 8,
            WH_DEBUG = 9,
            WH_SHELL = 10,
            WH_FOREGROUNDIDLE = 11,
            WH_CALLWNDPROCRET = 12,
            WH_KEYBOARD_LL = 13,
            WH_MOUSE_LL = 14
        }

        private enum MouseMessages
        {
            WM_LBUTTONDOWN = 0x201,
            WM_LBUTTONUP = 0x202,
            WM_MOUSEMOVE = 0x200,
            WM_MOUSEWHEEL = 0x20A,
            WM_RBUTTONDOWN = 0x204,
            WM_RBUTTONUP = 0x205
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MSLLHOOKSTRUCT
        {
            public POINT pt;
            public UInt32 mouseData;
            public UInt32 flags;
            public UInt32 time;
            public IntPtr dwExtraInfo;
        }


        private const int WM_KEYDOWN = 0x100;
        private HookProc _keyboardProc;
        private int _keyboardHookID = 0;
        private HookProc _mouseProc;
        private int _mouseHookID = 0;
        #endregion

        private System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();


        public ActivityMonitor()
        {
            LastActivity = DateTime.Now;

            _keyboardProc = new HookProc(KeyboardHookCallback);
            _mouseProc = new HookProc(MouseHookCallback);
            _keyboardHookID = SetKeyboardHook(_keyboardProc);
            _mouseHookID = SetMouseHook(_mouseProc);

            _timer.Interval = 1000;
            _timer.Tick += new System.EventHandler(_timer_Tick);
            _timer.Start();
        }



        public double MaxMinutesIdle = 30; //default


        private DateTime LastActivity;

        private EventHandler IdleEvent;
        public event EventHandler Idle
        {
            add
            {
                IdleEvent = (EventHandler)System.Delegate.Combine(IdleEvent, value);
            }
            remove
            {
                IdleEvent = (EventHandler)System.Delegate.Remove(IdleEvent, value);
            }
        }


        private bool _enabled = false;

        public bool Enabled
        {
            get
            {
                return _enabled;
            }
            set
            {
                _enabled = value;
            }
        }
        private bool m_IsLogoff;
        public bool IsLogoff
        {
            get
            {
                return m_IsLogoff;
            }
        }

        private void UpdateState()
        {
            if (Enabled == false)
            {
                return;
            }
            double timeElapsed = System.Convert.ToDouble((DateTime.Now - LastActivity).TotalMinutes);
            double timeLeft = MaxMinutesIdle - timeElapsed;

            if (timeLeft <= 0)
            {
                m_IsLogoff = true;
                OnIdle();
            }
            else
            {
                m_IsLogoff = true;
            }
        }

        private void OnIdle()
        {
            if (IdleEvent != null)
                IdleEvent(this, EventArgs.Empty);
        }

        #region mouse Hook
        private int SetMouseHook(HookProc proc)
        {

#pragma warning disable 612,618
            //Dim threadId As Integer = Threading.Thread.CurrentThread.ManagedThreadId
            // Don't touch it!
            int threadId = AppDomain.GetCurrentThreadId();
#pragma warning restore 612,618
            return SetWindowsHookEx(System.Convert.ToInt32(HookType.WH_MOUSE), proc, IntPtr.Zero, threadId);
        }

        private int MouseHookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            MouseMessages mouseInfo = (MouseMessages)wParam;
            if (nCode >= 0 && ((mouseInfo == MouseMessages.WM_LBUTTONDOWN) || (mouseInfo == MouseMessages.WM_RBUTTONDOWN)))
            {
                LastActivity = DateTime.Now;
                //Debug.WriteLine("MouseHookCallback: " + _currState.ToString() + "\t" + DateTime.Now.ToString() + "\t" + nCode.ToString() + "\t" + wParam + "\t" + lParam);
                //Debug.WriteLine("\t" + hookStruct.flags.ToString() + "\t" + hookStruct.mouseData.ToString() + "\t" + hookStruct.time.ToString());
            }

            return CallNextHookEx(_mouseHookID, nCode, wParam, lParam);
        }
        #endregion

        #region keyboard Hook

        private int SetKeyboardHook(HookProc proc)
        {
#pragma warning disable 612,618
            //Dim threadId As Integer = Threading.Thread.CurrentThread.ManagedThreadId
            // Don't touch it!
            int threadId = AppDomain.GetCurrentThreadId();
#pragma warning restore 612,618
            return SetWindowsHookEx(System.Convert.ToInt32(HookType.WH_KEYBOARD), proc, IntPtr.Zero, threadId);
        }

        private int KeyboardHookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode > 0)
            {
                LastActivity = DateTime.Now;
                if ((GetKeyState(System.Convert.ToInt32(VK_LCONTROL)) & 0x80) != 0 && (GetKeyState(System.Convert.ToInt32(VK_L)) & 0x80) != 0)
                {
                    LastActivity = DateTime.Now.AddMinutes(System.Convert.ToDouble(-MaxMinutesIdle - 1));
                    UpdateState();
                }
                // Debug.WriteLine(String.Format("{0} KeyboardHookCallback: nCode={1} w={2} l={3}", DateTime.Now.ToString(), nCode, wParam, lParam));
            }

            return CallNextHookEx(_keyboardHookID, nCode, wParam, lParam);
        }
        #endregion

        private void _timer_Tick(object sender, EventArgs e)
        {
            UpdateState();
        }

        public void Dispose()
        {
            UnhookWindowsHookEx(_keyboardHookID);
            UnhookWindowsHookEx(_mouseHookID);
        }

    }

}




