using System;

namespace Apex.WinForms.Interop
{
    [Flags]
    public enum SHGNO : uint
    {
        /// <summary>
        /// Default (display purpose)
        /// </summary>
        SHGDN_NORMAL = 0x0000,

        /// <summary>
        /// Displayed under a folder (relative)
        /// </summary>
        SHGDN_INFOLDER = 0x0001,

        /// <summary>
        /// For in-place editing
        /// </summary>
        SHGDN_FOREDITING = 0x1000,  

        /// <summary>
        /// UI friendly parsing name (remove ugly stuff)
        /// </summary>
        SHGDN_FORADDRESSBAR = 0x4000,

        /// <summary>
        /// Parsing name for ParseDisplayName()
        /// </summary>
        SHGDN_FORPARSING = 0x8000,
    }
}