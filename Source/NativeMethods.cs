using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BootVid
{
    public static class NativeMethods
    {
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public const int SW_MINIMIZE = 6;
        public const int SW_RESTORE = 9;
        public const int SW_HIDE = 0; // Ocultar ventana
        public const int SW_SHOW = 5;
    }
}