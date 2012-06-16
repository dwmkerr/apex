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
using Apex;
using Apex.MVVM;
using ZuneStyleApplication.ViewModels;
using Apex.Behaviours;
using ZuneStyleApplication.Views;

namespace ZuneStyleApplication.Pages.TheModel
{
    /// <summary>
    /// Interaction logic for TheModelView.xaml
    /// </summary>
    [View(typeof(TheModelViewModel))]
    public partial class TheModelView : UserControl, IView
    {
        public TheModelView()
        {
            InitializeComponent();
        }

        public void OnActivated()
        {
            //  Fade in all of the elements.
            SlideFadeInBehaviour.DoSlideFadeIn(this);
        }

        public void OnDeactivated()
        {
        }
    }
}
