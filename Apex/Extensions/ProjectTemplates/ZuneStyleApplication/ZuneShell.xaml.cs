using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using Apex.Shells;

namespace ZuneStyleApplication
{
    /// <summary>
    /// Interaction logic for ZuneShell.xaml
    /// </summary>
    public partial class ZuneShell : CustomShell
    {
        public ZuneShell()
        {
            InitializeComponent();
        }        

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void maximizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = System.Windows.WindowState.Maximized;
        }

        private void restoreButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = System.Windows.WindowState.Normal;
        }

        private void minimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = System.Windows.WindowState.Minimized;
        }

        private void borderWindowTitle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //  Is it a double click?
            if (e.ClickCount == 2)
            {
                //  Toggle between maximized and normal.
                WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
            }

            //  Is it a drag?
            if (e.ClickCount == 1)
                DragMove();
        }

        private void thumbDiagonal_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            var desiredWidth = Width + e.HorizontalChange;
            var desiredHeight = Height + e.VerticalChange;
            Width = Math.Floor(
        }

        private void thumbTopLeft_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            var desiredLeft = Left + e.HorizontalChange;
            var desiredTop = Top + e.VerticalChange;
            var desiredWidth = Width - e.HorizontalChange;
            var desiredHeight = Height - e.VerticalChange;
        }

        private void thumbTop_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            var desiredTop = Top + e.VerticalChange;
            var desiredHeight = Height - e.VerticalChange;
        }

        private void thumbTopRight_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            var desiredTop = Top + e.VerticalChange;
            var desiredHeight = Height - e.VerticalChange;
            var desiredWidth = Width + e.HorizontalChange;
        }

        private void thumbLeft_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            var desiredLeft = Left + e.HorizontalChange;
            var desiredWidth = Width - e.HorizontalChange;
        }

        private void thumbRight_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            var desiredWidth = Width + e.HorizontalChange;
        }

        private void thumbBottomLeft_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            var desiredLeft = Left + e.HorizontalChange;
            var desiredWidth = Width - e.HorizontalChange;
            var desiredHeight = Height + e.VerticalChange;
        }

        private void thumbBottom_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            var desiredHeight = Height + e.VerticalChange;
        }

        private void thumbBottomRight_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            var desiredWidth = Width + e.HorizontalChange;
            var desiredHeight = Height + e.VerticalChange;
        }
    }
}
