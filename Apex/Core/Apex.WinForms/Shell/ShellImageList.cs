using System;
using System.Collections.Generic;
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
        /// Initializes the <see cref="ShellImageList"/> class.
        /// </summary>
        static ShellImageList()
        {
        }

        /// <summary>
        /// Gets the image list interface.
        /// </summary>
        /// <param name="imageListSize">Size of the image list.</param>
        /// <returns>The IImageList for the shell image list of the given size.</returns>
        public static IntPtr GetImageList(ShellImageListSize imageListSize)
        {
            //  Do we have the image list?
            IImageList imageList;
            if (imageLists.TryGetValue(imageListSize, out imageList))
                return GetImageListHandle(imageList);

            //  We don't have the image list, create it.
            int result = Shell32.SHGetImageList((int) imageListSize, ref Shell32.IID_IImageList, ref imageList);

            //  Add it to the dictionary.
            imageLists.Add(imageListSize, imageList);

            //  Return it.
            return GetImageListHandle(imageList);
        }

        /// <summary>
        /// Gets the image list handle.
        /// </summary>
        /// <param name="imageList">The image list.</param>
        /// <returns>The image list handle for the image list.</returns>
        private static IntPtr GetImageListHandle(IImageList imageList)
        {
            return Marshal.GetIUnknownForObject(imageList);
        }

        /// <summary>
        /// The shell image lists.
        /// </summary>
        private readonly static Dictionary<ShellImageListSize, IImageList> imageLists = new Dictionary<ShellImageListSize, IImageList>();
    }
}
