using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apex.WinForms.Shell
{
    /// <summary>
    /// The Child Type flags.
    /// </summary>
    [Flags]
    public enum ChildTypes
    {
        Folders = 1,
        Files = 2,
        Hidden = 4
    }
}
