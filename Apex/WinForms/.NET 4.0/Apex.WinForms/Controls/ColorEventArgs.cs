using System;
using System.Drawing;

namespace Apex.Controls
{
    /// <summary>
    /// The ColorEventArgs arguments are passed in events dealing with colors.
    /// </summary>
	public class ColorEventArgs : EventArgs
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="ColourEventArgs"/> class.
        /// </summary>
        public ColorEventArgs()
        {
            //  Set the default color.
            Color = Color.Beige;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorEventArgs"/> class.
        /// </summary>
        /// <param name="color">The color.</param>
        public ColorEventArgs(Color color)
        {
            //  Set the color.
            Color = color;
        }

        /// <summary>
        /// Gets the color.
        /// </summary>
        public Color Color
        {
            get;
            private set;
        }
	}
}
