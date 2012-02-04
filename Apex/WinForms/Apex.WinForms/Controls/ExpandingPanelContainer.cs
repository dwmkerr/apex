using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Apex.Controls
{
    /// <summary>
    /// The Expanding Panel Container is a container for expanding panels.
    /// </summary>
	public class ExpandingPanelContainer : Panel
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="ExpandingPanelContainer"/> class.
        /// </summary>
		public ExpandingPanelContainer()
		{
            //  Initialise the component.
			InitializeComponent();

            //  Set the default properties.
            BackColor = Color.FromKnownColor(KnownColor.ControlLightLight);
            AutoScroll = true;
		}

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="T:System.Windows.Forms.Control"/> and its child controls and optionally releases the managed resources.
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
        /// Occurs when the control is layed out.
        /// </summary>
        /// <param name="levent">A <see cref="T:System.Windows.Forms.LayoutEventArgs"/> that contains the event data.</param>
		protected override void OnLayout(LayoutEventArgs levent)
		{
			//  Update the panel positions.
            UpdatePanelPositions();

            //  Call the base.
			base.OnLayout(levent);
		}

        /// <summary>
        /// Initializes the component.
        /// </summary>
		private void InitializeComponent()
		{
            //  Create the components object.
			components = new Container();
		}

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.ControlAdded"/> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ControlEventArgs"/> that contains the event data.</param>
		protected override void OnControlAdded(ControlEventArgs e)
		{
            //  If the child control is not an expanding panel, throw an exception.
            if (e.Control is ExpandingPanel != true)
                throw new Exception("Only Expanding Panels can be added to an Expanding Panel Container.");

            //  Call the base.
			base.OnControlAdded(e);

            //  Get the expanding panel, add it to the collection and set its container.
			ExpandingPanel expandingPanel = e.Control as ExpandingPanel;
			expandingPanels.Add(expandingPanel);
			expandingPanel.PanelContainer = this;

            //  Update the positions.
            UpdatePanelPositions();
		}

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.ControlRemoved"/> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ControlEventArgs"/> that contains the event data.</param>
		protected override void OnControlRemoved(ControlEventArgs e)
		{
            //  Are we removing an expanding panel?
			if (e.Control is ExpandingPanel)
			{
                //  Get the expanding panel, remove it, unset the parent.
                ExpandingPanel expandingPanel = e.Control as ExpandingPanel;
				expandingPanels.Remove(expandingPanel);
				expandingPanel.PanelContainer = null;
				
                //  Update the layout.
                UpdatePanelPositions();
			}

            //  Call the base.
			base.OnControlRemoved(e);
		}

        /// <summary>
        /// Updates the panel positions.
        /// </summary>
		public virtual void UpdatePanelPositions()
		{
            //  Get the width and y positions.
			int width = panelSpacing.Width;
			int yPosition = panelSpacing.Height + AutoScrollPosition.Y;

            //  Go through the panels.
            foreach(var panel in expandingPanels)
            {
                //  Set the panel bounds.
				panel.SetBounds(width, yPosition, 0, 0, BoundsSpecified.Location);
				
                //  If we are sizing the panels, set the size now.
                if (sizePanels)
                    panel.SetBounds(0, 0, ClientSize.Width - 2 *
                        panelSpacing.Width, 0, BoundsSpecified.Width);

				//  Update the y position.
				yPosition = yPosition + panel.Height + panelSpacing.Height;
				
			}

            //  Invalidate to redraw the control.
			Invalidate();
        }

        /// <summary>
        /// The set of child components.
        /// </summary>
        private Container components = null;

        /// <summary>
        /// The default panel spacing.
        /// </summary>
        private Size panelSpacing = new Size(4, 4);

        /// <summary>
        /// The 'size panels' flag.
        /// </summary>
        private bool sizePanels = true;

        /// <summary>
        /// The set of child panels.
        /// </summary>
        private List<ExpandingPanel> expandingPanels = new List<ExpandingPanel>();
	}
}
