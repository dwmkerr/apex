using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Apex.Controls
{
    /// <summary>
    /// The color changed delegate is used when sending color events.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="args">The <see cref="Apex.Controls.ColorEventArgs"/> instance containing the event data.</param>
    public delegate void ColorChangedDelegate(object sender, ColorEventArgs args);

    /// <summary>
    /// The mouse out delegate.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="args">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    public delegate void MouseOutDelegate(object sender, EventArgs args);

    /// <summary>
    /// The ColorMap is a user control that allows the user to pick
    /// a color from a gradient map.
    /// </summary>
	public class ColorMap : UserControl
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="ColorMap"/> class.
        /// </summary>
        public ColorMap()
		{
			this.InitializeComponent();
		}

        /// <summary>
        /// Dispose this instance.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged 
        /// resources; false to release only unmanaged resources.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}

			base.Dispose(disposing);
		}

        /// <summary>
        /// Initializes the component.
        /// </summary>
		private void InitializeComponent()
		{
            //  Set the initial properties.
            Name = "ColorMap";
            Size = new Size(272, 128);
		}

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint"/> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs"/> that contains the event data.</param>
		protected override void OnPaint(PaintEventArgs e)
		{
            //  If we don't have the bitmap, we cannot paint.
            if (bitmap == null)
                return;

            //  Get the graphics instance and draw the bitmap.
			e.Graphics.DrawImage(bitmap, 10, 0);
		}

        /// <summary>
        /// Gets a color value from a point.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <returns>The color at the specified point.</returns>
		protected Color ColorFromPoint(int x, int y)
		{
            //  The trivial case is the ten pixel border
            //  to the left.
			if (x < 10)
                return currentColor;

			//  Determine the color.
			float num = (float)x / (float)Width;
			float num2 = (num + 0.5f <= 1f) ? (1f - num * 2f) : 0f;
			float num3 = (num - 0.5f > 0f) ? ((num - 0.5f) * 2f) : 0f;
			float num4 = 1f - (float)y / (float)Height;
			float redComponent = num2 * 255f;
			float greenComponent = num3 * 255f;
			float blueComponent = num4 * 255f;

            //  Return the color.
			return Color.FromArgb((int)redComponent, (int)greenComponent, (int)blueComponent);;
		}

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
		protected override void OnMouseLeave(EventArgs e)
		{
			//  Fire the mouse out event.
            FireMouseOutEvent(this, e);
		}

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
		protected override void OnSizeChanged(EventArgs e)
		{
            //  Dispose the bitmap if we have it.
            if (bitmap != null)
                bitmap.Dispose();

            //  Create a bitmap of an appropriate size.
            bitmap = new Bitmap(Width - 10, Height, PixelFormat.Format24bppRgb);

            //  Set the pixels of the bitmap.
			for (int i = 0; i < Height; i++)
			{
				for (int j = 0; j < Width - 10; j++)
				{
					this.bitmap.SetPixel(j, i, ColorFromPoint(j + 10, i));
				}
			}

            //  Repaint.
			Invalidate();

            //  Call the base.
			base.OnSizeChanged(e);
		}

        /// <summary>
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"/> that contains the event data.</param>
		protected override void OnMouseDown(MouseEventArgs e)
		{
            //  Set the current color.
			CurrentColor = ColorFromPoint(e.X, e.Y);

            //  Fire the mouse out event.
            FireMouseOutEvent(this, e);
		}

        /// <summary>
        /// Fires the color changed event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="Apex.Controls.ColorEventArgs"/> instance containing the event data.</param>
        private void FireColorChangedEvent(object sender, ColorEventArgs args)
        {
            //  Get the event and fire it if it is registered.
            var theEvent = ColorChanged;
            if (theEvent != null)
                theEvent(sender, args);
        }

        /// <summary>
        /// Fires the mouse out event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void FireMouseOutEvent(object sender, EventArgs args)
        {
            //  Get the event and fire it if it is registered.
            var theEvent = MouseOut;
            if (theEvent != null)
                theEvent(sender, args);
        }

        /// <summary>
        /// The current color.
        /// </summary>
        private Color currentColor = Color.Red;

        /// <summary>
        /// The color border.
        /// </summary>
        private bool showColorBorder = true;

        /// <summary>
        /// The child components.
        /// </summary>
        private Container components = null;

        /// <summary>
        /// The bitmap used for drawing.
        /// </summary>
        private Bitmap bitmap;
        /// <summary>
        /// The color changed event.
        /// </summary>
        public event ColorChangedDelegate ColorChanged;

        /// <summary>
        /// The mouse out event.
        /// </summary>
        public event MouseOutDelegate MouseOut;

        /// <summary>
        /// Gets or sets the current color.
        /// </summary>
        /// <value>
        /// The current color.
        /// </value>
        public Color CurrentColor
        {
            get
            {
                return currentColor;
            }
            set
            {
                //  Set the current color.
                currentColor = value;

                //  Set the back color.
                BackColor = value;

                //  Fire the color changed event.
                FireColorChangedEvent(this, new ColorEventArgs(value));
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to show color border.
        /// </summary>
        /// <value>
        ///   <c>true</c> if showing a color border; otherwise, <c>false</c>.
        /// </value>
        public bool ShowColorBorder
        {
            get
            {
                return showColorBorder;
            }
            set
            {
                //  Set the value and redraw.
                showColorBorder = value;
                OnSizeChanged(new EventArgs());
            }
        }
	}
}
