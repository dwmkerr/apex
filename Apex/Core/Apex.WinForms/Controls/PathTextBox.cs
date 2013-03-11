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

            SizeChanged += (sender, args) => SetBrowseButtonLocation();
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
            browseButton.Click += new EventHandler(browseButton_Click);
            SetBrowseButtonLocation();
            browseButton.CreateControl();
        }

        void browseButton_Click(object sender, EventArgs e)
        {
            //  Create a browse dialog.
            var openFileDialog = new OpenFileDialog()
                {
                    Title = OpenFileDialogTitle,
                    Filter = OpenFileDialogFilter
                };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                Text = openFileDialog.FileName;
        }

        /// <summary>
        /// Sets the browse button location to the right of the control.
        /// </summary>
        private void SetBrowseButtonLocation()
        {
            browseButton.Location = new Point(ClientRectangle.Right - (ButtonWidth + ButtonPadding), ButtonPadding);
        }

        private const int ButtonWidth = 20;
        private const int ButtonPadding = 0;//1;

        private Button browseButton;

        public string OpenFileDialogTitle { get; set; }

        public string OpenFileDialogFilter { get; set; }
    }
}
