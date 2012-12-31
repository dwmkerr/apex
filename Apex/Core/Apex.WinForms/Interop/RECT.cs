using System.Runtime.InteropServices;

namespace Apex.WinForms.Interop
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct RECT
    {
        public int left, top, right, bottom;
    }
}