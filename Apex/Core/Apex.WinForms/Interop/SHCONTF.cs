using System;

namespace Apex.WinForms.Interop
{
    [Flags]
    public enum SHCONTF : uint
    {
        None = 0,
        SHCONTF_FOLDERS = 0x0020,              // Only want folders enumerated (SFGAO_FOLDER)
        SHCONTF_NONFOLDERS = 0x0040,           // Include non folders
        SHCONTF_INCLUDEHIDDEN = 0x0080,        // Show items normally hidden
        SHCONTF_INIT_ON_FIRST_NEXT = 0x0100,   // Allow EnumObject() to return before validating enum
        SHCONTF_NETPRINTERSRCH = 0x0200,       // Hint that client is looking for printers
        SHCONTF_SHAREABLE = 0x0400,            // Hint that client is looking sharable resources (remote shares)
        SHCONTF_STORAGE = 0x0800,              // Include all items with accessible storage and their ancestors
    }
}