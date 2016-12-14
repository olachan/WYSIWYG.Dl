using System;
using System.Runtime.InteropServices;

namespace WYSIWYG.Dl.Core
{
    public class WinAPI
    {

        [DllImport("Kernel32.dll")]
        public static extern bool QueryPerformanceCounter(ref long count);

        [DllImport("Kernel32.dll")]
        public static extern bool QueryPerformanceFrequency(ref long count);

        public const int EM_SETCUEBANNER = 0x1501;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);

    }
}