using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using Microsoft.Win32;

namespace Apex.Controls
{
    /// <summary>
    /// The PathTextBox is a textbox that contains an elipses button that allows the user
    /// to browse for files.
    /// </summary>
    [TemplatePart(Name = "PART_BrowseButton", Type = typeof(Label))]
    public class PathTextBox : TextBox
    {
        /// <summary>
        /// Initializes the <see cref="PathTextBox"/> class.
        /// </summary>
        static PathTextBox()
        {
            //  Override the default style. 
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PathTextBox), new FrameworkPropertyMetadata(typeof(PathTextBox)));
        }

        /// <summary>
        /// Is called when a control template is applied.
        /// </summary>
        public override void OnApplyTemplate()
        {
            //  Call the base.
            base.OnApplyTemplate();

            try
            {
                //  Get the cue labe.
                browseButton = (Button)GetTemplateChild("PART_BrowseButton");
            }
            catch
            {
                throw new Exception("Unable to access the internal elements of the PathTextBox.");
            }

            //  Handle the browse button click.
            browseButton.Click += new RoutedEventHandler(browseButton_Click);
        }

        /// <summary>
        /// Handles the Click event of the browseButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        void browseButton_Click(object sender, RoutedEventArgs e)
        {
            var fileOpenDialog = new OpenFileDialog();
            if (fileOpenDialog.ShowDialog() == true)
                Text = fileOpenDialog.FileName;
        }

        /// <summary>
        /// The browse button.
        /// </summary>
        private Button browseButton;
    }
}
