﻿using System;
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

namespace Gallery.Popups
{
    /// <summary>
    /// Interaction logic for PopupsView.xaml
    /// </summary>
    [View(typeof(PopupsViewModel))]
    public partial class PopupsView : UserControl
    {
        public PopupsView()
        {
            InitializeComponent();
        }
    }
}
