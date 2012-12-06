using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Apex.WinForms.Controls
{
    /// <summary>
    /// The Path Text Box is a text box that has a browse button.
    /// </summary>
    public class PathTextBox : TextBox
    {
        /// <summary>
        /// Raises the <see cref="M:System.Windows.Forms.Control.CreateControl"/> method.
        /// </summary>
        protected override void OnCreateControl()
        {
            //  Call the base.
            base.OnCreateControl();

            //  Create the button.
            CreateBrowseButton();
        }

        /// <summary>
        /// Creates the browse button.
        /// </summary>
        private void CreateBrowseButton()
        {
            //  Create the browse button.
            browseButton = new Button();
            browseButton.Parent = this;
            browseButton.Text = "...";
            browseButton.Size = new Size(ButtonWidth, ClientRectangle.Height - (ButtonPadding * 2));
            browseButton.Location = new Point(ClientRectangle.Right - (ButtonWidth + ButtonPadding), ButtonPadding);
            browseButton.CreateControl();
        }

        private const int ButtonWidth = 20;
        private const int ButtonPadding = 0;//1;

        private Button browseButton;
    }
}
