using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apex.MVVM
{
    /// <summary>
    /// An ExecutionContext identifies how an assembly is running - whether it is standard,
    /// in the visual studio designer, or as a unit test.
    /// </summary>
    public enum ExecutionContext
    {
        /// <summary>
        /// The code is executing.
        /// </summary>
        Standard,

        /// <summary>
        /// The code is executing, but in the context of the visual studio designer.
        /// </summary>
        Design,

        /// <summary>
        /// The code is executing, but in the context of a unit test.
        /// </summary>
        Test
    }
}
