using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apex.Helpers.Popups;

namespace Apex.MVVM
{
    /// <summary>
    /// An Application Host is the top level control in an application
    /// and must be able to show popups, progress etc.
    /// </summary>
    public interface IApplicationHost
    {
        /// <summary>
        /// Pushes a popup onto the popup stack.
        /// </summary>
        /// <param name="popup">The popup.</param>
        /// <returns>The popup result.</returns>
        object ShowPopup(IPopup popup);

        /// <summary>
        /// Closes the popup.
        /// </summary>
        /// <param name="popup">The popup.</param>
        void ClosePopup(IPopup popup);

        /// <summary>
        /// Gets or sets the popup animation helper.
        /// </summary>
        /// <value>
        /// The popup animation helper.
        /// </value>
        PopupAnimationHelper PopupAnimationHelper { get; set; }
    }
}
