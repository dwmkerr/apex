using System;
using System.Drawing;
using System.Windows.Forms;
using Apex.WinForms.Interop;

namespace Apex.WinForms.Extensions
{
    public static class ListViewExtensions
    {
        /// <summary>
        /// ListView ImageList type.
        /// </summary>
        public enum ImageListType
        {
            /// <summary>
            /// Normal images.
            /// </summary>
            Normal = 0,

            /// <summary>
            /// Small images.
            /// </summary>
            Small = 1,

            /// <summary>
            /// State images.
            /// </summary>
            State = 2,

            /// <summary>
            /// Group header images.
            /// </summary>
            GroupHeader = 3
        }

        /// <summary>
        /// Normal image list (typically 32x32).
        /// </summary>
        private const uint LVSIL_NORMAL = 0;

        /// <summary>
        /// Small image list (16x16).
        /// </summary>
        private const uint LVSIL_SMALL = 1;

        /// <summary>
        /// State image list.
        /// </summary>
        private const uint LVSIL_STATE = 2;

        /// <summary>
        /// Group header image list.
        /// </summary>
        private const uint LVSIL_GROUPHEADER = 3;

        /// <summary>
        /// First list view message.
        /// </summary>
        private const uint LVM_FIRST = 0x1000;

        /// <summary>
        /// Set image list message.
        /// </summary>
        private const uint LVM_SETIMAGELIST = (LVM_FIRST + 3);

        

        /// <summary>
        /// Sets the image list.
        /// </summary>
        /// <param name="this">The list view instance.</param>
        /// <param name="imageListType">Type of the image list.</param>
        /// <param name="imageListHandle">The image list handle.</param>
        public static void SetImageList(this ListView @this, ImageListType imageListType, IntPtr imageListHandle)
        {
            //  If we're using the group header image list (not wrapped by .NET), 
            //  just go straight to the Win32 API - we'll be using it from there 
            //  anyway.
            if(imageListType == ImageListType.GroupHeader)
            {
                //  Set the image list.
                User32.SendMessage(@this.Handle, LVM_SETIMAGELIST, (uint)imageListType, imageListHandle);

                //  That's all we need to do.
                return;
            }

            //  Get the image list details.
            int cx, cy;
            ComCtl32.ImageList_GetIconSize(imageListHandle, out cx, out cy);
            var imageCount = ComCtl32.ImageList_GetImageCount(imageListHandle);

            //  This isn't actually enough for a Winforms list view - we actually need to create a copy of the 
            //  image list.
            var imageList = new ImageList();
            imageList.ImageSize = new Size(cx, cy);

            for (int i = 0; i < imageCount; i++)
            {
                //  Get the icon.
                var hIcon = ComCtl32.ImageList_GetIcon(imageListHandle, i, 0);

                //  Create it.
                var icon = Icon.FromHandle(hIcon);

                //  Add it.
                imageList.Images.Add(icon);
            }

            //  Set the image list.
            switch (imageListType)
            {
                case ImageListType.Normal:
                    @this.LargeImageList = imageList;
                    break;
                case ImageListType.Small:
                    @this.SmallImageList = imageList;
                    break;
                case ImageListType.State:
                    @this.StateImageList = imageList;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("imageListType");
            }
        }

        /// <summary>
        /// Gets the image list.
        /// </summary>
        /// <param name="this">The list view instance.</param>
        /// <param name="imageListType">Type of the image list.</param>
        /// <returns>The image list handle.</returns>
        public static IntPtr GetImageList(this ListView @this, ImageListType imageListType)
        {
            //  Set the image list.
            return new IntPtr(User32.SendMessage(@this.Handle, LVM_SETIMAGELIST, (uint)imageListType, IntPtr.Zero));
        }
    }
}
