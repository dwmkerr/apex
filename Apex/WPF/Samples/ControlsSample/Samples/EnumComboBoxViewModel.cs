// -----------------------------------------------------------------------
// <copyright file="EnumComboBoxViewModel.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace ControlsSample.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using Apex.MVVM;

  /// <summary>
  /// TODO: Update summary.
  /// </summary>
  public class EnumComboBoxViewModel : ViewModel
  {

    private NotifyingProperty ExampleEnumerationProperty =
      new NotifyingProperty("ExampleEnumeration", typeof(ExampleEnumeration), ExampleEnumeration.SQLServer);

    public ExampleEnumeration ExampleEnumeration
    {
      get { return (ExampleEnumeration)GetValue(ExampleEnumerationProperty); }
      set { SetValue(ExampleEnumerationProperty, value); }
    }
  }
}
