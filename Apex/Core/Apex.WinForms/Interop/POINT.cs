using System.Runtime.InteropServices;

namespace Apex.WinForms.Interop
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct POINT
    {
        int x;
        int y;
    }
}