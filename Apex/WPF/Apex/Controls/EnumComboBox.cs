// -----------------------------------------------------------------------
// <copyright file="EnumComboBox.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Apex.Controls
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Windows.Controls;
  using System.ComponentModel;
using System.Windows.Data;
using System.Collections.ObjectModel;
  using Apex.Data;
  using System.Windows;

  /// <summary>
  /// TODO: Update summary.
  /// </summary>
  public class EnumComboBox : ComboBox
  {
    public EnumComboBox()
    {
      ItemsSource = enumerationItems;

   /*   DependencyPropertyDescriptor propertyDescriptor = DependencyPropertyDescriptor.FromProperty(SelectedItemProperty, GetType());
      propertyDescriptor.AddValueChanged(this, 
        delegate 
        {
          this.OnEnumerationChanged();
        });*/
    }

    public void TODO()
    {
      OnEnumerationChanged();
    }

    private void OnEnumerationChanged()
    {
    }

    private void BuildEnumerationValues(Type enumType)
    {
      //  Get the enum values.
      var enumValues = Enum.GetValues(enumType);

      //  Go through each one.
      foreach (var enumValue in enumValues)
      {
        //  Add the enumeration item.
        enumerationItems.Add(new EnumerationItem()
        {
          Value = enumValue,
          Name = GetEnumName(enumType, enumValue)
        });
      }      
    }

    private string GetEnumName(Type enumType, object enumValue)
    {
      var descriptionAttribute = enumType
        .GetField(enumValue.ToString())
        .GetCustomAttributes(typeof(ApexEnumValueAttribute), false)
        .FirstOrDefault() as ApexEnumValueAttribute;


      return descriptionAttribute != null
        ? descriptionAttribute.Name
        : enumValue.ToString();
    }

    /// <summary>
    /// The enumeration items.
    /// </summary>
    private ObservableCollection<EnumerationItem> enumerationItems = new ObservableCollection<EnumerationItem>();

    /// <summary>
    /// The SelectedEnum dependency property.
    /// </summary>
    private static readonly DependencyProperty SelectedEnumProperty =
      DependencyProperty.Register("SelectedEnum", typeof(object), typeof(EnumComboBox),
      new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
        new PropertyChangedCallback(OnSelectedEnumChanged)));

    public object SelectedEnum
    {
      get { return (object)GetValue(SelectedEnumProperty); }
      set { SetValue(SelectedEnumProperty, value); }
    }

    private static void OnSelectedEnumChanged(DependencyObject o, DependencyPropertyChangedEventArgs args)
    {
      EnumComboBox me = o as EnumComboBox;

      //  Only build the ItemsSource if we haven't done so already.
      if (me.enumerationItems == null)
      {
        if (args.NewValue is Enum == false)
          return;

        Binding binding = new Binding("SelectedEnum")
        {
          Mode = BindingMode.TwoWay,
          Source = me,
        };
        me.SetBinding(ComboBox.SelectedItemProperty, binding);

        //  Create the new enumeration items.
        me.enumerationItems = new ObservableCollection<EnumerationItem>();

        //  Enumerate the enum values.
        me.BuildEnumerationValues(args.NewValue.GetType());

        //  Set the items source.
        me.ItemsSource = me.enumerationItems;
        me.DisplayMemberPath = "Name";
      }
    }
                
  }

  public class EnumerationItem
  {
    public string Name
    {
      get;
      set;
    }

    public object Value
    {
      get;
      set;
    }
  }
}
