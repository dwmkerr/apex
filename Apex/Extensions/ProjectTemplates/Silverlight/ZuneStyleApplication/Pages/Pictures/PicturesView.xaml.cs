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
using Apex.MVVM;
using ZuneStyleApplication.ViewModels;
using Apex.Behaviours;

namespace ZuneStyleApplication.Views
{
    /// <summary>
    /// Interaction logic for PicturesView.xaml
    /// </summary>
    [View(typeof(PicturesViewModel))]
    public partial class PicturesView : UserControl, IView
    {
        public PicturesView()
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
