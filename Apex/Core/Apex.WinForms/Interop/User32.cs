using System;
using System.Runtime.InteropServices;

namespace Apex.WinForms.Interop
{
    internal static class User32
    {
        [DllImport("user32.dll")]
        public static extern Int32 SendMessage(IntPtr pWnd, UInt32 uMsg, UInt32 wParam, IntPtr lParam);      
    }
}