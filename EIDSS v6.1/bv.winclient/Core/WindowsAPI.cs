using System;
using System.Runtime.InteropServices;


namespace bv.winclient.Core
{
    public class WindowsAPI
    {

        public const int SW_HIDE = 0;
        public const int SW_MAX = 10;
        public const int SW_MAXIMIZE = 3;
        public const int SW_MINIMIZE = 6;
        public const int SW_NORMAL = 1;
        public const int SW_RESTORE = 9;
        public const int SW_SHOW = 5;
        public const int SW_SHOWDEFAULT = 10;
        public const int SW_SHOWMAXIMIZED = 3;
        public const int SW_SHOWMINIMIZED = 2;
        public const int SW_SHOWMINNOACTIVE = 7;
        public const int SW_SHOWNA = 8;
        public const int SW_SHOWNOACTIVATE = 4;
        public const int SW_SHOWNORMAL = 1;
        public const int WM_QUERYENDSESSION = 0x11;
        public const int GW_HWNDPREV = 3;

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {

            public int left;
            public int top;
            public int right;
            public int bottom;
            public override string ToString()
            {
                return (string.Format("Left :{0},Top :{1},Right :{2},Bottom :{3}", left, top, right, bottom));
            }
        }

        [DllImport("user32.dll", EntryPoint = "FindWindowEx", CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, [MarshalAs(UnmanagedType.LPTStr)]string lpszClass, [MarshalAs(UnmanagedType.LPTStr)]string lpszWindow);



        [DllImport("user32.dll", EntryPoint = "GetWindowRect", CharSet = CharSet.Auto)]
        public static extern bool GetWindowRect(IntPtr hwnd, ref RECT lpRect);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
        [DllImport("Winspool.drv", CharSet = CharSet.Auto)]
        public static extern bool SetDefaultPrinter(string pszPrinter);
        [DllImport("User32.dll", EntryPoint = "ShowWindow", CharSet = CharSet.Auto)]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("User32.dll", EntryPoint = "UpdateWindow", CharSet = CharSet.Auto)]
        public static extern bool UpdateWindow(IntPtr hWnd);

        [DllImport("user32.dll", EntryPoint = "IsIconic", CharSet = CharSet.Auto)]
        public static extern bool IsIconic(IntPtr hWnd);

        [DllImport("user32.dll", EntryPoint = "SetForegroundWindow", CharSet = CharSet.Auto)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", EntryPoint = "DrawAnimatedRects", CharSet = CharSet.Auto)]
        private static extern bool DrawAnimatedRects(IntPtr hwnd, int idAni, ref RECT lprcFrom, ref RECT lprcTo);

        [DllImport("user32.dll", EntryPoint = "GetWindow", CharSet = CharSet.Auto)]
        private static extern IntPtr GetWindow(IntPtr hwnd, int uCmd);
        [DllImport("user32.dll", EntryPoint = "IntersectRect", CharSet = CharSet.Auto)]
        private static extern bool IntersectRect(ref RECT rDest, ref RECT rSrc1, ref RECT rSrc2);

        [DllImport("user32.dll", EntryPoint = "IsWindowVisible", CharSet = CharSet.Auto)]
        private static extern bool IsWindowVisible(IntPtr hwnd);

        public static bool IsWindowOverapped(IntPtr hWnd)
        {
            //Start from the current window and use the GetWindow()
            //function to move through the previous window handles.
            //
            RECT myRect = new RECT();
            if (hWnd.Equals(IntPtr.Zero))
            {
                return false;
            }
            RECT DestRect = new RECT();
            RECT OtherRect = new RECT();
            IntPtr hNextWnd;
            IntPtr hPrevWnd = hWnd;
            while (true)
            {
                hNextWnd = GetWindow(hPrevWnd, GW_HWNDPREV);
                if (hNextWnd.Equals(IntPtr.Zero))
                {
                    break;
                }
                //Get the window rectangle dimensions of the window that
                //is higher Z-Order than the application's window.
                GetWindowRect(hNextWnd, ref OtherRect);
                //Get the window rectangle dimensions of the window that
                //Check to see if this window is visible and if intersects
                //with the rectangle of the application's window. If it does,
                //call MessageBeep(). This intersection is an area of this
                //application's window that is not visible.
                if (IsWindowVisible(hNextWnd) && IntersectRect(ref DestRect, ref myRect, ref OtherRect))
                {
                    return true;
                }
                hPrevWnd = hNextWnd;
            }
            return false;
        }

        [DllImport("User32.dll")]
        public static extern int GetAsyncKeyState(int vKey);
        [DllImport("User32.dll")]
        public static extern int GetKeyState(int vKey);
        //[DllImport("User32.dll"), CLSCompliantAttribute(false)]
        //extern static IntPtr PostMessage(IntPtr hWnd, uint msg, Int32 wParam, Int32 lParam);
        [DllImport("user32.dll"), CLSCompliantAttribute(false)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

    }
}