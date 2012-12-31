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

        public static Guid IID_IImageList = new Guid("46EB5926-582E-4017-9FDF-E8998DAA0950");

        /// <summary>
        /// The image size is normally 32x32 pixels. However, if the Use large icons option is selected from the Effects section of the Appearance tab in Display Properties, the image is 48x48 pixels.
        /// </summary>
        public static int SHIL_LARGE = 0x0;

        /// <summary>
        /// These images are the Shell standard small icon size of 16x16, but the size can be customized by the user.
        /// </summary>
        public static int SHIL_SMALL = 0x1;

        /// <summary>
        /// These images are the Shell standard extra-large icon size. This is typically 48x48, but the size can be customized by the user.
        /// </summary>
        public static int SHIL_EXTRALARGE = 0x2;

        /// <summary>
        /// These images are the size specified by GetSystemMetrics called with SM_CXSMICON and GetSystemMetrics called with SM_CYSMICON.
        /// </summary>
        public static int SHIL_SHIL_SYSSMALL = 0x3;

        /// <summary>
        /// Windows Vista and later. The image is normally 256x256 pixels.
        /// </summary>
        public static int SHIL_JUMBO = 0x4;

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

        [DllImport("shell32.dll", EntryPoint = "#727")]
        public extern static int SHGetImageList(int iImageList, ref Guid riid, ref IImageList ppv);
    }
}
