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
using Apex.Controls;
using Apex.MVVM;
using Apex.Behaviours;

namespace MVVMSample.ViewBrokerActivationSample
{
    /// <summary>
    /// Interaction logic for Page1View.xaml
    /// </summary>
    [View(typeof(Page1ViewModel))]
    public partial class Page1View : UserControl, IView
    {
        public Page1View()
        {
            InitializeComponent();
        }

        public void OnActivated()
        {
            //  Do the fade in.
            SlideFadeInBehaviour.DoSlideFadeIn(this);
        }

        public void OnDeactivated()
        {
        }
    }
}
