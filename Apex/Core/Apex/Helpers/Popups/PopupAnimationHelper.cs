using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Apex.MVVM;

namespace Apex.Helpers.Popups
{
    /// <summary>
    /// Base class for popup animation helpers.
    /// </summary>
    public abstract class PopupAnimationHelper
    {
        /// <summary>
        /// A list that stores each popup and associated background.
        /// </summary>
        private readonly List<PopupAndBackground> popupsAndBackgrounds = new List<PopupAndBackground>();

        /// <summary>
        /// Shows the popup in the popup host.
        /// </summary>
        /// <param name="popupHost">The popup host.</param>
        /// <param name="popup">The popup.</param>
        public void ShowPopup(Grid popupHost, UIElement popup)
        {
            //  Create the popup and background.
            var popupAndBackground = new PopupAndBackground()
            {
                PopupElement = popup,
                Background = new Grid()
            };
            
            //  Add the tuple to the internal collection.
            popupsAndBackgrounds.Add(popupAndBackground);

            //  Animate the popup.
            AnimatePopupShow(popupHost, popupAndBackground.Background, popup);
        }

        /// <summary>
        /// Closes the popup from the popup host.
        /// IMPORTANT: The stame instance of the PopupTransitionHelper that was used to 
        /// show the popup MUST be used to hide it.
        /// </summary>
        /// <param name="popupHost">The popup host.</param>
        /// <param name="popup">The popup.</param>
        public void ClosePopup(Grid popupHost, UIElement popup)
        {
            //  Find the tuple for the popup.
            var popupAndBackground = (from pab in popupsAndBackgrounds where pab.PopupElement == popup select pab).FirstOrDefault();

            //  If it's missing, then this popup was not shown in this instance of the helper.
            if(popupAndBackground == null)
                throw new InvalidOperationException("The popup to be hidden was not shown in this instance. Popups must be shown and then hidden by the same object.");

            //  Remove the popup and background from the internal collection.
            popupsAndBackgrounds.Remove(popupAndBackground);

            //  Animate the popup.
            AnimatePopupHide(popupHost, popupAndBackground.Background, popup);
        }

        /// <summary>
        /// Animates the popup show.
        /// </summary>
        /// <param name="popupHost">The popup host.</param>
        /// <param name="popupBackground">The popup background.</param>
        /// <param name="popupElement">The popup element.</param>
        protected abstract void AnimatePopupShow(Grid popupHost, Grid popupBackground, UIElement popupElement);

        /// <summary>
        /// Animates the popup hide.
        /// </summary>
        /// <param name="popupHost">The popup host.</param>
        /// <param name="popupBackground">The popup background.</param>
        /// <param name="popupElement">The popup element.</param>
        protected abstract void AnimatePopupHide(Grid popupHost, Grid popupBackground, UIElement popupElement);

        /// <summary>
        /// Gets the open popups count.
        /// </summary>
        public int OpenPopupsCount
        {
            get { return popupsAndBackgrounds.Count; }   
        }

        internal class PopupAndBackground
        {
            public UIElement PopupElement { get; set; }
            public Grid Background { get; set; }
        }
    }

    
}
