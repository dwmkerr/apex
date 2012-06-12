using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Interop;
using Apex.Interop;
using System.Runtime.InteropServices;

namespace Apex.Controls
{
    /// <summary>
    /// A Custom Window is a Window that has its chrome entirely
    /// drawn by WPF.
    /// </summary>
    public class CustomShellWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomShellWindow"/> class.
        /// </summary>
        public CustomShellWindow()
        {
            //  Custom shells have no border and no window style.
            ResizeMode = System.Windows.ResizeMode.NoResize;
            WindowStyle = System.Windows.WindowStyle.None;

            SourceInitialized += new EventHandler(CustomShell_SourceInitialized);
        }

        void CustomShell_SourceInitialized(object sender, EventArgs e)
        {
            System.IntPtr handle = (new WindowInteropHelper(this)).Handle;
            HwndSource.FromHwnd(handle).AddHook(new HwndSourceHook(WindowProc));
            dwmapi.DropShadow(handle);
        }

        private static System.IntPtr WindowProc(
              System.IntPtr hwnd,
              int msg,
              System.IntPtr wParam,
              System.IntPtr lParam,
              ref bool handled)
        {
            switch (msg)
            {
                case 0x0024:/* WM_GETMINMAXINFO */
                    WmGetMinMaxInfo(hwnd, lParam);
                    handled = true;
                    break;
            }

            return (System.IntPtr)0;
        }

        private static void WmGetMinMaxInfo(System.IntPtr hwnd, System.IntPtr lParam)
        {
            MINMAXINFO mmi = (MINMAXINFO)Marshal.PtrToStructure(lParam, typeof(MINMAXINFO));

            // Adjust the maximized size and position to fit the work area of the correct monitor
            int MONITOR_DEFAULTTONEAREST = 0x00000002;
            System.IntPtr monitor = User32.MonitorFromWindow(hwnd, MONITOR_DEFAULTTONEAREST);

            if (monitor != System.IntPtr.Zero)
            {

                MONITORINFO monitorInfo = new MONITORINFO();
                User32.GetMonitorInfo(monitor, monitorInfo);
                RECT rcWorkArea = monitorInfo.rcWork;
                RECT rcMonitorArea = monitorInfo.rcMonitor;
                mmi.ptMaxPosition.x = Math.Abs(rcWorkArea.left - rcMonitorArea.left);
                mmi.ptMaxPosition.y = Math.Abs(rcWorkArea.top - rcMonitorArea.top);
                mmi.ptMaxSize.x = Math.Abs(rcWorkArea.right - rcWorkArea.left);
                mmi.ptMaxSize.y = Math.Abs(rcWorkArea.bottom - rcWorkArea.top);
            }

            Marshal.StructureToPtr(mmi, lParam, true);
        }

        /// <summary>
        /// The DependencyProperty for the HasDropShadow property.
        /// </summary>
        private static readonly DependencyProperty HasDropShadowProperty =
          DependencyProperty.Register("HasDropShadow", typeof(bool), typeof(CustomShellWindow),
          new PropertyMetadata(true, new PropertyChangedCallback(OnHasDropShadowChanged)));

        /// <summary>
        /// Gets or sets HasDropShadow.
        /// </summary>
        /// <value>The value of HasDropShadow.</value>
        public bool HasDropShadow
        {
            get { return (bool)GetValue(HasDropShadowProperty); }
            set { SetValue(HasDropShadowProperty, value); }
        }

        /// <summary>
        /// Called when HasDropShadow is changed.
        /// </summary>
        /// <param name="o">The dependency object.</param>
        /// <param name="args">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnHasDropShadowChanged(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            CustomShellWindow me = o as CustomShellWindow;
        }
    }
}
