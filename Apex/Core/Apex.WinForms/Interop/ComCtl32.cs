using System;
using System.Runtime.InteropServices;

namespace Apex.WinForms.Interop
{
    public static class ComCtl32
    {

        [DllImport("comctl32.dll")]
        public static extern bool ImageList_GetIconSize(IntPtr hImageList, out int cx, out int cy);

        [DllImport("comctl32.dll")]
        public static extern IntPtr ImageList_GetIcon(IntPtr hImageList, int i, uint flags);
        
        [DllImport("comctl32.dll")]
        public static extern int ImageList_GetImageCount(IntPtr hImageList);
    }
}