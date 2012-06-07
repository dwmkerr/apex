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
#if !SILVERLIGHT

        //  WPF Only: Silverlight cannot push a dispatcher frame and
        //  call the function below synchronously without blocking the UI.

        /// <summary>
        /// Pushes a popup onto the popup stack and displays it.
        /// Once the popup is closed, this function returns with
        /// the value of IPopup.GetPopupResult();
        /// </summary>
        /// <param name="popup">The popup.</param>
        /// <returns>The popup result.</returns>
        object ShowPopup(IPopup popup);

#else

        /// <summary>
        /// Pushes a popup onto the popup stack and displays it.
        /// Once the popup is closed, this onPopupClosed action will be called 
        /// the value of IPopup.GetPopupResult();
        /// </summary>
        /// <param name="popup">The popup.</param>
        /// <param name="onPopopClosed">The action to invoke when the popop is closed.</param>
        void ShowPopup(IPopup popup, Action<object> onPopopClosed);

#endif

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
