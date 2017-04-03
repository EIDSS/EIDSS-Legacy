using System;
using System.Runtime.InteropServices;
namespace EIDSS
{
	class ListViewNativeMethods
	{
		/*[System.Runtime.InteropServices.DllImport("User32")]
		private static extern bool SendMesage(IntPtr hWnd,
			int Msg,
			int wParam,
			int lParam
			);*/
		[DllImport("user32.dll",EntryPoint="SendMessage")]
		public static extern int SendMessage(IntPtr hWnd,
			int Msg,
			int wParam,
			int lParam
			);
		[DllImport("user32.dll", EntryPoint="SendMessage", CharSet=CharSet.Auto)]
		public static extern IntPtr SendMessageItem(IntPtr hWnd, int msg,
			int wParam, ref LVITEM lvi);

		[DllImport("user32.dll", EntryPoint="SendMessage", CharSet=CharSet.Auto)]
		public static extern IntPtr SendMessageHitTest(IntPtr hWnd, int msg,
			int wParam, ref LVHITTESTINFO ht);

		public const int LVM_SETITEM = 0x1000 + 76; // LVM_FIRST + 76
		public const int LVM_GETITEM = 0x1000 + 5; // LVM_FIRST + 5
		public const int LVM_SETEXTENDEDLISTVIEWSTYLE = 0x1000+54; // LVM_FIRST + 54
		public const int LVM_SUBITEMHITTEST = 0x1000+57;

		public const int LVS_EX_SUBITEMIMAGES = 2; // LVM_FIRST + 54

		//private const int LVIF_TEXT        = 0x0001;
		public const int LVIF_IMAGE       = 0x0002;
		//private const int LVIF_PARAM       = 0x0004;
		//private const int LVIF_STATE       = 0x0008;
		//private const int LVIF_INDENT      = 0x0010;
		//private const int LVIF_NORECOMPUTE = 0x0800;

		[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
			public struct LVITEM
		{
			public int     mask;
			public int     iItem;
			public int     iSubItem;
			public int     state;
			public int     stateMask;
			[MarshalAs(UnmanagedType.LPTStr)]
			public string  pszText;
			public int     cchTextMax;
			public int     iImage;
			public int     lParam;
			// These are available in Common Controls >= 0x0300
			public int     iIndent;
			// These are available in Common Controls >= 0x056
			public int     iGroupId;
			public int     cColumns;
			public IntPtr  puColumns;
		};
		[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
			public struct POINT
		{
			public int x;
			public int y;
		}


		[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
			public struct LVHITTESTINFO 
		{
			public POINT pt;
			public int flags;
			public int iItem;
			public int iSubItem;
		}
	}
}