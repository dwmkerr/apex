﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace MVVMSample
{
  public partial class MainPage : PhoneApplicationPage
  {
    // Constructor
    public MainPage()
    {
      InitializeComponent();

      DataContext = viewModel;
    }

    private MainViewModel viewModel = new MainViewModel();

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        viewModel.BuildNameCommand.DoExecute(null);
    }
  }
}