using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Apex.WinForms.Interop
{
    internal static class Shell32
    {
        public const Int32 FILE_ATTRIBUTE_NORMAL = 0x80;
        public static Guid IID_IShellFolder = new Guid("000214E6-0000-0000-C000-000000000046");


        [DllImport("shell32.dll")]
        public static extern Int32 SHGetDesktopFolder(ref IShellFolder ppshf);

        [DllImport("shell32.dll")]
        public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttribs, out SHFILEINFO psfi, uint cbFileInfo, SHGFI uFlags);

        [DllImport("shell32.dll")]
        public static extern IntPtr SHGetFileInfo(IntPtr pIDL, uint dwFileAttributes, out SHFILEINFO psfi, uint cbFileInfo, SHGFI uFlags);

        [DllImport("shell32.dll")]
        public static extern Int32 SHGetSpecialFolderLocation(IntPtr hwndOwner, CSIDL nFolder, ref IntPtr ppidl);

        [DllImport("shell32.dll")]
        public static extern IntPtr ILCombine(IntPtr pIDLParent, IntPtr pIDLChild);

        [DllImport("shell32.dll")]
        public static extern Int32 SHGetPathFromIDList(IntPtr pIDL, StringBuilder strPath);
    }
}
