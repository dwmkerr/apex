using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Apex.Controls
{
    /// <summary>
    /// The Expanding Panel.
    /// </summary>
	public class ExpandingPanel : Panel
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="ExpandingPanel"/> class.
        /// </summary>
		public ExpandingPanel()
		{
            //  Initialise the component.
			InitializeComponent();

            //  Set the initial values.
			boldFont = new Font("Tahoma", 8f, FontStyle.Regular);
            underlineFont = new Font("Tahoma", 8f, FontStyle.Underline);
			nameFont = this.boldFont;
			BackColor = Color.FromKnownColor(KnownColor.ControlLight);
		}

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="T:System.Windows.Forms.Control"/> and its child controls and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			boldFont.Dispose();
			underlineFont.Dispose();
			nameFont = null;
			base.Dispose(disposing);
		}

        /// <summary>
        /// Initializes the component.
        /// </summary>
		private void InitializeComponent()
		{
			components = new Container();
		}

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint"/> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs"/> that contains the event data.</param>
		protected override void OnPaint(PaintEventArgs e)
		{
            //  Call the base.
			base.OnPaint(e);

            //  Draw the border.
			e.Graphics.DrawRectangle(Pens.Navy, e.ClipRectangle.Left,
                e.ClipRectangle.Top, e.ClipRectangle.Right - 1, Height - 1);

            //  If we do not have the name bounds, we must set them.
			if (nameBounds.Left == -1)
			{
                //  Set the name bounds.
				nameBounds.X = buttonRectangle.Right + 3;
				nameBounds.Y = buttonRectangle.Top - 2;
				SizeF sizeF = e.Graphics.MeasureString(panelName, boldFont);
				nameBounds.Width = (int)sizeF.Width;
				nameBounds.Height = (int)sizeF.Height;
			}

            //  Draw the title.
			e.Graphics.DrawString(panelName, nameFont, Brushes.Navy, 
                new PointF((float)nameBounds.Left, (float)nameBounds.Top));

            //  Paint the button.
			PaintButton(e);
		}

        /// <summary>
        /// Paints the button.
        /// </summary>
        /// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
		protected void PaintButton(PaintEventArgs e)
		{
			Pen pen = new Pen(this.brushDarkBlue, 1f);
			Pen pen2 = new Pen(Brushes.Blue, 1.5f);
			e.Graphics.FillRectangle(Brushes.White, buttonRectangle);
	        e.Graphics.DrawRectangle(pen, buttonRectangle);
			int num = buttonRectangle.Left + 2;
			int num2 = buttonRectangle.Right - 2;
			int num3 = buttonRectangle.Top + 2;
			int num4 = buttonRectangle.Bottom - 2;
			int num5 = buttonRectangle.Top + buttonRectangle.Height / 2;
			int num6 = buttonRectangle.Left + buttonRectangle.Width / 2;
			e.Graphics.DrawLine(pen, num, num5, num2, num5);
			if (!open)
			{
				e.Graphics.DrawLine(pen, num6, num3, num6, num4);
			}
		}

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
		protected override void OnMouseLeave(EventArgs e)
		{
            //  Update the font.
			if (nameFont != boldFont)
			{
				nameFont = boldFont;
				Invalidate();
			}

            //  Call the base.
			base.OnMouseLeave(e);
		}

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove"/> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"/> that contains the event data.</param>
		protected override void OnMouseMove(MouseEventArgs e)
		{
			if (nameBounds.X != -1)
			{
				Font font = nameFont;
				if (nameBounds.Contains(e.X, e.Y))
				{
					nameFont = underlineFont;
					if (Cursor != Cursors.Hand)
						Cursor = Cursors.Hand;
				}
				else
				{
					nameFont = boldFont;
					if (Cursor != Cursors.Default)
						Cursor = Cursors.Default;
				}

				if (nameFont != font)
					Invalidate();

				base.OnMouseMove(e);
			}
		}

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown"/> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"/> that contains the event data.</param>
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (buttonRectangle.Contains(e.X, e.Y) 
                || nameBounds.Contains(e.X, e.Y))
			{
				ChangeOpenState();
			}

			base.OnMouseDown(e);
		}

        /// <summary>
        /// Changes the state of the open.
        /// </summary>
		protected void ChangeOpenState()
		{
			if (open)
			{
				if (expandedHeight == -1)
					expandedHeight = Height;
				
				open = false;
				SetBounds(0, 0, 0, buttonRectangle.Bottom + 
                    buttonRectangle.Top + 1, BoundsSpecified.Height);
			}
			else
			{
				open = true;
				SetBounds(0, 0, 0, expandedHeight, BoundsSpecified.Height);
			}

			if (panelContainer != null)
				panelContainer.UpdatePanelPositions();

			base.Invalidate();
		}

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
		protected override void OnSizeChanged(EventArgs e)
		{
			if (panelContainer != null)
				panelContainer.UpdatePanelPositions();

			base.OnSizeChanged(e);
		}

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.LocationChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
		protected override void OnLocationChanged(EventArgs e)
		{
			Invalidate();
			base.OnLocationChanged(e);
		}

        /// <summary>
        /// </summary>
        /// <param name="levent">A <see cref="T:System.Windows.Forms.LayoutEventArgs"/> that contains the event data.</param>
		protected override void OnLayout(LayoutEventArgs levent)
		{
			Invalidate();
			base.OnLayout(levent);
		}

        /// <summary>
        /// The child components.
        /// </summary>
        private Container components = null;

        /// <summary>
        /// The name.
        /// </summary>
        private string panelName = "Panel";

        /// <summary>
        /// The current name boundaries.
        /// </summary>
        private Rectangle nameBounds = new Rectangle(-1, -1, -1, -1);

        /// <summary>
        /// The bold font.
        /// </summary>
        private Font boldFont;

        /// <summary>
        /// The underline font.
        /// </summary>
        private Font underlineFont;

        /// <summary>
        /// The name font.
        /// </summary>
        private Font nameFont;

        /// <summary>
        /// The button rectangle.
        /// </summary>
        private Rectangle buttonRectangle = new Rectangle(4, 4, 8, 8);

        /// <summary>
        /// The open flag.
        /// </summary>
        private bool open = true;

        /// <summary>
        /// The dark blue brush.
        /// </summary>
        private Brush brushDarkBlue = new SolidBrush(Color.FromArgb(0, 0, 120));

        /// <summary>
        /// The light blue brush.
        /// </summary>
        private Brush brushLightBlue = new SolidBrush(Color.FromArgb(240, 220, 255));

        /// <summary>
        /// The expanded height.
        /// </summary>
        private int expandedHeight = -1;

        /// <summary>
        /// The parent expanding panel container.
        /// </summary>
        private ExpandingPanelContainer panelContainer = null;

        /// <summary>
        /// Gets or sets the name of the panel.
        /// </summary>
        /// <value>
        /// The name of the panel.
        /// </value>
        public string PanelName
        {
            get
            {
                return panelName;
            }
            set
            {
                //  Set the name, clear the bounds and invalidate.
                panelName = value;
                nameBounds.X = -1;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the panel container.
        /// </summary>
        /// <value>
        /// The panel container.
        /// </value>
        public ExpandingPanelContainer PanelContainer
        {
            get
            {
                return panelContainer;
            }
            set
            {
                //  Set the container.
                panelContainer = value;
                
                //  If the container is set and we are sizing to it, size now.
                if (value != null && SizeWidthToContainer)
                    SetBounds(0, 0, panelContainer.Width - 10, 0, BoundsSpecified.Width);

                //  Re-draw.
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to size the width 
        /// to the parent container.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if we size the width to the container; otherwise, <c>false</c>.
        /// </value>
        public bool SizeWidthToContainer
        {
            get;
            set;
        }
	}
}
