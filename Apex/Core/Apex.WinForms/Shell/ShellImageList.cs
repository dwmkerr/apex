using System;
using System.Runtime.InteropServices;
using Apex.WinForms.Interop;

namespace Apex.WinForms.Shell
{
    /// <summary>
    /// The Shell Image List.
    /// </summary>
    public static class ShellImageList
    {
        /// <summary>
        /// The lazy small image list handle.
        /// </summary>
        private static readonly Lazy<IntPtr> smallImageListHandle;

        /// <summary>
        /// The lazy large image list handle.
        /// </summary>
        private static readonly Lazy<IntPtr> largeImageListHandle;

        /// <summary>
        /// Initializes the <see cref="ShellImageList"/> class.
        /// </summary>
        static ShellImageList()
        {
            //  Create the lazy handle.
            smallImageListHandle = new Lazy<IntPtr>(CreateSmallImageListHandle);
            largeImageListHandle = new Lazy<IntPtr>(CreateLargeImageListHandle);
        }

        private static IntPtr CreateSmallImageListHandle()
        {
            return CreateShellImageListHandle(true);
        }

        private static IntPtr CreateLargeImageListHandle()
        {
            return CreateShellImageListHandle(false);
        }

        /// <summary>
        /// Creates the shell image list handle.
        /// </summary>
        /// <returns>The shell image list handle.</returns>
        private static IntPtr CreateShellImageListHandle(bool small)
        {
            //  Create a shell file info.
            var shellFileInfo = new SHFILEINFO();

            //  Create the flags.
            var flags = SHGFI.SHGFI_USEFILEATTRIBUTES | SHGFI.SHGFI_SYSICONINDEX;
            flags |= small ? SHGFI.SHGFI_SMALLICON : SHGFI.SHGFI_LARGEICON;

            //  Get the file info for a dummy file, to get the shell image list handle.
            var handle = Shell32.SHGetFileInfo(".txt", Shell32.FILE_ATTRIBUTE_NORMAL, out shellFileInfo,
                (uint)Marshal.SizeOf(shellFileInfo), flags);

            //  Validate the handle.
            if(handle == IntPtr.Zero)
                throw new InvalidOperationException("Failed to get the Shell Image List.");

            //  Return the handle.
            return handle;
        }

        /// <summary>
        /// Gets the small image list handle.
        /// </summary>
        public static IntPtr SmallImageListHandle
        {
            get { return smallImageListHandle.Value; }
        }

        /// <summary>
        /// Gets the large image list handle.
        /// </summary>
        public static IntPtr LargeImageListHandle
        {
            get { return largeImageListHandle.Value; }
        }
    }
}
