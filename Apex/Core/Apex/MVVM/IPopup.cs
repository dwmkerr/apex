using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apex.MVVM
{
    /// <summary>
    /// Any class that implements IPopup can be popped up in an application host.
    /// </summary>
    public interface IPopup
    {
        /// <summary>
        /// Gets the popup result.
        /// </summary>
        /// <returns>The popup result.</returns>
        object GetPopupResult();
    }
}
