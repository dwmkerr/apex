using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.ComponentModel;
using System.Windows.Data;
using System.Collections.ObjectModel;
using System.Windows;
using System.IO;
using System.Windows.Markup;
using Apex.Extensions;

//  http://social.msdn.microsoft.com/forums/en-US/wpf/thread/f230804d-fc0f-4321-a61e-69a2c890b28d/
//  TODO: Add a dependency property - selectedenumeration
//  then set the datatemplate to show it

namespace Apex.Controls
{
    /// <summary>
    /// A EnumerationComboBox shows a selected enumeration value from a set of all available enumeration values.
    /// If the enumeration value has the 'Description' attribute, this is used.
    /// </summary>
    public class EnumerationComboBox : ComboBox
    {
        /// <summary>
        /// Handles the SelectionChanged event of the EnumerationComboBoxTemp control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Controls.SelectionChangedEventArgs"/> instance containing the event data.</param>
        void EnumerationComboBoxTemp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          //  Get the new item.
          if (e.AddedItems.Count == 0 || e.AddedItems[0] is NameValue == false)
            return;

          //  Keep the selected enumeration up to date.
          NameValue nameValue = e.AddedItems[0] as NameValue;
          SelectedEnumeration = nameValue.Value;
        }

        /// <summary>
        /// Populates the items source.
        /// </summary>
        private void PopulateItemsSource()
        {
            //  We must have an items source and an item which is an enum.
            if (ItemsSource != null || SelectedEnumeration is Enum == false)
                return;

            //  Get the enum type.
            var enumType = SelectedEnumeration.GetType();

            //  Get the enum values. Use the helper rather than Enum.GetValues
          //  as it works in Silverlight too.
            var enumValues = Apex.Helpers.EnumHelper.GetValues(enumType);

            //  Create some enum value/descriptions.
            Enumerations = new List<NameValue>();
          
            //  Go through each one.
            foreach (var enumValue in enumValues)
            {
                //  Add the enumeration item.
              Enumerations.Add(new NameValue(((Enum)enumValue).GetDescription(), enumValue));
            }

            //  Set the items source.
            ItemsSource = Enumerations;

          //  Initialise the control.
            Initialise();
        }

        /// <summary>
        /// Initialises this instance.
        /// </summary>
        private void Initialise()
        {
          //  Set the display member path and selected value path.
          DisplayMemberPath = "Name";
#if !WINDOWS_PHONE
          SelectedValuePath = "Value";
#endif

          //  If we have enumerations and a selected enumeration, set the selected item.
          if (Enumerations != null && SelectedEnumeration != null)
          {
            var selectedEnum = from enumeration in Enumerations where enumeration.Value.ToString() == SelectedEnumeration.ToString() select enumeration;
            this.SelectedItem = selectedEnum.FirstOrDefault();
          }

          //  Wait for selection changed events.
          SelectionChanged += new SelectionChangedEventHandler(EnumerationComboBoxTemp_SelectionChanged);
        }

        /// <summary>
        /// The SelectedEnumerationProperty.
        /// </summary>
        public static readonly DependencyProperty SelectedEnumerationProperty =
          DependencyProperty.Register("SelectedEnumeration", typeof(object), typeof(EnumerationComboBox),
#if !SILVERLIGHT
          new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnSelectedEnumerationChanged)));
#else
        new PropertyMetadata(null, new PropertyChangedCallback(OnSelectedEnumerationChanged)));
#endif

        public object SelectedEnumeration
        {
          get { return (object)GetValue(SelectedEnumerationProperty); }
          set { SetValue(SelectedEnumerationProperty, value); }
        }

        private static void OnSelectedEnumerationChanged(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
          EnumerationComboBox me = o as EnumerationComboBox;

          //  Populate the items source.
          me.PopulateItemsSource();
        }

        public List<NameValue> Enumerations
        {
          get;
          set;
        }
    }

    public class NameValue
    {
      public NameValue()
      {

      }

      public NameValue(string name, object value)
      {
        Name = name;
        Value = value;
      }

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