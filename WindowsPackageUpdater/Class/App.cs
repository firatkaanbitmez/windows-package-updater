using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WindowsPackageUpdater
{
    public class App : ApplicationContext
    {
        private const int SW_RESTORE = 9;

        private IntPtr mainWindowHandle;

        public App()
        {
            mainWindowHandle = NativeMethods.GetForegroundWindow();
        }

        public void ShowWindow()
        {
            NativeMethods.ShowWindow(mainWindowHandle, SW_RESTORE);
            NativeMethods.SetForegroundWindow(mainWindowHandle);
        }
    }

    internal static class NativeMethods
    {
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    }
}
