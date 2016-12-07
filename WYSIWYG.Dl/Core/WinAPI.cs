namespace WYSIWYG.Dl.Core
{
    public class WinAPI
    {
        #region Win API

        [System.Runtime.InteropServices.DllImport("Kernel32.dll")]
        public static extern bool QueryPerformanceCounter(ref long count);

        [System.Runtime.InteropServices.DllImport("Kernel32.dll")]
        public static extern bool QueryPerformanceFrequency(ref long count);

        #endregion Win API
    }
}