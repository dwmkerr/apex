using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Apex.WinForms.Interop;

namespace Apex.WinForms.Extensions
{
    public static class TreeViewExtensions
    {
        /// <summary>
        /// TreeView ImageList type.
        /// </summary>
        public enum ImageListType
        {
            /// <summary>
            /// Normal images.
            /// </summary>
            Normal = 0,

            /// <summary>
            /// State images.
            /// </summary>
            State = 2
        }

        /// <summary>
        /// Normal tree view image.
        /// </summary>
        private const uint TVSIL_NORMAL = 0;

        /// <summary>
        /// The state images.
        /// </summary>
        private const uint TVSIL_STATE = 2;

        /// <summary>
        /// First tree view message.
        /// </summary>
        private const uint TV_FIRST = 0x1100;

        /// <summary>
        /// Get image list message.
        /// </summary>
        private const uint TVM_GETIMAGELIST = TV_FIRST + 8;

        /// <summary>
        /// Set image list message.
        /// </summary>
        private const uint TVM_SETIMAGELIST = TV_FIRST + 9;

        /// <summary>
        /// Sets the image list.
        /// </summary>
        /// <param name="this">The tree view instance.</param>
        /// <param name="imageListType">Type of the image list.</param>
        /// <param name="imageListHandle">The image list handle.</param>
        public static void SetImageList(this TreeView @this, ImageListType imageListType, IntPtr imageListHandle)
        {
            //  Set the image list.
            User32.SendMessage(@this.Handle, TVM_SETIMAGELIST, (uint) imageListType, imageListHandle);
        }

        /// <summary>
        /// Gets the image list.
        /// </summary>
        /// <param name="this">The tree view instance.</param>
        /// <param name="imageListType">Type of the image list.</param>
        /// <returns>The image list handle.</returns>
        public static IntPtr GetImageList(this TreeView @this, ImageListType imageListType)
        {
            //  Set the image list.
            return new IntPtr(User32.SendMessage(@this.Handle, TVM_GETIMAGELIST, (uint)imageListType, IntPtr.Zero));
        }
    }
}
